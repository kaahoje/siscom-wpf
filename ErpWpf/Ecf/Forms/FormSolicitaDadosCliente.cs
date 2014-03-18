using WindowsControls.Forms;


namespace Ecf.Forms
{
    public partial class FormSolicitaDadosCliente : FormDefault
    {
        public FormSolicitaDadosCliente(ClienteCupom cliente)
        {
            InitializeComponent();
            cliente.CpfCnpj = "";
            cliente.Nome = "";
            cliente.Endereco = "";
            clienteCupomBindingSource.Add(cliente);
            InitFocusControl = cboTipoPessoa;
        }

        private void cmdConfirmar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public ClienteCupom ClienteCupom
        {
            get
            {
                return (ClienteCupom)clienteCupomBindingSource.Current;
            }
        }

        

        }
}
