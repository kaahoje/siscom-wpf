using System;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    [Serializable]
    public class ControlePedido
    {
        public virtual int Id { get; set; }
        public virtual int Controle { get; set; }
        public virtual string Chave { get; set; }
    }
}