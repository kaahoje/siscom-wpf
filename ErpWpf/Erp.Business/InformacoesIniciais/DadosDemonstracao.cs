using System;
using System.Globalization;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosDemonstracao
    {
        public static void GravarDadosDemonstracao(ISession session)
        {
            Unidade u = DadosIniciaiEstoque.UnidadesMedida[0];
            var g = new GrupoProduto();
            var sG = new SubGrupoProduto();


            // Grava um grupo para testes.
            g.Descricao = "Grupo teste";
            session.Save(g);

            // Grava um subgrupo para testes.
            sG.Descricao = "Subgrupo teste";
            sG.Grupo = g;
            session.Save(sG);
            GravarProdutos(session, u, sG);
            CriaUsuarios(session);
        }

        private static void CriaUsuarios(ISession session)
        {
            //foreach (Perfil perfil in DadosIniciaisPerfil.ListPerfil)
            //{
            //    var usuario = new Usuario
            //    {
            //        Nome = perfil.Nome.ToLower().Substring(0,3),
            //        Login = perfil.Nome.ToLower().Substring(0, 3),
            //        Senha = new Criptografia.CriptHash().GetHash("1"),
            //        TipoUsuario = TipoUsuario.Administrador,
            //        UsaLocadora = true,
            //        UsaRetaguarda = true,
            //        UsaVendaMercearia = true,
            //        UsaVendaRestaurante = true
            //    };
            //    foreach (PermissaoForm permissaoForm in perfil.PermissoesFormulario)
            //    {
            //        var permissao = new PermissaoForm
            //        {
            //            Formulario = permissaoForm.Formulario,
            //            PermissaoAcesso = permissaoForm.PermissaoAcesso,
            //            PermissaoDelete = permissaoForm.PermissaoDelete,
            //            PermissaoInsert = permissaoForm.PermissaoInsert,
            //            PermissaoSelect = permissaoForm.PermissaoSelect,
            //            PermissaoUpdate = permissaoForm.PermissaoUpdate
            //        };
            //        usuario.PermissoesFormulario.Add(permissao);
            //    }
            //    foreach (PermissaoRelatorio permissaoRelatorio in perfil.PermissoesRelatorio)
            //    {
            //        var permissao = new PermissaoRelatorio
            //        {
            //            Relatorio = permissaoRelatorio.Relatorio,
            //            Habilitado = permissaoRelatorio.Habilitado
            //        };
            //        usuario.PermissoesRelatorio.Add(permissao);
            //    }
            //    session.Save(usuario);
            //}
        }

        private static void GravarProdutos(ISession session, Unidade unidade, SubGrupoProduto sG)
        {
            Ncm ncm = NcmRepository.GetById(2);
            for (int i = 0; i < 100; i++)
            {
                var p = new Produto
                {
                    TemReceita = false,
                    Descricao = "Produto " + i,
                    CodBarra = i.ToString(CultureInfo.InvariantCulture),
                    Referencia = i.ToString(CultureInfo.InvariantCulture),
                    PrecoVenda = new Random(1000).Next(10, 100),
                    UnidadeCompra = unidade,
                    UnidadeVenda = unidade,
                    SubGrupo = sG,
                    Ncm = ncm
                };
                session.Save(p);
            }
        }
    }
}