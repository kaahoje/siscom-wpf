using System;
using System.Windows;
using Erp.Model.Extras;

namespace Erp.View.Extras
{
    /// <summary>
    /// Interaction logic for AtualizacaoProdutoFormView.xaml
    /// </summary>
    public partial class AtualizacaoProdutoFormView 
    {
        private AtualizacaoProdutoFormModel Model
        {
            get { return (AtualizacaoProdutoFormModel) DataContext; }
        }

        public AtualizacaoProdutoFormView()
        {
            InitializeComponent();
            ShowInTaskbar = true;
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            Model.Fechar += Model_Fechar;
            txtFiltro.Focus();
        }

        void Model_Fechar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
