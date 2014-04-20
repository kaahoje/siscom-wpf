using System;
using System.Globalization;
using System.Linq.Expressions;

namespace RestauranteMobile.Extensions
{
    public class ExtensionFunctions
    {
        public static string GetFieldName<TModel, TValue>(Expression<Func<TModel, TValue>>expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            var fieldName = expression.Body.ToString();
            fieldName = fieldName.Substring(fieldName.IndexOf('.') + 1);
            fieldName = fieldName.Replace(".", "_");
            return fieldName;
        }

        public static string GetPrimeiraLetaMinuscula( string text)
        {
            var ret = "";
            for (var i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    ret += text[i].ToString(CultureInfo.InvariantCulture).ToLower();
                }
                else
                {
                    ret += text[i];
                }
            }
            return ret;
        }
        
    }
}