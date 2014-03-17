using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Util
{
    public class Functions
    {
        public static void ClearForm(Control controlP)
        {
            foreach (Control c in controlP.Controls)
            {
                var box = c as TextBox;
                if (box != null)
                {
                    box.Text = String.Empty;
                }
                else
                {
                    var list = c as DropDownList;
                    if (list != null)
                    {
                        list.SelectedIndex = 0;
                    }
                    else
                        if (c.Controls.Count > 0)
                        {
                            ClearForm(c);
                        }
                        else
                        {
                            var button = c as RadioButton;
                            if (button != null)
                            {
                                button.Checked = false;
                            }
                        }
                }
            }
        }

        public static string GetUrlMapped(string url)
        {
            return url.Split('/')[1];
        }

        public static TableRow CreateRowOneCell(Control control, bool alignCenter, int columnSpan)
        {
            var row = new TableRow { Width = 300 };
            var cell = new TableCell { Width = 300 };

            if (alignCenter)
            {
                row.HorizontalAlign = HorizontalAlign.Center;
                cell.HorizontalAlign = HorizontalAlign.Center;
            }

            cell.ColumnSpan = columnSpan;

            cell.Controls.Add(control);
            row.Cells.Add(cell);

            return row;
        }

        public static string RemoverAcentos(string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";

            var bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string RemoveEspacoEntreTexto(string input)
        {
            return input.Replace(" ", "");
        }

        /// <summary> 
        /// Método para Calculo da Pascoa,Corpus Christ e Carnaval By: Flinox 
        /// </summary> 
        /// <param name="ano"> </param>
        /// <returns>Array Data[]</returns> 
        public static DateTime[] CalculaFeriadosMoveis(int ano)
        {
            var data = new DateTime[3];
            int x, y;
            int dia, mes;


            if (ano >= 1900 & ano <= 2099)
            {
                x = 24;
                y = 5;
            }
            else
                if (ano >= 2100 & ano <= 2199)
                {
                    x = 24;
                    y = 6;
                }
                else
                    if (ano >= 2200 & ano <= 2299)
                    {
                        x = 25;
                        y = 7;
                    }
                    else
                    {
                        x = 24;
                        y = 5;
                    }


            var a = ano % 19;
            var b = ano % 4;
            var c = ano % 7;
            var d = (19 * a + x) % 30;
            var e = (2 * b + 4 * c + 6 * d + y) % 7;


            if ((d + e) > 9)
            {
                dia = (d + e - 9);
                mes = 4;
            }
            else
            {
                dia = (d + e + 22);
                mes = 3;
            }

            // PASCOA 
            var pascoa = Convert.ToDateTime((Convert.ToString(dia) + "/" + Convert.ToString(mes) + "/" + ano));
            data[0] = pascoa;


            // CARNAVAL ( PASCOA - 47 dias ) 
            var carnaval = pascoa.AddDays(-47);
            data[1] = carnaval;


            // CORPUS CHRISTI ( PASCOA + 60 dias ) 
            var corpus = pascoa.AddDays(60);
            data[2] = corpus;

            return data;
        }

        public static bool ValidarCep(string cep)
        {
            // só aceita strings no formato '00000-000'
            var r = new Regex("^[0-9]{5}-[0-9]{3}$");
            return r.IsMatch(cep);
        }
    }
}