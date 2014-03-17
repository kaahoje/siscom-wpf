using Erp.Annotations;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for NcmSelectView.xaml
    /// </summary>
    public partial class NcmSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public NcmSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this);
            
        }
        
    }
}
