using Erp.Business.Entity.Sped;
using Erp.Model.Grids;

namespace Erp.Model.Forms
{
    public class NcmFormModel : ModelFormGeneric<Ncm>
    {
        public NcmFormModel()
        {
            ModelSelect = new NcmSelectModel();
            Entity = new Ncm();
            IsSalvar = false;
            IsExcluir = false;
        }

        public override void Salvar()
        {
            MensagemErro(MensagemFuncaoNaoSuportada);
        }

        public override void Excluir()
        {
            MensagemErro(MensagemFuncaoNaoSuportada);
        }
    }
}
