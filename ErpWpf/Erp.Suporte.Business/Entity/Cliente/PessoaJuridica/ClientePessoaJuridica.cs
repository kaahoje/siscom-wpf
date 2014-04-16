using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Suporte.Business.Entity.Licenca;
using Erp.Suporte.Business.Entity.Suporte;

namespace Erp.Suporte.Business.Entity.Cliente.PessoaJuridica
{
    public class ClientePessoaJuridica : ParceiroNegocioPessoaJuridica,ICliente
    {
        public int LimiteSuportePresencial { get; set; }
        public int LimiteLicencas { get; set; }
        public decimal ValorSuporte { get; set; }
        public DateTime DescontoAte { get; set; }
        public decimal Desconto { get; set; }
        public decimal JurosAposVencimento { get; set; }
        public decimal JurosMoraAposVencimento { get; set; }
        public virtual IList<LicencaUso> Licencas { get; set; }
        public IList<SolicitacaoSuporte> SolicitacoesSuporte { get; set; }
    }
}
