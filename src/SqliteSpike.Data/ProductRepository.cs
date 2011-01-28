using System.Collections.Generic;
using NHibernate;
using SqliteSpike.Entities;

namespace SqliteSpike.Data
{
    public class ProductRepository
    {
        public void Save(Product product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(product);
                transaction.Commit();
            }
        }

        public IList<Product> FetchAll()
        {
            IList<Product> products;

            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                products = session.QueryOver<Product>().List();
                transaction.Commit();
            }

            return products;
        }

    }
}
