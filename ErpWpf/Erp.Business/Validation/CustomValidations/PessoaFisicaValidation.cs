using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Util.Seguranca;

namespace Erp.Business.Validation.CustomValidations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PessoaFisicaValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            var parceiroModel = value as PessoaFisica;
            
            if (parceiroModel == null)
            {
                throw new Exception("O objeto value não é do tipo PessoaFisica.");
            }

            var novaSenha = "";
            if (novaSenha.Length <21 && !string.IsNullOrEmpty(parceiroModel.NovaSenha))
            {
                parceiroModel.NovaSenha = Criptografia.CriptografarSenha(parceiroModel.NovaSenha);
                novaSenha = parceiroModel.NovaSenha;
            }
            var senha = "";
            if (senha.Length < 21 && !string.IsNullOrEmpty(parceiroModel.Senha))
            {
                parceiroModel.Senha = Criptografia.CriptografarSenha(parceiroModel.Senha);
                senha = parceiroModel.Senha;
            }
            var confirmarSenha = "";
            if (confirmarSenha.Length < 21 && !string.IsNullOrEmpty(parceiroModel.ConfirmarSenha))
            {
                parceiroModel.ConfirmarSenha = Criptografia.CriptografarSenha(parceiroModel.ConfirmarSenha);
                confirmarSenha = parceiroModel.ConfirmarSenha;
            }
            // Verifica os dados de usuário
            if (parceiroModel.Id == 0)
            {
                // Confere se a senha é igual a confirmação
                if (!parceiroModel.Senha.Equals(parceiroModel.ConfirmarSenha))
                {
                    ErrorMessage = "A senha de confirmação não é igual a senha";
                    return false;
                }
            }
            else
            {
                var parceiro = PessoaFisicaRepository.GetById(parceiroModel.Id);
                // Confere se a senha é igual à confirmação
                if (novaSenha.Equals(confirmarSenha))
                {
                    // Confere se a senha informada pelo usuário confere com a senha de usuário gravada no banco.
                    if (!parceiro.Senha.Equals(senha))
                    {
                        ErrorMessage = "Senha inválida";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "A nova senha não confere com a confirmação da senha.";
                    return false;
                }
            }
            return true;
        }
    }
}
