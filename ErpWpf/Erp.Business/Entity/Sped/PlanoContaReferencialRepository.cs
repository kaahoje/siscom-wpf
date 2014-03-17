using System;
using System.Collections.Generic;
using FluentNHibernate.Conventions;
using NHibernate;

namespace Erp.Business.Entity.Sped
{
    public class PlanoContaReferencialRepository : RepositoryBase<PlanoContaReferencial>
    {
        public static void CreditarConta(ISession session, PlanoContaReferencial planoConta, decimal valor)
        {
            throw new NotImplementedException();
        }

        public static void DebitarConta(ISession session, PlanoContaReferencial planoConta, decimal valor)
        {
            throw new NotImplementedException();
        }

        public static PlanoContaReferencial GetByCodigoConta(string codigo)
        {
            IList<PlanoContaReferencial> list = GetQueryOver().Where(referencial => referencial.Codigo == codigo).List();
            if (list.IsEmpty())
            {
                return null;
            }
            return list[0];
        }

        public static int NivelConta(int id)
        {
            PlanoContaReferencial conta = GetById(id);
            if (conta == null)
            {
                return 0;
            }
            return conta.Codigo.Split('.').Length;
        }
    }
}