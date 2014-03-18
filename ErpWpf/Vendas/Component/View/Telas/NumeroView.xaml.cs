using System.Windows;
using System.Windows.Input;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for NumeroView.xaml
    /// </summary>
    public partial class NumeroView : Window
    {
        public NumeroView()
        {
            InitializeComponent();
            TxtNumero.KeyDown += TxtNumeroOnKeyDown;
            TxtNumero.Focus();
        }

        public int Value
        {
            get { return (int) TxtNumero.Value; }
        }

        private void TxtNumeroOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.Enter)
            {
                Hide();
            }
            if (keyEventArgs.Key == Key.Escape)
            {
                TxtNumero.Value = 0;
                Hide();
            }
        }

        private void NumeroView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }
    }
}
