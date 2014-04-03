using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxGridView;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisAdministrador
    {
        public static void SaveAdministrador()
        {
            #region Joao

            var email = new PessoaContatoEletronico
            {
                Nick = "jas.system@suporte.com",
                Tipo = TipoEmail.Email
            };

            

            var msn = new PessoaContatoEletronico
            {
                Nick = "jas.system@hotmail.com",
                Tipo = TipoEmail.Msn
            };

            var listContatoEletronicoJunior = new List<PessoaContatoEletronico> { msn, email };

            var endereco = new PessoaEndereco
            {
                Endereco = EnderecoRepository.GetByCep("49290000"),
                Complemento = "CASA ",
                TipoEndereco = TipoEndereco.Residencial,
                Numero = "08"
            };

         
            var administradorJoao = new PessoaFisica
            {
                DataCadastro = DateTime.Now,

                Nome = "JOSE ADAILTON DOS SANTOS",
               
                Sexo = Sexo.Masculino,
               EnderecoEletronicos = listContatoEletronicoJunior,
                Enderecos = new List<PessoaEndereco> { endereco},

                Login = "admin",
                Senha ="admin",
                ConfirmarSenha = "admin",
                
                Cpf = "03025509503",
                //DataEmissaoRG = DateTime.Now,

                //DataReservista = DateTime.Now,

                TemaPadrao = Theme.Moderno,
                IdiomaPadrao = Idioma.PortugesBrasil,
                ModoEdicaoGridView = GridViewEditingMode.PopupEditForm,
                Status = Status.Ativo
            };

            PessoaFisicaRepository.Save(administradorJoao);
            var pessoa = PessoaFisicaRepository.GetByLogin("admin");
            if (pessoa != null)
            {
                var forms = new FormularioDictionary();
                foreach (var form in forms.Values)
                {
                    pessoa.PermissaoFormulario.Add(new PermissaoFormularioPessoaFisica()
                    {
                        Formulario = form.Value,
                        Edita = true,
                        Exclui = true,
                        Insere = true,
                        Pesquisa = true
                    });
                }
                PessoaFisicaRepository.Save(pessoa);
            }
            #endregion
        }
    }
}
