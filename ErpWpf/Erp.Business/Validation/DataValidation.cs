namespace Erp.Business.Validation
{
    public class DataValidation
    {
        public static EntityValidationResult ValidateEntity<T>(T entity)
        {
            return new EntityValidator<T>().Validate(entity);
        }
    }
}