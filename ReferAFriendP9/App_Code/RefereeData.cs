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
    public class RefereeData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int RegistrationID { get; set; }
        public int CenterID { get; set; }
        public int BankID { get; set; }
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
        public string AccountHolderName { get; set; }
        public string IFSC { get; set; }

        #region Referee Registration function
        public void RefereeRegistration(RefereeData objReferee)
        {
            string CS = ConfigurationManager.ConnectionStrings["ReferAFriendCS"].ConnectionString;

            using (SqlConnection connect = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("insert into tblReferee (Name, Email, Mobile, RegistrationID, CentreID, BankID, AccountType, AccountNo, AccountHolderName, IFSC) values(@Name, @Email, @Mobile, @RegistrationID, @CentreID, @BankID, @AccountType, @AccountNo, @AccountHolderName, @IFSC)"))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    cmd.Parameters.AddWithValue("@Name", objReferee.Name);
                    cmd.Parameters.AddWithValue("@Email", objReferee.Email);
                    cmd.Parameters.AddWithValue("@Mobile", objReferee.Mobile);
                    cmd.Parameters.AddWithValue("@RegistrationID", objReferee.RegistrationID);
                    cmd.Parameters.AddWithValue("@CentreID", objReferee.CenterID);
                    cmd.Parameters.AddWithValue("@BankID", objReferee.BankID);
                    cmd.Parameters.AddWithValue("@AccountType", objReferee.AccountType);
                    cmd.Parameters.AddWithValue("@AccountNo", objReferee.AccountNo);
                    cmd.Parameters.AddWithValue("@AccountHolderName", objReferee.AccountHolderName);
                    cmd.Parameters.AddWithValue("@IFSC", objReferee.IFSC);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}