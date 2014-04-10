using DevExpress.Xpf.Core;

namespace Erp
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : DXWindow, ISplashScreen
    {
        public Splash()
        {
            InitializeComponent();
        }

        public void Progress(double value)
        {
            
        }

        public void SetProgressState(bool isIndeterminate)
        {
            
        }

        public void CloseSplashScreen()
        {
            Dispatcher.InvokeShutdown();
        }

        
    }
}
