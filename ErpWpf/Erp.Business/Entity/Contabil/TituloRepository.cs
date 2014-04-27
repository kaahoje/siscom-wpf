using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using AutoMapper;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
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

        #region Métodos para o setor contas à receber/pagar.

        public static void BaixarTitulo(Titulo titulo,int idPessoa)
        {
            Pessoa.Pessoa pessoa = ParceiroNegocioPessoaFisicaRepository.GetById(idPessoa);
            if (pessoa != null)
            {
                var tituloParceiro = new TituloParceiroNegocioPessoaFisica();
                Mapper.CreateMap<Titulo,TituloParceiroNegocioPessoaFisica>();
                Mapper.Map(titulo, tituloParceiro);
                tituloParceiro.ParceiroNegocioPessoaFisica = (ParceiroNegocioPessoaFisica) pessoa;
                TituloParceiroNegocioPessoaFisicaRepository.BaixarTitulo(tituloParceiro);
            }
            else
            {
                pessoa = ParceiroNegocioPessoaJuridicaRepository.GetById(idPessoa);
                if (pessoa != null)
                {
                    var tituloParceiro = new TituloParceiroNegocioPessoaJuridica();
                    Mapper.CreateMap<Titulo, TituloParceiroNegocioPessoaFisica>();
                    Mapper.Map(titulo, tituloParceiro);
                    tituloParceiro.ParceiroNegocioPessoaJuridica = (ParceiroNegocioPessoaJuridica)pessoa;
                    TituloParceiroNegocioPessoaJuridicaRepository.BaixarTitulo(tituloParceiro);
                }
            }
        }

        #endregion

        #region Métodos para o setor de vendas.
        public static void IncluirRecebimentoCliente(PagamentoCliente pagamento)
        {
            var titulo = GerarTitulo(true,
                pagamento.DataMovimento,
                pagamento.Valor,
                pagamento.Descontos,
                pagamento.Acrescimos,
                pagamento.FormaPagamento.TipoTituloRecebimentoCliente);
            BaixarTitulo(titulo,pagamento.Cliente.Id);
        }

        public static void IncluirPagamentoPedido(PagamentoPedido pagamento)
        {
            
        }
        #endregion

        #region Métodos gerais

        public static Titulo GerarTitulo(bool aReceber, DateTime vencimento, decimal valor, decimal acrescimos, decimal descontos,
             TipoTitulo tipo, string numeroOrdem = "", string historico = "")
        {
            return new Titulo()
            {
                AReceber = aReceber,
                Valor = valor,
                Acrescimos =acrescimos,
                Desconto = descontos,
                NumeroOrdem = numeroOrdem,
                TipoTitulo = tipo,
                DataVencimento = vencimento,
                DataLancamento = DateTime.Now.Date,
                Historico = historico
            };
        }

        #endregion

    }
}