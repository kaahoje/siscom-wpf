using System;

namespace Erp.Business.Annotations
{
    public class MenuDataAnnotation : Attribute,IMenuDataAnnotation
    {
        public string Url { get; set; }
        public string PathIcone { get; set; }
    }
}
