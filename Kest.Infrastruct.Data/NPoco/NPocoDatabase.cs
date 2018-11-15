using System;

using NPoco;
using NPoco.FluentMappings;

namespace Kest.Infrastruct.Data.NPoco
{
    internal sealed class NPocoDatabase:Database
    {
        private static DatabaseFactory factory;

        static NPocoDatabase()
        {
            factory = DatabaseFactory.Config(x => {
                x.UsingDatabase(() => new NPocoDatabase("connectionStringName"));
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

        public NPocoDatabase(string connectionStringName)
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
