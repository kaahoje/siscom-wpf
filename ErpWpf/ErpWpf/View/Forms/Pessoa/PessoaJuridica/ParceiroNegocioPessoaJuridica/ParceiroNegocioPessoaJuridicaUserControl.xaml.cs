using System.Windows;
using System.Windows.Controls;

namespace Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for ParceiroNegocioPessoaJuridicaUserControl.xaml
    /// </summary>
    public partial class ParceiroNegocioPessoaJuridicaUserControl : UserControl
    {
        public ParceiroNegocioPessoaJuridicaUserControl()
        {
            InitializeComponent();

        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == "DataContex")
            {
                JuridicaUserControl.DataContext = DataContext;
            }
        }
    }
}
