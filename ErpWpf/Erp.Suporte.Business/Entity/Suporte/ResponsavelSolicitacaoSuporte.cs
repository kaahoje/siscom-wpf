using System.Runtime.Serialization;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Validation;
using Erp.Suporte.Business.Entity.Cliente.PessoaFisica;

namespace Erp.Suporte.Business.Entity.Suporte
{
    [DataContract]
    public class ResponsavelSolicitacaoSuporte
    {
        private string _documento;

        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Documento
        {
            get { return _documento; }
            set
            {
                _documento = value;
                if (Validation.IsCNPJValid(value))
                {
                    PessoaJuridica = PessoaJuridicaRepository.GetByCnpj(value);
                    Pessoa = PessoaJuridica;
                }
                else if (Validation.IsCPFValid(value))
                {
                    PessoaFisica = PessoaFisicaRepository.GetByCpf(value);
                    Pessoa = PessoaFisica;
                }
            }
        }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica PessoaFisica { get; set; }
        public virtual Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica PessoaJuridica { get;
            set; }
        public virtual SolicitacaoSuporte Solicitacao { get; set; }
    }
}
