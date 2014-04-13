using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaJuridica : CustoFixo
    {
        private ParceiroNegocioPessoaJuridica _parceiroNegocioPessoaJuridica;

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Name = "Pessoa", Description = "Parceiro de negócios")]
        public virtual ParceiroNegocioPessoaJuridica ParceiroNegocioPessoaJuridica
        {
            get { return _parceiroNegocioPessoaJuridica; }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaJuridica)) return;
                _parceiroNegocioPessoaJuridica = value;
                OnPropertyChanged();
            }
        }
    }
}
