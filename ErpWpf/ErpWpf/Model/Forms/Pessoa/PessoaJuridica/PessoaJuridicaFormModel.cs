﻿using System;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Enum;
using Erp.Model.Grids.Pessoa.PessoaJuridica;
using Erp.View.Forms.Pessoa.PessoaFisica;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa.PessoaJuridica
{
    public class PessoaJuridicaFormModel : PessoaFormModel,IPessoa
    {
        

        public PessoaJuridicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica();
            ModelSelect = new PessoaJuridicaSelectModel();
            IsSalvar = false;
        }

        public override void Salvar()
        {
            MensagemErroBancoDados("Não é possível salvar ou editar uma pessoa jurídica.");
        }

        public Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica EntityPessoaJuridica
        {
            get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica) Entity; }
            set
            {
                Entity = value; 
                OnPropertyChanged("EntityPessoaJuridica");
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    PessoaJuridicaRepository.Save(EntityPessoaJuridica);
                    EntityPessoaJuridica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }
        #region Commands

        public ICommand CmdIrParaPessoaJuridica { get { return new RelayCommandBase(x=>IrParaPessoaJuridica());} }

        

        #endregion

        #region Operations

        public virtual void IrParaPessoaJuridica()
        {
            new PessoaFisicaFormView().ShowDialog();
        }

        #endregion

    }
}
