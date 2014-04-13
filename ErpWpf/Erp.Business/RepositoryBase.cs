using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Enum;
using Erp.Business.Validation;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;

namespace Erp.Business
{
    public class RepositoryBase<T> where T : class
    {
        private static ISessionFactory _sessionFactory;

        public static SimpleExpression CriteriaAtivos
        {
            get { return Restrictions.Eq("Status", Status.Ativo); }
        }

        public static SimpleExpression CriteriaBloqueados
        {
            get { return Restrictions.Eq("Status", Status.Bloqueado); }
        }

        public static SimpleExpression CriteriaCancelados
        {
            get { return Restrictions.Eq("Status", Status.Cancelado); }
        }

        protected static string ContainsStringFilter(String filter)
        {
            return "%" + filter + "%";
        }
        protected static string StartStringFilter(String filter)
        {
            return filter + "%";
        }
        protected static string EndStringFilter(String filter)
        {
            return "%" + filter;
        }

        public static ISession Session { get; set; }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = GetSessionFactory();
                }
                return _sessionFactory;
            }
            set { _sessionFactory = value; }
        }


        //public static readonly string _cnnStr = "Server=" + Settings.Default.Server + ";" +
        //                 "Port=" + Settings.Default.Port + ";" +
        //                 "User Id=" + Settings.Default.User + ";" +
        //                 "Password=" + Settings.Default.Password + ";" +
        //                 "Database=" + Settings.Default.Database + ";";


        public static T Save(T entity)
        {
            using (ITransaction transaction = NHibernateHttpModule.Session.BeginTransaction())
            {
                try
                {
                    if (Validate(entity))
                    {
                        NHibernateHttpModule.Session.Save(entity);
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return entity;
        }

        public static bool Validate(T entity)
        {
            EntityValidationResult result = DataValidation.ValidateEntity(entity);
            if (result.HasError)
            {
                throw new Exception(result.MensagemErro());
            }
            return true;
        }


        public T SaveObject(T entity)
        {
            return Save(entity);
        }

        public static T Delete(T entity)
        {
            using (ITransaction transaction = NHibernateHttpModule.Session.BeginTransaction())
            {
                try
                {
                    NHibernateHttpModule.Session.Delete(entity);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return entity;
        }

        public static T Update(T entity)
        {
            using (ITransaction transaction = NHibernateHttpModule.Session.BeginTransaction())
            {
                try
                {
                    if (Validate(entity))
                    {
                        NHibernateHttpModule.Session.Update(entity);
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return entity;
        }

        public static IList<T> SaveCollection(IList<T> collection)
        {
            using (ITransaction transaction = NHibernateHttpModule.Session.BeginTransaction())
            {
                try
                {
                    foreach (var entity in collection)
                    {
                        if (Validate(entity))
                        {
                            NHibernateHttpModule.Session.SaveOrUpdate(entity);
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return collection;
        }
        public static T SaveOrUpdate(T entity)
        {
            using (ITransaction transaction = NHibernateHttpModule.Session.BeginTransaction())
            {
                try
                {
                    if (Validate(entity))
                    {
                        NHibernateHttpModule.Session.SaveOrUpdate(entity);
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return entity;
        }

        public static IList<T> GetEmptyList()
        {
            var ret = new List<T>
            {
                Activator.CreateInstance<T>()
            };
            return ret;
        }

        public static IList<T> GetList()
        {
            return NHibernateHttpModule.Session.QueryOver<T>().List();
        }

        public static IList<T> GetListAtivos()
        {
            return NHibernateHttpModule.Session.CreateCriteria<T>().Add(CriteriaAtivos).List<T>();
        }
        public static IList<T> GetListAtivos(AbstractCriterion expression)
        {
            return NHibernateHttpModule.Session.CreateCriteria<T>().Add(CriteriaAtivos).Add(expression).List<T>();
        }

        public static IList<T> GetListAtivos(IQueryOver<T, T> query)
        {
            query.Where(CriteriaAtivos);
            return query.List<T>();
        }

        public static IList<T> GetList(ICriterion expression)
        {
            IList<T> list = NHibernateHttpModule.Session.QueryOver<T>().Where(expression).List();
            return list;
        }

        public IList<T> GetListObject()
        {
            return GetList();
        }

        public static T GetById(int id)
        {
            return NHibernateHttpModule.Session.Get<T>(id);
        }

        public static T GetById(object id)
        {
            return NHibernateHttpModule.Session.Get<T>(id);
        }

        public T GetObjectById(int id)
        {
            return GetById(id);
        }


        internal static ISessionFactory GetSessionFactory()
        {
            //var cnnStr = "DataSource=localhost; Database=D:\\Firebird\\bonesoft.fdb; UserId=SYSDBA; Pwd=masterkey";
            if (_sessionFactory == null)
            {
                //var strCnn = "Server=localhost;" +
                //                     "Port=5432;" +
                //                     "User Id=bonesoft;" +
                //                     "Password=123;" +
                //                     "Database=bonesoft;";
                SessionFactory = Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(DataBaseManager.CnnStr))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pessoa>())
                    .ExposeConfiguration(config => config.SetInterceptor(new SqlInterceptor()))
                    .BuildSessionFactory();
                //try
                //{
                //    Configuracao =
                //    SessionFactory.OpenSession()
                //    .CreateCriteria<ConfiguracaoGeral>()
                //    .UniqueResult<ConfiguracaoGeral>();

                //}
                //catch (Exception)
                //{


                //}

                // Configuração para o firebird
                //FirebirdConfiguration cfg = new FirebirdConfiguration()
                //.ConnectionString(cnnStr)
                //.AdoNetBatchSize(100);

                //SessionFactory = Fluently.Configure()
                //    .Database(cfg)
                //    .Mappings(m => m.FluentMappings.Add(typeof(Pessoa)))
                //    .ExposeConfiguration(config =>
                //    {
                //        var export = new SchemaExport(config);
                //        export.Drop(true,true);
                //        export.Create(true,true);
                //    })
                //    .BuildConfiguration()
                //    .BuildSessionFactory();
            }
            return SessionFactory;
        }

        public static IQueryOver<T, T> GetQueryOver()
        {
            return NHibernateHttpModule.Session.QueryOver<T>();
        }



        public static ICriteria GetCriteria()
        {
            return NHibernateHttpModule.Session.CreateCriteria<T>();
        }
    }
}