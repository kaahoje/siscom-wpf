using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;

namespace Erp.Business.Validation.CustomValidations
{
    public class CpfCnpjValidation
    {
        
        public static ValidationResult IsCpfCnpjValid(string cpfCnpj)
        {

            
            var val = Validation.GetOnlyNumber(cpfCnpj);

            if (String.IsNullOrEmpty(val))
            {
                return new ValidationResult("Campo CPF/CNPJ não informado");
            }
            if (Validation.IsCNPJValid(val) || Validation.IsCPFValid(val))
            {
                if (val.Length < 14)
                {
                    var pessoa = PessoaFisicaRepository.GetByCpf(val);
                    if (pessoa != null)
                    {
                        return new ValidationResult("Já existe uma pessoa cadastrada com esse CPF");
                    }
                }
                else
                {
                    var pessoa = PessoaJuridicaRepository.GetByCnpj(val);
                    if (pessoa != null)
                    {
                        return new ValidationResult("Já existe uma pessoa cadastrada com esse CNPJ");
                    }
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("CPF ou CNPJ inválido");
            }
        }
    }
}
