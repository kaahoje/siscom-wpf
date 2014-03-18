using System;

namespace Erp.Model
{
    public class ModelFormGeneric<T> : ModelFormBase where T : new()
    {
        private T _entity;
        private ModelSelectGeneric<T> _modelSelect;
        public T Entity
        {
            get { return _entity; }
            set
            {
                _entity = value; 
                OnPropertyChanged("Entity");
            }
        }
        public ModelSelectGeneric<T> ModelSelect
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
                    Entity = (T) prop.GetValue(ModelSelect);
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
