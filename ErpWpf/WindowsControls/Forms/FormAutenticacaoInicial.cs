using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.InformacoesIniciais;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using Util.Seguranca;

namespace WindowsControls.Forms
{
    public partial class FormAutenticacaoInicial : XtraForm
    {
        public FormAutenticacaoInicial()
        {
            InitializeComponent();
        }

        private int Count { get; set; }
        private bool Autenticar { get; set; }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            string senha = Criptografia.CriptografarSenha(senhaTextEdit.Text);
            string senhaInformada = new Criptografia.CriptHash().GetHash("123");
            if (usuarioTextEdit.Text.Equals("master") &&
                senhaInformada.Equals(senha))
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            MessageBox.Show("Usuário não autorizado", "Alerta!");
            Count += 1;
            if (Count >= 3)
            {
                Application.Exit();
            }
        }

        private void cmdConfiguracoes_Click(object sender, EventArgs e)
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdCriarBancoDeDadosToolStrip_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(this, "Esta operação cria o banco de dados. \n" +
                                                    "Mas caso o banco de dados já exista ele será apagado.\n\n" +
                                                    "Deseja realmente executar esta operação?", "Atenção",
                MessageBoxButtons.OKCancel);
            if (rs == DialogResult.OK)
            {
                createDbSplashScreenManager.ShowWaitForm();
                Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(DataBaseManager.CnnStr))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pessoa>())
                    .ExposeConfiguration(config =>
                    {
                        var export = new SchemaExport(config);
                        export.Drop(true, true);
                        export.Create(true, true);
                    })
                    .BuildSessionFactory();
                new DadosIniciais();
            }
            createDbSplashScreenManager.CloseWaitForm();
            MessageBox.Show("A aplicação será reiniciada agora.", "Atenção");
            Process.GetCurrentProcess().Kill();
        }
    }
}