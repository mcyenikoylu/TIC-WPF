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

                MessageBoxResult result = DXMessageBox.Show("Selection B - Financial Summary data saved successfully.", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);

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
                DataTable dt = DataAccess.getSelectionBFinancialSummary(DataAccess._CoverPageID);
                if (dt.Rows.Count > 0)
                {

                }
            }
        }
    }
}
