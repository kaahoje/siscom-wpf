using System;
using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa;

namespace Erp.Business.NotaFiscalEletronica
{
    public class NotaFiscal
    {
        private int _id;
        public virtual byte[] arquivoNF { get; set; }

        public virtual int id
        {
            get { return _id; }
        }

        public virtual String versao { get; set; }
        public virtual String idNfe { get; set; }
        public virtual IdentificacaoNFe ide { get; set; }
        public virtual IdentificacaoEmitente emit { get; set; }
        public virtual FiscoEmitente avulsa { get; set; }
        public virtual InformacaoDestinatario dest { get; set; }
        public virtual LocalRetirada retirada { get; set; }

        public virtual ObservableCollection<ProdutoNotaFiscal> det { get; set; }

        // Campos para a geração do banco de dados.
        // Identificação do emitente.

        public virtual Pessoa emitente { get; set; }
        // Identificação do destinatário.

        public virtual Pessoa destinatario { get; set; }
    }
}