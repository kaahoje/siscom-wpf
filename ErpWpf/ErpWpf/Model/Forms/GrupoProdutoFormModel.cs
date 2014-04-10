using System;
using Erp.Business;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids;

namespace Erp.Model.Forms
{
    public class GrupoProdutoFormModel : ModelFormGeneric<GrupoProduto>
    {
        public GrupoProdutoFormModel()
        {
            Entity = new GrupoProduto();
            ModelSelect = new GrupoProdutoSelectModel();
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    GrupoProdutoRepository.Save(Entity);
                    Entity = new GrupoProduto();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
            
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    GrupoProdutoRepository.Save(Entity);
                    Entity = new GrupoProduto();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
            
        }
    }
}
