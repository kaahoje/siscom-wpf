using System;
using System.Windows.Forms;
using WindowsControls.Controls;
using DevExpress.XtraEditors;
using Erp.Business.Seguranca;

namespace WindowsControls.Forms
{
    public partial class ListDefault : XtraForm
    {
        private CommandDelete _commandDelete;
        private CommandNovo _commandNovo;
        private CommandReload _commandRefresh;
        private CommandUpdate _commandUpdate;

        public ListDefault()
        {
            InitializeComponent();
        }

        public IForm FormEdit { get; set; }

        public CommandReload CommandRefresh
        {
            get { return _commandRefresh; }
            set
            {
                value.Form = GetForm();
                _commandRefresh = value;
            }
        }

        public CommandNovo CommandNovo
        {
            get { return _commandNovo; }
            set
            {
                value.Form = GetForm();
                _commandNovo = value;
            }
        }

        public CommandUpdate CommandUpdate
        {
            get { return _commandUpdate; }
            set
            {
                value.Form = GetForm();
                _commandUpdate = value;
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

        private void ListDefault_Shown(object sender, EventArgs e)
        {
            Visible = false;

            //if (!SegurancaUtils.VerificaPermissaoList(Name))
            //{
            //    MessageBox.Show("Usuário sem permissão para acessar esse formulário.");
            //    Close();
            //    return;
            //}
            Visible = true;
        }

        protected IForm GetForm()
        {
            if (DesignMode)
            {
                return null;
            }
            try
            {
                return (IForm) this;
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível converter o a tela para um tipo " +
                                "de formulário.");
                return null;
            }
        }
    }
}