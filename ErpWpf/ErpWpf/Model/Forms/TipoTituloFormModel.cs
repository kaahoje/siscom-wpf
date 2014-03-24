using System;
using Erp.Business.Entity.Contabil;
using Erp.Business.Enum;

namespace Erp.Model.Forms
{
    public class TipoTituloFormModel : ModelFormGeneric<TipoTitulo>
    {
        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    TipoTituloRepository.Save(Entity);
                    Entity = new TipoTitulo();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    TipoTituloRepository.Save(Entity);
                    Entity = new TipoTitulo();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }
    }
}
