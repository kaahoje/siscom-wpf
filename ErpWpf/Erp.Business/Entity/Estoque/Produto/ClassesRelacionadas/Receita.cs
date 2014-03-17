using System;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    [Serializable]
    public class Receita
    {
        public virtual int Id { get; set; }
        public virtual Produto MateriaPrima { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual Status Status { get; set; }
    }
}