using System;
using System.Windows.Input;
using AutoMapper;
using Erp.Business;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Model.Grids;
using NHibernate;
using Util.Wpf;

namespace Erp.Model.Extras
{
    public class AtualizacaoProdutoFormModel : ProdutoSelectModel
    {

        public AtualizacaoProdutoFormModel()
        {
            
        }

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
                NHibernateHttpModule.Session.FlushMode = FlushMode.Commit;
                foreach (var produto in Collection)
                {
                    var prod = ProdutoRepository.GetById(produto.Id);
                    Mapper.CreateMap(prod.GetType(), prod.GetType());
                    Mapper.Map(produto, prod);
                    ProdutoRepository.Save(prod);
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
