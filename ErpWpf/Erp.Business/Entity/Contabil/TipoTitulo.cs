using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    /// <summary>
    ///     Define os tipos de lançamento
    ///     Esta informação deve ser omitida caso o cliente use o sistema para gerar SPED contábil.
    /// </summary>
    [Serializable]
    public class TipoTitulo : INotifyPropertyChanged
    {
        private string _descricao;
        private PlanoContaReferencial _contaPartidaValor;
        private PlanoContaReferencial _contaPartidaDesconto;
        private PlanoContaReferencial _contaPartidaAcressimos;
        private PlanoContaReferencial _contaContraPartidaValor;
        private PlanoContaReferencial _contaContraPartidaDesconto;
        private PlanoContaReferencial _contaContraPartidaAcressimos;
        public virtual int Id { get; set; }

        [Display(Name = "Descricao", Description = "Descrição do tipo")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthDescriptions,ErrorMessage = Constants.MessageLengthDescriptionError)]
        public virtual string Descricao
        {
            get { return _descricao; }
            set
            {
                if (value == _descricao) return;
                _descricao = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Define a conta que foi movimentada na operação.
        /// </summary>
        [Display(Name = "Partida valor",Description = "Partida do valor")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual PlanoContaReferencial ContaPartidaValor
        {
            get { return _contaPartidaValor; }
            set
            {
                if (Equals(value, _contaPartidaValor)) return;
                _contaPartidaValor = value;
                OnPropertyChanged();
            }
        }

       
        public virtual PlanoContaReferencial ContaPartidaDesconto
        {
            get { return _contaPartidaDesconto; }
            set
            {
                if (Equals(value, _contaPartidaDesconto)) return;
                _contaPartidaDesconto = value;
                OnPropertyChanged();
            }
        }

        public virtual PlanoContaReferencial ContaPartidaAcressimos
        {
            get { return _contaPartidaAcressimos; }
            set
            {
                if (Equals(value, _contaPartidaAcressimos)) return;
                _contaPartidaAcressimos = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Contra partida valor", Description = "Conta do valor da contra partida")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual PlanoContaReferencial ContaContraPartidaValor
        {
            get { return _contaContraPartidaValor; }
            set
            {
                if (Equals(value, _contaContraPartidaValor)) return;
                _contaContraPartidaValor = value;
                OnPropertyChanged();
            }
        }

        

        public virtual PlanoContaReferencial ContaContraPartidaDesconto
        {
            get { return _contaContraPartidaDesconto; }
            set
            {
                if (Equals(value, _contaContraPartidaDesconto)) return;
                _contaContraPartidaDesconto = value;
                OnPropertyChanged();
            }
        }

        public virtual PlanoContaReferencial ContaContraPartidaAcressimos
        {
            get { return _contaContraPartidaAcressimos; }
            set
            {
                if (Equals(value, _contaContraPartidaAcressimos)) return;
                _contaContraPartidaAcressimos = value;
                OnPropertyChanged();
            }
        }

        public virtual Status Status { get; set; }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}