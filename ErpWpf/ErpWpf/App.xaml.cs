using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Sped;
using System.Collections.ObjectModel;
using Erp.Properties;
using Erp.Suporte;
using Erp.View.Forms;
using Util;


namespace Erp
{
    public delegate void ValidateLicense();
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PessoaFisica Usuario { get; set; }
        public static ObservableCollection<Ncm> Ncms { get; set; }
        public static ObservableCollection<Cst> Csts { get; set; }
        public static ObservableCollection<CstPis> CstPis { get; set; }
        public static ObservableCollection<CstCofins> CstCofins { get; set; }
        public static ObservableCollection<CstIpi> CstIpi { get; set; }

        public App()
        {
            
            
        }

       

        public static Splash splashScreen;

        private ManualResetEvent ResetSplashCreated;
        private Thread SplashThread;

        
        protected override void OnStartup(StartupEventArgs e)
        {

            //ResetSplashCreated = new ManualResetEvent(false);

            //// Create a new thread for the splash screen to run on
            //SplashThread = new Thread(ShowSplash);
            //SplashThread.SetApartmentState(ApartmentState.STA);
            //SplashThread.IsBackground = true;
            //SplashThread.Name = "Splash Screen";
            //SplashThread.Start();

            //// Wait for the blocker to be signaled before continuing. This is essentially the same as: while(ResetSplashCreated.NotSet) {}
            //ResetSplashCreated.WaitOne();
            //if (Settings.Default.Lix == null)
            //{
            //    new RequisicaoLicencaView().ShowDialog();
            //    if (Settings.Default.Lix == null)
            //    {
            //        Process.GetCurrentProcess().Kill();
            //    }
            Settings.Default.Lix = new LicencaConcedida(); // Apagar após o fim dos testes do serviço

            if (!Services.SuporteClient.LicenceActivated(Settings.Default.Lix.Codigo))
            {
                Services.SuporteClient.Log("Cliente:" + Settings.Default.Lix.Documento
                    + "\nErro ao carregar aplicação.\n Código do erro: x0:001\n");
            }
            //}
            //else
            //{
            
            //}
            var initType = Settings.Default.InitDbType;
            DataBaseManager.CnnStr = Settings.Default.ConnectionString;
            if (!string.IsNullOrEmpty(initType))
            {
                switch (initType)
                {
                    case "init":
                        DataBaseManager.InitDb();
                        break;
                    case "update":
                        DataBaseManager.UpdateDb();
                        break;
                }
            }
            
            base.OnStartup(e);
            //SplashThread.Interrupt();
        }

       

        //private void ShowSplash()
        //{
        //    // Create the window
        //    Splash animatedSplashScreenWindow = new Splash();
        //    splashScreen = animatedSplashScreenWindow;

        //    // Show it
        //    animatedSplashScreenWindow.Show();

        //    // Now that the window is created, allow the rest of the startup to run
        //    ResetSplashCreated.Set();
        //    System.Windows.Threading.Dispatcher.Run();
        //}

    }
}
