namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for UnidadeFormView.xaml
    /// </summary>
    public partial class UnidadeFormView
    {
        private FormDefaultActions FormDefaultActions { get; set; }
        public UnidadeFormView()
        {
            InitializeComponent();
            
            RestCommands.DataContext = DataContext;

            FormDefaultActions = new FormDefaultActions(this) { IsEnableShortcuts = false };
        }
    }
}
