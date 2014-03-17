using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Suprimento
{
    public class SuprimentoRepository : RepositoryBase<Suprimento>
    {
        public static IList<Suprimento> SuprimentosDia(int caixa, DateTime dia, PessoaJuridica empresa)
        {
            return NHibernateHttpModule.Session.CreateCriteria<Suprimento>()
                .Add(Restrictions.Where<Suprimento>(suprimento =>
                    suprimento.DataMovimento == dia &&
                    suprimento.Caixa == caixa && suprimento.Empresa == empresa)).List<Suprimento>();
        }
    }
}