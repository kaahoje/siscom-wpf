using System;

namespace Erp.Business.NotaFiscalEletronica
{
    [Serializable]
    public class IdentificacaoEmitente
    {
        // Campos que serão persistidos no XML da NF-e.
        // CNPJ do emitente da nota fiscal.
        public virtual string CNPJ { get; set; }
        // CPF do remetente da NF-e
        public string CPF { get; set; }
        // Razão social ou nome do emitente.
        public string xNome { get; set; }
        // Nome fantasia.
        public string xFant { get; set; }
        // Inscrição estadual.
        public string IE { get; set; }
        // Inscrição do substituto tributário.
        public string IEST { get; set; }
        // Inscrição municipal.
        public string IM { get; set; }
        // Código nacional de atividade empresarial.
        public string CNAE { get; set; }

        // Informações sobre o endereço do emitente.
        public EnderecoEmitente enderEmit { get; set; }
    }
}