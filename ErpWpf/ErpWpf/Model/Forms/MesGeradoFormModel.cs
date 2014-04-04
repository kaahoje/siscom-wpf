using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.ClassesRelacoinadas;
using Erp.Business.Enum;

namespace Erp.Model.Forms
{
    public class MesGeradoFormModel : ModelFormGeneric<MesGerado>
    {

        private bool _isGerar;

        public override MesGerado Entity
        {
            get { return base.Entity; }
            set
            {
                if (Equals(value, base.Entity)) return;
                base.Entity = value;
                if (Entity.Id != 0  )
                {
                    IsGerar = false;
                }
                OnPropertyChanged();
            }
        }

        public bool IsGerar
        {
            get { return _isGerar; }
            set
            {
                if (value.Equals(_isGerar)) return;
                _isGerar = value;
                OnPropertyChanged();
            }
        }

        
    }

}
