using System.Windows;

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
    }
}
