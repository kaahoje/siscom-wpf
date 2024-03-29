﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Util
{
    public class Text
    {
        public static string GetCapitalize(string texto)
        {
            if (texto == null)
            {
                return null;
            }

            texto = texto.ToLower();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            var novoTexto = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(texto);

            return novoTexto;
        }

        /// <summary>
        /// Método estático para cortar string
        /// </summary>
        /// <param name="ellipsis">Inserir reticências no final do texto?</param>
        /// <param name="length">Total de caracteres para retornar</param>
        /// <param name="text">Texto a ser cortado</param>
        /// <returns>Texto reduzido</returns>
        public static string CortarString(bool ellipsis, int length, string text)
        {
            // Valida caracteres
            if (text.Length < length || length == 0) return text;

            // Verifica espaços
            var trimmed = text.Substring(0, ellipsis ? length - 1 : length);

            var i = trimmed.LastIndexOf(' ');
            if (i != -1)
                trimmed = trimmed.Substring(0, i);

            // Retorna texto
            return ellipsis ? string.Concat(trimmed, "...") : trimmed;
        }

        public static string RemoveTagHtml(string inputString)
        {
            if (inputString != null)
            {
                var rx = new Regex("<[^>]*>");
                return rx.Replace(inputString, "");
            }

            return string.Empty;
        }


        public static string NumberForLiteral(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valorPorExtenso = string.Empty;

                for (int i = 0; i <= 15; i += 3)
                {
                    valorPorExtenso += escreva_parte(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valorPorExtenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valorPorExtenso += " TRILHÃO" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valorPorExtenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valorPorExtenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valorPorExtenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valorPorExtenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valorPorExtenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valorPorExtenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valorPorExtenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valorPorExtenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valorPorExtenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);

                    if (i == 12)
                    {
                        if (valorPorExtenso.Length > 8)
                            if (valorPorExtenso.Substring(valorPorExtenso.Length - 6, 6) == "BILHÃO" | valorPorExtenso.Substring(valorPorExtenso.Length - 6, 6) == "MILHÃO")
                                valorPorExtenso += " DE";
                            else
                                if (valorPorExtenso.Substring(valorPorExtenso.Length - 7, 7) == "BILHÕES" | valorPorExtenso.Substring(valorPorExtenso.Length - 7, 7) == "MILHÕES" | valorPorExtenso.Substring(valorPorExtenso.Length - 8, 7) == "TRILHÕES")
                                    valorPorExtenso += " DE";
                                else
                                    if (valorPorExtenso.Substring(valorPorExtenso.Length - 8, 8) == "TRILHÕES")
                                        valorPorExtenso += " DE";

                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valorPorExtenso != string.Empty)
                            valorPorExtenso += " E ";
                    }


                }
                return valorPorExtenso;
            }
        }

        static string escreva_parte(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }

    }
}
