using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Erp.Model;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace Erp.View.Selections
{
    public class SelectionDefaultActions
    {
        private DXWindow Window { get; set; }

        private ModelSelectBase Model
        {
            get { return (ModelSelectBase)Window.DataContext; }
        }
        public Control FilterControl { get; set; }

        public SelectionDefaultActions(DXWindow window, Control filterControl)
        {
            Window = window;
            window.PreviewKeyDown += window_PreviewKeyDown;
            window.IsVisibleChanged += window_IsVisibleChanged;
            window.ShowInTaskbar = true;
            window.WindowStyle = WindowStyle.ToolWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ResizeMode = ResizeMode.NoResize;
           
            CreateBindings();
            FilterControl = filterControl;
            filterControl.Focus();
        }

        void window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                FilterControl.Focus();
            }
        }

        private void CreateBindings()
        {
            var bindVisibility = new Binding("IsVisible") {Source = Model};
            Window.SetBinding(UIElement.VisibilityProperty, bindVisibility);
        }

        void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.Up:
                        Model.MovePrevious();
                        break;
                    case Key.Down:
                        Model.MoveNext();
                        break;
                    case Key.Escape:
                        Model.CancelarPesquisa();
                        
                        if (Model.IsVisible == Visibility.Hidden)
                        {
                            Window.Hide();
                        }
                        break;
                    case Key.Enter:
                        Model.Selecionar();
                        if (Model.IsVisible == Visibility.Hidden)
                        {
                            Window.Hide();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelBase.MensagemErro(ex.Message);
            }

        }

    }
}
