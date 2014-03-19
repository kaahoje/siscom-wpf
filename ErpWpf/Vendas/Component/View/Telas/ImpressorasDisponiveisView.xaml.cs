using System.Drawing.Printing;
using System.Windows.Input;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for ImpressorasDisponiveisView.xaml
    /// </summary>
    public partial class ImpressorasDisponiveisView 
    {
        public ImpressorasDisponiveisView()
        {
            InitializeComponent();
            CboImpressorasDisponiveis.Items.Clear();
            CboImpressorasDisponiveis.Items.Add("");
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                CboImpressorasDisponiveis.Items.Add(printer);
            }
            CboImpressorasDisponiveis.KeyDown += CboImpressorasDisponiveisOnKeyDown;
            CboImpressorasDisponiveis.Focus();
        }

        public string ImpressoraSelecionada
        {
            get { return (string) CboImpressorasDisponiveis.SelectedItem; }
        }

        private void CboImpressorasDisponiveisOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.Escape)
            {
                CboImpressorasDisponiveis.SelectedIndex = 0;
                Hide();
            }
            if (keyEventArgs.Key == Key.Enter)
            {
                CboImpressorasDisponiveis.SelectedIndex = 0;
                Hide();
            }
        }

        private void ImpressorasDisponiveisView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }
    }
}
