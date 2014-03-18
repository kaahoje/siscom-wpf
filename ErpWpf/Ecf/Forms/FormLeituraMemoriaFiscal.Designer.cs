namespace Ecf.Forms
{
    partial class FormLeituraMemoriaFiscal
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
            this.tipoIntervaloRadioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.tipoLeituraRadioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.tipoLeituraGroupBox = new System.Windows.Forms.GroupBox();
            this.filtroGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inicioFiltroCrzLabel = new System.Windows.Forms.Label();
            this.fimFiltroCrzLabel = new System.Windows.Forms.Label();
            this.inicioSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.fimSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inicioFiltroDataLabel = new System.Windows.Forms.Label();
            this.inicioDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.fimFiltroDataLabel = new System.Windows.Forms.Label();
            this.fimDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.gerarArquivoSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.imprimirLeituraSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.fecharSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tipoIntervaloRadioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoLeituraRadioGroup.Properties)).BeginInit();
            this.tipoLeituraGroupBox.SuspendLayout();
            this.filtroGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fimSpinEdit.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inicioDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fimDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fimDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoIntervaloRadioGroup
            // 
            this.tipoIntervaloRadioGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoIntervaloRadioGroup.Location = new System.Drawing.Point(7, 25);
            this.tipoIntervaloRadioGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tipoIntervaloRadioGroup.Name = "tipoIntervaloRadioGroup";
            this.tipoIntervaloRadioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tipoIntervaloRadioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.tipoIntervaloRadioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Data"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "CRZ")});
            this.tipoIntervaloRadioGroup.Size = new System.Drawing.Size(422, 36);
            this.tipoIntervaloRadioGroup.TabIndex = 6;
            // 
            // tipoLeituraRadioGroup
            // 
            this.tipoLeituraRadioGroup.Location = new System.Drawing.Point(7, 25);
            this.tipoLeituraRadioGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tipoLeituraRadioGroup.Name = "tipoLeituraRadioGroup";
            this.tipoLeituraRadioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tipoLeituraRadioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.tipoLeituraRadioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tipoLeituraRadioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Completa"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Simplificada")});
            this.tipoLeituraRadioGroup.Size = new System.Drawing.Size(246, 37);
            this.tipoLeituraRadioGroup.TabIndex = 8;
            // 
            // tipoLeituraGroupBox
            // 
            this.tipoLeituraGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoLeituraGroupBox.Controls.Add(this.tipoLeituraRadioGroup);
            this.tipoLeituraGroupBox.Location = new System.Drawing.Point(14, 190);
            this.tipoLeituraGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tipoLeituraGroupBox.Name = "tipoLeituraGroupBox";
            this.tipoLeituraGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tipoLeituraGroupBox.Size = new System.Drawing.Size(436, 76);
            this.tipoLeituraGroupBox.TabIndex = 10;
            this.tipoLeituraGroupBox.TabStop = false;
            this.tipoLeituraGroupBox.Text = "Tipo de leitura";
            // 
            // filtroGroupBox
            // 
            this.filtroGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtroGroupBox.Controls.Add(this.groupBox1);
            this.filtroGroupBox.Controls.Add(this.groupBox2);
            this.filtroGroupBox.Controls.Add(this.tipoIntervaloRadioGroup);
            this.filtroGroupBox.Location = new System.Drawing.Point(14, 13);
            this.filtroGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filtroGroupBox.Name = "filtroGroupBox";
            this.filtroGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filtroGroupBox.Size = new System.Drawing.Size(436, 169);
            this.filtroGroupBox.TabIndex = 11;
            this.filtroGroupBox.TabStop = false;
            this.filtroGroupBox.Text = "Intervalo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inicioFiltroCrzLabel);
            this.groupBox1.Controls.Add(this.fimFiltroCrzLabel);
            this.groupBox1.Controls.Add(this.inicioSpinEdit);
            this.groupBox1.Controls.Add(this.fimSpinEdit);
            this.groupBox1.Location = new System.Drawing.Point(239, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(188, 90);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // inicioFiltroCrzLabel
            // 
            this.inicioFiltroCrzLabel.AutoSize = true;
            this.inicioFiltroCrzLabel.Location = new System.Drawing.Point(7, 21);
            this.inicioFiltroCrzLabel.Name = "inicioFiltroCrzLabel";
            this.inicioFiltroCrzLabel.Size = new System.Drawing.Size(44, 17);
            this.inicioFiltroCrzLabel.TabIndex = 13;
            this.inicioFiltroCrzLabel.Text = "Inicio:";
            // 
            // fimFiltroCrzLabel
            // 
            this.fimFiltroCrzLabel.AutoSize = true;
            this.fimFiltroCrzLabel.Location = new System.Drawing.Point(7, 53);
            this.fimFiltroCrzLabel.Name = "fimFiltroCrzLabel";
            this.fimFiltroCrzLabel.Size = new System.Drawing.Size(34, 17);
            this.fimFiltroCrzLabel.TabIndex = 14;
            this.fimFiltroCrzLabel.Text = "Fim:";
            // 
            // inicioSpinEdit
            // 
            this.inicioSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inicioSpinEdit.Location = new System.Drawing.Point(55, 17);
            this.inicioSpinEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inicioSpinEdit.Name = "inicioSpinEdit";
            this.inicioSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inicioSpinEdit.Size = new System.Drawing.Size(117, 20);
            this.inicioSpinEdit.TabIndex = 9;
            // 
            // fimSpinEdit
            // 
            this.fimSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fimSpinEdit.Location = new System.Drawing.Point(49, 49);
            this.fimSpinEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fimSpinEdit.Name = "fimSpinEdit";
            this.fimSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fimSpinEdit.Size = new System.Drawing.Size(117, 20);
            this.fimSpinEdit.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inicioFiltroDataLabel);
            this.groupBox2.Controls.Add(this.inicioDateEdit);
            this.groupBox2.Controls.Add(this.fimFiltroDataLabel);
            this.groupBox2.Controls.Add(this.fimDateEdit);
            this.groupBox2.Location = new System.Drawing.Point(7, 68);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(220, 90);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // inicioFiltroDataLabel
            // 
            this.inicioFiltroDataLabel.AutoSize = true;
            this.inicioFiltroDataLabel.Location = new System.Drawing.Point(7, 21);
            this.inicioFiltroDataLabel.Name = "inicioFiltroDataLabel";
            this.inicioFiltroDataLabel.Size = new System.Drawing.Size(44, 17);
            this.inicioFiltroDataLabel.TabIndex = 11;
            this.inicioFiltroDataLabel.Text = "Inicio:";
            // 
            // inicioDateEdit
            // 
            this.inicioDateEdit.EditValue = null;
            this.inicioDateEdit.Location = new System.Drawing.Point(56, 17);
            this.inicioDateEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inicioDateEdit.Name = "inicioDateEdit";
            this.inicioDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inicioDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inicioDateEdit.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.inicioDateEdit.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.inicioDateEdit.Size = new System.Drawing.Size(157, 20);
            this.inicioDateEdit.TabIndex = 7;
            // 
            // fimFiltroDataLabel
            // 
            this.fimFiltroDataLabel.AutoSize = true;
            this.fimFiltroDataLabel.Location = new System.Drawing.Point(7, 53);
            this.fimFiltroDataLabel.Name = "fimFiltroDataLabel";
            this.fimFiltroDataLabel.Size = new System.Drawing.Size(34, 17);
            this.fimFiltroDataLabel.TabIndex = 12;
            this.fimFiltroDataLabel.Text = "Fim:";
            // 
            // fimDateEdit
            // 
            this.fimDateEdit.EditValue = null;
            this.fimDateEdit.Location = new System.Drawing.Point(45, 49);
            this.fimDateEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fimDateEdit.Name = "fimDateEdit";
            this.fimDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fimDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fimDateEdit.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.fimDateEdit.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.fimDateEdit.Size = new System.Drawing.Size(161, 20);
            this.fimDateEdit.TabIndex = 8;
            // 
            // gerarArquivoSimpleButton
            // 
            this.gerarArquivoSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gerarArquivoSimpleButton.Location = new System.Drawing.Point(119, 282);
            this.gerarArquivoSimpleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gerarArquivoSimpleButton.Name = "gerarArquivoSimpleButton";
            this.gerarArquivoSimpleButton.Size = new System.Drawing.Size(110, 43);
            this.gerarArquivoSimpleButton.TabIndex = 12;
            this.gerarArquivoSimpleButton.Text = "Gerar arquivo";
            this.gerarArquivoSimpleButton.Click += new System.EventHandler(this.gerarArquivoSimpleButton_Click);
            // 
            // imprimirLeituraSimpleButton
            // 
            this.imprimirLeituraSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimirLeituraSimpleButton.Location = new System.Drawing.Point(236, 282);
            this.imprimirLeituraSimpleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imprimirLeituraSimpleButton.Name = "imprimirLeituraSimpleButton";
            this.imprimirLeituraSimpleButton.Size = new System.Drawing.Size(120, 43);
            this.imprimirLeituraSimpleButton.TabIndex = 13;
            this.imprimirLeituraSimpleButton.Text = "Imprimir leitura";
            this.imprimirLeituraSimpleButton.Click += new System.EventHandler(this.imprimirLeituraSimpleButton_Click);
            // 
            // fecharSimpleButton
            // 
            this.fecharSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fecharSimpleButton.Location = new System.Drawing.Point(363, 282);
            this.fecharSimpleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fecharSimpleButton.Name = "fecharSimpleButton";
            this.fecharSimpleButton.Size = new System.Drawing.Size(87, 43);
            this.fecharSimpleButton.TabIndex = 14;
            this.fecharSimpleButton.Text = "Fechar";
            this.fecharSimpleButton.Click += new System.EventHandler(this.fecharSimpleButton_Click);
            // 
            // FormLeituraMemoriaFiscal
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 340);
            this.Controls.Add(this.fecharSimpleButton);
            this.Controls.Add(this.imprimirLeituraSimpleButton);
            this.Controls.Add(this.gerarArquivoSimpleButton);
            this.Controls.Add(this.filtroGroupBox);
            this.Controls.Add(this.tipoLeituraGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormLeituraMemoriaFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leitura de memória fiscal";
            ((System.ComponentModel.ISupportInitialize)(this.tipoIntervaloRadioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoLeituraRadioGroup.Properties)).EndInit();
            this.tipoLeituraGroupBox.ResumeLayout(false);
            this.filtroGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fimSpinEdit.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inicioDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fimDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fimDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup tipoIntervaloRadioGroup;
        private DevExpress.XtraEditors.RadioGroup tipoLeituraRadioGroup;
        private System.Windows.Forms.GroupBox tipoLeituraGroupBox;
        private System.Windows.Forms.GroupBox filtroGroupBox;
        private System.Windows.Forms.Label fimFiltroCrzLabel;
        private System.Windows.Forms.Label inicioFiltroCrzLabel;
        private System.Windows.Forms.Label fimFiltroDataLabel;
        private System.Windows.Forms.Label inicioFiltroDataLabel;
        private DevExpress.XtraEditors.SpinEdit fimSpinEdit;
        private DevExpress.XtraEditors.SpinEdit inicioSpinEdit;
        private DevExpress.XtraEditors.DateEdit fimDateEdit;
        private DevExpress.XtraEditors.DateEdit inicioDateEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton gerarArquivoSimpleButton;
        private DevExpress.XtraEditors.SimpleButton imprimirLeituraSimpleButton;
        private DevExpress.XtraEditors.SimpleButton fecharSimpleButton;
    }
}