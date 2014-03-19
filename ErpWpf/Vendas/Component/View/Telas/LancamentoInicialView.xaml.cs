using System;
using System.Diagnostics;
using System.Windows;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.LancamentoInicial;
using Util;
using Vendas.Properties;
using Vendas.ViewModel.Forms;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for LancamentoInicialView.xaml
    /// </summary>
    public partial class LancamentoInicialView 
    {
        private LancamentoInicialModel Model
        {
            get { return (LancamentoInicialModel) DataContext; }
        }

        public LancamentoInicialView()
        {
            InitializeComponent();
            TxtValor.Focus();
            RestCommands.DataContext = DataContext;
            
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == "DataContext")
            {
                Model.Sair += ModelOnSair;
            }
        }

        private void ModelOnSair(object sender, EventArgs eventArgs)
        {
            Close();
        }

        
        

        //private void LancamentoInicialView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Escape)
        //    {
        //        Hide();
        //    }
        //}


        private void LancamentoInicialView_OnClosed(object sender, EventArgs e)
        {
            var dia = LancamentoInicialRepository.DiaLancado(Settings.Default.Caixa, DateTime.Now, App.Proprietaria);
            if (dia == null)
            {
                CustomMessageBox.MensagemInformativa("Não foi identificado um lançamento inicial de caixa.\n\n " +
                                                     "A aplicação será encerrada.");
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
