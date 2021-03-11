using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TFS_Helper
{
    /// <summary>
    /// TFS窗口信息数据结构定义
    /// </summary>
    public class TFSWindowInfo
    {
        // 资源组名称
        public string m_strGroupName;

        // 注释控件
        public IntPtr m_hContentCtrl;
        public string m_strContent;

        // 变更集ID
        public IntPtr m_hIDCtrl;
        public int m_iID;

        // 用户名称
        public IntPtr m_hCheckinCtrl;
        public string m_strCheckin;

        // 签入日期
        public IntPtr m_hCheckinDateCtrl;
        public string m_strCheckinDate;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TFSWindowInfo()
        {
            m_strGroupName = "";
            m_hContentCtrl = IntPtr.Zero;
            m_strContent = "";
            m_hIDCtrl = IntPtr.Zero;
            m_iID = 0;
            m_hCheckinCtrl = IntPtr.Zero;
            m_strCheckin = "";
            m_hCheckinDateCtrl = IntPtr.Zero;
            m_strCheckinDate = "";
        }
    }

    /// <summary>
    /// 签入信息类定义
    /// </summary>
    public class CheckinRecord
    {
        // 签入类型
        public string m_strType;
        // 签入类型说明
        public string m_strTypeInfo;
        // 签入说明
        public string m_strContent;

        public CheckinRecord()
        {
            m_strType = "";
            m_strTypeInfo = "";
            m_strContent = "";
        }

        public static CheckinRecord GetObjectFormString(string strTFS)
        {
            // 【需求:AAAA】BALABALABALABALA
            CheckinRecord obj = new CheckinRecord();

            // 将Review记录信息剔除
            strTFS = Regex.Split(strTFS, @"【走查者】", RegexOptions.IgnoreCase)[0];

            // 提交代码的集中支持类型
            string[] sArray = null;
            string[] sPatterns = new string[6];
            string strUsePattern = "";
            sPatterns[0] = @"【需求[：|:]{1}.{1,}】";
            sPatterns[1] = @"【BUG[：|:]{1}.{1,}】";
            sPatterns[2] = @"【代码优化[：|:]{1}.{1,}】";
            sPatterns[3] = @"【PC Lint[：|:]{1}.{1,}】";
            sPatterns[4] = @"【走查问题处理[：|:]{1}.{1,}】";
            sPatterns[5] = @"【文档[：|:]{1}.{1,}】";

            int iIdx = 0;
            for (iIdx = 0; iIdx < sPatterns.Count(); ++iIdx)
            {
                sArray = Regex.Split(strTFS, sPatterns[iIdx], RegexOptions.IgnoreCase);
                if (sArray.Count() == 2)
                {
                    strUsePattern = sPatterns[iIdx];
                    break;
                }
            }
            if (strUsePattern == "")
            { // 没有匹配到的信息，格式错误
                return null;
            }

            obj.m_strContent = sArray[1].Trim(); // BALABALABALABALA

            Match matchObj = Regex.Match(strTFS, strUsePattern);
            string strTemp = matchObj.Value;                        // 【需求:AAAA】
            strTemp = strTemp.Substring(1, strTemp.Length - 2);     // 需求:AAAA
            string[] sArray2 = Regex.Split(strTemp, "[：|:]", RegexOptions.IgnoreCase);
            if (sArray2.Count() != 2)
            { // 格式不正确
                return null;
            }

            obj.m_strType = sArray2[0].Trim();
            obj.m_strTypeInfo = sArray2[1].Trim();

            return obj;
        }

        public static string GetStringFormObject(CheckinRecord obj)
        {
            string strRet = "";
            strRet += "【" + obj.m_strType + "：" + obj.m_strTypeInfo + "】" + obj.m_strContent;

            return strRet;
        }
    }

    /// <summary>
    /// Review信息数据结构定义
    /// </summary>
    public class ReviewRecord
    {
        // 变更集ID
        public string m_strTFSId;
        // 走查日期
        public string m_strReviewDate;
        // 走查人
        public string m_strReviewer;
        // 走查行数
        public int m_iReviewLine;
        // 签入者
        public string m_strCoder;
        // Review OK?
        public bool m_bResultFlag;

        // 问题列表，一次可能Review多个问题
        public List<QuestionRecord> m_QuestionList;

        // 构造函数
        public ReviewRecord()
        {
            m_strTFSId = "";
            m_strReviewDate = "";
            m_strReviewer = "";
            m_iReviewLine = 0;
            m_strCoder = "";
            m_bResultFlag = false;

            m_QuestionList = new List<QuestionRecord>();
        }

        public static ReviewRecord GetObjectFormString(string strReview)
        {
            // 有问题记录的Review信息字符串格式:
            // 【走查者】赵利平
            // 【走查时间】2018年2月28日
            // 【走查行数】100
            // 【1】[类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充
            //
            // 无问题记录的Review信息字符串格式:
            // 【走查者】赵利平
            // 【走查时间】2018年2月28日
            // 【走查行数】100
            // 【走查结果】通过

            ReviewRecord obj = new ReviewRecord();
            string[] sArray = Regex.Split(strReview, @"【.*?】", RegexOptions.IgnoreCase);
            if (sArray.Count() < 5)
            {
                return null;
            }
            obj.m_strReviewer = sArray[1].Trim();
            obj.m_strReviewDate = sArray[2].Trim();
            obj.m_iReviewLine = int.Parse(sArray[3]);
            if (sArray[4].Trim().Replace("\r\n", "") == "通过")
            { // Review通过的记录
                obj.m_bResultFlag = true;
                obj.m_QuestionList.Clear();
                return obj;
            }

            // 问题列表
            for (int iIdx = 4; iIdx < sArray.Count(); ++iIdx)
            {
                QuestionRecord questionObj = QuestionRecord.GetObjectFormString(sArray[iIdx].Trim());
                if (questionObj == null)
                {
                    return null;
                }

                obj.m_QuestionList.Add(questionObj);
            }

            return obj;
        }

        public static string GetStringFormObject(ReviewRecord obj)
        {
            // 有问题记录的Review信息字符串格式:
            // 【走查者】赵利平
            // 【走查时间】2018年2月28日
            // 【走查行数】100
            // 【1】[类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充
            //
            // 无问题记录的Review信息字符串格式:
            // 【走查者】赵利平
            // 【走查时间】2018年2月28日
            // 【走查行数】100
            // 【走查结果】通过

            string strReview = "【走查者】" + obj.m_strReviewer + "\r\n" +
                "【走查时间】" + obj.m_strReviewDate + "\r\n" +
                "【走查行数】" + obj.m_iReviewLine.ToString() + "\r\n";
            if (obj.m_bResultFlag)
            {
                strReview += "【走查结果】通过";
            }
            else
            {
                // 遍历所有问题
                for (int iIdx = 0; iIdx < obj.m_QuestionList.Count; ++iIdx)
                {
                    string strQuestion = QuestionRecord.GetStringFormObject(obj.m_QuestionList[iIdx]);
                    strReview += "【" + (iIdx + 1).ToString() + "】" + strQuestion;

                    if (iIdx != obj.m_QuestionList.Count - 1)
                    {
                        strReview += "\r\n";
                    }
                }
            }

            return strReview;
        }
    }

    /// <summary>
    /// 问题信息结构体定义
    /// </summary>
    public class QuestionRecord
    {
        // 模块名称
        public string m_strModuleName;
        // 问题类型
        public string m_strType;
        // 问题级别
        public string m_strLevel;
        // 问题状态
        public string m_strStatus;
        // 位置
        public string m_strLocation;
        // 问题描述
        public string m_strQDes;
        // 修改描述
        public string m_strADes;

        // 构造函数
        public QuestionRecord()
        {
            m_strModuleName = "";
            m_strType = "";
            m_strLevel = "";
            m_strStatus = "打开";
            m_strLocation = "";
            m_strQDes = "";
            m_strADes = "请补充";
        }

        public static QuestionRecord GetObjectFormString(string strQuestion)
        {
            // [类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充
            // strQuestion = "[类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充";
            QuestionRecord obj = new QuestionRecord();
            string[] sArray = Regex.Split(strQuestion, @"\[.*?\]", RegexOptions.IgnoreCase);
            if (sArray.Count() != 8)
            {
                return null;
            }

            // 第一个是空串，从第二个开始处理
            obj.m_strType = sArray[1].Trim();
            obj.m_strLevel = sArray[2].Trim();
            obj.m_strStatus = sArray[3].Trim();
            obj.m_strModuleName = sArray[4].Trim();
            obj.m_strLocation = sArray[5].Trim();
            obj.m_strQDes = sArray[6].Trim();
            obj.m_strADes = sArray[7].Trim();

            return obj;
        }

        public static string GetStringFormObject(QuestionRecord obj)
        {
            // [类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充
            if (obj == null)
            {
                MessageBox.Show("null");
                return "";
            }
            string strQuestion = "[类型]" + obj.m_strType +
                "[级别]" + obj.m_strLevel +
                "[状态]" + obj.m_strStatus +
                "[模块]" + obj.m_strModuleName +
                "[位置]" + obj.m_strLocation +
                "[问题说明]" + obj.m_strQDes +
                "[修改说明]" + obj.m_strADes;

            return strQuestion;
        }

        /// <summary>
        /// 判断问题是否关闭
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool QuestionIsClose(QuestionRecord obj)
        {
            return obj.m_strStatus == "关闭" || obj.m_strStatus == "不是问题";
        }
    }

    /// <summary>
    /// TFS注释对象,包含签入和Review信息
    /// </summary>
    public class TFSRecord
    {
        // 签入信息
        public CheckinRecord checkinObj;
        // Review信息
        public List<ReviewRecord> reviewObjList;

        public TFSRecord()
        {
            checkinObj = new CheckinRecord();
            reviewObjList = new List<ReviewRecord>();
        }

        // 通过字符串构造对象
        public static TFSRecord GetObjectFormString(string strTFS)
        {
            // 【需求:AAAA】BALABALABALABALA
            // 【走查者】赵利平
            // 【走查时间】2018年2月28日
            // 【走查行数】100
            // 【1】[类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充
            // 【走查者】赵利平
            // 【走查时间】2018年2月28日
            // 【走查行数】100
            // 【走查结果】通过
            // strTFS = @"【需求:AAAA】BALABALABALABALA
            //          【走查者】赵利平
            //          【走查时间】2018年2月28日
            //          【走查行数】100
            //          【1】[类型]实现逻辑[级别]严重[状态]Open[模块]硬件配置[位置]AutoThink.cpp Line:21[问题说明]内存泄露[修改说明]请补充
            //          【走查者】赵利平
            //          【走查时间】2018年2月28日
            //          【走查行数】100
            //          【走查结果】通过";
            TFSRecord obj = new TFSRecord();
            string[] sArray = Regex.Split(strTFS, @"【走查者】", RegexOptions.IgnoreCase);

            // 解析签入信息
            string strCheckin = sArray[0].Trim();
            CheckinRecord checkinObj = CheckinRecord.GetObjectFormString(strCheckin);
            if (checkinObj == null)
            { // 格式出错
                return null;
            }

            obj.checkinObj = checkinObj;

            if (sArray.Count() > 1)
            { // 有Review信息
                int iCount = TFSRecord.GetSReviewCount(strTFS);
                for (int iIdx = 0; iIdx < iCount; ++iIdx)
                {
                    string strReview = TFSRecord.GetReviewStringAt(strTFS, iIdx);
                    ReviewRecord reviewObj = ReviewRecord.GetObjectFormString(strReview);
                    if (reviewObj == null)
                    { // 格式出错
                        return null;
                    }

                    obj.reviewObjList.Add(reviewObj);
                }
            }

            return obj;
        }

        // 通过对象生成格式化字符串
        public static string GetStringFormObject(TFSRecord obj)
        {
            string strRet = "";

            if (obj == null)
            {
                return strRet;
            }

            strRet += CheckinRecord.GetStringFormObject(obj.checkinObj);
            for (int iIdx = 0; iIdx < obj.reviewObjList.Count(); ++iIdx)
            {
                ReviewRecord reviewObj = obj.reviewObjList[iIdx];
                strRet += "\r\n";

                strRet += ReviewRecord.GetStringFormObject(reviewObj);
            }

            return strRet;
        }

        // 获取Review记录个数
        private static int GetSReviewCount(string strRecord)
        {
            string strPattern = @"【走查者】";
            MatchCollection collection = Regex.Matches(strRecord, strPattern, System.Text.RegularExpressions.RegexOptions.Singleline);
            return collection.Count;
        }

        // 取得指定索引的Review记录字符串信息
        private static string GetReviewStringAt(string strRecord, int iIdx)
        {
            string strRet = "";
            string strPattern = @"【走查者】";

            int iFirst = strRecord.IndexOf(strPattern);
            while (iIdx-- > 0)
            {
                iFirst = strRecord.IndexOf(strPattern, iFirst + 1);
            }

            if (iFirst == -1)
            {
                return strRet;
            }

            int iLast = strRecord.IndexOf(strPattern, iFirst + 1);
            if (iLast == -1)
            {
                strRet = strRecord.Substring(iFirst);
            }
            else
            {
                strRet = strRecord.Substring(iFirst, iLast - iFirst);
            }

            return strRet;
        }
    }
}
