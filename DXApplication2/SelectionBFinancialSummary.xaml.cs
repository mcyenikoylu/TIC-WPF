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
    /// Interaction logic for SelectionBFinancialSummary.xaml
    /// </summary>
    public partial class SelectionBFinancialSummary : UserControl
    {
        public SelectionBFinancialSummary()
        {
            InitializeComponent();
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //LoadingIndicator.IsActive = true;
                DXSplashScreen.Show<SplashScreenLoading>();

                int workstatus_Client1 = 0;
                if ((bool)rbFullyemployed_Client1.IsChecked)
                    workstatus_Client1 = 1;
                else if ((bool)rbParttimeemployed_Client1.IsChecked)
                    workstatus_Client1 = 2;
                else if ((bool)rbHomeduties_Client1.IsChecked)
                    workstatus_Client1 = 3;
                else if ((bool)rbSelfemployed_Client1.IsChecked)
                    workstatus_Client1 = 4;
                else if ((bool)rbUnemployed_Client1.IsChecked)
                    workstatus_Client1 = 5;
                else if ((bool)rbEarlyRetirement_Client1.IsChecked)
                    workstatus_Client1 = 6;
                else if ((bool)rbRetired_Client1.IsChecked)
                    workstatus_Client1 = 7;
                else if ((bool)rbStudent_Client1.IsChecked)
                    workstatus_Client1 = 8;
                else if ((bool)rbUnknown_Client1.IsChecked)
                    workstatus_Client1 = 9;

                int workstatus_Client2 = 0;
                if ((bool)rbFullyemployed_Client2.IsChecked)
                    workstatus_Client2 = 2;
                else if ((bool)rbParttimeemployed_Client2.IsChecked)
                    workstatus_Client2 = 2;
                else if ((bool)rbHomeduties_Client2.IsChecked)
                    workstatus_Client2 = 3;
                else if ((bool)rbSelfemployed_Client2.IsChecked)
                    workstatus_Client2 = 4;
                else if ((bool)rbUnemployed_Client2.IsChecked)
                    workstatus_Client2 = 5;
                else if ((bool)rbEarlyRetirement_Client2.IsChecked)
                    workstatus_Client2 = 6;
                else if ((bool)rbRetired_Client2.IsChecked)
                    workstatus_Client2 = 7;
                else if ((bool)rbStudent_Client2.IsChecked)
                    workstatus_Client2 = 8;
                else if ((bool)rbUnknown_Client2.IsChecked)
                    workstatus_Client2 = 9;

                string fileNotesFolderPath = @"C:\tic\FileNotes";

                DataAccess.AddDataSelectionBFinancialSummary(
                    workstatus_Client1,
                    workstatus_Client2,
                    txtEmployer_Client1.Text,
                    txtEmployer_Client2.Text,
                    txtEmployeraddress_Client1.Text,
                    txtEmployeraddress_Client2.Text,
                    txtOccupation_Client1.Text,
                    txtOccupation_Client2.Text,
                    txtNumberofyearsservice_Client1.Text,
                    txtNumberofyearsservice_Client2.Text,
                    txtIntendedRetirementdate_Client1.Text,
                    txtIntendedRetirementdate_Client2.Text,
                    txtDoyouexpectemployment_Client1.Text,
                    txtDoyouexpectemployment_Client2.Text,
                    txtSalaryincome_Client1.Text,
                    txtSalaryincome_Client2.Text,
                    txtOthertaxableincome_Client1.Text,
                    txtOthertaxableincome_Client2.Text,
                    txtTaxfreeincome_Client1.Text,
                    txtTaxfreeincome_Client2.Text,
                    txtFamilyallowance_Client1.Text,
                    txtFamilyallowance_Client2.Text,
                    txtDirectorsfeesgratuities_Client1.Text,
                    txtDirectorsfeesgratuities_Client2.Text,
                    txtAreyouexpectingfunds1_Client1.Text,
                    txtAreyouexpectingfunds1_Client2.Text,
                    txtAreyouexpectingfunds2_Client1.Text,
                    txtAreyouexpectingfunds2_Client2.Text,
                    txtAreyouexpectingfunds3_Client1.Text,
                    txtAreyouexpectingfunds3_Client2.Text,
                    txtOther1_Client1.Text,
                    txtOther1_Client2.Text,
                    txtOther2_Client1.Text,
                    txtOther2_Client2.Text,
                    txtOther3_Client1.Text,
                    txtOther3_Client2.Text,
                    txtEmploymentsuper_Client1.Text,
                    txtEmploymentsuper_Client2.Text,
                    txtSalarysacrificetosuper_Client1.Text,
                    txtSalarysacrificetosuper_Client2.Text,
                    txtPackagedmotorvehicle_Client1.Text,
                    txtPackagedmotorvehicle_Client2.Text,
                    txtBonus_Client1.Text,
                    txtBonus_Client2.Text,
                    txtOther_Client1.Text,
                    txtOther_Client2.Text,
                    txtEntitlementamount_Client1.Text,
                    txtEntitlementamount_Client2.Text,
                    txtEntitlementtype_Client1.Text,
                    txtEntitlementtype_Client2.Text,
                    txtCentrelinkreferencenoCRN_Client1.Text,
                    txtCentrelinkreferencenoCRN_Client2.Text,
                    txtMaintenanceincome_Client1.Text,
                    txtMaintenanceincome_Client2.Text,
                    txtMaintenancepayment_Client1.Text,
                    txtMaintenancepayment_Client2.Text,
                    txtOverseassocialsecurityincome_Client1.Text,
                    txtOverseassocialsecurityincome_Client2.Text,
                    "FileNotesCentrelink_FileName",
                    fileNotesFolderPath,
                    txtFoodliquids_Fortnight.Text,
                    txtFoodliquids_Month.Text,
                    txtFoodliquids_Quarter.Text,
                    txtFoodliquids_Halfyear.Text,
                    txtFoodliquids_Annual.Text,
                    txtFoodliquids_Totallastyear.Text,
                    txtAlcohol_Fortnight.Text,
                    txtAlcohol_Month.Text,
                    txtAlcohol_Quarter.Text,
                    txtAlcohol_Halfyear.Text,
                    txtAlcohol_Annual.Text,
                    txtAlcohol_Totallastyear.Text,
                    txtTobacco_Fortnight.Text,
                    txtTobacco_Month.Text,
                    txtTobacco_Quarter.Text,
                    txtTobacco_Halfyear.Text,
                    txtTobacco_Annual.Text,
                    txtTobacco_Totallastyear.Text,
                    txtClothingfootwear_Fortnight.Text,
                    txtClothingfootwear_Month.Text,
                    txtClothingfootwear_Quarter.Text,
                    txtClothingfootwear_Halfyear.Text,
                    txtClothingfootwear_Annual.Text,
                    txtClothingfootwear_Totallastyear.Text,
                    txtMedicalhealth_Fortnight.Text,
                    txtMedicalhealth_Month.Text,
                    txtMedicalhealth_Quarter.Text,
                    txtMedicalhealth_Halfyear.Text,
                    txtMedicalhealth_Annual.Text,
                    txtMedicalhealth_Totallastyear.Text,
                    txtRecreation_Fortnight.Text,
                    txtRecreation_Month.Text,
                    txtRecreation_Quarter.Text,
                    txtRecreation_Halfyear.Text,
                    txtRecreation_Annual.Text,
                    txtRecreation_Totallastyear.Text,
                    txtPersonalcare_Fortnight.Text,
                    txtPersonalcare_Month.Text,
                    txtPersonalcare_Quarter.Text,
                    txtPersonalcare_Halfyear.Text,
                    txtPersonalcare_Annual.Text,
                    txtPersonalcare_Totallastyear.Text,
                    txtPhonePost_Fortnight.Text,
                    txtPhonePost_Month.Text,
                    txtPhonePost_Quarter.Text,
                    txtPhonePost_Halfyear.Text,
                    txtPhonePost_Annual.Text,
                    txtPhonePost_Totallastyear.Text,
                    txtTravel_Fortnight.Text,
                    txtTravel_Month.Text,
                    txtTravel_Quarter.Text,
                    txtTravel_Halfyear.Text,
                    txtTravel_Annual.Text,
                    txtTravel_Totallastyear.Text,
                    txtGifts_Fortnight.Text,
                    txtGifts_Month.Text,
                    txtGifts_Quarter.Text,
                    txtGifts_Halfyear.Text,
                    txtGifts_Annual.Text,
                    txtGifts_Totallastyear.Text,
                    txtOther_Fortnight.Text,
                    txtOther_Month.Text,
                    txtOther_Quarter.Text,
                    txtOther_Halfyear.Text,
                    txtOther_Annual.Text,
                    txtOther_Totallastyear.Text,
                    txtRatesinsurance_Fortnight.Text,
                    txtRatesinsurance_Month.Text,
                    txtRatesinsurance_Quarter.Text,
                    txtRatesinsurance_Halfyear.Text,
                    txtRatesinsurance_Annual.Text,
                    txtRatesinsurance_Totallastyear.Text,
                    txtRepairsmaintenance_Fortnight.Text,
                    txtRepairsmaintenance_Month.Text,
                    txtRepairsmaintenance_Quarter.Text,
                    txtRepairsmaintenance_Halfyear.Text,
                    txtRepairsmaintenance_Annual.Text,
                    txtRepairsmaintenance_Totallastyear.Text,
                    txtElectricitygas_Fortnight.Text,
                    txtElectricitygas_Month.Text,
                    txtElectricitygas_Quarter.Text,
                    txtElectricitygas_Halfyear.Text,
                    txtElectricitygas_Annual.Text,
                    txtElectricitygas_Totallastyear.Text,
                    txtHouseloanprincipal_Fortnight.Text,
                    txtHouseloanprincipal_Month.Text,
                    txtHouseloanprincipal_Quarter.Text,
                    txtHouseloanprincipal_Halfyear.Text,
                    txtHouseloanprincipal_Annual.Text,
                    txtHouseloanprincipal_Totallastyear.Text,
                    txtRentmortgage_Fortnight.Text,
                    txtRentmortgage_Month.Text,
                    txtRentmortgage_Quarter.Text,
                    txtRentmortgage_Halfyear.Text,
                    txtRentmortgage_Annual.Text,
                    txtRentmortgage_Totallastyear.Text,
                    txtExtramortgagepayments_Fortnight.Text,
                    txtExtramortgagepayments_Month.Text,
                    txtExtramortgagepayments_Quarter.Text,
                    txtExtramortgagepayments_Halfyear.Text,
                    txtExtramortgagepayments_Annual.Text,
                    txtExtramortgagepayments_Totallastyear.Text,
                    txtFurnishingequipment_Fortnight.Text,
                    txtFurnishingequipment_Month.Text,
                    txtFurnishingequipment_Quarter.Text,
                    txtFurnishingequipment_Halfyear.Text,
                    txtFurnishingequipment_Annual.Text,
                    txtFurnishingequipment_Totallastyear.Text,
                    txtOtherHousing_Fortnight.Text,
                    txtOtherHousing_Month.Text,
                    txtOtherHousing_Quarter.Text,
                    txtOtherHousing_Halfyear.Text,
                    txtOtherHousing_Annual.Text,
                    txtOtherHousing_Totallastyear.Text,
                    txtRegistrationinsurance_Fortnight.Text,
                    txtRegistrationinsurance_Month.Text,
                    txtRegistrationinsurance_Quarter.Text,
                    txtRegistrationinsurance_Halfyear.Text,
                    txtRegistrationinsurance_Annual.Text,
                    txtRegistrationinsurance_Totallastyear.Text,
                    txtRepairsmaintenanceTransport_Fortnight.Text,
                    txtRepairsmaintenanceTransport_Month.Text,
                    txtRepairsmaintenanceTransport_Quarter.Text,
                    txtRepairsmaintenanceTransport_Halfyear.Text,
                    txtRepairsmaintenanceTransport_Annual.Text,
                    txtRepairsmaintenanceTransport_Totallastyear.Text,
                    txtFuelOil_Fortnight.Text,
                    txtFuelOil_Month.Text,
                    txtFuelOil_Quarter.Text,
                    txtFuelOil_Halfyear.Text,
                    txtFuelOil_Annual.Text,
                    txtFuelOil_Totallastyear.Text,
                    txtReplacementvehicle_Fortnight.Text,
                    txtReplacementvehicle_Month.Text,
                    txtReplacementvehicle_Quarter.Text,
                    txtReplacementvehicle_Halfyear.Text,
                    txtReplacementvehicle_Annual.Text,
                    txtReplacementvehicle_Totallastyear.Text,
                    txtFares_Fortnight.Text,
                    txtFares_Month.Text,
                    txtFares_Quarter.Text,
                    txtFares_Halfyear.Text,
                    txtFares_Annual.Text,
                    txtFares_Totallastyear.Text,
                    txtOtherTransport_Fortnight.Text,
                    txtOtherTransport_Month.Text,
                    txtOtherTransport_Quarter.Text,
                    txtOtherTransport_Halfyear.Text,
                    txtOtherTransport_Annual.Text,
                    txtOtherTransport_Totallastyear.Text,
                    txtSuperlifeinsurance_Fortnight.Text,
                    txtSuperlifeinsurance_Month.Text,
                    txtSuperlifeinsurance_Quarter.Text,
                    txtSuperlifeinsurance_Halfyear.Text,
                    txtSuperlifeinsurance_Annual.Text,
                    txtSuperlifeinsurance_Totallastyear.Text,
                    txtLoansavings_Fortnight.Text,
                    txtLoansavings_Month.Text,
                    txtLoansavings_Quarter.Text,
                    txtLoansavings_Halfyear.Text,
                    txtLoansavings_Annual.Text,
                    txtLoansavings_Totallastyear.Text,
                    txtCarloan_Fortnight.Text,
                    txtCarloan_Month.Text,
                    txtCarloan_Quarter.Text,
                    txtCarloan_Halfyear.Text,
                    txtCarloan_Annual.Text,
                    txtCarloan_Totallastyear.Text,
                    txtOtherGeneral_Fortnight.Text,
                    txtOtherGeneral_Month.Text,
                    txtOtherGeneral_Quarter.Text,
                    txtOtherGeneral_Halfyear.Text,
                    txtOtherGeneral_Annual.Text,
                    txtOtherGeneral_Totallastyear.Text,
                    txtFoodliquid_Fortnight.Text,
                    txtFoodliquid_Month.Text,
                    txtFoodliquid_Quarter.Text,
                    txtFoodliquid_Halfyear.Text,
                    txtFoodliquid_Annual.Text,
                    txtFoodliquid_Totallastyear.Text,
                    txtClothingfootwearChildren_Fortnight.Text,
                    txtClothingfootwearChildren_Month.Text,
                    txtClothingfootwearChildren_Quarter.Text,
                    txtClothingfootwearChildren_Halfyear.Text,
                    txtClothingfootwearChildren_Annual.Text,
                    txtClothingfootwearChildren_Totallastyear.Text,
                    txtEducation_Fortnight.Text,
                    txtEducation_Month.Text,
                    txtEducation_Quarter.Text,
                    txtEducation_Halfyear.Text,
                    txtEducation_Annual.Text,
                    txtEducation_Totallastyear.Text,
                    txtOtherChildren_Fortnight.Text,
                    txtOtherChildren_Month.Text,
                    txtOtherChildren_Quarter.Text,
                    txtOtherChildren_Halfyear.Text,
                    txtOtherChildren_Annual.Text,
                    txtOtherChildren_Totallastyear.Text,
                    txtTotal_Fortnight.Text,
                    txtTotal_Month.Text,
                    txtTotal_Quarter.Text,
                    txtTotal_Halfyear.Text,
                    txtTotal_Annual.Text,
                    txtTotal_Totallastyear.Text,
                    "FileNotes_FileName",
                    fileNotesFolderPath
                    );

                StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(fileNotesFolderPath);

                string fileName = "FileNotesSelectionB_" + DataAccess._CoverPageID;
                var file = await storageFolder.CreateFileAsync(fileName + ".jpg", CreationCollisionOption.ReplaceExisting);

                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(fileNotesFolderPath + "//" + fileName + ".jpg", FileMode.Create);

                RenderTargetBitmap rtb = new RenderTargetBitmap((int)myInkCanvas.ActualWidth, (int)myInkCanvas.ActualHeight, 96d, 96d, PixelFormats.Default);
                rtb.Render(myInkCanvas);
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));

                encoder.Save(fs);
                fs.Close();

                //FileNotesSelectionACentrelink_
                string fileName2 = "FileNotesSelectionBCentrelink_" + DataAccess._CoverPageID;
                var file2 = await storageFolder.CreateFileAsync(fileName2 + ".jpg", CreationCollisionOption.ReplaceExisting);

                MemoryStream ms2 = new MemoryStream();
                FileStream fs2 = new FileStream(fileNotesFolderPath + "//" + fileName2 + ".jpg", FileMode.Create);

                RenderTargetBitmap rtb2 = new RenderTargetBitmap((int)myInkCanvasFileNotesCentrelink.ActualWidth, (int)myInkCanvasFileNotesCentrelink.ActualHeight, 96d, 96d, PixelFormats.Default);
                rtb2.Render(myInkCanvasFileNotesCentrelink);
                JpegBitmapEncoder encoder2 = new JpegBitmapEncoder();
                encoder2.Frames.Add(BitmapFrame.Create(rtb2));

                encoder2.Save(fs2);
                fs2.Close();

                
            }
            catch (Exception)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
            finally
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();

                MessageBoxResult result = DXMessageBox.Show("Selection B - Financial Summary data saved successfully.", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataAccess._CoverPageID > 0)
                {
                    DXSplashScreen.Show<SplashScreenLoading>();

                    DataTable dt = DataAccess.getSelectionBFinancialSummary(DataAccess._CoverPageID);
                    if (dt.Rows.Count > 0)
                    {
                        

                        //Employment Details
                        int workstatus_Client1 = Convert.ToInt32(dt.Rows[0].ItemArray[2]);
                        if (workstatus_Client1 == 1)
                            rbFullyemployed_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 2)
                            rbParttimeemployed_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 3)
                            rbHomeduties_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 4)
                            rbSelfemployed_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 5)
                            rbUnemployed_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 6)
                            rbEarlyRetirement_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 7)
                            rbRetired_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 8)
                            rbStudent_Client1.IsChecked = true;
                        else if (workstatus_Client1 == 9)
                            rbUnknown_Client1.IsChecked = true;

                        int workstatus_Client2 = Convert.ToInt32(dt.Rows[0].ItemArray[3]);
                        if (workstatus_Client2 == 1)
                            rbFullyemployed_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 2)
                            rbParttimeemployed_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 3)
                            rbHomeduties_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 4)
                            rbSelfemployed_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 5)
                            rbUnemployed_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 6)
                            rbEarlyRetirement_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 7)
                            rbRetired_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 8)
                            rbStudent_Client2.IsChecked = true;
                        else if (workstatus_Client2 == 9)
                            rbUnknown_Client2.IsChecked = true;

                        txtEmployer_Client1.Text = dt.Rows[0].ItemArray[4].ToString();
                        txtEmployer_Client2.Text = dt.Rows[0].ItemArray[5].ToString();

                        txtEmployeraddress_Client1.Text = dt.Rows[0].ItemArray[6].ToString();
                        txtEmployeraddress_Client2.Text = dt.Rows[0].ItemArray[7].ToString();

                        txtOccupation_Client1.Text = dt.Rows[0].ItemArray[8].ToString();
                        txtOccupation_Client2.Text = dt.Rows[0].ItemArray[9].ToString();

                        txtNumberofyearsservice_Client1.Text = dt.Rows[0].ItemArray[10].ToString();
                        txtNumberofyearsservice_Client2.Text = dt.Rows[0].ItemArray[11].ToString();

                        txtIntendedRetirementdate_Client1.Text = dt.Rows[0].ItemArray[12].ToString();
                        txtIntendedRetirementdate_Client2.Text = dt.Rows[0].ItemArray[13].ToString();

                        txtDoyouexpectemployment_Client1.Text = dt.Rows[0].ItemArray[14].ToString();
                        txtDoyouexpectemployment_Client2.Text = dt.Rows[0].ItemArray[15].ToString();

                        //Salary & Other Income
                        txtSalaryincome_Client1.Text = dt.Rows[0].ItemArray[16].ToString();
                        txtSalaryincome_Client2.Text = dt.Rows[0].ItemArray[17].ToString();

                        txtOthertaxableincome_Client1.Text = dt.Rows[0].ItemArray[18].ToString();
                        txtOthertaxableincome_Client2.Text = dt.Rows[0].ItemArray[19].ToString();

                        txtTaxfreeincome_Client1.Text = dt.Rows[0].ItemArray[20].ToString();
                        txtTaxfreeincome_Client2.Text = dt.Rows[0].ItemArray[21].ToString();

                        txtFamilyallowance_Client1.Text = dt.Rows[0].ItemArray[22].ToString();
                        txtFamilyallowance_Client2.Text = dt.Rows[0].ItemArray[23].ToString();

                        txtDirectorsfeesgratuities_Client1.Text = dt.Rows[0].ItemArray[24].ToString();
                        txtDirectorsfeesgratuities_Client2.Text = dt.Rows[0].ItemArray[25].ToString();

                        txtAreyouexpectingfunds1_Client1.Text = dt.Rows[0].ItemArray[26].ToString();
                        txtAreyouexpectingfunds1_Client2.Text = dt.Rows[0].ItemArray[27].ToString();

                        txtAreyouexpectingfunds2_Client1.Text = dt.Rows[0].ItemArray[28].ToString();
                        txtAreyouexpectingfunds2_Client2.Text = dt.Rows[0].ItemArray[29].ToString();

                        txtAreyouexpectingfunds3_Client1.Text = dt.Rows[0].ItemArray[30].ToString();
                        txtAreyouexpectingfunds3_Client2.Text = dt.Rows[0].ItemArray[31].ToString();

                        txtOther1_Client1.Text = dt.Rows[0].ItemArray[32].ToString();
                        txtOther1_Client2.Text = dt.Rows[0].ItemArray[33].ToString();

                        txtOther2_Client1.Text = dt.Rows[0].ItemArray[34].ToString();
                        txtOther2_Client2.Text = dt.Rows[0].ItemArray[35].ToString();

                        txtOther3_Client1.Text = dt.Rows[0].ItemArray[36].ToString();
                        txtOther3_Client2.Text = dt.Rows[0].ItemArray[37].ToString();

                        //Salary Sacrifice / Package
                        txtEmploymentsuper_Client1.Text = dt.Rows[0].ItemArray[38].ToString();
                        txtEmploymentsuper_Client2.Text = dt.Rows[0].ItemArray[39].ToString();

                        txtSalarysacrificetosuper_Client1.Text = dt.Rows[0].ItemArray[40].ToString();
                        txtSalarysacrificetosuper_Client2.Text = dt.Rows[0].ItemArray[41].ToString();

                        txtPackagedmotorvehicle_Client1.Text = dt.Rows[0].ItemArray[42].ToString();
                        txtPackagedmotorvehicle_Client2.Text = dt.Rows[0].ItemArray[43].ToString();

                        txtBonus_Client1.Text = dt.Rows[0].ItemArray[44].ToString();
                        txtBonus_Client2.Text = dt.Rows[0].ItemArray[45].ToString();

                        txtOther_Client1.Text = dt.Rows[0].ItemArray[46].ToString();
                        txtOther_Client2.Text = dt.Rows[0].ItemArray[47].ToString();

                        //Centrelink
                        txtEntitlementamount_Client1.Text = dt.Rows[0].ItemArray[48].ToString();
                        txtEntitlementamount_Client2.Text = dt.Rows[0].ItemArray[49].ToString();

                        txtEntitlementtype_Client1.Text = dt.Rows[0].ItemArray[50].ToString();
                        txtEntitlementtype_Client2.Text = dt.Rows[0].ItemArray[51].ToString();

                        txtCentrelinkreferencenoCRN_Client1.Text = dt.Rows[0].ItemArray[52].ToString();
                        txtCentrelinkreferencenoCRN_Client2.Text = dt.Rows[0].ItemArray[53].ToString();

                        txtMaintenanceincome_Client1.Text = dt.Rows[0].ItemArray[54].ToString();
                        txtMaintenanceincome_Client2.Text = dt.Rows[0].ItemArray[55].ToString();

                        txtMaintenancepayment_Client1.Text = dt.Rows[0].ItemArray[56].ToString();
                        txtMaintenancepayment_Client2.Text = dt.Rows[0].ItemArray[57].ToString();

                        txtOverseassocialsecurityincome_Client1.Text = dt.Rows[0].ItemArray[58].ToString();
                        txtOverseassocialsecurityincome_Client2.Text = dt.Rows[0].ItemArray[59].ToString();

                        string FileNotesCentrelink_FileName = dt.Rows[0].ItemArray[60].ToString();
                        string FileNotesCentrelink_FilePath = dt.Rows[0].ItemArray[61].ToString();
                        //myInkCanvasFileNotesCentrelink

                        //Cost of living
                        txtFoodliquids_Fortnight.Text = dt.Rows[0].ItemArray[62].ToString();
                        txtFoodliquids_Month.Text = dt.Rows[0].ItemArray[63].ToString();
                        txtFoodliquids_Quarter.Text = dt.Rows[0].ItemArray[64].ToString();
                        txtFoodliquids_Halfyear.Text = dt.Rows[0].ItemArray[65].ToString();
                        txtFoodliquids_Annual.Text = dt.Rows[0].ItemArray[66].ToString();
                        txtFoodliquids_Totallastyear.Text = dt.Rows[0].ItemArray[67].ToString();

                        txtAlcohol_Fortnight.Text = dt.Rows[0].ItemArray[68].ToString();
                        txtAlcohol_Month.Text = dt.Rows[0].ItemArray[69].ToString();
                        txtAlcohol_Quarter.Text = dt.Rows[0].ItemArray[70].ToString();
                        txtAlcohol_Halfyear.Text = dt.Rows[0].ItemArray[71].ToString();
                        txtAlcohol_Annual.Text = dt.Rows[0].ItemArray[72].ToString();
                        txtAlcohol_Totallastyear.Text = dt.Rows[0].ItemArray[73].ToString();

                        txtTobacco_Fortnight.Text = dt.Rows[0].ItemArray[74].ToString();
                        txtTobacco_Month.Text = dt.Rows[0].ItemArray[75].ToString();
                        txtTobacco_Quarter.Text = dt.Rows[0].ItemArray[76].ToString();
                        txtTobacco_Halfyear.Text = dt.Rows[0].ItemArray[77].ToString();
                        txtTobacco_Annual.Text = dt.Rows[0].ItemArray[78].ToString();
                        txtTobacco_Totallastyear.Text = dt.Rows[0].ItemArray[79].ToString();

                        txtClothingfootwear_Fortnight.Text = dt.Rows[0].ItemArray[80].ToString();
                        txtClothingfootwear_Month.Text = dt.Rows[0].ItemArray[81].ToString();
                        txtClothingfootwear_Quarter.Text = dt.Rows[0].ItemArray[82].ToString();
                        txtClothingfootwear_Halfyear.Text = dt.Rows[0].ItemArray[83].ToString();
                        txtClothingfootwear_Annual.Text = dt.Rows[0].ItemArray[84].ToString();
                        txtClothingfootwear_Totallastyear.Text = dt.Rows[0].ItemArray[85].ToString();

                        txtMedicalhealth_Fortnight.Text = dt.Rows[0].ItemArray[86].ToString();
                        txtMedicalhealth_Month.Text = dt.Rows[0].ItemArray[87].ToString();
                        txtMedicalhealth_Quarter.Text = dt.Rows[0].ItemArray[88].ToString();
                        txtMedicalhealth_Halfyear.Text = dt.Rows[0].ItemArray[89].ToString();
                        txtMedicalhealth_Annual.Text = dt.Rows[0].ItemArray[90].ToString();
                        txtMedicalhealth_Totallastyear.Text = dt.Rows[0].ItemArray[91].ToString();

                        txtRecreation_Fortnight.Text = dt.Rows[0].ItemArray[92].ToString();
                        txtRecreation_Month.Text = dt.Rows[0].ItemArray[93].ToString();
                        txtRecreation_Quarter.Text = dt.Rows[0].ItemArray[94].ToString();
                        txtRecreation_Halfyear.Text = dt.Rows[0].ItemArray[95].ToString();
                        txtRecreation_Annual.Text = dt.Rows[0].ItemArray[96].ToString();
                        txtRecreation_Totallastyear.Text = dt.Rows[0].ItemArray[97].ToString();

                        txtPersonalcare_Fortnight.Text = dt.Rows[0].ItemArray[98].ToString();
                        txtPersonalcare_Month.Text = dt.Rows[0].ItemArray[99].ToString();
                        txtPersonalcare_Quarter.Text = dt.Rows[0].ItemArray[100].ToString();
                        txtPersonalcare_Halfyear.Text = dt.Rows[0].ItemArray[101].ToString();
                        txtPersonalcare_Annual.Text = dt.Rows[0].ItemArray[102].ToString();
                        txtPersonalcare_Totallastyear.Text = dt.Rows[0].ItemArray[103].ToString();

                        txtPhonePost_Fortnight.Text = dt.Rows[0].ItemArray[104].ToString();
                        txtPhonePost_Month.Text = dt.Rows[0].ItemArray[105].ToString();
                        txtPhonePost_Quarter.Text = dt.Rows[0].ItemArray[106].ToString();
                        txtPhonePost_Halfyear.Text = dt.Rows[0].ItemArray[107].ToString();
                        txtPhonePost_Annual.Text = dt.Rows[0].ItemArray[108].ToString();
                        txtPhonePost_Totallastyear.Text = dt.Rows[0].ItemArray[109].ToString();

                        txtTravel_Fortnight.Text = dt.Rows[0].ItemArray[110].ToString();
                        txtTravel_Month.Text = dt.Rows[0].ItemArray[111].ToString();
                        txtTravel_Quarter.Text = dt.Rows[0].ItemArray[112].ToString();
                        txtTravel_Halfyear.Text = dt.Rows[0].ItemArray[113].ToString();
                        txtTravel_Annual.Text = dt.Rows[0].ItemArray[114].ToString();
                        txtTravel_Totallastyear.Text = dt.Rows[0].ItemArray[115].ToString();

                        txtGifts_Fortnight.Text = dt.Rows[0].ItemArray[116].ToString();
                        txtGifts_Month.Text = dt.Rows[0].ItemArray[117].ToString();
                        txtGifts_Quarter.Text = dt.Rows[0].ItemArray[118].ToString();
                        txtGifts_Halfyear.Text = dt.Rows[0].ItemArray[119].ToString();
                        txtGifts_Annual.Text = dt.Rows[0].ItemArray[120].ToString();
                        txtGifts_Totallastyear.Text = dt.Rows[0].ItemArray[121].ToString();

                        txtOther_Fortnight.Text = dt.Rows[0].ItemArray[122].ToString();
                        txtOther_Month.Text = dt.Rows[0].ItemArray[123].ToString();
                        txtOther_Quarter.Text = dt.Rows[0].ItemArray[124].ToString();
                        txtOther_Halfyear.Text = dt.Rows[0].ItemArray[125].ToString();
                        txtOther_Annual.Text = dt.Rows[0].ItemArray[126].ToString();
                        txtOther_Totallastyear.Text = dt.Rows[0].ItemArray[127].ToString();

                        txtRatesinsurance_Fortnight.Text = dt.Rows[0].ItemArray[128].ToString();
                        txtRatesinsurance_Month.Text = dt.Rows[0].ItemArray[129].ToString();
                        txtRatesinsurance_Quarter.Text = dt.Rows[0].ItemArray[130].ToString();
                        txtRatesinsurance_Halfyear.Text = dt.Rows[0].ItemArray[131].ToString();
                        txtRatesinsurance_Annual.Text = dt.Rows[0].ItemArray[132].ToString();
                        txtRatesinsurance_Totallastyear.Text = dt.Rows[0].ItemArray[133].ToString();

                        txtRepairsmaintenance_Fortnight.Text = dt.Rows[0].ItemArray[134].ToString();
                        txtRepairsmaintenance_Month.Text = dt.Rows[0].ItemArray[135].ToString();
                        txtRepairsmaintenance_Quarter.Text = dt.Rows[0].ItemArray[136].ToString();
                        txtRepairsmaintenance_Halfyear.Text = dt.Rows[0].ItemArray[137].ToString();
                        txtRepairsmaintenance_Annual.Text = dt.Rows[0].ItemArray[138].ToString();
                        txtRepairsmaintenance_Totallastyear.Text = dt.Rows[0].ItemArray[139].ToString();

                        txtElectricitygas_Fortnight.Text = dt.Rows[0].ItemArray[140].ToString();
                        txtElectricitygas_Month.Text = dt.Rows[0].ItemArray[141].ToString();
                        txtElectricitygas_Quarter.Text = dt.Rows[0].ItemArray[142].ToString();
                        txtElectricitygas_Halfyear.Text = dt.Rows[0].ItemArray[143].ToString();
                        txtElectricitygas_Annual.Text = dt.Rows[0].ItemArray[144].ToString();
                        txtElectricitygas_Totallastyear.Text = dt.Rows[0].ItemArray[145].ToString();

                        txtHouseloanprincipal_Fortnight.Text = dt.Rows[0].ItemArray[146].ToString();
                        txtHouseloanprincipal_Month.Text = dt.Rows[0].ItemArray[147].ToString();
                        txtHouseloanprincipal_Quarter.Text = dt.Rows[0].ItemArray[148].ToString();
                        txtHouseloanprincipal_Halfyear.Text = dt.Rows[0].ItemArray[149].ToString();
                        txtHouseloanprincipal_Annual.Text = dt.Rows[0].ItemArray[150].ToString();
                        txtHouseloanprincipal_Totallastyear.Text = dt.Rows[0].ItemArray[151].ToString();

                        txtRentmortgage_Fortnight.Text = dt.Rows[0].ItemArray[152].ToString();
                        txtRentmortgage_Month.Text = dt.Rows[0].ItemArray[153].ToString();
                        txtRentmortgage_Quarter.Text = dt.Rows[0].ItemArray[154].ToString();
                        txtRentmortgage_Halfyear.Text = dt.Rows[0].ItemArray[155].ToString();
                        txtRentmortgage_Annual.Text = dt.Rows[0].ItemArray[156].ToString();
                        txtRentmortgage_Totallastyear.Text = dt.Rows[0].ItemArray[157].ToString();

                        txtExtramortgagepayments_Fortnight.Text = dt.Rows[0].ItemArray[158].ToString();
                        txtExtramortgagepayments_Month.Text = dt.Rows[0].ItemArray[159].ToString();
                        txtExtramortgagepayments_Quarter.Text = dt.Rows[0].ItemArray[160].ToString();
                        txtExtramortgagepayments_Halfyear.Text = dt.Rows[0].ItemArray[161].ToString();
                        txtExtramortgagepayments_Annual.Text = dt.Rows[0].ItemArray[162].ToString();
                        txtExtramortgagepayments_Totallastyear.Text = dt.Rows[0].ItemArray[163].ToString();

                        txtFurnishingequipment_Fortnight.Text = dt.Rows[0].ItemArray[164].ToString();
                        txtFurnishingequipment_Month.Text = dt.Rows[0].ItemArray[165].ToString();
                        txtFurnishingequipment_Quarter.Text = dt.Rows[0].ItemArray[166].ToString();
                        txtFurnishingequipment_Halfyear.Text = dt.Rows[0].ItemArray[167].ToString();
                        txtFurnishingequipment_Annual.Text = dt.Rows[0].ItemArray[168].ToString();
                        txtFurnishingequipment_Totallastyear.Text = dt.Rows[0].ItemArray[169].ToString();

                        txtOtherHousing_Fortnight.Text = dt.Rows[0].ItemArray[170].ToString();
                        txtOtherHousing_Month.Text = dt.Rows[0].ItemArray[171].ToString();
                        txtOtherHousing_Quarter.Text = dt.Rows[0].ItemArray[172].ToString();
                        txtOtherHousing_Halfyear.Text = dt.Rows[0].ItemArray[173].ToString();
                        txtOtherHousing_Annual.Text = dt.Rows[0].ItemArray[174].ToString();
                        txtOtherHousing_Totallastyear.Text = dt.Rows[0].ItemArray[175].ToString();

                        txtRegistrationinsurance_Fortnight.Text = dt.Rows[0].ItemArray[176].ToString();
                        txtRegistrationinsurance_Month.Text = dt.Rows[0].ItemArray[177].ToString();
                        txtRegistrationinsurance_Quarter.Text = dt.Rows[0].ItemArray[178].ToString();
                        txtRegistrationinsurance_Halfyear.Text = dt.Rows[0].ItemArray[179].ToString();
                        txtRegistrationinsurance_Annual.Text = dt.Rows[0].ItemArray[180].ToString();
                        txtRegistrationinsurance_Totallastyear.Text = dt.Rows[0].ItemArray[181].ToString();

                        txtRepairsmaintenanceTransport_Fortnight.Text = dt.Rows[0].ItemArray[182].ToString();
                        txtRepairsmaintenanceTransport_Month.Text = dt.Rows[0].ItemArray[183].ToString();
                        txtRepairsmaintenanceTransport_Quarter.Text = dt.Rows[0].ItemArray[184].ToString();
                        txtRepairsmaintenanceTransport_Halfyear.Text = dt.Rows[0].ItemArray[185].ToString();
                        txtRepairsmaintenanceTransport_Annual.Text = dt.Rows[0].ItemArray[186].ToString();
                        txtRepairsmaintenanceTransport_Totallastyear.Text = dt.Rows[0].ItemArray[187].ToString();

                        txtFuelOil_Fortnight.Text = dt.Rows[0].ItemArray[188].ToString();
                        txtFuelOil_Month.Text = dt.Rows[0].ItemArray[189].ToString();
                        txtFuelOil_Quarter.Text = dt.Rows[0].ItemArray[190].ToString();
                        txtFuelOil_Halfyear.Text = dt.Rows[0].ItemArray[191].ToString();
                        txtFuelOil_Annual.Text = dt.Rows[0].ItemArray[192].ToString();
                        txtFuelOil_Totallastyear.Text = dt.Rows[0].ItemArray[193].ToString();

                        txtReplacementvehicle_Fortnight.Text = dt.Rows[0].ItemArray[194].ToString();
                        txtReplacementvehicle_Month.Text = dt.Rows[0].ItemArray[195].ToString();
                        txtReplacementvehicle_Quarter.Text = dt.Rows[0].ItemArray[196].ToString();
                        txtReplacementvehicle_Halfyear.Text = dt.Rows[0].ItemArray[197].ToString();
                        txtReplacementvehicle_Annual.Text = dt.Rows[0].ItemArray[198].ToString();
                        txtReplacementvehicle_Totallastyear.Text = dt.Rows[0].ItemArray[199].ToString();

                        txtFares_Fortnight.Text = dt.Rows[0].ItemArray[200].ToString();
                        txtFares_Month.Text = dt.Rows[0].ItemArray[201].ToString();
                        txtFares_Quarter.Text = dt.Rows[0].ItemArray[202].ToString();
                        txtFares_Halfyear.Text = dt.Rows[0].ItemArray[203].ToString();
                        txtFares_Annual.Text = dt.Rows[0].ItemArray[204].ToString();
                        txtFares_Totallastyear.Text = dt.Rows[0].ItemArray[205].ToString();

                        txtOtherTransport_Fortnight.Text = dt.Rows[0].ItemArray[206].ToString();
                        txtOtherTransport_Month.Text = dt.Rows[0].ItemArray[207].ToString();
                        txtOtherTransport_Quarter.Text = dt.Rows[0].ItemArray[208].ToString();
                        txtOtherTransport_Halfyear.Text = dt.Rows[0].ItemArray[209].ToString();
                        txtOtherTransport_Annual.Text = dt.Rows[0].ItemArray[210].ToString();
                        txtOtherTransport_Totallastyear.Text = dt.Rows[0].ItemArray[211].ToString();

                        txtSuperlifeinsurance_Fortnight.Text = dt.Rows[0].ItemArray[212].ToString();
                        txtSuperlifeinsurance_Month.Text = dt.Rows[0].ItemArray[213].ToString();
                        txtSuperlifeinsurance_Quarter.Text = dt.Rows[0].ItemArray[214].ToString();
                        txtSuperlifeinsurance_Halfyear.Text = dt.Rows[0].ItemArray[215].ToString();
                        txtSuperlifeinsurance_Annual.Text = dt.Rows[0].ItemArray[216].ToString();
                        txtSuperlifeinsurance_Totallastyear.Text = dt.Rows[0].ItemArray[217].ToString();

                        txtLoansavings_Fortnight.Text = dt.Rows[0].ItemArray[218].ToString();
                        txtLoansavings_Month.Text = dt.Rows[0].ItemArray[219].ToString();
                        txtLoansavings_Quarter.Text = dt.Rows[0].ItemArray[220].ToString();
                        txtLoansavings_Halfyear.Text = dt.Rows[0].ItemArray[221].ToString();
                        txtLoansavings_Annual.Text = dt.Rows[0].ItemArray[222].ToString();
                        txtLoansavings_Totallastyear.Text = dt.Rows[0].ItemArray[223].ToString();

                        txtCarloan_Fortnight.Text = dt.Rows[0].ItemArray[224].ToString();
                        txtCarloan_Month.Text = dt.Rows[0].ItemArray[225].ToString();
                        txtCarloan_Quarter.Text = dt.Rows[0].ItemArray[226].ToString();
                        txtCarloan_Halfyear.Text = dt.Rows[0].ItemArray[227].ToString();
                        txtCarloan_Annual.Text = dt.Rows[0].ItemArray[228].ToString();
                        txtCarloan_Totallastyear.Text = dt.Rows[0].ItemArray[229].ToString();

                        txtOtherGeneral_Fortnight.Text = dt.Rows[0].ItemArray[230].ToString();
                        txtOtherGeneral_Month.Text = dt.Rows[0].ItemArray[231].ToString();
                        txtOtherGeneral_Quarter.Text = dt.Rows[0].ItemArray[232].ToString();
                        txtOtherGeneral_Halfyear.Text = dt.Rows[0].ItemArray[233].ToString();
                        txtOtherGeneral_Annual.Text = dt.Rows[0].ItemArray[234].ToString();
                        txtOtherGeneral_Totallastyear.Text = dt.Rows[0].ItemArray[235].ToString();

                        txtFoodliquid_Fortnight.Text = dt.Rows[0].ItemArray[236].ToString();
                        txtFoodliquid_Month.Text = dt.Rows[0].ItemArray[237].ToString();
                        txtFoodliquid_Quarter.Text = dt.Rows[0].ItemArray[238].ToString();
                        txtFoodliquid_Halfyear.Text = dt.Rows[0].ItemArray[239].ToString();
                        txtFoodliquid_Annual.Text = dt.Rows[0].ItemArray[240].ToString();
                        txtFoodliquid_Totallastyear.Text = dt.Rows[0].ItemArray[241].ToString();

                        txtClothingfootwearChildren_Fortnight.Text = dt.Rows[0].ItemArray[242].ToString();
                        txtClothingfootwearChildren_Month.Text = dt.Rows[0].ItemArray[243].ToString();
                        txtClothingfootwearChildren_Quarter.Text = dt.Rows[0].ItemArray[244].ToString();
                        txtClothingfootwearChildren_Halfyear.Text = dt.Rows[0].ItemArray[245].ToString();
                        txtClothingfootwearChildren_Annual.Text = dt.Rows[0].ItemArray[246].ToString();
                        txtClothingfootwearChildren_Totallastyear.Text = dt.Rows[0].ItemArray[247].ToString();

                        txtEducation_Fortnight.Text = dt.Rows[0].ItemArray[248].ToString();
                        txtEducation_Month.Text = dt.Rows[0].ItemArray[249].ToString();
                        txtEducation_Quarter.Text = dt.Rows[0].ItemArray[250].ToString();
                        txtEducation_Halfyear.Text = dt.Rows[0].ItemArray[251].ToString();
                        txtEducation_Annual.Text = dt.Rows[0].ItemArray[252].ToString();
                        txtEducation_Totallastyear.Text = dt.Rows[0].ItemArray[253].ToString();

                        txtOtherChildren_Fortnight.Text = dt.Rows[0].ItemArray[254].ToString();
                        txtOtherChildren_Month.Text = dt.Rows[0].ItemArray[255].ToString();
                        txtOtherChildren_Quarter.Text = dt.Rows[0].ItemArray[256].ToString();
                        txtOtherChildren_Halfyear.Text = dt.Rows[0].ItemArray[257].ToString();
                        txtOtherChildren_Annual.Text = dt.Rows[0].ItemArray[258].ToString();
                        txtOtherChildren_Totallastyear.Text = dt.Rows[0].ItemArray[259].ToString();

                        txtTotal_Fortnight.Text = dt.Rows[0].ItemArray[260].ToString();
                        txtTotal_Month.Text = dt.Rows[0].ItemArray[261].ToString();
                        txtTotal_Quarter.Text = dt.Rows[0].ItemArray[262].ToString();
                        txtTotal_Halfyear.Text = dt.Rows[0].ItemArray[263].ToString();
                        txtTotal_Annual.Text = dt.Rows[0].ItemArray[264].ToString();
                        txtTotal_Totallastyear.Text = dt.Rows[0].ItemArray[265].ToString();

                        string FileNotes_FileName = dt.Rows[0].ItemArray[266].ToString();
                        string FileNotes_FilePath = dt.Rows[0].ItemArray[267].ToString();
                        //myInkCanvas

                       
                    }
   
                }
            }
            catch (Exception)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
            finally
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
        }
    }
}
