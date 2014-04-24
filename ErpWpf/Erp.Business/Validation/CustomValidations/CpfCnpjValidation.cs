using System;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Validation.CustomValidations
{
    public class CpfCnpjValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var ret = IsCpfCnpjValid(value == null ? "" : value.ToString());

            if (ret != null) ErrorMessage = ret.ErrorMessage;
            return ret;
        }

        public static ValidationResult IsCpfCnpjValid(string cpfCnpj)
        {


            var val = Validation.GetOnlyNumber(cpfCnpj);

            if (String.IsNullOrEmpty(val))
            {
                return new ValidationResult("Campo CPF/CNPJ não informado");
            }
            if (Validation.IsCNPJValid(val) || Validation.IsCPFValid(val))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("CPF ou CNPJ inválido");
        }
    }
}
