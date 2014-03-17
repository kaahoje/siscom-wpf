using System;
using System.Windows.Input;
using Erp.Model;

namespace Erp.View.Rest
{
    /// <summary>
    /// Interaction logic for RestGrid.xaml
    /// </summary>
    public partial class RestPesquisa
    {
        private ModelSelectBase Model
        {
            get { return DataContext as ModelSelectBase; }
        }

        public RestPesquisa()
        {
            InitializeComponent();
        }

        private void RestGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        Model.Selecionar();
                        break;
                    case Key.Escape:
                        Model.Sair();
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelBase.MensagemErro(ex.Message);
            }

        }
    }
}
