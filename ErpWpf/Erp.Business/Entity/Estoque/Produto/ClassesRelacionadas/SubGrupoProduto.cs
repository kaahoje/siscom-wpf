using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    [Serializable]
    public class SubGrupoProduto : INotifyPropertyChanged
    {
        private GrupoProduto _grupo;
        private string _impressora;
        private bool _imprimeEmComandaRestaurante;
        private string _descricao;
        public virtual int Id { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = Constants.MessageLengthDescriptionError)]
        [Display(Name = "Descrição", Description = "Descrição do subgrupo", Order = 1)]
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

        [Display(Name = "Imprime comanda", Description = "Imprime em comanda de restaurante", Order = 2)]
        public virtual bool ImprimeEmComandaRestaurante
        {
            get { return _imprimeEmComandaRestaurante; }
            set
            {
                if (value.Equals(_imprimeEmComandaRestaurante)) return;
                _imprimeEmComandaRestaurante = value;
                if (!value)
                {
                    Impressora = "";
                }
                OnPropertyChanged();
            }
        }

        [Display(Name = "Impressora", Description = "Impressora", Order = 3)]
        public virtual string Impressora
        {
            get { return _impressora; }
            set
            {
                if (value == _impressora) return;
                _impressora = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Name = "Descrição", Description = "Descrição do subgrupo", Order = 4)]
        public virtual GrupoProduto Grupo
        {
            get { return _grupo; }
            set
            {
                if (Equals(value, _grupo)) return;
                _grupo = value;
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