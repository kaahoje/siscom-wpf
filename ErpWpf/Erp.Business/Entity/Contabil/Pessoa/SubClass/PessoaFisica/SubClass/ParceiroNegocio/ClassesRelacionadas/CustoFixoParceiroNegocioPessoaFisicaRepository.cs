using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.ClassesRelacoinadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using NHibernate.Criterion;
using Util;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaFisicaRepository : RepositoryBase<CustoFixoParceiroNegocioPessoaFisica>
    {
        public static IList<CustoFixoParceiroNegocioPessoaFisica> GetByRange(string filter, int takePesquisa)
        {

            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaFisica)
                    .Where(parceiroNegocio => parceiroNegocio.Cpf.IsInsensitiveLike(StartStringFilter(filter)))
                    .Take(takePesquisa).List();
            }
            return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaFisica)
                    .Where(parceiroNegocio => parceiroNegocio.Nome.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                        parceiroNegocio.Alias.IsInsensitiveLike(ContainsStringFilter(filter)))
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
                        var titulo = new TituloParceiroNegocioPessoaFisica()
                        {
                            AReceber = false,
                            DataLancamento = DateTime.Now.Date,
                            DataVencimento = new DateTime(mes.Ano, mes.Mes, custo.DiaVencimento),
                            ParceiroNegocioPessoaFisica= custo.ParceiroNegocioPessoaFisica,
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
