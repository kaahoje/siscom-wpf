﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Sped;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class PlanoContaReferencialLargeDataModel : LargeDataModelGeneric<PlanoContaReferencial>
    {
        public PlanoContaReferencialLargeDataModel()
        {
            try
            {
                Collection = new ObservableCollection<PlanoContaReferencial>();
                Reset();
            }
            catch (Exception)
            {
                
            }
            
        }
        public override void Reset()
        {
            Collection.Clear();
            Collection.AddRange(
                PlanoContaReferencialRepository.GetList().Take(Settings.Default.TakePesquisa));

        }

        public override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(PlanoContaReferencialRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
