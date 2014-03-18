using System;
using Erp.Business.Common.CustomAttributes;

namespace Erp.Business
{
    public static class AttributesFunctions
    {
        public static string GetDisplayClassName(Type classType)
        {
            DisplayClass displayAttribute;


            var attrs = Attribute.GetCustomAttributes(classType);

            foreach (var attr in attrs)
            {
                displayAttribute = attr as DisplayClass;
                if (displayAttribute == null)
                    continue;
                return displayAttribute.Nome;
            }
            return "Atributo nome para classe não encotrado";
        }

        public static string GetDisplayClassHotKey(Type classType)
        {
            DisplayClass displayAttribute;


            var attrs = Attribute.GetCustomAttributes(classType);

            foreach (var attr in attrs)
            {
                displayAttribute = attr as DisplayClass;
                if (displayAttribute == null)
                    continue;
                return displayAttribute.HotKey;
            }
            return "Atributo hotKey para classe não encotrado";
        }
    }
}
