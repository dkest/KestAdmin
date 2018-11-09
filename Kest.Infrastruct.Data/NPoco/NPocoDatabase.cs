using NPoco;
using NPoco.FluentMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kest.Infrastruct.Data.NPoco
{
    internal sealed class NPocoDatabase:Database
    {
        private static DatabaseFactory factory;

        static NPocoDatabase()
        {
            factory = DatabaseFactory.Config(x => {
                x.UsingDatabase(() => new NPocoDatabase("DB"));
                x.WithFluentConfig(FluentMappingConfiguration.Configure(new NPocoDatabaseMappings()));
            });
        }

        [ThreadStatic]
        private static Database instance;

        public static Database Instance
        {
            get {
                if (instance == null) instance = factory.GetDatabase();
                return instance;
            }
        }

        public DkDatabase(string connectionStringName)
            : base(connectionStringName)
        {
            this.EnableAutoSelect = true;
        }

        protected override void OnException(Exception ex)
        {
            //LoggerProvider.Logger.Error(ex, "正在执行SQL语句: {0}", this.LastCommand);
            base.OnException(ex);
        }
    }
}
}
