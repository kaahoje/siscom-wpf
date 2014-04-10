using System;
using System.Linq;
using System.Windows;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas;

namespace Erp.Model
{
    
    public class ModelFormGeneric<T> : ModelFormBase where T : new()
    {
        private T _entity;
        private ModelSelectBase _modelSelect;

        public ModelFormGeneric()
        {
            AplicaPermissoes();
        } 

        public virtual T Entity
        {
            get { return _entity; }
            set
            {
                _entity = value; 
                OnPropertyChanged("Entity");
                //AplicaPermissoes();
            }
        }

        protected virtual bool AplicaPermissoes()
        {
            if (App.Usuario == null)
            {
                return false;
            }
            var permissao = GetPermissao();
            if (permissao == null)
            {
                return false;
            }
            if (permissao.Exclui || permissao.Insere || permissao.Pesquisa)
            {
                if (Entity != null)
                {
                    var propId = Entity.GetType().GetProperty("Id");
                    if (propId != null)
                    {
                        if ((int)propId.GetValue(Entity) == 0)
                        {
                            IsExcluir = false;
                            IsSalvar = permissao.Insere;

                            // Verifica a permissão de pesquisa
                            IsPesquisar = permissao.Exclui || permissao.Pesquisa;
                        }
                        else
                        {
                            IsExcluir = permissao.Exclui;
                            IsSalvar = permissao.Edita;
                        }
                    }
                }
                else
                {
                    Entity = new T();

                    // Verifica a permissão de pesquisa
                    IsPesquisar = permissao.Exclui || permissao.Pesquisa;

                    IsSalvar = permissao.Insere;
                    IsExcluir = false;
                }
            }

            return true;
        }

        protected PermissaoFormularioPessoaFisica GetPermissao()
        {
            return App.Usuario.PermissaoFormulario.SingleOrDefault(x => x.Formulario == Formulario);
        }

        public ModelSelectBase ModelSelect
        {
            get { return _modelSelect; }
            set
            {
                _modelSelect = value;
                OnPropertyChanged("ModelSelect");
                value.PropertyChanged += value_PropertyChanged;
            }
        }

        void value_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentItem")
            {
                try
                {
                    var prop = ModelSelect.GetType().GetProperty("CurrentItem");
                    if (ModelSelect == null)
                    {
                        return;
                    }
                    var o = (T) prop.GetValue(ModelSelect);
                    if (!(o == null))
                    {
                        Entity = o;
                    }
                    AplicaPermissoes();
                }
                catch (Exception ex)
                {
                    MensagemErro("Erro ao pegar item de pesquisa selecionado. \n" + ex.Message);
                }
                
            }
        }

        public override void Limpar()
        {
            Entity = new T();
            base.Limpar();
        }

        public override void Pesquisar()
        {
            ModelSelect.AbrirPesquisa();
        }
    }
}
