using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Fiscal;
using Erp.Business.NotaDaGente.ClassesRelacionadas;

namespace Erp.Business.NotaDaGente
{
    public class NotaDaGente : AbstractRegister<IList<NotaFiscal>>, IDisposable
    {
        public virtual string Cnpj { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int Notas { get; set; }
        public int Produtos { get; set; }
        public decimal TotalNotas { get; set; }
        public string Resultado { get; set; }
        public PessoaJuridica Empresa { get; set; }
        public void Dispose()
        {
        }

        public override string Gerar(IList<NotaFiscal> objeto)
        {
            try
            {
                if (Empresa == null)
                {
                    throw new Exception("Informe a empresa que está gerando o arquivo.");
                    
                }
                // Cria o registro de cabecalho.
                AddCampo("10");
                AddCampo("1.00");
                AddCampo(Empresa.Cnpj);
                AddCampo(Inicio);
                AddCampo(Fim);
                CrLf();
                // Inicia a propriedade resultado com o registro de cabecalho.
                Resultado = Registro;
                // Conta a quantidade de notas que é a quantidade de registros 20
                Notas = objeto.Count;
                // Cria os registros de todas as notas. Incluindo os registros filho.
                foreach (NotaFiscal notaFiscal in objeto)
                {
                    using (var nf = new NotaDaGenteNotaFiscal())
                    {
                        Resultado += nf.Gerar(notaFiscal);
                        TotalNotas += nf.ValorNota;
                        Produtos += notaFiscal.Produtos.Count;
                    }
                }
                Registro = "";
                AddCampo("90");
                AddCampo(Notas);
                AddCampo(Produtos);
                AddCampo(TotalNotas);
                return Resultado + Registro;
            }
            catch (Exception ex)
            {
                throw  new Exception("Erro ao gerar arquivo de nota fiscal.\n" +
                                ex.Message);
            }
            
        }
    }
}