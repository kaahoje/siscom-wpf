using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Erp.Business.Entity.Estoque.Produto;

namespace WindowsControls.Forms
{
    public partial class FormProdutosEncontrados : XtraForm
    {
        public bool Cancelado { get; set; }
        public FormProdutosEncontrados(IList<Produto> produtos)
        {
            InitializeComponent();
            Cancelado = false;
            produtoBindingSource.DataSource = produtos;
        }

        private void FormProdutosEncontrados_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
        }

        public Produto GetProdutoSelecionado()
        {
            if (Cancelado)
            {
                return null;
            }
            else
            {
                return (Produto) produtoBindingSource.Current;
            }
        }

        private void FormProdutosEncontrados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Hide();
            }
            if (e.KeyData == Keys.Escape)
            {
                Cancelado = true;
                Hide();
            }
        }

    }
}