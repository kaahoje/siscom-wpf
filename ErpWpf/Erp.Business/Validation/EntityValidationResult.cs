using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Validation
{
    public class EntityValidationResult
    {
        public EntityValidationResult(IList<ValidationResult> violations = null)
        {
            ValidationErrors = violations ?? new List<ValidationResult>();
        }

        public IList<ValidationResult> ValidationErrors { get; private set; }

        public bool HasError
        {
            get { return ValidationErrors.Count > 0; }
        }

        public string MensagemErro()
        {
            string mensagem = "Erros encontrados no preenchimento dos campos.|";
            foreach (ValidationResult error in ValidationErrors)
            {
                mensagem +=error.ErrorMessage + "|";
            }
            return mensagem;
        }
    }
}