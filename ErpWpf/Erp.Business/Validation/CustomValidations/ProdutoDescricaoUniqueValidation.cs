using System.ComponentModel.DataAnnotations;
using System.Linq;
using Erp.Business.Entity.Estoque.Produto;

namespace Erp.Business.Validation.CustomValidations
{
    public class ProdutoDescricaoUniqueValidation
    {
        public static ValidationResult IsValid(string descricao)
        {

            var produto = ProdutoRepository.GetQueryOver().Where(prod => prod.Descricao == descricao).List().FirstOrDefault();
            if (produto == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Descrição de produto já existente");

        }
    }
}
