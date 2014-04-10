using System;
using System.Windows.Input;
using Erp.Business;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.ClassesRelacoinadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Util.Wpf;

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

        

        public ICommand CmdGerarMes { get { return new RelayCommandBase(x=>GerarMes());} }

        private void GerarMes()
        {
            try
            {
                if (IsValid(Entity))
                {
                    CustoFixoParceiroNegocioPessoaFisicaRepository.GerarMes(Entity);
                    CustoFixoParceiroNegocioPessoaJuridicaRepository.GerarMes(Entity);
                    MesGeradoRepository.Save(Entity);
                    MensagemInformativa("Mês gerado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }
        
    }

}
