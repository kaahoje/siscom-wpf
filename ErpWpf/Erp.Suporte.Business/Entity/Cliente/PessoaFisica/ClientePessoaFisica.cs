using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Suporte.Business.Entity.Licenca;
using Erp.Suporte.Business.Entity.Suporte;

namespace Erp.Suporte.Business.Entity.Cliente.PessoaFisica
{
    /// <summary>
    /// Esta classe que lida com pessoa é declarada no suporte pois não é o objetivo do Sistema ERP gerênciar
    /// licenças de uso e particularidades da prestação de serviços por parte da empresa desenvolvedora.
    /// </summary>
    public class ClientePessoaFisica : ParceiroNegocioPessoaFisica,ICliente
    {
        public virtual int LimiteSuportePresencial { get; set; }
        public virtual int LimiteLicencas { get; set; }
        public virtual decimal ValorSuporte { get; set; }
        public virtual DateTime DescontoAte { get; set; }
        public virtual decimal Desconto { get; set; }
        public virtual decimal JurosAposVencimento { get; set; }
        public virtual decimal JurosMoraAposVencimento { get; set; }
        public virtual IList<LicencaUso> Licencas { get; set; }
        public IList<SolicitacaoSuporte> SolicitacoesSuporte { get; set; }
    }
}
