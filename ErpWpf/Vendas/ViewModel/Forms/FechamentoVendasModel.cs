using System.Collections.ObjectModel;
using System.Windows.Input;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Sangria;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Suprimento;
using Util.Wpf;

namespace Vendas.ViewModel.Forms
{
    public class FechamentoVendasModel : FormModelBase
    {
        public ObservableCollection<Sangria> Sangrias { get; set; } 
        public ObservableCollection<Suprimento> Suprimentos { get; set; }
        public ObservableCollection<PagamentoCliente> PagamentoClientes { get; set; }
        /// <summary>
        /// Nesta propriedade devem ser listadas apenas as o total de vendas 
        /// </summary>
        public ObservableCollection<RecebimentoVenda> RecebimentoVenda { get; set; }
        public decimal LancamentoInicial { get; set; }
        public decimal Suprimento { get; set; }
        public decimal Sangria { get; set; }
        public decimal VendasAPrazo { get; set; }
        public decimal VendasAVista { get; set; }
        public decimal VendaTotal { get; set; }
        public decimal TotalEmCaixa { get; set; }

        public ICommand CmdFecharCaixa
        {
            get
            {
                return new RelayCommandBase(x=>FecharCaixa());
            }
        }

        private void FecharCaixa()
        {
            
        }
    }
}
