using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Erp.Model;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace Erp.View.Forms
{
    public class FormDefaultActions<T> where T : new()
    {
        private DXWindow Window { get; set; }
        public bool IsEnableShortcuts { get; set; }
        private ModelFormGeneric<T> Model
        {
            get { return (ModelFormGeneric<T>)Window.DataContext; }
        }

        public FormDefaultActions(DXWindow window)
        {
            IsEnableShortcuts = true;
            Window = window;
            window.PreviewKeyDown += window_PreviewKeyDown;
            window.ShowInTaskbar = true;
            window.WindowStyle = WindowStyle.ToolWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ResizeMode = ResizeMode.NoResize;

            // Adiciona o contexto do modelo do formulário à tela de pesquisa.
            Model.ModelSelect.WindowSelect.DataContext = Model.ModelSelect;

            Model.Fechar += Model_Fechar;

        }

        void Model_Fechar(object sender, EventArgs e)
        {
            Window.Close();
        }


        void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    var ue = Keyboard.FocusedElement as UIElement;
                    if (ue != null)
                    {
                        ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                    //var element = Window.PredictFocus(FocusNavigationDirection.Next);
                    //if (Window.Tag != null && Window.Tag.ToString().Equals("IgnoreEnterKeyTraversal"))
                    //{
                    //    //ignore
                    //}
                    //else
                    //{
                    //    e.Handled = true;
                    //    Window.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    //}
                }
                if (IsEnableShortcuts)
                {
                    switch (e.Key)
                    {

                        case Key.F5:
                            if (Model.IsPesquisar)
                            {
                                Model.Pesquisar();
                            }
                            
                            break;
                        case Key.F6:
                            if (Model.IsSalvar)
                            {
                                Model.Salvar();
                            }
                            break;
                        case Key.F7:
                            if (Model.IsExcluir)
                            {
                                Model.Excluir();
                            }
                            break;
                        
                            
                    }
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        switch (e.Key)
                        {
                            case Key.F4:
                                Model.Sair();
                                break;
                            case Key.L:
                                if (Model.IsLimpar)
                                {
                                    Model.Limpar();
                                }
                                break;
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                ModelBase.MensagemErro(ex.Message);
            }

        }
    }
}
