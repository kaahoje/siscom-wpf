using Erp.Annotations;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for UnidadeSelectView.xaml
    /// </summary>
    public partial class UnidadeSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public UnidadeSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this);

        }
    }
}
