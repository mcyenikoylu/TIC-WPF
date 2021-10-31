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
                    //Personal Details
                    txtSurnameMaidenName_Client1.Text = dt.Rows[0].ItemArray[2].ToString();
                    txtSurnameMaidenName_Client2.Text = dt.Rows[0].ItemArray[3].ToString();

                    txtGivenNames_Client1.Text = dt.Rows[0].ItemArray[4].ToString();
                    txtGivenNames_Client2.Text = dt.Rows[0].ItemArray[5].ToString();

                    txtPreferredShortName_Client1.Text = dt.Rows[0].ItemArray[6].ToString();
                    txtPreferredShortName_Client2.Text = dt.Rows[0].ItemArray[7].ToString();

                    txtTitle_Client1.Text = dt.Rows[0].ItemArray[8].ToString();
                    txtTitle_Client2.Text = dt.Rows[0].ItemArray[9].ToString();

                    int gender_client1 = Convert.ToInt32(dt.Rows[0].ItemArray[10]);
                    if (gender_client1 == 1)
                        rbGenderMale_Client1.IsChecked = true;
                    else if (gender_client1 == 2)
                        rbGenderFemale_Client1.IsChecked = true;

                    int gender_client2 = Convert.ToInt32(dt.Rows[0].ItemArray[11]);
                    if (gender_client2 == 1)
                        rbGenderMale_Client2.IsChecked = true;
                    else if (gender_client2 == 2)
                        rbGenderFemale_Client2.IsChecked = true;

                    DateTime dateOfBirth_Client1 = Convert.ToDateTime(dt.Rows[0].ItemArray[12]);
                    DateTime dateOfBirth_Client2 = Convert.ToDateTime(dt.Rows[0].ItemArray[13]);
                    dtDateOfBirth_Client1.EditValue = dateOfBirth_Client1;
                    dtDateOfBirth_Client2.EditValue = dateOfBirth_Client2;

                    int age_client1 = Convert.ToInt32(dt.Rows[0].ItemArray[14]);
                    int age_client2 = Convert.ToInt32(dt.Rows[0].ItemArray[15]);
                    spnAge_Client1.EditValue = age_client1;
                    spnAge_Client2.EditValue = age_client2;

                    int maritalstatus_Client1 = Convert.ToInt32(dt.Rows[0].ItemArray[16]);
                    if (maritalstatus_Client1 == 1)
                        rbMarried_Client1.IsChecked = true;
                    else if (maritalstatus_Client1 == 2)
                        rbDivorced_Client1.IsChecked = true;
                    else if (maritalstatus_Client1 == 3)
                        rbSingle_Client1.IsChecked = true;
                    else if (maritalstatus_Client1 == 4)
                        rbWidowEd1_Client1.IsChecked = true;
                    else if (maritalstatus_Client1 == 5)
                        rbDeFacto_Client1.IsChecked = true;
                    else if (maritalstatus_Client1 == 6)
                        rbUnknown_Client1.IsChecked = true;

                    int maritalstatus_Client2 = Convert.ToInt32(dt.Rows[0].ItemArray[17]);
                    if (maritalstatus_Client2 == 1)
                        rbMarried_Client2.IsChecked = true;
                    else if (maritalstatus_Client2 == 2)
                        rbDivorced_Client2.IsChecked = true;
                    else if (maritalstatus_Client2 == 3)
                        rbSingle_Client2.IsChecked = true;
                    else if (maritalstatus_Client2 == 4)
                        rbWidowEd1_Client2.IsChecked = true;
                    else if (maritalstatus_Client2 == 5)
                        rbDeFacto_Client2.IsChecked = true;
                    else if (maritalstatus_Client2 == 6)
                        rbUnknown_Client2.IsChecked = true;

                    int health_Client1 = Convert.ToInt32(dt.Rows[0].ItemArray[18]);
                    if (health_Client1 == 1)
                        rbExcellent_Client1.IsChecked = true;
                    else if (health_Client1 == 2)
                        rbPoor_Client1.IsChecked = true;
                    else if (health_Client1 == 3)
                        rbGood_Client1.IsChecked = true;
                    else if (health_Client1 == 4)
                        rbUnknown_HealthClient1.IsChecked = true;

                    int health_Client2 = Convert.ToInt32(dt.Rows[0].ItemArray[19]);
                    if (health_Client2 == 1)
                        rbExcellent_Client2.IsChecked = true;
                    else if (health_Client2 == 2)
                        rbPoor_Client2.IsChecked = true;
                    else if (health_Client2 == 3)
                        rbGood_Client2.IsChecked = true;
                    else if (health_Client2 == 4)
                        rbUnknown_HealthClient1.IsChecked = true;

                    int smoker_Client1 = Convert.ToInt32(dt.Rows[0].ItemArray[20]);
                    if (smoker_Client1 == 1)
                        rbYes_SmokerClient1.IsChecked = true;
                    else if (smoker_Client1 == 2)
                        rbNo_SmokerClient1.IsChecked = true;

                    int smoker_Client2 = Convert.ToInt32(dt.Rows[0].ItemArray[21]);
                    if (smoker_Client2 == 1)
                        rbYes_SmokerClient1.IsChecked = true;
                    else if (smoker_Client2 == 2)
                        rbNo_SmokerClient1.IsChecked = true;

                    txtTownOfBirth_Client1.Text = dt.Rows[0].ItemArray[22].ToString();
                    txtTownOfBirth_Client2.Text = dt.Rows[0].ItemArray[23].ToString();

                    txtCountryOfBirth_Client1.Text = dt.Rows[0].ItemArray[24].ToString();
                    txtCountryOfBirth_Client2.Text = dt.Rows[0].ItemArray[25].ToString();

                    txtIfnotAustraliayearsinAustralia_Client1.Text = dt.Rows[0].ItemArray[26].ToString();
                    txtIfnotAustraliayearsinAustralia_Client2.Text = dt.Rows[0].ItemArray[27].ToString();

                    txtAreyouanonresident_Client1.Text = dt.Rows[0].ItemArray[28].ToString();
                    txtAreyouanonresident_Client2.Text = dt.Rows[0].ItemArray[29].ToString();

                    txtTaxfilenumber_Client1.Text = dt.Rows[0].ItemArray[30].ToString();
                    txtTaxfilenumber_Client2.Text = dt.Rows[0].ItemArray[31].ToString();

                    txtWereyoureferredtous_Client1.Text = dt.Rows[0].ItemArray[32].ToString();
                    txtWereyoureferredtous_Client2.Text = dt.Rows[0].ItemArray[33].ToString();

                    txtHaveyouworkedwithanotheradviser_Client1.Text = dt.Rows[0].ItemArray[34].ToString();
                    txtHaveyouworkedwithanotheradviser_Client2.Text = dt.Rows[0].ItemArray[35].ToString();

                    txtAreyouaresidentofanothercountryfortaxpurposes_Client1.Text = dt.Rows[0].ItemArray[36].ToString();
                    txtAreyouaresidentofanothercountryfortaxpurposes_Client2.Text = dt.Rows[0].ItemArray[37].ToString();

                    txtIfyescountryofresidence_Client1.Text = dt.Rows[0].ItemArray[38].ToString();
                    txtIfyescountryofresidence_Client2.Text = dt.Rows[0].ItemArray[39].ToString();

                    txtTaxidentificationnumberTINofforeigncountry_Client1.Text = dt.Rows[0].ItemArray[40].ToString();
                    txtTaxidentificationnumberTINofforeigncountry_Client2.Text = dt.Rows[0].ItemArray[41].ToString();

                    txtAreyouapoliticallyexposedperson_Client1.Text = dt.Rows[0].ItemArray[42].ToString();
                    txtAreyouapoliticallyexposedperson_Client2.Text = dt.Rows[0].ItemArray[43].ToString();

                    //Contact Details
                    txtAddresspostal_Client1.Text = dt.Rows[0].ItemArray[44].ToString();
                    txtAddresspostal_Client2.Text = dt.Rows[0].ItemArray[45].ToString();

                    txtAddresspostal2_Client1.Text = dt.Rows[0].ItemArray[46].ToString();
                    txtAddresspostal2_Client2.Text = dt.Rows[0].ItemArray[47].ToString();

                    txtAddresspostalState_Client1.Text = dt.Rows[0].ItemArray[48].ToString();
                    txtAddresspostalState_Client2.Text = dt.Rows[0].ItemArray[49].ToString();

                    txtAddresspostalPostcode_Client1.Text = dt.Rows[0].ItemArray[50].ToString();
                    txtAddresspostalPostcode_Client2.Text = dt.Rows[0].ItemArray[51].ToString();

                    txtAddressresidentialother_Client1.Text = dt.Rows[0].ItemArray[52].ToString();
                    txtAddressresidentialother_Client2.Text = dt.Rows[0].ItemArray[53].ToString();

                    txtAddressresidentialotherState_Client1.Text = dt.Rows[0].ItemArray[54].ToString();
                    txtAddressresidentialotherState_Client2.Text = dt.Rows[0].ItemArray[55].ToString();

                    txtAddressresidentialotherPostcode_Client1.Text = dt.Rows[0].ItemArray[56].ToString();
                    txtAddressresidentialotherPostcode_Client2.Text = dt.Rows[0].ItemArray[57].ToString();

                    txtEmailaddress_Client1.Text = dt.Rows[0].ItemArray[58].ToString();
                    txtEmailaddress_Client2.Text = dt.Rows[0].ItemArray[59].ToString();

                    txtContactnumbersmainnumber_Client1.Text = dt.Rows[0].ItemArray[60].ToString();
                    txtContactnumbersmainnumber_Client2.Text = dt.Rows[0].ItemArray[61].ToString();

                    txtOfficephone_Client1.Text = dt.Rows[0].ItemArray[62].ToString();
                    txtOfficephone_Client2.Text = dt.Rows[0].ItemArray[63].ToString();

                    txtMobile_Client1.Text = dt.Rows[0].ItemArray[64].ToString();
                    txtMobile_Client1.Text = dt.Rows[0].ItemArray[65].ToString();

                    txtFax_Client1.Text = dt.Rows[0].ItemArray[66].ToString();
                    txtFax_Client2.Text = dt.Rows[0].ItemArray[67].ToString();

                    //Dependants
                    txtSurnameName_Dependant1.Text = dt.Rows[0].ItemArray[68].ToString();
                    txtSurnameName_Dependant2.Text = dt.Rows[0].ItemArray[69].ToString();
                    txtSurnameName_Dependant3.Text = dt.Rows[0].ItemArray[70].ToString();

                    txtGivenNames_Dependant1.Text = dt.Rows[0].ItemArray[71].ToString();
                    txtGivenNames_Dependant2.Text = dt.Rows[0].ItemArray[72].ToString();
                    txtGivenNames_Dependant3.Text = dt.Rows[0].ItemArray[73].ToString();

                    txtPreferredShortName_Dependant1.Text = dt.Rows[0].ItemArray[74].ToString();
                    txtPreferredShortName_Dependant2.Text = dt.Rows[0].ItemArray[75].ToString();
                    txtPreferredShortName_Dependant3.Text = dt.Rows[0].ItemArray[76].ToString();

                    txtTitle_Dependant1.Text = dt.Rows[0].ItemArray[77].ToString();
                    txtTitle_Dependant2.Text = dt.Rows[0].ItemArray[78].ToString();
                    txtTitle_Dependant3.Text = dt.Rows[0].ItemArray[79].ToString();

                    int gender_dependant1 = Convert.ToInt32(dt.Rows[0].ItemArray[80]);
                    if (gender_dependant1 == 1)
                        rbGenderMale_Dependant1.IsChecked = true;
                    else if (gender_dependant1 == 2)
                        rbGenderFemale_Dependant1.IsChecked = true;

                    int gender_dependant2 = Convert.ToInt32(dt.Rows[0].ItemArray[81]);
                    if (gender_dependant2 == 1)
                        rbGenderMale_Dependant2.IsChecked = true;
                    else if (gender_dependant2 == 2)
                        rbGenderFemale_Dependant2.IsChecked = true;

                    int gender_dependant3 = Convert.ToInt32(dt.Rows[0].ItemArray[82]);
                    if (gender_dependant3 == 1)
                        rbGenderMale_Dependant3.IsChecked = true;
                    else if (gender_dependant3 == 2)
                        rbGenderFemale_Dependant3.IsChecked = true;

                    DateTime dateOfBirth_dependant1 = Convert.ToDateTime(dt.Rows[0].ItemArray[83]);
                    dtDateOfBirth_Dependant1.EditValue = dateOfBirth_dependant1;
                    DateTime dateOfBirth_dependant2 = Convert.ToDateTime(dt.Rows[0].ItemArray[84]);
                    dtDateOfBirth_Dependant2.EditValue = dateOfBirth_dependant2;
                    DateTime dateOfBirth_dependant3 = Convert.ToDateTime(dt.Rows[0].ItemArray[85]);
                    dtDateOfBirth_Dependant3.EditValue = dateOfBirth_dependant3;

                    int age_dependant1 = Convert.ToInt32(dt.Rows[0].ItemArray[86]);
                    spnAge_Dependant1.EditValue = age_dependant1;
                    int age_dependant2 = Convert.ToInt32(dt.Rows[0].ItemArray[87]);
                    spnAge_Dependant2.EditValue = age_dependant2;
                    int age_dependant3 = Convert.ToInt32(dt.Rows[0].ItemArray[88]);
                    spnAge_Dependant3.EditValue = age_dependant3;

                    txtRelationship_Dependant1.Text = dt.Rows[0].ItemArray[89].ToString();
                    txtRelationship_Dependant2.Text = dt.Rows[0].ItemArray[90].ToString();
                    txtRelationship_Dependant3.Text = dt.Rows[0].ItemArray[91].ToString();
                     
                    int specialNeeds_Dependant1 = Convert.ToInt32(dt.Rows[0].ItemArray[92]);
                    if (specialNeeds_Dependant1 == 1)
                        rbSpecialNeedsYes_Dependant1.IsChecked = true;
                    else if (specialNeeds_Dependant1 == 2)
                        rbSpecialNeedsNo_Dependant1.IsChecked = true; 

                    int specialNeeds_Dependant2 = Convert.ToInt32(dt.Rows[0].ItemArray[93]);
                    if (specialNeeds_Dependant2 == 1)
                        rbSpecialNeedsYes_Dependant2.IsChecked = true; 
                    else if ((bool)rbSpecialNeedsNo_Dependant2.IsChecked)
                        specialNeeds_Dependant2 = 2;

                    int specialNeeds_Dependant3 = Convert.ToInt32(dt.Rows[0].ItemArray[94]);
                    if (specialNeeds_Dependant3 == 1)
                        rbSpecialNeedsYes_Dependant3.IsChecked = true;
                    else if (specialNeeds_Dependant3 == 2)
                        rbSpecialNeedsNo_Dependant3.IsChecked = true;

                    txtDetails_Dependant1.Text = dt.Rows[0].ItemArray[95].ToString();
                    txtDetails_Dependant2.Text = dt.Rows[0].ItemArray[96].ToString();
                    txtDetails_Dependant3.Text = dt.Rows[0].ItemArray[97].ToString();

                    txtDetails2_Dependant1.Text = dt.Rows[0].ItemArray[98].ToString();
                    txtDetails2_Dependant2.Text = dt.Rows[0].ItemArray[99].ToString();
                    txtDetails2_Dependant3.Text = dt.Rows[0].ItemArray[100].ToString();

                    txtDetails3_Dependant1.Text = dt.Rows[0].ItemArray[101].ToString();
                    txtDetails3_Dependant2.Text = dt.Rows[0].ItemArray[102].ToString();
                    txtDetails3_Dependant3.Text = dt.Rows[0].ItemArray[103].ToString();

                    txtSupporttoage_Dependant1.Text = dt.Rows[0].ItemArray[104].ToString();
                    txtSupporttoage_Dependant2.Text = dt.Rows[0].ItemArray[105].ToString();
                    txtSupporttoage_Dependant3.Text = dt.Rows[0].ItemArray[106].ToString();

                    txtSchoolName_Dependant1.Text = dt.Rows[0].ItemArray[107].ToString();
                    txtSchoolName_Dependant2.Text = dt.Rows[0].ItemArray[108].ToString();
                    txtSchoolName_Dependant3.Text = dt.Rows[0].ItemArray[109].ToString();

                    txtSchoolYearLevel_Dependant1.Text = dt.Rows[0].ItemArray[110].ToString();
                    txtSchoolYearLevel_Dependant2.Text = dt.Rows[0].ItemArray[111].ToString();
                    txtSchoolYearLevel_Dependant3.Text = dt.Rows[0].ItemArray[112].ToString();

                    txtEstimatedCostofSchooling_Dependant1.Text = dt.Rows[0].ItemArray[113].ToString();
                    txtEstimatedCostofSchooling_Dependant2.Text = dt.Rows[0].ItemArray[114].ToString();
                    txtEstimatedCostofSchooling_Dependant3.Text = dt.Rows[0].ItemArray[115].ToString();

                    int austudyStatus_Dependant1 = Convert.ToInt32(dt.Rows[0].ItemArray[116]);
                    if (austudyStatus_Dependant1 == 1)
                        rbNotclaiming_Dependant1.IsChecked = true;
                    else if (austudyStatus_Dependant1 == 2)
                        rbHome_Dependant1.IsChecked = true;
                    else if (austudyStatus_Dependant1 == 3)
                        rbAwayfromhome_Dependant1.IsChecked = true; 

                    int austudyStatus_Dependant2 = Convert.ToInt32(dt.Rows[0].ItemArray[117]);
                    if (austudyStatus_Dependant2 == 1)
                        rbNotclaiming_Dependant2.IsChecked = true;
                    else if (austudyStatus_Dependant2 == 2)
                        rbHome_Dependant2.IsChecked = true;
                    else if (austudyStatus_Dependant2 == 3)
                        rbAwayfromhome_Dependant2.IsChecked = true; 

                    int austudyStatus_Dependant3 = Convert.ToInt32(dt.Rows[0].ItemArray[118]);
                    if (austudyStatus_Dependant3 == 1)
                        rbNotclaiming_Dependant3.IsChecked = true;
                    else if (austudyStatus_Dependant3 == 2)
                        rbHome_Dependant3.IsChecked = true;
                    else if (austudyStatus_Dependant3 == 3)
                        rbAwayfromhome_Dependant3.IsChecked = true;

                    txtClientsParents.Text = dt.Rows[0].ItemArray[119].ToString();
                    string FileNotesClientsParents_FileName = dt.Rows[0].ItemArray[120].ToString();
                    string FileNotesClientsParents_FilePath = dt.Rows[0].ItemArray[121].ToString();
                    //myInkCanvasFileNotesClientsParents

                    txtEgCollectablesGolfTennis_Client1.Text = dt.Rows[0].ItemArray[122].ToString();
                    txtEgCollectablesGolfTennis_Client2.Text = dt.Rows[0].ItemArray[123].ToString();

                    txtEgCollectablesGolfTennis2_Client1.Text = dt.Rows[0].ItemArray[124].ToString();
                    txtEgCollectablesGolfTennis2_Client2.Text = dt.Rows[0].ItemArray[125].ToString();

                    txtEgCollectablesGolfTennis3_Client1.Text = dt.Rows[0].ItemArray[126].ToString();
                    txtEgCollectablesGolfTennis3_Client2.Text = dt.Rows[0].ItemArray[127].ToString();

                    //Business Advisers
                    txtBusinessname_Accountant.Text = dt.Rows[0].ItemArray[128].ToString();
                    txtBusinessname_Banker.Text = dt.Rows[0].ItemArray[129].ToString();
                    txtBusinessname_Lawyer.Text = dt.Rows[0].ItemArray[130].ToString();

                    txtContactname_Accountant.Text = dt.Rows[0].ItemArray[131].ToString();
                    txtContactname_Banker.Text = dt.Rows[0].ItemArray[132].ToString();
                    txtContactname_Lawyer.Text = dt.Rows[0].ItemArray[133].ToString();

                    txtPostaladdress_Accountant.Text = dt.Rows[0].ItemArray[134].ToString();
                    txtPostaladdress_Banker.Text = dt.Rows[0].ItemArray[135].ToString();
                    txtPostaladdress_Lawyer.Text = dt.Rows[0].ItemArray[136].ToString();

                    txtPostaladdress2_Accountant.Text = dt.Rows[0].ItemArray[137].ToString();
                    txtPostaladdress2_Banker.Text = dt.Rows[0].ItemArray[138].ToString();
                    txtPostaladdress2_Lawyer.Text = dt.Rows[0].ItemArray[139].ToString();

                    txtPostaladdressState_Accountant.Text = dt.Rows[0].ItemArray[140].ToString();
                    txtPostaladdressState_Banker.Text = dt.Rows[0].ItemArray[141].ToString();
                    txtPostaladdressState_Lawyer.Text = dt.Rows[0].ItemArray[142].ToString();

                    txtPostaladdressPostcode_Accountant.Text = dt.Rows[0].ItemArray[143].ToString();
                    txtPostaladdressPostcode_Banker.Text = dt.Rows[0].ItemArray[144].ToString();
                    txtPostaladdressPostcode_Lawyer.Text = dt.Rows[0].ItemArray[145].ToString();

                    txtEmailaddress_Accountant.Text = dt.Rows[0].ItemArray[146].ToString();
                    txtEmailaddress_Banker.Text = dt.Rows[0].ItemArray[147].ToString();
                    txtEmailaddress_Lawyer.Text = dt.Rows[0].ItemArray[148].ToString();

                    txtPhoneaddress_Accountant.Text = dt.Rows[0].ItemArray[149].ToString();
                    txtPhoneaddress_Banker.Text = dt.Rows[0].ItemArray[150].ToString();
                    txtPhoneaddress_Lawyer.Text = dt.Rows[0].ItemArray[151].ToString();

                    txtFaxnumber_Accountant.Text = dt.Rows[0].ItemArray[152].ToString();
                    txtFaxnumber_Banker.Text = dt.Rows[0].ItemArray[153].ToString();
                    txtFaxnumber_Lawyer.Text = dt.Rows[0].ItemArray[154].ToString();

                    string FileNotes_FileName = dt.Rows[0].ItemArray[155].ToString();
                    string FileNotes_FilePath = dt.Rows[0].ItemArray[156].ToString();
                    //myInkCanvas
                    




                }
            }
        }
    }
}
