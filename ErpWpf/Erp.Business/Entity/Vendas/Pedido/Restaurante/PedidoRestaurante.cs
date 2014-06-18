using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using Remotion.Linq.Collections;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante
{
    [Serializable]
    public class PedidoRestaurante : Pedido
    {
        private int _mesa;
        private bool _confirmado;
        private ControlePedido _controle;
        private IList<ComposicaoProduto> _produtos;
        private StatusProducaoPedido _statusProducao;
        private ParceiroNegocioPessoaFisica _garcon;
        private TimeSpan _horaEntrada;
        private LocalPedidoRestaurante _local1;

        public PedidoRestaurante()
        {
            Produtos = new ObservableCollection<ComposicaoProduto>();
        }
        /// <summary>
        /// Hora de entrada do pedido.
        /// </summary>
        /// <summary>
        /// Hora em que a cozinha entregou o pedido.
        /// </summary>
        public virtual TimeSpan HoraProducao { get; set; }
        /// <summary>
        /// Hora em que o motoboy chegou na pizzaria após a entrega da pizza.
        /// </summary>
        public virtual TimeSpan HoraEntrega { get; set; }

        public virtual LocalPedidoRestaurante Local
        {
            get { return _local1; }
            set
            {
                if (value == _local1) return;
                _local1 = value;
                OnPropertyChanged();
            }
        }

        public virtual int Mesa
        {
            get { return _mesa; }
            set
            {
                if (value == _mesa) return;
                _mesa = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Propriedade que indica se o pedido já foi confirmado. Esta por sua vez não é guardada no banco de dados
        ///     que pode ser usada para controle nas telas.
        /// </summary>
        public virtual bool Confirmado
        {
            get { return _confirmado; }
            set
            {
                if (value.Equals(_confirmado)) return;
                _confirmado = value;
                OnPropertyChanged();
            }
        }

        public virtual ControlePedido Controle
        {
            get { return _controle; }
            set
            {
                if (Equals(value, _controle)) return;
                _controle = value;
                OnPropertyChanged();
            }
        }

        public virtual IList<ComposicaoProduto> Produtos
        {
            get { return _produtos; }
            set
            {
                if (Equals(value, _produtos)) return;
                _produtos = value;
                OnPropertyChanged();
            }
        }

        public virtual StatusProducaoPedido StatusProducao
        {
            get { return _statusProducao; }
            set
            {
                if (value == _statusProducao) return;
                _statusProducao = value;
                OnPropertyChanged();
            }
        }

        public virtual ParceiroNegocioPessoaFisica Garcon
        {
            get { return _garcon; }
            set
            {
                if (Equals(value, _garcon)) return;
                _garcon = value;
                OnPropertyChanged();
            }
        }

        public virtual TimeSpan HoraEntrada
        {
            get { return _horaEntrada; }
            set
            {
                if (value.Equals(_horaEntrada)) return;
                _horaEntrada = value;
                OnPropertyChanged();
            }
        }
    }
}