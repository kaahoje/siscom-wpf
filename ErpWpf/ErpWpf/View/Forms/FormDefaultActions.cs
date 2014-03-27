using System;
using System.Windows;
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
            ConfigureWindow(window);
            AddEvents(window);
            
        }

        public virtual void AddEvents(DXWindow window)
        {

            window.PreviewKeyDown += window_PreviewKeyDown;
            window.Loaded += WindowOnLoaded;
            Model.Fechar += Model_Fechar;
        }

        private void WindowOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (!Model.TelaPermitida())
            {
                Window.Close();
                
            }
            
        }


        protected virtual void AddContextModelSelect()
        {
            Model.ModelSelect.WindowSelect.DataContext = Model.ModelSelect;
        }
        protected virtual void ConfigureWindow(DXWindow window)
        {
            window.ShowInTaskbar = true;
            window.WindowStyle = WindowStyle.ToolWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ResizeMode = ResizeMode.NoResize;
        }

        void Model_Fechar(object sender, EventArgs e)
        {
            Window.Close();
        }


        void window_PreviewKeyDown(object sender, KeyEventArgs e)
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
            PreviewKeyDownCalled(e);
        }

        protected virtual void PreviewKeyDownCalled(KeyEventArgs e)
        {
            try
            {
                
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
