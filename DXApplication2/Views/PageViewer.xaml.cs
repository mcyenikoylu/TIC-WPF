using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;

namespace DXApplication2.Views
{
    /// <summary>
    /// Interaction logic for PageViewer.xaml
    /// </summary>
    public partial class PageViewer : Window
    {
        public PageViewer()
        {
            InitializeComponent();
            Stream stream = GetResourceStream(DataAccess._PageViewerFilePath);
            Viewer.DocumentSource = stream;
        }
        static Stream GetResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }
    }
}
