using System.Linq;
using DevExpress.Web.ASPxEditors;
using Util;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeSubClasseRepository : RepositoryBase<CnaeSubClasse>
    {
        public static object GetCnaeSubClassRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            var filter = Functions.RemoverAcentos(args.Filter.ToLower());
            
            var list = GetList().Where(x => 
               
                // //Codigo da Seção
                //Util.Functions.RemoverAcentos(x.Classe.Grupo.Divisao.Secao.Codigo.ToLower()).Contains(filter) ||
                
                ////Codigo da Divisao
                //Util.Functions.RemoverAcentos(x.Classe.Grupo.Divisao.Codigo.ToLower()).Contains(filter) ||

                //////Denominação da Divisao
                ////Util.Functions.RemoverAcentos(x.Classe.Grupo.Divisao.Secao.Denominacao.ToLower()).Contains(filter) ||

                ////Codigo do Grupo
                //Util.Functions.RemoverAcentos(x.Classe.Grupo.Codigo.ToLower()).Contains(filter) ||

                // //Codigo da Classe
                //Util.Functions.RemoverAcentos(x.Classe.Codigo.ToLower()).Contains(filter) ||

                //Codigo da SubClasse
                Functions.RemoverAcentos(x.Codigo.ToLower()).Contains(filter) ||
                
                //Denominação da SubClasse
                Functions.RemoverAcentos(x.Denominacao.ToLower()).Contains(filter)
                ).Skip(skip).Take(take);
                 

               return list.OrderBy(y => y.Denominacao).ToList();
        }
        public static object GetCnaeById(ListEditItemRequestedByValueEventArgs args)
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
