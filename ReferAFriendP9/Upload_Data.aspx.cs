using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using ReferAFriend;

public partial class Upload_Data : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        File1.Attributes["onchange"] = "CheckFile(this)";
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["LogIn"]) == 1)
            {
                string CS = ConfigurationManager.ConnectionStrings["ReferAFriendCS"].ConnectionString;

                using (SqlConnection connect = new SqlConnection(CS)) //binds Centers to the Drop down list
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from tblCentre"))
                    {
                        cmd.Connection = connect;
                        connect.Open();
                        ddlCenter.Items.Clear();
                        ddlCenter.DataSource = cmd.ExecuteReader();
                        ddlCenter.DataTextField = "CentreName";
                        ddlCenter.DataValueField = "id";
                        ddlCenter.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ReferAFriendCS"].ConnectionString;
        
        string excelfile = File1.PostedFile.FileName;
        if (excelfile.EndsWith("xls") || excelfile.EndsWith("xlsx"))
        {
            string path = Server.MapPath("~/UploadedExcel/" + excelfile);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            File1.SaveAs(path);

            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(path);
            Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
            Excel.Range range = worksheet.UsedRange;
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            
            //try
            {
                List<checkUpload> datacheckUpload = new List<checkUpload>();
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    if (((Excel.Range)range.Cells[row, 1]).Text.ToString()!="")
                    {
                        datacheckUpload.Add(new checkUpload
                        {
                            NSDCRegistrationNumber = ((Excel.Range)range.Cells[row, 1]).Text.ToString(),
                            ProposalNumber = ((Excel.Range)range.Cells[row, 2]).Text.ToString(),
                            SDMSEnrolmentNumber = ((Excel.Range)range.Cells[row, 3]).Text.ToString(),
                            CentreID = ((Excel.Range)range.Cells[row, 4]).Text.ToString(),
                            TPEnrollmentnumber = ((Excel.Range)range.Cells[row, 5]).Text.ToString(),
                            Salutation = ((Excel.Range)range.Cells[row, 6]).Text.ToString(),
                            FirstNameCandidate = ((Excel.Range)range.Cells[row, 7]).Text.ToString(),
                            LastNameCandidate = ((Excel.Range)range.Cells[row, 8]).Text.ToString(),
                            GuardianType = ((Excel.Range)range.Cells[row, 9]).Text.ToString(),
                            MaritalStatus = ((Excel.Range)range.Cells[row, 10]).Text.ToString(),
                            DateofBirth = ((Excel.Range)range.Cells[row, 11]).Text.ToString(),
                            PlaceofBirth = ((Excel.Range)range.Cells[row, 12]).Text.ToString(),
                            FirstNameofFatherGuardian = ((Excel.Range)range.Cells[row, 13]).Text.ToString(),
                            LastNameofFatherGuardian = ((Excel.Range)range.Cells[row, 14]).Text.ToString(),
                            MotherMaidenName = ((Excel.Range)range.Cells[row, 15]).Text.ToString(),
                            AadhaarEnrollmentNumber = ((Excel.Range)range.Cells[row, 16]).Text.ToString(),
                            Aadhaarno = ((Excel.Range)range.Cells[row, 17]).Text.ToString(),
                            RationCardNumber = ((Excel.Range)range.Cells[row, 18]).Text.ToString(),
                            Gender = ((Excel.Range)range.Cells[row, 19]).Text.ToString(),
                            CasteCategory = ((Excel.Range)range.Cells[row, 20]).Text.ToString(),
                            Disability = ((Excel.Range)range.Cells[row, 21]).Text.ToString(),
                            Religion = ((Excel.Range)range.Cells[row, 22]).Text.ToString(),
                            
                            TraineeAddress = ((Excel.Range)range.Cells[row, 23]).Text.ToString(),
                            TcState = ((Excel.Range)range.Cells[row, 24]).Text.ToString(),
                            TcDistrict = ((Excel.Range)range.Cells[row, 25]).Text.ToString(),
                            PINCode = ((Excel.Range)range.Cells[row, 26]).Text.ToString(),
                            ContactnoofTrainee = ((Excel.Range)range.Cells[row, 27]).Text.ToString(),
                            TypeofMobile = ((Excel.Range)range.Cells[row, 28]).Text.ToString(),
                            EmailIDofTrainee = ((Excel.Range)range.Cells[row, 29]).Text.ToString(),
                            PreTrainingStatus = ((Excel.Range)range.Cells[row, 30]).Text.ToString(),
                            Noofyearsofpreviousexperience = ((Excel.Range)range.Cells[row, 31]).Text.ToString(),
                            Noofmonthsofpreviousexperience = ((Excel.Range)range.Cells[row, 32]).Text.ToString(),
                            EducationLevel = ((Excel.Range)range.Cells[row, 33]).Text.ToString(),
                            TechnicalEducation = ((Excel.Range)range.Cells[row, 34]).Text.ToString(),
                            SectorCovered = ((Excel.Range)range.Cells[row, 35]).Text.ToString(),
                            CourseID = ((Excel.Range)range.Cells[row, 36]).Text.ToString(),
                            CourseFee = ((Excel.Range)range.Cells[row, 37]).Text.ToString(),

                          

                            TrainerID = ((Excel.Range)range.Cells[row, 38]).Text.ToString(),
                            FeePaidBy = ((Excel.Range)range.Cells[row, 39]).Text.ToString(),
                            BatchStartDate = ((Excel.Range)range.Cells[row, 40]).Text.ToString(),
                            BatchEndDate = ((Excel.Range)range.Cells[row, 41]).Text.ToString(),
                            TrainingStatus = ((Excel.Range)range.Cells[row, 42]).Text.ToString(),
                            DataSubmittedForMonth = ((Excel.Range)range.Cells[row, 43]).Text.ToString(),
                            DataSubmittedForYear = ((Excel.Range)range.Cells[row, 44]).Text.ToString(),
                            Attendance = ((Excel.Range)range.Cells[row, 45]).Text.ToString(),
                            PassingoutDate = ((Excel.Range)range.Cells[row, 46]).Text.ToString(),
                            Grade = ((Excel.Range)range.Cells[row, 47]).Text.ToString(),
                            Certified = ((Excel.Range)range.Cells[row, 48]).Text.ToString(),
                            CertificationDate = ((Excel.Range)range.Cells[row, 49]).Text.ToString(),
                            CertificatenameOrAward = ((Excel.Range)range.Cells[row, 50]).Text.ToString(),
                            Certificateno = ((Excel.Range)range.Cells[row, 51]).Text.ToString(),
                            AssessmentDate = ((Excel.Range)range.Cells[row, 52]).Text.ToString(),
                            Agency = ((Excel.Range)range.Cells[row, 53]).Text.ToString(),
                            Assessor = ((Excel.Range)range.Cells[row, 54]).Text.ToString(),
                            CertifyingAgency = ((Excel.Range)range.Cells[row, 55]).Text.ToString(),
                           
                            PlacementStatus = ((Excel.Range)range.Cells[row, 56]).Text.ToString(),
                            EmploymentType = ((Excel.Range)range.Cells[row, 57]).Text.ToString(),
                            Apprenticeship = ((Excel.Range)range.Cells[row, 58]).Text.ToString(),
                            Undertakingforselfemployedcollectedfromthetrainee = ((Excel.Range)range.Cells[row, 59]).Text.ToString(),
                            Proofofupskillingprovided = ((Excel.Range)range.Cells[row, 60]).Text.ToString(),
                            Typeofproof = ((Excel.Range)range.Cells[row, 61]).Text.ToString(),
                            DateofJoining = ((Excel.Range)range.Cells[row, 62]).Text.ToString(),
                            EmployerNameOrSelfEmployed = ((Excel.Range)range.Cells[row,63]).Text.ToString(),
                            EmployerContactPersonName = ((Excel.Range)range.Cells[row, 64]).Text.ToString(),
                            EmployerContactPersonDesignation = ((Excel.Range)range.Cells[row, 65]).Text.ToString(),

                            EmployercontactNo = ((Excel.Range)range.Cells[row, 66]).Text.ToString(),
                            LocationofemployerState = ((Excel.Range)range.Cells[row, 67]).Text.ToString(),
                            LocationofemployerDistrict = ((Excel.Range)range.Cells[row, 68]).Text.ToString(),
                            Feedbackcollectedfromemployer = ((Excel.Range)range.Cells[row, 69]).Text.ToString(),
                            frequencyoffeedback = ((Excel.Range)range.Cells[row, 70]).Text.ToString(),
                            StateofplacementORwork = ((Excel.Range)range.Cells[row, 71]).Text.ToString(),
                            DistrictofplacementORwork = ((Excel.Range)range.Cells[row, 72]).Text.ToString(),
                            MonthlyEarningOrCTCbeforeTraining = ((Excel.Range)range.Cells[row, 73]).Text.ToString(),
                            MonthlyCurrentCTCOrearning = ((Excel.Range)range.Cells[row, 74]).Text.ToString(),

                            BelowPovertyLine = ((Excel.Range)range.Cells[row, 75]).Text.ToString(),
                            AnnualHouseholdIncome = ((Excel.Range)range.Cells[row, 76]).Text.ToString(),
                            PassportNumber = ((Excel.Range)range.Cells[row, 77]).Text.ToString(),
                            ValidityDate = ((Excel.Range)range.Cells[row, 78]).Text.ToString(),
                            SkillingCategory = ((Excel.Range)range.Cells[row, 79]).Text.ToString(),
                            SourceofFunding = ((Excel.Range)range.Cells[row, 80]).Text.ToString(),
                            BankName = ((Excel.Range)range.Cells[row, 81]).Text.ToString(),
                            BranchAddress = ((Excel.Range)range.Cells[row, 82]).Text.ToString(),
                            IfscCode = ((Excel.Range)range.Cells[row, 83]).Text.ToString(),
                            BankAccountNumber = ((Excel.Range)range.Cells[row, 84]).Text.ToString(),
                            
                        });
                    }
                    else
                    {
                        goto here;
                    }
                }
                here:
                foreach (var item in datacheckUpload)
                {
                    if (item.NSDCRegistrationNumber!="")
                    {
                        string query = "insert into checkUpload (NSDCRegistrationNumber, ProposalNumber, SDMSEnrolmentNumber, CentreID,TPEnrollmentnumber, "+
                            "Salutation, FirstNameCandidate, LastNameCandidate, GuardianType, MaritalStatus, "+
                            "DateofBirth, PlaceofBirth, FirstNameofFatherGuardian, LastNameofFatherGuardian,MotherMaidenName,"+
                            "AadhaarEnrollmentNumber,Aadhaarno, RationCardNumber,Gender,CasteCategory, "+
                            "Disability, Religion, TraineeAddress,TcState, TcDistrict,"+
                            "PINCode, ContactnoofTrainee, TypeofMobile, EmailIDofTrainee, PreTrainingStatus, Noofyearsofpreviousexperience," +
                            "Noofmonthsofpreviousexperience, EducationLevel,TechnicalEducation, SectorCovered, CourseID, CourseFee,TrainerID, FeePaidBy,"+
                            "BatchStartDate,BatchEndDate,TrainingStatus,DataSubmittedForMonth,DataSubmittedForYear,Attendance,PassingoutDate,Grade, Certified,"+
                            "CertificationDate,CertificatenameOrAward,Certificateno,AssessmentDate,Agency,Assessor,CertifyingAgency,PlacementStatus,"+
                            "EmploymentType,Apprenticeship,Undertakingforselfemployedcollectedfromthetrainee,Proofofupskillingprovided,Typeofproof,DateofJoining,"+
                            "EmployerNameOrSelfEmployed,EmployerContactPersonName,EmployerContactPersonDesignation,EmployercontactNo, LocationofemployerState,"+
                            "LocationofemployerDistrict, Feedbackcollectedfromemployer, frequencyoffeedback, StateofplacementORwork,DistrictofplacementORwork,"+
                            "MonthlyEarningOrCTCbeforeTraining,MonthlyCurrentCTCOrearning, BelowPovertyLine, AnnualHouseholdIncome, PassportNumber,ValidityDate,SkillingCategory,SourceofFunding,BankName,BranchAddress,IfscCode,BankAccountNumber, CentreName) values" + 
                            "(@NSDCRegistrationNumber, @ProposalNumber, @SDMSEnrolmentNumber, @CentreID, "+
                            "@TPEnrollmentnumber, @Salutation, @FirstNameCandidate, @LastNameCandidate, @GuardianType, "+
                            "@MaritalStatus, @DateofBirth, @PlaceofBirth, @FirstNameofFatherGuardian, @LastNameofFatherGuardian, "+
                            "@MotherMaidenName, @AadhaarEnrollmentNumber, @Aadhaarno, @RationCardNumber, @Gender, "+
                            "@CasteCategory, @Disability, @Religion, @TraineeAddress,@TcState, "+
                            "@TcDistrict,@PINCode, @ContactnoofTrainee, @TypeofMobile, @EmailIDofTrainee, @PreTrainingStatus, " +
                            "@Noofyearsofpreviousexperience, @Noofmonthsofpreviousexperience, @EducationLevel,@TechnicalEducation, @SectorCovered, @CourseID, @CourseFee, "+
                            "@TrainerID, @FeePaidBy, @BatchStartDate, @BatchEndDate, @TrainingStatus,@DataSubmittedForMonth,@DataSubmittedForYear,@Attendance, "+
                            "@PassingoutDate, @Grade, @Certified, @CertificationDate,@CertificatenameOrAward,@Certificateno,@AssessmentDate, @Agency, @Assessor, "+
                            "@CertifyingAgency, @PlacementStatus,@EmploymentType,@Apprenticeship, @Undertakingforselfemployedcollectedfromthetrainee,"+
                            "@Proofofupskillingprovided, @Typeofproof,@DateofJoining,@EmployerNameOrSelfEmployed,@EmployerContactPersonName,"+
                            "@EmployerContactPersonDesignation, @EmployercontactNo, @LocationofemployerState, @LocationofemployerDistrict, @Feedbackcollectedfromemployer, "+
                            "@frequencyoffeedback, @StateofplacementORwork,@DistrictofplacementORwork, @MonthlyEarningOrCTCbeforeTraining,@MonthlyCurrentCTCOrearning, @BelowPovertyLine, " +
                            "@AnnualHouseholdIncome, @PassportNumber, @ValidityDate, @SkillingCategory,@SourceofFunding,@BankName,@BranchAddress,@IfscCode,@BankAccountNumber, @CentreName)";
                        using (SqlConnection connect = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = connect;
                                connect.Open();
                                cmd.Parameters.AddWithValue("@NSDCRegistrationNumber", item.NSDCRegistrationNumber);
                                cmd.Parameters.AddWithValue("@ProposalNumber", item.ProposalNumber);
                                cmd.Parameters.AddWithValue("@SDMSEnrolmentNumber", item.SDMSEnrolmentNumber);
                                cmd.Parameters.AddWithValue("@CentreID", item.CentreID);
                                cmd.Parameters.AddWithValue("@TPEnrollmentnumber", item.TPEnrollmentnumber);
                                cmd.Parameters.AddWithValue("@Salutation", item.Salutation);
                                cmd.Parameters.AddWithValue("@FirstNameCandidate", item.FirstNameCandidate);
                                cmd.Parameters.AddWithValue("@LastNameCandidate", item.LastNameCandidate);
                                cmd.Parameters.AddWithValue("@GuardianType", item.GuardianType);
                                cmd.Parameters.AddWithValue("@MaritalStatus", item.MaritalStatus);
                                cmd.Parameters.AddWithValue("@DateofBirth", item.DateofBirth);
                                cmd.Parameters.AddWithValue("@PlaceofBirth", item.PlaceofBirth);
                                cmd.Parameters.AddWithValue("@FirstNameofFatherGuardian", item.FirstNameofFatherGuardian);
                                cmd.Parameters.AddWithValue("@LastNameofFatherGuardian", item.LastNameofFatherGuardian);
                                cmd.Parameters.AddWithValue("@MotherMaidenName", item.MotherMaidenName);
                                cmd.Parameters.AddWithValue("@AadhaarEnrollmentNumber", item.AadhaarEnrollmentNumber);
                                cmd.Parameters.AddWithValue("@Aadhaarno", item.Aadhaarno);
                                cmd.Parameters.AddWithValue("@RationCardNumber", item.RationCardNumber);
                                cmd.Parameters.AddWithValue("@Gender", item.Gender);
                                cmd.Parameters.AddWithValue("@CasteCategory", item.CasteCategory);
                                cmd.Parameters.AddWithValue("@Disability", item.Disability);
                                cmd.Parameters.AddWithValue("@Religion", item.Religion);
                                cmd.Parameters.AddWithValue("@TraineeAddress", item.TraineeAddress);
                                cmd.Parameters.AddWithValue("@TcState", item.TcState);
                                cmd.Parameters.AddWithValue("@TcDistrict", item.TcDistrict);
                                cmd.Parameters.AddWithValue("@PINCode", item.PINCode);
                                cmd.Parameters.AddWithValue("@ContactnoofTrainee", item.ContactnoofTrainee);
                                cmd.Parameters.AddWithValue("@TypeofMobile", item.TypeofMobile);
                                cmd.Parameters.AddWithValue("@EmailIDofTrainee", item.EmailIDofTrainee);
                                cmd.Parameters.AddWithValue("@PreTrainingStatus", item.PreTrainingStatus);
                                cmd.Parameters.AddWithValue("@Noofyearsofpreviousexperience", item.Noofyearsofpreviousexperience);
                                cmd.Parameters.AddWithValue("@Noofmonthsofpreviousexperience", item.Noofmonthsofpreviousexperience);
                                cmd.Parameters.AddWithValue("@EducationLevel", item.EducationLevel);
                                cmd.Parameters.AddWithValue("@TechnicalEducation", item.TechnicalEducation);
                                cmd.Parameters.AddWithValue("@SectorCovered", item.SectorCovered);
                                cmd.Parameters.AddWithValue("@CourseID", item.CourseID);
                                cmd.Parameters.AddWithValue("@CourseFee", item.CourseFee);

                                cmd.Parameters.AddWithValue("@TrainerID", item.TrainerID);
                                cmd.Parameters.AddWithValue("@FeePaidBy", item.FeePaidBy);
                                cmd.Parameters.AddWithValue("@BatchStartDate", item.BatchStartDate);
                                cmd.Parameters.AddWithValue("@BatchEndDate", item.BatchEndDate);
                                cmd.Parameters.AddWithValue("@TrainingStatus", item.TrainingStatus);
                                cmd.Parameters.AddWithValue("@DataSubmittedForMonth", item.DataSubmittedForMonth);
                                cmd.Parameters.AddWithValue("@DataSubmittedForYear", item.DataSubmittedForYear);
                                cmd.Parameters.AddWithValue("@Attendance", item.Attendance);
                                cmd.Parameters.AddWithValue("@PassingoutDate", item.PassingoutDate);
                                cmd.Parameters.AddWithValue("@Grade", item.Grade);
                                cmd.Parameters.AddWithValue("@Certified", item.Certified);
                                cmd.Parameters.AddWithValue("@CertificationDate", item.CertificationDate);
                                cmd.Parameters.AddWithValue("@CertificatenameOrAward", item.CertificatenameOrAward);
                                cmd.Parameters.AddWithValue("@Certificateno", item.Certificateno);
                                cmd.Parameters.AddWithValue("@AssessmentDate", item.AssessmentDate);
                                cmd.Parameters.AddWithValue("@Agency", item.Agency);
                                cmd.Parameters.AddWithValue("@Assessor", item.Assessor);
                                cmd.Parameters.AddWithValue("@CertifyingAgency", item.CertifyingAgency);
                                cmd.Parameters.AddWithValue("@PlacementStatus", item.PlacementStatus);
                                
                                cmd.Parameters.AddWithValue("@EmploymentType", item.EmploymentType);
                                cmd.Parameters.AddWithValue("@Apprenticeship", item.Apprenticeship);
                                cmd.Parameters.AddWithValue("@Undertakingforselfemployedcollectedfromthetrainee", item.Undertakingforselfemployedcollectedfromthetrainee);
                                cmd.Parameters.AddWithValue("@Proofofupskillingprovided", item.Proofofupskillingprovided);
                                cmd.Parameters.AddWithValue("@Typeofproof", item.Typeofproof);
                                cmd.Parameters.AddWithValue("@DateofJoining", item.DateofJoining);
                                cmd.Parameters.AddWithValue("@EmployerNameOrSelfEmployed", item.EmployerNameOrSelfEmployed);
                                cmd.Parameters.AddWithValue("@EmployerContactPersonName", item.EmployerContactPersonName);
                                cmd.Parameters.AddWithValue("@EmployerContactPersonDesignation", item.EmployerContactPersonDesignation);
                                
                                cmd.Parameters.AddWithValue("@EmployercontactNo", item.EmployercontactNo);
                                cmd.Parameters.AddWithValue("@LocationofemployerState", item.LocationofemployerState);
                                cmd.Parameters.AddWithValue("@LocationofemployerDistrict", item.LocationofemployerDistrict);
                                cmd.Parameters.AddWithValue("@Feedbackcollectedfromemployer", item.Feedbackcollectedfromemployer);
                                cmd.Parameters.AddWithValue("@frequencyoffeedback", item.frequencyoffeedback);
                                cmd.Parameters.AddWithValue("@StateofplacementORwork", item.StateofplacementORwork);
                                cmd.Parameters.AddWithValue("@DistrictofplacementORwork", item.DistrictofplacementORwork);
                                cmd.Parameters.AddWithValue("@MonthlyEarningOrCTCbeforeTraining", item.MonthlyEarningOrCTCbeforeTraining);
                                cmd.Parameters.AddWithValue("@MonthlyCurrentCTCOrearning", item.MonthlyCurrentCTCOrearning);

                                cmd.Parameters.AddWithValue("@BelowPovertyLine", item.BelowPovertyLine);
                                cmd.Parameters.AddWithValue("@AnnualHouseholdIncome", item.AnnualHouseholdIncome);
                                cmd.Parameters.AddWithValue("@PassportNumber", item.PassportNumber);
                                cmd.Parameters.AddWithValue("@ValidityDate", item.ValidityDate);
                                cmd.Parameters.AddWithValue("@SkillingCategory", item.SkillingCategory);
                                cmd.Parameters.AddWithValue("@SourceofFunding", item.SourceofFunding);
                                cmd.Parameters.AddWithValue("@BankName", item.BankName);
                                cmd.Parameters.AddWithValue("@BranchAddress", item.BranchAddress);
                                cmd.Parameters.AddWithValue("@IfscCode", item.IfscCode);
                                cmd.Parameters.AddWithValue("@BankAccountNumber", item.BankAccountNumber);
                                cmd.Parameters.AddWithValue("@CentreName", ddlCenter.SelectedItem.ToString());
                                
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                workbook.Close(true, null, null);

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(application);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Spreadsheet has been uploaded.')", true);

            }




            //catch
            //{

            //}
        }
    }

    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["centreName"] = ddlCenter.SelectedItem.ToString();
    }
}