using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kest.Infrastruct.Data.Ado.net
{
    public class AutoUpdateDataTable : DataTable
    {
        Database CurrentDatabase;
        public DbDataAdapter DataAdapter;
        public DbCommandBuilder CommandBuilder;

        protected AutoUpdateDataTable()
            : base()
        {
        }

        public AutoUpdateDataTable(Database iniDatabase, string Sqlstring, string tableName, string key = "ID")
            : base()
        {
            CurrentDatabase = iniDatabase;
            if (CurrentDatabase != null)
            {
                DataAdapter = CurrentDatabase.GetDataAdapter();
                DbCommand command = CurrentDatabase.GetSqlStringCommand(Sqlstring);
                command.Connection = CurrentDatabase.CreateConnection();
                DataAdapter.SelectCommand = command;
                CommandBuilder = CurrentDatabase.DbProviderFactory.CreateCommandBuilder();
                CommandBuilder.DataAdapter = DataAdapter;
                CommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;

                this.TableName = tableName;

                DataAdapter.Fill(this);
                if (key == null)
                {
                    DataAdapter.FillSchema(this, SchemaType.Mapped);
                }
                else
                {
                    this.PrimaryKey = new DataColumn[] { this.Columns[key] };
                }
            }

        }

        public AutoUpdateDataTable(Database iniDatabase, DbCommand command, string tableName, string key = "ID")
            : base()
        {
            CurrentDatabase = iniDatabase;
            if (CurrentDatabase != null)
            {
                DataAdapter = CurrentDatabase.GetDataAdapter();
                //DbCommand command = CurrentDatabase.GetSqlStringCommand(Sqlstring);
                command.Connection = CurrentDatabase.CreateConnection();
                DataAdapter.SelectCommand = command;
                CommandBuilder = CurrentDatabase.DbProviderFactory.CreateCommandBuilder();
                CommandBuilder.DataAdapter = DataAdapter;
                CommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;


                this.TableName = tableName;

                DataAdapter.Fill(this);
                if (key == null)
                {
                    DataAdapter.FillSchema(this, SchemaType.Mapped);
                }
                else
                {
                    this.PrimaryKey = new DataColumn[] { this.Columns[key] };
                }
            }

        }

        public void RefreshData()
        {
            if (DataAdapter != null)
            {
                //string Cachekey = this.TableName + "_AUDT" + "_" + DataAdapter.SelectCommand.CommandText;
                ////DataAdapter.SelectCommand.
                //SqlCacheDependency scd = new SqlCacheDependency(DataAdapter.SelectCommand as System.Data.SqlClient.SqlCommand);

                //(DataAdapter.SelectCommand as System.Data.SqlClient.SqlCommand).Notification.
                //System.Data.SqlClient.SqlDependency.Start(
                DataAdapter.Fill(this);

                //StaticDatabaseHelper.SetCache(Cachekey, this, scd);
            }
        }

        public void UpdateTable()
        {
            if (this.GetChanges() != null)
            {

                DataAdapter.Update(this);

            }
        }




    }

    public class AutoUpdateDataSet : DataSet
    {
        Database CurrentDatabase;
        //DbConnection Connection;

        //Dictionary<string, DbDataAdapter> DataAdapters;
        //Dictionary<string, DbCommandBuilder> CommandBuilders;

        public System.Collections.Generic.Dictionary<string, AutoUpdateDataTable> AUDTCollection = new Dictionary<string, AutoUpdateDataTable>();


        public AutoUpdateDataSet(Database iniDatabase)
            : base()
        {
            CurrentDatabase = iniDatabase;
        }

        public AutoUpdateDataSet(Database iniDatabase, string Sqlstring, string tableName)
            : this(iniDatabase)
        {

            if (CurrentDatabase != null)
            {
                AddDataTable(Sqlstring, tableName);
            }

        }

        public void AddDataTable(string Sqlstring, string tableName)
        {
            if (this.Tables.IndexOf(tableName) < 0)
            {
                AutoUpdateDataTable AUDT = new AutoUpdateDataTable(CurrentDatabase, Sqlstring, tableName);
                this.Tables.Add(AUDT);

            }
        }

        public void AddAUDataTable(string Sqlstring, string tableName)
        {
            if (this.Tables.IndexOf(tableName) < 0)
            {
                AutoUpdateDataTable AUDT = new AutoUpdateDataTable(CurrentDatabase, Sqlstring, tableName);
                this.AUDTCollection.Add(tableName, AUDT);
            }
        }

        public void UpdateTable()
        {
            if (this.HasChanges())
            {
                foreach (AutoUpdateDataTable AUDT in this.Tables)
                {
                    AUDT.UpdateTable();
                }
            }
        }
    }
}