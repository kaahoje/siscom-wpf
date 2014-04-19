using System.ComponentModel.DataAnnotations;

namespace RestauranteMobile.Models
{
    public class NovoPedidoModel 
    {
        [Display(Name = "Mesa", Description = "Número da mesa")]
        [Required(ErrorMessage = "Informe o número da mesa")]
        [Range(1,100,ErrorMessage = "O número da mesa deve estar entre 1 e 100")]
        public virtual int Mesa { get; set; }
    }
}