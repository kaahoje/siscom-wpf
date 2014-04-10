using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using Erp.Business;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
using Erp.Model;
using Erp.View.Forms;
using NHibernate;

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
                Utils.GerarLog(ex);
                ModelBase.MensagemErroBancoDados("Erro ao carregar aplicação.\n\n" + ex.Message +
                    "\n\nA aplicação será encerrada para evitar danos ao banco de dados.");
                Process.GetCurrentProcess().Kill();
            }
            Model = new RetaguardaModel();
            Model.TelaAberta += model_TelaAberta;
            DataContext = Model;
            //NHibernateHttpModule.Session.FlushMode = FlushMode.Commit;
            //foreach (var produto in ProdutoRepository.GetList())
            //{
            //    if (produto.Tributacao == null)
            //    {
            //        produto.Tributacao = new Tributacao();
            //    }
            //    if (produto.Ncm.Codigo.Contains("1902200"))
            //    {
            //        produto.Tributacao.TipoTributacaoIcms = SituacaoTributaria.Tributado;
            //        produto.Tributacao.IcmsDevedor = 2.75M;
            //    }
            //    ProdutoRepository.Save(produto);
            //}

            //var pessoa = PessoaFisicaRepository.GetByLogin("admin");
            //if (pessoa != null)
            //{
            //    var forms = new FormularioDictionary();
            //    foreach (var form in forms.Values)
            //    {
            //        pessoa.PermissaoFormulario.Add(new PermissaoFormularioPessoaFisica()
            //        {
            //            Formulario = form.Value,
            //            Edita = false,
            //            Exclui = false,
            //            Insere = false,
            //            Pesquisa = true
            //        });
            //    }
            //    PessoaFisicaRepository.Save(pessoa);
            //}
            //try
            //{
            //    var empresa = new PessoaJuridica()
            //    {
            //        Cnpj = "13049042000169",
            //        RazaoSocial = "BONE PIZZA FRIOS BEBIDAS LTDA ME",
            //        NomeFantasia = "BONE PIZZA FILIAL ESTANCIA",
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
            //                Endereco = EnderecoRepository.GetByCep("492000000"),
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
            //App.splashScreen.CloseSplashScreen();
            if (App.Usuario == null)
            {
                new LoginFormView().ShowDialog();
            }
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
