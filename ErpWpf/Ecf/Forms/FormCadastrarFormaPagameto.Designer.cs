namespace Ecf.Forms
{
    partial class FormCadastrarFormaPagameto
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
            this.txtFormaPag = new DevExpress.XtraEditors.TextEdit();
            this.cmdCadastrar = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSair = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de pagamento:";
            // 
            // txtFormaPag
            // 
            this.txtFormaPag.Location = new System.Drawing.Point(177, 18);
            this.txtFormaPag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFormaPag.Name = "txtFormaPag";
            this.txtFormaPag.Size = new System.Drawing.Size(475, 20);
            this.txtFormaPag.TabIndex = 1;
            // 
            // cmdCadastrar
            // 
            this.cmdCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCadastrar.Location = new System.Drawing.Point(448, 61);
            this.cmdCadastrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCadastrar.Name = "cmdCadastrar";
            this.cmdCadastrar.Size = new System.Drawing.Size(99, 35);
            this.cmdCadastrar.TabIndex = 2;
            this.cmdCadastrar.Text = "Cadastrar";
            this.cmdCadastrar.Click += new System.EventHandler(this.cmdCadastrar_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSair.Location = new System.Drawing.Point(553, 61);
            this.cmdSair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(99, 35);
            this.cmdSair.TabIndex = 3;
            this.cmdSair.Text = "Sair";
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // FormCadastrarFormaPagameto
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 109);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdCadastrar);
            this.Controls.Add(this.txtFormaPag);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FormCadastrarFormaPagameto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de forma de pagamento";
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPag.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtFormaPag;
        private DevExpress.XtraEditors.SimpleButton cmdCadastrar;
        private DevExpress.XtraEditors.SimpleButton cmdSair;
    }
}