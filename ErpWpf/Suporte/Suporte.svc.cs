using System;
using Erp.Suporte.DataContracts;

namespace Erp.Suporte
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : ISuporte
    {
        

        public void LogDataBase(string exception)
        {
            
        }

        public void Log(string exception)
        {
            throw new NotImplementedException();
        }

        public bool LicenceValid(Licenca licenca)
        {
            throw new NotImplementedException();
        }

        public Licenca RequestLicence(Licenca licenca)
        {
            throw new NotImplementedException();
        }
    }
}
