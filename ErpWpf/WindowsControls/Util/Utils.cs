using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Erp.Business.Entity.Configuracao;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;

namespace WindowsControls.Util
{
    public class Utils
    {
        public static ConfiguracaoGeral _Configuracao = null;

        
        public static PessoaFisica UsuarioAtual { get; set; }

        public static ConfiguracaoGeral Configuracao
        {
            get
            {
                try
                {
                    //if (_Configuracao == null)
                    //{
                    //    _Configuracao =
                    //        RepositoryBase<ConfiguracaoGeral>.GetSession()
                    //            .CreateCriteria<ConfiguracaoGeral>()
                    //            .UniqueResult<ConfiguracaoGeral>();
                    //}
                    //if (_Configuracao == null)
                    //{
                    //    _Configuracao = new ConfiguracaoGeral();
                    //}
                    //if (Terminal != null)
                    //{
                    //    if (!Terminal.Ativo)
                    //    {
                    //        MessageBox.Show("O terminal não está ativo.");
                    //        Process.GetCurrentProcess().Close();
                    //    }
                    //}

                    //return _Configuracao;
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                _Configuracao = value;
            }
        }

        //public static ConfTerminal Terminal
        //{
        //    get
        //    {
        //        if (_Terminal == null)
        //        {
        //            _Terminal = ConfTerminalRepository.GetByChave(ObterChave());
        //            if (_Terminal == null)
        //            {
        //                MessageBox.Show("Terminal não cadastrado!");
        //                Application.Exit();
        //            }
        //            if (_Terminal != null && !_Terminal.Ativo)
        //            {
        //                MessageBox.Show("Terminal não autorizado!");
        //                Application.Exit();
        //            }
        //        }
        //        return _Terminal;
        //    }
        //    set { _Terminal = value; }
        //}

        public String NomeUsuario
        {
            get { return UsuarioAtual.Nome; }
        }

        
        //public static void BackupBaseDados()
        //{
        //    var split = DataBaseManager.CnnStr.Split(';');


        //    string cmd = " -i -U " + u + // Usuário
        //                 " -h " + h + // Host
        //                 " -p " + p + // Port 
        //                 " -F c " + // Format
        //                 " -f " + dir + "\\backup" + DateTime.Now.Ticks + ".backup " + // File
        //                 db; // Banco de dados

        //    // Cria o novo processo.
        //    var info = new ProcessStartInfo();
        //    info.FileName = pgDump + "\\pg_dump.exe";

        //    // Seta a variável de ambiente no Shell
        //    Environment.SetEnvironmentVariable("PGPASSWORD", w);

        //    info.Arguments = cmd;
        //    info.CreateNoWindow = true;
        //    info.UseShellExecute = false;
        //    info.ErrorDialog = true;

        //    // Cria o processo.
        //    var proc = new Process();


        //    proc.StartInfo = info;
        //    proc.Start();
        //    proc.ErrorDataReceived += proc_ErrorDataReceived;
        //    proc.OutputDataReceived += proc_OutputDataReceived;
        //    proc.Exited += proc_Exited;
        //    proc.WaitForExit();
        //}

        private static void proc_Exited(object sender, EventArgs e)
        {
        }

        private static void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            MessageBox.Show(e.Data);
        }

        private static void proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            MessageBox.Show(e.Data);
        }

        private static string ObterChave()
        {
            return ConfigurationManager.AppSettings["idAplicativo"];
        }

        
        public static void SetChaveTerminal(string chave)
        {
            //if (Settings.Default.IdAplicacao != "")
            //{
            //    MessageBox.Show("Tentativa de alterar o identificador do termnal " +
            //                    "inválida.");
            //    Application.Exit();
            //}
            //Settings.Default.IdAplicacao = chave;
            //Settings.Default.Save();
        }

        public static void GravarArquivo(string caminho, string conteudo)
        {
            using (var file = new StreamWriter(caminho, true))
            {
                file.WriteLine(conteudo);
            }
        }

        public static String ValidaString(string valor)
        {
            char[] chars = valor.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = ValidaChar(chars[i]);
            }
            return new string(chars);
        }

        public static String RemoveCaracteresEspeciais(string valor)
        {
            valor = valor.Replace("ã", "a");
            valor = valor.Replace("Ã", "A");

            valor = valor.Replace("á", "a");
            valor = valor.Replace("Á", "A");

            valor = valor.Replace("â", "a");
            valor = valor.Replace("Â", "A");

            valor = valor.Replace("ä", "a");
            valor = valor.Replace("Ä", "A");

            valor = valor.Replace("à", "a");
            valor = valor.Replace("À", "A");

            // Caracters não permitidos.
            valor = valor.Replace("ª", "");
            valor = valor.Replace("º", "");
            valor = valor.Replace("-", "");
            valor = valor.Replace("'", "");

            valor = valor.Replace("ç", "c");
            valor = valor.Replace("Ç", "c");
            // E
            valor = valor.Replace("ê", "e");
            valor = valor.Replace("Ê", "E");

            valor = valor.Replace("è", "e");
            valor = valor.Replace("È", "E");

            valor = valor.Replace("é", "e");
            valor = valor.Replace("É", "E");

            valor = valor.Replace("ë", "E");
            valor = valor.Replace("Ë", "E");

            // I
            valor = valor.Replace("î", "i");
            valor = valor.Replace("Î", "I");

            valor = valor.Replace("ì", "i");
            valor = valor.Replace("Ì", "I");

            valor = valor.Replace("í", "i");
            valor = valor.Replace("Í", "I");

            valor = valor.Replace("ï", "i");
            valor = valor.Replace("Ï", "I");

            valor = valor.Replace("õ", "o");
            valor = valor.Replace("Õ", "O");

            valor = valor.Replace("ô", "o");
            valor = valor.Replace("Ô", "O");

            valor = valor.Replace("ó", "o");
            valor = valor.Replace("Ó", "O");

            valor = valor.Replace("ó", "o");
            valor = valor.Replace("Ó", "O");

            valor = valor.Replace("ò", "o");
            valor = valor.Replace("Ò", "O");

            valor = valor.Replace("ö", "o");
            valor = valor.Replace("Ö", "O");

            valor = valor.Replace("û", "u");
            valor = valor.Replace("Û", "U");

            valor = valor.Replace("ú", "u");
            valor = valor.Replace("Ú", "U");

            valor = valor.Replace("ù", "u");
            valor = valor.Replace("Ù", "u");

            valor = valor.Replace("ü", "u");
            valor = valor.Replace("Ü", "U");

            return valor;
        }

        public static Char ValidaChar(char valor)
        {
            if ((valor) >= 97 && (valor) <= 122)
            {
                return (char) (valor - 32);
            }
            if ((valor < 48 || valor > 122))
            {
                if (valor != 27 && valor != 32 && valor != 45
                    && valor != 46 && valor != 8 && valor != 9
                    && valor != 44 && valor != 13)
                {
                    return (char) 0;
                }
            }
            if (valor >= 58 && valor <= 63)
            {
                return (char) 0;
            }

            return valor;
        }
    }
}