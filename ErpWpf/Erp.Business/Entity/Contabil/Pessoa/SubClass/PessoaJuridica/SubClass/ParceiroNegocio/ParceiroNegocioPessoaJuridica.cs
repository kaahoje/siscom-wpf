using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio
{
    [DisplayClass(Nome = "Parceiro de Negócios Pessoa Júridica", HotKey = "g + f2")]
    public class ParceiroNegocioPessoaJuridica : PessoaJuridica
    {
        private decimal _limiteCredito;

        public virtual decimal SaldoDevedorAtual
        {
            get
            {
                return PessoaRepository.GetSaldoDevedorById(Id);
            }
        }

        public virtual decimal SaldoAtual
        {
            get { return LimiteCredito - SaldoDevedorAtual; }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Limite de crédito", Name = "Limite de crédito", Order = 7)]
        [GridAnnotation(Order = 7, Visible = true, Width = 150)]
        public virtual decimal LimiteCredito
        {
            get { return _limiteCredito; }
            set
            {
                if (value == _limiteCredito) return;
                _limiteCredito = value;
                OnPropertyChanged();
                IdGuid = Guid.NewGuid();
                OnPropertyChanged("SaldoAtual");
            }
        }
    }
}
