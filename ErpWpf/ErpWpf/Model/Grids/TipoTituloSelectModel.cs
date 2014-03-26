﻿using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class TipoTituloSelectModel : ModelSelectGeneric<TipoTitulo>
    {
        public TipoTituloSelectModel()
        {
            Collection = new ObservableCollection<TipoTitulo>();
            WindowSelect = new TipoTituloSelectView();
            WindowSelect.DataContext = this;
        }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(TipoTituloRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
