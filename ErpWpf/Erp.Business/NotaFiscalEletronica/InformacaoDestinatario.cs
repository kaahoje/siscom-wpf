using System;

namespace Erp.Business.NotaFiscalEletronica
{
    [Serializable]
    public class InformacaoDestinatario
    {
        // Cnpj.
        public virtual string CNPJ { get; set; }
        // Cpf caso seja pessoa física.
        public virtual string CPF { get; set; }
        // Razão social ou nome do destinatário
        public virtual string xNome { get; set; }
        // Inscrição estadual.
        public virtual string IE { get; set; }
        // Inscriçaõ suframa.
        public virtual string ISUF { get; set; }
        // Email.
        public virtual string email { get; set; }
    }
}