using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using Ecf;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Enum;
using Vendas.Component.View.Telas;
using Vendas.Properties;

namespace Vendas
{
    public class Utils
    {
        private static readonly Font Fonte = new Font("Arial", 11);
        private static readonly string NewLine = " " + Environment.NewLine;
        private static string _comandaAtual = "";
        private static string _produtoAtual = "";
        private static string _impressoraNaoFiscal = "";

        public static Dictionary<String, String> ComandosImpressao { get; set; }

        public static void ImprimirPedido(PedidoRestaurante pedido)
        {
            ComandosImpressao = new Dictionary<string, string>();
            foreach (var composicaoProduto in pedido.Produtos)
            {
                _produtoAtual = "";
                if (composicaoProduto.Produto.SubGrupo.ImprimeEmComandaRestaurante)
                {
                    var imprime = composicaoProduto.Produto.SubGrupo.ImprimeEmComandaRestaurante;
                    var impressora = composicaoProduto.Produto.SubGrupo.Impressora;


                    if (composicaoProduto.Produto.Ippt == Ippt.Terceiros)
                    {
                        ImprimeProduto(
                            composicaoProduto.Produto,
                            composicaoProduto.Quantidade);
                    }
                    else
                    {
                        foreach (var produto in composicaoProduto.Composicao)
                        {
                            ImprimeProduto(
                                produto.Produto,
                                composicaoProduto.Quantidade / composicaoProduto.Composicao.Count);
                        }
                    }
                    if (imprime && ComandosImpressao.ContainsKey(impressora))
                    {

                        ComandosImpressao.TryGetValue(impressora, out _comandaAtual);
                        _comandaAtual += _produtoAtual;
                        ComandosImpressao.Remove(impressora);
                        ComandosImpressao.Add(impressora, _comandaAtual);

                    }
                    else
                    {
                        _comandaAtual = CriarCabecalho(pedido) + _produtoAtual;
                        ComandosImpressao.Add(impressora, _comandaAtual);
                    }
                }
            }
            foreach (var item in ComandosImpressao.Keys)
            {
                try
                {

                    ComandosImpressao.TryGetValue(item, out _comandaAtual);

                    if (pedido.Observacoes != null && !pedido.Observacoes.Equals(""))
                    {
                        _comandaAtual += pedido.Observacoes + NewLine;
                    }
                    _comandaAtual = FinalizaComanda(_comandaAtual);
                    Imprimir(_comandaAtual, item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao imprimir comanda.\nMensagem do erro: " +
                        ex.Message);
                }

            }
        }

        private static string FinalizaComanda(string comandaAtual)
        {
            comandaAtual += "------------------------------------------------" + NewLine;
            comandaAtual += DateTime.Now.ToString("dd/MM/yyyy                    HH:mm");
            return comandaAtual;
        }

        private static void Imprimir(string texto, bool fiscal)
        {
            if (fiscal)
            {
                EcfHelper.Ecf.ImprimeRelatorioGerencial(texto);
            }
            else
            {
                Imprimir(texto, _impressoraNaoFiscal);
            }

        }

        private static void Imprimir(string texto, string impressora)
        {

            if (string.IsNullOrEmpty(impressora) && string.IsNullOrEmpty(_impressoraNaoFiscal))
            {
                var f = new ImpressorasDisponiveisView();
                f.ShowDialog();
                if (string.IsNullOrEmpty(f.ImpressoraSelecionada))
                {
                    return;
                }
                _impressoraNaoFiscal = f.ImpressoraSelecionada;
                impressora = _impressoraNaoFiscal;
            }
            var doc = new PrintDocument();
            _comandaAtual = texto;
            doc.PrintPage += doc_PrintPage;
            doc.PrinterSettings.PrinterName = impressora;
            doc.DefaultPageSettings.Margins = new Margins(3, 3, 3, 3); doc.DocumentName = "comando_cozinha";
            doc.Print();
        }

        static void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(_comandaAtual, Fonte,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(_comandaAtual, Fonte, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            _comandaAtual = _comandaAtual.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (_comandaAtual.Length > 0);
        }

        private static string CriarCabecalho(PedidoRestaurante pedido)
        {
            string com = "";
            com = "Controle: " + pedido.Controle.Controle + "        ";

            if (pedido.Local == LocalPedidoRestaurante.Balcao)
            {
                com += "Balcão" + NewLine;
            }
            if (pedido.Local == LocalPedidoRestaurante.Mesa)
            {
                com += "Mesa: " + pedido.Mesa + NewLine;
            }
            if (pedido.Local == LocalPedidoRestaurante.Entrega)
            {
                com += "Entrega" + NewLine;
            }
            com += "Qtd.    Descricao" + NewLine;
            com += "------------------------------------------------" + NewLine;
            return com;
        }
        private static void ImprimeProduto(Produto produto, decimal quantidade)
        {
            if (produto.SubGrupo.ImprimeEmComandaRestaurante)
            {
                _produtoAtual += AjustarTamanho(
                    AjustaCasasDecimais(quantidade.ToString(CultureInfo.InvariantCulture), 2), 6);
                _produtoAtual += produto.Descricao + NewLine;
            }
        }


        private static String AjustarTamanho(String texto, int tamanho)
        {
            for (int i = 0; i < tamanho; i++)
            {
                texto += " ";
            }
            return texto.Substring(0, tamanho);
        }

        private static string AlinharADireita(String texto, int tamanho)
        {
            var adicional = "";
            for (int i = 0; i < tamanho - texto.Length; i++)
            {
                adicional += " ";
            }
            return adicional + texto;
        }

        private static string AjustaCasasDecimais(String texto, int casasDecimais)
        {
            if (!texto.Contains(","))
            {
                return texto;
            }
            return texto.Substring(texto.IndexOf(",", StringComparison.Ordinal), casasDecimais);
        }

        private static string FormataNumero(decimal numero, int casasDecimais)
        {
            var num = numero.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
            var zerosAdicionais = "000000000000000000000000000000";
            if (num.Contains(","))
            {
                var split = num.Split(',');
                split[1] = split[1] + zerosAdicionais;
                return split[0] + "," + split[1].Substring(0, casasDecimais);
            }
            else
            {
                return num + "," + zerosAdicionais.Substring(0, casasDecimais);
            }

        }

        public static void ParcialMesa(PedidoRestaurante pedido)
        {
            if (pedido.Local == LocalPedidoRestaurante.Mesa)
            {
                
                decimal valorPedido = 0;
                var parcial = NewLine + "                PARCIAL DA MESA" + NewLine + NewLine;
                parcial += "Mesa: " + pedido.Mesa + "              Caixa: " + Settings.Default.Caixa + "" + NewLine;
                parcial += "Sq.    Descricao" + NewLine;
                parcial += "Valor            Qtd.              Total" + NewLine;
                parcial += "===============================================" + NewLine;
                foreach (var prod in pedido.Produtos)
                {
                    if (prod.Produto.Tipo == TipoProduto.Mercadoria)
                    {
                        parcial += prod.Produto.Descricao + NewLine;

                        parcial += "R$" + AlinharADireita(
                            FormataNumero(prod.ValorUnitario, 2), 10);
                        parcial += "  x  " + AlinharADireita(
                            FormataNumero(prod.Quantidade, 3), 5);
                        parcial += "             R$" + AlinharADireita(
                            FormataNumero(prod.Valor, 2), 10) + NewLine;
                        valorPedido += prod.Valor;
                    }
                    else
                    {
                        foreach (var comp in prod.Composicao)
                        {
                            parcial += comp.Produto.Descricao + NewLine;
                            // Valores do produto.
                            parcial += "R$" + AlinharADireita(
                                FormataNumero(prod.ValorUnitario, 2), 10);
                            parcial += "  x  " + AlinharADireita(
                                FormataNumero(prod.Quantidade / prod.Composicao.Count, 3), 5);
                            parcial += "             R$" + AlinharADireita(
                                FormataNumero(prod.Valor, 2), 10) + NewLine;
                            valorPedido += prod.Valor;
                        }
                    }
                }
                parcial += "===============================================" + NewLine;
                parcial += NewLine + "Total dos produtos:                R$" + AlinharADireita(
                        FormataNumero(valorPedido, 2), 10) + "" +NewLine + NewLine;
                //parcial = FinalizaComanda(parcial);
                //FinalizaComanda(parcial);
                // Comanda a impressão na impressora fiscal.
                Imprimir(parcial, true);
            }
        }
    }
}
