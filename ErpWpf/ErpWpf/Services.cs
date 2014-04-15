using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using Erp.Suporte;

namespace Erp
{
    public class Services
    {
        private static SuporteClient _suporteClient;

        public static SuporteClient SuporteClient
        {
            get
            {
                if (_suporteClient == null)
                {
                    var end = new EndpointAddress("http://localhost:1430/Suporte.svc");
                    var bind = new WSHttpBinding(SecurityMode.Transport);
                    _suporteClient = new SuporteClient(bind, end);
                    
                }
                return _suporteClient;
            }
            set { _suporteClient = value; }
        }
    }
}
