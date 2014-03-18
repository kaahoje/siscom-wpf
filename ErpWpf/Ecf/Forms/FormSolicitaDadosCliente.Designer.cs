namespace Ecf.Forms
{
    partial class FormSolicitaDadosCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoPessoa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCpfCnpj = new DevExpress.XtraEditors.TextEdit();
            this.clienteCupomBindingSource = new System.Windows.Forms.BindingSource();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new DevExpress.XtraEditors.TextEdit();
            this.txtEndereco = new DevExpress.XtraEditors.TextEdit();
            this.cmdConfirmar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoPessoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCpfCnpj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteCupomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazaoSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndereco.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // cboTipoPessoa
            // 
            this.cboTipoPessoa.Location = new System.Drawing.Point(57, 12);
            this.cboTipoPessoa.Name = "cboTipoPessoa";
            this.cboTipoPessoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoPessoa.Properties.Items.AddRange(new object[] {
            "FISICA",
            "JURIDICA"});
            this.cboTipoPessoa.Size = new System.Drawing.Size(130, 20);
            this.cboTipoPessoa.TabIndex = 1;
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clienteCupomBindingSource, "CpfCnpj", true));
            this.txtCpfCnpj.EditValue = "";
            this.txtCpfCnpj.Location = new System.Drawing.Point(92, 38);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Properties.Mask.EditMask = "###.###.###-##";
            this.txtCpfCnpj.Properties.Mask.IgnoreMaskBlank = false;
            this.txtCpfCnpj.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtCpfCnpj.Properties.Mask.PlaceHolder = ' ';
            this.txtCpfCnpj.Properties.Mask.SaveLiteral = false;
            this.txtCpfCnpj.Size = new System.Drawing.Size(194, 20);
            this.txtCpfCnpj.TabIndex = 2;
            // 
            // clienteCupomBindingSource
            // 
            this.clienteCupomBindingSource.DataSource = typeof(Ecf.ClienteCupom);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Endereço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "CPF/CNPJ:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clienteCupomBindingSource, "Nome", true));
            this.txtRazaoSocial.Location = new System.Drawing.Point(67, 64);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(366, 20);
            this.txtRazaoSocial.TabIndex = 6;
            // 
            // txtEndereco
            // 
            this.txtEndereco.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clienteCupomBindingSource, "Endereco", true));
            this.txtEndereco.Location = new System.Drawing.Point(92, 90);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(397, 20);
            this.txtEndereco.TabIndex = 7;
            // 
            // cmdConfirmar
            // 
            this.cmdConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirmar.Location = new System.Drawing.Point(438, 137);
            this.cmdConfirmar.Name = "cmdConfirmar";
            this.cmdConfirmar.Size = new System.Drawing.Size(75, 35);
            this.cmdConfirmar.TabIndex = 8;
            this.cmdConfirmar.Text = "Confirmar";
            this.cmdConfirmar.Click += new System.EventHandler(this.cmdConfirmar_Click);
            // 
            // FormSolicitaDadosCliente
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 184);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.cboTipoPessoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRazaoSocial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCpfCnpj);
            this.Controls.Add(this.cmdConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormSolicitaDadosCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações do cliente";
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoPessoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCpfCnpj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteCupomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazaoSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndereco.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoPessoa;
        private DevExpress.XtraEditors.TextEdit txtCpfCnpj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtRazaoSocial;
        private DevExpress.XtraEditors.TextEdit txtEndereco;
        private DevExpress.XtraEditors.SimpleButton cmdConfirmar;
        private System.Windows.Forms.BindingSource clienteCupomBindingSource;
    }
}