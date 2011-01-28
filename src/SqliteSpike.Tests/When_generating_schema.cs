using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SqliteSpike.Entities;

namespace SqliteSpike.Tests
{
    [TestFixture]
    public class When_generating_schema
    {
        [Test]
        public void Should_save_schema_to_file()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            var schemaExport = new SchemaExport(cfg);
            schemaExport.SetOutputFile("../../GeneratedSchema/schema.sql");
            schemaExport.Create(true, true);
        }    
    }
}