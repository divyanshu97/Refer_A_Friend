<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload_Data.aspx.cs" Inherits="Upload_Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UPLOAD TRAINEE DATA</title>
    <script type="text/javascript">
    function CheckFile(fileUpload) {
        if (fileUpload.value != '') {
            document.getElementById("<%=btnUpload.ClientID %>").click();
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="lblCenter" runat="server" Text="Select Center: "></asp:Label>
                <asp:DropDownList ID="ddlCenter" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="ddlCenter" ID="RequiredCenter"
                    ValidationGroup="Group1" ErrorMessage="* Please select a type" ForeColor="Red"
                    InitialValue="Select" runat="server" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:FileUpload ID="File1" runat="server" />
                <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
            </p>
        </div>
    </form>
</body>
</html>
