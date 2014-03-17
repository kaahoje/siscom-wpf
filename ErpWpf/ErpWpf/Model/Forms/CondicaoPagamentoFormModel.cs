using System;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids;

namespace Erp.Model.Forms
{
    public class CondicaoPagamentoFormModel : ModelFormGeneric<CondicaoPagamento>
    {
        public CondicaoPagamentoFormModel()
        {
            Entity = new CondicaoPagamento();
            ModelSelect = new CondicaoPagamentoSelectModel();
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    CondicaoPagamentoRepository.Save(Entity);
                    base.Excluir();
                }
                
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados( ex.Message);
            }
            
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    CondicaoPagamentoRepository.Save(Entity);
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
