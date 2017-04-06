using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using ReferAFriend;

public partial class RefereeRegistration : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ReferAFriendCS"].ConnectionString;
        if (!IsPostBack)
        {
            using (SqlConnection connect = new SqlConnection(CS)) //binds Centers to the Drop down list
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblCentre"))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    ddlCenter.Items.Clear();
                    ddlCenter.DataSource = cmd.ExecuteReader();
                    ddlCenter.DataTextField = "CentreName";
                    ddlCenter.DataValueField = "NSDCCentreID";
                    ddlCenter.DataBind();
                    //ddlCenter.Items.Insert(0, new ListItem("Select", "-1"));
                    //ddlCenter.Items.Insert(0, new ListItem("--Select--"));
                    //ddlCenter.SelectedIndex = 0;
                }
            }
            using (SqlConnection connect = new SqlConnection(CS)) //binds banks to the Drop down list
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblBanks"))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    ddlBank.DataSource = cmd.ExecuteReader();
                    ddlBank.DataTextField = "BankName";
                    ddlBank.DataValueField = "id";
                    ddlBank.DataBind();
                    //ddlCenter.Items.Insert(0, new ListItem("Select", "-1"));
                    //ddlBank.Items.Insert(0, new ListItem("--Select--"));
                    //ddlBank.SelectedIndex = 0;
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int Center = 0, Bank = 0, emailCount = 0, BankCount = 0, regIDCount = 0;
        string name;

        string CS = ConfigurationManager.ConnectionStrings["ReferAFriendCS"].ConnectionString;
        #region EMAIL COUNT
        using (SqlConnection connect = new SqlConnection(CS)) // Checks if Email already exists
        {
            using (SqlCommand cmd = new SqlCommand("Select count(*) from tblReferee where Email='" + tbxEmail.Text.Trim() + "'"))
            {
                cmd.Connection = connect;
                connect.Open();
                emailCount = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
        }
        if (emailCount != 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This Email is already added.')", true);
            return;
        }
        #endregion
        #region CENTER ID
        using (SqlConnection connect = new SqlConnection(CS))   //To find the Center ID.
        {
            using (SqlCommand cmd = new SqlCommand("Select id from tblCentre where CentreName='" + ddlCenter.SelectedItem.Text + "'"))
            {
                cmd.Connection = connect;
                connect.Open();
                Center = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        #endregion
        #region BANK ID
        using (SqlConnection connect = new SqlConnection(CS)) // Checks if Email already exists
        {
            using (SqlCommand cmd = new SqlCommand("Select count(*) from tblBanks where BankName='" + ddlBank.SelectedItem.Text + "'"))
            {
                cmd.Connection = connect;
                connect.Open();
                BankCount = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
        }
        if (BankCount != 0)
        {
            using (SqlConnection connect = new SqlConnection(CS))   //To find the Bank ID.
            {
                using (SqlCommand cmd = new SqlCommand("Select id from tblBanks where BankName='" + ddlBank.SelectedItem.Text + "'"))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    Bank = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        #endregion
        #region Registration ID
        using (SqlConnection connect = new SqlConnection(CS)) // To match Registration Id with corresponding Name
        {
            using (SqlCommand cmd = new SqlCommand("Select name from tblUploadedData where TPEnrollmentNo='" + tbxRegID.Text.Trim() + "'"))
            {
                cmd.Connection = connect;
                connect.Open();
                name = cmd.ExecuteScalar().ToString();
            }
        }
        if (name != tbxName.Text)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Name or Registration ID')", true);
            return;
        }

        #endregion
        RefereeData objReferee = new RefereeData(); //object of class RefereeData

        objReferee.Name = tbxName.Text.Trim();
        objReferee.Email = tbxEmail.Text.Trim();
        objReferee.Mobile = tbxMobile.Text.Trim();
        objReferee.RegistrationID = Convert.ToInt32(tbxRegID.Text.Trim());
        objReferee.CenterID = Center;
        objReferee.BankID = Bank;
        objReferee.AccountType = rblAccountType.SelectedValue;
        objReferee.AccountNo = tbxAccountNo.Text.Trim();
        objReferee.AccountHolderName = tbxAccountHolder.Text.Trim();
        objReferee.IFSC = tbxIfsc.Text.Trim();

        objReferee.RefereeRegistration(objReferee);

        string RegID;

        using (SqlConnection connect = new SqlConnection(CS))   //To find the Registration ID.
        {
            using (SqlCommand cmd = new SqlCommand("Select id from tblReferee where Email='" + tbxEmail.Text.Trim() + "'"))
            {
                cmd.Connection = connect;
                connect.Open();
                RegID = cmd.ExecuteScalar().ToString();
            }
        }

        string RefereeID = "RF2017" + RegID;

        string subject = "Acknowledgement";
        string body = "Hello, " + tbxName.Text.ToString() + ". You have been registered. Your Referee ID is " + RefereeID + ". Thankyou.";
        string message = "Your Referee ID is " + RegID + ". Check your Email.";

        Mail.Send_Mail(tbxEmail.Text.Trim(), body, subject);

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);

    }

    protected void tbxRegID_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbxRegID.Text))
        {
            int count;
            string name;
            string number = tbxRegID.Text.Trim();
            string CS = ConfigurationManager.ConnectionStrings["ReferAFriendCS"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("Select  count(*) from tblUploadedData where TPEnrollmentNo='" + tbxRegID.Text.Trim() + "'"))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    connect.Close();
                }
                if (count == 0)
                    lblMessage.Text = "Id does not exist";
                else
                {
                        //lblMessage.Text = "ID Matched";

                    using (SqlCommand cmd = new SqlCommand("Select ProposalNumber from tblUploadedData where TPEnrollmentNo='" + tbxRegID.Text.Trim() + "'"))
                    {
                        cmd.Connection = connect;
                        connect.Open();
                        name = cmd.ExecuteScalar().ToString();
                    }
                    if (name == tbxName.Text)
                        lblMessage.Text = "ID Matched";
                    else
                        lblMessage.Text = "Invalid Registration Id";
                }
            }
        }
    }
}