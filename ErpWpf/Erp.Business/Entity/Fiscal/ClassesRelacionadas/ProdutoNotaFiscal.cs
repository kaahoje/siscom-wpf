using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class ProdutoNotaFiscal : INotifyPropertyChanged
    {
        private int _sequencia;
        private string _codigoFornecedor;
        private decimal _quantidade;
        private decimal _valorUnitario;
        private decimal _baseIcms;
        private decimal _valorIcms;
        private decimal _valorIpi;
        private OperacaoNotaDaGente _tipoOperacaoNotaDaGente;
        private IndicadorTotalizacao _indicadorTotalizacao;
        private Produto _produto;
        private Ncm _ncm;
        private Cst _cst;
        private Cfop _cfop;
        private Unidade _unidade;
        private NotaFiscal _notaFiscal;
        public virtual int Id { get; set; }

        public virtual int Sequencia
        {
            get { return _sequencia; }
            set
            {
                if (value == _sequencia) return;
                _sequencia = value;
                OnPropertyChanged();
            }
        }

        public virtual string CodigoFornecedor
        {
            get { return _codigoFornecedor; }
            set
            {
                if (value == _codigoFornecedor) return;
                _codigoFornecedor = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal Quantidade
        {
            get { return _quantidade; }
            set
            {
                if (value == _quantidade) return;
                _quantidade = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal ValorUnitario
        {
            get { return _valorUnitario; }
            set
            {
                if (value == _valorUnitario) return;
                _valorUnitario = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal BaseIcms
        {
            get { return _baseIcms; }
            set
            {
                if (value == _baseIcms) return;
                _baseIcms = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal ValorIcms
        {
            get { return _valorIcms; }
            set
            {
                if (value == _valorIcms) return;
                _valorIcms = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal ValorIpi
        {
            get { return _valorIpi; }
            set
            {
                if (value == _valorIpi) return;
                _valorIpi = value;
                OnPropertyChanged();
            }
        }

        public virtual OperacaoNotaDaGente TipoOperacaoNotaDaGente
        {
            get { return _tipoOperacaoNotaDaGente; }
            set
            {
                if (value == _tipoOperacaoNotaDaGente) return;
                _tipoOperacaoNotaDaGente = value;
                OnPropertyChanged();
            }
        }

        public virtual IndicadorTotalizacao IndicadorTotalizacao
        {
            get { return _indicadorTotalizacao; }
            set
            {
                if (value == _indicadorTotalizacao) return;
                _indicadorTotalizacao = value;
                OnPropertyChanged();
            }
        }

        public virtual Produto Produto
        {
            get { return _produto; }
            set
            {
                if (Equals(value, _produto)) return;
                _produto = value;
                OnPropertyChanged();
            }
        }

        public virtual Ncm NCM
        {
            get { return _ncm; }
            set
            {
                if (Equals(value, _ncm)) return;
                _ncm = value;
                OnPropertyChanged();
            }
        }

        public virtual Cst CST
        {
            get { return _cst; }
            set
            {
                if (Equals(value, _cst)) return;
                _cst = value;
                OnPropertyChanged();
            }
        }

        public virtual Cfop CFOP
        {
            get { return _cfop; }
            set
            {
                if (Equals(value, _cfop)) return;
                _cfop = value;
                OnPropertyChanged();
            }
        }

        public virtual Unidade Unidade
        {
            get { return _unidade; }
            set
            {
                if (Equals(value, _unidade)) return;
                _unidade = value;
                OnPropertyChanged();
            }
        }

        public virtual NotaFiscal NotaFiscal
        {
            get { return _notaFiscal; }
            set
            {
                if (Equals(value, _notaFiscal)) return;
                _notaFiscal = value;
                OnPropertyChanged();
            }
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}