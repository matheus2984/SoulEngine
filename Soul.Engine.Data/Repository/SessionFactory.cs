using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Soul.Engine.Data.Mapping;

namespace Soul.Engine.Data.Repository
{
    internal static class SessionFactory
    {
        private static string ConnectionString = "Server=localhost;Port=3306;Database=senai;Uid=root;Pwd=root;";

        private static ISessionFactory session;

        private static ISessionFactory CreateSession()
        {
            if (session != null)
            {
                return session;
            }

            IPersistenceConfigurer dbConfig = MySQLConfiguration.Standard.ConnectionString(ConnectionString);

            var mapConfig =
                Fluently.Configure()
                    .Database(dbConfig)
                    .Mappings(c => c.FluentMappings.AddFromAssemblyOf<AlunoMap>());

            session = mapConfig.BuildSessionFactory();

            return session;

        }

        public static ISession OpenSession()
        {
            return CreateSession().OpenSession();
        }
    }
}