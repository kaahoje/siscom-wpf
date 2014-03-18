﻿using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for CondicaoPagamentoFormView.xaml
    /// </summary>
    public partial class CondicaoPagamentoFormView 
    {
        private FormDefaultActions<CondicaoPagamento> FormDefaultActions { get; set; }
        public CondicaoPagamentoFormView()
        {
            InitializeComponent();
            DataContext = new CondicaoPagamentoFormModel();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions<CondicaoPagamento>(this);
        }
    }
}
