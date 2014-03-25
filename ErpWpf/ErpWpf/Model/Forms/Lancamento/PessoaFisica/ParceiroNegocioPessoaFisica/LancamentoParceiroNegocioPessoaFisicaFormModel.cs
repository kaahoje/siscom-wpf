using System;
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

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    LancamentoParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    Entity = new LancamentoParceiroNegocioPessoaFisica();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    LancamentoParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    Entity = new LancamentoParceiroNegocioPessoaFisica();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        private ParceiroNegocioPessoaFisicaLargeDataModel _parceiroNegocioPessoaFisicaLargeData;
        public ParceiroNegocioPessoaFisicaLargeDataModel ParceiroNegocioPessoaFisicaLargeData
        {
            get { return _parceiroNegocioPessoaFisicaLargeData; }
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
