using System.Windows.Input;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for Sangria.xaml
    /// </summary>
    public partial class SangriaView
    {
        public SangriaView()
        {
            InitializeComponent();
        }

        private void SangriaView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }
    }
}
