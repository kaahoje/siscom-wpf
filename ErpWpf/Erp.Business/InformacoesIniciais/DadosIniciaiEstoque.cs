using System.Collections.Generic;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaiEstoque
    {
        public static IList<Unidade> UnidadesMedida { get; set; }

        public static void IniciarDados(ISession session)
        {
            IniciarUnidadesMedidas(session);
        }

        private static void IniciarUnidadesMedidas(ISession session)
        {
            UnidadesMedida = new List<Unidade>();
            UnidadesMedida.Add(new Unidade {Descricao = "Unidade", Sigla = "UN", Quantidade = 1});
            UnidadesMedida.Add(new Unidade {Descricao = "Caixa com 6", Sigla = "CX6", Quantidade = 6});
            UnidadesMedida.Add(new Unidade {Descricao = "Caixa com 12", Sigla = "CX12", Quantidade = 12});
            UnidadesMedida.Add(new Unidade {Descricao = "Caixa com 18", Sigla = "CX18", Quantidade = 18});
            UnidadesMedida.Add(new Unidade {Descricao = "Fardo com 6", Sigla = "FD6", Quantidade = 6});
            UnidadesMedida.Add(new Unidade {Descricao = "Fardo com 12", Sigla = "FD12", Quantidade = 12});
            UnidadesMedida.Add(new Unidade {Descricao = "Dúzia", Sigla = "DZ", Quantidade = 12});
            UnidadesMedida.Add(new Unidade {Descricao = "Quilograma", Sigla = "KG", Quantidade = 1});
            UnidadesMedida.Add(new Unidade {Descricao = "Tonelada", Sigla = "T", Quantidade = 1000});
            UnidadesMedida.Add(new Unidade {Descricao = "Quilate", Sigla = "", Quantidade = decimal.Parse("0,205")});
            UnidadesMedida.Add(new Unidade {Descricao = "Onça", Sigla = "OZ", Quantidade = decimal.Parse("28,352")});
            UnidadesMedida.Add(new Unidade {Descricao = "Libra", Sigla = "LB", Quantidade = 16*decimal.Parse("28,352")});
            UnidadesMedida.Add(new Unidade {Descricao = "Arroba", Sigla = "", Quantidade = decimal.Parse("14,687")});
            UnidadesMedida.Add(new Unidade {Descricao = "Metro", Sigla = "", Quantidade = 1});
            UnidadesMedida.Add(new Unidade {Descricao = "Quilômetro", Sigla = "KM", Quantidade = 1000});
            UnidadesMedida.Add(new Unidade {Descricao = "Polegada", Sigla = "", Quantidade = decimal.Parse("0,0254")});
            UnidadesMedida.Add(new Unidade {Descricao = "Pé", Sigla = "", Quantidade = decimal.Parse("0,3048")});
            UnidadesMedida.Add(new Unidade {Descricao = "Jarda", Sigla = "", Quantidade = decimal.Parse("0,914")});
            UnidadesMedida.Add(new Unidade {Descricao = "Milha", Sigla = "", Quantidade = 1609});
            UnidadesMedida.Add(new Unidade {Descricao = "Milha marítima", Sigla = "", Quantidade = 1853});
            UnidadesMedida.Add(new Unidade {Descricao = "Braça", Sigla = "", Quantidade = decimal.Parse("2,2")});
            UnidadesMedida.Add(new Unidade {Descricao = "Metro quadrado", Sigla = "", Quantidade = 1});

            foreach (Unidade unidade in UnidadesMedida)
            {
                session.Save(unidade);
            }
        }
    }
}