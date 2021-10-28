using System;
using System.Data;
using System.IO;
using System.Windows.Controls;
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

        private async void BtnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                //LoadingIndicator.IsActive = true;

                DateTime dt = Convert.ToDateTime(dataPicket1.EditValue);

                string fileNotesFolderPath = @"C:\tic\FileNotes";
                DataAccess.AddDataCoverPage(txtPreparedFor.Text, txtYourAdviser.Text, dt, "", fileNotesFolderPath);

                StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(fileNotesFolderPath);

                string fileName = "FileNotesCoverPage_" + DataAccess._CoverPageID;
                var file = await storageFolder.CreateFileAsync(fileName + ".jpg", CreationCollisionOption.ReplaceExisting);

                //CanvasDevice device = CanvasDevice.GetSharedDevice();
                //CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)myInkCanvas.ActualWidth, (int)myInkCanvas.ActualHeight, 96);

                //using (var ds = renderTarget.CreateDrawingSession())
                //{
                //    ds.Clear(Colors.White);
                //    ds.DrawInk(myInkCanvas.InkPresenter.StrokeContainer.GetStrokes());
                //}

                //using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                //{
                //    await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Jpeg, 1f);
                //}

                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(fileNotesFolderPath +"//"+ fileName + ".jpg", FileMode.Create);

                RenderTargetBitmap rtb = new RenderTargetBitmap((int)myInkCanvas.ActualWidth, (int)myInkCanvas.ActualHeight, 96d, 96d, PixelFormats.Default);
                rtb.Render(myInkCanvas);
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));

                encoder.Save(fs);
                fs.Close();

                var dialog = new MessageDialog("Cover Page data saved successfully.", "Successful");
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //LoadingIndicator.IsActive = false;
            }
        }

        private void BtnNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnPDF_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataAccess._CoverPageID > 0)
            {
                DataTable dt = DataAccess.getCoverPageData(DataAccess._CoverPageID);
                if (dt.Rows.Count > 0)
                {
                    DateTime dDated = new DateTime();
                    dDated = Convert.ToDateTime(dt.Rows[0].ItemArray[3].ToString());

                    txtPreparedFor.Text = dt.Rows[0].ItemArray[1].ToString();
                    txtYourAdviser.Text = dt.Rows[0].ItemArray[2].ToString();
                    dataPicket1.EditValue = dDated;
                }
            }
        }
    }
}
