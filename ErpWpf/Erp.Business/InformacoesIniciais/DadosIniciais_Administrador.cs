using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxGridView;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Enum;
using Util.Seguranca;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisAdministrador
    {
        public static void SaveAdministrador()
        {
            #region Joao

            var email = new PessoaContatoEletronico
            {
                Nick = "bosco.system@hotmail.com",
                Tipo = TipoEmail.Email
            };

            var skype = new PessoaContatoEletronico
            {
                Nick = "juniormywill",
                Tipo = TipoEmail.Skype
            };

            var msn = new PessoaContatoEletronico
            {
                Nick = "juniormywill@hotmail.com",
                Tipo = TipoEmail.Msn
            };

            var listContatoEletronicoJunior = new List<PessoaContatoEletronico> { msn, skype, email };

            var enderecoJunior = new PessoaEndereco
            {
                Endereco = EnderecoRepository.GetByCep("12220140"),
                Complemento = "Condominio",
                TipoEndereco = TipoEndereco.Residencial,
                Numero = "0"
            };

         
            var administradorJoao = new PessoaFisica
            {
                DataCadastro = DateTime.Now,

                Nome = "João Bosco de Oliveira Junior",
               
                Sexo = Sexo.Masculino,
               EnderecoEletronicos = listContatoEletronicoJunior,
                Enderecos = new List<PessoaEndereco> { enderecoJunior },

                Login = "admin",
                Senha ="admin",
                ConfirmarSenha = "admin",
                
                Cpf = "00368748502",
                //DataEmissaoRG = DateTime.Now,

                //DataReservista = DateTime.Now,

                TemaPadrao = Theme.Moderno,
                IdiomaPadrao = Idioma.PortugesBrasil,
                ModoEdicaoGridView = GridViewEditingMode.PopupEditForm,
                Status = Status.Ativo
            };

            PessoaFisicaRepository.Save(administradorJoao);

            #endregion
        }
    }
}
