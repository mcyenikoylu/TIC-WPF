using DevExpress.Xpf.Core;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.UI.Popups;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                //LoadingIndicator.IsActive = true;
                DXSplashScreen.Show<SplashScreenLoading>();

                DateTime dt = Convert.ToDateTime(dataPicket1.EditValue);

                string fileNotesFolderPath = @"C:\tic\FileNotes";
                DataAccess.AddDataCoverPage(txtPreparedFor.Text, txtYourAdviser.Text, dt, "", fileNotesFolderPath);

                fileNoteSave(fileNotesFolderPath);
            }
            catch (Exception ex)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
            finally
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();

                MessageBoxResult result = DXMessageBox.Show("Cover Page data saved successfully.", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void fileNoteSave(string fileNotesFolderPath)
        {
            StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(fileNotesFolderPath);

            string fileName = "FileNotesCoverPage_" + DataAccess._CoverPageID;
            var file = await storageFolder.CreateFileAsync(fileName + ".jpg", CreationCollisionOption.ReplaceExisting);

            FileStream fs = new FileStream(fileNotesFolderPath + "//" + fileName + ".jpg", FileMode.Create);

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)myInkCanvas.ActualWidth, (int)myInkCanvas.ActualHeight, 96d, 96d, PixelFormats.Default);
            rtb.Render(myInkCanvas);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            encoder.Save(fs);
            fs.Close();
        }

        private void BtnNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = DXMessageBox.Show("All fields will be cleared. Do you confirm?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)

                //var dialog = new MessageDialog("All fields will be cleared. Do you confirm?", "Question");
                //dialog.Commands.Add(new UICommand("Yes", null));
                //dialog.Commands.Add(new UICommand("No", null));
                //dialog.DefaultCommandIndex = 0;
                //dialog.CancelCommandIndex = 1;
                //var result = await dialog.ShowAsync();

                //if (result.Label == "Yes")
                {
                    //LoadingIndicator.IsActive = true;
                    // do something
                    DataAccess._CoverPageID = 0;
                    txtPreparedFor.Text = "";
                    txtYourAdviser.Text = "";
                    dataPicket1.EditValue = null;
                    myInkCanvas.Strokes.Clear();
                    //myInkCanvas.InkPresenter.StrokeContainer.Clear();
                    //txtPreparedFor.Focus(FocusState.Keyboard);
                    txtPreparedFor.Focus();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                //LoadingIndicator.IsActive = false;
            }
        }

        private void BtnPDF_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                DXSplashScreen.Show<SplashScreenLoading>();
                LongOperationAsync();
            }
            catch (Exception ex)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
            finally
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();

                MessageBoxResult result = DXMessageBox.Show("The document has been created. Do you want to view the document?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Views.PageViewer win = new Views.PageViewer();
                    win.ShowDialog();
                }
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataAccess._CoverPageID > 0)
            {
                DataTable dt = DataAccess.getCoverPageData(DataAccess._CoverPageID);
                if (dt.Rows.Count > 0)
                {
                    DXSplashScreen.Show<SplashScreenLoading>();

                    DateTime dDated = new DateTime();
                    dDated = Convert.ToDateTime(dt.Rows[0].ItemArray[3].ToString());

                    txtPreparedFor.Text = dt.Rows[0].ItemArray[1].ToString();
                    txtYourAdviser.Text = dt.Rows[0].ItemArray[2].ToString();
                    dataPicket1.EditValue = dDated;

                    ////////BitmapImage bitImg = new BitmapImage(new Uri("", UriKind.Absolute));
                    ////FileStream fs = null;
                    ////fs = new FileStream(dt.Rows[0].ItemArray[5].ToString()+"\\"+dt.Rows[0].ItemArray[4].ToString(), FileMode.Open, FileAccess.Read);
                    ////StrokeCollection strokes = new StrokeCollection(fs);
                    ////myInkCanvas.Strokes = strokes;

                    ////Bitmap bitmap = new Bitmap(dt.Rows[0].ItemArray[5].ToString() + "\\" + dt.Rows[0].ItemArray[4].ToString());
                    ////BitmapImage bitImg = new BitmapImage(new Uri(dt.Rows[0].ItemArray[5].ToString() + "\\" + dt.Rows[0].ItemArray[4].ToString(), UriKind.Absolute));

                    ////myInkCanvas.
                    //string file = dt.Rows[0].ItemArray[5].ToString() + "\\" + dt.Rows[0].ItemArray[4].ToString();
                    //Canvas canvas = new Canvas { Width = myInkCanvas.ActualWidth, Height = myInkCanvas.ActualHeight };
                    //System.Windows.Controls.Image image = new System.Windows.Controls.Image
                    //{
                    //    Width = myInkCanvas.ActualWidth,
                    //    Height = myInkCanvas.ActualHeight,
                    //    Source = new BitmapImage(new Uri(file, UriKind.Relative))

                    //};
                    //myInkCanvas.Children.Add(canvas);
                    //canvas.Children.Add(image);
                    //Canvas.SetTop(image, 50);
                    //Canvas.SetLeft(image, 50);

                    ////using (FileStream filex = new FileStream(file,
                    ////                            FileMode.Create, FileAccess.Write))
                    ////{
                    ////    myInkCanvas.Strokes.Save(filex);
                    ////    filex.Close();
                    ////}
                    
                    if (DXSplashScreen.IsActive)
                        DXSplashScreen.Close();
                }
            }
        }

        private void LongOperationAsync()
        {
            // Create a new document.
            DataTable dt = DataAccess.getCoverPageData(DataAccess._CoverPageID);
            string fileName = dt.Rows[0].ItemArray[1].ToString() + "_" + DataAccess._CoverPageID.ToString();

            string filePathName = @"C:\tic\Documents\" + fileName + ".docx";
            string templatePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "") + @"\temp.docx";

            //using (var document = DocX.Create(filePathName))
            //{
            if (dt.Rows.Count > 0)
            {
                using (WordDocument document = new WordDocument())
                {
                    //Opens the input Word document.
                    Stream docStream = File.OpenRead(Path.GetFullPath(templatePath));
                    document.Open(docStream, FormatType.Docx);
                    docStream.Dispose();

                    #region cover page
                    DateTime dDated = new DateTime();
                    dDated = Convert.ToDateTime(dt.Rows[0].ItemArray[3].ToString());

                    //Finds all occurrences of a misspelled word and replaces with properly spelled word.
                    document.Replace("{preparedfor}", dt.Rows[0].ItemArray[1].ToString(), true, true);
                    document.Replace("{youradviser}", dt.Rows[0].ItemArray[2].ToString(), true, true);
                    document.Replace("{dated}", dDated.ToShortDateString(), true, true);
                    #endregion

                    #region Selection A
                    DataTable dt2 = DataAccess.getSelectionAPersonalDetails(DataAccess._CoverPageID);
                    if (dt2.Rows.Count > 0)
                    {
                        document.Replace("{SurnameMaidenName_Client1}", dt2.Rows[0].ItemArray[2].ToString(), true, true);
                        document.Replace("{SurnameMaidenName_Client2}", dt2.Rows[0].ItemArray[3].ToString(), true, true);
                        document.Replace("{Givennames_Client1}", dt2.Rows[0].ItemArray[4].ToString(), true, true);
                        document.Replace("{Givennames_Client2}", dt2.Rows[0].ItemArray[5].ToString(), true, true);
                        document.Replace("{Preferredshortname_Client1}", dt2.Rows[0].ItemArray[6].ToString(), true, true);
                        document.Replace("{Preferredshortname_Client2}", dt2.Rows[0].ItemArray[7].ToString(), true, true);
                        document.Replace("{TitleMrMrsMsSirDr_Client1}", dt2.Rows[0].ItemArray[8].ToString(), true, true);
                        document.Replace("{TitleMrMrsMsSirDr_Client2}", dt2.Rows[0].ItemArray[9].ToString(), true, true);

                        int gender_client1 = 0;
                        gender_client1 = dt2.Rows[0].ItemArray[10] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[10]) : 0;
                        if (gender_client1 == 1)
                        {
                            document.Replace("gM1", "X", true, true);
                            document.Replace("gF1", " ", true, true);
                        }
                        else if (gender_client1 == 2)
                        {
                            document.Replace("gM1", " ", true, true);
                            document.Replace("gF1", "X", true, true);
                        }
                        else
                        {
                            document.Replace("gM1", " ", true, true);
                            document.Replace("gF1", " ", true, true);
                        }

                        int gender_client2 = 0;
                        gender_client2 = dt2.Rows[0].ItemArray[11] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[11]) : 0;
                        if (gender_client2 == 1)
                        {
                            document.Replace("gM2", "X", true, true);
                            document.Replace("gF2", " ", true, true);
                        }
                        else if (gender_client2 == 2)
                        {
                            document.Replace("gM2", " ", true, true);
                            document.Replace("gF2", "X", true, true);
                        }
                        else
                        {
                            document.Replace("gM2", " ", true, true);
                            document.Replace("gF2", " ", true, true);
                        }

                        DateTime DateOfBirth_Client1 = dt2.Rows[0].ItemArray[12] != DBNull.Value ? Convert.ToDateTime(dt2.Rows[0].ItemArray[12]) : Convert.ToDateTime("1900-01-01");
                        DateTime DateOfBirth_Client2 = dt2.Rows[0].ItemArray[13] != DBNull.Value ? Convert.ToDateTime(dt2.Rows[0].ItemArray[13]) : Convert.ToDateTime("1900-01-01");

                        if (DateOfBirth_Client1 != Convert.ToDateTime("1900-01-01"))
                        {
                            string[] d = DateOfBirth_Client1.ToShortDateString().Split('/');
                            string dd = d[0];
                            string mm = d[1];
                            string yyyy = d[2];

                            document.Replace("d11", dd.Substring(0, 1), true, true);
                            document.Replace("d12", dd.Substring(1, 1), true, true);
                            document.Replace("d13", mm.Substring(0, 1), true, true);
                            document.Replace("d14", mm.Substring(1, 1), true, true);
                            document.Replace("d15", yyyy.Substring(0, 1), true, true);
                            document.Replace("d16", yyyy.Substring(1, 1), true, true);
                            document.Replace("d17", yyyy.Substring(2, 1), true, true);
                            document.Replace("d18", yyyy.Substring(3, 1), true, true);

                        }
                        else
                        {
                            document.Replace("d11", " ", true, true);
                            document.Replace("d12", " ", true, true);
                            document.Replace("d13", " ", true, true);
                            document.Replace("d14", " ", true, true);
                            document.Replace("d15", " ", true, true);
                            document.Replace("d16", " ", true, true);
                            document.Replace("d17", " ", true, true);
                            document.Replace("d18", " ", true, true);
                        }

                        if (DateOfBirth_Client2 != Convert.ToDateTime("1900-01-01"))
                        {
                            string[] d = DateOfBirth_Client2.ToShortDateString().Split('/');
                            string dd = d[0];
                            string mm = d[1];
                            string yyyy = d[2];

                            document.Replace("d21", dd.Substring(0, 1), true, true);
                            document.Replace("d22", dd.Substring(1, 1), true, true);
                            document.Replace("d23", mm.Substring(0, 1), true, true);
                            document.Replace("d24", mm.Substring(1, 1), true, true);
                            document.Replace("d25", yyyy.Substring(0, 1), true, true);
                            document.Replace("d26", yyyy.Substring(1, 1), true, true);
                            document.Replace("d27", yyyy.Substring(2, 1), true, true);
                            document.Replace("d28", yyyy.Substring(3, 1), true, true);

                        }
                        else
                        {
                            document.Replace("d21", " ", true, true);
                            document.Replace("d22", " ", true, true);
                            document.Replace("d23", " ", true, true);
                            document.Replace("d24", " ", true, true);
                            document.Replace("d25", " ", true, true);
                            document.Replace("d26", " ", true, true);
                            document.Replace("d27", " ", true, true);
                            document.Replace("d28", " ", true, true);
                        }

                        int Age_Client1 = dt2.Rows[0].ItemArray[14] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[14]) : 0;
                        int Age_Client2 = dt2.Rows[0].ItemArray[15] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[15]) : 0;

                        if (Age_Client1 != 0)
                            document.Replace("{Age_Client1}", Age_Client1.ToString(), true, true);
                        else
                            document.Replace("{Age_Client1}", " ", true, true);

                        if (Age_Client2 != 0)
                            document.Replace("{Age_Client2}", Age_Client2.ToString(), true, true);
                        else
                            document.Replace("{Age_Client2}", " ", true, true);

                        int Maritalstatus_Client1 = dt2.Rows[0].ItemArray[16] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[16]) : 0;
                        int Maritalstatus_Client2 = dt2.Rows[0].ItemArray[17] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[17]) : 0;

                        if (Maritalstatus_Client1 != 0)
                        {
                            switch (Maritalstatus_Client1)
                            {
                                case 1:
                                    document.Replace("M11", "X", true, true);
                                    document.Replace("M12", " ", true, true);
                                    document.Replace("M13", " ", true, true);
                                    document.Replace("M14", " ", true, true);
                                    document.Replace("M15", " ", true, true);
                                    document.Replace("M16", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("M11", " ", true, true);
                                    document.Replace("M12", "X", true, true);
                                    document.Replace("M13", " ", true, true);
                                    document.Replace("M14", " ", true, true);
                                    document.Replace("M15", " ", true, true);
                                    document.Replace("M16", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("M11", " ", true, true);
                                    document.Replace("M12", " ", true, true);
                                    document.Replace("M13", "X", true, true);
                                    document.Replace("M14", " ", true, true);
                                    document.Replace("M15", " ", true, true);
                                    document.Replace("M16", " ", true, true);
                                    break;
                                case 4:
                                    document.Replace("M11", " ", true, true);
                                    document.Replace("M12", " ", true, true);
                                    document.Replace("M13", " ", true, true);
                                    document.Replace("M14", "X", true, true);
                                    document.Replace("M15", " ", true, true);
                                    document.Replace("M16", " ", true, true);
                                    break;
                                case 5:
                                    document.Replace("M11", " ", true, true);
                                    document.Replace("M12", " ", true, true);
                                    document.Replace("M13", " ", true, true);
                                    document.Replace("M14", " ", true, true);
                                    document.Replace("M15", "X", true, true);
                                    document.Replace("M16", " ", true, true);
                                    break;
                                case 6:
                                    document.Replace("M11", " ", true, true);
                                    document.Replace("M12", " ", true, true);
                                    document.Replace("M13", " ", true, true);
                                    document.Replace("M14", " ", true, true);
                                    document.Replace("M15", " ", true, true);
                                    document.Replace("M16", "X", true, true);
                                    break;
                                default:
                                    document.Replace("M11", " ", true, true);
                                    document.Replace("M12", " ", true, true);
                                    document.Replace("M13", " ", true, true);
                                    document.Replace("M14", " ", true, true);
                                    document.Replace("M15", " ", true, true);
                                    document.Replace("M16", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("M11", " ", true, true);
                            document.Replace("M12", " ", true, true);
                            document.Replace("M13", " ", true, true);
                            document.Replace("M14", " ", true, true);
                            document.Replace("M15", " ", true, true);
                            document.Replace("M16", " ", true, true);
                        }

                        if (Maritalstatus_Client2 != 0)
                        {
                            switch (Maritalstatus_Client2)
                            {
                                case 1:
                                    document.Replace("M21", "X", true, true);
                                    document.Replace("M22", " ", true, true);
                                    document.Replace("M23", " ", true, true);
                                    document.Replace("M24", " ", true, true);
                                    document.Replace("M25", " ", true, true);
                                    document.Replace("M26", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("M21", " ", true, true);
                                    document.Replace("M22", "X", true, true);
                                    document.Replace("M23", " ", true, true);
                                    document.Replace("M24", " ", true, true);
                                    document.Replace("M25", " ", true, true);
                                    document.Replace("M26", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("M21", " ", true, true);
                                    document.Replace("M22", " ", true, true);
                                    document.Replace("M23", "X", true, true);
                                    document.Replace("M24", " ", true, true);
                                    document.Replace("M25", " ", true, true);
                                    document.Replace("M26", " ", true, true);
                                    break;
                                case 4:
                                    document.Replace("M21", " ", true, true);
                                    document.Replace("M22", " ", true, true);
                                    document.Replace("M23", " ", true, true);
                                    document.Replace("M24", "X", true, true);
                                    document.Replace("M25", " ", true, true);
                                    document.Replace("M26", " ", true, true);
                                    break;
                                case 5:
                                    document.Replace("M21", " ", true, true);
                                    document.Replace("M22", " ", true, true);
                                    document.Replace("M23", " ", true, true);
                                    document.Replace("M24", " ", true, true);
                                    document.Replace("M25", "X", true, true);
                                    document.Replace("M26", " ", true, true);
                                    break;
                                case 6:
                                    document.Replace("M21", " ", true, true);
                                    document.Replace("M22", " ", true, true);
                                    document.Replace("M23", " ", true, true);
                                    document.Replace("M24", " ", true, true);
                                    document.Replace("M25", " ", true, true);
                                    document.Replace("M26", "X", true, true);
                                    break;
                                default:
                                    document.Replace("M21", " ", true, true);
                                    document.Replace("M22", " ", true, true);
                                    document.Replace("M23", " ", true, true);
                                    document.Replace("M24", " ", true, true);
                                    document.Replace("M25", " ", true, true);
                                    document.Replace("M26", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("M21", " ", true, true);
                            document.Replace("M22", " ", true, true);
                            document.Replace("M23", " ", true, true);
                            document.Replace("M24", " ", true, true);
                            document.Replace("M25", " ", true, true);
                            document.Replace("M26", " ", true, true);
                        }

                        int Health_Client1 = dt2.Rows[0].ItemArray[18] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[18]) : 0;
                        int Health_Client2 = dt2.Rows[0].ItemArray[19] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[19]) : 0;

                        if (Health_Client1 != 0)
                        {
                            switch (Health_Client1)
                            {
                                case 1:
                                    document.Replace("H11", "X", true, true);
                                    document.Replace("H12", " ", true, true);
                                    document.Replace("H13", " ", true, true);
                                    document.Replace("H14", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("H11", " ", true, true);
                                    document.Replace("H12", "X", true, true);
                                    document.Replace("H13", " ", true, true);
                                    document.Replace("H14", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("H11", " ", true, true);
                                    document.Replace("H12", " ", true, true);
                                    document.Replace("H13", "X", true, true);
                                    document.Replace("H14", " ", true, true);
                                    break;
                                case 4:
                                    document.Replace("H11", " ", true, true);
                                    document.Replace("H12", " ", true, true);
                                    document.Replace("H13", " ", true, true);
                                    document.Replace("H14", "X", true, true);
                                    break;
                                default:
                                    document.Replace("H11", " ", true, true);
                                    document.Replace("H12", " ", true, true);
                                    document.Replace("H13", " ", true, true);
                                    document.Replace("H14", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("H11", " ", true, true);
                            document.Replace("H12", " ", true, true);
                            document.Replace("H13", " ", true, true);
                            document.Replace("H14", " ", true, true);
                        }

                        if (Health_Client2 != 0)
                        {
                            switch (Health_Client2)
                            {
                                case 1:
                                    document.Replace("H21", "X", true, true);
                                    document.Replace("H22", " ", true, true);
                                    document.Replace("H23", " ", true, true);
                                    document.Replace("H24", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("H21", " ", true, true);
                                    document.Replace("H22", "X", true, true);
                                    document.Replace("H23", " ", true, true);
                                    document.Replace("H24", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("H21", " ", true, true);
                                    document.Replace("H22", " ", true, true);
                                    document.Replace("H23", "X", true, true);
                                    document.Replace("H24", " ", true, true);
                                    break;
                                case 4:
                                    document.Replace("H21", " ", true, true);
                                    document.Replace("H22", " ", true, true);
                                    document.Replace("H23", " ", true, true);
                                    document.Replace("H24", "X", true, true);
                                    break;
                                default:
                                    document.Replace("H21", " ", true, true);
                                    document.Replace("H22", " ", true, true);
                                    document.Replace("H23", " ", true, true);
                                    document.Replace("H24", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("H21", " ", true, true);
                            document.Replace("H22", " ", true, true);
                            document.Replace("H23", " ", true, true);
                            document.Replace("H24", " ", true, true);
                        }

                        int Smoker_Client1 = dt2.Rows[0].ItemArray[20] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[20]) : 0;
                        int Smoker_Client2 = dt2.Rows[0].ItemArray[21] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[21]) : 0;

                        if (Smoker_Client1 != 0)
                        {
                            switch (Smoker_Client1)
                            {
                                case 1:
                                    document.Replace("S11", "X", true, true);
                                    document.Replace("S12", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("S11", " ", true, true);
                                    document.Replace("S12", "X", true, true);
                                    break;
                                default:
                                    document.Replace("S11", " ", true, true);
                                    document.Replace("S12", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("S11", " ", true, true);
                            document.Replace("S12", " ", true, true);
                        }

                        if (Smoker_Client2 != 0)
                        {
                            switch (Smoker_Client2)
                            {
                                case 1:
                                    document.Replace("S21", "X", true, true);
                                    document.Replace("S22", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("S21", " ", true, true);
                                    document.Replace("S22", "X", true, true);
                                    break;
                                default:
                                    document.Replace("S21", " ", true, true);
                                    document.Replace("S22", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("S21", " ", true, true);
                            document.Replace("S22", " ", true, true);
                        }

                        document.Replace("{TownOfBirth_Client1}", dt2.Rows[0].ItemArray[22].ToString(), true, true);
                        document.Replace("{TownOfBirth_Client2}", dt2.Rows[0].ItemArray[23].ToString(), true, true);
                        document.Replace("{CountryOfBirth_Client1}", dt2.Rows[0].ItemArray[24].ToString(), true, true);
                        document.Replace("{CountryOfBirth_Client2}", dt2.Rows[0].ItemArray[25].ToString(), true, true);
                        document.Replace("{IfnotAustraliayearsinAu_Client1}", dt2.Rows[0].ItemArray[26].ToString(), true, true);
                        document.Replace("{IfnotAustraliayearsinAu_Client2}", dt2.Rows[0].ItemArray[27].ToString(), true, true);
                        document.Replace("{Areyouanonresident_Client1}", dt2.Rows[0].ItemArray[28].ToString(), true, true);
                        document.Replace("{Areyouanonresident_Client2}", dt2.Rows[0].ItemArray[29].ToString(), true, true);

                        string Taxfilenumber_Client1 = dt2.Rows[0].ItemArray[30].ToString();
                        string Taxfilenumber_Client2 = dt2.Rows[0].ItemArray[31].ToString();

                        if (Taxfilenumber_Client1.Trim() != "")
                        {
                            string s1 = Taxfilenumber_Client1.Substring(0, 1);
                            string s2 = Taxfilenumber_Client1.Substring(1, 1);
                            string s3 = Taxfilenumber_Client1.Substring(2, 1);
                            string s4 = Taxfilenumber_Client1.Substring(3, 1);
                            string s5 = Taxfilenumber_Client1.Substring(4, 1);
                            string s6 = Taxfilenumber_Client1.Substring(5, 1);
                            string s7 = Taxfilenumber_Client1.Substring(6, 1);
                            string s8 = Taxfilenumber_Client1.Substring(7, 1);
                            string s9 = Taxfilenumber_Client1.Substring(8, 1);

                            document.Replace("T11", s1, true, true);
                            document.Replace("T12", s2, true, true);
                            document.Replace("T13", s3, true, true);
                            document.Replace("T14", s4, true, true);
                            document.Replace("T15", s5, true, true);
                            document.Replace("T16", s6, true, true);
                            document.Replace("T17", s7, true, true);
                            document.Replace("T18", s8, true, true);
                            document.Replace("T19", s9, true, true);
                        }
                        else
                        {
                            document.Replace("T11", " ", true, true);
                            document.Replace("T12", " ", true, true);
                            document.Replace("T13", " ", true, true);
                            document.Replace("T14", " ", true, true);
                            document.Replace("T15", " ", true, true);
                            document.Replace("T16", " ", true, true);
                            document.Replace("T17", " ", true, true);
                            document.Replace("T18", " ", true, true);
                            document.Replace("T19", " ", true, true);
                        }

                        if (Taxfilenumber_Client2.Trim() != "")
                        {
                            string s1 = Taxfilenumber_Client2.Substring(0, 1);
                            string s2 = Taxfilenumber_Client2.Substring(1, 1);
                            string s3 = Taxfilenumber_Client2.Substring(2, 1);
                            string s4 = Taxfilenumber_Client2.Substring(3, 1);
                            string s5 = Taxfilenumber_Client2.Substring(4, 1);
                            string s6 = Taxfilenumber_Client2.Substring(5, 1);
                            string s7 = Taxfilenumber_Client2.Substring(6, 1);
                            string s8 = Taxfilenumber_Client2.Substring(7, 1);
                            string s9 = Taxfilenumber_Client2.Substring(8, 1);

                            document.Replace("T21", s1, true, true);
                            document.Replace("T22", s2, true, true);
                            document.Replace("T23", s3, true, true);
                            document.Replace("T24", s4, true, true);
                            document.Replace("T25", s5, true, true);
                            document.Replace("T26", s6, true, true);
                            document.Replace("T27", s7, true, true);
                            document.Replace("T28", s8, true, true);
                            document.Replace("T29", s9, true, true);
                        }
                        else
                        {
                            document.Replace("T21", " ", true, true);
                            document.Replace("T22", " ", true, true);
                            document.Replace("T23", " ", true, true);
                            document.Replace("T24", " ", true, true);
                            document.Replace("T25", " ", true, true);
                            document.Replace("T26", " ", true, true);
                            document.Replace("T27", " ", true, true);
                            document.Replace("T28", " ", true, true);
                            document.Replace("T29", " ", true, true);
                        }

                        document.Replace("{Wereyoureferredtous_Client1}", dt2.Rows[0].ItemArray[32].ToString(), true, true);
                        document.Replace("{Wereyoureferredtous_Client2}", dt2.Rows[0].ItemArray[33].ToString(), true, true);
                        document.Replace("{Haveyouworkedwithanoth_Client1}", dt2.Rows[0].ItemArray[34].ToString(), true, true);
                        document.Replace("{Haveyouworkedwithanoth_Client2}", dt2.Rows[0].ItemArray[35].ToString(), true, true);
                        document.Replace("{Areyouaresidentofanother_Client1}", dt2.Rows[0].ItemArray[36].ToString(), true, true);
                        document.Replace("{Areyouaresidentofanother_Client2}", dt2.Rows[0].ItemArray[37].ToString(), true, true);
                        document.Replace("{Ifyescountryofresidence_Client1}", dt2.Rows[0].ItemArray[38].ToString(), true, true);
                        document.Replace("{Ifyescountryofresidence_Client2}", dt2.Rows[0].ItemArray[39].ToString(), true, true);
                        document.Replace("{TaxidentificationnumberTINof_Client1}", dt2.Rows[0].ItemArray[40].ToString(), true, true);
                        document.Replace("{TaxidentificationnumberTINof_Client2}", dt2.Rows[0].ItemArray[41].ToString(), true, true);
                        document.Replace("{Areyouapoliticallyexpos_Client1}", dt2.Rows[0].ItemArray[42].ToString(), true, true);
                        document.Replace("{Areyouapoliticallyexpos_Client2}", dt2.Rows[0].ItemArray[43].ToString(), true, true);

                        document.Replace("{Addresspostal_Client1}", dt2.Rows[0].ItemArray[44].ToString(), true, true);
                        document.Replace("{Addresspostal_Client2}", dt2.Rows[0].ItemArray[45].ToString(), true, true);
                        document.Replace("{Addresspostal2_Client1}", dt2.Rows[0].ItemArray[46].ToString(), true, true);
                        document.Replace("{Addresspostal2_Client2}", dt2.Rows[0].ItemArray[47].ToString(), true, true);
                        document.Replace("{AddPSC1}", dt2.Rows[0].ItemArray[48].ToString(), true, true);
                        document.Replace("{AddPSC2}", dt2.Rows[0].ItemArray[49].ToString(), true, true);
                        document.Replace("{AddPPC1}", dt2.Rows[0].ItemArray[50].ToString(), true, true);
                        document.Replace("{AddPPC2}", dt2.Rows[0].ItemArray[51].ToString(), true, true);
                        document.Replace("{Addressresidentialother_Client1}", dt2.Rows[0].ItemArray[52].ToString(), true, true);
                        document.Replace("{Addressresidentialother_Client2}", dt2.Rows[0].ItemArray[53].ToString(), true, true);
                        document.Replace("{AroS_C1}", dt2.Rows[0].ItemArray[54].ToString(), true, true);
                        document.Replace("{AroS_C2}", dt2.Rows[0].ItemArray[55].ToString(), true, true);
                        document.Replace("{AroP_C1}", dt2.Rows[0].ItemArray[56].ToString(), true, true);
                        document.Replace("{AroP_C2}", dt2.Rows[0].ItemArray[57].ToString(), true, true);
                        document.Replace("{Emailaddress_Client1}", dt2.Rows[0].ItemArray[58].ToString(), true, true);
                        document.Replace("{Emailaddress_Client2}", dt2.Rows[0].ItemArray[59].ToString(), true, true);
                        document.Replace("{Contactnumbersmainnumber_Client1}", dt2.Rows[0].ItemArray[60].ToString(), true, true);
                        document.Replace("{Contactnumbersmainnumber_Client2}", dt2.Rows[0].ItemArray[61].ToString(), true, true);
                        document.Replace("{Officephone_Client1}", dt2.Rows[0].ItemArray[62].ToString(), true, true);
                        document.Replace("{Officephone_Client2}", dt2.Rows[0].ItemArray[63].ToString(), true, true);
                        document.Replace("{Mobile_Client1}", dt2.Rows[0].ItemArray[64].ToString(), true, true);
                        document.Replace("{Mobile_Client2}", dt2.Rows[0].ItemArray[65].ToString(), true, true);
                        document.Replace("{Fax_Client1}", dt2.Rows[0].ItemArray[66].ToString(), true, true);
                        document.Replace("{Fax_Client2}", dt2.Rows[0].ItemArray[67].ToString(), true, true);

                        document.Replace("{SurnameName_Dependant1}", dt2.Rows[0].ItemArray[68].ToString(), true, true);
                        document.Replace("{SurnameName_Dependant2}", dt2.Rows[0].ItemArray[69].ToString(), true, true);
                        document.Replace("{SurnameName_Dependant3}", dt2.Rows[0].ItemArray[70].ToString(), true, true);
                        document.Replace("{GivenNames_Dependant1}", dt2.Rows[0].ItemArray[71].ToString(), true, true);
                        document.Replace("{GivenNames_Dependant2}", dt2.Rows[0].ItemArray[72].ToString(), true, true);
                        document.Replace("{GivenNames_Dependant3}", dt2.Rows[0].ItemArray[73].ToString(), true, true);
                        document.Replace("{PreferredShortName_D1}", dt2.Rows[0].ItemArray[74].ToString(), true, true);
                        document.Replace("{PreferredShortName_D2}", dt2.Rows[0].ItemArray[75].ToString(), true, true);
                        document.Replace("{PreferredShortName_D3}", dt2.Rows[0].ItemArray[76].ToString(), true, true);
                        document.Replace("{Title_Dependant1}", dt2.Rows[0].ItemArray[77].ToString(), true, true);
                        document.Replace("{Title_Dependant2}", dt2.Rows[0].ItemArray[78].ToString(), true, true);
                        document.Replace("{Title_Dependant3}", dt2.Rows[0].ItemArray[79].ToString(), true, true);

                        int GenderMale_Dependant1 = dt2.Rows[0].ItemArray[80] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[80]) : 0;
                        int GenderMale_Dependant2 = dt2.Rows[0].ItemArray[81] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[81]) : 0;
                        int GenderMale_Dependant3 = dt2.Rows[0].ItemArray[82] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[82]) : 0;

                        if (GenderMale_Dependant1 != 0)
                        {
                            switch (GenderMale_Dependant1)
                            {
                                case 1:
                                    document.Replace("Md1", "X", true, true);
                                    document.Replace("Mf1", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Md1", " ", true, true);
                                    document.Replace("Mf1", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Md1", " ", true, true);
                                    document.Replace("Mf1", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Md1", " ", true, true);
                            document.Replace("Mf1", " ", true, true);
                        }

                        if (GenderMale_Dependant2 != 0)
                        {
                            switch (GenderMale_Dependant2)
                            {
                                case 1:
                                    document.Replace("Md2", "X", true, true);
                                    document.Replace("Mf2", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Md2", " ", true, true);
                                    document.Replace("Mf2", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Md2", " ", true, true);
                                    document.Replace("Mf2", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Md2", " ", true, true);
                            document.Replace("Mf2", " ", true, true);
                        }

                        if (GenderMale_Dependant3 != 0)
                        {
                            switch (GenderMale_Dependant3)
                            {
                                case 1:
                                    document.Replace("Md3", "X", true, true);
                                    document.Replace("Mf3", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Md3", " ", true, true);
                                    document.Replace("Mf3", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Md3", " ", true, true);
                                    document.Replace("Mf3", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Md3", " ", true, true);
                            document.Replace("Mf3", " ", true, true);
                        }

                        DateTime DateOfBirth_Dependant1 = dt2.Rows[0].ItemArray[83] != DBNull.Value ? Convert.ToDateTime(dt2.Rows[0].ItemArray[12]) : Convert.ToDateTime("1900-01-01");
                        DateTime DateOfBirth_Dependant2 = dt2.Rows[0].ItemArray[84] != DBNull.Value ? Convert.ToDateTime(dt2.Rows[0].ItemArray[13]) : Convert.ToDateTime("1900-01-01");
                        DateTime DateOfBirth_Dependant3 = dt2.Rows[0].ItemArray[85] != DBNull.Value ? Convert.ToDateTime(dt2.Rows[0].ItemArray[13]) : Convert.ToDateTime("1900-01-01");

                        if (DateOfBirth_Dependant1 != Convert.ToDateTime("1900-01-01"))
                        {
                            string[] d = DateOfBirth_Dependant1.ToShortDateString().Split('/');
                            string dd = d[0];
                            string mm = d[1];
                            string yyyy = d[2];

                            document.Replace("o11", dd.Substring(0, 1), true, true);
                            document.Replace("o12", dd.Substring(1, 1), true, true);
                            document.Replace("o13", mm.Substring(0, 1), true, true);
                            document.Replace("o14", mm.Substring(1, 1), true, true);
                            document.Replace("o15", yyyy.Substring(0, 1), true, true);
                            document.Replace("o16", yyyy.Substring(1, 1), true, true);
                            document.Replace("o17", yyyy.Substring(2, 1), true, true);
                            document.Replace("o18", yyyy.Substring(3, 1), true, true);

                        }
                        else
                        {
                            document.Replace("o11", " ", true, true);
                            document.Replace("o12", " ", true, true);
                            document.Replace("o13", " ", true, true);
                            document.Replace("o14", " ", true, true);
                            document.Replace("o15", " ", true, true);
                            document.Replace("o16", " ", true, true);
                            document.Replace("o17", " ", true, true);
                            document.Replace("o18", " ", true, true);
                        }

                        if (DateOfBirth_Dependant2 != Convert.ToDateTime("1900-01-01"))
                        {
                            string[] d = DateOfBirth_Dependant2.ToShortDateString().Split('/');
                            string dd = d[0];
                            string mm = d[1];
                            string yyyy = d[2];

                            document.Replace("o21", dd.Substring(0, 1), true, true);
                            document.Replace("o22", dd.Substring(1, 1), true, true);
                            document.Replace("o23", mm.Substring(0, 1), true, true);
                            document.Replace("o24", mm.Substring(1, 1), true, true);
                            document.Replace("o25", yyyy.Substring(0, 1), true, true);
                            document.Replace("o26", yyyy.Substring(1, 1), true, true);
                            document.Replace("o27", yyyy.Substring(2, 1), true, true);
                            document.Replace("o28", yyyy.Substring(3, 1), true, true);

                        }
                        else
                        {
                            document.Replace("o21", " ", true, true);
                            document.Replace("o22", " ", true, true);
                            document.Replace("o23", " ", true, true);
                            document.Replace("o24", " ", true, true);
                            document.Replace("o25", " ", true, true);
                            document.Replace("o26", " ", true, true);
                            document.Replace("o27", " ", true, true);
                            document.Replace("o28", " ", true, true);
                        }

                        if (DateOfBirth_Dependant2 != Convert.ToDateTime("1900-01-01"))
                        {
                            string[] d = DateOfBirth_Dependant2.ToShortDateString().Split('/');
                            string dd = d[0];
                            string mm = d[1];
                            string yyyy = d[2];

                            document.Replace("o31", dd.Substring(0, 1), true, true);
                            document.Replace("o32", dd.Substring(1, 1), true, true);
                            document.Replace("o33", mm.Substring(0, 1), true, true);
                            document.Replace("o34", mm.Substring(1, 1), true, true);
                            document.Replace("o35", yyyy.Substring(0, 1), true, true);
                            document.Replace("o36", yyyy.Substring(1, 1), true, true);
                            document.Replace("o37", yyyy.Substring(2, 1), true, true);
                            document.Replace("o38", yyyy.Substring(3, 1), true, true);

                        }
                        else
                        {
                            document.Replace("o31", " ", true, true);
                            document.Replace("o32", " ", true, true);
                            document.Replace("o33", " ", true, true);
                            document.Replace("o34", " ", true, true);
                            document.Replace("o35", " ", true, true);
                            document.Replace("o36", " ", true, true);
                            document.Replace("o37", " ", true, true);
                            document.Replace("o38", " ", true, true);
                        }

                        int Age_Dependant1 = dt2.Rows[0].ItemArray[86] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[86]) : 0;
                        int Age_Dependant2 = dt2.Rows[0].ItemArray[87] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[87]) : 0;
                        int Age_Dependant3 = dt2.Rows[0].ItemArray[88] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[88]) : 0;

                        if (Age_Dependant1 != 0)
                            document.Replace("{Age_Dependant1}", Age_Dependant1.ToString(), true, true);
                        else
                            document.Replace("{Age_Dependant1}", " ", true, true);

                        if (Age_Dependant2 != 0)
                            document.Replace("{Age_Dependant2}", Age_Dependant2.ToString(), true, true);
                        else
                            document.Replace("{Age_Dependant2}", " ", true, true);

                        if (Age_Dependant3 != 0)
                            document.Replace("{Age_Dependant3}", Age_Dependant3.ToString(), true, true);
                        else
                            document.Replace("{Age_Dependant3}", " ", true, true);

                        document.Replace("{Relationship_Dependant1}", dt2.Rows[0].ItemArray[89].ToString(), true, true);
                        document.Replace("{Relationship_Dependant2}", dt2.Rows[0].ItemArray[90].ToString(), true, true);
                        document.Replace("{Relationship_Dependant3}", dt2.Rows[0].ItemArray[91].ToString(), true, true);

                        int SpecialNeeds_Dependant1 = dt2.Rows[0].ItemArray[92] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[92]) : 0;
                        int SpecialNeeds_Dependant2 = dt2.Rows[0].ItemArray[93] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[93]) : 0;
                        int SpecialNeeds_Dependant3 = dt2.Rows[0].ItemArray[94] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[94]) : 0;

                        if (SpecialNeeds_Dependant1 != 0)
                        {
                            switch (SpecialNeeds_Dependant1)
                            {
                                case 1:
                                    document.Replace("Sy1", "X", true, true);
                                    document.Replace("Sn1", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Sy1", " ", true, true);
                                    document.Replace("Sn1", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Sy1", " ", true, true);
                                    document.Replace("Sn1", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Sy1", " ", true, true);
                            document.Replace("Sn1", " ", true, true);
                        }

                        if (SpecialNeeds_Dependant2 != 0)
                        {
                            switch (SpecialNeeds_Dependant2)
                            {
                                case 1:
                                    document.Replace("Sy2", "X", true, true);
                                    document.Replace("Sn2", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Sy2", " ", true, true);
                                    document.Replace("Sn2", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Sy2", " ", true, true);
                                    document.Replace("Sn2", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Sy2", " ", true, true);
                            document.Replace("Sn2", " ", true, true);
                        }

                        if (SpecialNeeds_Dependant3 != 0)
                        {
                            switch (SpecialNeeds_Dependant3)
                            {
                                case 1:
                                    document.Replace("Sy3", "X", true, true);
                                    document.Replace("Sn3", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Sy3", " ", true, true);
                                    document.Replace("Sn3", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Sy3", " ", true, true);
                                    document.Replace("Sn3", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Sy3", " ", true, true);
                            document.Replace("Sn3", " ", true, true);
                        }

                        document.Replace("{Details_Dependant1}", dt2.Rows[0].ItemArray[95].ToString(), true, true);
                        document.Replace("{Details_Dependant2}", dt2.Rows[0].ItemArray[96].ToString(), true, true);
                        document.Replace("{Details_Dependant3}", dt2.Rows[0].ItemArray[97].ToString(), true, true);
                        document.Replace("{Details2_Dependant1}", dt2.Rows[0].ItemArray[98].ToString(), true, true);
                        document.Replace("{Details2_Dependant2}", dt2.Rows[0].ItemArray[99].ToString(), true, true);
                        document.Replace("{Details2_Dependant3}", dt2.Rows[0].ItemArray[100].ToString(), true, true);
                        document.Replace("{Details3_Dependant1}", dt2.Rows[0].ItemArray[101].ToString(), true, true);
                        document.Replace("{Details3_Dependant2}", dt2.Rows[0].ItemArray[102].ToString(), true, true);
                        document.Replace("{Details3_Dependant3}", dt2.Rows[0].ItemArray[103].ToString(), true, true);

                        document.Replace("{Supporttoage_Dependant1}", dt2.Rows[0].ItemArray[104].ToString(), true, true);
                        document.Replace("{Supporttoage_Dependant2}", dt2.Rows[0].ItemArray[105].ToString(), true, true);
                        document.Replace("{Supporttoage_Dependant3}", dt2.Rows[0].ItemArray[106].ToString(), true, true);
                        document.Replace("{SchoolName_Dependant1}", dt2.Rows[0].ItemArray[107].ToString(), true, true);
                        document.Replace("{SchoolName_Dependant2}", dt2.Rows[0].ItemArray[108].ToString(), true, true);
                        document.Replace("{SchoolName_Dependant3}", dt2.Rows[0].ItemArray[109].ToString(), true, true);
                        document.Replace("{SchoolYearLevel_D1}", dt2.Rows[0].ItemArray[110].ToString(), true, true);
                        document.Replace("{SchoolYearLevel_D2}", dt2.Rows[0].ItemArray[111].ToString(), true, true);
                        document.Replace("{SchoolYearLevel_D3}", dt2.Rows[0].ItemArray[112].ToString(), true, true);
                        document.Replace("{EstimatedCostofSchooling_Dependant1}", dt2.Rows[0].ItemArray[113].ToString(), true, true);
                        document.Replace("{EstimatedCostofSchooling_Dependant2}", dt2.Rows[0].ItemArray[114].ToString(), true, true);
                        document.Replace("{EstimatedCostofSchooling_Dependant3}", dt2.Rows[0].ItemArray[115].ToString(), true, true);

                        int AustudyStatus_Dependant1 = dt2.Rows[0].ItemArray[116] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[116]) : 0;
                        int AustudyStatus_Dependant2 = dt2.Rows[0].ItemArray[117] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[117]) : 0;
                        int AustudyStatus_Dependant3 = dt2.Rows[0].ItemArray[118] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0].ItemArray[118]) : 0;

                        if (AustudyStatus_Dependant1 != 0)
                        {
                            switch (AustudyStatus_Dependant1)
                            {
                                case 1:
                                    document.Replace("A1", "X", true, true);
                                    document.Replace("A4", " ", true, true);
                                    document.Replace("A7", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("A1", " ", true, true);
                                    document.Replace("A4", "X", true, true);
                                    document.Replace("A7", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("A1", " ", true, true);
                                    document.Replace("A4", " ", true, true);
                                    document.Replace("A7", "X", true, true);
                                    break;
                                default:
                                    document.Replace("A1", " ", true, true);
                                    document.Replace("A4", " ", true, true);
                                    document.Replace("A7", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("A1", " ", true, true);
                            document.Replace("A4", " ", true, true);
                            document.Replace("A7", " ", true, true);
                        }

                        if (AustudyStatus_Dependant2 != 0)
                        {
                            switch (AustudyStatus_Dependant2)
                            {
                                case 1:
                                    document.Replace("A2", "X", true, true);
                                    document.Replace("A5", " ", true, true);
                                    document.Replace("A8", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("A2", " ", true, true);
                                    document.Replace("A5", "X", true, true);
                                    document.Replace("A8", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("A2", " ", true, true);
                                    document.Replace("A5", " ", true, true);
                                    document.Replace("A8", "X", true, true);
                                    break;
                                default:
                                    document.Replace("A2", " ", true, true);
                                    document.Replace("A5", " ", true, true);
                                    document.Replace("A8", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("A2", " ", true, true);
                            document.Replace("A5", " ", true, true);
                            document.Replace("A8", " ", true, true);
                        }

                        if (AustudyStatus_Dependant3 != 0)
                        {
                            switch (AustudyStatus_Dependant3)
                            {
                                case 1:
                                    document.Replace("A3", "X", true, true);
                                    document.Replace("A6", " ", true, true);
                                    document.Replace("A9", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("A3", " ", true, true);
                                    document.Replace("A6", "X", true, true);
                                    document.Replace("A9", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("A3", " ", true, true);
                                    document.Replace("A6", " ", true, true);
                                    document.Replace("A9", "X", true, true);
                                    break;
                                default:
                                    document.Replace("A3", " ", true, true);
                                    document.Replace("A6", " ", true, true);
                                    document.Replace("A9", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("A3", " ", true, true);
                            document.Replace("A6", " ", true, true);
                            document.Replace("A9", " ", true, true);
                        }

                        document.Replace("{ClientsParents}", dt2.Rows[0].ItemArray[119].ToString(), true, true);

                        string FileNotesClientsParents_FileName = dt2.Rows[0].ItemArray[120].ToString();
                        string FileNotesClientsParents_FilePath = dt2.Rows[0].ItemArray[121].ToString();

                        document.Replace("{FileNotesClientsParents_FileName}", dt2.Rows[0].ItemArray[120].ToString(), true, true);

                        document.Replace("{EgCollectablesGolfTennis_Client1}", dt2.Rows[0].ItemArray[122].ToString(), true, true);
                        document.Replace("{EgCollectablesGolfTennis_Client2}", dt2.Rows[0].ItemArray[123].ToString(), true, true);
                        document.Replace("{EgCollectablesGolfTennis2_Client1}", dt2.Rows[0].ItemArray[124].ToString(), true, true);
                        document.Replace("{EgCollectablesGolfTennis2_Client2}", dt2.Rows[0].ItemArray[125].ToString(), true, true);
                        document.Replace("{EgCollectablesGolfTennis3_Client1}", dt2.Rows[0].ItemArray[126].ToString(), true, true);
                        document.Replace("{EgCollectablesGolfTennis3_Client2}", dt2.Rows[0].ItemArray[127].ToString(), true, true);

                        document.Replace("{Businessname_A}", dt2.Rows[0].ItemArray[128].ToString(), true, true);
                        document.Replace("{Businessname_B}", dt2.Rows[0].ItemArray[129].ToString(), true, true);
                        document.Replace("{Businessname_L}", dt2.Rows[0].ItemArray[130].ToString(), true, true);
                        document.Replace("{Contactname_A}", dt2.Rows[0].ItemArray[131].ToString(), true, true);
                        document.Replace("{Contactname_B}", dt2.Rows[0].ItemArray[132].ToString(), true, true);
                        document.Replace("{Contactname_L}", dt2.Rows[0].ItemArray[133].ToString(), true, true);
                        document.Replace("{Postaladdress_A}", dt2.Rows[0].ItemArray[134].ToString(), true, true);
                        document.Replace("{Postaladdress_B}", dt2.Rows[0].ItemArray[135].ToString(), true, true);
                        document.Replace("{Postaladdress_L}", dt2.Rows[0].ItemArray[136].ToString(), true, true);
                        document.Replace("{Postaladdress2_A}", dt2.Rows[0].ItemArray[137].ToString(), true, true);
                        document.Replace("{Postaladdress2_B}", dt2.Rows[0].ItemArray[138].ToString(), true, true);
                        document.Replace("{Postaladdress2_L}", dt2.Rows[0].ItemArray[139].ToString(), true, true);
                        document.Replace("{PostalAdS_A}", dt2.Rows[0].ItemArray[140].ToString(), true, true);
                        document.Replace("{PostalAdS_B}", dt2.Rows[0].ItemArray[141].ToString(), true, true);
                        document.Replace("{PostalAdS_L}", dt2.Rows[0].ItemArray[142].ToString(), true, true);
                        document.Replace("{PostalAdP_A}", dt2.Rows[0].ItemArray[143].ToString(), true, true);
                        document.Replace("{PostalAdP_B}", dt2.Rows[0].ItemArray[144].ToString(), true, true);
                        document.Replace("{PostalAdP_L}", dt2.Rows[0].ItemArray[145].ToString(), true, true);
                        document.Replace("{Emailaddress_A}", dt2.Rows[0].ItemArray[146].ToString(), true, true);
                        document.Replace("{Emailaddress_B}", dt2.Rows[0].ItemArray[147].ToString(), true, true);
                        document.Replace("{Emailaddress_L}", dt2.Rows[0].ItemArray[148].ToString(), true, true);
                        document.Replace("{Phoneaddress_A}", dt2.Rows[0].ItemArray[149].ToString(), true, true);
                        document.Replace("{Phoneaddress_B}", dt2.Rows[0].ItemArray[150].ToString(), true, true);
                        document.Replace("{Phoneaddress_L}", dt2.Rows[0].ItemArray[151].ToString(), true, true);
                        document.Replace("{Faxnumber_A}", dt2.Rows[0].ItemArray[152].ToString(), true, true);
                        document.Replace("{Faxnumber_B}", dt2.Rows[0].ItemArray[153].ToString(), true, true);
                        document.Replace("{Faxnumber_L}", dt2.Rows[0].ItemArray[154].ToString(), true, true);

                        string FileNotes_FileName = dt2.Rows[0].ItemArray[155].ToString();
                        string FileNotes_FilePath = dt2.Rows[0].ItemArray[156].ToString();

                        document.Replace("{FileNotes_FileName}", dt2.Rows[0].ItemArray[155].ToString(), true, true);



                    }
                    #endregion

                    #region Selection B
                    DataTable dt3 = DataAccess.getSelectionBFinancialSummary(DataAccess._CoverPageID);
                    if (dt3.Rows.Count > 0)
                    {

                        int Workstatus_Client1 = dt3.Rows[0].ItemArray[2] != DBNull.Value ? Convert.ToInt32(dt3.Rows[0].ItemArray[2]) : 0;
                        int Workstatus_Client2 = dt3.Rows[0].ItemArray[3] != DBNull.Value ? Convert.ToInt32(dt3.Rows[0].ItemArray[3]) : 0;

                        if (Workstatus_Client1 != 0)
                        {
                            switch (Workstatus_Client1)
                            {
                                case 1:
                                    document.Replace("W1", "X", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", "X", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", "X", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 4:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", "X", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 5:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", "X", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 6:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", "X", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 7:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", "X", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 8:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", "X", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                                case 9:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", "X", true, true);
                                    break;
                                default:
                                    document.Replace("W1", " ", true, true);
                                    document.Replace("W2", " ", true, true);
                                    document.Replace("W3", " ", true, true);
                                    document.Replace("W4", " ", true, true);
                                    document.Replace("W5", " ", true, true);
                                    document.Replace("W6", " ", true, true);
                                    document.Replace("W7", " ", true, true);
                                    document.Replace("W8", " ", true, true);
                                    document.Replace("W9", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("W1", " ", true, true);
                            document.Replace("W2", " ", true, true);
                            document.Replace("W3", " ", true, true);
                            document.Replace("W4", " ", true, true);
                            document.Replace("W5", " ", true, true);
                            document.Replace("W6", " ", true, true);
                            document.Replace("W7", " ", true, true);
                            document.Replace("W8", " ", true, true);
                            document.Replace("W9", " ", true, true);
                        }

                        if (Workstatus_Client2 != 0)
                        {
                            switch (Workstatus_Client2)
                            {
                                case 1:
                                    document.Replace("Q1", "X", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 2:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", "X", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 3:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", "X", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 4:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", "X", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 5:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", "X", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 6:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", "X", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 7:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", "X", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 8:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", "X", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                                case 9:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", "X", true, true);
                                    break;
                                default:
                                    document.Replace("Q1", " ", true, true);
                                    document.Replace("Q2", " ", true, true);
                                    document.Replace("Q3", " ", true, true);
                                    document.Replace("Q4", " ", true, true);
                                    document.Replace("Q5", " ", true, true);
                                    document.Replace("Q6", " ", true, true);
                                    document.Replace("Q7", " ", true, true);
                                    document.Replace("Q8", " ", true, true);
                                    document.Replace("Q9", " ", true, true);
                                    break;
                            }
                        }
                        else
                        {
                            document.Replace("Q1", " ", true, true);
                            document.Replace("Q2", " ", true, true);
                            document.Replace("Q3", " ", true, true);
                            document.Replace("Q4", " ", true, true);
                            document.Replace("Q5", " ", true, true);
                            document.Replace("Q6", " ", true, true);
                            document.Replace("Q7", " ", true, true);
                            document.Replace("Q8", " ", true, true);
                            document.Replace("Q9", " ", true, true);
                        }

                        document.Replace("{Employer_Client1}", dt3.Rows[0].ItemArray[4].ToString(), true, true);
                        document.Replace("{Employer_Client2}", dt3.Rows[0].ItemArray[5].ToString(), true, true);
                        document.Replace("{Employeraddress_Client1}", dt3.Rows[0].ItemArray[6].ToString(), true, true);
                        document.Replace("{Employeraddress_Client2}", dt3.Rows[0].ItemArray[7].ToString(), true, true);
                        document.Replace("{Occupation_Client1}", dt3.Rows[0].ItemArray[8].ToString(), true, true);
                        document.Replace("{Occupation_Client2}", dt3.Rows[0].ItemArray[9].ToString(), true, true);
                        document.Replace("{Numberofyearsservice_Client1}", dt3.Rows[0].ItemArray[10].ToString(), true, true);
                        document.Replace("{Numberofyearsservice_Client2}", dt3.Rows[0].ItemArray[11].ToString(), true, true);
                        document.Replace("{IntendedRetirementdate_Client1}", dt3.Rows[0].ItemArray[12].ToString(), true, true);
                        document.Replace("{IntendedRetirementdate_Client2}", dt3.Rows[0].ItemArray[13].ToString(), true, true);
                        document.Replace("{Doyouexpectemployment_Client1}", dt3.Rows[0].ItemArray[14].ToString(), true, true);
                        document.Replace("{Doyouexpectemployment_Client2}", dt3.Rows[0].ItemArray[15].ToString(), true, true);

                        document.Replace("{Salaryincome_Client1}", dt3.Rows[0].ItemArray[16].ToString(), true, true);
                        document.Replace("{Salaryincome_Client2}", dt3.Rows[0].ItemArray[17].ToString(), true, true);
                        document.Replace("{Othertaxableincome_Client1}", dt3.Rows[0].ItemArray[18].ToString(), true, true);
                        document.Replace("{Othertaxableincome_Client2}", dt3.Rows[0].ItemArray[19].ToString(), true, true);
                        document.Replace("{Taxfreeincome_Client1}", dt3.Rows[0].ItemArray[20].ToString(), true, true);
                        document.Replace("{Taxfreeincome_Client2}", dt3.Rows[0].ItemArray[21].ToString(), true, true);
                        document.Replace("{Familyallowance_Client1}", dt3.Rows[0].ItemArray[22].ToString(), true, true);
                        document.Replace("{Familyallowance_Client2}", dt3.Rows[0].ItemArray[23].ToString(), true, true);
                        document.Replace("{Directorsfeesgratuities_C1}", dt3.Rows[0].ItemArray[24].ToString(), true, true);
                        document.Replace("{Directorsfeesgratuities_C2}", dt3.Rows[0].ItemArray[25].ToString(), true, true);
                        document.Replace("{Areyouexpectingfunds1_Client1}", dt3.Rows[0].ItemArray[26].ToString(), true, true);
                        document.Replace("{Areyouexpectingfunds1_Client2}", dt3.Rows[0].ItemArray[27].ToString(), true, true);
                        document.Replace("{Areyouexpectingfunds2_Client1}", dt3.Rows[0].ItemArray[28].ToString(), true, true);
                        document.Replace("{Areyouexpectingfunds2_Client2}", dt3.Rows[0].ItemArray[29].ToString(), true, true);
                        document.Replace("{Areyouexpectingfunds3_Client1}", dt3.Rows[0].ItemArray[30].ToString(), true, true);
                        document.Replace("{Areyouexpectingfunds3_Client2}", dt3.Rows[0].ItemArray[31].ToString(), true, true);
                        document.Replace("{Other1_Client1}", dt3.Rows[0].ItemArray[32].ToString(), true, true);
                        document.Replace("{Other1_Client2}", dt3.Rows[0].ItemArray[33].ToString(), true, true);
                        document.Replace("{Other2_Client1}", dt3.Rows[0].ItemArray[34].ToString(), true, true);
                        document.Replace("{Other2_Client2}", dt3.Rows[0].ItemArray[35].ToString(), true, true);
                        document.Replace("{Other3_Client1}", dt3.Rows[0].ItemArray[36].ToString(), true, true);
                        document.Replace("{Other3_Client2}", dt3.Rows[0].ItemArray[37].ToString(), true, true);

                        document.Replace("{Employmentsuper_Client1}", dt3.Rows[0].ItemArray[38].ToString(), true, true);
                        document.Replace("{Employmentsuper_Client2}", dt3.Rows[0].ItemArray[39].ToString(), true, true);
                        document.Replace("{Salarysacrificetosuper_Client1}", dt3.Rows[0].ItemArray[40].ToString(), true, true);
                        document.Replace("{Salarysacrificetosuper_Client2}", dt3.Rows[0].ItemArray[41].ToString(), true, true);
                        document.Replace("{Packagedmotorvehicle_Client1}", dt3.Rows[0].ItemArray[42].ToString(), true, true);
                        document.Replace("{Packagedmotorvehicle_Client2}", dt3.Rows[0].ItemArray[43].ToString(), true, true);
                        document.Replace("{Bonus_Client1}", dt3.Rows[0].ItemArray[44].ToString(), true, true);
                        document.Replace("{Bonus_Client2}", dt3.Rows[0].ItemArray[45].ToString(), true, true);
                        document.Replace("{Other_Client1}", dt3.Rows[0].ItemArray[46].ToString(), true, true);
                        document.Replace("{Other_Client2}", dt3.Rows[0].ItemArray[47].ToString(), true, true);

                        document.Replace("{Entitlementamount_Client1}", dt3.Rows[0].ItemArray[48].ToString(), true, true);
                        document.Replace("{Entitlementamount_Client2}", dt3.Rows[0].ItemArray[49].ToString(), true, true);
                        document.Replace("{Entitlementtype_Client1}", dt3.Rows[0].ItemArray[50].ToString(), true, true);
                        document.Replace("{Entitlementtype_Client2}", dt3.Rows[0].ItemArray[51].ToString(), true, true);
                        document.Replace("{CentrelinkreferencenoCRN_C1}", dt3.Rows[0].ItemArray[52].ToString(), true, true);
                        document.Replace("{CentrelinkreferencenoCRN_C2}", dt3.Rows[0].ItemArray[53].ToString(), true, true);
                        document.Replace("{Maintenanceincome_Client1}", dt3.Rows[0].ItemArray[54].ToString(), true, true);
                        document.Replace("{Maintenanceincome_Client2}", dt3.Rows[0].ItemArray[55].ToString(), true, true);
                        document.Replace("{Maintenancepayment_Client1}", dt3.Rows[0].ItemArray[56].ToString(), true, true);
                        document.Replace("{Maintenancepayment_Client2}", dt3.Rows[0].ItemArray[57].ToString(), true, true);
                        document.Replace("{Overseassocialsecurityi_C1}", dt3.Rows[0].ItemArray[58].ToString(), true, true);
                        document.Replace("{Overseassocialsecurityi_C2}", dt3.Rows[0].ItemArray[59].ToString(), true, true);

                        string FileNotesCentrelink_FileName = dt3.Rows[0].ItemArray[60].ToString();
                        string FileNotesCentrelink_FilePath = dt3.Rows[0].ItemArray[61].ToString();

                        document.Replace("{FileNotesCentrelink_FileName}", dt3.Rows[0].ItemArray[60].ToString(), true, true);

                        document.Replace("{Foodliq_F}", dt3.Rows[0].ItemArray[62].ToString(), true, true);
                        document.Replace("{Foodliq_M}", dt3.Rows[0].ItemArray[63].ToString(), true, true);
                        document.Replace("{Foodliq_Q}", dt3.Rows[0].ItemArray[64].ToString(), true, true);
                        document.Replace("{Foodliq_H}", dt3.Rows[0].ItemArray[65].ToString(), true, true);
                        document.Replace("{Foodliq_A}", dt3.Rows[0].ItemArray[66].ToString(), true, true);
                        document.Replace("{Foodliq_T}", dt3.Rows[0].ItemArray[67].ToString(), true, true);

                        document.Replace("{Alcohol_F}", dt3.Rows[0].ItemArray[68].ToString(), true, true);
                        document.Replace("{Alcohol_M}", dt3.Rows[0].ItemArray[69].ToString(), true, true);
                        document.Replace("{Alcohol_Q}", dt3.Rows[0].ItemArray[70].ToString(), true, true);
                        document.Replace("{Alcohol_H}", dt3.Rows[0].ItemArray[71].ToString(), true, true);
                        document.Replace("{Alcohol_A}", dt3.Rows[0].ItemArray[72].ToString(), true, true);
                        document.Replace("{Alcohol_T}", dt3.Rows[0].ItemArray[73].ToString(), true, true);

                        document.Replace("{Tobacco_F}", dt3.Rows[0].ItemArray[74].ToString(), true, true);
                        document.Replace("{Tobacco_M}", dt3.Rows[0].ItemArray[75].ToString(), true, true);
                        document.Replace("{Tobacco_Q}", dt3.Rows[0].ItemArray[76].ToString(), true, true);
                        document.Replace("{Tobacco_H}", dt3.Rows[0].ItemArray[77].ToString(), true, true);
                        document.Replace("{Tobacco_A}", dt3.Rows[0].ItemArray[78].ToString(), true, true);
                        document.Replace("{Tobacco_T}", dt3.Rows[0].ItemArray[79].ToString(), true, true);

                        document.Replace("{Cfootw_F}", dt3.Rows[0].ItemArray[80].ToString(), true, true);
                        document.Replace("{Cfootw_M}", dt3.Rows[0].ItemArray[81].ToString(), true, true);
                        document.Replace("{Cfootw_Q}", dt3.Rows[0].ItemArray[82].ToString(), true, true);
                        document.Replace("{Cfootw_H}", dt3.Rows[0].ItemArray[83].ToString(), true, true);
                        document.Replace("{Cfootw_A}", dt3.Rows[0].ItemArray[84].ToString(), true, true);
                        document.Replace("{Cfootw_T}", dt3.Rows[0].ItemArray[85].ToString(), true, true);

                        document.Replace("{Medich_F}", dt3.Rows[0].ItemArray[86].ToString(), true, true);
                        document.Replace("{Medich_M}", dt3.Rows[0].ItemArray[87].ToString(), true, true);
                        document.Replace("{Medich_Q}", dt3.Rows[0].ItemArray[88].ToString(), true, true);
                        document.Replace("{Medich_H}", dt3.Rows[0].ItemArray[89].ToString(), true, true);
                        document.Replace("{Medich_A}", dt3.Rows[0].ItemArray[90].ToString(), true, true);
                        document.Replace("{Medich_T}", dt3.Rows[0].ItemArray[91].ToString(), true, true);

                        document.Replace("{Recrea_F}", dt3.Rows[0].ItemArray[92].ToString(), true, true);
                        document.Replace("{Recrea_M}", dt3.Rows[0].ItemArray[93].ToString(), true, true);
                        document.Replace("{Recrea_Q}", dt3.Rows[0].ItemArray[94].ToString(), true, true);
                        document.Replace("{Recrea_H}", dt3.Rows[0].ItemArray[95].ToString(), true, true);
                        document.Replace("{Recrea_A}", dt3.Rows[0].ItemArray[96].ToString(), true, true);
                        document.Replace("{Recrea_T}", dt3.Rows[0].ItemArray[97].ToString(), true, true);

                        document.Replace("{Person_F}", dt3.Rows[0].ItemArray[98].ToString(), true, true);
                        document.Replace("{Person_M}", dt3.Rows[0].ItemArray[99].ToString(), true, true);
                        document.Replace("{Person_Q}", dt3.Rows[0].ItemArray[100].ToString(), true, true);
                        document.Replace("{Person_H}", dt3.Rows[0].ItemArray[101].ToString(), true, true);
                        document.Replace("{Person_A}", dt3.Rows[0].ItemArray[102].ToString(), true, true);
                        document.Replace("{Person_T}", dt3.Rows[0].ItemArray[103].ToString(), true, true);

                        document.Replace("{PhoneP_F}", dt3.Rows[0].ItemArray[104].ToString(), true, true);
                        document.Replace("{PhoneP_M}", dt3.Rows[0].ItemArray[105].ToString(), true, true);
                        document.Replace("{PhoneP_Q}", dt3.Rows[0].ItemArray[106].ToString(), true, true);
                        document.Replace("{PhoneP_H}", dt3.Rows[0].ItemArray[107].ToString(), true, true);
                        document.Replace("{PhoneP_A}", dt3.Rows[0].ItemArray[108].ToString(), true, true);
                        document.Replace("{PhoneP_T}", dt3.Rows[0].ItemArray[109].ToString(), true, true);

                        document.Replace("{Travel_F}", dt3.Rows[0].ItemArray[110].ToString(), true, true);
                        document.Replace("{Travel_M}", dt3.Rows[0].ItemArray[111].ToString(), true, true);
                        document.Replace("{Travel_Q}", dt3.Rows[0].ItemArray[112].ToString(), true, true);
                        document.Replace("{Travel_H}", dt3.Rows[0].ItemArray[113].ToString(), true, true);
                        document.Replace("{Travel_A}", dt3.Rows[0].ItemArray[114].ToString(), true, true);
                        document.Replace("{Travel_T}", dt3.Rows[0].ItemArray[115].ToString(), true, true);

                        document.Replace("{Gifts_F}", dt3.Rows[0].ItemArray[116].ToString(), true, true);
                        document.Replace("{Gifts_M}", dt3.Rows[0].ItemArray[117].ToString(), true, true);
                        document.Replace("{Gifts_Q}", dt3.Rows[0].ItemArray[118].ToString(), true, true);
                        document.Replace("{Gifts_H}", dt3.Rows[0].ItemArray[119].ToString(), true, true);
                        document.Replace("{Gifts_A}", dt3.Rows[0].ItemArray[120].ToString(), true, true);
                        document.Replace("{Gifts_T}", dt3.Rows[0].ItemArray[121].ToString(), true, true);

                        document.Replace("{Other_Fo}", dt3.Rows[0].ItemArray[122].ToString(), true, true);
                        document.Replace("{Other_Mo}", dt3.Rows[0].ItemArray[123].ToString(), true, true);
                        document.Replace("{Other_Qu}", dt3.Rows[0].ItemArray[124].ToString(), true, true);
                        document.Replace("{Other_Ha}", dt3.Rows[0].ItemArray[125].ToString(), true, true);
                        document.Replace("{Other_An}", dt3.Rows[0].ItemArray[126].ToString(), true, true);
                        document.Replace("{Other_To}", dt3.Rows[0].ItemArray[127].ToString(), true, true);

                        document.Replace("{Rurnce_F}", dt3.Rows[0].ItemArray[128].ToString(), true, true);
                        document.Replace("{Rurnce_M}", dt3.Rows[0].ItemArray[129].ToString(), true, true);
                        document.Replace("{Rurnce_Q}", dt3.Rows[0].ItemArray[130].ToString(), true, true);
                        document.Replace("{Rurnce_H}", dt3.Rows[0].ItemArray[131].ToString(), true, true);
                        document.Replace("{Rurnce_A}", dt3.Rows[0].ItemArray[132].ToString(), true, true);
                        document.Replace("{Rurnce_T}", dt3.Rows[0].ItemArray[133].ToString(), true, true);

                        document.Replace("{Repair_F}", dt3.Rows[0].ItemArray[134].ToString(), true, true);
                        document.Replace("{Repair_M}", dt3.Rows[0].ItemArray[135].ToString(), true, true);
                        document.Replace("{Repair_Q}", dt3.Rows[0].ItemArray[136].ToString(), true, true);
                        document.Replace("{Repair_H}", dt3.Rows[0].ItemArray[137].ToString(), true, true);
                        document.Replace("{Repair_A}", dt3.Rows[0].ItemArray[138].ToString(), true, true);
                        document.Replace("{Repair_T}", dt3.Rows[0].ItemArray[139].ToString(), true, true);

                        document.Replace("{Electr_F}", dt3.Rows[0].ItemArray[140].ToString(), true, true);
                        document.Replace("{Electr_M}", dt3.Rows[0].ItemArray[141].ToString(), true, true);
                        document.Replace("{Electr_Q}", dt3.Rows[0].ItemArray[142].ToString(), true, true);
                        document.Replace("{Electr_H}", dt3.Rows[0].ItemArray[143].ToString(), true, true);
                        document.Replace("{Electr_A}", dt3.Rows[0].ItemArray[144].ToString(), true, true);
                        document.Replace("{Electr_T}", dt3.Rows[0].ItemArray[145].ToString(), true, true);

                        document.Replace("{Houselo_F}", dt3.Rows[0].ItemArray[146].ToString(), true, true);
                        document.Replace("{Houselo_M}", dt3.Rows[0].ItemArray[147].ToString(), true, true);
                        document.Replace("{Houselo_Q}", dt3.Rows[0].ItemArray[148].ToString(), true, true);
                        document.Replace("{Houselo_H}", dt3.Rows[0].ItemArray[149].ToString(), true, true);
                        document.Replace("{Houselo_A}", dt3.Rows[0].ItemArray[150].ToString(), true, true);
                        document.Replace("{Houselo_T}", dt3.Rows[0].ItemArray[151].ToString(), true, true);

                        document.Replace("{Rentmo_F}", dt3.Rows[0].ItemArray[152].ToString(), true, true);
                        document.Replace("{Rentmo_M}", dt3.Rows[0].ItemArray[153].ToString(), true, true);
                        document.Replace("{Rentmo_Q}", dt3.Rows[0].ItemArray[154].ToString(), true, true);
                        document.Replace("{Rentmo_H}", dt3.Rows[0].ItemArray[155].ToString(), true, true);
                        document.Replace("{Rentmo_A}", dt3.Rows[0].ItemArray[156].ToString(), true, true);
                        document.Replace("{Rentmo_T}", dt3.Rows[0].ItemArray[157].ToString(), true, true);

                        document.Replace("{Extram_F}", dt3.Rows[0].ItemArray[158].ToString(), true, true);
                        document.Replace("{Extram_M}", dt3.Rows[0].ItemArray[159].ToString(), true, true);
                        document.Replace("{Extram_Q}", dt3.Rows[0].ItemArray[160].ToString(), true, true);
                        document.Replace("{Extram_H}", dt3.Rows[0].ItemArray[161].ToString(), true, true);
                        document.Replace("{Extram_A}", dt3.Rows[0].ItemArray[162].ToString(), true, true);
                        document.Replace("{Extram_T}", dt3.Rows[0].ItemArray[163].ToString(), true, true);

                        document.Replace("{Furni_F}", dt3.Rows[0].ItemArray[164].ToString(), true, true);
                        document.Replace("{Furni_M}", dt3.Rows[0].ItemArray[165].ToString(), true, true);
                        document.Replace("{Furni_Q}", dt3.Rows[0].ItemArray[166].ToString(), true, true);
                        document.Replace("{Furni_H}", dt3.Rows[0].ItemArray[167].ToString(), true, true);
                        document.Replace("{Furni_A}", dt3.Rows[0].ItemArray[168].ToString(), true, true);
                        document.Replace("{Furni_T}", dt3.Rows[0].ItemArray[169].ToString(), true, true);

                        document.Replace("{OtherH_F}", dt3.Rows[0].ItemArray[170].ToString(), true, true);
                        document.Replace("{OtherH_M}", dt3.Rows[0].ItemArray[171].ToString(), true, true);
                        document.Replace("{OtherH_Q}", dt3.Rows[0].ItemArray[172].ToString(), true, true);
                        document.Replace("{OtherH_H}", dt3.Rows[0].ItemArray[173].ToString(), true, true);
                        document.Replace("{OtherH_A}", dt3.Rows[0].ItemArray[174].ToString(), true, true);
                        document.Replace("{OtherH_T}", dt3.Rows[0].ItemArray[175].ToString(), true, true);

                        document.Replace("{Registr_F}", dt3.Rows[0].ItemArray[176].ToString(), true, true);
                        document.Replace("{Registr_M}", dt3.Rows[0].ItemArray[177].ToString(), true, true);
                        document.Replace("{Registr_Q}", dt3.Rows[0].ItemArray[178].ToString(), true, true);
                        document.Replace("{Registr_H}", dt3.Rows[0].ItemArray[179].ToString(), true, true);
                        document.Replace("{Registr_A}", dt3.Rows[0].ItemArray[180].ToString(), true, true);
                        document.Replace("{Registr_T}", dt3.Rows[0].ItemArray[181].ToString(), true, true);

                        document.Replace("{RepaiT_F}", dt3.Rows[0].ItemArray[182].ToString(), true, true);
                        document.Replace("{RepaiT_M}", dt3.Rows[0].ItemArray[183].ToString(), true, true);
                        document.Replace("{RepaiT_Q}", dt3.Rows[0].ItemArray[184].ToString(), true, true);
                        document.Replace("{RepaiT_H}", dt3.Rows[0].ItemArray[185].ToString(), true, true);
                        document.Replace("{RepaiT_A}", dt3.Rows[0].ItemArray[186].ToString(), true, true);
                        document.Replace("{RepaiT_T}", dt3.Rows[0].ItemArray[187].ToString(), true, true);

                        document.Replace("{FuelOil_F}", dt3.Rows[0].ItemArray[188].ToString(), true, true);
                        document.Replace("{FuelOil_M}", dt3.Rows[0].ItemArray[189].ToString(), true, true);
                        document.Replace("{FuelOil_Q}", dt3.Rows[0].ItemArray[190].ToString(), true, true);
                        document.Replace("{FuelOil_H}", dt3.Rows[0].ItemArray[191].ToString(), true, true);
                        document.Replace("{FuelOil_A}", dt3.Rows[0].ItemArray[192].ToString(), true, true);
                        document.Replace("{FuelOil_T}", dt3.Rows[0].ItemArray[193].ToString(), true, true);

                        document.Replace("{ReplaV_F}", dt3.Rows[0].ItemArray[194].ToString(), true, true);
                        document.Replace("{ReplaV_M}", dt3.Rows[0].ItemArray[195].ToString(), true, true);
                        document.Replace("{ReplaV_Q}", dt3.Rows[0].ItemArray[196].ToString(), true, true);
                        document.Replace("{ReplaV_H}", dt3.Rows[0].ItemArray[197].ToString(), true, true);
                        document.Replace("{ReplaV_A}", dt3.Rows[0].ItemArray[198].ToString(), true, true);
                        document.Replace("{ReplaV_T}", dt3.Rows[0].ItemArray[199].ToString(), true, true);

                        document.Replace("{Fares_F}", dt3.Rows[0].ItemArray[200].ToString(), true, true);
                        document.Replace("{Fares_M}", dt3.Rows[0].ItemArray[201].ToString(), true, true);
                        document.Replace("{Fares_Q}", dt3.Rows[0].ItemArray[202].ToString(), true, true);
                        document.Replace("{Fares_H}", dt3.Rows[0].ItemArray[203].ToString(), true, true);
                        document.Replace("{Fares_A}", dt3.Rows[0].ItemArray[204].ToString(), true, true);
                        document.Replace("{Fares_T}", dt3.Rows[0].ItemArray[205].ToString(), true, true);

                        document.Replace("{OtherT_F}", dt3.Rows[0].ItemArray[206].ToString(), true, true);
                        document.Replace("{OtherT_M}", dt3.Rows[0].ItemArray[207].ToString(), true, true);
                        document.Replace("{OtherT_Q}", dt3.Rows[0].ItemArray[208].ToString(), true, true);
                        document.Replace("{OtherT_H}", dt3.Rows[0].ItemArray[209].ToString(), true, true);
                        document.Replace("{OtherT_A}", dt3.Rows[0].ItemArray[210].ToString(), true, true);
                        document.Replace("{OtherT_T}", dt3.Rows[0].ItemArray[211].ToString(), true, true);

                        document.Replace("{Superl_F}", dt3.Rows[0].ItemArray[212].ToString(), true, true);
                        document.Replace("{Superl_M}", dt3.Rows[0].ItemArray[213].ToString(), true, true);
                        document.Replace("{Superl_Q}", dt3.Rows[0].ItemArray[214].ToString(), true, true);
                        document.Replace("{Superl_H}", dt3.Rows[0].ItemArray[215].ToString(), true, true);
                        document.Replace("{Superl_A}", dt3.Rows[0].ItemArray[216].ToString(), true, true);
                        document.Replace("{Superl_T}", dt3.Rows[0].ItemArray[217].ToString(), true, true);

                        document.Replace("{Loans_F}", dt3.Rows[0].ItemArray[218].ToString(), true, true);
                        document.Replace("{Loans_M}", dt3.Rows[0].ItemArray[219].ToString(), true, true);
                        document.Replace("{Loans_Q}", dt3.Rows[0].ItemArray[220].ToString(), true, true);
                        document.Replace("{Loans_H}", dt3.Rows[0].ItemArray[221].ToString(), true, true);
                        document.Replace("{Loans_A}", dt3.Rows[0].ItemArray[222].ToString(), true, true);
                        document.Replace("{Loans_T}", dt3.Rows[0].ItemArray[223].ToString(), true, true);

                        document.Replace("{Carlo_F}", dt3.Rows[0].ItemArray[224].ToString(), true, true);
                        document.Replace("{Carlo_M}", dt3.Rows[0].ItemArray[225].ToString(), true, true);
                        document.Replace("{Carlo_Q}", dt3.Rows[0].ItemArray[226].ToString(), true, true);
                        document.Replace("{Carlo_H}", dt3.Rows[0].ItemArray[227].ToString(), true, true);
                        document.Replace("{Carlo_A}", dt3.Rows[0].ItemArray[228].ToString(), true, true);
                        document.Replace("{Carlo_T}", dt3.Rows[0].ItemArray[229].ToString(), true, true);

                        document.Replace("{OtherG_F}", dt3.Rows[0].ItemArray[230].ToString(), true, true);
                        document.Replace("{OtherG_M}", dt3.Rows[0].ItemArray[231].ToString(), true, true);
                        document.Replace("{OtherG_Q}", dt3.Rows[0].ItemArray[232].ToString(), true, true);
                        document.Replace("{OtherG_H}", dt3.Rows[0].ItemArray[233].ToString(), true, true);
                        document.Replace("{OtherG_A}", dt3.Rows[0].ItemArray[234].ToString(), true, true);
                        document.Replace("{OtherG_T}", dt3.Rows[0].ItemArray[235].ToString(), true, true);

                        document.Replace("{Foodli_F}", dt3.Rows[0].ItemArray[236].ToString(), true, true);
                        document.Replace("{Foodli_M}", dt3.Rows[0].ItemArray[237].ToString(), true, true);
                        document.Replace("{Foodli_Q}", dt3.Rows[0].ItemArray[238].ToString(), true, true);
                        document.Replace("{Foodli_H}", dt3.Rows[0].ItemArray[239].ToString(), true, true);
                        document.Replace("{Foodli_A}", dt3.Rows[0].ItemArray[240].ToString(), true, true);
                        document.Replace("{Foodli_T}", dt3.Rows[0].ItemArray[241].ToString(), true, true);

                        document.Replace("{ClotfC_F}", dt3.Rows[0].ItemArray[242].ToString(), true, true);
                        document.Replace("{ClotfC_M}", dt3.Rows[0].ItemArray[243].ToString(), true, true);
                        document.Replace("{ClotfC_Q}", dt3.Rows[0].ItemArray[244].ToString(), true, true);
                        document.Replace("{ClotfC_H}", dt3.Rows[0].ItemArray[245].ToString(), true, true);
                        document.Replace("{ClotfC_A}", dt3.Rows[0].ItemArray[246].ToString(), true, true);
                        document.Replace("{ClotfC_T}", dt3.Rows[0].ItemArray[247].ToString(), true, true);

                        document.Replace("{Educat_F}", dt3.Rows[0].ItemArray[248].ToString(), true, true);
                        document.Replace("{Educat_M}", dt3.Rows[0].ItemArray[249].ToString(), true, true);
                        document.Replace("{Educat_Q}", dt3.Rows[0].ItemArray[250].ToString(), true, true);
                        document.Replace("{Educat_H}", dt3.Rows[0].ItemArray[251].ToString(), true, true);
                        document.Replace("{Educat_A}", dt3.Rows[0].ItemArray[252].ToString(), true, true);
                        document.Replace("{Educat_T}", dt3.Rows[0].ItemArray[253].ToString(), true, true);

                        document.Replace("{OtherC_F}", dt3.Rows[0].ItemArray[254].ToString(), true, true);
                        document.Replace("{OtherC_M}", dt3.Rows[0].ItemArray[255].ToString(), true, true);
                        document.Replace("{OtherC_Q}", dt3.Rows[0].ItemArray[256].ToString(), true, true);
                        document.Replace("{OtherC_H}", dt3.Rows[0].ItemArray[257].ToString(), true, true);
                        document.Replace("{OtherC_A}", dt3.Rows[0].ItemArray[258].ToString(), true, true);
                        document.Replace("{OtherC_T}", dt3.Rows[0].ItemArray[259].ToString(), true, true);

                        document.Replace("{Total_F}", dt3.Rows[0].ItemArray[260].ToString(), true, true);
                        document.Replace("{Total_M}", dt3.Rows[0].ItemArray[261].ToString(), true, true);
                        document.Replace("{Total_Q}", dt3.Rows[0].ItemArray[262].ToString(), true, true);
                        document.Replace("{Total_H}", dt3.Rows[0].ItemArray[263].ToString(), true, true);
                        document.Replace("{Total_A}", dt3.Rows[0].ItemArray[264].ToString(), true, true);
                        document.Replace("{Total_T}", dt3.Rows[0].ItemArray[265].ToString(), true, true);
                    }
                    #endregion

                    //Saves the resultant file in the given path.
                    docStream = File.Create(Path.GetFullPath(filePathName));
                    document.Save(docStream, FormatType.Docx);
                    docStream.Dispose();
                }
            }

            // TIC Logo Add
            //WordImages(filePathName);

            //Syncfunction PDF
            ConvertPDF(filePathName, fileName);
            //}
        }

        private void ConvertPDF(string filePathName, string fileName)
        {
            ////Creates an instance of WordDocument Instance (Empty Word Document)
            //WordDocument wordDocument = new WordDocument();
            //    //Add a section and a paragraph in the empty document
            //    wordDocument.EnsureMinimal();
            //    //Append text to the last paragraph of the document
            //    wordDocument.LastParagraph.Text = "Adventure Works Cycles, the fictitious company on which the" +
            //" AdventureWorks sample databases are based, is a large, multinational manufacturing company. ";

            Stream inputStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read);

            //Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            //Stream inputStream = assembly.GetManifestResourceStream("fasdf_5.docx");
            WordDocument document = new WordDocument(inputStream, FormatType.Docx);

            //Instantiation of DocIORenderer for Word to PDF conversion
            DocIORenderer render = new DocIORenderer();
            //Converts Word document into PDF document
            PdfDocument pdfDocument = render.ConvertToPDF(document);
            //Releases all resources used by the Word document and DocIO Renderer objects
            render.Dispose();
            document.Dispose();
            //Saves the PDF file
            MemoryStream outputStream = new MemoryStream();
            pdfDocument.Save(outputStream);
            //Closes the instance of PDF document object
            pdfDocument.Close();
            outputStream.Position = 0;
            //Save the PDF file
            SavePDF(outputStream, fileName);
        }

        private async void SavePDF(Stream outputStream, string fileName)
        {
            StorageFile stFile;

            string folderPath = @"C:\tic\Documents";
            StorageFolder local = await StorageFolder.GetFolderFromPathAsync(folderPath);
            stFile = await local.CreateFileAsync(fileName + ".pdf", CreationCollisionOption.ReplaceExisting);

            if (stFile != null)
            {
                Windows.Storage.Streams.IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                Stream st = fileStream.AsStreamForWrite();
                st.SetLength(0);
                st.Write((outputStream as MemoryStream).ToArray(), 0, (int)outputStream.Length);
                st.Flush();
                st.Dispose();
                fileStream.Dispose();

                DataAccess._PageViewerFilePath = folderPath + @"\" + fileName + ".pdf";
            }
        }
    }
}
