namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe repositorio de "EnderecoPais".
    /// </summary>
    public class EnderecoPaisRepository : RepositoryBase<EnderecoPais>
    {
        /// <summary>
        ///     Método que obtém o país por meio do campo nome.
        /// </summary>
        /// <param name="nome">Nome de país que será pesquisado.</param>
        /// <returns></returns>
        public static EnderecoPais GetPaisByName(string nome)
        {
            EnderecoPais pais = NHibernateHttpModule.Session.QueryOver<EnderecoPais>()
                .Where(x => x.Nome == nome)
                .Take(1)
                .SingleOrDefault();

            return pais;
        }
    }
}