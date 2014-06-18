using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using NHibernate;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Sangria
{
    public class SangriaRepository : RepositoryBase<Sangria>
    {
        public static IList<Sangria> GetMovimentoDia(DateTime dia, PessoaJuridica empresa, int caixa)
        {
            return GetList().Where(x => x.Caixa == caixa && x.DataMovimento == dia).ToList();
            //return NHibernateHttpModule.Session.CreateCriteria<Sangria>().Add(
            //    Restrictions.Where<Sangria>(sangria =>
            //        sangria.DataMovimento == dia &&
            //        sangria.Caixa == caixa && sangria.Empresa == empresa)).List<Sangria>();
        }

        public static Sangria Save(Sangria sangria)
        {
            if (sangria.Valor > 0)
            {
                sangria.Valor *= -1;
            }
            ITransaction t = NHibernateHttpModule.Session.BeginTransaction();
            try
            {
                NHibernateHttpModule.Session.Save(sangria);
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw new Exception("Erro ao salvar sangria.\n" + ex.Message);
                
            }
            return sangria;
        }

       
    }
}