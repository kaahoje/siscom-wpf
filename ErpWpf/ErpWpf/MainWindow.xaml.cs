using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using Erp.Business;
using Erp.Business.Entity.Sped;
using Erp.Model;

namespace Erp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private RetaguardaModel Model { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            var initType = ConfigurationManager.AppSettings["initDbType"];
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
            try
            {
                App.Ncms = new ObservableCollection<Ncm>(NcmRepository.GetList());
                App.Csts = new ObservableCollection<Cst>(CstRepository.GetList());
                App.CstPis = new ObservableCollection<CstPis>(CstPisRepository.GetList());
                App.CstCofins = new ObservableCollection<CstCofins>(CstCofinsRepository.GetList());
                App.CstIpi = new ObservableCollection<CstIpi>(CstIpiRepository.GetList());
            }
            catch (Exception ex)
            {
                ModelBase.MensagemErroBancoDados("Erro ao carregar aplicação.\n\n" + ex.Message + 
                    "\n\nA aplicação será encerrada para evitar danos ao banco de dados.");
                Process.GetCurrentProcess().Kill();
            }
            Model = new RetaguardaModel();
            Model.TelaAberta += model_TelaAberta;
            DataContext = Model;
            
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        void model_TelaAberta(object sender, TelaAbertaEventArgs e)
        {
            

        }


        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
