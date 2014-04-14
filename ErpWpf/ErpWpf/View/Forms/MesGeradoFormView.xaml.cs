using Erp.Business.Entity.Contabil.ClassesRelacoinadas;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for MesGeradoFormView.xaml
    /// </summary>
    public partial class MesGeradoFormView
    {
        FormDefaultActions<MesGerado> Actions { get; set; }
        public MesGeradoFormView()
        {
            InitializeComponent();
            Actions = new FormDefaultActions<MesGerado>(this,spnMes){IsEnableShortcuts = false};
        }
    }
}
