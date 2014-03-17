using System;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Entity.Fiscal.ClassesRelacionadas;

namespace Erp.Business.NotaDaGente.ClassesRelacionadas
{
    public sealed class NotaDaGenteNotaFiscal : AbstractRegister<NotaFiscal>, IDisposable
    {
        public decimal ValorNota { get; set; }
        public decimal TotalProduto { get; set; }
        public decimal Desconto { get; set; }
        public decimal Frete { get; set; }
        public decimal Seguro { get; set; }
        public decimal OutrosAcressimos { get; set; }

        public void Dispose()
        {
            Registro = "";
        }

        public override string Gerar(NotaFiscal objeto)
        {
            AddCampo("20");
            AddCampo("1"); // Modelo D
            AddCampo("1"); // Sub série 1
            AddCampo(objeto.Numero);
            AddCampo(objeto.DataEmissao);
            AddCampo(objeto.DataEmissao); // Emissão é igual a saída.
            AddCampo(""); // Cnpj
            AddCampo(""); // Nome
            AddCampo(""); // Logradouro
            AddCampo(""); // Número
            AddCampo(""); // Complemento
            AddCampo(""); // Bairro
            AddCampo(""); // Cidade
            AddCampo(""); // UF
            AddCampo(""); // Cep
            AddCampo(""); // Telefone do cliente.
            // Chama o cálculo da nota fiscal.
            CalcularNota(objeto);
            AddCampo(TotalProduto);
            AddCampo(Desconto);
            AddCampo(Frete);
            AddCampo(Seguro);
            AddCampo(OutrosAcressimos);
            AddCampo("");
            AddCampo(ValorNota);
            AddCampo("");
            AddCampo("");
            AddCampo("2"); // Em registro de D1 não á informações de entrega.
            AddCampo("");
            AddCampo("");
            AddCampo("");
            AddCampo("");
            AddCampo("");
            AddCampo("");
            AddCampo(ValorNota);
            CrLf();
            foreach (ProdutoNotaFiscal prod in objeto.Produtos)
            {
                using (var pNf = new NotaDaGenteProdutoNotaFiscal())
                {
                    Registro += pNf.Gerar(prod);
                }
            }
            return Registro;
        }

        private void CalcularNota(NotaFiscal objeto)
        {
            ValorNota = 0;
            TotalProduto = 0;
            Desconto = objeto.Desconto;
            Frete = objeto.Frete;
            Seguro = objeto.Seguro;
            OutrosAcressimos = objeto.OutrasDespesasAcessorias;

            foreach (ProdutoNotaFiscal prod in objeto.Produtos)
            {
                TotalProduto += prod.ValorUnitario*prod.Quantidade;
            }
            ValorNota += TotalProduto - Desconto + Frete + Seguro + OutrosAcressimos;
        }
    }
}