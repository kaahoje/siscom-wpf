using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Validation;
using Erp.Model.Extras;
using Erp.Model.Forms;
using Erp.View.Extras;
using FluentNHibernate.Conventions;
using Util;

namespace Erp.View.Forms
{

    /// <summary>
    /// Interaction logic for NotaFiscalFormView.xaml
    /// </summary>
    public partial class NotaFiscalFormView
    {
        private NotaFiscalFormModelModel Model
        {
            get { return (NotaFiscalFormModelModel)DataContext; }
        }

        private FormDefaultActions<NotaFiscal> FormDefaultActions { get; set; }

        public NotaFiscalFormView(bool entrada)
        {
            InitializeComponent();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions<NotaFiscal>(this,TxtNumeroNota) { IsEnableShortcuts = false };
            Model.Entrada = entrada;
            if (entrada)
            {
                TabDestinatario.Visibility = Visibility.Hidden;
                TabDestinatario.VisibleInHeaderMenu = false;

            }
            else
            {
                TabEmitente.Visibility = Visibility.Hidden;
                TabEmitente.VisibleInHeaderMenu = false;
            }
        }

        private void CboEmitente_OnKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(CboEmitente.Name))
                {
                    Model.EmitenteLargeDataModel.Filter = CboEmitente.DisplayText;
                }
            }
        }

        private void CboDestinatario_OnKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(CboDestinatario.Name))
                {
                    Model.DestinatarioLargeDataModel.Filter = CboDestinatario.DisplayText;
                }
            }
        }

        private void CboTransportadora_OnKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(CboTransportadora.Name))
                {
                    Model.TransportadoraLargeDataModel.Filter = CboTransportadora.DisplayText;
                }
            }
        }

        private void TxtValorIpi_OnKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                const string msgProdNaoEncontrado = "Produto não encontrado";
                if (Model.ProdutoAtual.Produto == null)
                {
                    CustomMessageBox.MensagemInformativa(msgProdNaoEncontrado);
                    TxtProduto.Focus();
                    return;
                }
                if (Model.ProdutoAtual.Produto.Id == 0)
                {
                    CustomMessageBox.MensagemInformativa(msgProdNaoEncontrado);
                    TxtProduto.Focus();
                    return;
                }
                if (Model.ProdutoAtual != null)
                {
                    var result = DataValidation.ValidateEntity(Model.ProdutoAtual);
                    if (result.HasError)
                    {
                        throw new Exception(result.MensagemErro());
                    }

                    Model.SalvarProduto();
                }
                TxtProduto.Focus();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                throw;
            }
        }

        private void TxtProduto_OnKeyUp(object sender, KeyEventArgs e)
        {
            Model.ProdutoLargeDataModel.Filter = TxtProduto.DisplayText;
        }

        private void TxtProduto_OnLostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TxtProduto_OnKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TxtProduto_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (!string.IsNullOrEmpty(TxtProduto.Text))
                    {
                        var modProds = new ProdutosEncontradosGridModel();
                        modProds.Filter = TxtProduto.Text;
                        if (modProds.Collection.IsNotEmpty())
                        {
                            if (modProds.Collection.Count > 1)
                            {
                                modProds.WindowSelect.ShowDialog();
                                if (modProds.CurrentItem != null)
                                {
                                    Model.ProdutoAtual.Produto = modProds.CurrentItem;
                                }
                                else
                                {
                                    TxtProduto.Focus();
                                }
                            }
                            else
                            {
                                Model.ProdutoAtual.Produto = modProds.Collection[0];
                            }
                        }
                        else
                        {
                            TxtProduto.Focus();
                            CustomMessageBox.MensagemInformativa("Não foram encontrados produtos correspondentes à pesquisa");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
            }
        }
    }
}
