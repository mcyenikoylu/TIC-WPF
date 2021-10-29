using DevExpress.Xpf.Core;
using System.IO;

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
            DataAccess.path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            DataAccess.dbpath = DataAccess.path + "\\" + DataAccess.dbname;
        }
    }
}
