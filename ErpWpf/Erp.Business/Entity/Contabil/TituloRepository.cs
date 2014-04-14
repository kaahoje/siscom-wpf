using System;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Contabil
{
    public class TituloRepository : RepositoryBase<Titulo>, IDisposable
    {
        public void Dispose()
        {
        }

        

        public static IList<Titulo> TitulosAPagarAReceber(DateTime inicio, DateTime fim)
        {
            return GetCriteria()
                .Add(RestricaoNaoBaixado())
                .Add(RestricaoPeriodo(inicio, fim))
                .AddOrder(Order.Asc("DataVencimento")).List<Titulo>();
        }

        #region Construtores de restrições

        private static ICriterion RestricaoAPagar()
        {
            return Restrictions.Eq("AReceber", false);
        }

        private static ICriterion RestricaoAReceber()
        {
            return Restrictions.Eq("AReceber", true);
        }

        private static ICriterion RestricaoNaoBaixado()
        {
            return Restrictions.Eq("Baixado", false);
        }

        private static ICriterion RestricaoBaixado()
        {
            return Restrictions.Eq("Baixado", true);
        }

        private static ICriterion RestricaoPeriodo(DateTime inicio, DateTime fim)
        {
            return Restrictions.Where<Titulo>(titulo => titulo.DataVencimento >= inicio
                                                        && titulo.DataVencimento <= fim);
        }

        private static ICriterion RestricaoVencido()
        {
            return Restrictions.Where<Titulo>(titulo => titulo.DataVencimento < DateTime.Now);
        }

        #endregion

        #region Listas de títulos a pagar/receber

        public static List<Titulo> Titulos(DateTime inicio, DateTime fim)
        {
            var l = GetCriteria()
                .Add(RestricaoPeriodo(inicio, fim))
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
            return (List<Titulo>) l;
        }

        public static List<Titulo> TituosAPagarAReceber(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoPeriodo(inicio, fim))
                .Add(RestricaoNaoBaixado())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TituosPagosRecebidos(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoPeriodo(inicio, fim))
                .Add(RestricaoBaixado())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        #endregion

        #region Listas de títulos a pagar.

        public static List<Titulo> TitulosAPagarVencidos(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria().Add(Restrictions.Conjunction()
                .Add(RestricaoAPagar())
                .Add(RestricaoNaoBaixado()))
                .Add(RestricaoVencido())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TitulosPagosNoPeriodo(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoPeriodo(inicio, fim))
                .Add(RestricaoBaixado())
                .Add(RestricaoAPagar())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TitulosAPagar()
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoAPagar())
                .Add(RestricaoNaoBaixado())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TitulosAPagarNoPeriodo(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoPeriodo(inicio, fim))
                .Add(RestricaoAPagar())
                .Add(RestricaoNaoBaixado())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        #endregion

        #region Listas de títulos a receber.

        public static List<Titulo> TitulosAReceberVencidos()
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoAReceber())
                .Add(RestricaoNaoBaixado())
                .Add(RestricaoVencido())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TitulosRecebidosNoPeriodo(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoAReceber())
                .Add(RestricaoBaixado())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TitulosAReceber()
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoAReceber())
                .Add(RestricaoNaoBaixado())
                .AddOrder(Order.Asc("DataVencimento"))
                .List<Titulo>();
        }

        public static List<Titulo> TitulosAReceberNoPeriodo(DateTime inicio, DateTime fim)
        {
            return (List<Titulo>) GetCriteria()
                .Add(RestricaoAReceber())
                .Add(RestricaoNaoBaixado())
                .Add(RestricaoPeriodo(inicio, fim))
                .AddOrder(Order.Asc("DataVencimento")).List<Titulo>();
        }

        #endregion
    }
}