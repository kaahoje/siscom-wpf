namespace Ecf.Forms
{
    partial class FormMenuFiscal
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
            this.cmdLeituraX = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdAliquotasCadastradas = new DevExpress.XtraEditors.SimpleButton();
            this.cmdLMFS = new DevExpress.XtraEditors.SimpleButton();
            this.cmdLMFC = new DevExpress.XtraEditors.SimpleButton();
            this.cmdMeiosPagamento = new DevExpress.XtraEditors.SimpleButton();
            this.cmdIdPafECF = new DevExpress.XtraEditors.SimpleButton();
            this.cmdMesasAbertas = new DevExpress.XtraEditors.SimpleButton();
            this.cmdLeituraMovimentoDiario = new DevExpress.XtraEditors.SimpleButton();
            this.cmdManifestoFiscalViagem = new DevExpress.XtraEditors.SimpleButton();
            this.cmdReducaoZ = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCadastrarAliquota = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancelarUltimaVenda = new DevExpress.XtraEditors.SimpleButton();
            this.cmdTransfMesas = new DevExpress.XtraEditors.SimpleButton();
            this.cmdMovimentoPorECF = new DevExpress.XtraEditors.SimpleButton();
            this.cmdEstoque = new DevExpress.XtraEditors.SimpleButton();
            this.cmdTabelaProduto = new DevExpress.XtraEditors.SimpleButton();
            this.cmdArquivoMDF = new DevExpress.XtraEditors.SimpleButton();
            this.cmdEspelhoMDF = new DevExpress.XtraEditors.SimpleButton();
            this.cmdEncerrantes = new DevExpress.XtraEditors.SimpleButton();
            this.cmdDavEmitido = new DevExpress.XtraEditors.SimpleButton();
            this.mnuFuncoesFiscaisAdicionais = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdCadAliquota = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCadFormaPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.mnuFuncoesFiscaisAdicionais.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLeituraX
            // 
            this.cmdLeituraX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLeituraX.Location = new System.Drawing.Point(3, 4);
            this.cmdLeituraX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdLeituraX.Name = "cmdLeituraX";
            this.cmdLeituraX.Size = new System.Drawing.Size(227, 35);
            this.cmdLeituraX.TabIndex = 0;
            this.cmdLeituraX.Text = "LX";
            this.cmdLeituraX.Click += new System.EventHandler(this.cmdLeituraX_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cmdAliquotasCadastradas, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmdLMFC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmdCadastrarAliquota, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmdLeituraX, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdMeiosPagamento, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmdIdPafECF, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cmdMesasAbertas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmdLeituraMovimentoDiario, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmdManifestoFiscalViagem, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmdReducaoZ, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdCancelarUltimaVenda, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdTransfMesas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdMovimentoPorECF, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cmdEstoque, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmdTabelaProduto, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmdArquivoMDF, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmdEspelhoMDF, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmdEncerrantes, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmdDavEmitido, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmdLMFS, 0, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 430);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cmdAliquotasCadastradas
            // 
            this.cmdAliquotasCadastradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAliquotasCadastradas.Location = new System.Drawing.Point(236, 391);
            this.cmdAliquotasCadastradas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAliquotasCadastradas.Name = "cmdAliquotasCadastradas";
            this.cmdAliquotasCadastradas.Size = new System.Drawing.Size(228, 35);
            this.cmdAliquotasCadastradas.TabIndex = 6;
            this.cmdAliquotasCadastradas.Text = "Alíquotas cadastradas";
            this.cmdAliquotasCadastradas.Visible = false;
            this.cmdAliquotasCadastradas.Click += new System.EventHandler(this.cmdAliquotasCadastradas_Click);
            // 
            // cmdLMFS
            // 
            this.cmdLMFS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLMFS.Location = new System.Drawing.Point(3, 391);
            this.cmdLMFS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdLMFS.Name = "cmdLMFS";
            this.cmdLMFS.Size = new System.Drawing.Size(227, 35);
            this.cmdLMFS.TabIndex = 13;
            this.cmdLMFS.Text = "LMFS";
            this.cmdLMFS.Visible = false;
            this.cmdLMFS.Click += new System.EventHandler(this.cmdLMFS_Click);
            // 
            // cmdLMFC
            // 
            this.cmdLMFC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLMFC.Location = new System.Drawing.Point(3, 133);
            this.cmdLMFC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdLMFC.Name = "cmdLMFC";
            this.cmdLMFC.Size = new System.Drawing.Size(227, 35);
            this.cmdLMFC.TabIndex = 16;
            this.cmdLMFC.Text = "LMFC";
            this.cmdLMFC.Visible = false;
            this.cmdLMFC.Click += new System.EventHandler(this.cmdLMFC_Click);
            // 
            // cmdMeiosPagamento
            // 
            this.cmdMeiosPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMeiosPagamento.Location = new System.Drawing.Point(236, 133);
            this.cmdMeiosPagamento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdMeiosPagamento.Name = "cmdMeiosPagamento";
            this.cmdMeiosPagamento.Size = new System.Drawing.Size(228, 35);
            this.cmdMeiosPagamento.TabIndex = 17;
            this.cmdMeiosPagamento.Text = "Meios de Pagto.";
            this.cmdMeiosPagamento.Visible = false;
            // 
            // cmdIdPafECF
            // 
            this.cmdIdPafECF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdIdPafECF.Location = new System.Drawing.Point(236, 348);
            this.cmdIdPafECF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdIdPafECF.Name = "cmdIdPafECF";
            this.cmdIdPafECF.Size = new System.Drawing.Size(228, 35);
            this.cmdIdPafECF.TabIndex = 3;
            this.cmdIdPafECF.Text = "Identificação do PAF-ECF";
            this.cmdIdPafECF.Visible = false;
            // 
            // cmdMesasAbertas
            // 
            this.cmdMesasAbertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMesasAbertas.Location = new System.Drawing.Point(236, 90);
            this.cmdMesasAbertas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdMesasAbertas.Name = "cmdMesasAbertas";
            this.cmdMesasAbertas.Size = new System.Drawing.Size(228, 35);
            this.cmdMesasAbertas.TabIndex = 9;
            this.cmdMesasAbertas.Text = "MesasAbertas";
            this.cmdMesasAbertas.Click += new System.EventHandler(this.cmdMesasAbertas_Click);
            // 
            // cmdLeituraMovimentoDiario
            // 
            this.cmdLeituraMovimentoDiario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLeituraMovimentoDiario.Location = new System.Drawing.Point(236, 305);
            this.cmdLeituraMovimentoDiario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdLeituraMovimentoDiario.Name = "cmdLeituraMovimentoDiario";
            this.cmdLeituraMovimentoDiario.Size = new System.Drawing.Size(228, 35);
            this.cmdLeituraMovimentoDiario.TabIndex = 6;
            this.cmdLeituraMovimentoDiario.Text = "Leitura do Movimento Diário";
            this.cmdLeituraMovimentoDiario.Visible = false;
            // 
            // cmdManifestoFiscalViagem
            // 
            this.cmdManifestoFiscalViagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdManifestoFiscalViagem.Location = new System.Drawing.Point(236, 262);
            this.cmdManifestoFiscalViagem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdManifestoFiscalViagem.Name = "cmdManifestoFiscalViagem";
            this.cmdManifestoFiscalViagem.Size = new System.Drawing.Size(228, 35);
            this.cmdManifestoFiscalViagem.TabIndex = 7;
            this.cmdManifestoFiscalViagem.Text = "Manifesto Fiscal de Viagem";
            this.cmdManifestoFiscalViagem.Visible = false;
            this.cmdManifestoFiscalViagem.Click += new System.EventHandler(this.cmdManifestoFiscalViagem_Click);
            // 
            // cmdReducaoZ
            // 
            this.cmdReducaoZ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReducaoZ.Location = new System.Drawing.Point(236, 4);
            this.cmdReducaoZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdReducaoZ.Name = "cmdReducaoZ";
            this.cmdReducaoZ.Size = new System.Drawing.Size(228, 35);
            this.cmdReducaoZ.TabIndex = 5;
            this.cmdReducaoZ.Text = "Redução Z";
            this.cmdReducaoZ.Click += new System.EventHandler(this.cmdReducaoZ_Click);
            // 
            // cmdCadastrarAliquota
            // 
            this.cmdCadastrarAliquota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCadastrarAliquota.Location = new System.Drawing.Point(3, 90);
            this.cmdCadastrarAliquota.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCadastrarAliquota.Name = "cmdCadastrarAliquota";
            this.cmdCadastrarAliquota.Size = new System.Drawing.Size(227, 35);
            this.cmdCadastrarAliquota.TabIndex = 7;
            this.cmdCadastrarAliquota.Text = "Cadastrar alíquota";
            this.cmdCadastrarAliquota.Click += new System.EventHandler(this.cmdCadastrarAliquota_Click);
            // 
            // cmdCancelarUltimaVenda
            // 
            this.cmdCancelarUltimaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelarUltimaVenda.Location = new System.Drawing.Point(3, 47);
            this.cmdCancelarUltimaVenda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancelarUltimaVenda.Name = "cmdCancelarUltimaVenda";
            this.cmdCancelarUltimaVenda.Size = new System.Drawing.Size(227, 35);
            this.cmdCancelarUltimaVenda.TabIndex = 5;
            this.cmdCancelarUltimaVenda.Text = "Cancelar ultima venda";
            this.cmdCancelarUltimaVenda.Click += new System.EventHandler(this.cmdCancelarUltimaVenda_Click);
            // 
            // cmdTransfMesas
            // 
            this.cmdTransfMesas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTransfMesas.Location = new System.Drawing.Point(236, 47);
            this.cmdTransfMesas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdTransfMesas.Name = "cmdTransfMesas";
            this.cmdTransfMesas.Size = new System.Drawing.Size(228, 35);
            this.cmdTransfMesas.TabIndex = 11;
            this.cmdTransfMesas.Text = "Transf. Mesas";
            this.cmdTransfMesas.Click += new System.EventHandler(this.cmdTransfMesas_Click);
            // 
            // cmdMovimentoPorECF
            // 
            this.cmdMovimentoPorECF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMovimentoPorECF.Location = new System.Drawing.Point(3, 348);
            this.cmdMovimentoPorECF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdMovimentoPorECF.Name = "cmdMovimentoPorECF";
            this.cmdMovimentoPorECF.Size = new System.Drawing.Size(227, 35);
            this.cmdMovimentoPorECF.TabIndex = 4;
            this.cmdMovimentoPorECF.Text = "Movimento por ECF";
            this.cmdMovimentoPorECF.Visible = false;
            // 
            // cmdEstoque
            // 
            this.cmdEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEstoque.Location = new System.Drawing.Point(3, 305);
            this.cmdEstoque.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdEstoque.Name = "cmdEstoque";
            this.cmdEstoque.Size = new System.Drawing.Size(227, 35);
            this.cmdEstoque.TabIndex = 5;
            this.cmdEstoque.Text = "Estoque";
            this.cmdEstoque.Visible = false;
            // 
            // cmdTabelaProduto
            // 
            this.cmdTabelaProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTabelaProduto.Location = new System.Drawing.Point(3, 262);
            this.cmdTabelaProduto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdTabelaProduto.Name = "cmdTabelaProduto";
            this.cmdTabelaProduto.Size = new System.Drawing.Size(227, 35);
            this.cmdTabelaProduto.TabIndex = 8;
            this.cmdTabelaProduto.Text = "Tab. Prod.";
            this.cmdTabelaProduto.Visible = false;
            // 
            // cmdArquivoMDF
            // 
            this.cmdArquivoMDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdArquivoMDF.Location = new System.Drawing.Point(3, 219);
            this.cmdArquivoMDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdArquivoMDF.Name = "cmdArquivoMDF";
            this.cmdArquivoMDF.Size = new System.Drawing.Size(227, 35);
            this.cmdArquivoMDF.TabIndex = 10;
            this.cmdArquivoMDF.Text = "Arquivo MFD";
            this.cmdArquivoMDF.Visible = false;
            this.cmdArquivoMDF.Click += new System.EventHandler(this.cmdArquivoMDF_Click);
            // 
            // cmdEspelhoMDF
            // 
            this.cmdEspelhoMDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEspelhoMDF.Location = new System.Drawing.Point(3, 176);
            this.cmdEspelhoMDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdEspelhoMDF.Name = "cmdEspelhoMDF";
            this.cmdEspelhoMDF.Size = new System.Drawing.Size(227, 35);
            this.cmdEspelhoMDF.TabIndex = 12;
            this.cmdEspelhoMDF.Text = "Espelho MFD";
            this.cmdEspelhoMDF.Visible = false;
            this.cmdEspelhoMDF.Click += new System.EventHandler(this.cmdEspelhoMDF_Click);
            // 
            // cmdEncerrantes
            // 
            this.cmdEncerrantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEncerrantes.Location = new System.Drawing.Point(236, 219);
            this.cmdEncerrantes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdEncerrantes.Name = "cmdEncerrantes";
            this.cmdEncerrantes.Size = new System.Drawing.Size(228, 35);
            this.cmdEncerrantes.TabIndex = 14;
            this.cmdEncerrantes.Text = "Encerrantes";
            this.cmdEncerrantes.Visible = false;
            this.cmdEncerrantes.Click += new System.EventHandler(this.cmdEncerrantes_Click);
            // 
            // cmdDavEmitido
            // 
            this.cmdDavEmitido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDavEmitido.Location = new System.Drawing.Point(236, 176);
            this.cmdDavEmitido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdDavEmitido.Name = "cmdDavEmitido";
            this.cmdDavEmitido.Size = new System.Drawing.Size(228, 35);
            this.cmdDavEmitido.TabIndex = 15;
            this.cmdDavEmitido.Text = "DAV Emitidos";
            this.cmdDavEmitido.Visible = false;
            this.cmdDavEmitido.Click += new System.EventHandler(this.cmdDavEmitido_Click);
            // 
            // mnuFuncoesFiscaisAdicionais
            // 
            this.mnuFuncoesFiscaisAdicionais.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdCadAliquota,
            this.cmdCadFormaPagamento});
            this.mnuFuncoesFiscaisAdicionais.Name = "mnuFuncoesFiscaisAdicionais";
            this.mnuFuncoesFiscaisAdicionais.Size = new System.Drawing.Size(240, 48);
            this.mnuFuncoesFiscaisAdicionais.Click += new System.EventHandler(this.mnuFuncoesFiscaisAdicionais_Click);
            // 
            // cmdCadAliquota
            // 
            this.cmdCadAliquota.Name = "cmdCadAliquota";
            this.cmdCadAliquota.Size = new System.Drawing.Size(239, 22);
            this.cmdCadAliquota.Text = "Cadastrar alíquota";
            this.cmdCadAliquota.Click += new System.EventHandler(this.cmdCadAliquota_Click);
            // 
            // cmdCadFormaPagamento
            // 
            this.cmdCadFormaPagamento.Name = "cmdCadFormaPagamento";
            this.cmdCadFormaPagamento.Size = new System.Drawing.Size(239, 22);
            this.cmdCadFormaPagamento.Text = "Cadastrar forma de pagamento";
            // 
            // FormMenuFiscal
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 459);
            this.ContextMenuStrip = this.mnuFuncoesFiscaisAdicionais;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormMenuFiscal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu fiscal";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mnuFuncoesFiscaisAdicionais.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdLeituraX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton cmdIdPafECF;
        private DevExpress.XtraEditors.SimpleButton cmdMovimentoPorECF;
        private DevExpress.XtraEditors.SimpleButton cmdEstoque;
        private DevExpress.XtraEditors.SimpleButton cmdLeituraMovimentoDiario;
        private DevExpress.XtraEditors.SimpleButton cmdManifestoFiscalViagem;
        private DevExpress.XtraEditors.SimpleButton cmdTabelaProduto;
        private DevExpress.XtraEditors.SimpleButton cmdMesasAbertas;
        private DevExpress.XtraEditors.SimpleButton cmdArquivoMDF;
        private DevExpress.XtraEditors.SimpleButton cmdTransfMesas;
        private DevExpress.XtraEditors.SimpleButton cmdEspelhoMDF;
        private DevExpress.XtraEditors.SimpleButton cmdLMFS;
        private DevExpress.XtraEditors.SimpleButton cmdEncerrantes;
        private DevExpress.XtraEditors.SimpleButton cmdDavEmitido;
        private DevExpress.XtraEditors.SimpleButton cmdLMFC;
        private DevExpress.XtraEditors.SimpleButton cmdMeiosPagamento;
        private System.Windows.Forms.ContextMenuStrip mnuFuncoesFiscaisAdicionais;
        private System.Windows.Forms.ToolStripMenuItem cmdCadAliquota;
        private System.Windows.Forms.ToolStripMenuItem cmdCadFormaPagamento;
        private DevExpress.XtraEditors.SimpleButton cmdReducaoZ;
        private DevExpress.XtraEditors.SimpleButton cmdCancelarUltimaVenda;
        private DevExpress.XtraEditors.SimpleButton cmdAliquotasCadastradas;
        private DevExpress.XtraEditors.SimpleButton cmdCadastrarAliquota;
    }
}