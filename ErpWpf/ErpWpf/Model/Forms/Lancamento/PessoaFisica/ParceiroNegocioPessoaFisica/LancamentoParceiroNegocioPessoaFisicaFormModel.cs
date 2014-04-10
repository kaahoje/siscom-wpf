using System;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.Model.LargeDataModel;

namespace Erp.Model.Forms.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class LancamentoParceiroNegocioPessoaFisicaFormModel : ModelFormGeneric<LancamentoParceiroNegocioPessoaFisica>
    {
        
        private PlanoContaReferencialLargeDataModel _planoContaReferencialLargeData;

        public LancamentoParceiroNegocioPessoaFisicaFormModel()
        {
            Entity = new LancamentoParceiroNegocioPessoaFisica();
            ModelSelect = new LancamentoParceiroNegocioPessoaFisicaSelectModel();
            
        }

        public override bool IsExcluir
        {
            get { return false; }
            set
            {
                
            }
        }

        public override bool IsSalvar
        {
            get { return false; }
            set
            {
                
            }
        }

        public override void Excluir()
        {
            MensagemInformativa(MensagemFuncaoNaoSuportada);
        }

        public override void Salvar()
        {
            MensagemInformativa(MensagemFuncaoNaoSuportada);
        }

        private ParceiroNegocioPessoaFisicaLargeDataModel _parceiroNegocioPessoaFisicaLargeData;
        public ParceiroNegocioPessoaFisicaLargeDataModel ParceiroNegocioPessoaFisicaLargeData
        {
            get { return _parceiroNegocioPessoaFisicaLargeData ?? (_parceiroNegocioPessoaFisicaLargeData = new ParceiroNegocioPessoaFisicaLargeDataModel()); }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaFisicaLargeData)) return;
                _parceiroNegocioPessoaFisicaLargeData = value;
                OnPropertyChanged();
            }
        }


        public PlanoContaReferencialLargeDataModel PlanoContaReferencialLargeData
        {
            get { return _planoContaReferencialLargeData; }
            set
            {
                if (Equals(value, _planoContaReferencialLargeData)) return;
                _planoContaReferencialLargeData = value;
                OnPropertyChanged();
            }
        }
    }
}
