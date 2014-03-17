using System.IO;
using Util.Seguranca;

namespace Erp.Business.Entity.GestaoDeArquivos
{
    public class ArquivoDigitalRepository : RepositoryBase<ArquivoDigital>
    {
        public static void ImportarArquivo(string arquivo, string historico, TipoArquivoDigital tipo)
        {
            var stream = new FileStream(arquivo, FileMode.Open);
            var read = new BinaryReader(stream);
            byte[] buf = read.ReadBytes((int)new FileInfo(arquivo).Length);

            var arquivoDigital = new ArquivoDigital
            {
                Md5 = new Criptografia.CriptHash(Criptografia.HashProvider.MD5).
                    GetHash(stream),
                Historico = historico,
                Arquivo = buf,
                Tipo = tipo
            };
            Save(arquivoDigital);

        }
    }
}