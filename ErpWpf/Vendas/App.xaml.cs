using System.Diagnostics;
using System.Windows;
using Ecf;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Util;
using Vendas.Enums;
using Vendas.Properties;

namespace Vendas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static PessoaFisica Usuario { get; set; }
        public static PessoaJuridica Proprietaria { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var processName = Process.GetCurrentProcess().ProcessName;
            if (processName.Equals(Process.GetProcessesByName(processName)))
            {
                CustomMessageBox.MensagemCritica("Já existe uma instancia do aplicativo rodando.\n\nA aplicação será encerrada.");
                Process.GetCurrentProcess().Kill();
            }
            EcfHelper.FabricanteEcf = Settings.Default.FabricanteEcf;
            Usuario = PessoaFisicaRepository.GetByLogin("admin");
            Proprietaria = PessoaJuridicaRepository.GetById(Settings.Default.IdEmpresa);
            switch (Settings.Default.TipoPdv)
            {
                case TipoPdv.Mercearia:
                    break;
                case TipoPdv.Restaurante:
                    new RestauranteWindow().Show();
                    break;
            }
            
        }
    }
}
