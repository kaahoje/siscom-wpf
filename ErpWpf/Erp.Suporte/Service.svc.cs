using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Erp.Business;
using Erp.Suporte.Business.Entity.Cliente;
using Erp.Suporte.Business.Entity.Cliente.PessoaFisica;
using Erp.Suporte.Business.Entity.Cliente.PessoaJuridica;
using Erp.Suporte.Business.Entity.Licenca;
using Erp.Suporte.Business.Entity.Log;
using Erp.Suporte.Business.Entity.Suporte;
using Erp.Suporte.Business.Enum;
using Util;
using FileInfo = Util.FileSystem.FileInfo;
using Validation = Erp.Business.Validation.Validation;

namespace Erp.Suporte
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public void Log(string stackTrace)
        {
            try
            {
                var log = new LogSistema()
                {
                    StackTrace = stackTrace,
                    Tipo = TipoLog.Sistema
                };
                LogSistemaRepository.Save(log);
            }
            catch (Exception ex)
            {
                LogService(ex);
            }
        }

        public void LogDataBase(string stackTrace)
        {
            try
            {
                var log = new LogSistema()
                {
                    StackTrace = stackTrace,
                    Tipo = TipoLog.BancoDados
                };
                LogSistemaRepository.Save(log);
            }
            catch (Exception ex)
            {
                LogService(ex);
            }
        }

        public void LogService(Exception ex)
        {
            try
            {
                var log = new LogSistema()
                {
                    StackTrace = Utils.GetStackTrace(ex),
                    Tipo = TipoLog.Servidor
                };
                LogSistemaRepository.Save(log);
            }
            catch (Exception exception)
            {
                var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\log\\";
                dir = dir.Replace("file:\\","");
                var file = dir + "Log " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                Utils.GravarArquivo(file, Utils.GetStackTrace(exception));
            }
        }
        public string RequestLicense(LicencaConcedida solicitacao)
        {
            try
            {
                ICliente cliente = null;
                if (Validation.IsCNPJValid(solicitacao.Documento))
                {
                    cliente = ClientePessoaFisicaRepository.GetByCpf(solicitacao.Documento);
                }
                else if (Validation.IsCPFValid(solicitacao.Documento))
                {
                    cliente = ClientePessoaJuridicaRepository.GetByCnpj(solicitacao.Documento);
                }
                else
                {
                    return "";
                }
                if (cliente == null)
                {
                    return "";
                }
                var licencaAtual = cliente.Licencas.SingleOrDefault(x => x.Codigo.Equals(solicitacao.GetCodigo()));
                if (licencaAtual != null)
                {
                    if (licencaAtual.Status == StatusLicenca.ReenviarCodigo)
                    {
                        return licencaAtual.Codigo;
                    }
                    return "";
                }
                return solicitacao.GetCodigo();
            }
            catch (Exception ex)
            {
                LogService(ex);
            }
            return "";
        }

        public bool LicenceActivated(string codigo)
        {
            try
            {
                var lic = LicencaConcedidaRepository.GetByCodigo(codigo);
                if (lic != null && lic.Status == StatusLicenca.Ativa)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogService(ex);
            }

            return false;
        }

        public StatusLicenca LicenseSituation(string codigo)
        {
            try
            {
                var lic = LicencaConcedidaRepository.GetByCodigo(codigo);
                if (lic == null)
                {
                    return StatusLicenca.Bloqueada;
                }
                return lic.Status;
            }
            catch (Exception ex)
            {
                LogService(ex);
            }
            return StatusLicenca.Bloqueada;
        }

        public Dictionary<string, FileStream> RequestUpdate(LicencaConcedida licenca, Dictionary<string, string> currentFileList)
        {
            var ret = new Dictionary<string, FileStream>();
            try
            {
                var dist = Environment.CurrentDirectory + "\\dist";
                var distFiles = new Dictionary<string, string>();

                distFiles = FileInfo.GetListFileInfo(dist, distFiles);
                foreach (var distFile in distFiles.Keys)
                {
                    var fileToUpdate = dist + distFile;

                    var currentFileVersion = "";
                    var distFileVersion = "";

                    distFiles.TryGetValue(distFile, out distFileVersion);
                    // Verifica se o arquivo existe no lado do cliente.
                    if (currentFileList.TryGetValue(distFile, out currentFileVersion))
                    {
                        // Verifica se a versão do arquivo do lado cliente é a mesma do lado servidor. Caso não seja
                        // adiciona à lista de download.
                        if (distFileVersion != null && !distFileVersion.Equals(currentFileVersion))
                        {
                            ret.Add(distFile, new FileStream(fileToUpdate, FileMode.Open));
                        }
                    }
                    else
                    {
                        // Se não existir o arquivo adicona à lista para download
                        ret.Add(distFile, new FileStream(fileToUpdate, FileMode.Open));

                    }
                }

            }
            catch (Exception ex)
            {
                LogService(ex);
            }
            return ret;
        }

        public SolicitacaoSuporte RequestSuport(LicencaConcedida licenca, SolicitacaoSuporte solicitacao)
        {
            try
            {
                if (LicenceActivated(licenca.Codigo))
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                LogService(ex);

            }

            return solicitacao;
        }


    }
}
