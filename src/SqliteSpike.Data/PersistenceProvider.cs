using System.Collections.Generic;
using NHibernate;

namespace SqliteSpike.Data
{
    public class PersistenceProvider<T> where T:class
    {
        public void Save(T objectToSave)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(objectToSave);
                    transaction.Commit();
                    session.Flush();
                }
            }
        }

        public IList<T> FetchAll()
        {
            IList<T> objectsToReturn;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                objectsToReturn = session.QueryOver<T>().List();
            }

            return objectsToReturn;
        }

    }
}
