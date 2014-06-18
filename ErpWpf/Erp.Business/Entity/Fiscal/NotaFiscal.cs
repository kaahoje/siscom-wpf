using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Fiscal.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Fiscal
{
    [Serializable]
    public class NotaFiscal : INotifyPropertyChanged
    {
        public NotaFiscal()
        {
            Arquivo = new byte[0];
        }

        public virtual int Id { get; set; }
        public virtual DateTime DataEmissao { get; set; }
        public virtual DateTime DataEntrada { get; set; }
        public virtual bool Entrada { get; set; }
        public virtual DateTime HoraSaida { get; set; }
        public virtual int Numero { get; set; }

        public virtual string Serie { get; set; }
        public virtual string ChaveAcesso { get; set; }
        public virtual string NaturezaOperacao { get; set; }
        public virtual string Protocolo { get; set; }
        public virtual string InscricaoSubTributario { get; set; }

        public virtual string FretePorConta { get; set; }
        public virtual decimal Desconto { get; set; }
        public virtual decimal Frete { get; set; }
        public virtual decimal Seguro { get; set; }
        public virtual decimal OutrasDespesasAcessorias { get; set; }
        public virtual string CodigoAntt { get; set; }
        public virtual string PlacaVeiculo { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual string Especie { get; set; }
        public virtual string Marca { get; set; }
        public virtual decimal PesoBruto { get; set; }
        public virtual decimal PesoLiquido { get; set; }
        public virtual string InscricaoMunicipal { get; set; }
        public virtual decimal ValorServico { get; set; }
        public virtual decimal BaseIssqn { get; set; }
        public virtual decimal ValorIssqn { get; set; }
        public virtual string DadosAdicionais { get; set; }
        public virtual string ReservadoAoFiscao { get; set; }
        public virtual bool Lancada { get; set; }
        public virtual byte[] Arquivo { get; set; }
        public virtual ModeloNotaFiscal Modelo { get; set; }

        public virtual NaturezaInterna NaturezaInterna { get; set; }
        public virtual Pessoa Emitente { get; set; }
        public virtual Pessoa Transportadora { get; set; }
        public virtual Pessoa Destinatario { get; set; }

        public virtual IList<ProdutoNotaFiscal> Produtos { get; set; }
        public virtual IList<NotaFiscalPagamento> Pagamento { get; set; }

        public virtual Status Status { get; set; }

        public virtual Decimal TotalNota
        {
            get { return NotaFiscalRepository.CalculaNota(this); }
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