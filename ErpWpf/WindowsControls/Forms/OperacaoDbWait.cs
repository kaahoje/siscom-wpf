using DevExpress.XtraWaitForm;

namespace WindowsControls.Forms
{
    public partial class OperacaoDbWait : WaitForm
    {
        public enum WaitFormCommand
        {
        }

        public OperacaoDbWait()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }

        #endregion
    }
}