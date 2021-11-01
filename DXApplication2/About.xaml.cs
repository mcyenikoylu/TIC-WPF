using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Controls;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DXApplication2
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class About : UserControl
    {
        //DataModel grid_data = new DataModel();

        public About()
        {
            InitializeComponent();
            //DataContext = grid_data;
            //databasepath.Text = "Database Path: " + Path.Combine(ApplicationData.Current.LocalFolder.Path, "ticdb.db");
        }

        public class DataModel
        {
            public ICollectionView Data { get; set; }
            public ICollectionView Data2 { get; set; }
            public ICollectionView Data3 { get; set; }

            public DataModel()
            {
                Data = new CollectionViewSource
                {
                    Source = CreateList()
                }.View;

                Data2 = new CollectionViewSource
                {
                    Source = CreateList_SelectionAPersonalDetails()
                }.View;

                Data3 = new CollectionViewSource
                {
                    Source = CreateList_SelectionBFinancialSummary()
                }.View;
            }
        }

        public static IList CreateList()
        {
            List<TestData> list = new List<TestData>();

            SqliteConnection connstr = new SqliteConnection(@"Data Source=ticdb.db;");
            connstr.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connstr;
            cmd.CommandText = "select ID,PreparedFor,YourAdviser,DateValue,FileNotes_FileName,FileNotes_FilePath from CoverPage";
            SqliteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            connstr.Close();

            foreach (DataRow item in dt.Rows)
            {
                int id = Convert.ToInt32(item.ItemArray[0]);
                string preparedFor = item.ItemArray[1].ToString();
                string yourAdviser = item.ItemArray[2].ToString();
                DateTime dateValue = Convert.ToDateTime(item.ItemArray[3]);
                string fileNotes_FileName = item.ItemArray[4].ToString();
                string fileNotes_FilePath = item.ItemArray[5].ToString();
                list.Add(new TestData()
                {
                    ID = id,
                    PreparedFor = preparedFor,
                    YourAdviser = yourAdviser,
                    DateValue = dateValue,
                    FileNotes_FileName = fileNotes_FileName,
                    FileNotes_FilePath = fileNotes_FilePath
                });

            }

            //for (int i = 0; i < 100; i++)
            //{
            //    list.Add(new TestData()
            //    {
            //        Number1 = i,
            //        Number2 = i * 10,
            //        Text1 = "row " + i,
            //        Text2 = "ROW " + i
            //    });
            //}
            return list;
        }

        public class TestData
        {
            public int ID { get; set; }
            public string PreparedFor { get; set; }
            public string YourAdviser { get; set; }
            public DateTime DateValue { get; set; }
            //File Notes
            public string FileNotes_FileName { get; set; }
            public string FileNotes_FilePath { get; set; }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchFolderAsync(ApplicationData.Current.LocalFolder);
        }

        public static IList CreateList_SelectionAPersonalDetails()
        {
            List<SelectionAPersonalDetails> list = new List<SelectionAPersonalDetails>();

            SqliteConnection connstr = new SqliteConnection(@"Data Source=ticdb.db;");
            connstr.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connstr;
            cmd.CommandText = "select * from SelectionAPersonalDetails";
            SqliteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            connstr.Close();

            foreach (DataRow item in dt.Rows)
            {
                int ID = item.ItemArray[0] != DBNull.Value ? Convert.ToInt32(item.ItemArray[0]) : 0;
                int CoverPageID = item.ItemArray[1] != DBNull.Value ? Convert.ToInt32(item.ItemArray[1]) : 0;
                string SurnameMaidenName_Client1 = item.ItemArray[2].ToString();
                string SurnameMaidenName_Client2 = item.ItemArray[3].ToString();
                string Givennames_Client1 = item.ItemArray[4].ToString();
                string Givennames_Client2 = item.ItemArray[5].ToString();
                string Preferredshortname_Client1 = item.ItemArray[6].ToString();
                string Preferredshortname_Client2 = item.ItemArray[7].ToString();
                string TitleMrMrsMsSirDr_Client1 = item.ItemArray[8].ToString();
                string TitleMrMrsMsSirDr_Client2 = item.ItemArray[9].ToString();
                int Gender_Client1 = item.ItemArray[10] != DBNull.Value ? Convert.ToInt32(item.ItemArray[10]) : 0;
                int Gender_Client2 = item.ItemArray[11] != DBNull.Value ? Convert.ToInt32(item.ItemArray[11]) : 0;
                DateTime DateOfBirth_Client1 = item.ItemArray[12] != DBNull.Value ? Convert.ToDateTime(item.ItemArray[12]) : Convert.ToDateTime("1900-01-01");
                DateTime DateOfBirth_Client2 = item.ItemArray[13] != DBNull.Value ? Convert.ToDateTime(item.ItemArray[13]) : Convert.ToDateTime("1900-01-01");
                int Age_Client1 = item.ItemArray[14] != DBNull.Value ? Convert.ToInt32(item.ItemArray[14]) : 0;
                int Age_Client2 = item.ItemArray[15] != DBNull.Value ? Convert.ToInt32(item.ItemArray[15]) : 0;
                int Maritalstatus_Client1 = item.ItemArray[16] != DBNull.Value ? Convert.ToInt32(item.ItemArray[16]) : 0;
                int Maritalstatus_Client2 = item.ItemArray[17] != DBNull.Value ? Convert.ToInt32(item.ItemArray[17]) : 0;
                int Health_Client1 = item.ItemArray[18] != DBNull.Value ? Convert.ToInt32(item.ItemArray[18]) : 0;
                int Health_Client2 = item.ItemArray[19] != DBNull.Value ? Convert.ToInt32(item.ItemArray[19]) : 0;
                int Smoker_Client1 = item.ItemArray[20] != DBNull.Value ? Convert.ToInt32(item.ItemArray[20]) : 0;
                int Smoker_Client2 = item.ItemArray[21] != DBNull.Value ? Convert.ToInt32(item.ItemArray[21]) : 0;
                string TownOfBirth_Client1 = item.ItemArray[22].ToString();
                string TownOfBirth_Client2 = item.ItemArray[23].ToString();
                string CountryOfBirth_Client1 = item.ItemArray[24].ToString();
                string CountryOfBirth_Client2 = item.ItemArray[25].ToString();
                string IfnotAustraliayearsinAustralia_Client1 = item.ItemArray[26].ToString();
                string IfnotAustraliayearsinAustralia_Client2 = item.ItemArray[27].ToString();
                string Areyouanonresident_Client1 = item.ItemArray[28].ToString();
                string Areyouanonresident_Client2 = item.ItemArray[29].ToString();
                string Taxfilenumber_Client1 = item.ItemArray[30].ToString();
                string Taxfilenumber_Client2 = item.ItemArray[31].ToString();
                string Wereyoureferredtous_Client1 = item.ItemArray[32].ToString();
                string Wereyoureferredtous_Client2 = item.ItemArray[33].ToString();
                string Haveyouworkedwithanotheradviser_Client1 = item.ItemArray[34].ToString();
                string Haveyouworkedwithanotheradviser_Client2 = item.ItemArray[35].ToString();
                string Areyouaresidentofanothercountryfortaxpurposes_Client1 = item.ItemArray[36].ToString();
                string Areyouaresidentofanothercountryfortaxpurposes_Client2 = item.ItemArray[37].ToString();
                string Ifyescountryofresidence_Client1 = item.ItemArray[38].ToString();
                string Ifyescountryofresidence_Client2 = item.ItemArray[39].ToString();
                string TaxidentificationnumberTINofforeigncountry_Client1 = item.ItemArray[40].ToString();
                string TaxidentificationnumberTINofforeigncountry_Client2 = item.ItemArray[41].ToString();
                string Areyouapoliticallyexposedperson_Client1 = item.ItemArray[42].ToString();
                string Areyouapoliticallyexposedperson_Client2 = item.ItemArray[43].ToString();
                //Contact Details
                string Addresspostal_Client1 = item.ItemArray[44].ToString();
                string Addresspostal_Client2 = item.ItemArray[45].ToString();
                string Addresspostal2_Client1 = item.ItemArray[46].ToString();
                string Addresspostal2_Client2 = item.ItemArray[47].ToString();
                string AddresspostalState_Client1 = item.ItemArray[48].ToString();
                string AddresspostalState_Client2 = item.ItemArray[49].ToString();
                string AddresspostalPostcode_Client1 = item.ItemArray[50].ToString();
                string AddresspostalPostcode_Client2 = item.ItemArray[51].ToString();
                string Addressresidentialother_Client1 = item.ItemArray[52].ToString();
                string Addressresidentialother_Client2 = item.ItemArray[53].ToString();
                string AddressresidentialotherState_Client1 = item.ItemArray[54].ToString();
                string AddressresidentialotherState_Client2 = item.ItemArray[55].ToString();
                string AddressresidentialotherPostcode_Client1 = item.ItemArray[56].ToString();
                string AddressresidentialotherPostcode_Client2 = item.ItemArray[57].ToString();
                string Emailaddress_Client1 = item.ItemArray[58].ToString();
                string Emailaddress_Client2 = item.ItemArray[59].ToString();
                string Contactnumbersmainnumber_Client1 = item.ItemArray[60].ToString();
                string Contactnumbersmainnumber_Client2 = item.ItemArray[61].ToString();
                string Officephone_Client1 = item.ItemArray[62].ToString();
                string Officephone_Client2 = item.ItemArray[63].ToString();
                string Mobile_Client1 = item.ItemArray[64].ToString();
                string Mobile_Client2 = item.ItemArray[65].ToString();
                string Fax_Client1 = item.ItemArray[66].ToString();
                string Fax_Client2 = item.ItemArray[67].ToString();
                //Dependants
                string SurnameName_Dependant1 = item.ItemArray[68].ToString();
                string SurnameName_Dependant2 = item.ItemArray[69].ToString();
                string SurnameName_Dependant3 = item.ItemArray[70].ToString();
                string GivenNames_Dependant1 = item.ItemArray[71].ToString();
                string GivenNames_Dependant2 = item.ItemArray[72].ToString();
                string GivenNames_Dependant3 = item.ItemArray[73].ToString();
                string PreferredShortName_Dependant1 = item.ItemArray[74].ToString();
                string PreferredShortName_Dependant2 = item.ItemArray[75].ToString();
                string PreferredShortName_Dependant3 = item.ItemArray[76].ToString();
                string Title_Dependant1 = item.ItemArray[77].ToString();
                string Title_Dependant2 = item.ItemArray[78].ToString();
                string Title_Dependant3 = item.ItemArray[79].ToString();
                int GenderMale_Dependant1 = item.ItemArray[80] != DBNull.Value ? Convert.ToInt32(item.ItemArray[80]) : 0;
                int GenderMale_Dependant2 = item.ItemArray[81] != DBNull.Value ? Convert.ToInt32(item.ItemArray[81]) : 0;
                int GenderMale_Dependant3 = item.ItemArray[82] != DBNull.Value ? Convert.ToInt32(item.ItemArray[82]) : 0;
                DateTime DateOfBirth_Dependant1 = item.ItemArray[83] != DBNull.Value ? Convert.ToDateTime(item.ItemArray[83]) : Convert.ToDateTime("1900-01-01");
                DateTime DateOfBirth_Dependant2 = item.ItemArray[84] != DBNull.Value ? Convert.ToDateTime(item.ItemArray[84]) : Convert.ToDateTime("1900-01-01");
                DateTime DateOfBirth_Dependant3 = item.ItemArray[85] != DBNull.Value ? Convert.ToDateTime(item.ItemArray[85]) : Convert.ToDateTime("1900-01-01");
                int Age_Dependant1 = item.ItemArray[86] != DBNull.Value ? Convert.ToInt32(item.ItemArray[86]) : 0;
                int Age_Dependant2 = item.ItemArray[87] != DBNull.Value ? Convert.ToInt32(item.ItemArray[87]) : 0;
                int Age_Dependant3 = item.ItemArray[88] != DBNull.Value ? Convert.ToInt32(item.ItemArray[88]) : 0;
                string Relationship_Dependant1 = item.ItemArray[89].ToString();
                string Relationship_Dependant2 = item.ItemArray[90].ToString();
                string Relationship_Dependant3 = item.ItemArray[91].ToString();
                int SpecialNeeds_Dependant1 = item.ItemArray[92] != DBNull.Value ? Convert.ToInt32(item.ItemArray[92]) : 0;
                int SpecialNeeds_Dependant2 = item.ItemArray[93] != DBNull.Value ? Convert.ToInt32(item.ItemArray[93]) : 0;
                int SpecialNeeds_Dependant3 = item.ItemArray[94] != DBNull.Value ? Convert.ToInt32(item.ItemArray[94]) : 0;
                string Details_Dependant1 = item.ItemArray[95].ToString();
                string Details_Dependant2 = item.ItemArray[96].ToString();
                string Details_Dependant3 = item.ItemArray[97].ToString();
                string Details2_Dependant1 = item.ItemArray[98].ToString();
                string Details2_Dependant2 = item.ItemArray[99].ToString();
                string Details2_Dependant3 = item.ItemArray[100].ToString();
                string Details3_Dependant1 = item.ItemArray[101].ToString();
                string Details3_Dependant2 = item.ItemArray[102].ToString();
                string Details3_Dependant3 = item.ItemArray[103].ToString();
                string Supporttoage_Dependant1 = item.ItemArray[104].ToString();
                string Supporttoage_Dependant2 = item.ItemArray[105].ToString();
                string Supporttoage_Dependant3 = item.ItemArray[106].ToString();
                string SchoolName_Dependant1 = item.ItemArray[107].ToString();
                string SchoolName_Dependant2 = item.ItemArray[108].ToString();
                string SchoolName_Dependant3 = item.ItemArray[109].ToString();
                string SchoolYearLevel_Dependant1 = item.ItemArray[110].ToString();
                string SchoolYearLevel_Dependant2 = item.ItemArray[111].ToString();
                string SchoolYearLevel_Dependant3 = item.ItemArray[112].ToString();
                string EstimatedCostofSchooling_Dependant1 = item.ItemArray[113].ToString();
                string EstimatedCostofSchooling_Dependant2 = item.ItemArray[114].ToString();
                string EstimatedCostofSchooling_Dependant3 = item.ItemArray[115].ToString();
                int AustudyStatus_Dependant1 = item.ItemArray[116] != DBNull.Value ? Convert.ToInt32(item.ItemArray[116]) : 0;
                int AustudyStatus_Dependant2 = item.ItemArray[117] != DBNull.Value ? Convert.ToInt32(item.ItemArray[117]) : 0;
                int AustudyStatus_Dependant3 = item.ItemArray[118] != DBNull.Value ? Convert.ToInt32(item.ItemArray[118]) : 0;
                string ClientsParents = item.ItemArray[119].ToString();
                string FileNotesClientsParents_FileName = item.ItemArray[120].ToString();
                string FileNotesClientsParents_FilePath = item.ItemArray[121].ToString();
                string EgCollectablesGolfTennis_Client1 = item.ItemArray[122].ToString();
                string EgCollectablesGolfTennis_Client2 = item.ItemArray[123].ToString();
                string EgCollectablesGolfTennis2_Client1 = item.ItemArray[124].ToString();
                string EgCollectablesGolfTennis2_Client2 = item.ItemArray[125].ToString();
                string EgCollectablesGolfTennis3_Client1 = item.ItemArray[126].ToString();
                string EgCollectablesGolfTennis3_Client2 = item.ItemArray[127].ToString();
                //Business Advisers
                string Businessname_Accountant = item.ItemArray[128].ToString();
                string Businessname_Banker = item.ItemArray[129].ToString();
                string Businessname_Lawyer = item.ItemArray[130].ToString();
                string Contactname_Accountant = item.ItemArray[131].ToString();
                string Contactname_Banker = item.ItemArray[132].ToString();
                string Contactname_Lawyer = item.ItemArray[133].ToString();
                string Postaladdress_Accountant = item.ItemArray[134].ToString();
                string Postaladdress_Banker = item.ItemArray[135].ToString();
                string Postaladdress_Lawyer = item.ItemArray[136].ToString();
                string Postaladdress2_Accountant = item.ItemArray[137].ToString();
                string Postaladdress2_Banker = item.ItemArray[138].ToString();
                string Postaladdress2_Lawyer = item.ItemArray[139].ToString();
                string PostaladdressState_Accountant = item.ItemArray[140].ToString();
                string PostaladdressState_Banker = item.ItemArray[141].ToString();
                string PostaladdressState_Lawyer = item.ItemArray[142].ToString();
                string PostaladdressPostcode_Accountant = item.ItemArray[143].ToString();
                string PostaladdressPostcode_Banker = item.ItemArray[144].ToString();
                string PostaladdressPostcode_Lawyer = item.ItemArray[145].ToString();
                string Emailaddress_Accountant = item.ItemArray[146].ToString();
                string Emailaddress_Banker = item.ItemArray[147].ToString();
                string Emailaddress_Lawyer = item.ItemArray[148].ToString();
                string Phoneaddress_Accountant = item.ItemArray[149].ToString();
                string Phoneaddress_Banker = item.ItemArray[150].ToString();
                string Phoneaddress_Lawyer = item.ItemArray[151].ToString();
                string Faxnumber_Accountant = item.ItemArray[152].ToString();
                string Faxnumber_Banker = item.ItemArray[153].ToString();
                string Faxnumber_Lawyer = item.ItemArray[154].ToString();
                //File Notes
                string FileNotes_FileName = item.ItemArray[155].ToString();
                string FileNotes_FilePath = item.ItemArray[156].ToString();

                list.Add(new SelectionAPersonalDetails()
                {
                    ID = ID,
                    CoverPageID = CoverPageID,
                    SurnameMaidenName_Client1 = SurnameMaidenName_Client1,
                    SurnameMaidenName_Client2 = SurnameMaidenName_Client2,
                    Givennames_Client1 = Givennames_Client1,
                    Givennames_Client2 = Givennames_Client2,
                    Preferredshortname_Client1 = Preferredshortname_Client1,
                    Preferredshortname_Client2 = Preferredshortname_Client2,
                    TitleMrMrsMsSirDr_Client1 = TitleMrMrsMsSirDr_Client1,
                    TitleMrMrsMsSirDr_Client2 = TitleMrMrsMsSirDr_Client2,
                    Gender_Client1 = Gender_Client1,
                    Gender_Client2 = Gender_Client2,
                    DateOfBirth_Client1 = DateOfBirth_Client1,
                    DateOfBirth_Client2 = DateOfBirth_Client2,
                    Age_Client1 = Age_Client1,
                    Age_Client2 = Age_Client2,
                    Maritalstatus_Client1 = Maritalstatus_Client1,
                    Maritalstatus_Client2 = Maritalstatus_Client2,
                    Health_Client1 = Health_Client1,
                    Health_Client2 = Health_Client2,
                    Smoker_Client1 = Smoker_Client1,
                    Smoker_Client2 = Smoker_Client2,
                    TownOfBirth_Client1 = TownOfBirth_Client1,
                    TownOfBirth_Client2 = TownOfBirth_Client2,
                    CountryOfBirth_Client1 = CountryOfBirth_Client1,
                    CountryOfBirth_Client2 = CountryOfBirth_Client2,
                    IfnotAustraliayearsinAustralia_Client1 = IfnotAustraliayearsinAustralia_Client1,
                    IfnotAustraliayearsinAustralia_Client2 = IfnotAustraliayearsinAustralia_Client2,
                    Areyouanonresident_Client1 = Areyouanonresident_Client1,
                    Areyouanonresident_Client2 = Areyouanonresident_Client2,
                    Taxfilenumber_Client1 = Taxfilenumber_Client1,
                    Taxfilenumber_Client2 = Taxfilenumber_Client2,
                    Wereyoureferredtous_Client1 = Wereyoureferredtous_Client1,
                    Wereyoureferredtous_Client2 = Wereyoureferredtous_Client2,
                    Haveyouworkedwithanotheradviser_Client1 = Haveyouworkedwithanotheradviser_Client1,
                    Haveyouworkedwithanotheradviser_Client2 = Haveyouworkedwithanotheradviser_Client2,
                    Areyouaresidentofanothercountryfortaxpurposes_Client1 = Areyouaresidentofanothercountryfortaxpurposes_Client1,
                    Areyouaresidentofanothercountryfortaxpurposes_Client2 = Areyouaresidentofanothercountryfortaxpurposes_Client2,
                    Ifyescountryofresidence_Client1 = Ifyescountryofresidence_Client1,
                    Ifyescountryofresidence_Client2 = Ifyescountryofresidence_Client2,
                    TaxidentificationnumberTINofforeigncountry_Client1 = TaxidentificationnumberTINofforeigncountry_Client1,
                    TaxidentificationnumberTINofforeigncountry_Client2 = TaxidentificationnumberTINofforeigncountry_Client2,
                    Areyouapoliticallyexposedperson_Client1 = Areyouapoliticallyexposedperson_Client1,
                    Areyouapoliticallyexposedperson_Client2 = Areyouapoliticallyexposedperson_Client2,
                    //Contact Details	
                    Addresspostal_Client1 = Addresspostal_Client1,
                    Addresspostal_Client2 = Addresspostal_Client2,
                    Addresspostal2_Client1 = Addresspostal2_Client1,
                    Addresspostal2_Client2 = Addresspostal2_Client2,
                    AddresspostalState_Client1 = AddresspostalState_Client1,
                    AddresspostalState_Client2 = AddresspostalState_Client2,
                    AddresspostalPostcode_Client1 = AddresspostalPostcode_Client1,
                    AddresspostalPostcode_Client2 = AddresspostalPostcode_Client2,
                    Addressresidentialother_Client1 = Addressresidentialother_Client1,
                    Addressresidentialother_Client2 = Addressresidentialother_Client2,
                    AddressresidentialotherState_Client1 = AddressresidentialotherState_Client1,
                    AddressresidentialotherState_Client2 = AddressresidentialotherState_Client2,
                    AddressresidentialotherPostcode_Client1 = AddressresidentialotherPostcode_Client1,
                    AddressresidentialotherPostcode_Client2 = AddressresidentialotherPostcode_Client2,
                    Emailaddress_Client1 = Emailaddress_Client1,
                    Emailaddress_Client2 = Emailaddress_Client2,
                    Contactnumbersmainnumber_Client1 = Contactnumbersmainnumber_Client1,
                    Contactnumbersmainnumber_Client2 = Contactnumbersmainnumber_Client2,
                    Officephone_Client1 = Officephone_Client1,
                    Officephone_Client2 = Officephone_Client2,
                    Mobile_Client1 = Mobile_Client1,
                    Mobile_Client2 = Mobile_Client2,
                    Fax_Client1 = Fax_Client1,
                    Fax_Client2 = Fax_Client2,
                    //Dependants	
                    SurnameName_Dependant1 = SurnameName_Dependant1,
                    SurnameName_Dependant2 = SurnameName_Dependant2,
                    SurnameName_Dependant3 = SurnameName_Dependant3,
                    GivenNames_Dependant1 = GivenNames_Dependant1,
                    GivenNames_Dependant2 = GivenNames_Dependant2,
                    GivenNames_Dependant3 = GivenNames_Dependant3,
                    PreferredShortName_Dependant1 = PreferredShortName_Dependant1,
                    PreferredShortName_Dependant2 = PreferredShortName_Dependant2,
                    PreferredShortName_Dependant3 = PreferredShortName_Dependant3,
                    Title_Dependant1 = Title_Dependant1,
                    Title_Dependant2 = Title_Dependant2,
                    Title_Dependant3 = Title_Dependant3,
                    GenderMale_Dependant1 = GenderMale_Dependant1,
                    GenderMale_Dependant2 = GenderMale_Dependant2,
                    GenderMale_Dependant3 = GenderMale_Dependant3,
                    DateOfBirth_Dependant1 = DateOfBirth_Dependant1,
                    DateOfBirth_Dependant2 = DateOfBirth_Dependant2,
                    DateOfBirth_Dependant3 = DateOfBirth_Dependant3,
                    Age_Dependant1 = Age_Dependant1,
                    Age_Dependant2 = Age_Dependant2,
                    Age_Dependant3 = Age_Dependant3,
                    Relationship_Dependant1 = Relationship_Dependant1,
                    Relationship_Dependant2 = Relationship_Dependant2,
                    Relationship_Dependant3 = Relationship_Dependant3,
                    SpecialNeeds_Dependant1 = SpecialNeeds_Dependant1,
                    SpecialNeeds_Dependant2 = SpecialNeeds_Dependant2,
                    SpecialNeeds_Dependant3 = SpecialNeeds_Dependant3,
                    Details_Dependant1 = Details_Dependant1,
                    Details_Dependant2 = Details_Dependant2,
                    Details_Dependant3 = Details_Dependant3,
                    Details2_Dependant1 = Details2_Dependant1,
                    Details2_Dependant2 = Details2_Dependant2,
                    Details2_Dependant3 = Details2_Dependant3,
                    Details3_Dependant1 = Details3_Dependant1,
                    Details3_Dependant2 = Details3_Dependant2,
                    Details3_Dependant3 = Details3_Dependant3,
                    Supporttoage_Dependant1 = Supporttoage_Dependant1,
                    Supporttoage_Dependant2 = Supporttoage_Dependant2,
                    Supporttoage_Dependant3 = Supporttoage_Dependant3,
                    SchoolName_Dependant1 = SchoolName_Dependant1,
                    SchoolName_Dependant2 = SchoolName_Dependant2,
                    SchoolName_Dependant3 = SchoolName_Dependant3,
                    SchoolYearLevel_Dependant1 = SchoolYearLevel_Dependant1,
                    SchoolYearLevel_Dependant2 = SchoolYearLevel_Dependant2,
                    SchoolYearLevel_Dependant3 = SchoolYearLevel_Dependant3,
                    EstimatedCostofSchooling_Dependant1 = EstimatedCostofSchooling_Dependant1,
                    EstimatedCostofSchooling_Dependant2 = EstimatedCostofSchooling_Dependant2,
                    EstimatedCostofSchooling_Dependant3 = EstimatedCostofSchooling_Dependant3,
                    AustudyStatus_Dependant1 = AustudyStatus_Dependant1,
                    AustudyStatus_Dependant2 = AustudyStatus_Dependant2,
                    AustudyStatus_Dependant3 = AustudyStatus_Dependant3,
                    ClientsParents = ClientsParents,
                    FileNotesClientsParents_FileName = FileNotesClientsParents_FileName,
                    FileNotesClientsParents_FilePath = FileNotesClientsParents_FilePath,
                    EgCollectablesGolfTennis_Client1 = EgCollectablesGolfTennis_Client1,
                    EgCollectablesGolfTennis_Client2 = EgCollectablesGolfTennis_Client2,
                    EgCollectablesGolfTennis2_Client1 = EgCollectablesGolfTennis2_Client1,
                    EgCollectablesGolfTennis2_Client2 = EgCollectablesGolfTennis2_Client2,
                    EgCollectablesGolfTennis3_Client1 = EgCollectablesGolfTennis3_Client1,
                    EgCollectablesGolfTennis3_Client2 = EgCollectablesGolfTennis3_Client2,
                    //Business Advisers	
                    Businessname_Accountant = Businessname_Accountant,
                    Businessname_Banker = Businessname_Banker,
                    Businessname_Lawyer = Businessname_Lawyer,
                    Contactname_Accountant = Contactname_Accountant,
                    Contactname_Banker = Contactname_Banker,
                    Contactname_Lawyer = Contactname_Lawyer,
                    Postaladdress_Accountant = Postaladdress_Accountant,
                    Postaladdress_Banker = Postaladdress_Banker,
                    Postaladdress_Lawyer = Postaladdress_Lawyer,
                    Postaladdress2_Accountant = Postaladdress2_Accountant,
                    Postaladdress2_Banker = Postaladdress2_Banker,
                    Postaladdress2_Lawyer = Postaladdress2_Lawyer,
                    PostaladdressState_Accountant = PostaladdressState_Accountant,
                    PostaladdressState_Banker = PostaladdressState_Banker,
                    PostaladdressState_Lawyer = PostaladdressState_Lawyer,
                    PostaladdressPostcode_Accountant = PostaladdressPostcode_Accountant,
                    PostaladdressPostcode_Banker = PostaladdressPostcode_Banker,
                    PostaladdressPostcode_Lawyer = PostaladdressPostcode_Lawyer,
                    Emailaddress_Accountant = Emailaddress_Accountant,
                    Emailaddress_Banker = Emailaddress_Banker,
                    Emailaddress_Lawyer = Emailaddress_Lawyer,
                    Phoneaddress_Accountant = Phoneaddress_Accountant,
                    Phoneaddress_Banker = Phoneaddress_Banker,
                    Phoneaddress_Lawyer = Phoneaddress_Lawyer,
                    Faxnumber_Accountant = Faxnumber_Accountant,
                    Faxnumber_Banker = Faxnumber_Banker,
                    Faxnumber_Lawyer = Faxnumber_Lawyer,
                    //File Notes	
                    FileNotes_FileName = FileNotes_FileName,
                    FileNotes_FilePath = FileNotes_FilePath
                });

            }

            return list;
        }

        public class SelectionAPersonalDetails
        {
            public int ID { get; set; }
            public int CoverPageID { get; set; }
            public string SurnameMaidenName_Client1 { get; set; }
            public string SurnameMaidenName_Client2 { get; set; }
            public string Givennames_Client1 { get; set; }
            public string Givennames_Client2 { get; set; }
            public string Preferredshortname_Client1 { get; set; }
            public string Preferredshortname_Client2 { get; set; }
            public string TitleMrMrsMsSirDr_Client1 { get; set; }
            public string TitleMrMrsMsSirDr_Client2 { get; set; }
            public int Gender_Client1 { get; set; }
            public int Gender_Client2 { get; set; }
            public DateTime DateOfBirth_Client1 { get; set; }
            public DateTime DateOfBirth_Client2 { get; set; }
            public int Age_Client1 { get; set; }
            public int Age_Client2 { get; set; }
            public int Maritalstatus_Client1 { get; set; }
            public int Maritalstatus_Client2 { get; set; }
            public int Health_Client1 { get; set; }
            public int Health_Client2 { get; set; }
            public int Smoker_Client1 { get; set; }
            public int Smoker_Client2 { get; set; }
            public string TownOfBirth_Client1 { get; set; }
            public string TownOfBirth_Client2 { get; set; }
            public string CountryOfBirth_Client1 { get; set; }
            public string CountryOfBirth_Client2 { get; set; }
            public string IfnotAustraliayearsinAustralia_Client1 { get; set; }
            public string IfnotAustraliayearsinAustralia_Client2 { get; set; }
            public string Areyouanonresident_Client1 { get; set; }
            public string Areyouanonresident_Client2 { get; set; }
            public string Taxfilenumber_Client1 { get; set; }
            public string Taxfilenumber_Client2 { get; set; }
            public string Wereyoureferredtous_Client1 { get; set; }
            public string Wereyoureferredtous_Client2 { get; set; }
            public string Haveyouworkedwithanotheradviser_Client1 { get; set; }
            public string Haveyouworkedwithanotheradviser_Client2 { get; set; }
            public string Areyouaresidentofanothercountryfortaxpurposes_Client1 { get; set; }
            public string Areyouaresidentofanothercountryfortaxpurposes_Client2 { get; set; }
            public string Ifyescountryofresidence_Client1 { get; set; }
            public string Ifyescountryofresidence_Client2 { get; set; }
            public string TaxidentificationnumberTINofforeigncountry_Client1 { get; set; }
            public string TaxidentificationnumberTINofforeigncountry_Client2 { get; set; }
            public string Areyouapoliticallyexposedperson_Client1 { get; set; }
            public string Areyouapoliticallyexposedperson_Client2 { get; set; }
            //Contact Details
            public string Addresspostal_Client1 { get; set; }
            public string Addresspostal_Client2 { get; set; }
            public string Addresspostal2_Client1 { get; set; }
            public string Addresspostal2_Client2 { get; set; }
            public string AddresspostalState_Client1 { get; set; }
            public string AddresspostalState_Client2 { get; set; }
            public string AddresspostalPostcode_Client1 { get; set; }
            public string AddresspostalPostcode_Client2 { get; set; }
            public string Addressresidentialother_Client1 { get; set; }
            public string Addressresidentialother_Client2 { get; set; }
            public string AddressresidentialotherState_Client1 { get; set; }
            public string AddressresidentialotherState_Client2 { get; set; }
            public string AddressresidentialotherPostcode_Client1 { get; set; }
            public string AddressresidentialotherPostcode_Client2 { get; set; }
            public string Emailaddress_Client1 { get; set; }
            public string Emailaddress_Client2 { get; set; }
            public string Contactnumbersmainnumber_Client1 { get; set; }
            public string Contactnumbersmainnumber_Client2 { get; set; }
            public string Officephone_Client1 { get; set; }
            public string Officephone_Client2 { get; set; }
            public string Mobile_Client1 { get; set; }
            public string Mobile_Client2 { get; set; }
            public string Fax_Client1 { get; set; }
            public string Fax_Client2 { get; set; }
            //Dependants
            public string SurnameName_Dependant1 { get; set; }
            public string SurnameName_Dependant2 { get; set; }
            public string SurnameName_Dependant3 { get; set; }
            public string GivenNames_Dependant1 { get; set; }
            public string GivenNames_Dependant2 { get; set; }
            public string GivenNames_Dependant3 { get; set; }
            public string PreferredShortName_Dependant1 { get; set; }
            public string PreferredShortName_Dependant2 { get; set; }
            public string PreferredShortName_Dependant3 { get; set; }
            public string Title_Dependant1 { get; set; }
            public string Title_Dependant2 { get; set; }
            public string Title_Dependant3 { get; set; }
            public int GenderMale_Dependant1 { get; set; }
            public int GenderMale_Dependant2 { get; set; }
            public int GenderMale_Dependant3 { get; set; }
            public DateTime DateOfBirth_Dependant1 { get; set; }
            public DateTime DateOfBirth_Dependant2 { get; set; }
            public DateTime DateOfBirth_Dependant3 { get; set; }
            public int Age_Dependant1 { get; set; }
            public int Age_Dependant2 { get; set; }
            public int Age_Dependant3 { get; set; }
            public string Relationship_Dependant1 { get; set; }
            public string Relationship_Dependant2 { get; set; }
            public string Relationship_Dependant3 { get; set; }
            public int SpecialNeeds_Dependant1 { get; set; }
            public int SpecialNeeds_Dependant2 { get; set; }
            public int SpecialNeeds_Dependant3 { get; set; }
            public string Details_Dependant1 { get; set; }
            public string Details_Dependant2 { get; set; }
            public string Details_Dependant3 { get; set; }
            public string Details2_Dependant1 { get; set; }
            public string Details2_Dependant2 { get; set; }
            public string Details2_Dependant3 { get; set; }
            public string Details3_Dependant1 { get; set; }
            public string Details3_Dependant2 { get; set; }
            public string Details3_Dependant3 { get; set; }
            public string Supporttoage_Dependant1 { get; set; }
            public string Supporttoage_Dependant2 { get; set; }
            public string Supporttoage_Dependant3 { get; set; }
            public string SchoolName_Dependant1 { get; set; }
            public string SchoolName_Dependant2 { get; set; }
            public string SchoolName_Dependant3 { get; set; }
            public string SchoolYearLevel_Dependant1 { get; set; }
            public string SchoolYearLevel_Dependant2 { get; set; }
            public string SchoolYearLevel_Dependant3 { get; set; }
            public string EstimatedCostofSchooling_Dependant1 { get; set; }
            public string EstimatedCostofSchooling_Dependant2 { get; set; }
            public string EstimatedCostofSchooling_Dependant3 { get; set; }
            public int AustudyStatus_Dependant1 { get; set; }
            public int AustudyStatus_Dependant2 { get; set; }
            public int AustudyStatus_Dependant3 { get; set; }
            public string ClientsParents { get; set; }
            public string FileNotesClientsParents_FileName { get; set; }
            public string FileNotesClientsParents_FilePath { get; set; }
            public string EgCollectablesGolfTennis_Client1 { get; set; }
            public string EgCollectablesGolfTennis_Client2 { get; set; }
            public string EgCollectablesGolfTennis2_Client1 { get; set; }
            public string EgCollectablesGolfTennis2_Client2 { get; set; }
            public string EgCollectablesGolfTennis3_Client1 { get; set; }
            public string EgCollectablesGolfTennis3_Client2 { get; set; }
            //Business Advisers
            public string Businessname_Accountant { get; set; }
            public string Businessname_Banker { get; set; }
            public string Businessname_Lawyer { get; set; }
            public string Contactname_Accountant { get; set; }
            public string Contactname_Banker { get; set; }
            public string Contactname_Lawyer { get; set; }
            public string Postaladdress_Accountant { get; set; }
            public string Postaladdress_Banker { get; set; }
            public string Postaladdress_Lawyer { get; set; }
            public string Postaladdress2_Accountant { get; set; }
            public string Postaladdress2_Banker { get; set; }
            public string Postaladdress2_Lawyer { get; set; }
            public string PostaladdressState_Accountant { get; set; }
            public string PostaladdressState_Banker { get; set; }
            public string PostaladdressState_Lawyer { get; set; }
            public string PostaladdressPostcode_Accountant { get; set; }
            public string PostaladdressPostcode_Banker { get; set; }
            public string PostaladdressPostcode_Lawyer { get; set; }
            public string Emailaddress_Accountant { get; set; }
            public string Emailaddress_Banker { get; set; }
            public string Emailaddress_Lawyer { get; set; }
            public string Phoneaddress_Accountant { get; set; }
            public string Phoneaddress_Banker { get; set; }
            public string Phoneaddress_Lawyer { get; set; }
            public string Faxnumber_Accountant { get; set; }
            public string Faxnumber_Banker { get; set; }
            public string Faxnumber_Lawyer { get; set; }
            //File Notes
            public string FileNotes_FileName { get; set; }
            public string FileNotes_FilePath { get; set; }




        }

        public class SelectionBFinancialSummary
        {
            public int ID { get; set; }
            public int CoverPageID { get; set; }
            //Employment Details
            public int Workstatus_Client1 { get; set; }
            public int Workstatus_Client2 { get; set; }
            public string Employer_Client1 { get; set; }
            public string Employer_Client2 { get; set; }
            public string Employeraddress_Client1 { get; set; }
            public string Employeraddress_Client2 { get; set; }
            public string Occupation_Client1 { get; set; }
            public string Occupation_Client2 { get; set; }
            public string Numberofyearsservice_Client1 { get; set; }
            public string Numberofyearsservice_Client2 { get; set; }
            public string IntendedRetirementdate_Client1 { get; set; }
            public string IntendedRetirementdate_Client2 { get; set; }
            public string Doyouexpectemployment_Client1 { get; set; }
            public string Doyouexpectemployment_Client2 { get; set; }
            //Salary & Other Income
            public string Salaryincome_Client1 { get; set; }
            public string Salaryincome_Client2 { get; set; }
            public string Othertaxableincome_Client1 { get; set; }
            public string Othertaxableincome_Client2 { get; set; }
            public string Taxfreeincome_Client1 { get; set; }
            public string Taxfreeincome_Client2 { get; set; }
            public string Familyallowance_Client1 { get; set; }
            public string Familyallowance_Client2 { get; set; }
            public string Directorsfeesgratuities_Client1 { get; set; }
            public string Directorsfeesgratuities_Client2 { get; set; }
            public string Areyouexpectingfunds1_Client1 { get; set; }
            public string Areyouexpectingfunds1_Client2 { get; set; }
            public string Areyouexpectingfunds2_Client1 { get; set; }
            public string Areyouexpectingfunds2_Client2 { get; set; }
            public string Areyouexpectingfunds3_Client1 { get; set; }
            public string Areyouexpectingfunds3_Client2 { get; set; }
            public string Other1_Client1 { get; set; }
            public string Other1_Client2 { get; set; }
            public string Other2_Client1 { get; set; }
            public string Other2_Client2 { get; set; }
            public string Other3_Client1 { get; set; }
            public string Other3_Client2 { get; set; }
            //Salary Sacrifice / Package
            public string Employmentsuper_Client1 { get; set; }
            public string Employmentsuper_Client2 { get; set; }
            public string Salarysacrificetosuper_Client1 { get; set; }
            public string Salarysacrificetosuper_Client2 { get; set; }
            public string Packagedmotorvehicle_Client1 { get; set; }
            public string Packagedmotorvehicle_Client2 { get; set; }
            public string Bonus_Client1 { get; set; }
            public string Bonus_Client2 { get; set; }
            public string Other_Client1 { get; set; }
            public string Other_Client2 { get; set; }
            //Centrelink
            public string Entitlementamount_Client1 { get; set; }
            public string Entitlementamount_Client2 { get; set; }
            public string Entitlementtype_Client1 { get; set; }
            public string Entitlementtype_Client2 { get; set; }
            public string CentrelinkreferencenoCRN_Client1 { get; set; }
            public string CentrelinkreferencenoCRN_Client2 { get; set; }
            public string Maintenanceincome_Client1 { get; set; }
            public string Maintenanceincome_Client2 { get; set; }
            public string Maintenancepayment_Client1 { get; set; }
            public string Maintenancepayment_Client2 { get; set; }
            public string Overseassocialsecurityincome_Client1 { get; set; }
            public string Overseassocialsecurityincome_Client2 { get; set; }
            //Centrelink - File Notes
            public string FileNotesCentrelink_FileName { get; set; }
            public string FileNotesCentrelink_FilePath { get; set; }
            //Cost of living
            public string Foodliquids_Fortnight { get; set; }
            public string Foodliquids_Month { get; set; }
            public string Foodliquids_Quarter { get; set; }
            public string Foodliquids_Halfyear { get; set; }
            public string Foodliquids_Annual { get; set; }
            public string Foodliquids_Totallastyear { get; set; }

            public string Alcohol_Fortnight { get; set; }
            public string Alcohol_Month { get; set; }
            public string Alcohol_Quarter { get; set; }
            public string Alcohol_Halfyear { get; set; }
            public string Alcohol_Annual { get; set; }
            public string Alcohol_Totallastyear { get; set; }

            public string Tobacco_Fortnight { get; set; }
            public string Tobacco_Month { get; set; }
            public string Tobacco_Quarter { get; set; }
            public string Tobacco_Halfyear { get; set; }
            public string Tobacco_Annual { get; set; }
            public string Tobacco_Totallastyear { get; set; }

            public string Clothingfootwear_Fortnight { get; set; }
            public string Clothingfootwear_Month { get; set; }
            public string Clothingfootwear_Quarter { get; set; }
            public string Clothingfootwear_Halfyear { get; set; }
            public string Clothingfootwear_Annual { get; set; }
            public string Clothingfootwear_Totallastyear { get; set; }

            public string Medicalhealth_Fortnight { get; set; }
            public string Medicalhealth_Month { get; set; }
            public string Medicalhealth_Quarter { get; set; }
            public string Medicalhealth_Halfyear { get; set; }
            public string Medicalhealth_Annual { get; set; }
            public string Medicalhealth_Totallastyear { get; set; }

            public string Recreation_Fortnight { get; set; }
            public string Recreation_Month { get; set; }
            public string Recreation_Quarter { get; set; }
            public string Recreation_Halfyear { get; set; }
            public string Recreation_Annual { get; set; }
            public string Recreation_Totallastyear { get; set; }

            public string Personalcare_Fortnight { get; set; }
            public string Personalcare_Month { get; set; }
            public string Personalcare_Quarter { get; set; }
            public string Personalcare_Halfyear { get; set; }
            public string Personalcare_Annual { get; set; }
            public string Personalcare_Totallastyear { get; set; }

            public string PhonePost_Fortnight { get; set; }
            public string PhonePost_Month { get; set; }
            public string PhonePost_Quarter { get; set; }
            public string PhonePost_Halfyear { get; set; }
            public string PhonePost_Annual { get; set; }
            public string PhonePost_Totallastyear { get; set; }

            public string Travel_Fortnight { get; set; }
            public string Travel_Month { get; set; }
            public string Travel_Quarter { get; set; }
            public string Travel_Halfyear { get; set; }
            public string Travel_Annual { get; set; }
            public string Travel_Totallastyear { get; set; }

            public string Gifts_Fortnight { get; set; }
            public string Gifts_Month { get; set; }
            public string Gifts_Quarter { get; set; }
            public string Gifts_Halfyear { get; set; }
            public string Gifts_Annual { get; set; }
            public string Gifts_Totallastyear { get; set; }

            public string Other_Fortnight { get; set; }
            public string Other_Month { get; set; }
            public string Other_Quarter { get; set; }
            public string Other_Halfyear { get; set; }
            public string Other_Annual { get; set; }
            public string Other_Totallastyear { get; set; }

            public string Ratesinsurance_Fortnight { get; set; }
            public string Ratesinsurance_Month { get; set; }
            public string Ratesinsurance_Quarter { get; set; }
            public string Ratesinsurance_Halfyear { get; set; }
            public string Ratesinsurance_Annual { get; set; }
            public string Ratesinsurance_Totallastyear { get; set; }

            public string Repairsmaintenance_Fortnight { get; set; }
            public string Repairsmaintenance_Month { get; set; }
            public string Repairsmaintenance_Quarter { get; set; }
            public string Repairsmaintenance_Halfyear { get; set; }
            public string Repairsmaintenance_Annual { get; set; }
            public string Repairsmaintenance_Totallastyear { get; set; }

            public string Electricitygas_Fortnight { get; set; }
            public string Electricitygas_Month { get; set; }
            public string Electricitygas_Quarter { get; set; }
            public string Electricitygas_Halfyear { get; set; }
            public string Electricitygas_Annual { get; set; }
            public string Electricitygas_Totallastyear { get; set; }

            public string Houseloanprincipal_Fortnight { get; set; }
            public string Houseloanprincipal_Month { get; set; }
            public string Houseloanprincipal_Quarter { get; set; }
            public string Houseloanprincipal_Halfyear { get; set; }
            public string Houseloanprincipal_Annual { get; set; }
            public string Houseloanprincipal_Totallastyear { get; set; }

            public string Rentmortgage_Fortnight { get; set; }
            public string Rentmortgage_Month { get; set; }
            public string Rentmortgage_Quarter { get; set; }
            public string Rentmortgage_Halfyear { get; set; }
            public string Rentmortgage_Annual { get; set; }
            public string Rentmortgage_Totallastyear { get; set; }

            public string Extramortgagepayments_Fortnight { get; set; }
            public string Extramortgagepayments_Month { get; set; }
            public string Extramortgagepayments_Quarter { get; set; }
            public string Extramortgagepayments_Halfyear { get; set; }
            public string Extramortgagepayments_Annual { get; set; }
            public string Extramortgagepayments_Totallastyear { get; set; }

            public string Furnishingequipment_Fortnight { get; set; }
            public string Furnishingequipment_Month { get; set; }
            public string Furnishingequipment_Quarter { get; set; }
            public string Furnishingequipment_Halfyear { get; set; }
            public string Furnishingequipment_Annual { get; set; }
            public string Furnishingequipment_Totallastyear { get; set; }

            public string OtherHousing_Fortnight { get; set; }
            public string OtherHousing_Month { get; set; }
            public string OtherHousing_Quarter { get; set; }
            public string OtherHousing_Halfyear { get; set; }
            public string OtherHousing_Annual { get; set; }
            public string OtherHousing_Totallastyear { get; set; }

            public string Registrationinsurance_Fortnight { get; set; }
            public string Registrationinsurance_Month { get; set; }
            public string Registrationinsurance_Quarter { get; set; }
            public string Registrationinsurance_Halfyear { get; set; }
            public string Registrationinsurance_Annual { get; set; }
            public string Registrationinsurance_Totallastyear { get; set; }

            public string RepairsmaintenanceTransport_Fortnight { get; set; }
            public string RepairsmaintenanceTransport_Month { get; set; }
            public string RepairsmaintenanceTransport_Quarter { get; set; }
            public string RepairsmaintenanceTransport_Halfyear { get; set; }
            public string RepairsmaintenanceTransport_Annual { get; set; }
            public string RepairsmaintenanceTransport_Totallastyear { get; set; }

            public string FuelOil_Fortnight { get; set; }
            public string FuelOil_Month { get; set; }
            public string FuelOil_Quarter { get; set; }
            public string FuelOil_Halfyear { get; set; }
            public string FuelOil_Annual { get; set; }
            public string FuelOil_Totallastyear { get; set; }

            public string Replacementvehicle_Fortnight { get; set; }
            public string Replacementvehicle_Month { get; set; }
            public string Replacementvehicle_Quarter { get; set; }
            public string Replacementvehicle_Halfyear { get; set; }
            public string Replacementvehicle_Annual { get; set; }
            public string Replacementvehicle_Totallastyear { get; set; }

            public string Fares_Fortnight { get; set; }
            public string Fares_Month { get; set; }
            public string Fares_Quarter { get; set; }
            public string Fares_Halfyear { get; set; }
            public string Fares_Annual { get; set; }
            public string Fares_Totallastyear { get; set; }

            public string OtherTransport_Fortnight { get; set; }
            public string OtherTransport_Month { get; set; }
            public string OtherTransport_Quarter { get; set; }
            public string OtherTransport_Halfyear { get; set; }
            public string OtherTransport_Annual { get; set; }
            public string OtherTransport_Totallastyear { get; set; }

            public string Superlifeinsurance_Fortnight { get; set; }
            public string Superlifeinsurance_Month { get; set; }
            public string Superlifeinsurance_Quarter { get; set; }
            public string Superlifeinsurance_Halfyear { get; set; }
            public string Superlifeinsurance_Annual { get; set; }
            public string Superlifeinsurance_Totallastyear { get; set; }

            public string Loansavings_Fortnight { get; set; }
            public string Loansavings_Month { get; set; }
            public string Loansavings_Quarter { get; set; }
            public string Loansavings_Halfyear { get; set; }
            public string Loansavings_Annual { get; set; }
            public string Loansavings_Totallastyear { get; set; }

            public string Carloan_Fortnight { get; set; }
            public string Carloan_Month { get; set; }
            public string Carloan_Quarter { get; set; }
            public string Carloan_Halfyear { get; set; }
            public string Carloan_Annual { get; set; }
            public string Carloan_Totallastyear { get; set; }

            public string OtherGeneral_Fortnight { get; set; }
            public string OtherGeneral_Month { get; set; }
            public string OtherGeneral_Quarter { get; set; }
            public string OtherGeneral_Halfyear { get; set; }
            public string OtherGeneral_Annual { get; set; }
            public string OtherGeneral_Totallastyear { get; set; }

            public string Foodliquid_Fortnight { get; set; }
            public string Foodliquid_Month { get; set; }
            public string Foodliquid_Quarter { get; set; }
            public string Foodliquid_Halfyear { get; set; }
            public string Foodliquid_Annual { get; set; }
            public string Foodliquid_Totallastyear { get; set; }

            public string ClothingfootwearChildren_Fortnight { get; set; }
            public string ClothingfootwearChildren_Month { get; set; }
            public string ClothingfootwearChildren_Quarter { get; set; }
            public string ClothingfootwearChildren_Halfyear { get; set; }
            public string ClothingfootwearChildren_Annual { get; set; }
            public string ClothingfootwearChildren_Totallastyear { get; set; }

            public string Education_Fortnight { get; set; }
            public string Education_Month { get; set; }
            public string Education_Quarter { get; set; }
            public string Education_Halfyear { get; set; }
            public string Education_Annual { get; set; }
            public string Education_Totallastyear { get; set; }

            public string OtherChildren_Fortnight { get; set; }
            public string OtherChildren_Month { get; set; }
            public string OtherChildren_Quarter { get; set; }
            public string OtherChildren_Halfyear { get; set; }
            public string OtherChildren_Annual { get; set; }
            public string OtherChildren_Totallastyear { get; set; }

            public string Total_Fortnight { get; set; }
            public string Total_Month { get; set; }
            public string Total_Quarter { get; set; }
            public string Total_Halfyear { get; set; }
            public string Total_Annual { get; set; }
            public string Total_Totallastyear { get; set; }



        }

        public static IList CreateList_SelectionBFinancialSummary()
        {
            List<SelectionBFinancialSummary> list = new List<SelectionBFinancialSummary>();

            SqliteConnection connstr = new SqliteConnection(@"Data Source=ticdb.db;");
            connstr.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connstr;
            cmd.CommandText = "select * from SelectionBFinancialSummary";
            SqliteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            connstr.Close();

            foreach (DataRow item in dt.Rows)
            {
                int ID = item.ItemArray[0] != DBNull.Value ? Convert.ToInt32(item.ItemArray[0]) : 0;
                int CoverPageID = item.ItemArray[1] != DBNull.Value ? Convert.ToInt32(item.ItemArray[1]) : 0;
                //Employment Details
                int Workstatus_Client1 = item.ItemArray[2] != DBNull.Value ? Convert.ToInt32(item.ItemArray[2]) : 0;
                int Workstatus_Client2 = item.ItemArray[3] != DBNull.Value ? Convert.ToInt32(item.ItemArray[3]) : 0;
                string Employer_Client1 = item.ItemArray[4].ToString();
                string Employer_Client2 = item.ItemArray[5].ToString();
                string Employeraddress_Client1 = item.ItemArray[6].ToString();
                string Employeraddress_Client2 = item.ItemArray[7].ToString();
                string Occupation_Client1 = item.ItemArray[8].ToString();
                string Occupation_Client2 = item.ItemArray[9].ToString();
                string Numberofyearsservice_Client1 = item.ItemArray[10].ToString();
                string Numberofyearsservice_Client2 = item.ItemArray[11].ToString();
                string IntendedRetirementdate_Client1 = item.ItemArray[12].ToString();
                string IntendedRetirementdate_Client2 = item.ItemArray[13].ToString();
                string Doyouexpectemployment_Client1 = item.ItemArray[14].ToString();
                string Doyouexpectemployment_Client2 = item.ItemArray[15].ToString();
                //Salary & Other Income
                string Salaryincome_Client1 = item.ItemArray[16].ToString();
                string Salaryincome_Client2 = item.ItemArray[17].ToString();
                string Othertaxableincome_Client1 = item.ItemArray[18].ToString();
                string Othertaxableincome_Client2 = item.ItemArray[19].ToString();
                string Taxfreeincome_Client1 = item.ItemArray[20].ToString();
                string Taxfreeincome_Client2 = item.ItemArray[21].ToString();
                string Familyallowance_Client1 = item.ItemArray[22].ToString();
                string Familyallowance_Client2 = item.ItemArray[23].ToString();
                string Directorsfeesgratuities_Client1 = item.ItemArray[24].ToString();
                string Directorsfeesgratuities_Client2 = item.ItemArray[25].ToString();
                string Areyouexpectingfunds1_Client1 = item.ItemArray[26].ToString();
                string Areyouexpectingfunds1_Client2 = item.ItemArray[27].ToString();
                string Areyouexpectingfunds2_Client1 = item.ItemArray[28].ToString();
                string Areyouexpectingfunds2_Client2 = item.ItemArray[29].ToString();
                string Areyouexpectingfunds3_Client1 = item.ItemArray[30].ToString();
                string Areyouexpectingfunds3_Client2 = item.ItemArray[31].ToString();
                string Other1_Client1 = item.ItemArray[32].ToString();
                string Other1_Client2 = item.ItemArray[33].ToString();
                string Other2_Client1 = item.ItemArray[34].ToString();
                string Other2_Client2 = item.ItemArray[35].ToString();
                string Other3_Client1 = item.ItemArray[36].ToString();
                string Other3_Client2 = item.ItemArray[37].ToString();
                //Salary Sacrifice / Package
                string Employmentsuper_Client1 = item.ItemArray[38].ToString();
                string Employmentsuper_Client2 = item.ItemArray[39].ToString();
                string Salarysacrificetosuper_Client1 = item.ItemArray[40].ToString();
                string Salarysacrificetosuper_Client2 = item.ItemArray[41].ToString();
                string Packagedmotorvehicle_Client1 = item.ItemArray[42].ToString();
                string Packagedmotorvehicle_Client2 = item.ItemArray[43].ToString();
                string Bonus_Client1 = item.ItemArray[44].ToString();
                string Bonus_Client2 = item.ItemArray[45].ToString();
                string Other_Client1 = item.ItemArray[46].ToString();
                string Other_Client2 = item.ItemArray[47].ToString();
                //Centrelink
                string Entitlementamount_Client1 = item.ItemArray[48].ToString();
                string Entitlementamount_Client2 = item.ItemArray[49].ToString();
                string Entitlementtype_Client1 = item.ItemArray[50].ToString();
                string Entitlementtype_Client2 = item.ItemArray[51].ToString();
                string CentrelinkreferencenoCRN_Client1 = item.ItemArray[52].ToString();
                string CentrelinkreferencenoCRN_Client2 = item.ItemArray[53].ToString();
                string Maintenanceincome_Client1 = item.ItemArray[54].ToString();
                string Maintenanceincome_Client2 = item.ItemArray[55].ToString();
                string Maintenancepayment_Client1 = item.ItemArray[56].ToString();
                string Maintenancepayment_Client2 = item.ItemArray[57].ToString();
                string Overseassocialsecurityincome_Client1 = item.ItemArray[58].ToString();
                string Overseassocialsecurityincome_Client2 = item.ItemArray[59].ToString();
                //Centrelink - File Notes
                string FileNotesCentrelink_FileName = item.ItemArray[60].ToString();
                string FileNotesCentrelink_FilePath = item.ItemArray[61].ToString();
                //Cost of living
                string Foodliquids_Fortnight = item.ItemArray[62].ToString();
                string Foodliquids_Month = item.ItemArray[63].ToString();
                string Foodliquids_Quarter = item.ItemArray[64].ToString();
                string Foodliquids_Halfyear = item.ItemArray[65].ToString();
                string Foodliquids_Annual = item.ItemArray[66].ToString();
                string Foodliquids_Totallastyear = item.ItemArray[67].ToString();

                string Alcohol_Fortnight = item.ItemArray[68].ToString();
                string Alcohol_Month = item.ItemArray[69].ToString();
                string Alcohol_Quarter = item.ItemArray[70].ToString();
                string Alcohol_Halfyear = item.ItemArray[71].ToString();
                string Alcohol_Annual = item.ItemArray[72].ToString();
                string Alcohol_Totallastyear = item.ItemArray[73].ToString();

                string Tobacco_Fortnight = item.ItemArray[74].ToString();
                string Tobacco_Month = item.ItemArray[75].ToString();
                string Tobacco_Quarter = item.ItemArray[76].ToString();
                string Tobacco_Halfyear = item.ItemArray[77].ToString();
                string Tobacco_Annual = item.ItemArray[78].ToString();
                string Tobacco_Totallastyear = item.ItemArray[79].ToString();

                string Clothingfootwear_Fortnight = item.ItemArray[80].ToString();
                string Clothingfootwear_Month = item.ItemArray[81].ToString();
                string Clothingfootwear_Quarter = item.ItemArray[82].ToString();
                string Clothingfootwear_Halfyear = item.ItemArray[83].ToString();
                string Clothingfootwear_Annual = item.ItemArray[84].ToString();
                string Clothingfootwear_Totallastyear = item.ItemArray[85].ToString();

                string Medicalhealth_Fortnight = item.ItemArray[86].ToString();
                string Medicalhealth_Month = item.ItemArray[87].ToString();
                string Medicalhealth_Quarter = item.ItemArray[88].ToString();
                string Medicalhealth_Halfyear = item.ItemArray[89].ToString();
                string Medicalhealth_Annual = item.ItemArray[90].ToString();
                string Medicalhealth_Totallastyear = item.ItemArray[91].ToString();

                string Recreation_Fortnight = item.ItemArray[92].ToString();
                string Recreation_Month = item.ItemArray[93].ToString();
                string Recreation_Quarter = item.ItemArray[94].ToString();
                string Recreation_Halfyear = item.ItemArray[95].ToString();
                string Recreation_Annual = item.ItemArray[96].ToString();
                string Recreation_Totallastyear = item.ItemArray[97].ToString();

                string Personalcare_Fortnight = item.ItemArray[98].ToString();
                string Personalcare_Month = item.ItemArray[99].ToString();
                string Personalcare_Quarter = item.ItemArray[100].ToString();
                string Personalcare_Halfyear = item.ItemArray[101].ToString();
                string Personalcare_Annual = item.ItemArray[102].ToString();
                string Personalcare_Totallastyear = item.ItemArray[103].ToString();

                string PhonePost_Fortnight = item.ItemArray[104].ToString();
                string PhonePost_Month = item.ItemArray[105].ToString();
                string PhonePost_Quarter = item.ItemArray[106].ToString();
                string PhonePost_Halfyear = item.ItemArray[107].ToString();
                string PhonePost_Annual = item.ItemArray[108].ToString();
                string PhonePost_Totallastyear = item.ItemArray[109].ToString();

                string Travel_Fortnight = item.ItemArray[110].ToString();
                string Travel_Month = item.ItemArray[111].ToString();
                string Travel_Quarter = item.ItemArray[112].ToString();
                string Travel_Halfyear = item.ItemArray[113].ToString();
                string Travel_Annual = item.ItemArray[114].ToString();
                string Travel_Totallastyear = item.ItemArray[115].ToString();

                string Gifts_Fortnight = item.ItemArray[116].ToString();
                string Gifts_Month = item.ItemArray[117].ToString();
                string Gifts_Quarter = item.ItemArray[118].ToString();
                string Gifts_Halfyear = item.ItemArray[119].ToString();
                string Gifts_Annual = item.ItemArray[120].ToString();
                string Gifts_Totallastyear = item.ItemArray[121].ToString();

                string Other_Fortnight = item.ItemArray[122].ToString();
                string Other_Month = item.ItemArray[123].ToString();
                string Other_Quarter = item.ItemArray[124].ToString();
                string Other_Halfyear = item.ItemArray[125].ToString();
                string Other_Annual = item.ItemArray[126].ToString();
                string Other_Totallastyear = item.ItemArray[127].ToString();

                string Ratesinsurance_Fortnight = item.ItemArray[128].ToString();
                string Ratesinsurance_Month = item.ItemArray[129].ToString();
                string Ratesinsurance_Quarter = item.ItemArray[130].ToString();
                string Ratesinsurance_Halfyear = item.ItemArray[131].ToString();
                string Ratesinsurance_Annual = item.ItemArray[132].ToString();
                string Ratesinsurance_Totallastyear = item.ItemArray[133].ToString();

                string Repairsmaintenance_Fortnight = item.ItemArray[134].ToString();
                string Repairsmaintenance_Month = item.ItemArray[135].ToString();
                string Repairsmaintenance_Quarter = item.ItemArray[136].ToString();
                string Repairsmaintenance_Halfyear = item.ItemArray[137].ToString();
                string Repairsmaintenance_Annual = item.ItemArray[138].ToString();
                string Repairsmaintenance_Totallastyear = item.ItemArray[139].ToString();

                string Electricitygas_Fortnight = item.ItemArray[140].ToString();
                string Electricitygas_Month = item.ItemArray[141].ToString();
                string Electricitygas_Quarter = item.ItemArray[142].ToString();
                string Electricitygas_Halfyear = item.ItemArray[143].ToString();
                string Electricitygas_Annual = item.ItemArray[144].ToString();
                string Electricitygas_Totallastyear = item.ItemArray[145].ToString();

                string Houseloanprincipal_Fortnight = item.ItemArray[146].ToString();
                string Houseloanprincipal_Month = item.ItemArray[147].ToString();
                string Houseloanprincipal_Quarter = item.ItemArray[148].ToString();
                string Houseloanprincipal_Halfyear = item.ItemArray[149].ToString();
                string Houseloanprincipal_Annual = item.ItemArray[150].ToString();
                string Houseloanprincipal_Totallastyear = item.ItemArray[151].ToString();

                string Rentmortgage_Fortnight = item.ItemArray[152].ToString();
                string Rentmortgage_Month = item.ItemArray[153].ToString();
                string Rentmortgage_Quarter = item.ItemArray[154].ToString();
                string Rentmortgage_Halfyear = item.ItemArray[155].ToString();
                string Rentmortgage_Annual = item.ItemArray[156].ToString();
                string Rentmortgage_Totallastyear = item.ItemArray[157].ToString();

                string Extramortgagepayments_Fortnight = item.ItemArray[158].ToString();
                string Extramortgagepayments_Month = item.ItemArray[159].ToString();
                string Extramortgagepayments_Quarter = item.ItemArray[160].ToString();
                string Extramortgagepayments_Halfyear = item.ItemArray[161].ToString();
                string Extramortgagepayments_Annual = item.ItemArray[162].ToString();
                string Extramortgagepayments_Totallastyear = item.ItemArray[163].ToString();

                string Furnishingequipment_Fortnight = item.ItemArray[164].ToString();
                string Furnishingequipment_Month = item.ItemArray[165].ToString();
                string Furnishingequipment_Quarter = item.ItemArray[166].ToString();
                string Furnishingequipment_Halfyear = item.ItemArray[167].ToString();
                string Furnishingequipment_Annual = item.ItemArray[168].ToString();
                string Furnishingequipment_Totallastyear = item.ItemArray[169].ToString();

                string OtherHousing_Fortnight = item.ItemArray[170].ToString();
                string OtherHousing_Month = item.ItemArray[171].ToString();
                string OtherHousing_Quarter = item.ItemArray[172].ToString();
                string OtherHousing_Halfyear = item.ItemArray[173].ToString();
                string OtherHousing_Annual = item.ItemArray[174].ToString();
                string OtherHousing_Totallastyear = item.ItemArray[175].ToString();

                string Registrationinsurance_Fortnight = item.ItemArray[176].ToString();
                string Registrationinsurance_Month = item.ItemArray[177].ToString();
                string Registrationinsurance_Quarter = item.ItemArray[178].ToString();
                string Registrationinsurance_Halfyear = item.ItemArray[179].ToString();
                string Registrationinsurance_Annual = item.ItemArray[180].ToString();
                string Registrationinsurance_Totallastyear = item.ItemArray[181].ToString();

                string RepairsmaintenanceTransport_Fortnight = item.ItemArray[182].ToString();
                string RepairsmaintenanceTransport_Month = item.ItemArray[183].ToString();
                string RepairsmaintenanceTransport_Quarter = item.ItemArray[184].ToString();
                string RepairsmaintenanceTransport_Halfyear = item.ItemArray[185].ToString();
                string RepairsmaintenanceTransport_Annual = item.ItemArray[186].ToString();
                string RepairsmaintenanceTransport_Totallastyear = item.ItemArray[187].ToString();

                string FuelOil_Fortnight = item.ItemArray[188].ToString();
                string FuelOil_Month = item.ItemArray[189].ToString();
                string FuelOil_Quarter = item.ItemArray[190].ToString();
                string FuelOil_Halfyear = item.ItemArray[191].ToString();
                string FuelOil_Annual = item.ItemArray[192].ToString();
                string FuelOil_Totallastyear = item.ItemArray[193].ToString();

                string Replacementvehicle_Fortnight = item.ItemArray[194].ToString();
                string Replacementvehicle_Month = item.ItemArray[195].ToString();
                string Replacementvehicle_Quarter = item.ItemArray[196].ToString();
                string Replacementvehicle_Halfyear = item.ItemArray[197].ToString();
                string Replacementvehicle_Annual = item.ItemArray[198].ToString();
                string Replacementvehicle_Totallastyear = item.ItemArray[199].ToString();

                string Fares_Fortnight = item.ItemArray[200].ToString();
                string Fares_Month = item.ItemArray[201].ToString();
                string Fares_Quarter = item.ItemArray[202].ToString();
                string Fares_Halfyear = item.ItemArray[203].ToString();
                string Fares_Annual = item.ItemArray[204].ToString();
                string Fares_Totallastyear = item.ItemArray[205].ToString();

                string OtherTransport_Fortnight = item.ItemArray[206].ToString();
                string OtherTransport_Month = item.ItemArray[207].ToString();
                string OtherTransport_Quarter = item.ItemArray[208].ToString();
                string OtherTransport_Halfyear = item.ItemArray[209].ToString();
                string OtherTransport_Annual = item.ItemArray[210].ToString();
                string OtherTransport_Totallastyear = item.ItemArray[211].ToString();

                string Superlifeinsurance_Fortnight = item.ItemArray[212].ToString();
                string Superlifeinsurance_Month = item.ItemArray[213].ToString();
                string Superlifeinsurance_Quarter = item.ItemArray[214].ToString();
                string Superlifeinsurance_Halfyear = item.ItemArray[215].ToString();
                string Superlifeinsurance_Annual = item.ItemArray[216].ToString();
                string Superlifeinsurance_Totallastyear = item.ItemArray[217].ToString();

                string Loansavings_Fortnight = item.ItemArray[218].ToString();
                string Loansavings_Month = item.ItemArray[219].ToString();
                string Loansavings_Quarter = item.ItemArray[220].ToString();
                string Loansavings_Halfyear = item.ItemArray[221].ToString();
                string Loansavings_Annual = item.ItemArray[222].ToString();
                string Loansavings_Totallastyear = item.ItemArray[223].ToString();

                string Carloan_Fortnight = item.ItemArray[224].ToString();
                string Carloan_Month = item.ItemArray[225].ToString();
                string Carloan_Quarter = item.ItemArray[226].ToString();
                string Carloan_Halfyear = item.ItemArray[227].ToString();
                string Carloan_Annual = item.ItemArray[228].ToString();
                string Carloan_Totallastyear = item.ItemArray[229].ToString();

                string OtherGeneral_Fortnight = item.ItemArray[230].ToString();
                string OtherGeneral_Month = item.ItemArray[231].ToString();
                string OtherGeneral_Quarter = item.ItemArray[232].ToString();
                string OtherGeneral_Halfyear = item.ItemArray[233].ToString();
                string OtherGeneral_Annual = item.ItemArray[234].ToString();
                string OtherGeneral_Totallastyear = item.ItemArray[235].ToString();

                string Foodliquid_Fortnight = item.ItemArray[236].ToString();
                string Foodliquid_Month = item.ItemArray[237].ToString();
                string Foodliquid_Quarter = item.ItemArray[238].ToString();
                string Foodliquid_Halfyear = item.ItemArray[239].ToString();
                string Foodliquid_Annual = item.ItemArray[240].ToString();
                string Foodliquid_Totallastyear = item.ItemArray[241].ToString();

                string ClothingfootwearChildren_Fortnight = item.ItemArray[242].ToString();
                string ClothingfootwearChildren_Month = item.ItemArray[243].ToString();
                string ClothingfootwearChildren_Quarter = item.ItemArray[244].ToString();
                string ClothingfootwearChildren_Halfyear = item.ItemArray[245].ToString();
                string ClothingfootwearChildren_Annual = item.ItemArray[246].ToString();
                string ClothingfootwearChildren_Totallastyear = item.ItemArray[247].ToString();

                string Education_Fortnight = item.ItemArray[248].ToString();
                string Education_Month = item.ItemArray[249].ToString();
                string Education_Quarter = item.ItemArray[250].ToString();
                string Education_Halfyear = item.ItemArray[251].ToString();
                string Education_Annual = item.ItemArray[252].ToString();
                string Education_Totallastyear = item.ItemArray[253].ToString();

                string OtherChildren_Fortnight = item.ItemArray[254].ToString();
                string OtherChildren_Month = item.ItemArray[255].ToString();
                string OtherChildren_Quarter = item.ItemArray[256].ToString();
                string OtherChildren_Halfyear = item.ItemArray[257].ToString();
                string OtherChildren_Annual = item.ItemArray[258].ToString();
                string OtherChildren_Totallastyear = item.ItemArray[259].ToString();

                string Total_Fortnight = item.ItemArray[260].ToString();
                string Total_Month = item.ItemArray[261].ToString();
                string Total_Quarter = item.ItemArray[262].ToString();
                string Total_Halfyear = item.ItemArray[263].ToString();
                string Total_Annual = item.ItemArray[264].ToString();
                string Total_Totallastyear = item.ItemArray[265].ToString();


                list.Add(new SelectionBFinancialSummary()
                {



                    ID = ID,
                    CoverPageID = CoverPageID,
                    //Employment Details			
                    Workstatus_Client1 = Workstatus_Client1,
                    Workstatus_Client2 = Workstatus_Client2,
                    Employer_Client1 = Employer_Client1,
                    Employer_Client2 = Employer_Client2,
                    Employeraddress_Client1 = Employeraddress_Client1,
                    Employeraddress_Client2 = Employeraddress_Client2,
                    Occupation_Client1 = Occupation_Client1,
                    Occupation_Client2 = Occupation_Client2,
                    Numberofyearsservice_Client1 = Numberofyearsservice_Client1,
                    Numberofyearsservice_Client2 = Numberofyearsservice_Client2,
                    IntendedRetirementdate_Client1 = IntendedRetirementdate_Client1,
                    IntendedRetirementdate_Client2 = IntendedRetirementdate_Client2,
                    Doyouexpectemployment_Client1 = Doyouexpectemployment_Client1,
                    Doyouexpectemployment_Client2 = Doyouexpectemployment_Client2,
                    //Salary & Other Income	
                    Salaryincome_Client1 = Salaryincome_Client1,
                    Salaryincome_Client2 = Salaryincome_Client2,
                    Othertaxableincome_Client1 = Othertaxableincome_Client1,
                    Othertaxableincome_Client2 = Othertaxableincome_Client2,
                    Taxfreeincome_Client1 = Taxfreeincome_Client1,
                    Taxfreeincome_Client2 = Taxfreeincome_Client2,
                    Familyallowance_Client1 = Familyallowance_Client1,
                    Familyallowance_Client2 = Familyallowance_Client2,
                    Directorsfeesgratuities_Client1 = Directorsfeesgratuities_Client1,
                    Directorsfeesgratuities_Client2 = Directorsfeesgratuities_Client2,
                    Areyouexpectingfunds1_Client1 = Areyouexpectingfunds1_Client1,
                    Areyouexpectingfunds1_Client2 = Areyouexpectingfunds1_Client2,
                    Areyouexpectingfunds2_Client1 = Areyouexpectingfunds2_Client1,
                    Areyouexpectingfunds2_Client2 = Areyouexpectingfunds2_Client2,
                    Areyouexpectingfunds3_Client1 = Areyouexpectingfunds3_Client1,
                    Areyouexpectingfunds3_Client2 = Areyouexpectingfunds3_Client2,
                    Other1_Client1 = Other1_Client1,
                    Other1_Client2 = Other1_Client2,
                    Other2_Client1 = Other2_Client1,
                    Other2_Client2 = Other2_Client2,
                    Other3_Client1 = Other3_Client1,
                    Other3_Client2 = Other3_Client2,
                    //Salary Sacrifice / Package	
                    Employmentsuper_Client1 = Employmentsuper_Client1,
                    Employmentsuper_Client2 = Employmentsuper_Client2,
                    Salarysacrificetosuper_Client1 = Salarysacrificetosuper_Client1,
                    Salarysacrificetosuper_Client2 = Salarysacrificetosuper_Client2,
                    Packagedmotorvehicle_Client1 = Packagedmotorvehicle_Client1,
                    Packagedmotorvehicle_Client2 = Packagedmotorvehicle_Client2,
                    Bonus_Client1 = Bonus_Client1,
                    Bonus_Client2 = Bonus_Client2,
                    Other_Client1 = Other_Client1,
                    Other_Client2 = Other_Client2,
                    //Centrelink			
                    Entitlementamount_Client1 = Entitlementamount_Client1,
                    Entitlementamount_Client2 = Entitlementamount_Client2,
                    Entitlementtype_Client1 = Entitlementtype_Client1,
                    Entitlementtype_Client2 = Entitlementtype_Client2,
                    CentrelinkreferencenoCRN_Client1 = CentrelinkreferencenoCRN_Client1,
                    CentrelinkreferencenoCRN_Client2 = CentrelinkreferencenoCRN_Client2,
                    Maintenanceincome_Client1 = Maintenanceincome_Client1,
                    Maintenanceincome_Client2 = Maintenanceincome_Client2,
                    Maintenancepayment_Client1 = Maintenancepayment_Client1,
                    Maintenancepayment_Client2 = Maintenancepayment_Client2,
                    Overseassocialsecurityincome_Client1 = Overseassocialsecurityincome_Client1,
                    Overseassocialsecurityincome_Client2 = Overseassocialsecurityincome_Client2,
                    //Centrelink - File Notes	
                    FileNotesCentrelink_FileName = FileNotesCentrelink_FileName,
                    FileNotesCentrelink_FilePath = FileNotesCentrelink_FilePath,
                    //Cost of living			
                    Foodliquids_Fortnight = Foodliquids_Fortnight,
                    Foodliquids_Month = Foodliquids_Month,
                    Foodliquids_Quarter = Foodliquids_Quarter,
                    Foodliquids_Halfyear = Foodliquids_Halfyear,
                    Foodliquids_Annual = Foodliquids_Annual,
                    Foodliquids_Totallastyear = Foodliquids_Totallastyear,

                    Alcohol_Fortnight = Alcohol_Fortnight,
                    Alcohol_Month = Alcohol_Month,
                    Alcohol_Quarter = Alcohol_Quarter,
                    Alcohol_Halfyear = Alcohol_Halfyear,
                    Alcohol_Annual = Alcohol_Annual,
                    Alcohol_Totallastyear = Alcohol_Totallastyear,

                    Tobacco_Fortnight = Tobacco_Fortnight,
                    Tobacco_Month = Tobacco_Month,
                    Tobacco_Quarter = Tobacco_Quarter,
                    Tobacco_Halfyear = Tobacco_Halfyear,
                    Tobacco_Annual = Tobacco_Annual,
                    Tobacco_Totallastyear = Tobacco_Totallastyear,

                    Clothingfootwear_Fortnight = Clothingfootwear_Fortnight,
                    Clothingfootwear_Month = Clothingfootwear_Month,
                    Clothingfootwear_Quarter = Clothingfootwear_Quarter,
                    Clothingfootwear_Halfyear = Clothingfootwear_Halfyear,
                    Clothingfootwear_Annual = Clothingfootwear_Annual,
                    Clothingfootwear_Totallastyear = Clothingfootwear_Totallastyear,

                    Medicalhealth_Fortnight = Medicalhealth_Fortnight,
                    Medicalhealth_Month = Medicalhealth_Month,
                    Medicalhealth_Quarter = Medicalhealth_Quarter,
                    Medicalhealth_Halfyear = Medicalhealth_Halfyear,
                    Medicalhealth_Annual = Medicalhealth_Annual,
                    Medicalhealth_Totallastyear = Medicalhealth_Totallastyear,

                    Recreation_Fortnight = Recreation_Fortnight,
                    Recreation_Month = Recreation_Month,
                    Recreation_Quarter = Recreation_Quarter,
                    Recreation_Halfyear = Recreation_Halfyear,
                    Recreation_Annual = Recreation_Annual,
                    Recreation_Totallastyear = Recreation_Totallastyear,

                    Personalcare_Fortnight = Personalcare_Fortnight,
                    Personalcare_Month = Personalcare_Month,
                    Personalcare_Quarter = Personalcare_Quarter,
                    Personalcare_Halfyear = Personalcare_Halfyear,
                    Personalcare_Annual = Personalcare_Annual,
                    Personalcare_Totallastyear = Personalcare_Totallastyear,

                    PhonePost_Fortnight = PhonePost_Fortnight,
                    PhonePost_Month = PhonePost_Month,
                    PhonePost_Quarter = PhonePost_Quarter,
                    PhonePost_Halfyear = PhonePost_Halfyear,
                    PhonePost_Annual = PhonePost_Annual,
                    PhonePost_Totallastyear = PhonePost_Totallastyear,

                    Travel_Fortnight = Travel_Fortnight,
                    Travel_Month = Travel_Month,
                    Travel_Quarter = Travel_Quarter,
                    Travel_Halfyear = Travel_Halfyear,
                    Travel_Annual = Travel_Annual,
                    Travel_Totallastyear = Travel_Totallastyear,

                    Gifts_Fortnight = Gifts_Fortnight,
                    Gifts_Month = Gifts_Month,
                    Gifts_Quarter = Gifts_Quarter,
                    Gifts_Halfyear = Gifts_Halfyear,
                    Gifts_Annual = Gifts_Annual,
                    Gifts_Totallastyear = Gifts_Totallastyear,

                    Other_Fortnight = Other_Fortnight,
                    Other_Month = Other_Month,
                    Other_Quarter = Other_Quarter,
                    Other_Halfyear = Other_Halfyear,
                    Other_Annual = Other_Annual,
                    Other_Totallastyear = Other_Totallastyear,

                    Ratesinsurance_Fortnight = Ratesinsurance_Fortnight,
                    Ratesinsurance_Month = Ratesinsurance_Month,
                    Ratesinsurance_Quarter = Ratesinsurance_Quarter,
                    Ratesinsurance_Halfyear = Ratesinsurance_Halfyear,
                    Ratesinsurance_Annual = Ratesinsurance_Annual,
                    Ratesinsurance_Totallastyear = Ratesinsurance_Totallastyear,

                    Repairsmaintenance_Fortnight = Repairsmaintenance_Fortnight,
                    Repairsmaintenance_Month = Repairsmaintenance_Month,
                    Repairsmaintenance_Quarter = Repairsmaintenance_Quarter,
                    Repairsmaintenance_Halfyear = Repairsmaintenance_Halfyear,
                    Repairsmaintenance_Annual = Repairsmaintenance_Annual,
                    Repairsmaintenance_Totallastyear = Repairsmaintenance_Totallastyear,

                    Electricitygas_Fortnight = Electricitygas_Fortnight,
                    Electricitygas_Month = Electricitygas_Month,
                    Electricitygas_Quarter = Electricitygas_Quarter,
                    Electricitygas_Halfyear = Electricitygas_Halfyear,
                    Electricitygas_Annual = Electricitygas_Annual,
                    Electricitygas_Totallastyear = Electricitygas_Totallastyear,

                    Houseloanprincipal_Fortnight = Houseloanprincipal_Fortnight,
                    Houseloanprincipal_Month = Houseloanprincipal_Month,
                    Houseloanprincipal_Quarter = Houseloanprincipal_Quarter,
                    Houseloanprincipal_Halfyear = Houseloanprincipal_Halfyear,
                    Houseloanprincipal_Annual = Houseloanprincipal_Annual,
                    Houseloanprincipal_Totallastyear = Houseloanprincipal_Totallastyear,

                    Rentmortgage_Fortnight = Rentmortgage_Fortnight,
                    Rentmortgage_Month = Rentmortgage_Month,
                    Rentmortgage_Quarter = Rentmortgage_Quarter,
                    Rentmortgage_Halfyear = Rentmortgage_Halfyear,
                    Rentmortgage_Annual = Rentmortgage_Annual,
                    Rentmortgage_Totallastyear = Rentmortgage_Totallastyear,

                    Extramortgagepayments_Fortnight = Extramortgagepayments_Fortnight,
                    Extramortgagepayments_Month = Extramortgagepayments_Month,
                    Extramortgagepayments_Quarter = Extramortgagepayments_Quarter,
                    Extramortgagepayments_Halfyear = Extramortgagepayments_Halfyear,
                    Extramortgagepayments_Annual = Extramortgagepayments_Annual,
                    Extramortgagepayments_Totallastyear = Extramortgagepayments_Totallastyear,

                    Furnishingequipment_Fortnight = Furnishingequipment_Fortnight,
                    Furnishingequipment_Month = Furnishingequipment_Month,
                    Furnishingequipment_Quarter = Furnishingequipment_Quarter,
                    Furnishingequipment_Halfyear = Furnishingequipment_Halfyear,
                    Furnishingequipment_Annual = Furnishingequipment_Annual,
                    Furnishingequipment_Totallastyear = Furnishingequipment_Totallastyear,

                    OtherHousing_Fortnight = OtherHousing_Fortnight,
                    OtherHousing_Month = OtherHousing_Month,
                    OtherHousing_Quarter = OtherHousing_Quarter,
                    OtherHousing_Halfyear = OtherHousing_Halfyear,
                    OtherHousing_Annual = OtherHousing_Annual,
                    OtherHousing_Totallastyear = OtherHousing_Totallastyear,

                    Registrationinsurance_Fortnight = Registrationinsurance_Fortnight,
                    Registrationinsurance_Month = Registrationinsurance_Month,
                    Registrationinsurance_Quarter = Registrationinsurance_Quarter,
                    Registrationinsurance_Halfyear = Registrationinsurance_Halfyear,
                    Registrationinsurance_Annual = Registrationinsurance_Annual,
                    Registrationinsurance_Totallastyear = Registrationinsurance_Totallastyear,

                    RepairsmaintenanceTransport_Fortnight = RepairsmaintenanceTransport_Fortnight,
                    RepairsmaintenanceTransport_Month = RepairsmaintenanceTransport_Month,
                    RepairsmaintenanceTransport_Quarter = RepairsmaintenanceTransport_Quarter,
                    RepairsmaintenanceTransport_Halfyear = RepairsmaintenanceTransport_Halfyear,
                    RepairsmaintenanceTransport_Annual = RepairsmaintenanceTransport_Annual,
                    RepairsmaintenanceTransport_Totallastyear = RepairsmaintenanceTransport_Totallastyear,

                    FuelOil_Fortnight = FuelOil_Fortnight,
                    FuelOil_Month = FuelOil_Month,
                    FuelOil_Quarter = FuelOil_Quarter,
                    FuelOil_Halfyear = FuelOil_Halfyear,
                    FuelOil_Annual = FuelOil_Annual,
                    FuelOil_Totallastyear = FuelOil_Totallastyear,

                    Replacementvehicle_Fortnight = Replacementvehicle_Fortnight,
                    Replacementvehicle_Month = Replacementvehicle_Month,
                    Replacementvehicle_Quarter = Replacementvehicle_Quarter,
                    Replacementvehicle_Halfyear = Replacementvehicle_Halfyear,
                    Replacementvehicle_Annual = Replacementvehicle_Annual,
                    Replacementvehicle_Totallastyear = Replacementvehicle_Totallastyear,

                    Fares_Fortnight = Fares_Fortnight,
                    Fares_Month = Fares_Month,
                    Fares_Quarter = Fares_Quarter,
                    Fares_Halfyear = Fares_Halfyear,
                    Fares_Annual = Fares_Annual,
                    Fares_Totallastyear = Fares_Totallastyear,

                    OtherTransport_Fortnight = OtherTransport_Fortnight,
                    OtherTransport_Month = OtherTransport_Month,
                    OtherTransport_Quarter = OtherTransport_Quarter,
                    OtherTransport_Halfyear = OtherTransport_Halfyear,
                    OtherTransport_Annual = OtherTransport_Annual,
                    OtherTransport_Totallastyear = OtherTransport_Totallastyear,

                    Superlifeinsurance_Fortnight = Superlifeinsurance_Fortnight,
                    Superlifeinsurance_Month = Superlifeinsurance_Month,
                    Superlifeinsurance_Quarter = Superlifeinsurance_Quarter,
                    Superlifeinsurance_Halfyear = Superlifeinsurance_Halfyear,
                    Superlifeinsurance_Annual = Superlifeinsurance_Annual,
                    Superlifeinsurance_Totallastyear = Superlifeinsurance_Totallastyear,

                    Loansavings_Fortnight = Loansavings_Fortnight,
                    Loansavings_Month = Loansavings_Month,
                    Loansavings_Quarter = Loansavings_Quarter,
                    Loansavings_Halfyear = Loansavings_Halfyear,
                    Loansavings_Annual = Loansavings_Annual,
                    Loansavings_Totallastyear = Loansavings_Totallastyear,

                    Carloan_Fortnight = Carloan_Fortnight,
                    Carloan_Month = Carloan_Month,
                    Carloan_Quarter = Carloan_Quarter,
                    Carloan_Halfyear = Carloan_Halfyear,
                    Carloan_Annual = Carloan_Annual,
                    Carloan_Totallastyear = Carloan_Totallastyear,

                    OtherGeneral_Fortnight = OtherGeneral_Fortnight,
                    OtherGeneral_Month = OtherGeneral_Month,
                    OtherGeneral_Quarter = OtherGeneral_Quarter,
                    OtherGeneral_Halfyear = OtherGeneral_Halfyear,
                    OtherGeneral_Annual = OtherGeneral_Annual,
                    OtherGeneral_Totallastyear = OtherGeneral_Totallastyear,

                    Foodliquid_Fortnight = Foodliquid_Fortnight,
                    Foodliquid_Month = Foodliquid_Month,
                    Foodliquid_Quarter = Foodliquid_Quarter,
                    Foodliquid_Halfyear = Foodliquid_Halfyear,
                    Foodliquid_Annual = Foodliquid_Annual,
                    Foodliquid_Totallastyear = Foodliquid_Totallastyear,

                    ClothingfootwearChildren_Fortnight = ClothingfootwearChildren_Fortnight,
                    ClothingfootwearChildren_Month = ClothingfootwearChildren_Month,
                    ClothingfootwearChildren_Quarter = ClothingfootwearChildren_Quarter,
                    ClothingfootwearChildren_Halfyear = ClothingfootwearChildren_Halfyear,
                    ClothingfootwearChildren_Annual = ClothingfootwearChildren_Annual,
                    ClothingfootwearChildren_Totallastyear = ClothingfootwearChildren_Totallastyear,

                    Education_Fortnight = Education_Fortnight,
                    Education_Month = Education_Month,
                    Education_Quarter = Education_Quarter,
                    Education_Halfyear = Education_Halfyear,
                    Education_Annual = Education_Annual,
                    Education_Totallastyear = Education_Totallastyear,

                    OtherChildren_Fortnight = OtherChildren_Fortnight,
                    OtherChildren_Month = OtherChildren_Month,
                    OtherChildren_Quarter = OtherChildren_Quarter,
                    OtherChildren_Halfyear = OtherChildren_Halfyear,
                    OtherChildren_Annual = OtherChildren_Annual,
                    OtherChildren_Totallastyear = OtherChildren_Totallastyear,
                    Total_Fortnight = Total_Fortnight,
                    Total_Month = Total_Month,
                    Total_Quarter = Total_Quarter,
                    Total_Halfyear = Total_Halfyear,
                    Total_Annual = Total_Annual,
                    Total_Totallastyear = Total_Totallastyear





                });

            }

            return list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            grdDatabase.ItemsSource = CreateList();
            grdDatabase2.ItemsSource = CreateList_SelectionAPersonalDetails();
            grdDatabase3.ItemsSource = CreateList_SelectionBFinancialSummary();
            databasepath.Text = "Database Path: " + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "").ToString() + "\\ticdb.db";
        }
    }
}
