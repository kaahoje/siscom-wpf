using System;

namespace Erp.Relatorios
{
    public partial class BaseDatePeriodePortrait : BasePortrait
    {
        public BaseDatePeriodePortrait()
        {
            InitializeComponent();
            var y = DateTime.Now.Year;
            var m = DateTime.Now.Month;
            dataInicial.Value = new DateTime(y, m, 1);
            dataFinal.Value = new DateTime(y, m, DateTime.DaysInMonth(y, m));
        }

        protected DateTime DataInicialAbreviada()
        {
            return ((DateTime) dataInicial.Value).Date;
        }
        protected DateTime DataFinalAbreviada()
        {
            return ((DateTime) dataFinal.Value).Date;
        }
        protected DateTime DataInicialCompleta()
        {
            return (DateTime) dataInicial.Value;
        }
        protected DateTime DataFinalCompleta()
        {
            return (DateTime) dataFinal.Value;
        }
    }
}
