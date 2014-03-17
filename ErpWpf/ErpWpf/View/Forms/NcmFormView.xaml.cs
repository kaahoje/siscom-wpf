using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for NcmFormView.xaml
    /// </summary>
    public partial class NcmFormView 
    {
        //private FormDefaultActions FormDefaultActions { get; set; }
        public NcmFormView()
        {
            InitializeComponent();
            DataContext = new NcmFormModel();
            RestCommands.DataContext = DataContext;
            //FormDefaultActions = new FormDefaultActions(this);
            //FormDefaultActions.IsEnableShortcuts = false;
        }
    }
}
