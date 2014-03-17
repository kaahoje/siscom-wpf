using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum ConfNomesBancoDados
    {
        [Display(Name="PostgreSQL 8.5")]
        PostgreSql,
        [Display(Name = "Firebird 2.5")]
        Firebird,
        [Display(Name = "MySql 3.0")]
        MySql
    }
}