using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Util.Wpf
{
    public class EnumDictionary<T> : IValueConverter
    {
        public EnumDictionary()
        {
            Values = new List<EnumDictionaryValue<T>>();
            Load();
        }

        private T Type { get; set; }
        public IList<EnumDictionaryValue<T>> Values { get; set; }
        //private void LoadValues()
        //{
        //    var members = Type.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
        //    foreach (var member in members)
        //    {
        //        var attributes = member.GetCustomAttributes(typeof(DisplayAttribute), true);
        //        foreach (var attribute in attributes)
        //        {
        //            var description = attribute as DisplayAttribute;
        //            if (description != null)
        //            {
        //                Values.Add(new EnumDictionaryValue()
        //                {
        //                    Description = description.Name,
        //                    Value = member.ReflectedType
        //                });
        //            }
        //        }
        //    }

        //}
        public void Load()
        {

            var enumValues = System.Enum.GetValues(Type.GetType());
            foreach (Object t in enumValues)
            {
                Values.Add(new EnumDictionaryValue<T>()
                {
                    Description = GetDisplay(t, Type.GetType()),
                    Value = (T)t
                });
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var ret = Values.FirstOrDefault(x => value != null && x.Value.Equals(value));
            if (ret != null) return ret;

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null && Values.Count > 0)
            {
                return Values[0].Value;
            }
            var val = value as EnumDictionaryValue<T>;
            if (val != null)
            {
                return val.Value;
            }

            return null;
        }
        private string GetDisplay(object enumValue, Type enumType)
        {
            var descriptionAttribute = enumType
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;


            return descriptionAttribute != null
                ? descriptionAttribute.Name
                : enumValue.ToString();
        }
    }

    public class EnumDictionaryValue<T>
    {
        public string Description { get; set; }
        public T Value { get; set; }
    }
}
