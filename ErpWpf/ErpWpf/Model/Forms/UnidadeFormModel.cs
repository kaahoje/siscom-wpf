using System;
using Erp.Business;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids;

namespace Erp.Model.Forms
{
    public class UnidadeFormModel : ModelFormGeneric<Unidade>
    {
        public UnidadeFormModel()
        {
            Entity = new Unidade();
            ModelSelect = new UnidadeSelectModel();
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    UnidadeRepository.Save(Entity);
                    Entity = new Unidade();
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
                    UnidadeRepository.Save(Entity);
                    Entity = new Unidade();
                    base.Excluir();
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
