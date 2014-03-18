namespace Ecf.Forms
{
    partial class FormCadastrarAliquota
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
            this.cboTipoAliquota = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tipoAliquotaDicionaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAliquota = new DevExpress.XtraEditors.SpinEdit();
            this.cmdSair = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCadastrar = new DevExpress.XtraEditors.SimpleButton();
            this.lstAliquotas = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoAliquota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoAliquotaDicionaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAliquota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstAliquotas)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoAliquota
            // 
            this.cboTipoAliquota.Location = new System.Drawing.Point(138, 13);
            this.cboTipoAliquota.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTipoAliquota.Name = "cboTipoAliquota";
            this.cboTipoAliquota.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAliquota.Properties.Appearance.Options.UseFont = true;
            this.cboTipoAliquota.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoAliquota.Properties.DataSource = this.tipoAliquotaDicionaryBindingSource;
            this.cboTipoAliquota.Properties.DisplayMember = "Descricao";
            this.cboTipoAliquota.Properties.ValueMember = "Valor";
            this.cboTipoAliquota.Properties.View = this.gridLookUpEdit1View;
            this.cboTipoAliquota.Size = new System.Drawing.Size(134, 24);
            this.cboTipoAliquota.TabIndex = 0;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de alíquota:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alíquota:";
            // 
            // txtAliquota
            // 
            this.txtAliquota.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAliquota.Location = new System.Drawing.Point(81, 45);
            this.txtAliquota.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquota.Properties.Appearance.Options.UseFont = true;
            this.txtAliquota.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAliquota.Size = new System.Drawing.Size(134, 24);
            this.txtAliquota.TabIndex = 3;
            // 
            // cmdSair
            // 
            this.cmdSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSair.Location = new System.Drawing.Point(280, 348);
            this.cmdSair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(99, 35);
            this.cmdSair.TabIndex = 5;
            this.cmdSair.Text = "Sair";
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdCadastrar
            // 
            this.cmdCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCadastrar.Location = new System.Drawing.Point(175, 348);
            this.cmdCadastrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCadastrar.Name = "cmdCadastrar";
            this.cmdCadastrar.Size = new System.Drawing.Size(99, 35);
            this.cmdCadastrar.TabIndex = 4;
            this.cmdCadastrar.Text = "Cadastrar";
            this.cmdCadastrar.Click += new System.EventHandler(this.cmdCadastrar_Click);
            // 
            // lstAliquotas
            // 
            this.lstAliquotas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAliquotas.Location = new System.Drawing.Point(12, 76);
            this.lstAliquotas.Name = "lstAliquotas";
            this.lstAliquotas.Size = new System.Drawing.Size(367, 265);
            this.lstAliquotas.TabIndex = 6;
            // 
            // FormCadastrarAliquota
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 396);
            this.Controls.Add(this.lstAliquotas);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdCadastrar);
            this.Controls.Add(this.txtAliquota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoAliquota);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FormCadastrarAliquota";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoAliquota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoAliquotaDicionaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAliquota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstAliquotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit cboTipoAliquota;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SpinEdit txtAliquota;
        private DevExpress.XtraEditors.SimpleButton cmdSair;
        private DevExpress.XtraEditors.SimpleButton cmdCadastrar;
        private System.Windows.Forms.BindingSource tipoAliquotaDicionaryBindingSource;
        private DevExpress.XtraEditors.ListBoxControl lstAliquotas;
    }
}