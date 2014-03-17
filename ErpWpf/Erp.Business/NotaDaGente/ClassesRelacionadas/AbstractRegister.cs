using System;
using System.Globalization;

namespace Erp.Business.NotaDaGente.ClassesRelacionadas
{
    public abstract class AbstractRegister<T>
    {
        public const int LimiteCaracteresEmCampo = 60;
        public const int CasasDecimaisPadrao = 2;
        protected string Registro { get; set; }
        public abstract String Gerar(T objeto);

        protected void CrLf()
        {
            Registro += Environment.NewLine;
        }

        protected void AddCampo(String conteudo)
        {
            if (Registro == null)
            {
                Registro = "";
            }
            if (!Registro.Equals(""))
            {
                Registro += "|";
            }
            Registro += conteudo;
        }

        protected void AddCampo(DateTime conteudo)
        {
            if (!Registro.Equals(""))
            {
                Registro += "|";
            }
            Registro += FormataData(conteudo);
        }

        protected void AddCampo(decimal conteudo)
        {
            if (!Registro.Equals(""))
            {
                Registro += "|";
            }
            Registro += FormataNumero(conteudo, CasasDecimaisPadrao);
        }

        protected void AddCampo(int conteudo)
        {
            if (!Registro.Equals(""))
            {
                Registro += "|";
            }
            Registro += conteudo;
        }

        public string FormataData(DateTime data)
        {
            return data.ToString("dd/MM/yyyy");
        }

        public string FormataNumero(Decimal numero, int casasDecimais)
        {
            string[] split = numero.ToString(CultureInfo.InvariantCulture).Replace(".", ",").Split(',');
            string zeros = "0000000000000000000000000";
            if (split.Length == 1)
            {
                return split[0] + "," + zeros.Substring(0, casasDecimais);
            }
            split[1] = split[1] + zeros;
            return split[0] + "," + split[1].Substring(0, casasDecimais);
        }

        public string FormataTexto(string texto)
        {
            return texto.Substring(0, LimiteCaracteresEmCampo);
        }
    }
}