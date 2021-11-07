using System.Windows;
using DevExpress.Xpf.Core;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDk5ODE1QDMxMzkyZTMyMmUzMEJGcU80NFlWUTBpWlJXRjhSTGxxWU9sVjYvWCtvUjRBbGlhRHJBM1VmLzg9");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DXSplashScreen.Show<SplashScreenStart>();
        }
    }
}
