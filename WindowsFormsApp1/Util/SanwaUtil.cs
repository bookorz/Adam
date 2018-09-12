using log4net;
using SANWA.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adam.Util
{
    static class SanwaUtil
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SanwaUtil));
        static public string GetArmID(string arm)
        {
            Dictionary<string, string> armMap = new Dictionary<string, string>();
            armMap["Upper"] = "1";
            armMap["Lower"] = "2";
            armMap["Both"] = "3";
            armMap["R"] = "1";
            armMap["L"] = "2";
            return armMap[arm];
        }
        static public void addActionLog(string function_type, string action_type, string action_user)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("\n INSERT INTO log_system_action");
                sql.Append("\n   (action_id, function_type, action_type, action_user, action_time)");
                sql.Append("\n  SELECT UUID(), @function_type, @action_type, @action_user, CURRENT_TIMESTAMP(6)");

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@function_type", function_type);
                param.Add("@action_type", action_type);
                param.Add("@action_user", action_user);

                //Query
                DBUtil dBUtil = new DBUtil();
                dBUtil.ExecuteNonQuery(sql.ToString(), param);
                dBUtil = null;
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }


        }
        static public void addActionLog(string function_type, string action_type, string action_user, string remark)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("\n INSERT INTO log_system_action");
                sql.Append("\n     (action_id, function_type, action_type, remark, action_user, action_time)");
                sql.Append("\n  SELECT UUID(), @function_type, @action_type, @remark, @action_user, CURRENT_TIMESTAMP(6)");

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@function_type", function_type);
                param.Add("@action_type", action_type);
                param.Add("@action_user", action_user);
                param.Add("@remark", remark);

                //Query
                DBUtil dBUtil = new DBUtil();
                dBUtil.ExecuteNonQuery(sql.ToString(), param);
                dBUtil = null;
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }


        }
        static public void addPartition()
        {
            try
            {
                StringBuilder qrySql = new StringBuilder();
                qrySql.Append("\n SELECT CAST(t_name AS CHAR) t_name,CAST(p_name AS CHAR) p_name,CAST(max_date AS CHAR) max_date ");
                qrySql.Append("\n   FROM view_new_partition");
                qrySql.Append("\n  ORDER BY t_name, max_date;");
                Dictionary<string, object> param = new Dictionary<string, object>();

                //Query
                DBUtil dBUtil = new DBUtil();
                DataTableReader rs = dBUtil.GetDataReader(qrySql.ToString(), param);
                if (rs != null)
                {
                    while (rs.Read())
                    {
                        string t_name = (string)rs["t_name"];
                        string p_neme = (string)rs["p_name"];
                        string max_date = (string)rs["max_date"];
                        StringBuilder updSql = new StringBuilder();
                        updSql.Append("\n ALTER TABLE " + t_name + " REORGANIZE PARTITION p_future");
                        updSql.Append("\n  INTO(");
                        updSql.Append("\n       PARTITION " + p_neme + "  VALUES LESS THAN(UNIX_TIMESTAMP('" + max_date + "')),");
                        updSql.Append("\n       PARTITION p_future VALUES LESS THAN MAXVALUE");
                        updSql.Append("\n  );");
                        dBUtil.ExecuteNonQuery(updSql.ToString(), param);//split p_future => 2 partition
                    }
                    rs.Close();
                }
                dBUtil = null;
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        static public void dropPartition()
        {
            try
            {
                StringBuilder qrySql = new StringBuilder();
                qrySql.Append("\n SELECT CAST(table_name AS CHAR) AS t_name, CAST(partition_name AS CHAR) AS p_name");
                qrySql.Append("\n   FROM view_drop_partition");
                qrySql.Append("\n  ORDER BY table_name, partition_name;");
                Dictionary<string, object> param = new Dictionary<string, object>();

                //Query
                DBUtil dBUtil = new DBUtil();
                DataTableReader rs = dBUtil.GetDataReader(qrySql.ToString(), param);
                if (rs != null)
                {
                    while (rs.Read())
                    {
                        string t_name = (string)rs["t_name"];
                        string p_name = (string)rs["p_name"];
                        StringBuilder updSql = new StringBuilder();
                        updSql.Append("\n  ALTER TABLE ");
                        updSql.Append( t_name );
                        updSql.Append("  DROP PARTITION ");
                        updSql.Append( p_name );
                        updSql.Append(";");
                        dBUtil.ExecuteNonQuery(updSql.ToString(), param);//drop expired partition table
                    }
                    rs.Close();
                }
                dBUtil = null;
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }
    }
}
