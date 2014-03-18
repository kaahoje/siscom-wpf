using System;
using System.Windows.Forms;
using WindowsControls.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace WindowsControls.Controls
{
    public class CommandBase : SimpleButton
    {
        private Keys _atalho;
        private bool _ativo;
        private IForm _form;
        private SplashScreenManager _splash;

        public CommandBase()
        {
            Height = 35;
            Width = 100;
        }

        public Keys Atalho
        {
            get { return _atalho; }
            set
            {
                _atalho = value;
                Text = Texto(Text);
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = Texto(value); }
        }

        public IForm Form
        {
            get { return _form; }
            set
            {
                _form = value;
                if (!IsDesignMode)
                {
                    if (Form != null)
                    {
                        Form.Form.KeyDown += FormOnKeyDown;
                        Form.Form.Activated += Form_Activated;
                        _splash = new SplashScreenManager(Form.Form, typeof (OperacaoDbWait), true, true);
                    }
                }
            }
        }

        private string Texto(string texto)
        {
            string sAtalho = _atalho.ToString();
            if (sAtalho.Length > 3)
            {
                sAtalho = sAtalho.Substring(0, 3);
            }
            if (texto.Contains("("))
            {
                texto = texto.Substring(0, texto.IndexOf("("))
                        + "(" + sAtalho + ")";
            }
            else
            {
                texto = texto + "(" + sAtalho + ")";
            }
            return texto;
        }

        protected void BeforeOperation()
        {
            if (!_splash.IsSplashFormVisible && _ativo)
            {
                _splash.ShowWaitForm();
            }
        }

        protected void AfterOperation()
        {
            if (_splash.IsSplashFormVisible && _ativo)
            {
                _splash.CloseWaitForm();
            }
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            Actived();

            _ativo = true;
        }

        private void FormOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            OnKeyDown(keyEventArgs);
        }

        protected void ExibeErro(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandBase
            // 
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TabStop = false;
            ResumeLayout(false);
        }

        public virtual void Actived()
        {
        }
    }
}