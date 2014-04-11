namespace Erp.Relatorios
{
    partial class BaseIntegerPeriodeLandscape
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.valorInicial = new DevExpress.XtraReports.Parameters.Parameter();
            this.valorFinal = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // lblNomeRelatorio
            // 
            this.lblNomeRelatorio.StylePriority.UseFont = false;
            this.lblNomeRelatorio.StylePriority.UseTextAlignment = false;
            // 
            // lblRazaoSocial
            // 
            this.lblRazaoSocial.StylePriority.UseFont = false;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            // 
            // detailBand1
            // 
            this.detailBand1.HeightF = 43.75F;
            // 
            // valorInicial
            // 
            this.valorInicial.Description = "Valor inicial";
            this.valorInicial.Name = "valorInicial";
            this.valorInicial.Type = typeof(decimal);
            this.valorInicial.ValueInfo = "0";
            // 
            // valorFinal
            // 
            this.valorFinal.Description = "Valor final";
            this.valorFinal.Name = "valorFinal";
            this.valorFinal.Type = typeof(decimal);
            this.valorFinal.ValueInfo = "0";
            // 
            // BaseIntegerPeriodeLandscape
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.detailBand1});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.valorInicial,
            this.valorFinal});
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        protected DevExpress.XtraReports.Parameters.Parameter valorFinal;
        protected DevExpress.XtraReports.Parameters.Parameter valorInicial;
    }
}
