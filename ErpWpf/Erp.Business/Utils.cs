﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Erp.Business
{
    public class Utils
    {




        //public static ConfTerminal Terminal
        //{
        //    get
        //    {
        //        if (_Terminal == null)
        //        {
        //            _Terminal = ConfTerminalRepository.GetByChave(ObterChave());
        //            if (_Terminal == null)
        //            {
        //                throw new Exception("Terminal não cadastrado!");

        //            }
        //            if (_Terminal != null && !_Terminal.Ativo)
        //            {
        //                throw new Exception("Terminal não autorizado!");

        //            }
        //        }
        //        return _Terminal;
        //    }
        //    set { _Terminal = value; }
        //}



        //public static bool SolicitaBackup()
        //{
        //    return Settings.Default.FazBackup;
        //}

        public static void BackupBaseDados()
        {
            //string pgDump = Settings.Default.CaminhoPgDump;
            //string u = Settings.Default.User;
            //string w = Settings.Default.Password;
            //int p = Settings.Default.Port;
            //string h = Settings.Default.Server;
            //string dir = Settings.Default.BackupDir;
            //string db = Settings.Default.Database;


            //string cmd = " -i -U " + u + // Usuário
            //             " -h " + h + // Host
            //             " -p " + p + // Port 
            //             " -F c " + // Format
            //             " -f " + dir + "\\backup" + DateTime.Now.Ticks + ".backup " + // File
            //             db; // Banco de dados

            //// Cria o novo processo.
            //var info = new ProcessStartInfo();
            //info.FileName = pgDump + "\\pg_dump.exe";

            //// Seta a variável de ambiente no Shell
            //Environment.SetEnvironmentVariable("PGPASSWORD", w);

            //info.Arguments = cmd;
            //info.CreateNoWindow = true;
            //info.UseShellExecute = false;
            //info.ErrorDialog = true;

            //// Cria o processo.
            //var proc = new Process();


            //proc.StartInfo = info;
            //proc.Start();
            //proc.ErrorDataReceived += proc_ErrorDataReceived;
            //proc.OutputDataReceived += proc_OutputDataReceived;
            //proc.Exited += proc_Exited;
            //proc.WaitForExit();
        }

        private static void proc_Exited(object sender, EventArgs e)
        {
        }

        private static void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new Exception(e.Data);
        }

        private static void proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new Exception(e.Data);
        }

        private static string ObterChave()
        {
            return ConfigurationManager.AppSettings["IdAplicacao"];
        }

        //public static void ResetIdAplicacao()
        //{
        //    Settings.Default.IdAplicacao = "";
        //    Settings.Default.Save();
        //}

        public static void SetChaveTerminal(string chave)
        {
            //if (Settings.Default.IdAplicacao != "")
            //{
            //    throw new Exception("Tentativa de alterar o identificador do termnal " +
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
                return (char)(valor - 32);
            }
            if ((valor < 48 || valor > 122))
            {
                if (valor != 27 && valor != 32 && valor != 45
                    && valor != 46 && valor != 8 && valor != 9
                    && valor != 44 && valor != 13)
                {
                    return (char)0;
                }
            }
            if (valor >= 58 && valor <= 63)
            {
                return (char)0;
            }

            return valor;
        }

        public static void GerarLog(Exception ex)
        {
            try
            {
                var message = GetStackTrace(ex);
                var path = Environment.CurrentDirectory + "\\log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "\\log" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";

                GravarArquivo(path, message);
            }
            catch (Exception)
            {
                
            }
            
        }
        public static void GerarLogDataBase(Exception ex)
        {
            try
            {
                var message = GetStackTrace(ex);

                var path = Environment.CurrentDirectory + "\\DbLog";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "\\log" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt";

                GravarArquivo(path, message);

            }
            catch (Exception)
            {

            }
        }

        public static string GetStackTrace(Exception ex)
        {
            var e = ex;
            var trace = ex.StackTrace;

            var message ="";

            while (e != null)
            {
                message += "Excepton:" + e.Message + Environment.NewLine;
                e = e.InnerException;
            }

            return message + trace;
        }

        public static void GerarLogFiscal(Exception ex)
        {
            try
            {
                var message = GetStackTrace(ex);

                var path = Environment.CurrentDirectory + "\\EcfLog";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "\\log" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".txt";

                GravarArquivo(path, message);

            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Calcula quantos por cento equivale a parte do todo.
        /// </summary>
        /// <param name="todo">Valor total</param>
        /// <param name="parte">Parte da qual se quer saber a quantos por cento equivale do todo</param>
        /// <returns></returns>
        public static decimal GetPercentual(decimal todo, decimal parte)
        {
            return (parte*100)/todo;
        }
        /// <summary>
        /// Obtém o valor monetário do todo em relação ao valor percentual.
        /// </summary>
        /// <param name="percentual">Percentual do valor a ser calculado.</param>
        /// <param name="todo">Valor base para o cálculo.</param>
        /// <returns></returns>
        public static decimal GetValorDoPercentual(decimal percentual, decimal todo)
        {
            return (todo/100)*percentual;
        }

        /// <summary>
        /// Método que calcula a proporção segundo a equação => extremoPrimeiroTermo : meioPrimeiroTermo = meioSegundoTermo : x.
        /// Onde x é o resultado da equação segundo os valores fornecidos.
        /// </summary>
        /// <param name="extremoPrimeiroTermo">Extremo do primeiro termo</param>
        /// <param name="meioPrimeiroTermo">Meio do primeiro termo</param>
        /// <param name="meioSegundoTermo">Meio do segundo termo</param>
        /// <returns></returns>
        public static decimal CalculaProporcao(decimal extremoPrimeiroTermo, decimal meioPrimeiroTermo, decimal meioSegundoTermo)
        {
            
            return (meioPrimeiroTermo*meioSegundoTermo)/extremoPrimeiroTermo;
        }
    }
}