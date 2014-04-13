using Erp.Business.Entity.Estoque.Produto;

namespace Erp.Relatorios.Produto
{
    public partial class ProdutoReport : BaseLandscape
    {
        public ProdutoReport()
        {
            InitializeComponent();
            bindingSource.DataSource = ProdutoRepository.GetListAtivos();
        }

    }
}
