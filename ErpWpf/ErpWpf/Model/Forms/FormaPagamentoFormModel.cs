﻿using System;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Model.Forms
{
    public class FormaPagamentoFormModel : ModelFormGeneric<FormaPagamento>
    {
        public FormaPagamentoFormModel()
        {
            Entity = new FormaPagamento();
            ModelSelect = new ModelSelectGeneric<FormaPagamento>();
        }
        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    FormaPagamentoRepository.Save(Entity);
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
                    FormaPagamentoRepository.Save(Entity);
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        private FormaPagamento _entity;

        public new FormaPagamento Entity
        {
            get { return _entity ?? (_entity = new FormaPagamento()); }
            set
            {
                _entity = value; 
                OnPropertyChanged("Entity");
            }
        }
    }
}
