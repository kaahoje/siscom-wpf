using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Forms.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class CustoFixoParceiroNegocioPessoaFisicaFormModel : ModelFormGeneric<CustoFixoParceiroNegocioPessoaFisica>
    {
        public CustoFixoParceiroNegocioPessoaFisicaFormModel()
        {
            Entity = new CustoFixoParceiroNegocioPessoaFisica();
            ModelSelect = new CustoFixoParceiroNegocioPessoaFisicaSelectModel();
        }

        
        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    CustoFixoParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    Entity = new CustoFixoParceiroNegocioPessoaFisica();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    CustoFixoParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    Entity = new CustoFixoParceiroNegocioPessoaFisica();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }
    }
}
