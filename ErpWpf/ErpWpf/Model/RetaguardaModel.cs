using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Docking;
using DevExpress.XtraReports.UI;
using Erp.Business;
using Erp.Enum;
using Erp.Relatorios.CondicoesPagamento;
using Erp.Relatorios.CustosFixos;
using Erp.Relatorios.CustosFixos.ParceiroNegocioPessoaFisica;
using Erp.Relatorios.CustosFixos.ParceiroNegocioPessoaJuridica;
using Erp.Relatorios.FormasPagamento;
using Erp.Relatorios.Lancamentos;
using Erp.Relatorios.Lancamentos.ParceiroNegocioPessoaFisica;
using Erp.Relatorios.Lancamentos.ParceiroNegocioPessoaJuridica;
using Erp.Relatorios.Pessoa.PessoaFisica;
using Erp.Relatorios.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.Relatorios.Pessoa.PessoaJuridica;
using Erp.Relatorios.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.Relatorios.Produto;
using Erp.Relatorios.Titulos;
using Erp.Relatorios.Titulos.ParceiroNegocioPessoaFisica;
using Erp.Relatorios.Titulos.ParceiroNegocioPessoaJuridica;
using Erp.View.Extras;
using Erp.View.Forms;
using Erp.View.Forms.Pessoa;
using ErpWpf.Annotations;
using NHibernate;
using Util.Wpf;

namespace Erp.Model
{
    public delegate void TelaAbertaEventHandler(object sender, TelaAbertaEventArgs e);

    public class RetaguardaModel : INotifyPropertyChanged
    {


        #region Eventos

        public event TelaAbertaEventHandler TelaAberta;

        protected virtual void OnTelaAberta(string caption, UserControl control)
        {
            TelaAbertaEventHandler handler = TelaAberta;

            if (handler != null) handler(this, new TelaAbertaEventArgs()
            {
                Control = control,
                Caption = caption
            });
        }

        #endregion

        #region Keys


        public KeyGesture KeyTelaProduto
        {
            get
            {
                return new KeyGesture(Key.P, ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaCondicaoPagamento
        {
            get
            {
                return new KeyGesture(Key.C, ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaFormaPagamento
        {
            get
            {
                return new KeyGesture(Key.F, ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaTransferencias
        {
            get
            {
                return new KeyGesture(Key.F, ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaLancamentos
        {
            get
            {
                return new KeyGesture(Key.F, ModifierKeys.Alt);
            }
        }

        #endregion
        #region Properties
        #endregion
        #region Commands

        public ICommand CmdAbrirTelaCustoFixo { get { return new RelayCommandBase(x => AbrirTelaCustoFixo()); } }
        public ICommand CmdAbrirTelaTitulo { get { return new RelayCommandBase(x => AbrirTelaTitulo()); } }
        public ICommand CmdAbrirTelaLancamento { get { return new RelayCommandBase(x => AbrirTelaLancamento()); } }
        public ICommand CmdAbrirTelaTipoTitulo { get { return new RelayCommandBase(x => AbrirTelaTipoTitulo()); } }
        public ICommand CmdAbrirTelaPermissoesUsuario { get { return new RelayCommandBase(x => AbrirTelaPermissoesUsuario()); } }
        public ICommand CmdAbrirTelaGerarMes { get { return new RelayCommandBase(x => AbrirTelaGerarMes()); } }

        public ICommand CmdAbrirTelaParceiroNegocio
        {
            get { return new RelayCommandBase(x => AbrirTelaParceiroNegocio()); }
        }



        public ICommand CmdAbrirTelaUnidade
        {
            get { return new RelayCommandBase(x => AbrirTelaUnidade()); }
        }

        public ICommand CmdAbrirTelaGrupoProduto
        {
            get { return new RelayCommandBase(x => AbrirTelaGrupoProduto()); }
        }
        public ICommand CmdAbrirTelaSubGrupoProduto
        {
            get { return new RelayCommandBase(x => AbrirTelaSubGrupoProduto()); }
        }

        public ICommand CmdAbrirTelaProduto
        {
            get { return new RelayCommandBase(o => AbrirTelaProduto()); }

        }
        public ICommand CmdAbrirTelaNotaFiscalEntrada { get { return new RelayCommandBase(x=> AbrirTelaNotaFiscalEntrada());} }
        public ICommand CmdAbrirTelaNotaFiscalSaida{ get { return new RelayCommandBase(x=> AbrirTelaNotaFiscalSaida());} }

        

        public ICommand CmdAbrirTelaFormaPagamento
        {
            get { return new RelayCommandBase(o => AbrirTelaFormaPagamento()); }

        }
        public ICommand CmdAbrirTelaNcm
        {
            get { return new RelayCommandBase(o => AbrirTelaNcm()); }

        }

        public ICommand CmdAbrirTelaCondicaoPagamento
        {
            get { return new RelayCommandBase(x => AbrirTelaCondicaoPagamento()); }

        }



        #endregion

        #region Commands Extras

        public ICommand CmdAbrirTelaAtualizacaoProduto { get { return new RelayCommandBase(x => AbrirTelaAtualizacaoProduto()); } }

        #endregion
        #region Comandos de abertura de tela

        public void AbrirTelaPermissoesUsuario()
        {
            new PermissaoUsuarioFormView().ShowDialog();
        }

        private void AbrirTelaGerarMes()
        {
            new MesGeradoFormView().ShowDialog();
        }

        public void AbrirTelaTipoTitulo()
        {
            new TipoTituloFormView().ShowDialog();
        }
        public void AbrirTelaCustoFixo()
        {
            new TipoPessoaSelectView(TipoCadastroPessoa.CustoFixo).ShowDialog();
        }
        public void AbrirTelaTitulo()
        {
            new TipoPessoaSelectView(TipoCadastroPessoa.Titulo).ShowDialog();
        }

        public void AbrirTelaLancamento()
        {
            new TipoPessoaSelectView(TipoCadastroPessoa.Lancamento).ShowDialog();
        }

        public void AbrirTelaParceiroNegocio()
        {
            new TipoPessoaSelectView(TipoCadastroPessoa.ParceiroNegocio).ShowDialog();
        }

        public void AbrirTelaUnidade()
        {
            new UnidadeFormView().ShowDialog();
        }

        public void AbrirTelaGrupoProduto()
        {
            new GrupoProdutoFormView().ShowDialog();
        }
        public void AbrirTelaSubGrupoProduto()
        {
            new SubGrupoProdutoFormView().ShowDialog();
        }
        public void AbrirTelaProduto()
        {
            new ProdutoFormView().ShowDialog();
        }
        private void AbrirTelaNotaFiscalEntrada()
        {
            new NotaFiscalFormView(true).ShowDialog();
        }

        private void AbrirTelaNotaFiscalSaida()
        {
            new NotaFiscalFormView(false).ShowDialog();
        }


        public void AbrirTelaFormaPagamento()
        {
            new FormaPagamentoFormView().ShowDialog();
        }
        public void AbrirTelaNcm()
        {
            new NcmFormView().ShowDialog();
        }

        public void AbrirTelaCondicaoPagamento()
        {
            new CondicaoPagamentoFormView().ShowDialog();
        }

        #endregion

        #region Comandos de abertura de relatórios

        public void AbrirRelatorio(XtraReport report)
        {
            NHibernateHttpModule.Session.CacheMode = CacheMode.Refresh;
            report.ShowPreviewDialog();
            NHibernateHttpModule.Session.CacheMode = CacheMode.Normal;
        }
        #region Condiões de pagamento
        public ICommand CmdRelatorioCondicaoPagamento { get { return new RelayCommandBase(x => RelatorioCondicaoPagamento()); } }

        private void RelatorioCondicaoPagamento()
        {
            AbrirRelatorio(new CondicaoPagamentoReport());
        }

        #endregion

        #region Custo fixo

        public ICommand CmdRelatorioCustoFixo { get { return new RelayCommandBase(x => RelatorioCustoFixo()); } }

        private void RelatorioCustoFixo()
        {
            AbrirRelatorio(new CustoFixoReport());
        }
        public ICommand CmdRelatorioCustoFixoParceiroNegocioPessoaFisica { get { return new RelayCommandBase(x => RelatorioCustoFixoParceiroNegocioPessoaFisica()); } }

        private void RelatorioCustoFixoParceiroNegocioPessoaFisica()
        {
            AbrirRelatorio(new CustoFixoParceiroNegocioPessoaFisicaReport());
        }

        public ICommand CmdRelatorioCustoFixoParceiroNegocioPessoaJuridica { get { return new RelayCommandBase(x => RelatorioCustoFixoParceiroNegocioPessoaJuridica()); } }

        private void RelatorioCustoFixoParceiroNegocioPessoaJuridica()
        {
            AbrirRelatorio(new CustoFixoParceiroNegocioPessoaJuridicaReport());
        }

        #endregion

        #region Formas de pagamento
        public ICommand CmdRelatorioFormaPagamento { get { return new RelayCommandBase(x => RelatorioFormaPagamento()); } }

        private void RelatorioFormaPagamento()
        {
            AbrirRelatorio(new FormaPagamentoReport());
        }

        #endregion

        #region Lançamentos
        #region Resumidos
        public ICommand CmdRelatorioLancamentoResumidoPeriodo { get { return new RelayCommandBase(x => RelatorioLancamentoResumidoPeriodo()); } }

        private void RelatorioLancamentoResumidoPeriodo()
        {
            AbrirRelatorio(new LancamentoResumidoPeriodoReport());
        }

        public ICommand CmdRelatorioLancamentoParceiroNegocioPessoaFisicaResumidoPeriodo { get { return new RelayCommandBase(x => RelatorioLancamentoParceiroNegocioPessoaFisicaResumidoPeriodo()); } }

        private void RelatorioLancamentoParceiroNegocioPessoaFisicaResumidoPeriodo()
        {
            AbrirRelatorio(new LancamentoParceiroNegocioPessoaFisicaResumidoPeriodoReport());
        }
        public ICommand CmdRelatorioLancamentoParceiroNegocioPessoaJuridicaResumidoPeriodo { get { return new RelayCommandBase(x => RelatorioLancamentoParceiroNegocioPessoaJuridicaResumidoPeriodo()); } }

        private void RelatorioLancamentoParceiroNegocioPessoaJuridicaResumidoPeriodo()
        {
            AbrirRelatorio(new LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport());
        }

        #endregion

        #region Detalhados

        #endregion

        #endregion

        #region Pessoa
        #region Resumida

        #endregion

        #region Detalhada

        public ICommand CmdRelatorioPessoaFisicaDetalhada
        {
            get { return new RelayCommandBase(x => RelatorioPessoaFisicaDetalhada()); }
        }

        private void RelatorioPessoaFisicaDetalhada()
        {
            AbrirRelatorio(new PessoaFisicaDetalhadaReport());
        }

        public ICommand CmdRelatorioPessoaJuridicaDetalhada
        {
            get { return new RelayCommandBase(x=>RelatorioPessoaJuridicaDetalhada());}
        }

        private void RelatorioPessoaJuridicaDetalhada()
        {
            AbrirRelatorio(new PessoaJuridicaDetalhadaReport());
        }

        public ICommand CmdRelatorioParceiroNegocioPessoaFisicaDetalhada
        {
            get { return new RelayCommandBase(x=>RelatorioParceiroNegocioPessoaFisicaDetalhada());}
        }

        private void RelatorioParceiroNegocioPessoaFisicaDetalhada()
        {
            AbrirRelatorio(new ParceiroNegocioPessoaFisicaDetalhadaReport());
        }

        public ICommand CmdRelatorioParceiroNegocioPessoaJuridicaDetalhada
        {
            get {return new RelayCommandBase(x=>RelatorioParceiroNegocioPessoaJuridicaDetalhada());}
        }

        private void RelatorioParceiroNegocioPessoaJuridicaDetalhada()
        {
            AbrirRelatorio(new ParceiroNegocioPessoaJuridicaDetalhadaReport());
        }

        #endregion

        #endregion

        #region Produto

        public ICommand CmdRelatorioProduto
        {
            get { return new RelayCommandBase(x=>RelatorioProduto());}
        }

        private void RelatorioProduto()
        {
            AbrirRelatorio(new ProdutoReport());
        }

        #endregion

        #region Titulos

        public ICommand CmdRelatorioTituloPeriodo
        {
            get { return new RelayCommandBase(x=>RelatorioTituloPeriodo());}
        }

        private void RelatorioTituloPeriodo()
        {
            AbrirRelatorio(new TituloPeriodoReport());
        }

        public ICommand CmdRelatorioTituloPeriodoGrupoData
        {
            get { return new RelayCommandBase(x=>RelatorioTituloPeriodoGrupoData());}
        }

        private void RelatorioTituloPeriodoGrupoData()
        {
            AbrirRelatorio(new TituloPeriodoGrupoDataReport());
        }
        public ICommand CmdRelatorioTituloPeriodoGrupoTipo
        {
            get { return new RelayCommandBase(x=>RelatorioTituloPeriodoGrupoTipo());}
        }

        private void RelatorioTituloPeriodoGrupoTipo()
        {
            AbrirRelatorio(new TituloPeriodoGrupoTipoReport());
        }
        public ICommand CmdRelatorioTituloParceiroNegocioPessoaFisicaPeriodo
        {
            get { return new RelayCommandBase(x => RelatorioTituloParceiroNegocioPessoaFisicaPeriodo()); }
        }

        private void RelatorioTituloParceiroNegocioPessoaFisicaPeriodo()
        {
            AbrirRelatorio(new TituloParceiroNegocioPessoaFisicaPeriodoReport());
        }

        public ICommand CmdRelatorioTituloParceiroNegocioPessoaFisicaPeriodoGrupoData
        {
            get { return new RelayCommandBase(x => RelatorioTituloParceiroNegocioPessoaFisicaPeriodoGrupoData()); }
        }

        private void RelatorioTituloParceiroNegocioPessoaFisicaPeriodoGrupoData()
        {
            AbrirRelatorio(new TituloParceiroNegocioPessoaFisicaPeriodoGrupoDataReport());
        }
        public ICommand CmdRelatorioTituloParceiroNegocioPessoaFisicaPeriodoGrupoTipo
        {
            get { return new RelayCommandBase(x => RelatorioTituloParceiroNegocioPessoaFisicaPeriodoGrupoTipo()); }
        }

        private void RelatorioTituloParceiroNegocioPessoaFisicaPeriodoGrupoTipo()
        {
            AbrirRelatorio(new TituloParceiroNegocioPessoaFisicaPeriodoGrupoTipoReport());
        }

        public ICommand CmdRelatorioTituloParceiroNegocioPessoaJuridicaPeriodo
        {
            get { return new RelayCommandBase(x => RelatorioTituloParceiroNegocioPessoaJuridicaPeriodo()); }
        }

        private void RelatorioTituloParceiroNegocioPessoaJuridicaPeriodo()
        {
            AbrirRelatorio(new TituloParceiroNegocioPessoaJuridicaPeriodoReport());
        }

        public ICommand CmdRelatorioTituloParceiroNegocioPessoaJuridicaPeriodoGrupoData
        {
            get { return new RelayCommandBase(x => RelatorioTituloParceiroNegocioPessoaJuridicaPeriodoGrupoData()); }
        }

        private void RelatorioTituloParceiroNegocioPessoaJuridicaPeriodoGrupoData()
        {
            AbrirRelatorio(new TituloParceiroNegocioPessoaJuridicaPeriodoGrupoData());
        }
        public ICommand CmdRelatorioTituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipo
        {
            get { return new RelayCommandBase(x => RelatorioTituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipo()); }
        }

        private void RelatorioTituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipo()
        {
            AbrirRelatorio(new TituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipoReport());
        }

        #endregion

        #endregion

        #region Comandos de abertura de telas extras

        private void AbrirTelaAtualizacaoProduto()
        {
            new AtualizacaoProdutoFormView().ShowDialog();
        }

        #endregion
        public void AbrirTela(string caption, UserControl control)
        {
            OnTelaAberta(caption, control);
        }

        public void FecharTela(DocumentPanel panel)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TelaAbertaEventArgs : EventArgs
    {
        public string Caption { get; set; }
        public UserControl Control { get; set; }
    }
}
