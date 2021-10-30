using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Storage;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for SelectionAPersonalDetails.xaml
    /// </summary>
    public partial class SelectionAPersonalDetails : UserControl
    {
        public SelectionAPersonalDetails()
        {
            InitializeComponent();
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //LoadingIndicator.IsActive = true;

                int gender_client1 = 0;
                if ((bool)rbGenderMale_Client1.IsChecked)
                    gender_client1 = 1;
                else if ((bool)rbGenderFemale_Client1.IsChecked)
                    gender_client1 = 2;

                int gender_client2 = 0;
                if ((bool)rbGenderMale_Client2.IsChecked)
                    gender_client2 = 1;
                else if ((bool)rbGenderFemale_Client2.IsChecked)
                    gender_client2 = 2;

                DateTime dateOfBirth_Client1 = Convert.ToDateTime(dtDateOfBirth_Client1.EditValue);
                DateTime dateOfBirth_Client2 = Convert.ToDateTime(dtDateOfBirth_Client2.EditValue);

                int age_client1 = Convert.ToInt32(spnAge_Client1.EditValue);
                int age_client2 = Convert.ToInt32(spnAge_Client2.EditValue);

                int maritalstatus_Client1 = 0;
                if ((bool)rbMarried_Client1.IsChecked)
                    maritalstatus_Client1 = 1;
                else if ((bool)rbDivorced_Client1.IsChecked)
                    maritalstatus_Client1 = 2;
                else if ((bool)rbSingle_Client1.IsChecked)
                    maritalstatus_Client1 = 3;
                else if ((bool)rbWidowEd1_Client1.IsChecked)
                    maritalstatus_Client1 = 4;
                else if ((bool)rbDeFacto_Client1.IsChecked)
                    maritalstatus_Client1 = 5;
                else if ((bool)rbUnknown_Client1.IsChecked)
                    maritalstatus_Client1 = 6;

                int maritalstatus_Client2 = 0;
                if ((bool)rbMarried_Client2.IsChecked)
                    maritalstatus_Client2 = 1;
                else if ((bool)rbDivorced_Client2.IsChecked)
                    maritalstatus_Client2 = 2;
                else if ((bool)rbSingle_Client2.IsChecked)
                    maritalstatus_Client2 = 3;
                else if ((bool)rbWidowEd1_Client2.IsChecked)
                    maritalstatus_Client2 = 4;
                else if ((bool)rbDeFacto_Client2.IsChecked)
                    maritalstatus_Client2 = 5;
                else if ((bool)rbUnknown_Client2.IsChecked)
                    maritalstatus_Client2 = 6;

                int health_Client1 = 0;
                if ((bool)rbExcellent_Client1.IsChecked)
                    health_Client1 = 1;
                else if ((bool)rbPoor_Client1.IsChecked)
                    health_Client1 = 2;
                else if ((bool)rbGood_Client1.IsChecked)
                    health_Client1 = 3;
                else if ((bool)rbUnknown_HealthClient1.IsChecked)
                    health_Client1 = 4;

                int health_Client2 = 0;
                if ((bool)rbExcellent_Client2.IsChecked)
                    health_Client2 = 1;
                else if ((bool)rbPoor_Client2.IsChecked)
                    health_Client2 = 2;
                else if ((bool)rbGood_Client2.IsChecked)
                    health_Client2 = 3;
                else if ((bool)rbUnknown_HealthClient2.IsChecked)
                    health_Client2 = 4;

                int smoker_Client1 = 0;
                if ((bool)rbYes_SmokerClient1.IsChecked)
                    smoker_Client1 = 1;
                else if ((bool)rbNo_SmokerClient1.IsChecked)
                    smoker_Client1 = 2;

                int smoker_Client2 = 0;
                if ((bool)rbYes_SmokerClient2.IsChecked)
                    smoker_Client2 = 1;
                else if ((bool)rbNo_SmokerClient2.IsChecked)
                    smoker_Client2 = 2;

                int gender_dependant1 = 0;
                if ((bool)rbGenderMale_Dependant1.IsChecked)
                    gender_dependant1 = 1;
                else if ((bool)rbGenderFemale_Dependant1.IsChecked)
                    gender_dependant1 = 2;

                int gender_dependant2 = 0;
                if ((bool)rbGenderMale_Dependant2.IsChecked)
                    gender_dependant2 = 1;
                else if ((bool)rbGenderFemale_Dependant2.IsChecked)
                    gender_dependant2 = 2;

                int gender_dependant3 = 0;
                if ((bool)rbGenderMale_Dependant3.IsChecked)
                    gender_dependant3 = 1;
                else if ((bool)rbGenderFemale_Dependant3.IsChecked)
                    gender_dependant3 = 2;

                DateTime dateOfBirth_dependant1 = Convert.ToDateTime(dtDateOfBirth_Dependant1.EditValue);
                DateTime dateOfBirth_dependant2 = Convert.ToDateTime(dtDateOfBirth_Dependant2.EditValue);
                DateTime dateOfBirth_dependant3 = Convert.ToDateTime(dtDateOfBirth_Dependant3.EditValue);

                int age_dependant1 = Convert.ToInt32(spnAge_Dependant1.EditValue);
                int age_dependant2 = Convert.ToInt32(spnAge_Dependant2.EditValue);
                int age_dependant3 = Convert.ToInt32(spnAge_Dependant3.EditValue);

                int specialNeeds_Dependant1 = 0;
                if ((bool)rbSpecialNeedsYes_Dependant1.IsChecked)
                    specialNeeds_Dependant1 = 1;
                else if ((bool)rbSpecialNeedsNo_Dependant1.IsChecked)
                    specialNeeds_Dependant1 = 2;

                int specialNeeds_Dependant2 = 0;
                if ((bool)rbSpecialNeedsYes_Dependant2.IsChecked)
                    specialNeeds_Dependant2 = 1;
                else if ((bool)rbSpecialNeedsNo_Dependant2.IsChecked)
                    specialNeeds_Dependant2 = 2;

                int specialNeeds_Dependant3 = 0;
                if ((bool)rbSpecialNeedsYes_Dependant3.IsChecked)
                    specialNeeds_Dependant3 = 1;
                else if ((bool)rbSpecialNeedsNo_Dependant3.IsChecked)
                    specialNeeds_Dependant3 = 2;

                int austudyStatus_Dependant1 = 0;
                if ((bool)rbNotclaiming_Dependant1.IsChecked)
                    austudyStatus_Dependant1 = 1;
                else if ((bool)rbHome_Dependant1.IsChecked)
                    austudyStatus_Dependant1 = 2;
                else if ((bool)rbAwayfromhome_Dependant1.IsChecked)
                    austudyStatus_Dependant1 = 3;

                int austudyStatus_Dependant2 = 0;
                if ((bool)rbNotclaiming_Dependant2.IsChecked)
                    austudyStatus_Dependant2 = 1;
                else if ((bool)rbHome_Dependant2.IsChecked)
                    austudyStatus_Dependant2 = 2;
                else if ((bool)rbAwayfromhome_Dependant2.IsChecked)
                    austudyStatus_Dependant2 = 3;

                int austudyStatus_Dependant3 = 0;
                if ((bool)rbNotclaiming_Dependant3.IsChecked)
                    austudyStatus_Dependant3 = 1;
                else if ((bool)rbHome_Dependant3.IsChecked)
                    austudyStatus_Dependant3 = 2;
                else if ((bool)rbAwayfromhome_Dependant3.IsChecked)
                    austudyStatus_Dependant3 = 3;

                string fileNotesFolderPath = @"C:\tic\FileNotes";

                DataAccess.AddDataSelectionAPersonalDetails(txtSurnameMaidenName_Client1.Text,
                    txtSurnameMaidenName_Client2.Text,
                    txtGivenNames_Client1.Text,
                    txtGivenNames_Client2.Text,
                    txtPreferredShortName_Client1.Text,
                    txtPreferredShortName_Client2.Text,
                    txtTitle_Client1.Text,
                    txtTitle_Client2.Text,
                    gender_client1,
                    gender_client2,
                    dateOfBirth_Client1,
                    dateOfBirth_Client2,
                    age_client1,
                    age_client2,
                    maritalstatus_Client1,
                    maritalstatus_Client2,
                    health_Client1,
                    health_Client2,
                    smoker_Client1,
                    smoker_Client2,
                    txtTownOfBirth_Client1.Text,
                    txtTownOfBirth_Client2.Text,
                    txtCountryOfBirth_Client1.Text,
                    txtCountryOfBirth_Client2.Text,
                    txtIfnotAustraliayearsinAustralia_Client1.Text,
                    txtIfnotAustraliayearsinAustralia_Client2.Text,
                    txtAreyouanonresident_Client1.Text,
                    txtAreyouanonresident_Client2.Text,
                    txtTaxfilenumber_Client1.Text,
                    txtTaxfilenumber_Client2.Text,
                    txtWereyoureferredtous_Client1.Text,
                    txtWereyoureferredtous_Client2.Text,
                    txtHaveyouworkedwithanotheradviser_Client1.Text,
                    txtHaveyouworkedwithanotheradviser_Client2.Text,
                    txtAreyouaresidentofanothercountryfortaxpurposes_Client1.Text,
                    txtAreyouaresidentofanothercountryfortaxpurposes_Client2.Text,
                    txtIfyescountryofresidence_Client1.Text,
                    txtIfyescountryofresidence_Client2.Text,
                    txtTaxidentificationnumberTINofforeigncountry_Client1.Text,
                    txtTaxidentificationnumberTINofforeigncountry_Client2.Text,
                    txtAreyouapoliticallyexposedperson_Client1.Text,
                    txtAreyouapoliticallyexposedperson_Client2.Text,
                    txtAddresspostal_Client1.Text,
                    txtAddresspostal_Client2.Text,
                    txtAddresspostal2_Client1.Text,
                    txtAddresspostal2_Client2.Text,
                    txtAddresspostalState_Client1.Text,
                    txtAddresspostalState_Client2.Text,
                    txtAddresspostalPostcode_Client1.Text,
                    txtAddresspostalPostcode_Client2.Text,
                    txtAddressresidentialother_Client1.Text,
                    txtAddressresidentialother_Client2.Text,
                    txtAddressresidentialotherState_Client1.Text,
                    txtAddressresidentialotherState_Client2.Text,
                    txtAddressresidentialotherPostcode_Client1.Text,
                    txtAddressresidentialotherPostcode_Client2.Text,
                    txtEmailaddress_Client1.Text,
                    txtEmailaddress_Client2.Text,
                    txtContactnumbersmainnumber_Client1.Text,
                    txtContactnumbersmainnumber_Client2.Text,
                    txtOfficephone_Client1.Text,
                    txtOfficephone_Client2.Text,
                    txtMobile_Client1.Text,
                    txtMobile_Client2.Text,
                    txtFax_Client1.Text,
                    txtFax_Client2.Text,
                    txtSurnameName_Dependant1.Text,
                    txtSurnameName_Dependant2.Text,
                    txtSurnameName_Dependant3.Text,
                    txtGivenNames_Dependant1.Text,
                    txtGivenNames_Dependant2.Text,
                    txtGivenNames_Dependant3.Text,
                    txtPreferredShortName_Dependant1.Text,
                    txtPreferredShortName_Dependant2.Text,
                    txtPreferredShortName_Dependant3.Text,
                    txtTitle_Dependant1.Text,
                    txtTitle_Dependant2.Text,
                    txtTitle_Dependant3.Text,
                    gender_dependant1,
                    gender_dependant2,
                    gender_dependant3,
                    dateOfBirth_dependant1,
                    dateOfBirth_dependant2,
                    dateOfBirth_dependant3,
                    age_dependant1,
                    age_dependant2,
                    age_dependant3,
                    txtRelationship_Dependant1.Text,
                    txtRelationship_Dependant2.Text,
                    txtRelationship_Dependant3.Text,
                    specialNeeds_Dependant1,
                    specialNeeds_Dependant2,
                    specialNeeds_Dependant3,
                    txtDetails_Dependant1.Text,
                    txtDetails_Dependant2.Text,
                    txtDetails_Dependant3.Text,
                    txtDetails2_Dependant1.Text,
                    txtDetails2_Dependant2.Text,
                    txtDetails2_Dependant3.Text,
                    txtDetails3_Dependant1.Text,
                    txtDetails3_Dependant2.Text,
                    txtDetails3_Dependant3.Text,
                    txtSupporttoage_Dependant1.Text,
                    txtSupporttoage_Dependant2.Text,
                    txtSupporttoage_Dependant3.Text,
                    txtSchoolName_Dependant1.Text,
                    txtSchoolName_Dependant2.Text,
                    txtSchoolName_Dependant3.Text,
                    txtSchoolYearLevel_Dependant1.Text,
                    txtSchoolYearLevel_Dependant2.Text,
                    txtSchoolYearLevel_Dependant3.Text,
                    txtEstimatedCostofSchooling_Dependant1.Text,
                    txtEstimatedCostofSchooling_Dependant2.Text,
                    txtEstimatedCostofSchooling_Dependant3.Text,
                    austudyStatus_Dependant1,
                    austudyStatus_Dependant2,
                    austudyStatus_Dependant3,
                    txtClientsParents.Text,
                    "FileNotesClientsParents_FileName",
                    fileNotesFolderPath,
                    txtEgCollectablesGolfTennis_Client1.Text,
                    txtEgCollectablesGolfTennis_Client2.Text,
                    txtEgCollectablesGolfTennis2_Client1.Text,
                    txtEgCollectablesGolfTennis2_Client2.Text,
                    txtEgCollectablesGolfTennis3_Client1.Text,
                    txtEgCollectablesGolfTennis3_Client2.Text,
                    txtBusinessname_Accountant.Text,
                    txtBusinessname_Banker.Text,
                    txtBusinessname_Lawyer.Text,
                    txtContactname_Accountant.Text,
                    txtContactname_Banker.Text,
                    txtContactname_Lawyer.Text,
                    txtPostaladdress_Accountant.Text,
                    txtPostaladdress_Banker.Text,
                    txtPostaladdress_Lawyer.Text,
                    txtPostaladdress2_Accountant.Text,
                    txtPostaladdress2_Banker.Text,
                    txtPostaladdress2_Lawyer.Text,
                    txtPostaladdressState_Accountant.Text,
                    txtPostaladdressState_Banker.Text,
                    txtPostaladdressState_Lawyer.Text,
                    txtPostaladdressPostcode_Accountant.Text,
                    txtPostaladdressPostcode_Banker.Text,
                    txtPostaladdressPostcode_Lawyer.Text,
                    txtEmailaddress_Accountant.Text,
                    txtEmailaddress_Banker.Text,
                    txtEmailaddress_Lawyer.Text,
                    txtPhoneaddress_Accountant.Text,
                    txtPhoneaddress_Banker.Text,
                    txtPhoneaddress_Lawyer.Text,
                    txtFaxnumber_Accountant.Text,
                    txtFaxnumber_Banker.Text,
                    txtFaxnumber_Lawyer.Text,
                    "FileNotes_FileName",
                    fileNotesFolderPath
                    );

                StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(fileNotesFolderPath);

                string fileName = "FileNotesSelectionA_" + DataAccess._CoverPageID;
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
                FileStream fs = new FileStream(fileNotesFolderPath + "//" + fileName + ".jpg", FileMode.Create);

                RenderTargetBitmap rtb = new RenderTargetBitmap((int)myInkCanvas.ActualWidth, (int)myInkCanvas.ActualHeight, 96d, 96d, PixelFormats.Default);
                rtb.Render(myInkCanvas);
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));

                encoder.Save(fs);
                fs.Close();

                //FileNotesSelectionACentrelink_
                string fileName2 = "FileNotesSelectionAClientsParents_" + DataAccess._CoverPageID;
                var file2 = await storageFolder.CreateFileAsync(fileName2 + ".jpg", CreationCollisionOption.ReplaceExisting);

                //CanvasDevice device2 = CanvasDevice.GetSharedDevice();
                //CanvasRenderTarget renderTarget2 = new CanvasRenderTarget(
                //    device2,
                //    (int)myInkCanvasFileNotesClientsParents.ActualWidth,
                //    (int)myInkCanvasFileNotesClientsParents.ActualHeight,
                //    96);

                //using (var ds2 = renderTarget2.CreateDrawingSession())
                //{
                //    ds2.Clear(Colors.White);
                //    ds2.DrawInk(myInkCanvasFileNotesClientsParents.InkPresenter.StrokeContainer.GetStrokes());
                //}

                //using (var fileStream2 = await file2.OpenAsync(FileAccessMode.ReadWrite))
                //{
                //    await renderTarget2.SaveAsync(fileStream2, CanvasBitmapFileFormat.Jpeg, 1f);
                //}

                MemoryStream ms2 = new MemoryStream();
                FileStream fs2 = new FileStream(fileNotesFolderPath + "//" + fileName2 + ".jpg", FileMode.Create);

                RenderTargetBitmap rtb2 = new RenderTargetBitmap((int)myInkCanvasFileNotesClientsParents.ActualWidth, (int)myInkCanvasFileNotesClientsParents.ActualHeight, 96d, 96d, PixelFormats.Default);
                rtb2.Render(myInkCanvasFileNotesClientsParents);
                JpegBitmapEncoder encoder2 = new JpegBitmapEncoder();
                encoder2.Frames.Add(BitmapFrame.Create(rtb2));

                encoder2.Save(fs2);
                fs2.Close();

                MessageBoxResult result = DXMessageBox.Show("Selection A - Personal Details data saved successfully.", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            catch (Exception)
            {

            }
            finally
            {
                //LoadingIndicator.IsActive = false;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataAccess._CoverPageID > 0)
            {
                DataTable dt = DataAccess.getSelectionAPersonalDetails(DataAccess._CoverPageID);
                if (dt.Rows.Count > 0)
                {

                }
            }
        }
    }
}
