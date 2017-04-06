<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RefereeRegistration.aspx.cs" Inherits="RefereeRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REFEREE REGISTRATION</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <h3>Personal Information:
                <%--<asp:Label ID="lblTag1" runat="server" Text="Personal Information: " Font-Bold="true"></asp:Label>--%>
            </h3>
            <p>
                <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                <asp:TextBox ID="tbxName" runat="server" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredName" runat="server" Display="Dynamic"
                    ControlToValidate="tbxName" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email ID: "></asp:Label>
                <asp:TextBox ID="tbxEmail" runat="server" type="email"></asp:TextBox>
                <%-- <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" Display="Dynamic"
                    ControlToValidate="tbxEmail" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularEmail" runat="server"
                    Display="Dynamic" ControlToValidate="tbxMobile" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w)+)+)"
                    ErrorMessage="* Enter a valid Email ID" ForeColor="red"></asp:RegularExpressionValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredEmail" runat="server"
                    ControlToValidate="tbxEmail" ErrorMessage="* Field is required" ForeColor="red">
                </asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularEmail" runat="server"
                    ErrorMessage="* Invalid Email" ControlToValidate="tbxEmail"
                    SetFocusOnError="True" ForeColor="red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label ID="lblMobile" runat="server" Text="Mobile No.: "></asp:Label>
                <asp:TextBox ID="tbxMobile" runat="server" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" Display="Dynamic"
                    ControlToValidate="tbxMobile" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularMobile" runat="server"
                    Display="Dynamic" ControlToValidate="tbxMobile" ValidationExpression="[7-9][0-9]{9}"
                    ErrorMessage="* Enter a valid phone number" ForeColor="red"></asp:RegularExpressionValidator>
            </p>
            <h3>Details of Training Attended:
                <%--<asp:Label ID="lblTag2" runat="server" Text="Details of Training Attended: " Font-Bold="true"></asp:Label>--%>
            </h3>
            <p>
                <asp:Label ID="lblRegID" runat="server" Text="Registration ID: "></asp:Label>

                <asp:UpdatePanel ID="CheckRegID" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="tbxRegID" runat="server" type="text" AutoPostBack="true" OnTextChanged="tbxRegID_TextChanged"></asp:TextBox>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredRegID" runat="server" Display="Dynamic"
                            ControlToValidate="tbxEmail" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <p>
                <asp:Label ID="lblCenter" runat="server" Text="Select Center: "></asp:Label>
                <asp:DropDownList ID="ddlCenter" runat="server" ValidationGroup="Group1"></asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="ddlCenter" ID="RequiredCenter"
                    ValidationGroup="Group1" ErrorMessage="* Please select a type" ForeColor="Red"
                    InitialValue="Select" runat="server" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </p>
            <h3>Bank Account Details:
            </h3>
            <p>
                <asp:Label ID="lblBank" runat="server" Text="Bank Name: "></asp:Label>
                <%--<asp:TextBox ID="tbxBank" runat="server" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredBank" runat="server" Display="Dynamic"
                    ControlToValidate="tbxBank" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>--%>
                <asp:DropDownList ID="ddlBank" runat="server" ValidationGroup="Group2"></asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="ddlBank" ID="RequiredBank"
                    ValidationGroup="Group2" ErrorMessage="* Please select a bank" ForeColor="Red"
                    InitialValue="Select" runat="server" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </p>
            <p>
                <%--<asp:Label ID="lblAccountType" runat="server" Text="Type of Account: "></asp:Label>
                <asp:RadioButton ID="RadioButtonSavings" GroupName="Radio" runat="server" Text=" Savings" />
                <asp:RadioButton ID="RadioButtonCurrent" GroupName="Radio" runat="server" Text=" Current" />--%>
                <asp:Label ID="lblAccountType" runat="server" Text="Type of Account: "></asp:Label>
                <asp:RadioButtonList ID="rblAccountType" runat="server">
                    <asp:ListItem>Savings</asp:ListItem>
                    <asp:ListItem>Current</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredAccountType"
                    ControlToValidate="rblAccountType" Text="* Field is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblAccountNo" runat="server" Text="Account No.: "></asp:Label>
                <asp:TextBox ID="tbxAccountNo" runat="server" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredAccountNo" runat="server" Display="Dynamic"
                    ControlToValidate="tbxAccountNo" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularAccountNo" runat="server"
                    Display="Dynamic" ControlToValidate="tbxAccountNo" ValidationExpression="[0-9]+"
                    ErrorMessage="* Enter a valid Account Number" ForeColor="red"></asp:RegularExpressionValidator>

            </p>
            <p>
                <asp:Label ID="lblAccountHolder" runat="server" Text="Account Holder Name: "></asp:Label>
                <asp:TextBox ID="tbxAccountHolder" runat="server" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredAccountHolder" runat="server" Display="Dynamic"
                    ControlToValidate="tbxAccountHolder" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblIfsc" runat="server" Text="IFSC Code: "></asp:Label>
                <asp:TextBox ID="tbxIfsc" runat="server" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredIfsc" runat="server" Display="Dynamic"
                    ControlToValidate="tbxIfsc" ErrorMessage="* Field is required" ForeColor="red"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="SUBMIT" />
            </p>
        </div>
    </form>
</body>
</html>
