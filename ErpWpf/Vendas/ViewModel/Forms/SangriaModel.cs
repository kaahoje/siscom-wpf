using System;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Sangria;
using Util;
using Vendas.Properties;

namespace Vendas.ViewModel.Forms
{
    public class SangriaFormModel : FormModelGeneric<Sangria>
    {
        public SangriaFormModel()
        {
            Entity = new Sangria();
        }
        public override void Salvar()
        {
            try
            {
                if (MovimentacaoCaixaRepository.LancarSangria(
                    Entity.Valor,
                    Entity.Historico, 
                    Settings.Default.Caixa,
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
