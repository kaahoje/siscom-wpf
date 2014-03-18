namespace WindowsControls.Forms
{
     partial class FormDefault
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
            this.SuspendLayout();
            // 
            // FormDefault
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 322);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDefault";
            this.Text = "FormDefault";
            this.Activated += new System.EventHandler(this.FormDefault_Activated);
            this.Shown += new System.EventHandler(this.FormDefault_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDefault_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormDefault_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
    }
}