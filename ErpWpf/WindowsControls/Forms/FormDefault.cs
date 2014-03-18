using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using WindowsControls.Controls;
using DevExpress.XtraEditors;
using Erp.Business.Validation;
using Utils = WindowsControls.Util.Utils;

namespace WindowsControls.Forms
{
    public partial class FormDefault : XtraForm
    {
        private CommandCancel _commandCancel;
        private CommandDelete _commandDelete;
        private CommandSave _commandSave;

        public int GetInt(object o)
        {
            var val = o.ToString();
            val = Validation.GetOnlyNumber(val);
            if (String.IsNullOrEmpty(val))
            {
                return 0;
            }
            return int.Parse(val);
        }
        public decimal GetDecimal(object o)
        {
            var val = o.ToString();
            val = Validation.GetOnlyNumber(val);
            if (String.IsNullOrEmpty(val))
            {
                return 0;
            }
            return decimal.Parse(val);
        }
        public string GetString(object o)
        {
            return o.ToString();
        }

        public FormDefault()
        {
            InitializeComponent();
        }

        public CommandCancel CommandCancel
        {
            get { return _commandCancel; }
            set
            {
                value.Form = GetForm();
                _commandCancel = value;
            }
        }

        public CommandDelete CommandDelete
        {
            get { return _commandDelete; }
            set
            {
                value.Form = GetForm();
                _commandDelete = value;
            }
        }

        public CommandSave CommandSave
        {
            get { return _commandSave; }
            set
            {
                value.Form = GetForm();
                _commandSave = value;
            }
        }

        protected Control InitFocusControl { get; set; }

        private void FormDefault_Activated(object sender, EventArgs e)
        {
        }

        private void FormDefault_Shown(object sender, EventArgs e)
        {
            if (InitFocusControl != null)
            {
                InitFocusControl.Focus();
            }
            Visible = false;
            Visible = true;
            // Chama a verificação de permissão para os botões do formulário.
        }

        private void FormDefault_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        protected void ExibeErrosPreencimento(EntityValidationResult result)
        {
            string mensagem = "Erros encontrados no preenchimento dos campos.\n";
            foreach (ValidationResult error in result.ValidationErrors)
            {
                mensagem += error.ErrorMessage;
            }
            MessageBox.Show(mensagem, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormDefault_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Utils.ValidaChar(e.KeyChar);
        }

        public IForm GetForm()
        {
            if (DesignMode)
            {
                return null;
            }
            return (IForm)this;
        }
    }
}