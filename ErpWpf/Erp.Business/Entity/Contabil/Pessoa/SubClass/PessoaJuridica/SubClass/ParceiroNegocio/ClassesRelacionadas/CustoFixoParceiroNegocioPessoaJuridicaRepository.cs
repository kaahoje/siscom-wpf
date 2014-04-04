using System;
using System.Collections.Generic;
using System.Linq;
using Erp.Business.Entity.Contabil.ClassesRelacoinadas;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using Util;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaJuridicaRepository : RepositoryBase<CustoFixoParceiroNegocioPessoaJuridica>
    {
        public static IList<CustoFixoParceiroNegocioPessoaJuridica> GetByRange(string filter, int takePesquisa)
        {
            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetList().Where(custo => custo.ParceiroNegocioPessoaJuridica != null &&(
                    custo.ParceiroNegocioPessoaJuridica.Cnpj.IsInsensitiveLike(ContainsStringFilter(filter))))
                    .ToList();
                //return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaJuridica)
                //    .Where(parceiroNegocio => parceiroNegocio.Cnpj.IsInsensitiveLike(StartStringFilter(filter)))
                //    .Take(takePesquisa).List();
            }
            return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaJuridica,JoinType.FullJoin)
                    .Where(parceiroNegocio => parceiroNegocio.RazaoSocial.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                        parceiroNegocio.NomeFantasia.IsInsensitiveLike(ContainsStringFilter(filter)))
                    .Take(takePesquisa).List();
        }

        public static void GerarMes(MesGerado mes)
        {
            var mesGerado = MesGeradoRepository.GetByMesAno(mes.Mes, mes.Ano);
            if (mesGerado == null)
            {
                var custosJuridico = GetListAtivos();
                foreach (var custo in custosJuridico)
                {
                    var t = NHibernateHttpModule.Session.BeginTransaction();
                    try
                    {
                        var titulo = new TituloParceiroNegocioPessoaJuridica()
                        {
                             AReceber = false,
                             DataLancamento = DateTime.Now.Date,
                             DataVencimento = new DateTime(mes.Ano,mes.Mes,custo.DiaVencimento),
                             ParceiroNegocioPessoaJuridica = custo.ParceiroNegocioPessoaJuridica,
                             Valor = custo.Valor
                        };
                        NHibernateHttpModule.Session.Save(titulo);
                        t.Commit();
                    }
                    catch (Exception)
                    {
                        t.Rollback();
                        throw;
                    }
                }
            }
            else
            {
                CustomMessageBox.MensagemInformativa("Este mês já foi gerado.");
            }
        }
    }
}
