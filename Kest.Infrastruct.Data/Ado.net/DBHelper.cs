using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Kest.Infrastruct.Data.Ado.net
{
    public static class DBHelper
    {

        public static Database MainDatabase
        {
            get {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                return factory.CreateDefault();
            }
        }
        public static DbConnection MainDbConnection
        {
            get {
                return MainDatabase.CreateConnection();
            }
        }
        public static bool IsNullOrDBNull(object o)
        {
            return o == null || o == DBNull.Value;
        }

        public static int SimpleExecuteNonQuery(string SQLString)
        {
            return MainDatabase.ExecuteNonQuery(CommandType.Text, SQLString);
        }

        public static int SimpleExecuteNonQuery(DbCommand command)
        {
            return MainDatabase.ExecuteNonQuery(command);
        }

        public static int LongTimeExecuteNonQuery(string SQLString)
        {
            int EffectRows = 0;
            using (DbCommand command = MainDbConnection.CreateCommand())
            {
                command.Connection.Open();
                command.CommandTimeout = 6000;
                command.CommandText = SQLString;
                EffectRows = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return EffectRows;
        }

        public static object LongTimeExecuteScalar(string SQLString)
        {
            object ReturnObject = null;
            using (DbCommand command = MainDbConnection.CreateCommand())
            {
                command.Connection.Open();
                command.CommandTimeout = 6000;
                command.CommandText = SQLString;
                ReturnObject = command.ExecuteScalar();
                command.Connection.Close();
            }
            return ReturnObject;
        }

        public static int LongTimeExecuteNonQueryFromCommand(string SQLString, Hashtable sqlparams)
        {
            int EffectRows = 0;
            using (DbCommand command = MainDbConnection.CreateCommand())
            {
                command.Connection.Open();
                command.CommandTimeout = 6000;
                command.CommandText = SQLString;
                if (sqlparams != null)
                {
                    foreach (DictionaryEntry param in sqlparams)
                    {
                        command.Parameters.Add(GetNewDbParameter(param.Key.ToString(), param.Value));
                    }
                }
                EffectRows = command.ExecuteNonQuery();
                command.Connection.Close();
            }

            return EffectRows;
        }

        public static object LongTimeExecuteScalarFromCommand(string SQLString, Hashtable sqlparams)
        {
            object ReturnObject = null;
            using (DbCommand command = MainDbConnection.CreateCommand())
            {
                command.Connection.Open();
                command.CommandTimeout = 6000;
                command.CommandText = SQLString;
                if (sqlparams != null)
                {
                    foreach (DictionaryEntry param in sqlparams)
                    {
                        command.Parameters.Add(GetNewDbParameter(param.Key.ToString(), param.Value));
                    }
                }
                ReturnObject = command.ExecuteScalar();
                command.Connection.Close();
            }

            return ReturnObject;
        }

        public static IDataReader SimpleExecuteReader(string SQLString)
        {
            return MainDatabase.ExecuteReader(CommandType.Text, SQLString);
        }

        public static object SimpleExecuteScalar(string SQLString)
        {
            return MainDatabase.ExecuteScalar(CommandType.Text, SQLString);
        }

        public static DataSet SimpleExecuteDataSet(string SQLString)
        {
            return MainDatabase.ExecuteDataSet(CommandType.Text, SQLString);
        }

        public static DataTable SimpleExecuteDataTable(string SQLString, CommandType CType = CommandType.Text)
        {
            DataSet ds = MainDatabase.ExecuteDataSet(CType, SQLString);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
       
        public static DbCommand GetNewDbCommand()
        {

            return MainDatabase.DbProviderFactory.CreateCommand();
        }

        public static DbParameter GetNewDbParameter()
        {
            return MainDatabase.DbProviderFactory.CreateParameter();
        }
        public static DbParameter GetNewDbParameter(string parametername, object parametevalue, DbType parametetype = DbType.Object)
        {
            DbParameter p = MainDatabase.DbProviderFactory.CreateParameter();
            p.ParameterName = parametername;
            p.Value = parametevalue;
            if (parametetype != DbType.Object)
            {
                p.DbType = parametetype;
            }

            return p;
        }
        public static void ExecSQLList(List<string> SQLList, bool logRec = true)
        {
            StringBuilder sb = new StringBuilder(4000);
            string SQLText = "";
            foreach (string sql in SQLList)
            {
                sb.Append(sql + "\n");
            }
            SQLText = sb.ToString();
            DbCommand command = MainDatabase.DbProviderFactory.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = SQLText;
            command.CommandTimeout = 300;
            MainDatabase.ExecuteNonQuery(command);
            command.Connection.Close();
        }

    }
}
