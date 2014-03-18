using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Erp.Model;

namespace Erp.View.Forms
{
    public class FormDefaultActions
    {
        private DXWindow Window { get; set; }
        public bool IsEnableShortcuts { get; set; }
        private ModelFormBase Model
        {
            get { return (ModelFormBase)Window.DataContext; }
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
                if (IsEnableShortcuts)
                {
                    switch (e.Key)
                    {

                        case Key.F5:
                            Model.Pesquisar();
                            break;
                        case Key.F6:
                            Model.Salvar();
                            break;
                        case Key.F7:
                            Model.Excluir();
                            break;
                        case Key.F4:
                            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                            {
                                Model.Sair();
                            }
                            break;
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
