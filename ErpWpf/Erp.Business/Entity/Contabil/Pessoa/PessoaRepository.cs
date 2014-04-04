using System;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Validation;

namespace Erp.Business.Entity.Contabil.Pessoa
{
    public class PessoaRepository : RepositoryBase<Pessoa>
    {
        public new static Pessoa Save(Pessoa entity)
        {
            var s = NHibernateHttpModule.Session;
            var t = s.BeginTransaction();
            try
            {
                
                //Validate(entity);
                s.Save(entity);
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                throw;
            }
            return entity;
        }

        public new static bool Validate(Pessoa entity)
        {
            var result = DataValidation.ValidateEntity(entity);

            if (result.HasError)
            {
                throw new Exception(result.MensagemErro());
            }
            
            if (entity.Enderecos.Count == 0)
            {
                throw new Exception("É necessário informar ao menos um endereço.");
            }
            foreach (var end in entity.Enderecos)
            {
                PessoaEnderecoRepository.Validate(end);
            }
            foreach (var fone in entity.ContatoTelefonicos)
            {
                PessoaTelefoneRepository.Validate(fone);
            }
            foreach (var email in entity.EnderecoEletronicos)
            {
                PessoaContatoEletronicoRepository.Validate(email);
            }
            return true;
            
        }
        
        
     

        /// <summary>
        ///     Método que calcula o saldo devedor atual de uma pessoa cadastrada no sistema.
        /// </summary>
        /// <param name="id">Identificador da pessoa.</param>
        /// <returns></returns>
        //public static decimal GetSaldoDevedorById(int id)
        //{
        //    Pessoa pessoa = GetById(id);
        //    IList<Titulo> titulos = RepositoryBase<Titulo>.GetQueryOver().Where(titulo =>
        //        !titulo.Baixado && titulo.Pessoa == pessoa
        //        && titulo.AReceber).List<Titulo>();
        //    return titulos.Sum(titulo => titulo.ValorTotal);
        //}

        /// <summary>
        ///     Método que calcula o saldo credor atual de uma pessoa cadastrada no sistema.
        /// </summary>
        /// <param name="id">Identificador da pessoa.</param>
        /// <returns></returns>
        //public static decimal GetSaldoCredorById(int id)
        //{
        //    var pessoa = GetById(id);
        //    var titulos =
        //        RepositoryBase<Titulo>.GetQueryOver().Where(titulo => !titulo.Baixado && titulo.Pessoa == pessoa
        //                                                              && !titulo.AReceber).List<Titulo>();
        //    return titulos.Sum(titulo => titulo.ValorTotal);
        //}
    }
}