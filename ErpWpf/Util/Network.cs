using System.Net.Http;
using System.Net.NetworkInformation;
using System.ServiceModel.Channels;
using System.Web;

namespace Util
{
    public class Network
    {
        public static string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                var prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];

                return prop.Address;
            }

            return null;
        }

        public static string GetClienteMAC()
        {
            var nics = NetworkInterface.GetAllNetworkInterfaces();

            if (nics.Length > 0)
            {
                return nics[0].GetPhysicalAddress().ToString();
            }

            return null;
        }

        public static string GetClienteMACId()
        {
            var nics = NetworkInterface.GetAllNetworkInterfaces();

            if (nics.Length > 0)
            {
                return nics[0].Id;
            }

            return null;
        }
    }
}
