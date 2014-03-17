using Erp.Business.Enum;
using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Fiscal
{
    public class NotaFiscalMap : ClassMap<NotaFiscal>
    {
        public NotaFiscalMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqNotaFiscal").Not.Nullable().Unique();

            Map(x => x.DataEmissao);
            Map(x => x.DataEntrada);
            Map(x => x.Entrada);
            Map(x => x.HoraSaida);
            Map(x => x.Numero);


            Map(x => x.Serie);
            Map(x => x.ChaveAcesso);
            Map(x => x.NaturezaOperacao);
            Map(x => x.Protocolo);
            Map(x => x.InscricaoSubTributario);
            Map(x => x.FretePorConta);
            Map(x => x.Desconto);
            Map(x => x.Frete);
            Map(x => x.Seguro);
            Map(x => x.OutrasDespesasAcessorias);
            Map(x => x.CodigoAntt);
            Map(x => x.PlacaVeiculo);
            Map(x => x.Quantidade);
            Map(x => x.Especie);
            Map(x => x.Marca);
            Map(x => x.PesoBruto);
            Map(x => x.PesoLiquido);
            Map(x => x.InscricaoMunicipal);
            Map(x => x.ValorServico);
            Map(x => x.BaseIssqn);
            Map(x => x.ValorIssqn);
            Map(x => x.ReservadoAoFiscao);
            Map(x => x.DadosAdicionais);
            Map(x => x.Lancada);
            Map(x => x.Arquivo).CustomType<byte[]>();
            Map(x => x.Modelo).CustomType<ModeloNotaFiscal>();
            Map(x => x.Status);

            References(x => x.NaturezaInterna).LazyLoad();
            References(x => x.Emitente).LazyLoad();
            References(x => x.Destinatario).LazyLoad();
            References(x => x.Transportadora).LazyLoad();

            HasMany(x => x.Produtos).Cascade.All().LazyLoad();
            HasMany(x => x.Pagamento).Cascade.All().LazyLoad();
        }
    }
}