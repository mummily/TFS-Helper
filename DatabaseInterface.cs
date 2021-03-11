using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TFS_Helper
{
    /// <summary>
    /// 数据库操作接口封装类
    /// </summary>
    public class DatabaseInterface
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DatabaseInterface()
        {
        }

        /// <summary>
        /// 添加记录到数据库
        /// </summary>
        /// <param name="recordObj"></param>
        /// <returns></returns>
        public static int AddRecord(DBRecord recordObj)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO review_record_tbl(tfs_id, group_name, coder, code_date, reviewer, review_date, code_line, content)");
                sb.Append("VALUES(?tfs_id,?group_name,?coder,?code_date,?reviewer,?review_date,?code_line,?content)");
                MySqlParameter[] parameters = {
                    new MySqlParameter("?tfs_id", MySqlDbType.Int32),
                    new MySqlParameter("?group_name", MySqlDbType.String),
                    new MySqlParameter("?coder", MySqlDbType.String),
                    new MySqlParameter("?code_date", MySqlDbType.Date),
                    new MySqlParameter("?reviewer", MySqlDbType.String),
                    new MySqlParameter("?review_date", MySqlDbType.Date),
                    new MySqlParameter("?code_line", MySqlDbType.Int32),
                    new MySqlParameter("?content", MySqlDbType.String)
                };

                parameters[0].Value = recordObj.m_iTfsID;
                parameters[1].Value = recordObj.m_strGroupName;
                parameters[2].Value = recordObj.m_strCoder;
                parameters[3].Value = recordObj.m_strCodeDate;
                parameters[4].Value = recordObj.m_strReviewer;
                parameters[5].Value = recordObj.m_strReviewDate;
                parameters[6].Value = recordObj.m_iReviewLine;
                parameters[7].Value = recordObj.m_strContent;

                return SQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameters);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改指定的记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static int ModRecord(int id, string strContent)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE review_record_tbl SET content = ?content WHERE id = ?id");
                MySqlParameter[] parameters = {
                    new MySqlParameter("?content", MySqlDbType.String),
                    new MySqlParameter("?id", MySqlDbType.Int32)
                };

                parameters[0].Value = strContent;
                parameters[1].Value = id;
                return SQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameters);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static MySqlDataReader SearchRecord(DBSearchCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            List<MySqlParameter> paramList = new List<MySqlParameter>();

            try
            {
                sb.Append("SELECT * FROM review_record_tbl");

                sb.Append(" WHERE ");
                if (condition.m_iId != -1)
                {
                    sb.Append("id = ?id AND ");
                    MySqlParameter param = new MySqlParameter("?id", MySqlDbType.Int32);
                    param.Value = condition.m_iId;
                    paramList.Add(param);
                }
                if (condition.m_iTfsId != -1)
                {
                    sb.Append("tfs_id = ?tfs_id AND ");
                    MySqlParameter param = new MySqlParameter("?tfs_id", MySqlDbType.Int32);
                    param.Value = condition.m_iTfsId;
                    paramList.Add(param);
                }
                if (condition.m_strGroupName != "")
                {
                    sb.Append("group_name = ?group_name AND ");
                    MySqlParameter param = new MySqlParameter("?group_name", MySqlDbType.String);
                    param.Value = condition.m_strGroupName;
                    paramList.Add(param);
                }
                if (condition.m_strCoder != "")
                {
                    sb.Append("coder = ?coder AND ");
                    MySqlParameter param = new MySqlParameter("?coder", MySqlDbType.String);
                    param.Value = condition.m_strCoder;
                    paramList.Add(param);
                }
                if (condition.m_strReviewer != "")
                {
                    sb.Append("reviewer = ?reviewer AND ");
                    MySqlParameter param = new MySqlParameter("?reviewer", MySqlDbType.String);
                    param.Value = condition.m_strReviewer;
                    paramList.Add(param);
                }
                if (condition.m_strReviewDateStart != "")
                {
                    sb.Append("Date(review_date) >= Date(?review_date) AND ");
                    MySqlParameter param = new MySqlParameter("?review_date", MySqlDbType.Date);
                    param.Value = condition.m_strReviewDateStart.ToString();
                    paramList.Add(param);
                }
                if (condition.m_strReviewDateEnd != "")
                {
                    sb.Append("Date(review_date) <= Date(?review_date_end) AND ");
                    MySqlParameter param = new MySqlParameter("?review_date_end", MySqlDbType.Date);
                    param.Value = condition.m_strReviewDateEnd;
                    paramList.Add(param);
                }
                sb.Append(" 1 = 1 ");

                //排序
                sb.Append(" ORDER BY id");
                return SQLHelper.ExecuteReader(sb.ToString(), CommandType.Text, paramList.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// 检索条件
    /// </summary>
    public class DBSearchCondition
    {
        public int m_iId;
        public int m_iTfsId;
        public string m_strGroupName;
        public string m_strCoder;
        public string m_strReviewer;
        public string m_strReviewDateStart;
        public string m_strReviewDateEnd;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DBSearchCondition()
        {
            m_iId = -1;
            m_iTfsId = -1;
            m_strGroupName = "";
            m_strCoder = "";
            m_strReviewer = "";
            m_strReviewDateStart = "";
            m_strReviewDateEnd = "";
        }
    }

    /// <summary>
    /// 数据库记录集信息 
    /// </summary>
    public class DBRecord
    {
        public int m_iTfsID;
        public string m_strGroupName;
        public string m_strCoder;
        public string m_strCodeDate;
        public string m_strReviewer;
        public string m_strReviewDate;
        public int m_iReviewLine;
        public string m_strContent;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DBRecord()
        {
            m_iTfsID = 0;
            m_strGroupName = "";
            m_strCoder = "";
            m_strCodeDate = "";
            m_strReviewer = "";
            m_strReviewDate = "";
            m_iReviewLine = 0;
            m_strContent = "";
        }
    }
}
