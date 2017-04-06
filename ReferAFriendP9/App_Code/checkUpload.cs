using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for RefereeData
/// </summary>
namespace ReferAFriend
{
    public class checkUpload
    {

        public int ID { get; set; }
        public string NSDCRegistrationNumber { get; set; }
        public string ProposalNumber { get; set; }
        public string SDMSEnrolmentNumber { get; set; }
        public string CentreID { get; set; }
        public string TPEnrollmentnumber { get; set; }
        public string Salutation { get; set; }
        public string FirstNameCandidate { get; set; }
        public string LastNameCandidate { get; set; }
        public string GuardianType { get; set; }
        public string MaritalStatus { get; set; }
        public string DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string FirstNameofFatherGuardian { get; set; }
        public string LastNameofFatherGuardian { get; set; }
        public string MotherMaidenName { get; set; }
        public string AadhaarEnrollmentNumber { get; set; }
        public string Aadhaarno { get; set; }
        public string RationCardNumber { get; set; }
        public string Gender { get; set; }
        public string CasteCategory { get; set; }
        public string Disability { get; set; }
        public string Religion { get; set; }
        public string TraineeAddress { get; set; }
        public string TcState { get; set; }
        public string TcDistrict { get; set; }
        public string PINCode { get; set; }
        public string ContactnoofTrainee { get; set; }
        public string TypeofMobile { get; set; }
        public string EmailIDofTrainee { get; set; }
        public string PreTrainingStatus { get; set; }
        public string Noofyearsofpreviousexperience { get; set; }
        public string Noofmonthsofpreviousexperience { get; set; }
        public string EducationLevel { get; set; }
        public string TechnicalEducation { get; set; }
        public string SectorCovered { get; set; }
        public string CourseID { get; set; }
        public string CourseFee { get; set; }
        public string TrainerID { get; set; }
        public string FeePaidBy { get; set; }
        public string BatchStartDate { get; set; }
        public string BatchEndDate { get; set; }
        public string TrainingStatus { get; set; }
        public string DataSubmittedForMonth { get; set; }
        public string DataSubmittedForYear { get; set; }
        public string Attendance { get; set; }
        public string PassingoutDate { get; set; }
        public string Grade { get; set; }
        public string Certified { get; set; }
        public string CertificationDate { get; set; }
        public string CertificatenameOrAward { get; set; }
        public string Certificateno { get; set; }
        public string AssessmentDate { get; set; }
        public string Agency { get; set; }
        public string Assessor { get; set; }
        public string CertifyingAgency { get; set; }
        public string PlacementStatus { get; set; }
        public string EmploymentType { get; set; }
        public string Apprenticeship { get; set; }
        public string Undertakingforselfemployedcollectedfromthetrainee { get; set; }
        public string Proofofupskillingprovided { get; set; }
        public string Typeofproof { get; set; }
        public string DateofJoining { get; set; }
        public string EmployerNameOrSelfEmployed { get; set; }
        public string EmployerContactPersonName { get; set; }
        public string EmployerContactPersonDesignation { get; set; }
        public string EmployercontactNo { get; set; }
        public string LocationofemployerState { get; set; }
        public string LocationofemployerDistrict { get; set; }
        public string Feedbackcollectedfromemployer { get; set; }
        public string frequencyoffeedback { get; set; }
        public string StateofplacementORwork { get; set; }
        public string DistrictofplacementORwork { get; set; }
        public string MonthlyEarningOrCTCbeforeTraining { get; set; }
        public string BelowPovertyLine { get; set; }
        public string AnnualHouseholdIncome { get; set; }
        public string PassportNumber { get; set; }
        public string ValidityDate { get; set; }
        public string SkillingCategory { get; set; }

        public string SourceofFunding { get; set; }

        public string BankName { get; set; }


        public string BranchAddress { get; set; }

        public string IfscCode { get; set; }

        public string BankAccountNumber { get; set; }

        public string MonthlyCurrentCTCOrearning { get; set; }
        //public string CentreName { get; set; }
    }
}