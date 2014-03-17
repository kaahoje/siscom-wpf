namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe reposirótio para a classe "EnderecoEstado"
    /// </summary>
    public class EnderecoEstadoRepository : RepositoryBase<EnderecoEstado>
    {
        public static EnderecoEstado GetEstadoByName(string nome)
        {
            EnderecoEstado estado = NHibernateHttpModule.Session.QueryOver<EnderecoEstado>()
                .Where(x => x.Nome == nome)
                .Take(1)
                .SingleOrDefault();

            return estado;
        }

        public static EnderecoEstado GetEstadoBySigla(string sigla)
        {
            EnderecoEstado estado = NHibernateHttpModule.Session.QueryOver<EnderecoEstado>()
                .Where(x => x.UF == sigla)
                .Take(1)
                .SingleOrDefault();

            return estado;
        }
    }
}