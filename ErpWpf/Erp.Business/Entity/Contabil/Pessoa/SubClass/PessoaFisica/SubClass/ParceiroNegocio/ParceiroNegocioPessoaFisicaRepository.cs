﻿using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using NHibernate;
using NHibernate.Criterion;
using Util.Seguranca;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio
{
    public class ParceiroNegocioPessoaFisicaRepository : RepositoryBase<ParceiroNegocioPessoaFisica>
    {

        public static ParceiroNegocioPessoaFisica Save(ParceiroNegocioPessoaFisica entity)
        {
            using (ITransaction transaction = NHibernateHttpModule.Session.BeginTransaction())
            {
                try
                {
                    if (PessoaFisicaRepository.ExisteCpf(entity))
                    {
                        throw new Exception("Já existe um CPF cadastrado");
                    }
                    if (Validate(entity))
                    {
                        entity.Senha = Criptografia.CriptografarSenha(entity.Senha);
                        NHibernateHttpModule.Session.Save(entity);
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return entity;
        }
        public static IList<ParceiroNegocioPessoaFisica> GetByCpfCnpj(String cpfCnpj)
        {
            Pessoa p = null;
            IList<ParceiroNegocioPessoaFisica> list = GetQueryOver().JoinQueryOver(cliente => cliente,() => p).List();
            return list;
        }


        public static IList<ParceiroNegocioPessoaFisica> GetByCep(string cep)
        {
            Pessoa p = null;
            PessoaEndereco endPessoa = null;
            Endereco end = null;
            return GetQueryOver().JoinQueryOver(pessoa => pessoa.Enderecos, () => endPessoa)
                .JoinQueryOver(endereco => endereco.Endereco, () => end)
                .Where(endereco => endereco.Cep == cep).List<ParceiroNegocioPessoaFisica>();
        }

        public static bool IsLimiteDisponivel(int pessoa, decimal saldoADebitar)
        {
            
            //if (GetById(pessoa).SaldoAtual < saldoADebitar)
            //{
            //    return false;
            //}
            return true;
        }

        public static IList<ParceiroNegocioPessoaFisica> GetByNome(string text)
        {

            return GetQueryOver().Where(cliente => cliente.Nome.IsInsensitiveLike(text + "%")).List();
        }

        public static object GetRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - skip + 1;
            if (String.IsNullOrEmpty(Validation.Validation.GetOnlyNumber(args.Filter)))
            {
                return GetQueryOver().Where(pessoa => pessoa.Cpf.IsInsensitiveLike(args.Filter + "%"))
                    .Skip(skip).Take(take).List<ParceiroNegocioPessoaFisica>();
            }
            return GetQueryOver().Where(pessoa => pessoa.Nome.IsInsensitiveLike("%" + args.Filter + "%"))
                .Skip(skip).Take(take).List<ParceiroNegocioPessoaFisica>();
        }

        public static object GetByValue(ListEditItemRequestedByValueEventArgs args)
        {
            return GetQueryOver().Where(pessoa => pessoa.Id == int.Parse(args.Value.ToString())).Take(1)
                .List<ParceiroNegocioPessoaFisica>();
        }

        public static IList<ParceiroNegocioPessoaFisica> GetByRange(string filter, int takePesquisa)
        {
            if (Validation.Validation.GetOnlyNumber(filter).Length == filter.Length)
            {
                return GetQueryOver().Where(x => x.Cpf.IsInsensitiveLike(StartStringFilter(filter))).Take(takePesquisa).List();
            }
            return GetQueryOver().Where(x => x.Nome.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                x.Alias.IsInsensitiveLike(ContainsStringFilter(filter))).Take(takePesquisa).List();
        }
    }
}