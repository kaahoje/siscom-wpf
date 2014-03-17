using System.Collections.Generic;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Sped;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisFinanceiro
    {
        public static void IniciarDadosFinanceiro(ISession session)
        {
            var condPag = new CondicaoPagamento
            {
                Descricao = "PAGAMENTO A VISTA",
                Prazos = new List<PrazoPagamentoCondicaoPagamento> {new PrazoPagamentoCondicaoPagamento {Prazo = 0}}
            };
            session.Save(condPag);

            var formaPag = new FormaPagamento
            {
                AVista = true,
                Descricao = "DINHEIRO",
                ExigeIdentificacaoCliente = false,
                PrazoCompensacao = 0,
                TaxaAdministracao = 0,
            };
            session.Save(formaPag);
            // Informações de lançamento obtidas do site http://contabilidade.wikidot.com/lancto:index dia 05/11/2013
            IniciaTiposLancamentoReceitaOperacionalBruta(session);
            IniciaTiposLancamentoDeducoesReceitaBruta(session);
        }

        private static void IniciaTiposLancamentoDeducoesReceitaBruta(ISession session)
        {
        }

        private static TipoLancamento GetTipoLancamentoAVista(ISession session)
        {
            var vendaMercadoriaAVista = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.1.02"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.01.01.01.00"),
                Descricao = "VENDA DE MERCADORIAS A VISTA"
            };
            session.Save(vendaMercadoriaAVista);

            return vendaMercadoriaAVista;
        }

        private static void IniciaTiposLancamentoReceitaOperacionalBruta(ISession session)
        {
            var vendasMercadoriaAPrazo = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.1.02"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.01.05.02.00"),
                Descricao = "VENDA DE MERCADORIAS A PRAZO"
            };
            session.Save(vendasMercadoriaAPrazo);
            var vendasProdutoAVista = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.1.01"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.1.1.01"),
                Descricao = "VENDA DE PRODUTO A VISTA"
            };
            session.Save(vendasProdutoAVista);

            var vendasProdutoAPrazo = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.1.02"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.01.05.02.00"),
                Descricao = "VENDA DE PRODUTO A PRAZO"
            };
            session.Save(vendasProdutoAPrazo);

            var vendasServicoAVista = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.1.03"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.1.1.01"),
                Descricao = "VENDA DE SERVICO A VISTA"
            };
            session.Save(vendasServicoAVista);

            var vendasServicoAPrazo = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.1.02"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.01.05.02.00"),
                Descricao = "VENDA DE SERVICOS A PRAZO"
            };
            session.Save(vendasServicoAPrazo);

            var vendasRecebimentoJuros = new TipoLancamento
            {
                ContaContraPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("3.1.2.01"),
                ContaPartidaValor = PlanoContaReferencialRepository.GetByCodigoConta("1.1.1.02"),
                Descricao = "RECEBIMENTO DE JUROS"
            };
            session.Save(vendasRecebimentoJuros);


            session.Save(DadosIniciais.Conf);
        }
    }
}