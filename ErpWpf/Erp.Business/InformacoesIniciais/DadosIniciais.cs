using System;
using Erp.Business.Entity.Configuracao;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciais : IDisposable
    {
        public static Pessoa Pessoa { get; set; }
        public static ConfiguracaoGeral Conf { get; set; }
        public static PessoaJuridica Empresa { get; set; }
        public static ISessionFactory Factory { get; set; }

        public void Dispose()
        {
        }

        public static void Iniciar()
        {
            ISession session;

            if (Factory == null)
            {
                session = RepositoryBase<object>.GetSessionFactory().OpenSession();
            }
            else
            {
                session = Factory.OpenSession();
            }
            var transaction = session.BeginTransaction();

            DadosIniciaisAdministrador.SaveAdministrador();

            DadosIniciaisSped.PlanoContaReferencial(session);
            DadosIniciaisCst.Inicio(session);
            DadosIniciaisCfop.Iniciar(session);
            DadosIniciaisNcm.IniciarDados(session);
            //DadosIniciaisPerfil.IniciarDados(session);
            DadosIniciaisMenu.Iniciar(session);
            DadosIniciaisVenda.Iniciar(session);
            DadosIniciaisSped.PlanoContaReferencial(session);
            DadosIniciaiEstoque.IniciarDados(session);
            
            transaction.Commit();
        }

        public static void IniciarEtapa2()
        {
            DadosIniciaisEndereco.SaveEndereco();
        }
        public static void IniciarEtapa3()
        {
            DadosIniciaisCnae.SaveCnae();
        }

        public static void IniciaConfiguracoes(ISession session)
        {
            Conf = new ConfiguracaoGeral();
            //var tipoTitulo = DadosIniciaisFinanceiro.TipoTituloPagamentoAvista(session);
            //var condicaoPagamento = DadosIniciaisVenda.CondicaoPagamentoPadrao(session);

            // Configurações do do sistema de retaguarda.
            if (Pessoa == null)
            {
                Pessoa = session.Get<Pessoa>(1);
            }

            //Dados iniciais de venda.
            //conf.CondicaoPagamentoPadrao = condicaoPagamento;
            //conf.FormaPagamentoPadrao = DadosIniciaisVenda.FormaPagamentoPadrao(session, tipoTitulo);
            Conf.DiaProcessamento = new DateTime();
            Conf.CobrarComposicaoPorMaiorValor = true;
            Conf.LimitarComposicaoDeProdutoEm = 0;

            //session.Save(u.Pessoa);
            session.Save(Conf);
        }
    }
}