using System.Collections.Generic;
using System.Windows.Forms;
using WindowsControls.Forms;
using Erp.Business.Entity.Estoque.Produto;

namespace WindowsControls.Util
{
    public class Functions
    {
        public static Produto SelecionaProduto(IList<Produto> prods)
        {
            if (prods.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado para a descrição.");
                
            }
            if (prods.Count == 1)
            {
                IEnumerator<Produto> en = prods.GetEnumerator();
                en.MoveNext();
                return en.Current;
            }
            if (prods.Count > 1)
            {
                var f = new FormProdutosEncontrados(prods);
                f.ShowDialog();
                if (!f.Cancelado)
                {
                    return f.GetProdutoSelecionado();
                }
            }
            return null;
        }
    }
}
