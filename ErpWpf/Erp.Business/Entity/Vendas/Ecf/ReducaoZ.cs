using System;

namespace Erp.Business.Entity.Vendas.Ecf
{
    public class ReducaoZ
    {
        public virtual int Id { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual int GrandeTotal { get; set; }
        public virtual int GrandeTotalInicial { get; set; }
        public virtual Decimal DescontoIcms { get; set; }
        public virtual Decimal DescontoIss { get; set; }
        public virtual Decimal CancelamentoIcms { get; set; }
        public virtual Decimal CancelamentoIss { get; set; }
        public virtual Decimal AcrescimoIcms { get; set; }
        public virtual Decimal AcrescimoIss { get; set; }
        public virtual string TributadosIcmsIss { get; set; }
        public virtual Decimal F1Icms { get; set; }
        public virtual Decimal F2Icms { get; set; }
        public virtual Decimal I1Icms { get; set; }
        public virtual Decimal I2Icms { get; set; }
        public virtual Decimal N1Icms { get; set; }
        public virtual Decimal N2Icms { get; set; }
        public virtual Decimal F1Iss { get; set; }
        public virtual Decimal F2Iss { get; set; }
        public virtual Decimal I1Iss { get; set; }
        public virtual Decimal I2Iss { get; set; }
        public virtual Decimal N1Iss { get; set; }
        public virtual Decimal N2Iss { get; set; }
        public virtual string TotalizadoresNf { get; set; }
        public virtual decimal DescontosNf { get; set; }
        public virtual decimal CancelamentosNf { get; set; }
        public virtual decimal AcressimosNf { get; set; }
        public virtual string Aliquotas { get; set; }
        public virtual int Cro { get; set; }
        public virtual int Crz { get; set; }
        public virtual int CrzRestante { get; set; }
        public virtual int Coo { get; set; }
        public virtual int Gnf { get; set; }
        public virtual int Ccf { get; set; }
        public virtual int Cvc { get; set; }
        public virtual int Grg { get; set; }
        public virtual int Cfd { get; set; }
        public virtual int Cbp { get; set; }
        public virtual int Nfc { get; set; }
        public virtual int Cmv { get; set; }
        public virtual int Cfc { get; set; }
        public virtual int Cnc { get; set; }
        public virtual int Cbc { get; set; }
        public virtual int Ncn { get; set; }
        public virtual int Cdc { get; set; }
        public virtual int Con { get; set; }
        public virtual int Cer { get; set; }
    }
}