using System;
using Erp.Business;
using Erp.Properties;
using Erp.Suporte;

namespace Erp.Model.Forms
{
    public class RequisicaoLicencaFormModel : ModelFormGeneric<LicencaConcedida>
    {
        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    var lic = Services.SuporteClient.RequestLicense(Entity);
                    if (!string.IsNullOrEmpty(lic))
                    {
                        Entity.Codigo = lic;
                        //Settings.Default.Lix = Entity;
                    }
                }
            }
            catch (Exception ex)
            {
                MensagemErro(ex.Message);
                Utils.GerarLog(ex);
            }
        }
    }
}
