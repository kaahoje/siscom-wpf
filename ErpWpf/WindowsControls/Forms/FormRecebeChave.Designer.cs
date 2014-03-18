namespace WindowsControls.Forms
{
    partial class FormRecebeChave
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
            this.chaveTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cmdGravar = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chaveTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chave:";
            // 
            // chaveTextEdit
            // 
            this.chaveTextEdit.Location = new System.Drawing.Point(60, 12);
            this.chaveTextEdit.Name = "chaveTextEdit";
            this.chaveTextEdit.Size = new System.Drawing.Size(334, 20);
            this.chaveTextEdit.TabIndex = 1;
            this.chaveTextEdit.EditValueChanged += new System.EventHandler(this.chaveTextEdit_EditValueChanged);
            // 
            // cmdGravar
            // 
            this.cmdGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGravar.Location = new System.Drawing.Point(252, 56);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(75, 35);
            this.cmdGravar.TabIndex = 2;
            this.cmdGravar.Text = "Gravar";
            this.cmdGravar.Click += new System.EventHandler(this.cmdGravar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(342, 56);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 35);
            this.cmdCancelar.TabIndex = 3;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // FormRecebeChave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 103);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.chaveTextEdit);
            this.Controls.Add(this.label1);
            this.Name = "FormRecebeChave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe a chave do terminal";
            ((System.ComponentModel.ISupportInitialize)(this.chaveTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit chaveTextEdit;
        private DevExpress.XtraEditors.SimpleButton cmdGravar;
        private DevExpress.XtraEditors.SimpleButton cmdCancelar;
    }
}