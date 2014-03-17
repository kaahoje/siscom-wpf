using System.Linq;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe repositório de telefone.
    /// </summary>
    public class PessoaTelefoneRepository : RepositoryBase<PessoaTelefone>
    {
        public static string GetPrimeiroTelefoneResidencial()
        {
            var telefone = Session.QueryOver<PessoaTelefone>()
                .List()
                .Where(x => x.TelefoneTipo == TelefoneTipo.Residencial)
                .Take(1)
                .SingleOrDefault();

            return telefone != null ? telefone.Numero : string.Empty;
        }

        public static string GetPrimeiroTelefoneComercial()
        {
            var telefone = Session.QueryOver<PessoaTelefone>()
                .List()
                .Where(x => x.TelefoneTipo == TelefoneTipo.Comercial)
                .Take(1)
                .SingleOrDefault();
            return telefone != null ? telefone.Numero : string.Empty;
        }

        public static string GetPrimeiroTelefoneRecado()
        {
            var telefone = Session.QueryOver<PessoaTelefone>()
                .List()
                .Where(x => x.TelefoneTipo == TelefoneTipo.Fax)
                .Take(1)
                .SingleOrDefault();

            return telefone != null ? telefone.Numero : string.Empty;
        }

        public static string GetPrimeiroTelefoneCelular()
        {
            var telefone = Session.QueryOver<PessoaTelefone>()
                .List()
                .Where(x => x.TelefoneTipo == TelefoneTipo.Movel)
                .Take(1)
                .SingleOrDefault();

            return telefone != null ? telefone.Numero : string.Empty;
        }
    }
}