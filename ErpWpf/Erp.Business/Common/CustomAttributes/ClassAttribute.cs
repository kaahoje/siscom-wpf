using System;

namespace Erp.Business.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DisplayClass : Attribute
    {
        public string Nome { get; set; }

        public string HotKey { get; set; }
    }

}
