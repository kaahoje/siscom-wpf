using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for PermissaoUsuarioFormView.xaml
    /// </summary>
    public partial class PermissaoUsuarioFormView
    {
        FormDefaultActions<PessoaFisica> Actions { get; set; } 
        public PermissaoUsuarioFormView()
        {
            InitializeComponent();
            DataContext = new PermissaoUsuarioFormModel();
            RestCommands.DataContext = DataContext;
            Actions = new FormDefaultActions<PessoaFisica>(this,txtCpf){IsEnableShortcuts = false};
        }
    }
}
