using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Ecf
{
    public class ReducaoZMap : ClassMap<ReducaoZ>
    {
        public ReducaoZMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Sequence("sqReducaoZ");

            Map(x => x.Data);
            Map(x => x.GrandeTotal);
            Map(x => x.GrandeTotalInicial);
            Map(x => x.DescontoIcms);
            Map(x => x.DescontoIss);
            Map(x => x.CancelamentoIcms);
            Map(x => x.CancelamentoIss);
            Map(x => x.AcrescimoIcms);
            Map(x => x.AcrescimoIss);
            Map(x => x.TributadosIcmsIss);
            Map(x => x.F1Icms);
            Map(x => x.F1Iss);
            Map(x => x.F2Icms);
            Map(x => x.F2Iss);
            Map(x => x.I1Icms);
            Map(x => x.I1Iss);
            Map(x => x.I2Icms);
            Map(x => x.I2Iss);
            Map(x => x.N1Icms);
            Map(x => x.N2Icms);
            Map(x => x.N2Iss);
            Map(x => x.TotalizadoresNf);
            Map(x => x.DescontosNf);
            Map(x => x.CancelamentosNf);
            Map(x => x.AcressimosNf);
            Map(x => x.Aliquotas);
            Map(x => x.Cro).Index("idxReducaoZCro");
            Map(x => x.Crz).Index("idxReducaoZCrz");
            Map(x => x.CrzRestante);
            Map(x => x.Coo).Index("idxReducaoZCoo");
            Map(x => x.Gnf);
            Map(x => x.Ccf);
            Map(x => x.Cvc);
            Map(x => x.Grg);
            Map(x => x.Cfd);
            Map(x => x.Cbp);
            Map(x => x.Nfc);
            Map(x => x.Cmv);
            Map(x => x.Cfc);
            Map(x => x.Cnc);
            Map(x => x.Cbc);
            Map(x => x.Ncn);
            Map(x => x.Cdc);
            Map(x => x.Con);
            Map(x => x.Cer);
        }
    }
}