using Ecf.ImplementacaoEcf;
using Erp.Business.Enum;

namespace Ecf
{
    public class EcfHelper
    {
        private static AbstractEcf _ecf;
        public static FabricanteEcf FabricanteEcf { get; set; }

        public static AbstractEcf Ecf
        {
            get
            {

                switch (FabricanteEcf)
                {
                    case FabricanteEcf.Bematech:
                        return _ecf ?? (_ecf = new BematechEcf());
                    case FabricanteEcf.Daruma:
                        return _ecf ?? (_ecf = new DarumaEcf());
                    default:
                        return _ecf ?? (_ecf = new ErroConfiguracaoEcf());
                }

            }
            set { _ecf = value; }
        }


       
    }
}
