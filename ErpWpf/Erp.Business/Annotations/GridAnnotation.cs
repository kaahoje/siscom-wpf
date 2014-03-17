using System;

namespace Erp.Business.Annotations
{
    public class GridAnnotation : Attribute
    {
        public bool Visible { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }

        public string FieldName { get; set; }
    }
}
