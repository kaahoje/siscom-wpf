using System;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Suprimento;
using Util;

namespace Vendas.ViewModel.Forms
{
    public class SuprimentoModel : FormModelGeneric<Suprimento>
    {
        public SuprimentoModel()
        {
            Entity = new Suprimento();
        }

        public override void Salvar()
        {
            try
            {
                if (MovimentacaoCaixaRepository.LancarSuprimento(
                    Entity.Valor,
                    Entity.Historico,
                    Entity.Caixa,
                    DateTime.Now.Date,
                    App.Proprietaria,
                    App.Usuario
                    ))
                {
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErroBancoDados(ex.Message);
            }
        }
    }
}
