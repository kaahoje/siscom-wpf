using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class TituloParceiroNegocioPessoaFisica : Titulo
    {
        private ParceiroNegocioPessoaFisica _parceiroNegocioPessoaFisica;

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Name = "Pessoa", Description = "Parceiro de negócios")]
        public virtual ParceiroNegocioPessoaFisica ParceiroNegocioPessoaFisica
        {
            get { return _parceiroNegocioPessoaFisica; }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaFisica)) return;
                _parceiroNegocioPessoaFisica = value;
                OnPropertyChanged();
            }
        }
    }
}
