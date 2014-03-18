using System;
using System.Collections.Generic;
using System.Windows.Input;
using AutoMapper;
using Erp.Business;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Model.Grids;
using Util.Wpf;

namespace Erp.Model.Extras
{
    public class AtualizacaoProdutoFormModel : ProdutoSelectModel
    {
        #region Commands

        public ICommand CmdDesfazer { get { return new RelayCommandBase(x => Desfazer()); } }
        public ICommand CmdSalvar { get { return new RelayCommandBase(x => Salvar()); } }



        #endregion

        #region Keys

        public KeyGesture KeyDesfazer { get { return new KeyGesture(Key.F7, ModifierKeys.Control); } }
        public KeyGesture KeySalvar { get { return new KeyGesture(Key.F6); } }

        public override KeyGesture KeySair
        {
            get { return new KeyGesture(Key.F4, ModifierKeys.Control); }
        }

        #endregion

        #region Métodos de ação

        private void Salvar()
        {
            try
            {


                foreach (var produto in Collection)
                {
                    try
                    {
                        if (IsValid(produto))
                        {
                            var prod = ProdutoRepository.GetById(produto.Id);
                            Mapper.CreateMap(typeof (Produto), typeof (Produto));
                            Mapper.Map(produto, prod);
                            ProdutoRepository.SaveOrUpdate(prod);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format("O produto {0} contém o seguinte erro. \n\n {1}", produto.Descricao, ex.Message));
                    }
                }
                
            }
            catch (Exception ex)
            {
                
                MensagemErroBancoDados(ex.Message);
            }
            Collection.Clear();
        }
        private void Desfazer()
        {
            Filtrar();
        }

        #endregion
    }
}
