using System.ServiceModel;
using Erp.Suporte;

namespace Erp
{
    public class Services
    {
        private static ServiceClient _suporteClient;

        public static ServiceClient SuporteClient
        {
            get
            {
                if (_suporteClient == null)
                {
                    var end = new EndpointAddress("http://localhost:5269/Suporte.svc");
                    var bind = new WSHttpBinding(SecurityMode.None);
                    bind.Security.Mode = SecurityMode.None;
                    //bind.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                    _suporteClient = new ServiceClient();

                }
                return _suporteClient;
            }
            set { _suporteClient = value; }
        }
    }
}
