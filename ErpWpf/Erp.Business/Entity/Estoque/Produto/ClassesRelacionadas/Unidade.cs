using System;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    [Serializable]
    public class Unidade
    {
        public virtual int Id { get; set; }
        public virtual string Sigla { get; set; }
        public virtual string Descricao { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual Status Status { get; set; }
    }
}