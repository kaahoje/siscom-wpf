using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Docking.Base;
using DevExpress.Xpf.Layout.Core;
using Erp.Business;
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

        
    }
}
