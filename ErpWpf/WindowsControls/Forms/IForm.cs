using System;
using DevExpress.XtraEditors;
using Erp.Business.Validation;

namespace WindowsControls.Forms
{
    public interface IForm
    {
        object CurrentObject { get; set; }

        
        XtraForm Form { get; }
        FormState FormState { get; set; }
        Object Save();


        void Update(Object entity);

        bool Delete(object entity);

        EntityValidationResult Validate();

        void Reload();
        void Cancel();
        Object New();
    }

    public enum FormState
    {
        None,
        Inserting,
        Updating
    }
}