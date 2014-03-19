using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
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
            //try
            //{
            //    var empresa = new PessoaJuridica()
            //    {
            //        Cnpj = "13049042000240",
            //        RazaoSocial = "BONE PIZZA FRIOS BEBIDAS LTDA ME",
            //        NomeFantasia = "BONE PIZZA FILIAL 1",
            //        DataAbertura = DateTime.Parse("01/01/2012"),
            //        InscricaoEstadual = "271371099",
            //        DataCadastro = DateTime.Now,
            //        ContatoTelefonicos = new PessoaTelefone[] { 
            //            new PessoaTelefone()
            //                {
            //                    DdiPais = "55",
            //                    DddTelefone = "79",
            //                    Numero = "35229059",
            //                    TelefoneTipo = TelefoneTipo.Comercial
            //                },  
            //             new PessoaTelefone()
            //                {
            //                    DdiPais = "55",
            //                    DddTelefone = "79",
            //                    Numero = "99193007",
            //                    TelefoneTipo = TelefoneTipo.Comercial
            //                }  
            //        },
            //        Enderecos = new PessoaEndereco[]
            //        {
            //            new PessoaEndereco()
            //            {
            //                Logradouro = "RUA PEDRO HOMEM DA COSTA",
            //                Numero = "292",
            //                Endereco = EnderecoRepository.GetByCep("492900000"),
            //                InformadoManualmente = true,
            //                TipoEndereco = TipoEndereco.Comercial
            //            }
            //        }
            //    };
            //    empresa.Enderecos[0].Pessoa = empresa;
            //    empresa.ContatoTelefonicos[0].Pessoa = empresa;
            //    empresa.ContatoTelefonicos[1].Pessoa = empresa;
            //    PessoaJuridicaRepository.Save(empresa);
            //    ModelBase.MensagemInformativa("Empresa cadastrada com sucesso. Identificador: " + empresa.Id);
            //}
            //catch (Exception ex)
            //{
            //    ModelBase.MensagemErroBancoDados(ex.Message);
            //}

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
