using System;
using System.Collections.Generic;
using Erp.Business;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids;

namespace Erp.Model.Forms
{
    public class SubGrupoProdutoFormModel : ModelFormGeneric<SubGrupoProduto>
    {
        public SubGrupoProdutoFormModel()
        {
            Entity = new SubGrupoProduto();
            ModelSelect = new SubGrupoProdutoSelectModel();
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {

                    SubGrupoProdutoRepository.Save(Entity);
                    Entity = new SubGrupoProduto();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    SubGrupoProdutoRepository.Save(Entity);
                    Entity = new SubGrupoProduto();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }

        public IList<GrupoProduto> Grupos
        {
            get { return GrupoProdutoRepository.GetListAtivos(); }
        }
    }
}
