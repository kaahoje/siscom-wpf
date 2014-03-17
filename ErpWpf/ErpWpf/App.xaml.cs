using System.Windows;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Sped;
using System.Collections.ObjectModel;


namespace Erp
{
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
            Ncms = new ObservableCollection<Ncm>(NcmRepository.GetList());
            Csts = new ObservableCollection<Cst>(CstRepository.GetList());
            CstPis = new ObservableCollection<CstPis>(CstPisRepository.GetList());
            CstCofins = new ObservableCollection<CstCofins>(CstCofinsRepository.GetList());
            CstIpi = new ObservableCollection<CstIpi>(CstIpiRepository.GetList());

        }
    }
}
