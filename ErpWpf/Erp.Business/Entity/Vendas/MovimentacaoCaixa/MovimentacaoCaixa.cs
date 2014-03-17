using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa
{
    public class MovimentacaoCaixa
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataMovimento { get; set; }
        public virtual string Historico { get; set; }
        public virtual PessoaJuridica Empresa { get; set; }
        public virtual decimal Valor { get; set; }

        public virtual int Caixa { get; set; }
        public virtual PessoaFisica Usuario { get; set; }
        public virtual Status Status { get; set; }
    }
}