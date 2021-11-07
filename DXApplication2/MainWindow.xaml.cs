using DevExpress.Xpf.Core;
using System.IO;
using System.Windows;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            DataAccess.path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            DataAccess.dbpath = DataAccess.path + "\\" + DataAccess.dbname;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(DXSplashScreen.IsActive)
                DXSplashScreen.Close();

            this.Activate();
        }
    }
}
