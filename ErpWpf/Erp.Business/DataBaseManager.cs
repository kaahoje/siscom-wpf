﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Sistema.Menu;
using Erp.Business.InformacoesIniciais;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Ionic.Zip;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Erp.Business
{
    public class DataBaseManager
    {
        private static string _cnnStr = "";
        public static string CnnStr
        {
            get
            {
                if (string.IsNullOrEmpty(_cnnStr))
                {
                    string machine = Environment.MachineName;

                    switch (machine)
                    {
                        case "BONEDEV":

                            _cnnStr = ConfigurationManager.AppSettings["cnnAdailton"];
                            break;
                        case "JMW-JOAO-PC":

                            _cnnStr = ConfigurationManager.AppSettings["cnnJunior"];
                            break;
                        default:

                            _cnnStr = ConfigurationManager.AppSettings["cnnDeploy"];
                            break;
                    }
                    Utils.GerarLogDataBase(new Exception(_cnnStr));
                    if (String.IsNullOrEmpty(_cnnStr))
                    {
                        //CustomMessageBox.MensagemErro("Não foi possível determinar as informações de conexão com o banco de dados.");
                        _cnnStr = "Server=localhost; Port= 5432;User Id=postgres; Password=123; Database=siscom;";
                    }
                
                }
                return _cnnStr;
            }
            set { _cnnStr = value; }
        }


        public static void InitDb()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "arquivos\\";
                string dir = path.Substring(0, path.Length - 1);
                string fileOrigem = path + "dados.zip";
                string fileXml = path + "Xml_Endereco.xml";
                if (!File.Exists(fileXml))
                {
                    ZipFile zipFile = ZipFile.Read(fileOrigem);
                    zipFile.ExtractAll(dir);
                    zipFile.Dispose();
                }

                ISession s = Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(CnnStr))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TipoTitulo>())
                    .ExposeConfiguration(config => new SchemaExport(config).Create(true, true))
                    .BuildSessionFactory().OpenSession();
                DadosIniciais.Iniciar();
                DadosIniciais.IniciarEtapa2();
                DadosIniciais.IniciarEtapa3();

                //var pessoa = new PessoaFisica
                //{
                //    Nome = "Admin",
                //    Cpf = "67425049511",
                //    Login = "admin",
                //    Senha = Criptografia.CriptografarSenha("admin"),
                //    Enderecos = new List<PessoaEndereco>
                //    {
                //        new PessoaEndereco
                //        {
                //            Endereco = EnderecoRepository.GetByCep("49290000"),
                //            EnderecoTipo = Enum.EnderecoTipo.Comercial,
                //            Logradouro = "Itabaianinha"
                //        }
                //    }
                //};
                //PessoaFisicaRepository.Save(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar banco de dados.\n" + ex.Message);
            }
        }

        public static void UpdateDb()
        {
            try
            {
                Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(
                        CnnStr))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TipoTitulo>())
                    .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                    .BuildSessionFactory().OpenSession();
                var listaAtual = SistemaMenuRepository.GetList();
                var listaParaVerificar = DadosIniciaisMenu.GetMenusList();
                foreach (var verifique in listaParaVerificar)
                {
                    var item = listaAtual.FirstOrDefault(menu => menu.Nome.Equals(verifique.Nome));
                    SistemaMenu master = null;
                    if (verifique.MenuMaster != null)
                    {
                        master = listaAtual.FirstOrDefault(menu => menu.Nome == verifique.MenuMaster.Nome);
                    }

                    if (item == null)
                    {

                        SistemaMenuRepository.Save(verifique);
                    }
                    else
                    {
                        var menu = SistemaMenuRepository.GetById(item.Id);
                        menu.Nome = verifique.Nome;
                        menu.Habilitado = verifique.Habilitado;
                        menu.Descricao = verifique.Descricao;
                        menu.PathIcone = verifique.PathIcone;
                        menu.Url = verifique.Url;
                        menu.MenuMaster = master;
                        SistemaMenuRepository.Update(menu);
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar banco de dados.\n" + ex.Message);
            }
        }


        //private static void VerificaRelatorios()
        //{

        //    var relsEmPerfil = DadosIniciaisPerfil.ListRelatorios;
        //    var relsAtuais = RelatorioRepository.GetList();
        //    foreach (var relEmPerfil in relsEmPerfil.Values)
        //    {
        //        Relatorio rel = EncontraRel(relsAtuais, relEmPerfil.Nome);
        //        if (rel == null)
        //        {
        //            RelatorioRepository.Save(relEmPerfil);
        //        }
        //        else
        //        {
        //            rel.Nome = relEmPerfil.Nome;
        //            rel.Descricao = relEmPerfil.Descricao;
        //            rel.Nivel = relEmPerfil.Nivel;
        //            RelatorioRepository.Save(rel);
        //        }
        //    }
        //}

        //private static Relatorio EncontraRel(IEnumerable<Relatorio> relsAtuais, string nome)
        //{
        //    return relsAtuais.FirstOrDefault(relatorio => relatorio.Nome.Equals(nome));
        //}

        //private static void VerificaFormularios()
        //{
        //    var formsEmPerfil = DadosIniciaisPerfil.ListForms;
        //    var formsAtuais = FormularioRepository.GetList();

        //    foreach (var formEmPerfil in formsEmPerfil.Values)
        //    {
        //        Formulario form = EncontraForm(formsAtuais, formEmPerfil.Nome);
        //        if (form == null)
        //        {
        //            FormularioRepository.Save(formEmPerfil);
        //        }
        //        else
        //        {
        //            form.Nome = formEmPerfil.Nome;
        //            form.Descricao = formEmPerfil.Descricao;
        //            form.Url = formEmPerfil.Url;
        //            form.Ativa = formEmPerfil.Ativa;
        //            FormularioRepository.Save(form);
        //        }
        //    }
        //}

        //private static Formulario EncontraForm(IEnumerable<Formulario> formsAtuais, string nome)
        //{
        //    foreach (var formulario in formsAtuais)
        //    {
        //        if (formulario.Nome.Equals(nome))
        //        {
        //            return formulario;
        //        }
        //    }
        //    return null;
        //}

        //private static void VerificaPermissaoRelatorios()
        //{
        //    var rels = RelatorioRepository.GetList();
        //    // Verifica se há diferênça na lista de permissões de formulário.
        //    foreach (var rel in rels)
        //    {
        //        var perfis = PerfilRepository.GetList();

        //        foreach (var perfil in perfis)
        //        {
        //            PermissaoRelatorio perm = EncontraPermissaoRel(perfil, rel.Nome);
        //            if (perm == null)
        //            {
        //                var newPerm = new PermissaoRelatorio
        //                {
        //                    Habilitado = false,
        //                    Relatorio = rel
        //                };
        //                PermissaoRelatorioRepository.Save(newPerm);
        //            }
        //        }
        //    }
        //}

        //private static PermissaoRelatorio EncontraPermissaoRel(string nome)
        //{
        //    //foreach (var rel in perfil.PermissoesRelatorio)
        //    //{
        //    //    if (rel.Relatorio.Nome.Equals(nome))
        //    //    {
        //    //        return rel;
        //    //    }
        //    //}
        //    return null;
        //}

        //private static void VerificaPermissaoFormularios()
        //{
        //    var fs = FormularioRepository.GetList();
        //    // Verifica se há diferênça na lista de permissões de formulário.
        //    foreach (var form in fs)
        //    {
        //        var perfis = PerfilRepository.GetList();

        //        foreach (var perfil in perfis)
        //        {
        //            PermissaoForm perm = EncontraPermissaoForm(perfil, form.Nome);
        //            if (perm == null)
        //            {
        //                var newPerm = new PermissaoForm
        //                {
        //                    Formulario = form,
        //                    PermissaoAcesso = false,
        //                    PermissaoDelete = false,
        //                    PermissaoInsert = false,
        //                    PermissaoSelect = false,
        //                    PermissaoUpdate = false
        //                };
        //                PermissaoFormRepository.Save(newPerm);
        //            }
        //        }
        //    }
        //}

        //private static PermissaoForm EncontraPermissaoForm(Perfil perfil, string nome)
        //{
        //    foreach (var form in perfil.PermissoesFormulario)
        //    {
        //        if (form.Formulario.Nome.Equals(nome))
        //        {
        //            return form;
        //        }
        //    }
        //    return null;
        //}
    }
}