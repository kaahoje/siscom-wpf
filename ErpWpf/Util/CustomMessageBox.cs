using System.Windows;
using DevExpress.Xpf.Core;

namespace Util
{
    public class CustomMessageBox
    {
        public static MessageBoxResult MensagemConfirmacao(string mensagem)
        {
            return DXMessageBox.Show(mensagem,"Atenção",MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.Yes);
        }
        public static void MensagemErro(string mensagem)
        {
            DXMessageBox.Show(mensagem, "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        public static void MensagemInformativa(string mensagem)
        {
            DXMessageBox.Show(mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void MensagemCritica(string mensagem)
        {
            DXMessageBox.Show(mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MensagemErroBancoDados(string mensagem)
        {
            DXMessageBox.Show(mensagem, "Erro com operação no banco", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
