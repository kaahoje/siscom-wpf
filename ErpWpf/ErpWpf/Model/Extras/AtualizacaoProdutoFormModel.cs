using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
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
            get { return new KeyGesture(Key.F4,ModifierKeys.Control); }
        }

        #endregion

        #region Métodos de ação

        private void Salvar()
        {
            var listRemove = new List<Produto>();
            var sucess = true;
            try
            {
                foreach (var produto in Collection)
                {
                    try
                    {
                        if (IsValid(produto))
                        {
                            ProdutoRepository.Save(produto);
                            listRemove.Add(produto);
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
                sucess = false;
                MensagemErroBancoDados(ex.Message);
            }
            foreach (var produto in listRemove)
            {
                Collection.Remove(produto);
            }
            if (sucess)
            {
                MensagemInformativa("Os produtos foram salvos com sucesso.");
            }
        }
        private void Desfazer()
        {
            Filtrar();
        }

        #endregion
    }
}
