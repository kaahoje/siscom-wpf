using System;
using System.Collections.Generic;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
using Erp.Model.Grids;

namespace Erp.Model.Forms
{
    public class ProdutoFormModel : ModelFormGeneric<Produto>
    {
        private IpptDictionary _ipptDictionary;
        private IatDictionary _iatDictionary;
        private OrigemProdutoDictionary _origemProdutoDictionary;

        

        public ProdutoFormModel() 
        {
            Entity = new Produto()
            {
                Ippt = Ippt.Propria,
                Origem = OrigemProduto.Nacional
            };
            ModelSelect = new ProdutoSelectModel();
        }
        public override void Salvar()
        {
            try
            {
                Entity.Iat = Iat.Arredondamento;
                if (IsValid(Entity))
                {
                    ProdutoRepository.Save(Entity);
                    base.Salvar();
                }
                
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    ProdutoRepository.Save(Entity);
                    base.Excluir();
                }
                
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        
        
        #region Listas usadas

        public IList<SubGrupoProduto> SubGrupos
        {
            get { return SubGrupoProdutoRepository.GetList(); }
        }

        public IList<Unidade> Unidades
        {
            get { return UnidadeRepository.GetList(); }
        }

        public IList<Ncm> Ncms
        {
            get { return App.Ncms; }
        }


        
        #endregion
        #region Dictionarys

        public IpptDictionary IpptDictionary
        {
            get { return _ipptDictionary ?? (_ipptDictionary = new IpptDictionary()); }
            set
            {
                _ipptDictionary = value;
                OnPropertyChanged("IpptDictionary");
            }
        }

        public IatDictionary IatDictionary
        {
            get { return _iatDictionary ?? (_iatDictionary = new IatDictionary()); }
            set
            {
                _iatDictionary = value;
                OnPropertyChanged("IatDictionary");
            }
        }

        public OrigemProdutoDictionary OrigemProdutoDictionary
        {
            get { return _origemProdutoDictionary ?? (_origemProdutoDictionary = new OrigemProdutoDictionary()); }
            set
            {
                _origemProdutoDictionary = value;
                OnPropertyChanged("OrigemProdutoDictionary");
            }
        }

        #endregion
    }
}
