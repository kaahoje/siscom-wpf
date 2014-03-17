using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae;
using Erp.Business.Validation.CustomValidations;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica
{
    public class PessoaJuridica : Pessoa
    {
        [Display(Description = "Razão social da pessoa.", Name = "Razão social", Order = 1)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 250)]
        public virtual String RazaoSocial { get; set; }

        [Display(Description = "Nome fantasia da pessoa.", Name = "Nome fantasia", Order = 2)]
        [GridAnnotation(Order = 1, Visible = true, Width = 200)]
        public virtual String NomeFantasia { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "CNPJ da pessoa", Name = "CNPJ", Order = 3)]
        [DisplayFormat(DataFormatString = Constants.MaskCnpj,NullDisplayText = Constants.NullTextGeneroMasculino)]
        [CustomValidation(typeof(CpfCnpjValidation), "IsCpfCnpjValid")]
        [Mask(Constants.MaskCnpj)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        public virtual String Cnpj { get; set; }

        public virtual IList<PessoaJuridicaXcnaeSubClasse> RamosDeAtividade { get; set; }

        #region
        [Display(Description = "Inscrição estadual", Name = "IM", Order = 4)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroFeminino)]
        [GridAnnotation(Order = 3, Visible = true, Width = 100)]
        public virtual String InscricaoEstadual { get; set; }

        [Display(Description = "Inscrição estadual", Name = "IE", Order = 5)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroFeminino)]
        public virtual String InscricaoMunicipal { get; set; }


        [Display(Description = "Data de Abertura", Name = "Data de Abertura", Order = 6)]
        public virtual DateTime DataAbertura { get; set; }

        #endregion

        public PessoaJuridica()
        {
            RamosDeAtividade = new List<PessoaJuridicaXcnaeSubClasse>();
        }
    }
}
