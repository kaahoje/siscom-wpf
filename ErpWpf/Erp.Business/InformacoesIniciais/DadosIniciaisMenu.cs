using System.Collections.Generic;
using Erp.Business.Entity.Sistema.Menu;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisMenu
    {
        public static void Iniciar(ISession session)
        {
            var list = GetMenusList();
            foreach (var sistemaMenu in list)
            {
                SistemaMenuRepository.Save(sistemaMenu);
            }
        }

        public static IList<SistemaMenu> GetMenusList()
        {
            var menus = new List<SistemaMenu>();

            #region Cadastros

            var cadastros = new SistemaMenu()
            {
                Descricao = "Cadastros",
                Nome = "Cadastros"
            };
            menus.Add(cadastros);

            var cadParceiroNegocioPessoaFisica = new SistemaMenu()
            {
                Descricao = "Parceiro pessoa física",
                Nome = "cadParceiroNegocioPessoaFisica",
                Url = "/ParceiroNegocioPessoaFisica",
                MenuMaster = cadastros
            };
            menus.Add(cadParceiroNegocioPessoaFisica);
            var cadParceiroNegocioPessoaJuridica = new SistemaMenu()
            {
                Descricao = "Parceiro pessoa jurídica",
                Nome = "cadParceiroNegocioPessoaJuridica",
                Url = "/ParceiroNegocioPessoaJuridica",
                MenuMaster = cadastros
            };
            menus.Add(cadParceiroNegocioPessoaJuridica);

            #endregion


            #region Estoque

            var estoque = new SistemaMenu()
            {
                Descricao = "Estoque",
                Nome = "Estoque"
            };
            menus.Add(estoque);
            var produto = new SistemaMenu()
            {
                Descricao = "Produto",
                Nome = "cadProduto",
                Url = "/produto",
                MenuMaster = estoque
            };
            menus.Add(produto);

            var grupoProduto = new SistemaMenu()
            {
                Descricao = "Grupo de produto",
                Nome = "cadGrupoProduto",
                Url = "/grupo_produto",
                MenuMaster = estoque
            };
            menus.Add(grupoProduto);

            var sugGrupoProduto = new SistemaMenu()
            {
                Descricao = "Subgrupo de produto",
                Nome = "cadSubgrupoProduto",
                Url = "/subgrupo_produto",
                MenuMaster = estoque
            };
            menus.Add(sugGrupoProduto);

            #endregion

            var fiscal = new SistemaMenu()
                        {
                            Descricao = "Fiscal",
                            Nome = "Fiscal"
                        };
            menus.Add(fiscal);

            var vendas = new SistemaMenu()
                        {
                            Descricao = "Vendas",
                            Nome = "Vendas"
                        };
            menus.Add(vendas);

            #region Vendas

            var cadFormaPagamento = new SistemaMenu()
            {
                Descricao = "Forma de pagamento",
                Nome = "cadFormaPagamento",
                Url = "/forma_pagamento",
                MenuMaster = vendas
            };
            menus.Add(cadFormaPagamento);

            var cadCondicaoPagamento = new SistemaMenu()
            {
                Descricao = "Condição de pagamento",
                Nome = "cadCondicaoPagamento",
                Url = "/condicao_pagamento",
                MenuMaster = vendas
            };
            menus.Add(cadCondicaoPagamento);

            #endregion



            return menus;
        }

    }
}