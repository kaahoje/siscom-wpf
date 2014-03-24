using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae;
using Erp.Business.Validation.CustomValidations;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica
{
    public class PessoaJuridica : Pessoa, INotifyPropertyChanged
    {
        private DateTime _dataAbertura;
        private string _inscricaoMunicipal;
        private string _inscricaoEstadual;
        private IList<PessoaJuridicaXcnaeSubClasse> _ramosDeAtividade;
        private string _cnpj;
        private string _nomeFantasia;
        private string _razaoSocial;
        private Guid _idGuid;

        public virtual Guid IdGuid
        {
            get { return _idGuid; }
            set
            {
                if (value.Equals(_idGuid)) return;
                _idGuid = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Razão social da pessoa.", Name = "Razão social", Order = 1)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 250)]
        public virtual String RazaoSocial
        {
            get { return _razaoSocial; }
            set
            {
                if (value == _razaoSocial) return;
                _razaoSocial = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Nome fantasia da pessoa.", Name = "Nome fantasia", Order = 2)]
        [GridAnnotation(Order = 1, Visible = true, Width = 200)]
        public virtual String NomeFantasia
        {
            get { return _nomeFantasia; }
            set
            {
                if (value == _nomeFantasia) return;
                _nomeFantasia = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "CNPJ da pessoa", Name = "CNPJ", Order = 3)]
        [DisplayFormat(DataFormatString = Constants.MaskCnpj, NullDisplayText = Constants.NullTextGeneroMasculino)]
        [CustomValidation(typeof (CpfCnpjValidation), "IsCpfCnpjValid", ErrorMessage = "CNPJ inválido")]
        [Mask(Constants.MaskCnpj)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        public virtual String Cnpj
        {
            get { return _cnpj; }
            set
            {
                if (value == _cnpj) return;
                _cnpj = value;
                OnPropertyChanged();
            }
        }

        public virtual IList<PessoaJuridicaXcnaeSubClasse> RamosDeAtividade
        {
            get { return _ramosDeAtividade; }
            set
            {
                if (Equals(value, _ramosDeAtividade)) return;
                _ramosDeAtividade = value;
                OnPropertyChanged();
            }
        }

        #region

        [Display(Description = "Inscrição estadual", Name = "IM", Order = 4)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroFeminino)]
        [GridAnnotation(Order = 3, Visible = true, Width = 100)]
        public virtual String InscricaoEstadual
        {
            get { return _inscricaoEstadual; }
            set
            {
                if (value == _inscricaoEstadual) return;
                _inscricaoEstadual = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Inscrição estadual", Name = "IE", Order = 5)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroFeminino)]
        public virtual String InscricaoMunicipal
        {
            get { return _inscricaoMunicipal; }
            set
            {
                if (value == _inscricaoMunicipal) return;
                _inscricaoMunicipal = value;
                OnPropertyChanged();
            }
        }


        [Display(Description = "Data de Abertura", Name = "Data de Abertura", Order = 6)]
        public virtual DateTime DataAbertura
        {
            get { return _dataAbertura; }
            set
            {
                if (value.Equals(_dataAbertura)) return;
                _dataAbertura = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public PessoaJuridica()
        {
            RamosDeAtividade = new List<PessoaJuridicaXcnaeSubClasse>();
            IdGuid = Guid.NewGuid();
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
