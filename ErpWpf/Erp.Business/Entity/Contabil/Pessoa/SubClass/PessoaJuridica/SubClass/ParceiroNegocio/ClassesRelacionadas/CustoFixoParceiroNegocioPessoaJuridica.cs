﻿using System.ComponentModel;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaJuridica : CustoFixo
    {
        private ParceiroNegocioPessoaJuridica _parceiroNegocioPessoaJuridica;

        public ParceiroNegocioPessoaJuridica ParceiroNegocioPessoaJuridica
        {
            get { return _parceiroNegocioPessoaJuridica; }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaJuridica)) return;
                _parceiroNegocioPessoaJuridica = value;
                OnPropertyChanged();
            }
        }
    }
}
