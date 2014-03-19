using System;
using System.Windows.Forms;
using DevExpress.Skins;
using Ecf.Forms;

namespace Ecf
{
    static class Program
    {
        //private static ConfTerminal _terminal;

        //public static ConfTerminal Terminal
        //{
        //    get
        //    {
        //        if (_terminal == null)
        //        {
        //            _terminal = ConfTerminalRepository.GetByChave(ConfigurationManager.AppSettings["IdAplicacao"]);
        //        }
        //        return _terminal;
        //    }
        //    set { _terminal = value; }
        //}
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkinManager.EnableFormSkins();
            //DevExpress.UserSkins.BonusSkins.Register();
            
            //UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.Skin);

            Application.Run(new FormMenuFiscal(FormMenuFiscal.MenuFiscalTipo.Auditoria));
        }
    }
}