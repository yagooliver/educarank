using EducaRank.Data.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace EducaRank.Data.Config
{
    public class SessionFactory
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["projeto"].ToString();
        public ISessionFactory CreateSessionFactory()
        {
            try
            {
                var _session = Fluently.Configure().Database(PostgreSQLConfiguration.Standard.Raw("hbm2ddl.keywords", "none")
                    //.ConnectionString(c => c.Host("localhost").Port(5432).Database("educarank").Username("postgres").Password("developer")))
                    .ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EscolaMap>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();

                return _session;
            }
            catch (FluentConfigurationException ex)
            {
                throw ex;
            }
        }

        private static void BuildSchema(Configuration config)
        {
            var update = new SchemaUpdate(config);
            //update.Drop(false,true)
            update.Execute(false, true);
        }
    }
}
