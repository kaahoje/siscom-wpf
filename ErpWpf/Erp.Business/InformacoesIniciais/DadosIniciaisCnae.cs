using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Educacao.Utils.Annotations;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisCnae
    {
        [UsedImplicitly]
        private static CnaeSecao _cnaeSecao = new CnaeSecao();

        [UsedImplicitly]
        private static readonly List<CnaeSecao> ListCnaeSecao = new List<CnaeSecao>();

        [UsedImplicitly]
        private static CnaeDivisao _cnaeDivisao = new CnaeDivisao();

        [UsedImplicitly]
        private static readonly List<CnaeDivisao> ListCnaeDivisao = new List<CnaeDivisao>();

        [UsedImplicitly]
        private static CnaeGrupo _cnaeGrupo = new CnaeGrupo();

        [UsedImplicitly]
        private static readonly List<CnaeGrupo> ListCnaeGrupo = new List<CnaeGrupo>();

        [UsedImplicitly]
        private static CnaeClasse _cnaeClasse = new CnaeClasse();

        [UsedImplicitly]
        private static readonly List<CnaeClasse> ListCnaeClasse = new List<CnaeClasse>();

        private static List<CnaeSubClasse> ListCnaeSubClasse = new List<CnaeSubClasse>();


        public static void SaveCnae()
        {
            var nameProject = Path.GetFileName(Assembly.GetExecutingAssembly().Location).Split('.')[0];
            //var path = AppDomain.CurrentDomain.BaseDirectory.Replace(nameProject, "Util") + "Cnae";
            var path = Environment.CurrentDirectory + "\\Cnae";

            const string fileCnae = @"\CnaeSubClass2_1.xml";
            var pathDocXml = path + fileCnae;

            using (var xml = new XmlTextReader(pathDocXml))
            {
                while (xml.Read())
                {
                    if (xml.IsStartElement())
                    {
                        switch (xml.Name)
                        {
                            case "_x0027_Est":

                                break;
                            case "Cnae":

                                if (xml["name"] != null)
                                {
                                    //SEÇÃO

                                    if (xml["name"] == "Secao")
                                    {
                                        SecaoReader(xml);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        public static void SecaoReader(XmlReader xml, bool saveInList = false)
        {
            if (xml.Read())
            {
                if (saveInList)
                {
                    ListCnaeSecao.Add(_cnaeSecao);
                }

                _cnaeSecao = new CnaeSecao { Codigo = xml.Value.Trim() };

                while (xml.Read())
                {
                    RouteCnae(xml);

                    if (xml["name"] == "Denominacao")
                    {
                        if (xml.Read())
                        {
                            var denominacao = xml.Value.Trim();
                            _cnaeSecao.Denominacao = denominacao;
                        }
                    }
                }
            }
        }

        public static void DivisaoReader(XmlReader xml)
        {
            if (xml.Read())
            {
                _cnaeDivisao = new CnaeDivisao { Codigo = xml.Value.Trim() };

                while (xml.Read())
                {
                    RouteCnae(xml);

                    if (xml["name"] == "Denominacao")
                    {
                        if (xml.Read())
                        {
                            _cnaeDivisao.Denominacao = xml.Value.Trim();
                        }
                        _cnaeDivisao.Secao = _cnaeSecao;

                        ListCnaeDivisao.Add(_cnaeDivisao);
                    }
                }
            }
        }

        public static void GrupoReader(XmlReader xml)
        {
            if (xml.Read())
            {
                _cnaeGrupo = new CnaeGrupo { Codigo = xml.Value.Trim() };

                while (xml.Read())
                {
                    RouteCnae(xml);

                    if (xml["name"] == "Denominacao")
                    {
                        if (xml.Read())
                        {
                            _cnaeGrupo.Denominacao = xml.Value.Trim();
                        }

                        _cnaeGrupo.Divisao = _cnaeDivisao;

                        ListCnaeGrupo.Add(_cnaeGrupo);
                    }
                }
            }
        }

        public static void ClassReader(XmlReader xml)
        {
            if (xml.Read())
            {
                _cnaeClasse = new CnaeClasse { Codigo = xml.Value.Trim() };

                while (xml.Read())
                {
                    RouteCnae(xml);

                    if (xml["name"] == "Denominacao")
                    {
                        if (xml.Read())
                        {
                            _cnaeClasse.Denominacao = xml.Value.Trim();
                        }

                        _cnaeClasse.Grupo = _cnaeGrupo;

                        ListCnaeClasse.Add(_cnaeClasse);
                    }
                }
            }
        }

        public static void SubClasseReader(XmlReader xml)
        {
            if (xml.Read())
            {
                var cnaeSubClasse = new CnaeSubClasse { Codigo = xml.Value.Trim() };

                while (xml.Read())
                {
                    RouteCnae(xml);

                    if (xml["name"] == "Denominacao")
                    {
                        if (xml.Read())
                        {
                            cnaeSubClasse.Denominacao = xml.Value.Trim();
                        }

                        cnaeSubClasse.Classe = _cnaeClasse;

                        ListCnaeSubClasse.Add(cnaeSubClasse);
                        break;
                    }
                }
            }

        }

        public static void RouteCnae(XmlReader xml)
        {
            if (xml["name"] == "Secao")
            {
                SecaoReader(xml, true);
            }

            if (xml["name"] == "Divisao")
            {
                DivisaoReader(xml);
            }

            if (xml["name"] == "Grupo")
            {
                GrupoReader(xml);
            }

            if (xml["name"] == "Class")
            {
                ClassReader(xml);
            }

            if (xml["name"] == "SubClass")
            {
                SubClasseReader(xml);
            }

            if (xml["name"] == "FinalLeitura")
            {
                SaveCnaes();
            }
        }

        public static bool SaveCnaes()
        {
            try
            {
                foreach (var cnaeSecao in ListCnaeSecao)
                {
                    CnaeSecaoRepository.Save(cnaeSecao);
                }
                foreach (var cnaeDivisao in ListCnaeDivisao)
                {
                    CnaeDivisaoRepository.Save(cnaeDivisao);
                }
                foreach (var cnaeGrupo in ListCnaeGrupo)
                {
                    CnaeGrupoRepository.Save(cnaeGrupo);
                }
                foreach (var cnaeClasse in ListCnaeClasse)
                {
                    CnaeClasseRepository.Save(cnaeClasse);
                }

                for (var i = 0; i < ListCnaeSubClasse.Count - 1; i++)
                {
                    CnaeSubClasseRepository.Save(ListCnaeSubClasse[i]);
                }


                return true;
            }
            catch (Exception ex)
            {
                var exMessage = ex.Message;
                return false;
            }

        }

    }
}



