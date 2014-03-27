using System.Windows;
using Erp.Business.Entity.Estoque.Produto;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for ProdutoFormView.xaml
    /// </summary>
    public partial class ProdutoFormView 
    {
        private FormDefaultActions<Produto> FormDefaultActions { get; set; }
        public ProdutoFormView()
        {
            InitializeComponent();
            
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions<Produto>(this){IsEnableShortcuts = true};
        }

        
    }
}
