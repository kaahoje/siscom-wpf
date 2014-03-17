using Erp.Model;

namespace Erp.View.Rest
{
    
    /// <summary>
    /// Interaction logic for RestForm.xaml
    /// </summary>
    public partial class RestForm
    {
        public ModelFormBase Model
        {
            get { return (ModelFormBase) DataContext; }
            set
            {
                
                DataContext = value;
            }
        }

        public RestForm()
        {
            InitializeComponent();
        }
    }
}
