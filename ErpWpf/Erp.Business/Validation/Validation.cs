using System;
using System.Text.RegularExpressions;

namespace Erp.Business.Validation
{
    public class Validation
    {
        public static string RemoveWhiteSpaces(string texto)
        {
            if (texto == null)
            {
                return null;
            }

            texto = Regex.Replace(texto, @"\s+", "");

            return texto;
        }


        public static string GetOnlyWords(string input)
        {
            if (input == null)
            {
                return null;
            }

            // remove espaços duplos
            var regexDoubleSpace = new Regex(@"[ ]{2,}", RegexOptions.None);
            input = regexDoubleSpace.Replace(input, @" ");

            // remove caracteres
            var regexCharacteres = new Regex("(?:[^\\w\\d ]|(?<=['\"])s)",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regexCharacteres.Replace(input, String.Empty);
        }

        public static string GetOnlyNumber(string input)
        {
            if (input == null)
            {
                return null;
            }

            // remove caracteres
            var regexCharacteres = new Regex("(?:[^\\d]|(?<=['\"])s)",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regexCharacteres.Replace(input, String.Empty);
        }

        public static string GetOnlyLetters(string input, bool acceptSpace = false)
        {
            if (input == null)
            {
                return null;
            }

            var space = string.Empty;

            if (acceptSpace)
            {
                space = " ";
            }

            // remove espaços duplos
            var regexDoubleSpace = new Regex(@"[ ]{2,}", RegexOptions.None);
            input = regexDoubleSpace.Replace(input, @" ");

            // remove caracteres
            var regexCharacteres = new Regex("(?:[^\\w" + space + "]|(?<=['\"])s|([\\d]))",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regexCharacteres.Replace(input, String.Empty);
        }

        public static bool IsCPFValid(string cpf)
        {
            if (cpf == null)
            {
                return false;
            }

            var valor = GetOnlyNumber(cpf);

            if (valor == "00000000000" || valor == "11111111111" || valor == "12345678909")
            {
                return false;
            }


            if (valor.Length != 11)
            {
                return false;
            }

            var igual = true;


            for (var i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0])
                {
                    igual = false;
                }
            }

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }

            var soma = 0;

            for (var i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }

            soma = 0;

            for (var i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }
            else if (numeros[10] != 11 - resultado)
            {
                return false;
            }

            return true;

        }

        public static bool IsCNPJValid(string cnpj)
        {
            if (cnpj == null)
            {
                return false;
            }

            var multiplicador1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = GetOnlyNumber(cnpj);

            if (cnpj == "00000000000000")
            {
                return false;
            }

            if (cnpj.Length != 14)
            {
                return false;
            }

            var tempCnpj = cnpj.Substring(0, 12);

            var soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            var resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            var digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto;

            return cnpj.EndsWith(digito);
        }

        public static bool IsEmailValid(string email)
        {
            if (email == null)
            {
                return false;
            }

            var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");

            return regex.IsMatch(email);

        }
    }
}
