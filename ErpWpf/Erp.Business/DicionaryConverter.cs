using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Erp.Business
{
    public class DicionaryConverter : IValueConverter
    {
        public DicionaryConverter(Type enumType)
        {
            EnumType = enumType;
        }

        protected Type EnumType { get; set; }

        //public class ItemMenu
        //{
        //    public Object Valor { get; set; }
        //    public String Descicao { get; set; }

        //    public ItemMenu(Object valor, String descricao)
        //    {
        //        this.Valor = valor;
        //        this.Descicao = descricao;
        //    }
        //}

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String key = GetDisplay(value, EnumType);
            return key;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                foreach (Object en in System.Enum.GetValues(EnumType))
                {
                    if (GetDisplay(en, EnumType).Equals(value))
                    {
                        return en;
                    }
                }
            }
            catch (Exception ex)
            {
                return value;
            }


            return value;
        }

        private string GetDisplay(object enumValue, Type enumType)
        {
            var descriptionAttribute = enumType
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof (DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
                ? descriptionAttribute.Description
                : enumValue.ToString();
        }

        public object Convert(Object value)
        {
            return Convert(value, EnumType, null, null);
        }

        /// <summary>
        ///     Método que retorna o valor do enum com base na descrição
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ConvertBack(object value)
        {
            return ConvertBack(value, EnumType, null, null);
        }
    }
}