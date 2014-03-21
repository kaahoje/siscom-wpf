using System;
using System.Web;
using System.Web.SessionState;
using Erp.Business.Entity.Contabil.Pessoa;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

//http://www.leandroprado.com.br/2012/01/mapeiamentos-com-fluent-nhibernate/
using Util;

namespace Erp.Business
{
    public class NHibernateHttpModule : IHttpModule, IRequiresSessionState
    {
        public static readonly string Key = "NHibernateSession";
        private static ISession _session;
        private static ISessionFactory _factory;

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        public void Dispose()
        {
        }

        public static ISession Session
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    if (_session != null)
                    {
                        return _session;
                    }

                    _session = OpenSession();

                    return _session;
                }

                var currentContext = HttpContext.Current;
                var session = currentContext.Items[Key] as ISession;

                if (session == null)
                {
                    session = OpenSession();
                    currentContext.Items[Key] = session;
                }
                return session;
            }
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;
            context.Items[Key] = OpenSession();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;
            var session = context.Items[Key] as ISession;

            if (session != null)
            {
                session.Flush();
                session.Close();
            }

            context.Items[Key] = null;
        }

        private static ISession OpenSession()
        {
            var session = GetFactory().OpenSession();

            if (session == null)
                throw new InvalidOperationException("OpenSession() is null.");

            return session;
        }

        private static ISessionFactory GetFactory()
        {

            if (_factory != null) return _factory;
            _factory = CreateSessionFactory();

            if (_factory == null)
                throw new InvalidOperationException("BuildSessionFactory is null.");

            return _factory;
        }

        public static ISessionFactory CreateSessionFactory()
        {
            string connectionString = DataBaseManager.CnnStr;
            #region PostGre



            try
            {
                var fact = Fluently
                .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Pessoa>()).BuildSessionFactory();
                _session = fact.OpenSession();
                return fact;
            }
            catch (Exception ex)
            {
                Utils.GerarLogDataBase(ex);
                throw;
            }
            return null;

            #endregion
        }
    }
}
