using System;
using System.Collections.Generic;

namespace Erp.Business.Seguranca
{
    public class SegurancaUtils
    {
        protected static IList<String> FormulariosSuperAdmin = new List<string>
        {
            "ConfigBusiness",
            "RecebeChave",
            "Funcoes",
            "ConfTerminal",
            "Usuario",
            "Empresa",
            "ConfGeral"
        };

        protected static IList<String> FormulariosLivres = new List<string>
        {
            "SolicitaDadosCliente",
            "Login",
            "EspelhoMDF"
        };

        protected static IList<String> FormulariosAdministrador = new List<string>
        {
            "GerarArquivoNotaDaGente"
        };

    }

    public enum TipoAcao
    {
        Select,
        Update,
        Delete,
        Insert
    }
}