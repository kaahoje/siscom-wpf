using System;
using System.Collections.Generic;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using Remotion.Linq.Collections;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante
{
    [Serializable]
    public class PedidoRestaurante : Pedido
    {
        public PedidoRestaurante()
        {
            Produtos = new ObservableCollection<ComposicaoProduto>();
        }
        /// <summary>
        /// Hora de entrada do pedido.
        /// </summary>
        public virtual TimeSpan HoraEntrada { get; set; }
        /// <summary>
        /// Hora em que a cozinha entregou o pedido.
        /// </summary>
        public virtual TimeSpan HoraProducao { get; set; }
        /// <summary>
        /// Hora em que o motoboy chegou na pizzaria após a entrega da pizza.
        /// </summary>
        public virtual TimeSpan HoraEntrega { get; set; }
        public virtual StatusProducaoPedido StatusProducao { get; set; }
        public virtual LocalPedidoRestaurante Local { get; set; }
        public virtual int Mesa { get; set; }

        /// <summary>
        ///     Propriedade que indica se o pedido já foi confirmado. Esta por sua vez não é guardada no banco de dados
        ///     que pode ser usada para controle nas telas.
        /// </summary>
        public virtual bool Confirmado { get; set; }

        public virtual ControlePedido Controle { get; set; }
        public virtual IList<ComposicaoProduto> Produtos { get; set; }
    }
}