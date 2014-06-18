using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Entity.Fiscal.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using Erp.Model.Grids;
using Erp.Model.LargeDataModel;


namespace Erp.Model.Forms
{
    public class NotaFiscalFormModelModel : ModelFormGeneric<NotaFiscal>
    {
        public NotaFiscalFormModelModel()
        {
            ModelSelect = new NotaFiscalSelectModel();

            try
            {
                
                Ncms = App.Ncms;
                Csts = App.Csts;
                Cfops = CfopRepository.GetList();
                NaturezasInterna = NaturezaInternaRepository.GetList();
                IsCancelado = true;
                IsSalvar = true;
                IsLimpar = true;
                IsPesquisar = true;
            }
            catch (Exception)
            {
                
            }
            
        }

        public override NotaFiscal Entity
        {
            get { return base.Entity; }
            set
            {
                base.Entity = value;
                Entity.Entrada = _entrada;
                if (_entrada)
                {
                    Entity.Destinatario = App.Configuracao.Proprietaria;
                }
                else
                {
                    Entity.Emitente = App.Configuracao.Proprietaria;
                }
            }
        }

        public ModeloNotaFiscalDictionary ModeloNotaFiscalDictionary
        {
            get { return _modeloNotaFiscalDictionary ?? (_modeloNotaFiscalDictionary = new ModeloNotaFiscalDictionary()); }
            set { _modeloNotaFiscalDictionary = value; }
        }

        public IList<Ncm> Ncms
        {
            get { return _ncms ?? (_ncms  = App.Ncms); }
            set { _ncms = value; }
        }

        public IList<Cst> Csts
        {
            get { return _csts ?? (_csts = App.Csts); }
            set { _csts = value; }
        }

        public IList<Cfop> Cfops
        {
            get { return _cfops ?? (_cfops = App.Cfops); }
            set { _cfops = value; }
        }

        public IList<NaturezaInterna> NaturezasInterna{ get; set; }

        public ParceiroNegocioPessoaJuridicaLargeDataModel EmitenteLargeDataModel
        {
            get { return _emitenteLargeDataModel ?? (_emitenteLargeDataModel = new ParceiroNegocioPessoaJuridicaLargeDataModel()); }
            set { _emitenteLargeDataModel = value; }
        }

        public ParceiroNegocioPessoaJuridicaLargeDataModel DestinatarioLargeDataModel
        {
            get { return _destinatarioLargeDataModel ?? (_destinatarioLargeDataModel = new ParceiroNegocioPessoaJuridicaLargeDataModel()); }
            set { _destinatarioLargeDataModel = value; }
        }

        public ParceiroNegocioPessoaJuridicaLargeDataModel TransportadoraLargeDataModel
        {
            get { return _transportadoraLargeDataModel ?? (_transportadoraLargeDataModel = new ParceiroNegocioPessoaJuridicaLargeDataModel()); }
            set { _transportadoraLargeDataModel = value; }
        }

        private PessoaJuridica _emitente;
        private PessoaJuridica _destinatario;
        private PessoaJuridica _transportadora;
        private ModeloNotaFiscalDictionary _modeloNotaFiscalDictionary;
        private ParceiroNegocioPessoaJuridicaLargeDataModel _emitenteLargeDataModel;
        private ParceiroNegocioPessoaJuridicaLargeDataModel _destinatarioLargeDataModel;
        private ParceiroNegocioPessoaJuridicaLargeDataModel _transportadoraLargeDataModel;
        private bool _entrada;
        private ProdutoLargeDataModel _produtoLargeDataModel;
        private IList<Ncm> _ncms;
        private IList<Cst> _csts;
        private IList<Cfop> _cfops;
        private ObservableCollection<ProdutoNotaFiscal> _produtos;
        private ObservableCollection<NotaFiscalPagamento> _pagamento;

        public PessoaJuridica Emitente
        {
            get { return _emitente; }
            set
            {
                if (Equals(value, _emitente)) return;
                _emitente = value;
                // Passa o emitente para anota fiscal.
                Entity.Emitente = value;
                OnPropertyChanged();
            }
        }

        public PessoaJuridica Destinatario
        {
            get { return _destinatario; }
            set
            {
                if (Equals(value, _destinatario)) return;
                _destinatario = value;
                // Passa o destinatário da mercadoria da nota fiscal.
                Entity.Destinatario = value;
                OnPropertyChanged();
            }
        }

        public PessoaJuridica Transportadora
        {
            get { return _transportadora; }
            set
            {
                if (Equals(value, _transportadora)) return;
                _transportadora = value;
                // Passa a transportadora para a nota fiscal.
                Entity.Transportadora = value;
                OnPropertyChanged();
            }
        }

        public virtual ObservableCollection<ProdutoNotaFiscal> Produtos
        {
            get { return _produtos ?? (_produtos = new ObservableCollection<ProdutoNotaFiscal>()); }
            set { _produtos = value; }
        }

        public virtual ObservableCollection<NotaFiscalPagamento> Pagamento
        {
            get { return _pagamento ?? (_pagamento = new ObservableCollection<NotaFiscalPagamento>()); }
            set { _pagamento = value; }
        }

        public bool Entrada
        {
            get { return _entrada; }
            set
            {
                Entity.Entrada = value;
                ((NotaFiscalSelectModel) ModelSelect).Entrada = value;
                if (value.Equals(_entrada)) return;
                _entrada = value;
                OnPropertyChanged();
            }
        }

        public ProdutoLargeDataModel ProdutoLargeDataModel
        {
            get { return _produtoLargeDataModel ?? (_produtoLargeDataModel = new ProdutoLargeDataModel()); }
            set { _produtoLargeDataModel = value; }
        }

        public void AddProduto()
        {
            ProdutoAtual.Sequencia = Produtos.Count + 1;
            Produtos.Add(ProdutoAtual);
            ProdutoAtual = new ProdutoNotaFiscal();
        }

        public void SalvarProduto()
        {
            if (ProdutoAtual.Sequencia == 0)
            {
                AddProduto();
            }
            else
            {
                UpdateProduto();
            }
        }

        public override void Salvar()
        {
            Entity.Produtos = Produtos;
            Entity.Pagamento = Pagamento;
            NotaFiscalRepository.Save(Entity);
        }

        private void UpdateProduto()
        {
            ProdutoAtual = new ProdutoNotaFiscal();
        }
    }
}
