using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Erp.Business
{
    class DicionaryEnumBase : ObservableCollection<DicionaryItem>
    {
        private Type EnumType { get; set; }

        public void Load(Type enumType)
        {
            EnumType = enumType;
            Array enumValues = System.Enum.GetValues(enumType);
            foreach (Object t in enumValues)
            {
                //AddChild(new ClienteWPF.DicionaryConverter.ItemMenu(t, GetDisplay(Name = t, enumType)));
                Add(new DicionaryItem
                {
                    Descricao = GetDisplay(t, enumType),
                    Valor = t
                });
            }
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

        public Collection<DicionaryItem> GetList()
        {
            return this;
        }
    }
}