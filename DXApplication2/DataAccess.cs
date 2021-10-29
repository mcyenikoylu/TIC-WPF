using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DXApplication2
{
    public class DataAccess
    {
        public static int _CoverPageID = 0;
        public static string dbname = "ticdb.db";
        public static string _PageViewerFilePath = "";

        public static string path = ""; 
        public static string dbpath = ""; 

        public static void AddDataCoverPage(
            string preparedFor,
            string yourAdviser,
            DateTime dateValue,
         //File Notes
         string fileNotes_FileName,
         string fileNotes_FilePath)
        {
            try
            {
                //string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbname);
                using (SqliteConnection db = new SqliteConnection($"Filename={dbname}"))
                {
                    db.Open();

                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO CoverPage (PreparedFor,YourAdviser,DateValue,FileNotes_FileName,FileNotes_FilePath) VALUES (@PreparedFor, @YourAdviser, @DateValue, @FileNotes_FileName, @FileNotes_FilePath);";
                    insertCommand.Parameters.AddWithValue("@PreparedFor", preparedFor);
                    insertCommand.Parameters.AddWithValue("@YourAdviser", yourAdviser);
                    insertCommand.Parameters.AddWithValue("@DateValue", Convert.ToDateTime(dateValue));
                    insertCommand.Parameters.AddWithValue("@FileNotes_FileName", fileNotes_FileName);
                    insertCommand.Parameters.AddWithValue("@FileNotes_FilePath", fileNotes_FilePath);

                    SqliteCommand cmd_id = new SqliteCommand();
                    cmd_id.Connection = db;
                    cmd_id.CommandText = "select last_insert_rowid() as ID from CoverPage";

                    insertCommand.ExecuteReader();

                    //_CoverPageID = -1;
                    object __CoverPageID = cmd_id.ExecuteScalar();
                    _CoverPageID = int.Parse(__CoverPageID.ToString());
                    fileNotes_FileName = "FileNotesCoverPage_" + _CoverPageID.ToString() + ".jpg";

                    SqliteCommand insertCommand2 = new SqliteCommand();
                    insertCommand2.Connection = db;
                    insertCommand2.CommandText = "UPDATE CoverPage SET FileNotes_FileName = @FileNotes_FileName WHERE ID = @ID";
                    insertCommand2.Parameters.AddWithValue("@ID", _CoverPageID);
                    insertCommand2.Parameters.AddWithValue("@FileNotes_FileName", fileNotes_FileName);
                    insertCommand2.ExecuteReader();

                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #region AddDataSelectionAPersonalDetails


        public static void AddDataSelectionAPersonalDetails(
         string SurnameMaidenName_Client1,
         string SurnameMaidenName_Client2,
         string Givennames_Client1,
         string Givennames_Client2,
         string Preferredshortname_Client1,
         string Preferredshortname_Client2,
         string TitleMrMrsMsSirDr_Client1,
         string TitleMrMrsMsSirDr_Client2,
         int Gender_Client1,
         int Gender_Client2,
         DateTime DateOfBirth_Client1,
         DateTime DateOfBirth_Client2,
         int Age_Client1,
         int Age_Client2,
         int Maritalstatus_Client1,
         int Maritalstatus_Client2,
         int Health_Client1,
         int Health_Client2,
         int Smoker_Client1,
         int Smoker_Client2,
         string TownOfBirth_Client1,
         string TownOfBirth_Client2,
         string CountryOfBirth_Client1,
         string CountryOfBirth_Client2,
         string IfnotAustraliayearsinAustralia_Client1,
         string IfnotAustraliayearsinAustralia_Client2,
         string Areyouanonresident_Client1,
         string Areyouanonresident_Client2,
         string Taxfilenumber_Client1,
         string Taxfilenumber_Client2,
         string Wereyoureferredtous_Client1,
         string Wereyoureferredtous_Client2,
         string Haveyouworkedwithanotheradviser_Client1,
         string Haveyouworkedwithanotheradviser_Client2,
         string Areyouaresidentofanothercountryfortaxpurposes_Client1,
         string Areyouaresidentofanothercountryfortaxpurposes_Client2,
         string Ifyescountryofresidence_Client1,
         string Ifyescountryofresidence_Client2,
         string TaxidentificationnumberTINofforeigncountry_Client1,
         string TaxidentificationnumberTINofforeigncountry_Client2,
         string Areyouapoliticallyexposedperson_Client1,
         string Areyouapoliticallyexposedperson_Client2,
        //Contact Details
         string Addresspostal_Client1,
         string Addresspostal_Client2,
         string Addresspostal2_Client1,
         string Addresspostal2_Client2,
         string AddresspostalState_Client1,
         string AddresspostalState_Client2,
         string AddresspostalPostcode_Client1,
         string AddresspostalPostcode_Client2,
         string Addressresidentialother_Client1,
         string Addressresidentialother_Client2,
         string AddressresidentialotherState_Client1,
         string AddressresidentialotherState_Client2,
         string AddressresidentialotherPostcode_Client1,
         string AddressresidentialotherPostcode_Client2,
         string Emailaddress_Client1,
         string Emailaddress_Client2,
         string Contactnumbersmainnumber_Client1,
         string Contactnumbersmainnumber_Client2,
         string Officephone_Client1,
         string Officephone_Client2,
         string Mobile_Client1,
         string Mobile_Client2,
         string Fax_Client1,
         string Fax_Client2,
        //Dependants
         string SurnameName_Dependant1,
         string SurnameName_Dependant2,
         string SurnameName_Dependant3,
         string GivenNames_Dependant1,
         string GivenNames_Dependant2,
         string GivenNames_Dependant3,
         string PreferredShortName_Dependant1,
         string PreferredShortName_Dependant2,
         string PreferredShortName_Dependant3,
         string Title_Dependant1,
         string Title_Dependant2,
         string Title_Dependant3,
         int GenderMale_Dependant1,
         int GenderMale_Dependant2,
         int GenderMale_Dependant3,
         DateTime DateOfBirth_Dependant1,
         DateTime DateOfBirth_Dependant2,
         DateTime DateOfBirth_Dependant3,
         int Age_Dependant1,
         int Age_Dependant2,
         int Age_Dependant3,
         string Relationship_Dependant1,
         string Relationship_Dependant2,
         string Relationship_Dependant3,
         int SpecialNeeds_Dependant1,
         int SpecialNeeds_Dependant2,
         int SpecialNeeds_Dependant3,
         string Details_Dependant1,
         string Details_Dependant2,
         string Details_Dependant3,
         string Details2_Dependant1,
         string Details2_Dependant2,
         string Details2_Dependant3,
         string Details3_Dependant1,
         string Details3_Dependant2,
         string Details3_Dependant3,
         string Supporttoage_Dependant1,
         string Supporttoage_Dependant2,
         string Supporttoage_Dependant3,
         string SchoolName_Dependant1,
         string SchoolName_Dependant2,
         string SchoolName_Dependant3,
         string SchoolYearLevel_Dependant1,
         string SchoolYearLevel_Dependant2,
         string SchoolYearLevel_Dependant3,
         string EstimatedCostofSchooling_Dependant1,
         string EstimatedCostofSchooling_Dependant2,
         string EstimatedCostofSchooling_Dependant3,
         int AustudyStatus_Dependant1,
         int AustudyStatus_Dependant2,
         int AustudyStatus_Dependant3,
         string ClientsParents,
         string FileNotesClientsParents_FileName,
         string FileNotesClientsParents_FilePath,
         string EgCollectablesGolfTennis_Client1,
         string EgCollectablesGolfTennis_Client2,
         string EgCollectablesGolfTennis2_Client1,
         string EgCollectablesGolfTennis2_Client2,
         string EgCollectablesGolfTennis3_Client1,
         string EgCollectablesGolfTennis3_Client2,
        //Business Advisers
         string Businessname_Accountant,
         string Businessname_Banker,
         string Businessname_Lawyer,
         string Contactname_Accountant,
         string Contactname_Banker,
         string Contactname_Lawyer,
         string Postaladdress_Accountant,
         string Postaladdress_Banker,
         string Postaladdress_Lawyer,
         string Postaladdress2_Accountant,
         string Postaladdress2_Banker,
         string Postaladdress2_Lawyer,
         string PostaladdressState_Accountant,
         string PostaladdressState_Banker,
         string PostaladdressState_Lawyer,
         string PostaladdressPostcode_Accountant,
         string PostaladdressPostcode_Banker,
         string PostaladdressPostcode_Lawyer,
         string Emailaddress_Accountant,
         string Emailaddress_Banker,
         string Emailaddress_Lawyer,
         string Phoneaddress_Accountant,
         string Phoneaddress_Banker,
         string Phoneaddress_Lawyer,
         string Faxnumber_Accountant,
         string Faxnumber_Banker,
         string Faxnumber_Lawyer,
        //File Notes
         string FileNotes_FileName,
         string FileNotes_FilePath
            )
        {
            
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbname}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO SelectionAPersonalDetails (   CoverPageID ," +
"	SurnameMaidenName_Client1	," +
"	SurnameMaidenName_Client2	," +
"	Givennames_Client1	," +
"	Givennames_Client2	," +
"	Preferredshortname_Client1	," +
"	Preferredshortname_Client2	," +
"	TitleMrMrsMsSirDr_Client1	," +
"	TitleMrMrsMsSirDr_Client2	," +
"	Gender_Client1	," +
"	Gender_Client2	," +
"	DateOfBirth_Client1 	," +
"	DateOfBirth_Client2	," +
"	Age_Client1	," +
"	Age_Client2	," +
"	Maritalstatus_Client1	," +
"	Maritalstatus_Client2	," +
"	Health_Client1	," +
"	Health_Client2	," +
"	Smoker_Client1	," +
"	Smoker_Client2	," +
"	TownOfBirth_Client1	," +
"	TownOfBirth_Client2	," +
"	CountryOfBirth_Client1	," +
"	CountryOfBirth_Client2	," +
"	IfnotAustraliayearsinAustralia_Client1	," +
"	IfnotAustraliayearsinAustralia_Client2	," +
"	Areyouanonresident_Client1	," +
"	Areyouanonresident_Client2	," +
"	Taxfilenumber_Client1	," +
"	Taxfilenumber_Client2	," +
"	Wereyoureferredtous_Client1	," +
"	Wereyoureferredtous_Client2	," +
"	Haveyouworkedwithanotheradviser_Client1	," +
"	Haveyouworkedwithanotheradviser_Client2	," +
"	Areyouaresidentofanothercountryfortaxpurposes_Client1	," +
"	Areyouaresidentofanothercountryfortaxpurposes_Client2	," +
"	Ifyescountryofresidence_Client1	," +
"	Ifyescountryofresidence_Client2	," +
"	TaxidentificationnumberTINofforeigncountry_Client1	," +
"	TaxidentificationnumberTINofforeigncountry_Client2	," +
"	Areyouapoliticallyexposedperson_Client1	," +
"	Areyouapoliticallyexposedperson_Client2	," +
"	Addresspostal_Client1	," +
"	Addresspostal_Client2	," +
"	Addresspostal2_Client1	," +
"	Addresspostal2_Client2	," +
"	AddresspostalState_Client1	," +
"	AddresspostalState_Client2	," +
"	AddresspostalPostcode_Client1	," +
"	AddresspostalPostcode_Client2	," +
"	Addressresidentialother_Client1	," +
"	Addressresidentialother_Client2	," +
"	AddressresidentialotherState_Client1	," +
"	AddressresidentialotherState_Client2	," +
"	AddressresidentialotherPostcode_Client1	," +
"	AddressresidentialotherPostcode_Client2	," +
"	Emailaddress_Client1	," +
"	Emailaddress_Client2	," +
"	Contactnumbersmainnumber_Client1	," +
"	Contactnumbersmainnumber_Client2	," +
"	Officephone_Client1	," +
"	Officephone_Client2	," +
"	Mobile_Client1	," +
"	Mobile_Client2	," +
"	Fax_Client1	," +
"	Fax_Client2	," +
"	SurnameName_Dependant1	," +
"	SurnameName_Dependant2	," +
"	SurnameName_Dependant3	," +
"	GivenNames_Dependant1	," +
"	GivenNames_Dependant2	," +
"	GivenNames_Dependant3	," +
"	PreferredShortName_Dependant1	," +
"	PreferredShortName_Dependant2	," +
"	PreferredShortName_Dependant3	," +
"	Title_Dependant1	," +
"	Title_Dependant2	," +
"	Title_Dependant3	," +
"	GenderMale_Dependant1	," +
"	GenderMale_Dependant2	," +
"	GenderMale_Dependant3	," +
"	DateOfBirth_Dependant1 	," +
"	DateOfBirth_Dependant2	," +
"	DateOfBirth_Dependant3 	," +
"	Age_Dependant1	," +
"	Age_Dependant2	," +
"	Age_Dependant3	," +
"	Relationship_Dependant1	," +
"	Relationship_Dependant2	," +
"	Relationship_Dependant3	," +
"	SpecialNeeds_Dependant1	," +
"	SpecialNeeds_Dependant2	," +
"	SpecialNeeds_Dependant3	," +
"	Details_Dependant1	," +
"	Details_Dependant2	," +
"	Details_Dependant3	," +
"	Details2_Dependant1	," +
"	Details2_Dependant2	," +
"	Details2_Dependant3	," +
"	Details3_Dependant1	," +
"	Details3_Dependant2	," +
"	Details3_Dependant3	," +
"	Supporttoage_Dependant1	," +
"	Supporttoage_Dependant2	," +
"	Supporttoage_Dependant3	," +
"	SchoolName_Dependant1	," +
"	SchoolName_Dependant2	," +
"	SchoolName_Dependant3	," +
"	SchoolYearLevel_Dependant1	," +
"	SchoolYearLevel_Dependant2	," +
"	SchoolYearLevel_Dependant3	," +
"	EstimatedCostofSchooling_Dependant1	," +
"	EstimatedCostofSchooling_Dependant2	," +
"	EstimatedCostofSchooling_Dependant3	," +
"	AustudyStatus_Dependant1	," +
"	AustudyStatus_Dependant2	," +
"	AustudyStatus_Dependant3	," +
"	ClientsParents	," +
"	FileNotesClientsParents_FileName	," +
"	FileNotesClientsParents_FilePath	," +
"	EgCollectablesGolfTennis_Client1	," +
"	EgCollectablesGolfTennis_Client2	," +
"	EgCollectablesGolfTennis2_Client1	," +
"	EgCollectablesGolfTennis2_Client2	," +
"	EgCollectablesGolfTennis3_Client1	," +
"	EgCollectablesGolfTennis3_Client2	," +
"	Businessname_Accountant	," +
"	Businessname_Banker	," +
"	Businessname_Lawyer	," +
"	Contactname_Accountant	," +
"	Contactname_Banker	," +
"	Contactname_Lawyer	," +
"	Postaladdress_Accountant	," +
"	Postaladdress_Banker	," +
"	Postaladdress_Lawyer	," +
"	Postaladdress2_Accountant	," +
"	Postaladdress2_Banker	," +
"	Postaladdress2_Lawyer	," +
"	PostaladdressState_Accountant	," +
"	PostaladdressState_Banker	," +
"	PostaladdressState_Lawyer	," +
"	PostaladdressPostcode_Accountant	," +
"	PostaladdressPostcode_Banker	," +
"	PostaladdressPostcode_Lawyer	," +
"	Emailaddress_Accountant	," +
"	Emailaddress_Banker	," +
"	Emailaddress_Lawyer	," +
"	Phoneaddress_Accountant	," +
"	Phoneaddress_Banker	," +
"	Phoneaddress_Lawyer	," +
"	Faxnumber_Accountant	," +
"	Faxnumber_Banker	," +
"	Faxnumber_Lawyer	," +
"	FileNotes_FileName	," +
"	FileNotes_FilePath	" +

") VALUES (" +
    "@CoverPageID	," +
"@SurnameMaidenName_Client1	," +
"@SurnameMaidenName_Client2	," +
"@Givennames_Client1	," +
"@Givennames_Client2	," +
"@Preferredshortname_Client1	," +
"@Preferredshortname_Client2	," +
"@TitleMrMrsMsSirDr_Client1	," +
"@TitleMrMrsMsSirDr_Client2	," +
"@Gender_Client1	," +
"@Gender_Client2	," +
"@DateOfBirth_Client1 	," +
"@DateOfBirth_Client2	," +
"@Age_Client1	," +
"@Age_Client2	," +
"@Maritalstatus_Client1	," +
"@Maritalstatus_Client2	," +
"@Health_Client1	," +
"@Health_Client2	," +
"@Smoker_Client1	," +
"@Smoker_Client2	," +
"@TownOfBirth_Client1	," +
"@TownOfBirth_Client2	," +
"@CountryOfBirth_Client1	," +
"@CountryOfBirth_Client2	," +
"@IfnotAustraliayearsinAustralia_Client1	," +
"@IfnotAustraliayearsinAustralia_Client2	," +
"@Areyouanonresident_Client1	," +
"@Areyouanonresident_Client2	," +
"@Taxfilenumber_Client1	," +
"@Taxfilenumber_Client2	," +
"@Wereyoureferredtous_Client1	," +
"@Wereyoureferredtous_Client2	," +
"@Haveyouworkedwithanotheradviser_Client1	," +
"@Haveyouworkedwithanotheradviser_Client2	," +
"@Areyouaresidentofanothercountryfortaxpurposes_Client1	," +
"@Areyouaresidentofanothercountryfortaxpurposes_Client2	," +
"@Ifyescountryofresidence_Client1	," +
"@Ifyescountryofresidence_Client2	," +
"@TaxidentificationnumberTINofforeigncountry_Client1	," +
"@TaxidentificationnumberTINofforeigncountry_Client2	," +
"@Areyouapoliticallyexposedperson_Client1	," +
"@Areyouapoliticallyexposedperson_Client2	," +
"@Addresspostal_Client1	," +
"@Addresspostal_Client2	," +
"@Addresspostal2_Client1	," +
"@Addresspostal2_Client2	," +
"@AddresspostalState_Client1	," +
"@AddresspostalState_Client2	," +
"@AddresspostalPostcode_Client1	," +
"@AddresspostalPostcode_Client2	," +
"@Addressresidentialother_Client1	," +
"@Addressresidentialother_Client2	," +
"@AddressresidentialotherState_Client1	," +
"@AddressresidentialotherState_Client2	," +
"@AddressresidentialotherPostcode_Client1	," +
"@AddressresidentialotherPostcode_Client2	," +
"@Emailaddress_Client1	," +
"@Emailaddress_Client2	," +
"@Contactnumbersmainnumber_Client1	," +
"@Contactnumbersmainnumber_Client2	," +
"@Officephone_Client1	," +
"@Officephone_Client2	," +
"@Mobile_Client1	," +
"@Mobile_Client2	," +
"@Fax_Client1	," +
"@Fax_Client2	," +
"@SurnameName_Dependant1	," +
"@SurnameName_Dependant2	," +
"@SurnameName_Dependant3	," +
"@GivenNames_Dependant1	," +
"@GivenNames_Dependant2	," +
"@GivenNames_Dependant3	," +
"@PreferredShortName_Dependant1	," +
"@PreferredShortName_Dependant2	," +
"@PreferredShortName_Dependant3	," +
"@Title_Dependant1	," +
"@Title_Dependant2	," +
"@Title_Dependant3	," +
"@GenderMale_Dependant1	," +
"@GenderMale_Dependant2	," +
"@GenderMale_Dependant3	," +
"@DateOfBirth_Dependant1 	," +
"@DateOfBirth_Dependant2	," +
"@DateOfBirth_Dependant3 	," +
"@Age_Dependant1	," +
"@Age_Dependant2	," +
"@Age_Dependant3	," +
"@Relationship_Dependant1	," +
"@Relationship_Dependant2	," +
"@Relationship_Dependant3	," +
"@SpecialNeeds_Dependant1	," +
"@SpecialNeeds_Dependant2	," +
"@SpecialNeeds_Dependant3	," +
"@Details_Dependant1	," +
"@Details_Dependant2	," +
"@Details_Dependant3	," +
"@Details2_Dependant1	," +
"@Details2_Dependant2	," +
"@Details2_Dependant3	," +
"@Details3_Dependant1	," +
"@Details3_Dependant2	," +
"@Details3_Dependant3	," +
"@Supporttoage_Dependant1	," +
"@Supporttoage_Dependant2	," +
"@Supporttoage_Dependant3	," +
"@SchoolName_Dependant1	," +
"@SchoolName_Dependant2	," +
"@SchoolName_Dependant3	," +
"@SchoolYearLevel_Dependant1	," +
"@SchoolYearLevel_Dependant2	," +
"@SchoolYearLevel_Dependant3	," +
"@EstimatedCostofSchooling_Dependant1	," +
"@EstimatedCostofSchooling_Dependant2	," +
"@EstimatedCostofSchooling_Dependant3	," +
"@AustudyStatus_Dependant1	," +
"@AustudyStatus_Dependant2	," +
"@AustudyStatus_Dependant3	," +
"@ClientsParents	," +
"@FileNotesClientsParents_FileName	," +
"@FileNotesClientsParents_FilePath	," +
"@EgCollectablesGolfTennis_Client1	," +
"@EgCollectablesGolfTennis_Client2	," +
"@EgCollectablesGolfTennis2_Client1	," +
"@EgCollectablesGolfTennis2_Client2	," +
"@EgCollectablesGolfTennis3_Client1	," +
"@EgCollectablesGolfTennis3_Client2	," +
"@Businessname_Accountant	," +
"@Businessname_Banker	," +
"@Businessname_Lawyer	," +
"@Contactname_Accountant	," +
"@Contactname_Banker	," +
"@Contactname_Lawyer	," +
"@Postaladdress_Accountant	," +
"@Postaladdress_Banker	," +
"@Postaladdress_Lawyer	," +
"@Postaladdress2_Accountant	," +
"@Postaladdress2_Banker	," +
"@Postaladdress2_Lawyer	," +
"@PostaladdressState_Accountant	," +
"@PostaladdressState_Banker	," +
"@PostaladdressState_Lawyer	," +
"@PostaladdressPostcode_Accountant	," +
"@PostaladdressPostcode_Banker	," +
"@PostaladdressPostcode_Lawyer	," +
"@Emailaddress_Accountant	," +
"@Emailaddress_Banker	," +
"@Emailaddress_Lawyer	," +
"@Phoneaddress_Accountant	," +
"@Phoneaddress_Banker	," +
"@Phoneaddress_Lawyer	," +
"@Faxnumber_Accountant	," +
"@Faxnumber_Banker	," +
"@Faxnumber_Lawyer	," +
"@FileNotes_FileName	," +
"@FileNotes_FilePath	" +

    ");";

                insertCommand.Parameters.AddWithValue("@CoverPageID", _CoverPageID);
                insertCommand.Parameters.AddWithValue("@SurnameMaidenName_Client1", SurnameMaidenName_Client1);
                insertCommand.Parameters.AddWithValue("@SurnameMaidenName_Client2", SurnameMaidenName_Client2);
                insertCommand.Parameters.AddWithValue("@Givennames_Client1", Givennames_Client1);
                insertCommand.Parameters.AddWithValue("@Givennames_Client2", Givennames_Client2);
                insertCommand.Parameters.AddWithValue("@Preferredshortname_Client1", Preferredshortname_Client1);
                insertCommand.Parameters.AddWithValue("@Preferredshortname_Client2", Preferredshortname_Client2);
                insertCommand.Parameters.AddWithValue("@TitleMrMrsMsSirDr_Client1", TitleMrMrsMsSirDr_Client1);
                insertCommand.Parameters.AddWithValue("@TitleMrMrsMsSirDr_Client2", TitleMrMrsMsSirDr_Client2);
                insertCommand.Parameters.AddWithValue("@Gender_Client1", Gender_Client1);
                insertCommand.Parameters.AddWithValue("@Gender_Client2", Gender_Client2);
                insertCommand.Parameters.AddWithValue("@DateOfBirth_Client1", DateOfBirth_Client1);
                insertCommand.Parameters.AddWithValue("@DateOfBirth_Client2", DateOfBirth_Client2);
                insertCommand.Parameters.AddWithValue("@Age_Client1", Age_Client1);
                insertCommand.Parameters.AddWithValue("@Age_Client2", Age_Client2);
                insertCommand.Parameters.AddWithValue("@Maritalstatus_Client1", Maritalstatus_Client1);
                insertCommand.Parameters.AddWithValue("@Maritalstatus_Client2", Maritalstatus_Client2);
                insertCommand.Parameters.AddWithValue("@Health_Client1", Health_Client1);
                insertCommand.Parameters.AddWithValue("@Health_Client2", Health_Client2);
                insertCommand.Parameters.AddWithValue("@Smoker_Client1", Smoker_Client1);
                insertCommand.Parameters.AddWithValue("@Smoker_Client2", Smoker_Client2);
                insertCommand.Parameters.AddWithValue("@TownOfBirth_Client1", TownOfBirth_Client1);
                insertCommand.Parameters.AddWithValue("@TownOfBirth_Client2", TownOfBirth_Client2);
                insertCommand.Parameters.AddWithValue("@CountryOfBirth_Client1", CountryOfBirth_Client1);
                insertCommand.Parameters.AddWithValue("@CountryOfBirth_Client2", CountryOfBirth_Client2);
                insertCommand.Parameters.AddWithValue("@IfnotAustraliayearsinAustralia_Client1", IfnotAustraliayearsinAustralia_Client1);
                insertCommand.Parameters.AddWithValue("@IfnotAustraliayearsinAustralia_Client2", IfnotAustraliayearsinAustralia_Client2);
                insertCommand.Parameters.AddWithValue("@Areyouanonresident_Client1", Areyouanonresident_Client1);
                insertCommand.Parameters.AddWithValue("@Areyouanonresident_Client2", Areyouanonresident_Client2);
                insertCommand.Parameters.AddWithValue("@Taxfilenumber_Client1", Taxfilenumber_Client1);
                insertCommand.Parameters.AddWithValue("@Taxfilenumber_Client2", Taxfilenumber_Client2);
                insertCommand.Parameters.AddWithValue("@Wereyoureferredtous_Client1", Wereyoureferredtous_Client1);
                insertCommand.Parameters.AddWithValue("@Wereyoureferredtous_Client2", Wereyoureferredtous_Client2);
                insertCommand.Parameters.AddWithValue("@Haveyouworkedwithanotheradviser_Client1", Haveyouworkedwithanotheradviser_Client1);
                insertCommand.Parameters.AddWithValue("@Haveyouworkedwithanotheradviser_Client2", Haveyouworkedwithanotheradviser_Client2);
                insertCommand.Parameters.AddWithValue("@Areyouaresidentofanothercountryfortaxpurposes_Client1", Areyouaresidentofanothercountryfortaxpurposes_Client1);
                insertCommand.Parameters.AddWithValue("@Areyouaresidentofanothercountryfortaxpurposes_Client2", Areyouaresidentofanothercountryfortaxpurposes_Client2);
                insertCommand.Parameters.AddWithValue("@Ifyescountryofresidence_Client1", Ifyescountryofresidence_Client1);
                insertCommand.Parameters.AddWithValue("@Ifyescountryofresidence_Client2", Ifyescountryofresidence_Client2);
                insertCommand.Parameters.AddWithValue("@TaxidentificationnumberTINofforeigncountry_Client1", TaxidentificationnumberTINofforeigncountry_Client1);
                insertCommand.Parameters.AddWithValue("@TaxidentificationnumberTINofforeigncountry_Client2", TaxidentificationnumberTINofforeigncountry_Client2);
                insertCommand.Parameters.AddWithValue("@Areyouapoliticallyexposedperson_Client1", Areyouapoliticallyexposedperson_Client1);
                insertCommand.Parameters.AddWithValue("@Areyouapoliticallyexposedperson_Client2", Areyouapoliticallyexposedperson_Client2);
                insertCommand.Parameters.AddWithValue("@Addresspostal_Client1", Addresspostal_Client1);
                insertCommand.Parameters.AddWithValue("@Addresspostal_Client2", Addresspostal_Client2);
                insertCommand.Parameters.AddWithValue("@Addresspostal2_Client1", Addresspostal2_Client1);
                insertCommand.Parameters.AddWithValue("@Addresspostal2_Client2", Addresspostal2_Client2);
                insertCommand.Parameters.AddWithValue("@AddresspostalState_Client1", AddresspostalState_Client1);
                insertCommand.Parameters.AddWithValue("@AddresspostalState_Client2", AddresspostalState_Client2);
                insertCommand.Parameters.AddWithValue("@AddresspostalPostcode_Client1", AddresspostalPostcode_Client1);
                insertCommand.Parameters.AddWithValue("@AddresspostalPostcode_Client2", AddresspostalPostcode_Client2);
                insertCommand.Parameters.AddWithValue("@Addressresidentialother_Client1", Addressresidentialother_Client1);
                insertCommand.Parameters.AddWithValue("@Addressresidentialother_Client2", Addressresidentialother_Client2);
                insertCommand.Parameters.AddWithValue("@AddressresidentialotherState_Client1", AddressresidentialotherState_Client1);
                insertCommand.Parameters.AddWithValue("@AddressresidentialotherState_Client2", AddressresidentialotherState_Client2);
                insertCommand.Parameters.AddWithValue("@AddressresidentialotherPostcode_Client1", AddressresidentialotherPostcode_Client1);
                insertCommand.Parameters.AddWithValue("@AddressresidentialotherPostcode_Client2", AddressresidentialotherPostcode_Client2);
                insertCommand.Parameters.AddWithValue("@Emailaddress_Client1", Emailaddress_Client1);
                insertCommand.Parameters.AddWithValue("@Emailaddress_Client2", Emailaddress_Client2);
                insertCommand.Parameters.AddWithValue("@Contactnumbersmainnumber_Client1", Contactnumbersmainnumber_Client1);
                insertCommand.Parameters.AddWithValue("@Contactnumbersmainnumber_Client2", Contactnumbersmainnumber_Client2);
                insertCommand.Parameters.AddWithValue("@Officephone_Client1", Officephone_Client1);
                insertCommand.Parameters.AddWithValue("@Officephone_Client2", Officephone_Client2);
                insertCommand.Parameters.AddWithValue("@Mobile_Client1", Mobile_Client1);
                insertCommand.Parameters.AddWithValue("@Mobile_Client2", Mobile_Client2);
                insertCommand.Parameters.AddWithValue("@Fax_Client1", Fax_Client1);
                insertCommand.Parameters.AddWithValue("@Fax_Client2", Fax_Client2);
                insertCommand.Parameters.AddWithValue("@SurnameName_Dependant1", SurnameName_Dependant1);
                insertCommand.Parameters.AddWithValue("@SurnameName_Dependant2", SurnameName_Dependant2);
                insertCommand.Parameters.AddWithValue("@SurnameName_Dependant3", SurnameName_Dependant3);
                insertCommand.Parameters.AddWithValue("@GivenNames_Dependant1", GivenNames_Dependant1);
                insertCommand.Parameters.AddWithValue("@GivenNames_Dependant2", GivenNames_Dependant2);
                insertCommand.Parameters.AddWithValue("@GivenNames_Dependant3", GivenNames_Dependant3);
                insertCommand.Parameters.AddWithValue("@PreferredShortName_Dependant1", PreferredShortName_Dependant1);
                insertCommand.Parameters.AddWithValue("@PreferredShortName_Dependant2", PreferredShortName_Dependant2);
                insertCommand.Parameters.AddWithValue("@PreferredShortName_Dependant3", PreferredShortName_Dependant3);
                insertCommand.Parameters.AddWithValue("@Title_Dependant1", Title_Dependant1);
                insertCommand.Parameters.AddWithValue("@Title_Dependant2", Title_Dependant2);
                insertCommand.Parameters.AddWithValue("@Title_Dependant3", Title_Dependant3);
                insertCommand.Parameters.AddWithValue("@GenderMale_Dependant1", GenderMale_Dependant1);
                insertCommand.Parameters.AddWithValue("@GenderMale_Dependant2", GenderMale_Dependant2);
                insertCommand.Parameters.AddWithValue("@GenderMale_Dependant3", GenderMale_Dependant3);
                insertCommand.Parameters.AddWithValue("@DateOfBirth_Dependant1", DateOfBirth_Dependant1);
                insertCommand.Parameters.AddWithValue("@DateOfBirth_Dependant2", DateOfBirth_Dependant2);
                insertCommand.Parameters.AddWithValue("@DateOfBirth_Dependant3", DateOfBirth_Dependant3);
                insertCommand.Parameters.AddWithValue("@Age_Dependant1", Age_Dependant1);
                insertCommand.Parameters.AddWithValue("@Age_Dependant2", Age_Dependant2);
                insertCommand.Parameters.AddWithValue("@Age_Dependant3", Age_Dependant3);
                insertCommand.Parameters.AddWithValue("@Relationship_Dependant1", Relationship_Dependant1);
                insertCommand.Parameters.AddWithValue("@Relationship_Dependant2", Relationship_Dependant2);
                insertCommand.Parameters.AddWithValue("@Relationship_Dependant3", Relationship_Dependant3);
                insertCommand.Parameters.AddWithValue("@SpecialNeeds_Dependant1", SpecialNeeds_Dependant1);
                insertCommand.Parameters.AddWithValue("@SpecialNeeds_Dependant2", SpecialNeeds_Dependant2);
                insertCommand.Parameters.AddWithValue("@SpecialNeeds_Dependant3", SpecialNeeds_Dependant3);
                insertCommand.Parameters.AddWithValue("@Details_Dependant1", Details_Dependant1);
                insertCommand.Parameters.AddWithValue("@Details_Dependant2", Details_Dependant2);
                insertCommand.Parameters.AddWithValue("@Details_Dependant3", Details_Dependant3);
                insertCommand.Parameters.AddWithValue("@Details2_Dependant1", Details2_Dependant1);
                insertCommand.Parameters.AddWithValue("@Details2_Dependant2", Details2_Dependant2);
                insertCommand.Parameters.AddWithValue("@Details2_Dependant3", Details2_Dependant3);
                insertCommand.Parameters.AddWithValue("@Details3_Dependant1", Details3_Dependant1);
                insertCommand.Parameters.AddWithValue("@Details3_Dependant2", Details3_Dependant2);
                insertCommand.Parameters.AddWithValue("@Details3_Dependant3", Details3_Dependant3);
                insertCommand.Parameters.AddWithValue("@Supporttoage_Dependant1", Supporttoage_Dependant1);
                insertCommand.Parameters.AddWithValue("@Supporttoage_Dependant2", Supporttoage_Dependant2);
                insertCommand.Parameters.AddWithValue("@Supporttoage_Dependant3", Supporttoage_Dependant3);
                insertCommand.Parameters.AddWithValue("@SchoolName_Dependant1", SchoolName_Dependant1);
                insertCommand.Parameters.AddWithValue("@SchoolName_Dependant2", SchoolName_Dependant2);
                insertCommand.Parameters.AddWithValue("@SchoolName_Dependant3", SchoolName_Dependant3);
                insertCommand.Parameters.AddWithValue("@SchoolYearLevel_Dependant1", SchoolYearLevel_Dependant1);
                insertCommand.Parameters.AddWithValue("@SchoolYearLevel_Dependant2", SchoolYearLevel_Dependant2);
                insertCommand.Parameters.AddWithValue("@SchoolYearLevel_Dependant3", SchoolYearLevel_Dependant3);
                insertCommand.Parameters.AddWithValue("@EstimatedCostofSchooling_Dependant1", EstimatedCostofSchooling_Dependant1);
                insertCommand.Parameters.AddWithValue("@EstimatedCostofSchooling_Dependant2", EstimatedCostofSchooling_Dependant2);
                insertCommand.Parameters.AddWithValue("@EstimatedCostofSchooling_Dependant3", EstimatedCostofSchooling_Dependant3);
                insertCommand.Parameters.AddWithValue("@AustudyStatus_Dependant1", AustudyStatus_Dependant1);
                insertCommand.Parameters.AddWithValue("@AustudyStatus_Dependant2", AustudyStatus_Dependant2);
                insertCommand.Parameters.AddWithValue("@AustudyStatus_Dependant3", AustudyStatus_Dependant3);
                insertCommand.Parameters.AddWithValue("@ClientsParents", ClientsParents);
                insertCommand.Parameters.AddWithValue("@FileNotesClientsParents_FileName", FileNotesClientsParents_FileName);
                insertCommand.Parameters.AddWithValue("@FileNotesClientsParents_FilePath", FileNotesClientsParents_FilePath);
                insertCommand.Parameters.AddWithValue("@EgCollectablesGolfTennis_Client1", EgCollectablesGolfTennis_Client1);
                insertCommand.Parameters.AddWithValue("@EgCollectablesGolfTennis_Client2", EgCollectablesGolfTennis_Client2);
                insertCommand.Parameters.AddWithValue("@EgCollectablesGolfTennis2_Client1", EgCollectablesGolfTennis2_Client1);
                insertCommand.Parameters.AddWithValue("@EgCollectablesGolfTennis2_Client2", EgCollectablesGolfTennis2_Client2);
                insertCommand.Parameters.AddWithValue("@EgCollectablesGolfTennis3_Client1", EgCollectablesGolfTennis3_Client1);
                insertCommand.Parameters.AddWithValue("@EgCollectablesGolfTennis3_Client2", EgCollectablesGolfTennis3_Client2);
                insertCommand.Parameters.AddWithValue("@Businessname_Accountant", Businessname_Accountant);
                insertCommand.Parameters.AddWithValue("@Businessname_Banker", Businessname_Banker);
                insertCommand.Parameters.AddWithValue("@Businessname_Lawyer", Businessname_Lawyer);
                insertCommand.Parameters.AddWithValue("@Contactname_Accountant", Contactname_Accountant);
                insertCommand.Parameters.AddWithValue("@Contactname_Banker", Contactname_Banker);
                insertCommand.Parameters.AddWithValue("@Contactname_Lawyer", Contactname_Lawyer);
                insertCommand.Parameters.AddWithValue("@Postaladdress_Accountant", Postaladdress_Accountant);
                insertCommand.Parameters.AddWithValue("@Postaladdress_Banker", Postaladdress_Banker);
                insertCommand.Parameters.AddWithValue("@Postaladdress_Lawyer", Postaladdress_Lawyer);
                insertCommand.Parameters.AddWithValue("@Postaladdress2_Accountant", Postaladdress2_Accountant);
                insertCommand.Parameters.AddWithValue("@Postaladdress2_Banker", Postaladdress2_Banker);
                insertCommand.Parameters.AddWithValue("@Postaladdress2_Lawyer", Postaladdress2_Lawyer);
                insertCommand.Parameters.AddWithValue("@PostaladdressState_Accountant", PostaladdressState_Accountant);
                insertCommand.Parameters.AddWithValue("@PostaladdressState_Banker", PostaladdressState_Banker);
                insertCommand.Parameters.AddWithValue("@PostaladdressState_Lawyer", PostaladdressState_Lawyer);
                insertCommand.Parameters.AddWithValue("@PostaladdressPostcode_Accountant", PostaladdressPostcode_Accountant);
                insertCommand.Parameters.AddWithValue("@PostaladdressPostcode_Banker", PostaladdressPostcode_Banker);
                insertCommand.Parameters.AddWithValue("@PostaladdressPostcode_Lawyer", PostaladdressPostcode_Lawyer);
                insertCommand.Parameters.AddWithValue("@Emailaddress_Accountant", Emailaddress_Accountant);
                insertCommand.Parameters.AddWithValue("@Emailaddress_Banker", Emailaddress_Banker);
                insertCommand.Parameters.AddWithValue("@Emailaddress_Lawyer", Emailaddress_Lawyer);
                insertCommand.Parameters.AddWithValue("@Phoneaddress_Accountant", Phoneaddress_Accountant);
                insertCommand.Parameters.AddWithValue("@Phoneaddress_Banker", Phoneaddress_Banker);
                insertCommand.Parameters.AddWithValue("@Phoneaddress_Lawyer", Phoneaddress_Lawyer);
                insertCommand.Parameters.AddWithValue("@Faxnumber_Accountant", Faxnumber_Accountant);
                insertCommand.Parameters.AddWithValue("@Faxnumber_Banker", Faxnumber_Banker);
                insertCommand.Parameters.AddWithValue("@Faxnumber_Lawyer", Faxnumber_Lawyer);
                insertCommand.Parameters.AddWithValue("@FileNotes_FileName", FileNotes_FileName);
                insertCommand.Parameters.AddWithValue("@FileNotes_FilePath", FileNotes_FilePath);

                //_CoverPageID = Convert.ToInt32(insertCommand.ExecuteReader());
                insertCommand.ExecuteReader();

                FileNotes_FileName = "FileNotes_" + _CoverPageID.ToString() + ".jpg";
                FileNotesClientsParents_FileName = "FileNotesClientsParents_" + _CoverPageID.ToString() + ".jpg";

                SqliteCommand insertCommand2 = new SqliteCommand();
                insertCommand2.Connection = db;
                insertCommand2.CommandText = "UPDATE SelectionAPersonalDetails SET FileNotes_FileName = @FileNotes_FileName, FileNotesClientsParents_FileName = @FileNotesClientsParents_FileName WHERE CoverPageID = @ID";
                insertCommand2.Parameters.AddWithValue("@ID", _CoverPageID);
                insertCommand2.Parameters.AddWithValue("@FileNotes_FileName", FileNotes_FileName);
                insertCommand2.Parameters.AddWithValue("@FileNotesClientsParents_FileName", FileNotesClientsParents_FileName);
                insertCommand2.ExecuteReader();

                db.Close();
            }

        }
        #endregion

        #region AddDataSelectionBFinancialSummary


        public static void AddDataSelectionBFinancialSummary(
         int Workstatus_Client1,
         int Workstatus_Client2,
         string Employer_Client1,
         string Employer_Client2,
         string Employeraddress_Client1,
         string Employeraddress_Client2,
         string Occupation_Client1,
         string Occupation_Client2,
         string Numberofyearsservice_Client1,
         string Numberofyearsservice_Client2,
         string IntendedRetirementdate_Client1,
         string IntendedRetirementdate_Client2,
         string Doyouexpectemployment_Client1,
         string Doyouexpectemployment_Client2,
         string Salaryincome_Client1,
         string Salaryincome_Client2,
         string Othertaxableincome_Client1,
         string Othertaxableincome_Client2,
         string Taxfreeincome_Client1,
         string Taxfreeincome_Client2,
         string Familyallowance_Client1,
         string Familyallowance_Client2,
         string Directorsfeesgratuities_Client1,
         string Directorsfeesgratuities_Client2,
         string Areyouexpectingfunds1_Client1,
         string Areyouexpectingfunds1_Client2,
         string Areyouexpectingfunds2_Client1,
         string Areyouexpectingfunds2_Client2,
         string Areyouexpectingfunds3_Client1,
         string Areyouexpectingfunds3_Client2,
         string Other1_Client1,
         string Other1_Client2,
         string Other2_Client1,
         string Other2_Client2,
         string Other3_Client1,
         string Other3_Client2,
         string Employmentsuper_Client1,
         string Employmentsuper_Client2,
         string Salarysacrificetosuper_Client1,
         string Salarysacrificetosuper_Client2,
         string Packagedmotorvehicle_Client1,
         string Packagedmotorvehicle_Client2,
         string Bonus_Client1,
         string Bonus_Client2,
         string Other_Client1,
         string Other_Client2,
         string Entitlementamount_Client1,
         string Entitlementamount_Client2,
         string Entitlementtype_Client1,
         string Entitlementtype_Client2,
         string CentrelinkreferencenoCRN_Client1,
         string CentrelinkreferencenoCRN_Client2,
         string Maintenanceincome_Client1,
         string Maintenanceincome_Client2,
         string Maintenancepayment_Client1,
         string Maintenancepayment_Client2,
         string Overseassocialsecurityincome_Client1,
         string Overseassocialsecurityincome_Client2,
         string FileNotesCentrelink_FileName,
         string FileNotesCentrelink_FilePath,
         string Foodliquids_Fortnight,
         string Foodliquids_Month,
         string Foodliquids_Quarter,
         string Foodliquids_Halfyear,
         string Foodliquids_Annual,
         string Foodliquids_Totallastyear,
         string Alcohol_Fortnight,
         string Alcohol_Month,
         string Alcohol_Quarter,
         string Alcohol_Halfyear,
         string Alcohol_Annual,
         string Alcohol_Totallastyear,
         string Tobacco_Fortnight,
         string Tobacco_Month,
         string Tobacco_Quarter,
         string Tobacco_Halfyear,
         string Tobacco_Annual,
         string Tobacco_Totallastyear,
         string Clothingfootwear_Fortnight,
         string Clothingfootwear_Month,
         string Clothingfootwear_Quarter,
         string Clothingfootwear_Halfyear,
         string Clothingfootwear_Annual,
         string Clothingfootwear_Totallastyear,
         string Medicalhealth_Fortnight,
         string Medicalhealth_Month,
         string Medicalhealth_Quarter,
         string Medicalhealth_Halfyear,
         string Medicalhealth_Annual,
         string Medicalhealth_Totallastyear,
         string Recreation_Fortnight,
         string Recreation_Month,
         string Recreation_Quarter,
         string Recreation_Halfyear,
         string Recreation_Annual,
         string Recreation_Totallastyear,
         string Personalcare_Fortnight,
         string Personalcare_Month,
         string Personalcare_Quarter,
         string Personalcare_Halfyear,
         string Personalcare_Annual,
         string Personalcare_Totallastyear,
         string PhonePost_Fortnight,
         string PhonePost_Month,
         string PhonePost_Quarter,
         string PhonePost_Halfyear,
         string PhonePost_Annual,
         string PhonePost_Totallastyear,
         string Travel_Fortnight,
         string Travel_Month,
         string Travel_Quarter,
         string Travel_Halfyear,
         string Travel_Annual,
         string Travel_Totallastyear,
         string Gifts_Fortnight,
         string Gifts_Month,
         string Gifts_Quarter,
         string Gifts_Halfyear,
         string Gifts_Annual,
         string Gifts_Totallastyear,
         string Other_Fortnight,
         string Other_Month,
         string Other_Quarter,
         string Other_Halfyear,
         string Other_Annual,
         string Other_Totallastyear,
         string Ratesinsurance_Fortnight,
         string Ratesinsurance_Month,
         string Ratesinsurance_Quarter,
         string Ratesinsurance_Halfyear,
         string Ratesinsurance_Annual,
         string Ratesinsurance_Totallastyear,
         string Repairsmaintenance_Fortnight,
         string Repairsmaintenance_Month,
         string Repairsmaintenance_Quarter,
         string Repairsmaintenance_Halfyear,
         string Repairsmaintenance_Annual,
         string Repairsmaintenance_Totallastyear,
         string Electricitygas_Fortnight,
         string Electricitygas_Month,
         string Electricitygas_Quarter,
         string Electricitygas_Halfyear,
         string Electricitygas_Annual,
         string Electricitygas_Totallastyear,
         string Houseloanprincipal_Fortnight,
         string Houseloanprincipal_Month,
         string Houseloanprincipal_Quarter,
         string Houseloanprincipal_Halfyear,
         string Houseloanprincipal_Annual,
         string Houseloanprincipal_Totallastyear,
         string Rentmortgage_Fortnight,
         string Rentmortgage_Month,
         string Rentmortgage_Quarter,
         string Rentmortgage_Halfyear,
         string Rentmortgage_Annual,
         string Rentmortgage_Totallastyear,
         string Extramortgagepayments_Fortnight,
         string Extramortgagepayments_Month,
         string Extramortgagepayments_Quarter,
         string Extramortgagepayments_Halfyear,
         string Extramortgagepayments_Annual,
         string Extramortgagepayments_Totallastyear,
         string Furnishingequipment_Fortnight,
         string Furnishingequipment_Month,
         string Furnishingequipment_Quarter,
         string Furnishingequipment_Halfyear,
         string Furnishingequipment_Annual,
         string Furnishingequipment_Totallastyear,
         string OtherHousing_Fortnight,
         string OtherHousing_Month,
         string OtherHousing_Quarter,
         string OtherHousing_Halfyear,
         string OtherHousing_Annual,
         string OtherHousing_Totallastyear,
         string Registrationinsurance_Fortnight,
         string Registrationinsurance_Month,
         string Registrationinsurance_Quarter,
         string Registrationinsurance_Halfyear,
         string Registrationinsurance_Annual,
         string Registrationinsurance_Totallastyear,
         string RepairsmaintenanceTransport_Fortnight,
         string RepairsmaintenanceTransport_Month,
         string RepairsmaintenanceTransport_Quarter,
         string RepairsmaintenanceTransport_Halfyear,
         string RepairsmaintenanceTransport_Annual,
         string RepairsmaintenanceTransport_Totallastyear,
         string FuelOil_Fortnight,
         string FuelOil_Month,
         string FuelOil_Quarter,
         string FuelOil_Halfyear,
         string FuelOil_Annual,
         string FuelOil_Totallastyear,
         string Replacementvehicle_Fortnight,
         string Replacementvehicle_Month,
         string Replacementvehicle_Quarter,
         string Replacementvehicle_Halfyear,
         string Replacementvehicle_Annual,
         string Replacementvehicle_Totallastyear,
         string Fares_Fortnight,
         string Fares_Month,
         string Fares_Quarter,
         string Fares_Halfyear,
         string Fares_Annual,
         string Fares_Totallastyear,
         string OtherTransport_Fortnight,
         string OtherTransport_Month,
         string OtherTransport_Quarter,
         string OtherTransport_Halfyear,
         string OtherTransport_Annual,
         string OtherTransport_Totallastyear,
         string Superlifeinsurance_Fortnight,
         string Superlifeinsurance_Month,
         string Superlifeinsurance_Quarter,
         string Superlifeinsurance_Halfyear,
         string Superlifeinsurance_Annual,
         string Superlifeinsurance_Totallastyear,
         string Loansavings_Fortnight,
         string Loansavings_Month,
         string Loansavings_Quarter,
         string Loansavings_Halfyear,
         string Loansavings_Annual,
         string Loansavings_Totallastyear,
         string Carloan_Fortnight,
         string Carloan_Month,
         string Carloan_Quarter,
         string Carloan_Halfyear,
         string Carloan_Annual,
         string Carloan_Totallastyear,
         string OtherGeneral_Fortnight,
         string OtherGeneral_Month,
         string OtherGeneral_Quarter,
         string OtherGeneral_Halfyear,
         string OtherGeneral_Annual,
         string OtherGeneral_Totallastyear,
         string Foodliquid_Fortnight,
         string Foodliquid_Month,
         string Foodliquid_Quarter,
         string Foodliquid_Halfyear,
         string Foodliquid_Annual,
         string Foodliquid_Totallastyear,
         string ClothingfootwearChildren_Fortnight,
         string ClothingfootwearChildren_Month,
         string ClothingfootwearChildren_Quarter,
         string ClothingfootwearChildren_Halfyear,
         string ClothingfootwearChildren_Annual,
         string ClothingfootwearChildren_Totallastyear,
         string Education_Fortnight,
         string Education_Month,
         string Education_Quarter,
         string Education_Halfyear,
         string Education_Annual,
         string Education_Totallastyear,
         string OtherChildren_Fortnight,
         string OtherChildren_Month,
         string OtherChildren_Quarter,
         string OtherChildren_Halfyear,
         string OtherChildren_Annual,
         string OtherChildren_Totallastyear,
         string Total_Fortnight,
         string Total_Month,
         string Total_Quarter,
         string Total_Halfyear,
         string Total_Annual,
         string Total_Totallastyear,
         //File Notes
         string FileNotes_FileName,
         string FileNotes_FilePath
            )
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbname);
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO SelectionBFinancialSummary (" +
                    "CoverPageID," +
         "Workstatus_Client1," +
         "Workstatus_Client2," +
         "Employer_Client1," +
         "Employer_Client2," +
         "Employeraddress_Client1," +
         "Employeraddress_Client2," +
         "Occupation_Client1," +
         "Occupation_Client2," +
         "Numberofyearsservice_Client1," +
         "Numberofyearsservice_Client2," +
         "IntendedRetirementdate_Client1," +
         "IntendedRetirementdate_Client2," +
         "Doyouexpectemployment_Client1," +
         "Doyouexpectemployment_Client2," +
         "Salaryincome_Client1," +
         "Salaryincome_Client2," +
         "Othertaxableincome_Client1," +
         "Othertaxableincome_Client2," +
         "Taxfreeincome_Client1," +
         "Taxfreeincome_Client2," +
         "Familyallowance_Client1," +
         "Familyallowance_Client2," +
         "Directorsfeesgratuities_Client1," +
         "Directorsfeesgratuities_Client2," +
         "Areyouexpectingfunds1_Client1," +
         "Areyouexpectingfunds1_Client2," +
         "Areyouexpectingfunds2_Client1," +
         "Areyouexpectingfunds2_Client2," +
         "Areyouexpectingfunds3_Client1," +
         "Areyouexpectingfunds3_Client2," +
         "Other1_Client1," +
         "Other1_Client2," +
         "Other2_Client1," +
         "Other2_Client2," +
         "Other3_Client1," +
         "Other3_Client2," +
         "Employmentsuper_Client1," +
         "Employmentsuper_Client2," +
         "Salarysacrificetosuper_Client1," +
         "Salarysacrificetosuper_Client2," +
         "Packagedmotorvehicle_Client1," +
         "Packagedmotorvehicle_Client2," +
         "Bonus_Client1," +
         "Bonus_Client2," +
         "Other_Client1," +
         "Other_Client2," +
         "Entitlementamount_Client1," +
         "Entitlementamount_Client2," +
         "Entitlementtype_Client1," +
         "Entitlementtype_Client2," +
         "CentrelinkreferencenoCRN_Client1," +
         "CentrelinkreferencenoCRN_Client2," +
         "Maintenanceincome_Client1," +
         "Maintenanceincome_Client2," +
         "Maintenancepayment_Client1," +
         "Maintenancepayment_Client2," +
         "Overseassocialsecurityincome_Client1," +
         "Overseassocialsecurityincome_Client2," +
         "FileNotesCentrelink_FileName," +
         "FileNotesCentrelink_FilePath," +
         "Foodliquids_Fortnight," +
         "Foodliquids_Month," +
         "Foodliquids_Quarter," +
         "Foodliquids_Halfyear," +
         "Foodliquids_Annual," +
         "Foodliquids_Totallastyear," +
         "Alcohol_Fortnight," +
         "Alcohol_Month," +
         "Alcohol_Quarter," +
         "Alcohol_Halfyear," +
         "Alcohol_Annual," +
         "Alcohol_Totallastyear," +
         "Tobacco_Fortnight," +
         "Tobacco_Month," +
         "Tobacco_Quarter," +
         "Tobacco_Halfyear," +
         "Tobacco_Annual," +
         "Tobacco_Totallastyear," +
         "Clothingfootwear_Fortnight," +
         "Clothingfootwear_Month," +
         "Clothingfootwear_Quarter," +
         "Clothingfootwear_Halfyear," +
         "Clothingfootwear_Annual," +
         "Clothingfootwear_Totallastyear," +
         "Medicalhealth_Fortnight," +
         "Medicalhealth_Month," +
         "Medicalhealth_Quarter," +
         "Medicalhealth_Halfyear," +
         "Medicalhealth_Annual," +
         "Medicalhealth_Totallastyear," +
         "Recreation_Fortnight," +
         "Recreation_Month," +
         "Recreation_Quarter," +
         "Recreation_Halfyear," +
         "Recreation_Annual," +
         "Recreation_Totallastyear," +
         "Personalcare_Fortnight," +
         "Personalcare_Month," +
         "Personalcare_Quarter," +
         "Personalcare_Halfyear," +
         "Personalcare_Annual," +
         "Personalcare_Totallastyear," +
         "PhonePost_Fortnight," +
         "PhonePost_Month," +
         "PhonePost_Quarter," +
         "PhonePost_Halfyear," +
         "PhonePost_Annual," +
         "PhonePost_Totallastyear," +
         "Travel_Fortnight," +
         "Travel_Month," +
         "Travel_Quarter," +
         "Travel_Halfyear," +
         "Travel_Annual," +
         "Travel_Totallastyear," +
         "Gifts_Fortnight," +
         "Gifts_Month," +
         "Gifts_Quarter," +
         "Gifts_Halfyear," +
         "Gifts_Annual," +
         "Gifts_Totallastyear," +
         "Other_Fortnight," +
         "Other_Month," +
         "Other_Quarter," +
         "Other_Halfyear," +
         "Other_Annual," +
         "Other_Totallastyear," +
         "Ratesinsurance_Fortnight," +
         "Ratesinsurance_Month," +
         "Ratesinsurance_Quarter," +
         "Ratesinsurance_Halfyear," +
         "Ratesinsurance_Annual," +
         "Ratesinsurance_Totallastyear," +
         "Repairsmaintenance_Fortnight," +
         "Repairsmaintenance_Month," +
         "Repairsmaintenance_Quarter," +
         "Repairsmaintenance_Halfyear," +
         "Repairsmaintenance_Annual," +
         "Repairsmaintenance_Totallastyear," +
         "Electricitygas_Fortnight," +
         "Electricitygas_Month," +
         "Electricitygas_Quarter," +
         "Electricitygas_Halfyear," +
         "Electricitygas_Annual," +
         "Electricitygas_Totallastyear," +
         "Houseloanprincipal_Fortnight," +
         "Houseloanprincipal_Month," +
         "Houseloanprincipal_Quarter," +
         "Houseloanprincipal_Halfyear," +
         "Houseloanprincipal_Annual," +
         "Houseloanprincipal_Totallastyear," +
         "Rentmortgage_Fortnight," +
         "Rentmortgage_Month," +
         "Rentmortgage_Quarter," +
         "Rentmortgage_Halfyear," +
         "Rentmortgage_Annual," +
         "Rentmortgage_Totallastyear," +
         "Extramortgagepayments_Fortnight," +
         "Extramortgagepayments_Month," +
         "Extramortgagepayments_Quarter," +
         "Extramortgagepayments_Halfyear," +
         "Extramortgagepayments_Annual," +
         "Extramortgagepayments_Totallastyear," +
         "Furnishingequipment_Fortnight," +
         "Furnishingequipment_Month," +
         "Furnishingequipment_Quarter," +
         "Furnishingequipment_Halfyear," +
         "Furnishingequipment_Annual," +
         "Furnishingequipment_Totallastyear," +
         "OtherHousing_Fortnight," +
         "OtherHousing_Month," +
         "OtherHousing_Quarter," +
         "OtherHousing_Halfyear," +
         "OtherHousing_Annual," +
         "OtherHousing_Totallastyear," +
         "Registrationinsurance_Fortnight," +
         "Registrationinsurance_Month," +
         "Registrationinsurance_Quarter," +
         "Registrationinsurance_Halfyear," +
         "Registrationinsurance_Annual," +
         "Registrationinsurance_Totallastyear," +
         "RepairsmaintenanceTransport_Fortnight," +
         "RepairsmaintenanceTransport_Month," +
         "RepairsmaintenanceTransport_Quarter," +
         "RepairsmaintenanceTransport_Halfyear," +
         "RepairsmaintenanceTransport_Annual," +
         "RepairsmaintenanceTransport_Totallastyear," +
         "FuelOil_Fortnight," +
         "FuelOil_Month," +
         "FuelOil_Quarter," +
         "FuelOil_Halfyear," +
         "FuelOil_Annual," +
         "FuelOil_Totallastyear," +
         "Replacementvehicle_Fortnight," +
         "Replacementvehicle_Month," +
         "Replacementvehicle_Quarter," +
         "Replacementvehicle_Halfyear," +
         "Replacementvehicle_Annual," +
         "Replacementvehicle_Totallastyear," +
         "Fares_Fortnight," +
         "Fares_Month," +
         "Fares_Quarter," +
         "Fares_Halfyear," +
         "Fares_Annual," +
         "Fares_Totallastyear," +
         "OtherTransport_Fortnight," +
         "OtherTransport_Month," +
         "OtherTransport_Quarter," +
         "OtherTransport_Halfyear," +
         "OtherTransport_Annual," +
         "OtherTransport_Totallastyear," +
         "Superlifeinsurance_Fortnight," +
         "Superlifeinsurance_Month," +
         "Superlifeinsurance_Quarter," +
         "Superlifeinsurance_Halfyear," +
         "Superlifeinsurance_Annual," +
         "Superlifeinsurance_Totallastyear," +
         "Loansavings_Fortnight," +
         "Loansavings_Month," +
         "Loansavings_Quarter," +
         "Loansavings_Halfyear," +
         "Loansavings_Annual," +
         "Loansavings_Totallastyear," +
         "Carloan_Fortnight," +
         "Carloan_Month," +
         "Carloan_Quarter," +
         "Carloan_Halfyear," +
         "Carloan_Annual," +
         "Carloan_Totallastyear," +
         "OtherGeneral_Fortnight," +
         "OtherGeneral_Month," +
         "OtherGeneral_Quarter," +
         "OtherGeneral_Halfyear," +
         "OtherGeneral_Annual," +
         "OtherGeneral_Totallastyear," +
         "Foodliquid_Fortnight," +
         "Foodliquid_Month," +
         "Foodliquid_Quarter," +
         "Foodliquid_Halfyear," +
         "Foodliquid_Annual," +
         "Foodliquid_Totallastyear," +
         "ClothingfootwearChildren_Fortnight," +
         "ClothingfootwearChildren_Month," +
         "ClothingfootwearChildren_Quarter," +
         "ClothingfootwearChildren_Halfyear," +
         "ClothingfootwearChildren_Annual," +
         "ClothingfootwearChildren_Totallastyear," +
         "Education_Fortnight," +
         "Education_Month," +
         "Education_Quarter," +
         "Education_Halfyear," +
         "Education_Annual," +
         "Education_Totallastyear," +
         "OtherChildren_Fortnight," +
         "OtherChildren_Month," +
         "OtherChildren_Quarter," +
         "OtherChildren_Halfyear," +
         "OtherChildren_Annual," +
         "OtherChildren_Totallastyear," +
         "Total_Fortnight," +
         "Total_Month," +
         "Total_Quarter," +
         "Total_Halfyear," +
         "Total_Annual," +
         "Total_Totallastyear," +
         "	FileNotes_FileName	," +
"	FileNotes_FilePath	" +
                    ") VALUES (" +
                    "@CoverPageID," +
         "@Workstatus_Client1," +
         "@Workstatus_Client2," +
         "@Employer_Client1," +
         "@Employer_Client2," +
         "@Employeraddress_Client1," +
         "@Employeraddress_Client2," +
         "@Occupation_Client1," +
         "@Occupation_Client2," +
         "@Numberofyearsservice_Client1," +
         "@Numberofyearsservice_Client2," +
         "@IntendedRetirementdate_Client1," +
         "@IntendedRetirementdate_Client2," +
         "@Doyouexpectemployment_Client1," +
         "@Doyouexpectemployment_Client2," +
         "@Salaryincome_Client1," +
         "@Salaryincome_Client2," +
         "@Othertaxableincome_Client1," +
         "@Othertaxableincome_Client2," +
         "@Taxfreeincome_Client1," +
         "@Taxfreeincome_Client2," +
         "@Familyallowance_Client1," +
         "@Familyallowance_Client2," +
         "@Directorsfeesgratuities_Client1," +
         "@Directorsfeesgratuities_Client2," +
         "@Areyouexpectingfunds1_Client1," +
         "@Areyouexpectingfunds1_Client2," +
         "@Areyouexpectingfunds2_Client1," +
         "@Areyouexpectingfunds2_Client2," +
         "@Areyouexpectingfunds3_Client1," +
         "@Areyouexpectingfunds3_Client2," +
         "@Other1_Client1," +
         "@Other1_Client2," +
         "@Other2_Client1," +
         "@Other2_Client2," +
         "@Other3_Client1," +
         "@Other3_Client2," +
         "@Employmentsuper_Client1," +
         "@Employmentsuper_Client2," +
         "@Salarysacrificetosuper_Client1," +
         "@Salarysacrificetosuper_Client2," +
         "@Packagedmotorvehicle_Client1," +
         "@Packagedmotorvehicle_Client2," +
         "@Bonus_Client1," +
         "@Bonus_Client2," +
         "@Other_Client1," +
         "@Other_Client2," +
         "@Entitlementamount_Client1," +
         "@Entitlementamount_Client2," +
         "@Entitlementtype_Client1," +
         "@Entitlementtype_Client2," +
         "@CentrelinkreferencenoCRN_Client1," +
         "@CentrelinkreferencenoCRN_Client2," +
         "@Maintenanceincome_Client1," +
         "@Maintenanceincome_Client2," +
         "@Maintenancepayment_Client1," +
         "@Maintenancepayment_Client2," +
         "@Overseassocialsecurityincome_Client1," +
         "@Overseassocialsecurityincome_Client2," +
         "@FileNotesCentrelink_FileName," +
         "@FileNotesCentrelink_FilePath," +
         "@Foodliquids_Fortnight," +
         "@Foodliquids_Month," +
         "@Foodliquids_Quarter," +
         "@Foodliquids_Halfyear," +
         "@Foodliquids_Annual," +
         "@Foodliquids_Totallastyear," +
         "@Alcohol_Fortnight," +
         "@Alcohol_Month," +
         "@Alcohol_Quarter," +
         "@Alcohol_Halfyear," +
         "@Alcohol_Annual," +
         "@Alcohol_Totallastyear," +
         "@Tobacco_Fortnight," +
         "@Tobacco_Month," +
         "@Tobacco_Quarter," +
         "@Tobacco_Halfyear," +
         "@Tobacco_Annual," +
         "@Tobacco_Totallastyear," +
         "@Clothingfootwear_Fortnight," +
         "@Clothingfootwear_Month," +
         "@Clothingfootwear_Quarter," +
         "@Clothingfootwear_Halfyear," +
         "@Clothingfootwear_Annual," +
         "@Clothingfootwear_Totallastyear," +
         "@Medicalhealth_Fortnight," +
         "@Medicalhealth_Month," +
         "@Medicalhealth_Quarter," +
         "@Medicalhealth_Halfyear," +
         "@Medicalhealth_Annual," +
         "@Medicalhealth_Totallastyear," +
         "@Recreation_Fortnight," +
         "@Recreation_Month," +
         "@Recreation_Quarter," +
         "@Recreation_Halfyear," +
         "@Recreation_Annual," +
         "@Recreation_Totallastyear," +
         "@Personalcare_Fortnight," +
         "@Personalcare_Month," +
         "@Personalcare_Quarter," +
         "@Personalcare_Halfyear," +
         "@Personalcare_Annual," +
         "@Personalcare_Totallastyear," +
         "@PhonePost_Fortnight," +
         "@PhonePost_Month," +
         "@PhonePost_Quarter," +
         "@PhonePost_Halfyear," +
         "@PhonePost_Annual," +
         "@PhonePost_Totallastyear," +
         "@Travel_Fortnight," +
         "@Travel_Month," +
         "@Travel_Quarter," +
         "@Travel_Halfyear," +
         "@Travel_Annual," +
         "@Travel_Totallastyear," +
         "@Gifts_Fortnight," +
         "@Gifts_Month," +
         "@Gifts_Quarter," +
         "@Gifts_Halfyear," +
         "@Gifts_Annual," +
         "@Gifts_Totallastyear," +
         "@Other_Fortnight," +
         "@Other_Month," +
         "@Other_Quarter," +
         "@Other_Halfyear," +
         "@Other_Annual," +
         "@Other_Totallastyear," +
         "@Ratesinsurance_Fortnight," +
         "@Ratesinsurance_Month," +
         "@Ratesinsurance_Quarter," +
         "@Ratesinsurance_Halfyear," +
         "@Ratesinsurance_Annual," +
         "@Ratesinsurance_Totallastyear," +
         "@Repairsmaintenance_Fortnight," +
         "@Repairsmaintenance_Month," +
         "@Repairsmaintenance_Quarter," +
         "@Repairsmaintenance_Halfyear," +
         "@Repairsmaintenance_Annual," +
         "@Repairsmaintenance_Totallastyear," +
         "@Electricitygas_Fortnight," +
         "@Electricitygas_Month," +
         "@Electricitygas_Quarter," +
         "@Electricitygas_Halfyear," +
         "@Electricitygas_Annual," +
         "@Electricitygas_Totallastyear," +
         "@Houseloanprincipal_Fortnight," +
         "@Houseloanprincipal_Month," +
         "@Houseloanprincipal_Quarter," +
         "@Houseloanprincipal_Halfyear," +
         "@Houseloanprincipal_Annual," +
         "@Houseloanprincipal_Totallastyear," +
         "@Rentmortgage_Fortnight," +
         "@Rentmortgage_Month," +
         "@Rentmortgage_Quarter," +
         "@Rentmortgage_Halfyear," +
         "@Rentmortgage_Annual," +
         "@Rentmortgage_Totallastyear," +
         "@Extramortgagepayments_Fortnight," +
         "@Extramortgagepayments_Month," +
         "@Extramortgagepayments_Quarter," +
         "@Extramortgagepayments_Halfyear," +
         "@Extramortgagepayments_Annual," +
         "@Extramortgagepayments_Totallastyear," +
         "@Furnishingequipment_Fortnight," +
         "@Furnishingequipment_Month," +
         "@Furnishingequipment_Quarter," +
         "@Furnishingequipment_Halfyear," +
         "@Furnishingequipment_Annual," +
         "@Furnishingequipment_Totallastyear," +
         "@OtherHousing_Fortnight," +
         "@OtherHousing_Month," +
         "@OtherHousing_Quarter," +
         "@OtherHousing_Halfyear," +
         "@OtherHousing_Annual," +
         "@OtherHousing_Totallastyear," +
         "@Registrationinsurance_Fortnight," +
         "@Registrationinsurance_Month," +
         "@Registrationinsurance_Quarter," +
         "@Registrationinsurance_Halfyear," +
         "@Registrationinsurance_Annual," +
         "@Registrationinsurance_Totallastyear," +
         "@RepairsmaintenanceTransport_Fortnight," +
         "@RepairsmaintenanceTransport_Month," +
         "@RepairsmaintenanceTransport_Quarter," +
         "@RepairsmaintenanceTransport_Halfyear," +
         "@RepairsmaintenanceTransport_Annual," +
         "@RepairsmaintenanceTransport_Totallastyear," +
         "@FuelOil_Fortnight," +
         "@FuelOil_Month," +
         "@FuelOil_Quarter," +
         "@FuelOil_Halfyear," +
         "@FuelOil_Annual," +
         "@FuelOil_Totallastyear," +
         "@Replacementvehicle_Fortnight," +
         "@Replacementvehicle_Month," +
         "@Replacementvehicle_Quarter," +
         "@Replacementvehicle_Halfyear," +
         "@Replacementvehicle_Annual," +
         "@Replacementvehicle_Totallastyear," +
         "@Fares_Fortnight," +
         "@Fares_Month," +
         "@Fares_Quarter," +
         "@Fares_Halfyear," +
         "@Fares_Annual," +
         "@Fares_Totallastyear," +
         "@OtherTransport_Fortnight," +
         "@OtherTransport_Month," +
         "@OtherTransport_Quarter," +
         "@OtherTransport_Halfyear," +
         "@OtherTransport_Annual," +
         "@OtherTransport_Totallastyear," +
         "@Superlifeinsurance_Fortnight," +
         "@Superlifeinsurance_Month," +
         "@Superlifeinsurance_Quarter," +
         "@Superlifeinsurance_Halfyear," +
         "@Superlifeinsurance_Annual," +
         "@Superlifeinsurance_Totallastyear," +
         "@Loansavings_Fortnight," +
         "@Loansavings_Month," +
         "@Loansavings_Quarter," +
         "@Loansavings_Halfyear," +
         "@Loansavings_Annual," +
         "@Loansavings_Totallastyear," +
         "@Carloan_Fortnight," +
         "@Carloan_Month," +
         "@Carloan_Quarter," +
         "@Carloan_Halfyear," +
         "@Carloan_Annual," +
         "@Carloan_Totallastyear," +
         "@OtherGeneral_Fortnight," +
         "@OtherGeneral_Month," +
         "@OtherGeneral_Quarter," +
         "@OtherGeneral_Halfyear," +
         "@OtherGeneral_Annual," +
         "@OtherGeneral_Totallastyear," +
         "@Foodliquid_Fortnight," +
         "@Foodliquid_Month," +
         "@Foodliquid_Quarter," +
         "@Foodliquid_Halfyear," +
         "@Foodliquid_Annual," +
         "@Foodliquid_Totallastyear," +
         "@ClothingfootwearChildren_Fortnight," +
         "@ClothingfootwearChildren_Month," +
         "@ClothingfootwearChildren_Quarter," +
         "@ClothingfootwearChildren_Halfyear," +
         "@ClothingfootwearChildren_Annual," +
         "@ClothingfootwearChildren_Totallastyear," +
         "@Education_Fortnight," +
         "@Education_Month," +
         "@Education_Quarter," +
         "@Education_Halfyear," +
         "@Education_Annual," +
         "@Education_Totallastyear," +
         "@OtherChildren_Fortnight," +
         "@OtherChildren_Month," +
         "@OtherChildren_Quarter," +
         "@OtherChildren_Halfyear," +
         "@OtherChildren_Annual," +
         "@OtherChildren_Totallastyear," +
         "@Total_Fortnight," +
         "@Total_Month," +
         "@Total_Quarter," +
         "@Total_Halfyear," +
         "@Total_Annual," +
         "@Total_Totallastyear," +
         "@FileNotes_FileName," +
         "@FileNotes_FilePath" +
                    ");";

                insertCommand.Parameters.AddWithValue("@CoverPageID", _CoverPageID);
                insertCommand.Parameters.AddWithValue("@Workstatus_Client1", Workstatus_Client1);
                insertCommand.Parameters.AddWithValue("@Workstatus_Client2", Workstatus_Client2);
                insertCommand.Parameters.AddWithValue("@Employer_Client1", Employer_Client1);
                insertCommand.Parameters.AddWithValue("@Employer_Client2", Employer_Client2);
                insertCommand.Parameters.AddWithValue("@Employeraddress_Client1", Employeraddress_Client1);
                insertCommand.Parameters.AddWithValue("@Employeraddress_Client2", Employeraddress_Client2);
                insertCommand.Parameters.AddWithValue("@Occupation_Client1", Occupation_Client1);
                insertCommand.Parameters.AddWithValue("@Occupation_Client2", Occupation_Client2);
                insertCommand.Parameters.AddWithValue("@Numberofyearsservice_Client1", Numberofyearsservice_Client1);
                insertCommand.Parameters.AddWithValue("@Numberofyearsservice_Client2", Numberofyearsservice_Client2);
                insertCommand.Parameters.AddWithValue("@IntendedRetirementdate_Client1", IntendedRetirementdate_Client1);
                insertCommand.Parameters.AddWithValue("@IntendedRetirementdate_Client2", IntendedRetirementdate_Client2);
                insertCommand.Parameters.AddWithValue("@Doyouexpectemployment_Client1", Doyouexpectemployment_Client1);
                insertCommand.Parameters.AddWithValue("@Doyouexpectemployment_Client2", Doyouexpectemployment_Client2);
                insertCommand.Parameters.AddWithValue("@Salaryincome_Client1", Salaryincome_Client1);
                insertCommand.Parameters.AddWithValue("@Salaryincome_Client2", Salaryincome_Client2);
                insertCommand.Parameters.AddWithValue("@Othertaxableincome_Client1", Othertaxableincome_Client1);
                insertCommand.Parameters.AddWithValue("@Othertaxableincome_Client2", Othertaxableincome_Client2);
                insertCommand.Parameters.AddWithValue("@Taxfreeincome_Client1", Taxfreeincome_Client1);
                insertCommand.Parameters.AddWithValue("@Taxfreeincome_Client2", Taxfreeincome_Client2);
                insertCommand.Parameters.AddWithValue("@Familyallowance_Client1", Familyallowance_Client1);
                insertCommand.Parameters.AddWithValue("@Familyallowance_Client2", Familyallowance_Client2);
                insertCommand.Parameters.AddWithValue("@Directorsfeesgratuities_Client1", Directorsfeesgratuities_Client1);
                insertCommand.Parameters.AddWithValue("@Directorsfeesgratuities_Client2", Directorsfeesgratuities_Client2);
                insertCommand.Parameters.AddWithValue("@Areyouexpectingfunds1_Client1", Areyouexpectingfunds1_Client1);
                insertCommand.Parameters.AddWithValue("@Areyouexpectingfunds1_Client2", Areyouexpectingfunds1_Client2);
                insertCommand.Parameters.AddWithValue("@Areyouexpectingfunds2_Client1", Areyouexpectingfunds2_Client1);
                insertCommand.Parameters.AddWithValue("@Areyouexpectingfunds2_Client2", Areyouexpectingfunds2_Client2);
                insertCommand.Parameters.AddWithValue("@Areyouexpectingfunds3_Client1", Areyouexpectingfunds3_Client1);
                insertCommand.Parameters.AddWithValue("@Areyouexpectingfunds3_Client2", Areyouexpectingfunds3_Client2);
                insertCommand.Parameters.AddWithValue("@Other1_Client1", Other1_Client1);
                insertCommand.Parameters.AddWithValue("@Other1_Client2", Other1_Client2);
                insertCommand.Parameters.AddWithValue("@Other2_Client1", Other2_Client1);
                insertCommand.Parameters.AddWithValue("@Other2_Client2", Other2_Client2);
                insertCommand.Parameters.AddWithValue("@Other3_Client1", Other3_Client1);
                insertCommand.Parameters.AddWithValue("@Other3_Client2", Other3_Client2);
                insertCommand.Parameters.AddWithValue("@Employmentsuper_Client1", Employmentsuper_Client1);
                insertCommand.Parameters.AddWithValue("@Employmentsuper_Client2", Employmentsuper_Client2);
                insertCommand.Parameters.AddWithValue("@Salarysacrificetosuper_Client1", Salarysacrificetosuper_Client1);
                insertCommand.Parameters.AddWithValue("@Salarysacrificetosuper_Client2", Salarysacrificetosuper_Client2);
                insertCommand.Parameters.AddWithValue("@Packagedmotorvehicle_Client1", Packagedmotorvehicle_Client1);
                insertCommand.Parameters.AddWithValue("@Packagedmotorvehicle_Client2", Packagedmotorvehicle_Client2);
                insertCommand.Parameters.AddWithValue("@Bonus_Client1", Bonus_Client1);
                insertCommand.Parameters.AddWithValue("@Bonus_Client2", Bonus_Client2);
                insertCommand.Parameters.AddWithValue("@Other_Client1", Other_Client1);
                insertCommand.Parameters.AddWithValue("@Other_Client2", Other_Client2);
                insertCommand.Parameters.AddWithValue("@Entitlementamount_Client1", Entitlementamount_Client1);
                insertCommand.Parameters.AddWithValue("@Entitlementamount_Client2", Entitlementamount_Client2);
                insertCommand.Parameters.AddWithValue("@Entitlementtype_Client1", Entitlementtype_Client1);
                insertCommand.Parameters.AddWithValue("@Entitlementtype_Client2", Entitlementtype_Client2);
                insertCommand.Parameters.AddWithValue("@CentrelinkreferencenoCRN_Client1", CentrelinkreferencenoCRN_Client1);
                insertCommand.Parameters.AddWithValue("@CentrelinkreferencenoCRN_Client2", CentrelinkreferencenoCRN_Client2);
                insertCommand.Parameters.AddWithValue("@Maintenanceincome_Client1", Maintenanceincome_Client1);
                insertCommand.Parameters.AddWithValue("@Maintenanceincome_Client2", Maintenanceincome_Client2);
                insertCommand.Parameters.AddWithValue("@Maintenancepayment_Client1", Maintenancepayment_Client1);
                insertCommand.Parameters.AddWithValue("@Maintenancepayment_Client2", Maintenancepayment_Client2);
                insertCommand.Parameters.AddWithValue("@Overseassocialsecurityincome_Client1", Overseassocialsecurityincome_Client1);
                insertCommand.Parameters.AddWithValue("@Overseassocialsecurityincome_Client2", Overseassocialsecurityincome_Client2);
                insertCommand.Parameters.AddWithValue("@FileNotesCentrelink_FileName", FileNotesCentrelink_FileName);
                insertCommand.Parameters.AddWithValue("@FileNotesCentrelink_FilePath", FileNotesCentrelink_FilePath);
                insertCommand.Parameters.AddWithValue("@Foodliquids_Fortnight", Foodliquids_Fortnight);
                insertCommand.Parameters.AddWithValue("@Foodliquids_Month", Foodliquids_Month);
                insertCommand.Parameters.AddWithValue("@Foodliquids_Quarter", Foodliquids_Quarter);
                insertCommand.Parameters.AddWithValue("@Foodliquids_Halfyear", Foodliquids_Halfyear);
                insertCommand.Parameters.AddWithValue("@Foodliquids_Annual", Foodliquids_Annual);
                insertCommand.Parameters.AddWithValue("@Foodliquids_Totallastyear", Foodliquids_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Alcohol_Fortnight", Alcohol_Fortnight);
                insertCommand.Parameters.AddWithValue("@Alcohol_Month", Alcohol_Month);
                insertCommand.Parameters.AddWithValue("@Alcohol_Quarter", Alcohol_Quarter);
                insertCommand.Parameters.AddWithValue("@Alcohol_Halfyear", Alcohol_Halfyear);
                insertCommand.Parameters.AddWithValue("@Alcohol_Annual", Alcohol_Annual);
                insertCommand.Parameters.AddWithValue("@Alcohol_Totallastyear", Alcohol_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Tobacco_Fortnight", Tobacco_Fortnight);
                insertCommand.Parameters.AddWithValue("@Tobacco_Month", Tobacco_Month);
                insertCommand.Parameters.AddWithValue("@Tobacco_Quarter", Tobacco_Quarter);
                insertCommand.Parameters.AddWithValue("@Tobacco_Halfyear", Tobacco_Halfyear);
                insertCommand.Parameters.AddWithValue("@Tobacco_Annual", Tobacco_Annual);
                insertCommand.Parameters.AddWithValue("@Tobacco_Totallastyear", Tobacco_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Clothingfootwear_Fortnight", Clothingfootwear_Fortnight);
                insertCommand.Parameters.AddWithValue("@Clothingfootwear_Month", Clothingfootwear_Month);
                insertCommand.Parameters.AddWithValue("@Clothingfootwear_Quarter", Clothingfootwear_Quarter);
                insertCommand.Parameters.AddWithValue("@Clothingfootwear_Halfyear", Clothingfootwear_Halfyear);
                insertCommand.Parameters.AddWithValue("@Clothingfootwear_Annual", Clothingfootwear_Annual);
                insertCommand.Parameters.AddWithValue("@Clothingfootwear_Totallastyear", Clothingfootwear_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Medicalhealth_Fortnight", Medicalhealth_Fortnight);
                insertCommand.Parameters.AddWithValue("@Medicalhealth_Month", Medicalhealth_Month);
                insertCommand.Parameters.AddWithValue("@Medicalhealth_Quarter", Medicalhealth_Quarter);
                insertCommand.Parameters.AddWithValue("@Medicalhealth_Halfyear", Medicalhealth_Halfyear);
                insertCommand.Parameters.AddWithValue("@Medicalhealth_Annual", Medicalhealth_Annual);
                insertCommand.Parameters.AddWithValue("@Medicalhealth_Totallastyear", Medicalhealth_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Recreation_Fortnight", Recreation_Fortnight);
                insertCommand.Parameters.AddWithValue("@Recreation_Month", Recreation_Month);
                insertCommand.Parameters.AddWithValue("@Recreation_Quarter", Recreation_Quarter);
                insertCommand.Parameters.AddWithValue("@Recreation_Halfyear", Recreation_Halfyear);
                insertCommand.Parameters.AddWithValue("@Recreation_Annual", Recreation_Annual);
                insertCommand.Parameters.AddWithValue("@Recreation_Totallastyear", Recreation_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Personalcare_Fortnight", Personalcare_Fortnight);
                insertCommand.Parameters.AddWithValue("@Personalcare_Month", Personalcare_Month);
                insertCommand.Parameters.AddWithValue("@Personalcare_Quarter", Personalcare_Quarter);
                insertCommand.Parameters.AddWithValue("@Personalcare_Halfyear", Personalcare_Halfyear);
                insertCommand.Parameters.AddWithValue("@Personalcare_Annual", Personalcare_Annual);
                insertCommand.Parameters.AddWithValue("@Personalcare_Totallastyear", Personalcare_Totallastyear);
                insertCommand.Parameters.AddWithValue("@PhonePost_Fortnight", PhonePost_Fortnight);
                insertCommand.Parameters.AddWithValue("@PhonePost_Month", PhonePost_Month);
                insertCommand.Parameters.AddWithValue("@PhonePost_Quarter", PhonePost_Quarter);
                insertCommand.Parameters.AddWithValue("@PhonePost_Halfyear", PhonePost_Halfyear);
                insertCommand.Parameters.AddWithValue("@PhonePost_Annual", PhonePost_Annual);
                insertCommand.Parameters.AddWithValue("@PhonePost_Totallastyear", PhonePost_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Travel_Fortnight", Travel_Fortnight);
                insertCommand.Parameters.AddWithValue("@Travel_Month", Travel_Month);
                insertCommand.Parameters.AddWithValue("@Travel_Quarter", Travel_Quarter);
                insertCommand.Parameters.AddWithValue("@Travel_Halfyear", Travel_Halfyear);
                insertCommand.Parameters.AddWithValue("@Travel_Annual", Travel_Annual);
                insertCommand.Parameters.AddWithValue("@Travel_Totallastyear", Travel_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Gifts_Fortnight", Gifts_Fortnight);
                insertCommand.Parameters.AddWithValue("@Gifts_Month", Gifts_Month);
                insertCommand.Parameters.AddWithValue("@Gifts_Quarter", Gifts_Quarter);
                insertCommand.Parameters.AddWithValue("@Gifts_Halfyear", Gifts_Halfyear);
                insertCommand.Parameters.AddWithValue("@Gifts_Annual", Gifts_Annual);
                insertCommand.Parameters.AddWithValue("@Gifts_Totallastyear", Gifts_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Other_Fortnight", Other_Fortnight);
                insertCommand.Parameters.AddWithValue("@Other_Month", Other_Month);
                insertCommand.Parameters.AddWithValue("@Other_Quarter", Other_Quarter);
                insertCommand.Parameters.AddWithValue("@Other_Halfyear", Other_Halfyear);
                insertCommand.Parameters.AddWithValue("@Other_Annual", Other_Annual);
                insertCommand.Parameters.AddWithValue("@Other_Totallastyear", Other_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Ratesinsurance_Fortnight", Ratesinsurance_Fortnight);
                insertCommand.Parameters.AddWithValue("@Ratesinsurance_Month", Ratesinsurance_Month);
                insertCommand.Parameters.AddWithValue("@Ratesinsurance_Quarter", Ratesinsurance_Quarter);
                insertCommand.Parameters.AddWithValue("@Ratesinsurance_Halfyear", Ratesinsurance_Halfyear);
                insertCommand.Parameters.AddWithValue("@Ratesinsurance_Annual", Ratesinsurance_Annual);
                insertCommand.Parameters.AddWithValue("@Ratesinsurance_Totallastyear", Ratesinsurance_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Repairsmaintenance_Fortnight", Repairsmaintenance_Fortnight);
                insertCommand.Parameters.AddWithValue("@Repairsmaintenance_Month", Repairsmaintenance_Month);
                insertCommand.Parameters.AddWithValue("@Repairsmaintenance_Quarter", Repairsmaintenance_Quarter);
                insertCommand.Parameters.AddWithValue("@Repairsmaintenance_Halfyear", Repairsmaintenance_Halfyear);
                insertCommand.Parameters.AddWithValue("@Repairsmaintenance_Annual", Repairsmaintenance_Annual);
                insertCommand.Parameters.AddWithValue("@Repairsmaintenance_Totallastyear", Repairsmaintenance_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Electricitygas_Fortnight", Electricitygas_Fortnight);
                insertCommand.Parameters.AddWithValue("@Electricitygas_Month", Electricitygas_Month);
                insertCommand.Parameters.AddWithValue("@Electricitygas_Quarter", Electricitygas_Quarter);
                insertCommand.Parameters.AddWithValue("@Electricitygas_Halfyear", Electricitygas_Halfyear);
                insertCommand.Parameters.AddWithValue("@Electricitygas_Annual", Electricitygas_Annual);
                insertCommand.Parameters.AddWithValue("@Electricitygas_Totallastyear", Electricitygas_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Houseloanprincipal_Fortnight", Houseloanprincipal_Fortnight);
                insertCommand.Parameters.AddWithValue("@Houseloanprincipal_Month", Houseloanprincipal_Month);
                insertCommand.Parameters.AddWithValue("@Houseloanprincipal_Quarter", Houseloanprincipal_Quarter);
                insertCommand.Parameters.AddWithValue("@Houseloanprincipal_Halfyear", Houseloanprincipal_Halfyear);
                insertCommand.Parameters.AddWithValue("@Houseloanprincipal_Annual", Houseloanprincipal_Annual);
                insertCommand.Parameters.AddWithValue("@Houseloanprincipal_Totallastyear", Houseloanprincipal_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Rentmortgage_Fortnight", Rentmortgage_Fortnight);
                insertCommand.Parameters.AddWithValue("@Rentmortgage_Month", Rentmortgage_Month);
                insertCommand.Parameters.AddWithValue("@Rentmortgage_Quarter", Rentmortgage_Quarter);
                insertCommand.Parameters.AddWithValue("@Rentmortgage_Halfyear", Rentmortgage_Halfyear);
                insertCommand.Parameters.AddWithValue("@Rentmortgage_Annual", Rentmortgage_Annual);
                insertCommand.Parameters.AddWithValue("@Rentmortgage_Totallastyear", Rentmortgage_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Extramortgagepayments_Fortnight", Extramortgagepayments_Fortnight);
                insertCommand.Parameters.AddWithValue("@Extramortgagepayments_Month", Extramortgagepayments_Month);
                insertCommand.Parameters.AddWithValue("@Extramortgagepayments_Quarter", Extramortgagepayments_Quarter);
                insertCommand.Parameters.AddWithValue("@Extramortgagepayments_Halfyear", Extramortgagepayments_Halfyear);
                insertCommand.Parameters.AddWithValue("@Extramortgagepayments_Annual", Extramortgagepayments_Annual);
                insertCommand.Parameters.AddWithValue("@Extramortgagepayments_Totallastyear", Extramortgagepayments_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Furnishingequipment_Fortnight", Furnishingequipment_Fortnight);
                insertCommand.Parameters.AddWithValue("@Furnishingequipment_Month", Furnishingequipment_Month);
                insertCommand.Parameters.AddWithValue("@Furnishingequipment_Quarter", Furnishingequipment_Quarter);
                insertCommand.Parameters.AddWithValue("@Furnishingequipment_Halfyear", Furnishingequipment_Halfyear);
                insertCommand.Parameters.AddWithValue("@Furnishingequipment_Annual", Furnishingequipment_Annual);
                insertCommand.Parameters.AddWithValue("@Furnishingequipment_Totallastyear", Furnishingequipment_Totallastyear);
                insertCommand.Parameters.AddWithValue("@OtherHousing_Fortnight", OtherHousing_Fortnight);
                insertCommand.Parameters.AddWithValue("@OtherHousing_Month", OtherHousing_Month);
                insertCommand.Parameters.AddWithValue("@OtherHousing_Quarter", OtherHousing_Quarter);
                insertCommand.Parameters.AddWithValue("@OtherHousing_Halfyear", OtherHousing_Halfyear);
                insertCommand.Parameters.AddWithValue("@OtherHousing_Annual", OtherHousing_Annual);
                insertCommand.Parameters.AddWithValue("@OtherHousing_Totallastyear", OtherHousing_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Registrationinsurance_Fortnight", Registrationinsurance_Fortnight);
                insertCommand.Parameters.AddWithValue("@Registrationinsurance_Month", Registrationinsurance_Month);
                insertCommand.Parameters.AddWithValue("@Registrationinsurance_Quarter", Registrationinsurance_Quarter);
                insertCommand.Parameters.AddWithValue("@Registrationinsurance_Halfyear", Registrationinsurance_Halfyear);
                insertCommand.Parameters.AddWithValue("@Registrationinsurance_Annual", Registrationinsurance_Annual);
                insertCommand.Parameters.AddWithValue("@Registrationinsurance_Totallastyear", Registrationinsurance_Totallastyear);
                insertCommand.Parameters.AddWithValue("@RepairsmaintenanceTransport_Fortnight", RepairsmaintenanceTransport_Fortnight);
                insertCommand.Parameters.AddWithValue("@RepairsmaintenanceTransport_Month", RepairsmaintenanceTransport_Month);
                insertCommand.Parameters.AddWithValue("@RepairsmaintenanceTransport_Quarter", RepairsmaintenanceTransport_Quarter);
                insertCommand.Parameters.AddWithValue("@RepairsmaintenanceTransport_Halfyear", RepairsmaintenanceTransport_Halfyear);
                insertCommand.Parameters.AddWithValue("@RepairsmaintenanceTransport_Annual", RepairsmaintenanceTransport_Annual);
                insertCommand.Parameters.AddWithValue("@RepairsmaintenanceTransport_Totallastyear", RepairsmaintenanceTransport_Totallastyear);
                insertCommand.Parameters.AddWithValue("@FuelOil_Fortnight", FuelOil_Fortnight);
                insertCommand.Parameters.AddWithValue("@FuelOil_Month", FuelOil_Month);
                insertCommand.Parameters.AddWithValue("@FuelOil_Quarter", FuelOil_Quarter);
                insertCommand.Parameters.AddWithValue("@FuelOil_Halfyear", FuelOil_Halfyear);
                insertCommand.Parameters.AddWithValue("@FuelOil_Annual", FuelOil_Annual);
                insertCommand.Parameters.AddWithValue("@FuelOil_Totallastyear", FuelOil_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Replacementvehicle_Fortnight", Replacementvehicle_Fortnight);
                insertCommand.Parameters.AddWithValue("@Replacementvehicle_Month", Replacementvehicle_Month);
                insertCommand.Parameters.AddWithValue("@Replacementvehicle_Quarter", Replacementvehicle_Quarter);
                insertCommand.Parameters.AddWithValue("@Replacementvehicle_Halfyear", Replacementvehicle_Halfyear);
                insertCommand.Parameters.AddWithValue("@Replacementvehicle_Annual", Replacementvehicle_Annual);
                insertCommand.Parameters.AddWithValue("@Replacementvehicle_Totallastyear", Replacementvehicle_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Fares_Fortnight", Fares_Fortnight);
                insertCommand.Parameters.AddWithValue("@Fares_Month", Fares_Month);
                insertCommand.Parameters.AddWithValue("@Fares_Quarter", Fares_Quarter);
                insertCommand.Parameters.AddWithValue("@Fares_Halfyear", Fares_Halfyear);
                insertCommand.Parameters.AddWithValue("@Fares_Annual", Fares_Annual);
                insertCommand.Parameters.AddWithValue("@Fares_Totallastyear", Fares_Totallastyear);
                insertCommand.Parameters.AddWithValue("@OtherTransport_Fortnight", OtherTransport_Fortnight);
                insertCommand.Parameters.AddWithValue("@OtherTransport_Month", OtherTransport_Month);
                insertCommand.Parameters.AddWithValue("@OtherTransport_Quarter", OtherTransport_Quarter);
                insertCommand.Parameters.AddWithValue("@OtherTransport_Halfyear", OtherTransport_Halfyear);
                insertCommand.Parameters.AddWithValue("@OtherTransport_Annual", OtherTransport_Annual);
                insertCommand.Parameters.AddWithValue("@OtherTransport_Totallastyear", OtherTransport_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Superlifeinsurance_Fortnight", Superlifeinsurance_Fortnight);
                insertCommand.Parameters.AddWithValue("@Superlifeinsurance_Month", Superlifeinsurance_Month);
                insertCommand.Parameters.AddWithValue("@Superlifeinsurance_Quarter", Superlifeinsurance_Quarter);
                insertCommand.Parameters.AddWithValue("@Superlifeinsurance_Halfyear", Superlifeinsurance_Halfyear);
                insertCommand.Parameters.AddWithValue("@Superlifeinsurance_Annual", Superlifeinsurance_Annual);
                insertCommand.Parameters.AddWithValue("@Superlifeinsurance_Totallastyear", Superlifeinsurance_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Loansavings_Fortnight", Loansavings_Fortnight);
                insertCommand.Parameters.AddWithValue("@Loansavings_Month", Loansavings_Month);
                insertCommand.Parameters.AddWithValue("@Loansavings_Quarter", Loansavings_Quarter);
                insertCommand.Parameters.AddWithValue("@Loansavings_Halfyear", Loansavings_Halfyear);
                insertCommand.Parameters.AddWithValue("@Loansavings_Annual", Loansavings_Annual);
                insertCommand.Parameters.AddWithValue("@Loansavings_Totallastyear", Loansavings_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Carloan_Fortnight", Carloan_Fortnight);
                insertCommand.Parameters.AddWithValue("@Carloan_Month", Carloan_Month);
                insertCommand.Parameters.AddWithValue("@Carloan_Quarter", Carloan_Quarter);
                insertCommand.Parameters.AddWithValue("@Carloan_Halfyear", Carloan_Halfyear);
                insertCommand.Parameters.AddWithValue("@Carloan_Annual", Carloan_Annual);
                insertCommand.Parameters.AddWithValue("@Carloan_Totallastyear", Carloan_Totallastyear);
                insertCommand.Parameters.AddWithValue("@OtherGeneral_Fortnight", OtherGeneral_Fortnight);
                insertCommand.Parameters.AddWithValue("@OtherGeneral_Month", OtherGeneral_Month);
                insertCommand.Parameters.AddWithValue("@OtherGeneral_Quarter", OtherGeneral_Quarter);
                insertCommand.Parameters.AddWithValue("@OtherGeneral_Halfyear", OtherGeneral_Halfyear);
                insertCommand.Parameters.AddWithValue("@OtherGeneral_Annual", OtherGeneral_Annual);
                insertCommand.Parameters.AddWithValue("@OtherGeneral_Totallastyear", OtherGeneral_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Foodliquid_Fortnight", Foodliquid_Fortnight);
                insertCommand.Parameters.AddWithValue("@Foodliquid_Month", Foodliquid_Month);
                insertCommand.Parameters.AddWithValue("@Foodliquid_Quarter", Foodliquid_Quarter);
                insertCommand.Parameters.AddWithValue("@Foodliquid_Halfyear", Foodliquid_Halfyear);
                insertCommand.Parameters.AddWithValue("@Foodliquid_Annual", Foodliquid_Annual);
                insertCommand.Parameters.AddWithValue("@Foodliquid_Totallastyear", Foodliquid_Totallastyear);
                insertCommand.Parameters.AddWithValue("@ClothingfootwearChildren_Fortnight", ClothingfootwearChildren_Fortnight);
                insertCommand.Parameters.AddWithValue("@ClothingfootwearChildren_Month", ClothingfootwearChildren_Month);
                insertCommand.Parameters.AddWithValue("@ClothingfootwearChildren_Quarter", ClothingfootwearChildren_Quarter);
                insertCommand.Parameters.AddWithValue("@ClothingfootwearChildren_Halfyear", ClothingfootwearChildren_Halfyear);
                insertCommand.Parameters.AddWithValue("@ClothingfootwearChildren_Annual", ClothingfootwearChildren_Annual);
                insertCommand.Parameters.AddWithValue("@ClothingfootwearChildren_Totallastyear", ClothingfootwearChildren_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Education_Fortnight", Education_Fortnight);
                insertCommand.Parameters.AddWithValue("@Education_Month", Education_Month);
                insertCommand.Parameters.AddWithValue("@Education_Quarter", Education_Quarter);
                insertCommand.Parameters.AddWithValue("@Education_Halfyear", Education_Halfyear);
                insertCommand.Parameters.AddWithValue("@Education_Annual", Education_Annual);
                insertCommand.Parameters.AddWithValue("@Education_Totallastyear", Education_Totallastyear);
                insertCommand.Parameters.AddWithValue("@OtherChildren_Fortnight", OtherChildren_Fortnight);
                insertCommand.Parameters.AddWithValue("@OtherChildren_Month", OtherChildren_Month);
                insertCommand.Parameters.AddWithValue("@OtherChildren_Quarter", OtherChildren_Quarter);
                insertCommand.Parameters.AddWithValue("@OtherChildren_Halfyear", OtherChildren_Halfyear);
                insertCommand.Parameters.AddWithValue("@OtherChildren_Annual", OtherChildren_Annual);
                insertCommand.Parameters.AddWithValue("@OtherChildren_Totallastyear", OtherChildren_Totallastyear);
                insertCommand.Parameters.AddWithValue("@Total_Fortnight", Total_Fortnight);
                insertCommand.Parameters.AddWithValue("@Total_Month", Total_Month);
                insertCommand.Parameters.AddWithValue("@Total_Quarter", Total_Quarter);
                insertCommand.Parameters.AddWithValue("@Total_Halfyear", Total_Halfyear);
                insertCommand.Parameters.AddWithValue("@Total_Annual", Total_Annual);
                insertCommand.Parameters.AddWithValue("@Total_Totallastyear", Total_Totallastyear);
                insertCommand.Parameters.AddWithValue("@FileNotes_FileName", FileNotes_FileName);
                insertCommand.Parameters.AddWithValue("@FileNotes_FilePath", FileNotes_FilePath);

                insertCommand.ExecuteReader();

                FileNotes_FileName = "FileNotesSelectionB_" + _CoverPageID.ToString() + ".jpg";
                FileNotesCentrelink_FileName = "FileNotesSelectionBCentrelink_" + _CoverPageID.ToString() + ".jpg";

                SqliteCommand insertCommand2 = new SqliteCommand();
                insertCommand2.Connection = db;
                insertCommand2.CommandText = "UPDATE SelectionBFinancialSummary SET FileNotes_FileName = @FileNotes_FileName, FileNotesCentrelink_FileName = @FileNotesCentrelink_FileName WHERE CoverPageID = @ID";
                insertCommand2.Parameters.AddWithValue("@ID", _CoverPageID);
                insertCommand2.Parameters.AddWithValue("@FileNotes_FileName", FileNotes_FileName);
                insertCommand2.Parameters.AddWithValue("@FileNotesCentrelink_FileName", FileNotesCentrelink_FileName);
                insertCommand2.ExecuteReader();

                db.Close();
            }
        }
        #endregion

        //public static List<String> GetData()
        //{
        //    List<String> entries = new List<string>();

        //    //string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
        //    using (SqliteConnection db =
        //       new SqliteConnection($"Filename={dbpath}"))
        //    {
        //        db.Open();

        //        SqliteCommand selectCommand = new SqliteCommand
        //            ("SELECT Text_Entry from MyTable", db);

        //        SqliteDataReader query = selectCommand.ExecuteReader();

        //        while (query.Read())
        //        {
        //            entries.Add(query.GetString(0));
        //        }

        //        db.Close();
        //    }

        //    return entries;
        //}

        public static DataTable getCoverPageData(int coverPageID)
        {
            SqliteConnection connstr = new SqliteConnection(@"Data Source=ticdb.db;");
            connstr.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connstr;
            cmd.CommandText = "select ID,PreparedFor,YourAdviser,DateValue,FileNotes_FileName,FileNotes_FilePath from CoverPage where ID = " + coverPageID.ToString();
            SqliteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            connstr.Close();

            return dt;
        }

        public static DataTable getSelectionAPersonalDetails(int coverPageID)
        {
            SqliteConnection connstr = new SqliteConnection(@"Data Source=ticdb.db;");
            connstr.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connstr;
            cmd.CommandText = "select * from SelectionAPersonalDetails where CoverPageID = " + coverPageID.ToString();
            SqliteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            connstr.Close();

            return dt;
        }

        public static DataTable getSelectionBFinancialSummary(int coverPageID)
        {
            SqliteConnection connstr = new SqliteConnection(@"Data Source=ticdb.db;");
            connstr.Open();
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = connstr;
            cmd.CommandText = "select * from SelectionBFinancialSummary where CoverPageID = " + coverPageID.ToString();
            SqliteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            connstr.Close();

            return dt;
        }

    }
}
