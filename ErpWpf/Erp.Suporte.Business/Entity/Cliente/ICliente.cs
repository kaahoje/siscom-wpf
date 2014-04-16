using System;
using System.Collections.Generic;
using Erp.Suporte.Business.Entity.Licenca;
using Erp.Suporte.Business.Entity.Suporte;

namespace Erp.Suporte.Business.Entity.Cliente
{
    public interface ICliente
    {
        /// <summary>
        /// Limite de suportes técnicos presenciais sem cobrança adicional.
        /// </summary>
        int LimiteSuportePresencial { get; set; }
        /// <summary>
        /// Quantidade de licenças adiquiridas pelo cliente.
        /// </summary>
        int LimiteLicencas { get; set; }
        /// <summary>
        /// Valor do base do suporte
        /// </summary>
        decimal ValorSuporte { get; set; }
        /// <summary>
        /// Data limite para a concessão de desconto ao cliente.
        /// </summary>
        DateTime DescontoAte { get; set; }
        /// <summary>
        /// Valor percentual de desconto a ser dado ao cliente.
        /// </summary>
        decimal Desconto { get; set; }
        /// <summary>
        /// Juros a serem cobrados adicionalmente após o vencimento do pagamento de suporte.
        /// </summary>
        decimal JurosAposVencimento { get; set; }
        /// <summary>
        /// Valor dos juros cobrados por dia de atrazo no pagamento do suporte.
        /// </summary>
        decimal JurosMoraAposVencimento { get; set; }
        /// <summary>
        /// Licenças já utilizadas pelo cliente.
        /// </summary>
        IList<LicencaUso> Licencas { get; set; }
        IList<SolicitacaoSuporte> SolicitacoesSuporte { get; set; }
    }
}
