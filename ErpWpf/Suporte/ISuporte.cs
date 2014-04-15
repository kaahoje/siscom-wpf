using System.Runtime.Serialization;
using System.ServiceModel;
using Erp.Suporte.DataContracts;

namespace Erp.Suporte
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISuporte
    {

        [OperationContract]
        void LogDataBase(string exception);

        [OperationContract]
        void Log(string exception);

        [OperationContract]
        bool LicenceValid(Licenca licenca);

        [OperationContract]
        Licenca RequestLicence(Licenca licenca);
    }


    
}
