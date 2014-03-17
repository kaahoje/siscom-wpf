using System;
using System.Collections.ObjectModel;
using Erp.Business.Enum;

namespace Erp.Business.NotaFiscalEletronica
{
    public class IdentificacaoNFe
    {
        // Código da UF do emitente do documento fiscal.
        public virtual int cUF { get; set; }
        // Código numérico que compões a Chave de Acesso.
        public virtual int cNF { get; set; }
        // Descrição da natureza da operação.
        public virtual string natOp { get; set; }
        // Indicador da forma de pagamento.
        public virtual NFeIndicadorPagamento indPag { get; set; }
        // Código do modelo do documento fiscal.
        public virtual string mod { get; set; }
        // Série do documento fiscal.
        public virtual string serie { get; set; }
        // Número do documento fiscal.
        public virtual int nNF { get; set; }
        // Data de emissão do Documento Fiscal.
        public virtual DateTime dEmi { get; set; }
        // Data de saída do documento fiscal.
        public virtual DateTime dSaiEnt { get; set; }
        // Hora de saída ou da entrada da mercadoria/produto
        public virtual DateTime hSaiEnt { get; set; }
        // SubGrupo de operação.
        public virtual NFeTipoOperacao tpNF { get; set; }
        // Código do município de ocorrência do fato gerador.
        public virtual int cMunFG { get; set; }

        // Formato de impressão do DANFE.
        public virtual NFeFormatoDanfe tpImp { get; set; }
        // SubGrupo de emissão da NF-e.
        public virtual NFeTipoEmissao tpEmis { get; set; }
        // Dígito verificador da chave de acesso da NF-e.
        public virtual int cDV { get; set; }
        // Identificação do ambiente.
        public virtual NFeTipoAmbiente tpAm { get; set; }
        // Finalidade de emissao da NF-e.
        public virtual NFeFinalidadeEmissao finNFe { get; set; }
        // Processo de emissão da NF-e.
        // Esta informação no caso de emissão pelo ERP será sempre 0;
        public virtual int procEmi { get; set; }
        // Versão do processo emissor.
        public virtual string verProc { get; set; }
        // Data e hora de entrada em contingência.
        public virtual DateTime dhCont { get; set; }
        // Justificativa da entrada em contngência.
        public virtual string xJust { get; set; }

        // Grupo de informações das NF/NF-e referênciadas.
        public virtual ObservableCollection<InformacaoReferenciada> NFref { get; set; }
    }
}