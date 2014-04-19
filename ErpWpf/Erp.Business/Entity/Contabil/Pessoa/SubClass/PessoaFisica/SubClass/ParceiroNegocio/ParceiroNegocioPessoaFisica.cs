using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio
{
    [Serializable]
    [DisplayClass(Nome = "Teste do nome para classe", HotKey = "b + f9")]
    public class ParceiroNegocioPessoaFisica :PessoaFisica
    {
        
        //public virtual decimal SaldoDevedorAtual
        //{
        //    get
        //    {
        //       return PessoaRepository.GetSaldoDevedorById(Id);
        //    }
        //}

        //public virtual decimal SaldoAtual
        //{
        //    get { return LimiteCredito - SaldoDevedorAtual; }
        //}
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Limite de crédito", Name = "Limite de crédito", Order = 8)]
        [GridAnnotation(Order = 5, Visible = true, Width = 150)]
        public virtual decimal LimiteCredito { get; set; }

        
    }
}