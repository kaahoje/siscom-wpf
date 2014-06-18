using Erp.Business.Entity.Configuracao;
using Util;

namespace Erp.Model.Forms
{
    public class ConfiguracaoFormModel : ModelFormGeneric<ConfiguracaoGeral>
    {
        public ConfiguracaoFormModel()
        {
            Entity = new ConfiguracaoGeral();
            ModelSelect = null;
            IsPesquisar = false;
        }
        public override void Excluir()
        {
            CustomMessageBox.MensagemInformativa("Esta operação não é suportada.");
        }

        public override void Salvar()
        {
            ConfiguracaoGeralRepository.Save(Entity);
        }
    }
}
