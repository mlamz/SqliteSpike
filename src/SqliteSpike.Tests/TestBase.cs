using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SqliteSpike.Entities;

namespace SqliteSpike.Tests
{
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            new SchemaExport(cfg).Execute(true, true, false);
        }

        
    }
}