using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ecf;
using Ecf.Enum;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Vendas.Pedido;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Mercearia;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Enum;
using Util;
using Vendas.Component.View.Telas;
using Vendas.ViewModel.Forms;

namespace Vendas
{
    public class CupomFiscal
    {
        private static string TributosIbpt { get; set; }
        public static bool FecharPedidoMercearia(Mercearia pedido)
        {
            if (pedido.Produtos.Count == 0)
            {
                throw new Exception("Informe ao menos um produto para poder fechar o pedido.");
            }
            var s =NHibernateHttpModule.Session;
            CondicaoPagamentoRepository.Session = s;
            FormaPagamentoRepository.Session = s;
            
            // quando do uso de cupom fiscal deve ser chamado o comando de impressão aqui.
            pedido.Caixa = Properties.Settings.Default.Caixa;
            MerceariaRepository.Save(pedido);
            return true;
        }

        
        public static bool FecharPedidoRestaurante(PedidoRestaurante pedido)
        {
            try
            {
                if (pedido.Produtos.Count == 0)
                {
                    throw new Exception("Informe ao menos um produto para poder fechar o pedido.");
                }


                foreach (var pag in pedido.Pagamento)
                {
                    pag.Pedido = pedido;
                }
                CustomMessageBox.MensagemInformativa("A impressão de cupom fiscal está desabilitada.");
                if (!FecharPedidoRestaurante(pedido, GetProdutosDeComposicao(pedido), pedido.Pagamento)) return false;
                pedido.Coo = EcfHelper.Ecf.UltimoCupomEmitido();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar pedido.\n" + ex.Message + "\n" +
                                "Mensagem do erro: " + ex.InnerException);
                return false;

            }
            return true;
        }

        public static IList<ProdutoPedido> GetProdutosDeComposicao(PedidoRestaurante pedido)
        {
            var prods = new List<ProdutoPedido>();
            foreach (var composicao in pedido.Produtos)
            {
                foreach (var prod in composicao.Composicao)
                {
                    prod.Valor /= composicao.Composicao.Count;
                    prods.Add(prod);
                }
            }
            return prods;
        }

        private static bool FecharPedidoRestaurante(Pedido pedido, IList<ProdutoPedido> produtos,
            IList<PagamentoPedido> pagamento)
        {
            var dadosCliente = new EcfDadosClienteView();
            var dadosModel = new EcfDadosClienteModel();
            
            
            dadosModel.Cliente = new Pessoa();
            dadosCliente.DataContext = dadosModel;
            dadosCliente.ShowDialog();
            
            if (!EcfHelper.Ecf.AbrirCupom(dadosModel.ClienteCupom)) return false;
            if (!LancarProdutos(produtos)) return false;

            EcfHelper.Ecf.IniciaFechamentoCupom(
                TipoDescontoAcressimo.AcressimoValor,
                pedido.Descontos,
                pedido.Acressimos);
            foreach (var pag in pagamento)
            {
                if (!EcfHelper.Ecf.
                    EfetuarPagamento(pag.FormaPagamento.Descricao, pag.Valor)) return false;
            }

            CalcularTributosDeOlhoNoImposto(produtos);
            if (string.IsNullOrEmpty(pedido.Observacoes))
            {
                if (!EcfHelper.Ecf.EncerrarCupom(TributosIbpt + Environment.NewLine +
                "Usuário:" + App.Usuario.Nome))
                    return false;
            }
            else
            {
                if (!EcfHelper.Ecf.EncerrarCupom(TributosIbpt + Environment.NewLine +
                "Usuário:" + App.Usuario.Nome + Environment.NewLine + Environment.NewLine +
                pedido.Observacoes))
                    return false;
            }
            return true;
        }

        public static string CalcularTributosDeOlhoNoImposto(IList<ProdutoPedido> produtos)
        {
            decimal totalProd = 0;
            decimal aliquotaMedia = 0;
            foreach (var prod in produtos)
            {
                totalProd += prod.Valor;
                if (prod.Produto.Origem == OrigemProduto.Nacional)
                {
                    aliquotaMedia += prod.Produto.Ncm.TributosNacionalIbpt;
                }
                else
                {
                    aliquotaMedia += prod.Produto.Ncm.TributosImportadoIbpt;
                }

            }
            aliquotaMedia = aliquotaMedia / produtos.Count;
            TributosIbpt = "Val Aprox Tributos " +
                    String.Format("{0:c}", (totalProd / 100) * aliquotaMedia) +
                    "(" + EcfHelper.Ecf.FormataPercentual(aliquotaMedia) + "%) Fonte: IBPT";
            return TributosIbpt;
        }

        private static bool LancarProdutos(IList<ProdutoPedido> produtos)
        {
            foreach (var prod in produtos)
            {

                bool ret;
                if (prod.Produto.Tipo == TipoProduto.Produto || prod.Produto.Tipo == TipoProduto.Mercadoria)
                {

                    ret = EcfHelper.Ecf.VenderItem(prod.Produto.Tributacao.TipoTributacaoIcms,
                    prod.Produto.Tipo,
                    prod.Quantidade,
                    prod.ValorUnitario,
                    TipoDescontoAcressimo.AcressimoValor,
                    0,
                    prod.Produto.Id,
                    prod.Produto.UnidadeVenda.Sigla,
                    prod.Produto.Descricao,
                    prod.Produto.Tributacao.IcmsDevedor);
                }
                else
                {

                    ret = EcfHelper.Ecf.VenderItem(
                    prod.Produto.Tributacao.TipoTributacaoIss,
                    prod.Produto.Tipo,
                    prod.Quantidade,
                    prod.ValorUnitario,
                    TipoDescontoAcressimo.AcressimoValor,
                    0,
                    prod.Produto.Id,
                    prod.Produto.UnidadeVenda.Sigla,
                    prod.Produto.Descricao,
                    prod.Produto.Tributacao.IssDevedor);
                }
                if (!ret)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
