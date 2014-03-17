using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxEditors;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe repositório da classe "Endereco"
    /// </summary>
    public class EnderecoRepository : RepositoryBase<Endereco>
    {
        /// <summary>
        ///     Método que consulta uma cidade com base no seu CEP.
        /// </summary>
        /// <param name="cep">Cep da cidade.</param>
        /// <returns>
        ///     Retorna o endereço de acordo com o CEP. Retorna null se não for
        ///     encontrado nenhum registro ou se não for informado o CEP ou ainda
        ///     se CEP não corresponder ao padrão esperado.
        /// </returns>
        public static Endereco GetByCep(string cep)
        {
            //return NHibernateHttpModule.Session.CreateCriteria<Endereco>().Add(Restrictions.Like("Cep", value: "%" + cep + "%")).UniqueResult<Endereco>();
            Endereco endereco = NHibernateHttpModule.Session.QueryOver<Endereco>()
                .Where(endereco1 => endereco1.Cep == cep)
                .SingleOrDefault();
            return endereco;
        }

        public static object GetByRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - skip + 1;
            if (Validation.Validation.GetOnlyNumber(args.Filter).Equals(""))
            {
                return GetQueryOver().Where(endereco => endereco.Nome.IsInsensitiveLike("%" + args.Filter + "%"))
                    .Skip(skip).Take(take).List<Endereco>();
            }
            return GetQueryOver().Where(endereco => endereco.Cep.IsInsensitiveLike(args.Filter + "%"))
                .Skip(skip).Take(take).List<Endereco>();
        }

        public static object GetByValue(ListEditItemRequestedByValueEventArgs args)
        {
            if (args.Value == null)
            {
                return new List<Endereco>();
            }
            return GetQueryOver().Where(endereco => endereco.Id == int.Parse(args.Value.ToString())).Take(1).List<Endereco>();
        }

        public static string RemoveDiacritics(String s)
        {
            var normalizedString = s.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
            {
                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public static object GetEnderecoRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Filter))
            {
                var skip = args.BeginIndex;
                var take = args.EndIndex - args.BeginIndex + 1;
                var filter = Util.Functions.RemoverAcentos(args.Filter.ToLower());

                var enderecos = NHibernateHttpModule.Session.Query<Endereco>();

                var list = (from endereco in enderecos

                            where (
                                //Cep
                                endereco.Cep.Contains("%" + filter + "%") ||
                                //Logradouro
                                endereco.Nome.Contains("%" + filter + "%") 
                                //Bairro
                                //endereco.Bairro.Nome.Contains("%" + filter + "%") ||
                                //Cidade
                                //endereco.Cidade.Nome.Contains("%" + filter + "%") ||
                                //Estado
                                //endereco.Cidade.Estado.Nome.Contains("%" + filter + "%")

                                )
                            orderby endereco.Nome
                            select endereco).OrderBy(x => x.Nome).Skip(skip).Take(take);


                return list.ToList();
            }

            return null;
        }

        public static object GetEnderecoById(ListEditItemRequestedByValueEventArgs args)
        {
            if (args.Value != null)
            {
                var id = (int)args.Value;
                return GetList().Where(x => x.Id == id).Take(1);
            }
            return null;
        }
    }
}