﻿namespace Erp.Relatorios.Lancamentos.ParceiroNegocioPessoaJuridica
{
    partial class LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport
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
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas.LancamentoParceiroNegocioPessoaJuridica);
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(686F, 0F);
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(582F, 0F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(477.9999F, 0F);
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(790F, 0F);
            // 
            // xrLabel7
            // 
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(477.9999F, 0F);
            // 
            // xrLabel10
            // 
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(790F, 0F);
            // 
            // xrLabel9
            // 
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(686F, 0F);
            // 
            // xrLabel8
            // 
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(582F, 0F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13});
            this.PageHeader.Controls.SetChildIndex(this.xrLabel7, 0);
            this.PageHeader.Controls.SetChildIndex(this.xrLabel8, 0);
            this.PageHeader.Controls.SetChildIndex(this.xrLabel9, 0);
            this.PageHeader.Controls.SetChildIndex(this.xrLabel10, 0);
            this.PageHeader.Controls.SetChildIndex(this.xrLabel13, 0);
            // 
            // dataInicial
            // 
            this.dataInicial.ValueInfo = "";
            // 
            // dataFinal
            // 
            this.dataFinal.ValueInfo = "";
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
            this.detailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11});
            this.detailBand1.Controls.SetChildIndex(this.xrLabel3, 0);
            this.detailBand1.Controls.SetChildIndex(this.xrLabel4, 0);
            this.detailBand1.Controls.SetChildIndex(this.xrLabel5, 0);
            this.detailBand1.Controls.SetChildIndex(this.xrLabel6, 0);
            this.detailBand1.Controls.SetChildIndex(this.xrLabel11, 0);
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ParceiroNegocioPessoaJuridica.RazaoSocial")});
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(114F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(359.9999F, 23F);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel12
            // 
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(115F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(358.9999F, 23F);
            // 
            // xrLabel13
            // 
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(114F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(359.9999F, 23F);
            this.xrLabel13.Text = "Razão social";
            // 
            // LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.detailBand1,
            this.PageHeader});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.dataInicial,
            this.dataFinal});
            this.Version = "13.2";
            this.ParametersRequestSubmit += new System.EventHandler<DevExpress.XtraReports.Parameters.ParametersRequestEventArgs>(this.LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport_ParametersRequestSubmit);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
    }
}
