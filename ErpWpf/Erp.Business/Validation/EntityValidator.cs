using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Validation
{
    public class EntityValidator<T>
    {
        public EntityValidationResult Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            
            var vc = new ValidationContext(entity, null, null);
            bool isValid = Validator.TryValidateObject(entity, vc, validationResults, true);

            return new EntityValidationResult(validationResults);
        }
    }
}