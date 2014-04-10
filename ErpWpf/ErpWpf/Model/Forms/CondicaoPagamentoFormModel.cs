using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoMapper;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids;
using FluentNHibernate.Conventions;
using Util.Wpf;

namespace Erp.Model.Forms
{
    public class CondicaoPagamentoFormModel : ModelFormGeneric<CondicaoPagamento>
    {
        private ObservableCollection<PrazoPagamentoCondicaoPagamento> _prazos;
        private PrazoPagamentoCondicaoPagamento _prazoAtual;

        public CondicaoPagamentoFormModel()
        {
            Entity = new CondicaoPagamento();
            ModelSelect = new CondicaoPagamentoSelectModel();
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    CondicaoPagamentoRepository.Save(Entity);
                    Entity = new CondicaoPagamento();
                    base.Excluir();
                }

            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }

        }

        public override void Salvar()
        {
            try
            {
                Mapper.CreateMap(typeof(CondicaoPagamentoFormModel), typeof(CondicaoPagamento));
                Mapper.Map(this, Entity);
                if (IsValid(Entity))
                {
                    CondicaoPagamentoRepository.Save(Entity);
                    Entity = new CondicaoPagamento();
                    base.Salvar();
                }

            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public PrazoPagamentoCondicaoPagamento PrazoAtual
        {
            get { return _prazoAtual; }
            set
            {
                _prazoAtual = value; 
                OnPropertyChanged("PrazoAtual");
            }
        }

        public ObservableCollection<PrazoPagamentoCondicaoPagamento> Prazos
        {
            get { return _prazos ?? (_prazos = new ObservableCollection<PrazoPagamentoCondicaoPagamento>()); }
            set
            {
                _prazos = value;
                OnPropertyChanged("Prazos");
            }
        }
        public ICommand CmdAddPrazo { get { return new RelayCommandBase(x => AddPrazo()); } }

        private void AddPrazo()
        {
            int prazo = 0;
            foreach (var pr in Prazos)
            {
                if (pr.Prazo > prazo)
                {
                    prazo = pr.Prazo + 1;
                }
            }
            Prazos.Add(new PrazoPagamentoCondicaoPagamento() { Prazo = prazo });
        }

        public ICommand CmdRemovePrazo { get { return new RelayCommandBase(x => RemovePrazo()); } }

        private void RemovePrazo()
        {
            if (Prazos == null || Prazos.IsEmpty())
            {
                MensagemErro("Não há prazos cadastrados.");
                return;
            }
            if (PrazoAtual == null)
            {
                MensagemErro("Selecione um prazo para excluir.");
                return;
            }
            Prazos.Remove(PrazoAtual);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Entity")
            {
                Prazos.Clear();
                Prazos.AddRange(Entity.Prazos);
            }
        }
    }
}
