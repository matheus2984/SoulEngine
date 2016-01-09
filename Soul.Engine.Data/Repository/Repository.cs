using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Soul.Engine.Data.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        public void Insert(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.Transaction)
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Error to insert in database: " + ex.Message);
                    }
                }
            }
        }

        public void Delete(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Error to delete in database: " + ex.Message);
                    }
                }
            }
        }

        public void Update(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Error to update in database: " + ex.Message);
                    }
                }
            }
        }

        public T GetById(int id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> Query()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return (from x in session.Query<T>() select x).ToList();
            }
        }
    }
}
