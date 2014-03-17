using System;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.Filial
{
    [Serializable]
    public class Filial : PessoaJuridica
    {

        /*
         * Define qual a entidade responsável pela manutenção do plano de contas
         * referêncial utilizado pela empresa.
         * Os valores possíveis são 10-Receitas federal e 20-Cosif
         */
        public virtual SpedInstituicaoResponsavel EntidadePlanoContaReferencial { get; set; }
        public virtual PessoaJuridica Matriz { get; set; }
        public virtual RegimeTributacao Regime { get; set; }
        public virtual String LogoEmpresa { get; set; }
    }
}