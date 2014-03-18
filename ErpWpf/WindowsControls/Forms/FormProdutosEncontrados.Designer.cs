using Erp.Business.Entity.Estoque.Produto;

namespace WindowsControls.Forms
{
    partial class FormProdutosEncontrados
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtoGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUltimaCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodBarra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCusto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustoMedio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecoCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecoVenda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLucro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorPromocional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoAtual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoMinimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcmsDevedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcmsCredor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcmsSubDev = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcmsSubCred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPisPercentCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSitTribPisCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCofinsPercentCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSitTribCofinsCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpiPrecentCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSitTribIpiCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtdUnidadeTributavel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidadeAtual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIppt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperacaoNotaDaGente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTributacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoCST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtTIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadeCodBarra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadeComercial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadeTributavel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgregado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Produto);
            // 
            // produtoGridControl
            // 
            this.produtoGridControl.DataSource = this.produtoBindingSource;
            this.produtoGridControl.Location = new System.Drawing.Point(12, 12);
            this.produtoGridControl.MainView = this.gridView1;
            this.produtoGridControl.Name = "produtoGridControl";
            this.produtoGridControl.Size = new System.Drawing.Size(634, 231);
            this.produtoGridControl.TabIndex = 1;
            this.produtoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUltimaCompra,
            this.colDescricao,
            this.colReferencia,
            this.colCodBarra,
            this.colCusto,
            this.colCustoMedio,
            this.colPrecoCompra,
            this.colPrecoVenda,
            this.colLucro,
            this.colValorPromocional,
            this.colSaldoAtual,
            this.colSaldoMinimo,
            this.colGenero,
            this.colIcmsDevedor,
            this.colIcmsCredor,
            this.colIcmsSubDev,
            this.colIcmsSubCred,
            this.colPisPercentCompra,
            this.colSitTribPisCompra,
            this.colCofinsPercentCompra,
            this.colSitTribCofinsCompra,
            this.colIpiPrecentCompra,
            this.colSitTribIpiCompra,
            this.colQtdUnidadeTributavel,
            this.colQuantidadeAtual,
            this.colIat,
            this.colIppt,
            this.colOperacaoNotaDaGente,
            this.colTributacao,
            this.colRegime,
            this.colTipo,
            this.colCodigoCST,
            this.colExtTIPI,
            this.colUnidadeCodBarra,
            this.colUnidadeComercial,
            this.colUnidadeTributavel,
            this.colNCM,
            this.colAgregado,
            this.colSubTipo});
            this.gridView1.GridControl = this.produtoGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colUltimaCompra
            // 
            this.colUltimaCompra.FieldName = "UltimaCompra";
            this.colUltimaCompra.Name = "colUltimaCompra";
            // 
            // colDescricao
            // 
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 4;
            this.colDescricao.Width = 214;
            // 
            // colReferencia
            // 
            this.colReferencia.FieldName = "Referencia";
            this.colReferencia.Name = "colReferencia";
            this.colReferencia.Visible = true;
            this.colReferencia.VisibleIndex = 3;
            this.colReferencia.Width = 110;
            // 
            // colCodBarra
            // 
            this.colCodBarra.FieldName = "CodBarra";
            this.colCodBarra.Name = "colCodBarra";
            this.colCodBarra.Visible = true;
            this.colCodBarra.VisibleIndex = 2;
            this.colCodBarra.Width = 107;
            // 
            // colCusto
            // 
            this.colCusto.FieldName = "Custo";
            this.colCusto.Name = "colCusto";
            // 
            // colCustoMedio
            // 
            this.colCustoMedio.FieldName = "CustoMedio";
            this.colCustoMedio.Name = "colCustoMedio";
            // 
            // colPrecoCompra
            // 
            this.colPrecoCompra.FieldName = "PrecoCompra";
            this.colPrecoCompra.Name = "colPrecoCompra";
            // 
            // colPrecoVenda
            // 
            this.colPrecoVenda.DisplayFormat.FormatString = "c";
            this.colPrecoVenda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecoVenda.FieldName = "PrecoVenda";
            this.colPrecoVenda.Name = "colPrecoVenda";
            this.colPrecoVenda.Visible = true;
            this.colPrecoVenda.VisibleIndex = 1;
            this.colPrecoVenda.Width = 115;
            // 
            // colLucro
            // 
            this.colLucro.FieldName = "Lucro";
            this.colLucro.Name = "colLucro";
            // 
            // colValorPromocional
            // 
            this.colValorPromocional.FieldName = "ValorPromocional";
            this.colValorPromocional.Name = "colValorPromocional";
            // 
            // colSaldoAtual
            // 
            this.colSaldoAtual.FieldName = "SaldoAtual";
            this.colSaldoAtual.Name = "colSaldoAtual";
            this.colSaldoAtual.Visible = true;
            this.colSaldoAtual.VisibleIndex = 0;
            this.colSaldoAtual.Width = 70;
            // 
            // colSaldoMinimo
            // 
            this.colSaldoMinimo.FieldName = "SaldoMinimo";
            this.colSaldoMinimo.Name = "colSaldoMinimo";
            // 
            // colGenero
            // 
            this.colGenero.FieldName = "Genero";
            this.colGenero.Name = "colGenero";
            // 
            // colIcmsDevedor
            // 
            this.colIcmsDevedor.FieldName = "IcmsDevedor";
            this.colIcmsDevedor.Name = "colIcmsDevedor";
            // 
            // colIcmsCredor
            // 
            this.colIcmsCredor.FieldName = "IcmsCredor";
            this.colIcmsCredor.Name = "colIcmsCredor";
            // 
            // colIcmsSubDev
            // 
            this.colIcmsSubDev.FieldName = "IcmsSubDev";
            this.colIcmsSubDev.Name = "colIcmsSubDev";
            // 
            // colIcmsSubCred
            // 
            this.colIcmsSubCred.FieldName = "IcmsSubCred";
            this.colIcmsSubCred.Name = "colIcmsSubCred";
            // 
            // colPisPercentCompra
            // 
            this.colPisPercentCompra.FieldName = "PisPercentCompra";
            this.colPisPercentCompra.Name = "colPisPercentCompra";
            // 
            // colSitTribPisCompra
            // 
            this.colSitTribPisCompra.FieldName = "SitTribPisCompra";
            this.colSitTribPisCompra.Name = "colSitTribPisCompra";
            // 
            // colCofinsPercentCompra
            // 
            this.colCofinsPercentCompra.FieldName = "CofinsPercentCompra";
            this.colCofinsPercentCompra.Name = "colCofinsPercentCompra";
            // 
            // colSitTribCofinsCompra
            // 
            this.colSitTribCofinsCompra.FieldName = "SitTribCofinsCompra";
            this.colSitTribCofinsCompra.Name = "colSitTribCofinsCompra";
            // 
            // colIpiPrecentCompra
            // 
            this.colIpiPrecentCompra.FieldName = "IpiPrecentCompra";
            this.colIpiPrecentCompra.Name = "colIpiPrecentCompra";
            // 
            // colSitTribIpiCompra
            // 
            this.colSitTribIpiCompra.FieldName = "SitTribIpiCompra";
            this.colSitTribIpiCompra.Name = "colSitTribIpiCompra";
            // 
            // colQtdUnidadeTributavel
            // 
            this.colQtdUnidadeTributavel.FieldName = "QtdUnidadeTributavel";
            this.colQtdUnidadeTributavel.Name = "colQtdUnidadeTributavel";
            // 
            // colQuantidadeAtual
            // 
            this.colQuantidadeAtual.FieldName = "QuantidadeAtual";
            this.colQuantidadeAtual.Name = "colQuantidadeAtual";
            // 
            // colIat
            // 
            this.colIat.FieldName = "Iat";
            this.colIat.Name = "colIat";
            // 
            // colIppt
            // 
            this.colIppt.FieldName = "Ippt";
            this.colIppt.Name = "colIppt";
            // 
            // colOperacaoNotaDaGente
            // 
            this.colOperacaoNotaDaGente.FieldName = "OperacaoNotaDaGente";
            this.colOperacaoNotaDaGente.Name = "colOperacaoNotaDaGente";
            // 
            // colTributacao
            // 
            this.colTributacao.FieldName = "Tributacao";
            this.colTributacao.Name = "colTributacao";
            // 
            // colRegime
            // 
            this.colRegime.FieldName = "Regime";
            this.colRegime.Name = "colRegime";
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "SubGrupo";
            this.colTipo.Name = "colTipo";
            // 
            // colCodigoCST
            // 
            this.colCodigoCST.FieldName = "CodigoCST";
            this.colCodigoCST.Name = "colCodigoCST";
            // 
            // colExtTIPI
            // 
            this.colExtTIPI.FieldName = "ExtTIPI";
            this.colExtTIPI.Name = "colExtTIPI";
            // 
            // colUnidadeCodBarra
            // 
            this.colUnidadeCodBarra.FieldName = "UnidadeCodBarra";
            this.colUnidadeCodBarra.Name = "colUnidadeCodBarra";
            // 
            // colUnidadeComercial
            // 
            this.colUnidadeComercial.FieldName = "UnidadeComercial";
            this.colUnidadeComercial.Name = "colUnidadeComercial";
            // 
            // colUnidadeTributavel
            // 
            this.colUnidadeTributavel.FieldName = "UnidadeTributavel";
            this.colUnidadeTributavel.Name = "colUnidadeTributavel";
            // 
            // colNCM
            // 
            this.colNCM.FieldName = "NCM";
            this.colNCM.Name = "colNCM";
            // 
            // colAgregado
            // 
            this.colAgregado.FieldName = "Agregado";
            this.colAgregado.Name = "colAgregado";
            // 
            // colSubTipo
            // 
            this.colSubTipo.FieldName = "SubTipo";
            this.colSubTipo.Name = "colSubTipo";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(571, 259);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 35);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Cancelar";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(490, 259);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 35);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Selecionar";
            // 
            // FormProdutosEncontrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 306);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.produtoGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormProdutosEncontrados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos encontrados";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormProdutosEncontrados_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormProdutosEncontrados_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource produtoBindingSource;
        private DevExpress.XtraGrid.GridControl produtoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colUltimaCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colCodBarra;
        private DevExpress.XtraGrid.Columns.GridColumn colCusto;
        private DevExpress.XtraGrid.Columns.GridColumn colCustoMedio;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecoCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecoVenda;
        private DevExpress.XtraGrid.Columns.GridColumn colLucro;
        private DevExpress.XtraGrid.Columns.GridColumn colValorPromocional;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoAtual;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoMinimo;
        private DevExpress.XtraGrid.Columns.GridColumn colGenero;
        private DevExpress.XtraGrid.Columns.GridColumn colIcmsDevedor;
        private DevExpress.XtraGrid.Columns.GridColumn colIcmsCredor;
        private DevExpress.XtraGrid.Columns.GridColumn colIcmsSubDev;
        private DevExpress.XtraGrid.Columns.GridColumn colIcmsSubCred;
        private DevExpress.XtraGrid.Columns.GridColumn colPisPercentCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colSitTribPisCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colCofinsPercentCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colSitTribCofinsCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colIpiPrecentCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colSitTribIpiCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colQtdUnidadeTributavel;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidadeAtual;
        private DevExpress.XtraGrid.Columns.GridColumn colIat;
        private DevExpress.XtraGrid.Columns.GridColumn colIppt;
        private DevExpress.XtraGrid.Columns.GridColumn colOperacaoNotaDaGente;
        private DevExpress.XtraGrid.Columns.GridColumn colTributacao;
        private DevExpress.XtraGrid.Columns.GridColumn colRegime;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoCST;
        private DevExpress.XtraGrid.Columns.GridColumn colExtTIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadeCodBarra;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadeComercial;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadeTributavel;
        private DevExpress.XtraGrid.Columns.GridColumn colNCM;
        private DevExpress.XtraGrid.Columns.GridColumn colAgregado;
        private DevExpress.XtraGrid.Columns.GridColumn colSubTipo;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}