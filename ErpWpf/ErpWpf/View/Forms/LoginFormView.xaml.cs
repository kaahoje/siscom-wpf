using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for LoginFormView.xaml
    /// </summary>
    public partial class LoginFormView
    {
        
        public LoginFormView()
        {
            InitializeComponent();
            txtUsuario.Focus();

        }

        
        private void LoginFormView_OnClosing(object sender, CancelEventArgs e)
        {
            if (App.Usuario == null)
            {
                e.Cancel = true;
            }
        }

        private void LoginFormView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var ue = Keyboard.FocusedElement as UIElement;
                if (ue != null)
                {
                    ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
                
            }
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            Process.GetCurrentProcess().Kill();
        }
    }
}
