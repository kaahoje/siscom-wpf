using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Forms.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class CustoFixoParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<CustoFixoParceiroNegocioPessoaJuridica>
    {
        public CustoFixoParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new CustoFixoParceiroNegocioPessoaJuridica();
            ModelSelect = new  CustoFixoParceiroNegocioPessoaJuridicaSelectModel();
        }

        public override void Excluir()
        {
            try
            {
                if (IsValid(Entity))
                {
                    Entity.Status = Status.Excluido;
                    CustoFixoParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    Entity = new CustoFixoParceiroNegocioPessoaJuridica();
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
                    CustoFixoParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    Entity = new CustoFixoParceiroNegocioPessoaJuridica();
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
