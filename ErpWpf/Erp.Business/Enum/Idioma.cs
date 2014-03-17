using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum Idioma
    {
        [Display(Name = "pt-BR")]
        PortugesBrasil = 0,

        [Display(Name = "en-US")]
        Ingles = 1,

        [Display(Name = "es")]
        Espanhol = 2
    }
}
