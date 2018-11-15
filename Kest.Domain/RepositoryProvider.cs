using Kest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kest.Domain
{
    public class RepositoryProvider
    {
        static RepositoryProvider()
        {
            Factory = GetService<IRepositoryFactory>("RepositoryProvider", "Kest.Infrastruct.Data.dll");
            if (Factory == null) throw new ApplicationException("未找到存储提供者");
        }

        public static IRepositoryFactory Factory { get; private set; }

        private static T GetService<T>(string providerKey, string defaultProvider)
        {
            string fileName = ConfigurationManager.AppSettings[providerKey];
            if (string.IsNullOrEmpty(fileName)) fileName = defaultProvider;
            if (!Path.IsPathRooted(fileName)) fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            Assembly asm = Assembly.LoadFrom(fileName);

            string typeName = typeof(T).FullName;

            Type[] types = asm.GetExportedTypes();
            foreach (Type type in types)
            {
                if (type.GetInterface(typeName) != null && type.IsClass && !type.IsAbstract)
                {
                    T instance = (T)Activator.CreateInstance(type);
                    return instance;
                }
            }

            return default(T);
        }
    }
}
