using System;
using Erp.Business;
using Erp.Business.Entity.Contabil;
using Erp.Business.Enum;
using Erp.Model.Grids;
using Erp.Model.LargeDataModel;

namespace Erp.Model.Forms
{
    public class TipoTituloFormModel : ModelFormGeneric<TipoTitulo>
    {
        private PlanoContaReferencialLargeDataModel _contaValorPartida;
        private PlanoContaReferencialLargeDataModel _contaValorContraPartida;
        private PlanoContaReferencialLargeDataModel _contaAcrescimoPartida;
        private PlanoContaReferencialLargeDataModel _contaAcrescimoContraPartida;
        private PlanoContaReferencialLargeDataModel _contaDescontoPartida;
        private PlanoContaReferencialLargeDataModel _contaDescontoContraPartida;


        public TipoTituloFormModel()
        {
            Entity = new TipoTitulo();
            ModelSelect= new TipoTituloSelectModel();
            ModelSelect.WindowSelect.IsVisibleChanged += WindowSelect_IsVisibleChanged;
        }

        void WindowSelect_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (Entity.Id != 0)
            {
                ContaValorPartida.Filter = Entity.ContaPartidaValor.Codigo;
                ContaValorContraPartida.Filter = Entity.ContaContraPartidaValor.Codigo;
                if (Entity.ContaPartidaAcressimos != null)
                {
                    ContaAcrescimoPartida.Filter = Entity.ContaPartidaAcressimos.Codigo;
                }
                if (Entity.ContaContraPartidaAcressimos!= null)
                {
                    ContaAcrescimoContraPartida.Filter = Entity.ContaContraPartidaAcressimos.Codigo;
                }
                if (Entity.ContaPartidaDesconto != null)
                {
                    ContaDescontoPartida.Filter = Entity.ContaPartidaDesconto.Codigo;
                }
                if (Entity.ContaContraPartidaDesconto != null)
                {
                    ContaDescontoContraPartida.Filter = Entity.ContaContraPartidaDesconto.Codigo;
                }
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    TipoTituloRepository.Save(Entity);
                    Entity = new TipoTitulo();
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
                if (IsValid(Entity))
                {
                    TipoTituloRepository.Save(Entity);
                    Entity = new TipoTitulo();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }


        public PlanoContaReferencialLargeDataModel ContaValorPartida
        {
            get { return _contaValorPartida ?? (_contaValorPartida = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _contaValorPartida)) return;
                _contaValorPartida = value;
                OnPropertyChanged();
            }
        }

        public PlanoContaReferencialLargeDataModel ContaValorContraPartida
        {
            get { return _contaValorContraPartida ?? (_contaValorContraPartida = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _contaValorContraPartida)) return;
                _contaValorContraPartida = value;
                OnPropertyChanged();
            }
        }

        public PlanoContaReferencialLargeDataModel ContaAcrescimoPartida
        {
            get { return _contaAcrescimoPartida ?? (_contaAcrescimoPartida = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _contaAcrescimoPartida)) return;
                _contaAcrescimoPartida = value;
                OnPropertyChanged();
            }
        }

        public PlanoContaReferencialLargeDataModel ContaAcrescimoContraPartida
        {
            get { return _contaAcrescimoContraPartida ?? (_contaAcrescimoContraPartida = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _contaAcrescimoContraPartida)) return;
                _contaAcrescimoContraPartida = value;
                OnPropertyChanged();
            }
        }

        public PlanoContaReferencialLargeDataModel ContaDescontoPartida
        {
            get { return _contaDescontoPartida ?? (_contaDescontoPartida = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _contaDescontoPartida)) return;
                _contaDescontoPartida = value;
                OnPropertyChanged();
            }
        }

        public PlanoContaReferencialLargeDataModel ContaDescontoContraPartida
        {
            get { return _contaDescontoContraPartida ?? (_contaDescontoContraPartida = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _contaDescontoContraPartida)) return;
                _contaDescontoContraPartida = value;
                OnPropertyChanged();
            }
        }
    }
}
