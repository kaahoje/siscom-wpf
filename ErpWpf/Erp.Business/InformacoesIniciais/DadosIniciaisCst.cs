using System;
using System.IO;
using Erp.Business.Entity.Sped;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisCst
    {
        public static void Inicio(ISession session)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "arquivos\\";

            var arqCstIcms = new StreamReader(path + "cstIcms.txt");
            var arqCstPis = new StreamReader(path + "cstPis.txt");
            var arqCstCofins = new StreamReader(path + "cstCofins.txt");
            string lineCstIcms = "";
            string lineCstPis = "";
            string lineCstCofins = "";
            while (lineCstIcms != null)
            {
                lineCstIcms = arqCstIcms.ReadLine();
                if (lineCstIcms != null && !lineCstIcms.Equals(""))
                {
                    string[] split = lineCstIcms.Split(';');
                    var cst = new Cst
                    {
                        Codigo = split[0],
                        Descricao = "'" + split[1] + "'",
                        Origem = split[0].Substring(0, 1)
                    };
                    session.Save(cst);
                }
            }
            while (lineCstPis != null)
            {
                lineCstPis = arqCstPis.ReadLine();
                if (lineCstPis != null && !lineCstPis.Equals(""))
                {
                    string[] split = lineCstPis.Split(';');
                    var cstPis = new CstPis
                    {
                        Cst = split[0],
                        Descricao = "'" + split[1] + "'"
                    };
                    session.Save(cstPis);
                }
            }
            while (lineCstCofins != null)
            {
                lineCstCofins = arqCstCofins.ReadLine();
                if (lineCstCofins != null && !lineCstCofins.Equals(""))
                {
                    string[] split = lineCstCofins.Split(';');
                    var cstCofins = new CstCofins
                    {
                        Codigo = split[0],
                        Descricao = "'" + split[1] + "'"
                    };
                    session.Save(cstCofins);
                }
            }
        }
    }
}