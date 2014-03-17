using System;
using Erp.Business.Entity.Fiscal.ClassesRelacionadas;
using Erp.Business.Entity.Sped;

namespace Erp.Business.NotaDaGente.ClassesRelacionadas
{
    public class NotaDaGenteProdutoNotaFiscal : AbstractRegister<ProdutoNotaFiscal>, IDisposable
    {
        public void Dispose()
        {
            Registro = null;
        }

        public override string Gerar(ProdutoNotaFiscal objeto)
        {
            
            Registro = "";
            AddCampo("21");
            AddCampo(objeto.Sequencia);
            AddCampo("");
            AddCampo((int) objeto.Produto.Tributacao.OperacaoNotaDaGente);
            AddCampo(objeto.Produto.Descricao);
            AddCampo(objeto.Produto.UnidadeVenda.Sigla);
            AddCampo(FormataNumero(objeto.Quantidade, 3));
            AddCampo(objeto.ValorUnitario);
            AddCampo(objeto.ValorUnitario*objeto.Quantidade);
            CrLf();
            return Registro;
        }
    }
}