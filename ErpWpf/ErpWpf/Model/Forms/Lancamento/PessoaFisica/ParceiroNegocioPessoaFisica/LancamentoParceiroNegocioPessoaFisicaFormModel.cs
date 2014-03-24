using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Forms.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class LancamentoParceiroNegocioPessoaFisicaFormModel : ModelFormGeneric<LancamentoParceiroNegocioPessoaFisica>
    {
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
    }
}
