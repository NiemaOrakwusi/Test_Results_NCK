<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Employee.aspx.cs" Inherits="Test_Results_Niema_Kitt.Add_Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 479px">
    <form id="form1" runat="server">
    <div style="height: 476px">
    
     <asp:Label ID="Label2" runat="server" Font-Size="20pt" style="top: 33px; left: 373px; position: absolute; height: 36px; width: 274px; text-align: center" Text="Add New Employee"></asp:Label>
     <asp:DropDownList ID="drpManager" runat="server" style="top: 96px; left: 476px; position: absolute; height: 23px; width: 157px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
     </asp:DropDownList>
     <asp:Label ID="Label3" runat="server" style="top: 95px; left: 360px; position: absolute; height: 19px; width: 34px" Text="Manager: "></asp:Label>
     <asp:Label ID="Label4" runat="server" style="top: 152px; left: 360px; position: absolute; height: 19px; width: 76px" Text="First Name: "></asp:Label>
     <asp:Label ID="Label5" runat="server" style="top: 210px; left: 360px; position: absolute; height: 19px; width: 76px" Text="Last Name"></asp:Label>
     <asp:Label ID="Label6" runat="server" style="top: 269px; left: 360px; position: absolute; height: 19px; width: 92px" Text="Employee ID: "></asp:Label>
     <asp:Label ID="Label7" runat="server" style="top: 331px; left: 360px; position: absolute; height: 19px; width: 34px" Text="Roles: "></asp:Label>
     <asp:ListBox ID="lstRoles" runat="server" SelectionMode="Multiple" style="top: 330px; left: 476px; position: absolute; height: 70px; width: 78px">
      <asp:ListItem>IT</asp:ListItem>
      <asp:ListItem>Support</asp:ListItem>
      <asp:ListItem>Etc.</asp:ListItem>
     </asp:ListBox>
     <asp:TextBox ID="txtFirstName" runat="server" style="top: 147px; left: 476px; position: absolute; height: 22px; width: 128px; bottom: 232px;"></asp:TextBox>
     <asp:TextBox ID="txtLastName" runat="server" style="top: 196px; left: 476px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
     <asp:TextBox ID="txtEmployeeID" runat="server" style="top: 256px; left: 476px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
     <asp:Button ID="btnSave" runat="server" style="top: 438px; left: 377px; position: absolute; height: 26px; width: 56px" Text="Save" OnClick="btnSave_Click" />
     <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" style="top: 435px; left: 558px; position: absolute; height: 26px; width: 56px" Text="Cancel" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName" ForeColor="Red"
    ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." style="top: 150px; left: 617px; position: absolute; height: 19px; width: 243px" />
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName" ForeColor="Red"
    ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Valid characters: Alphabets and space." style="top: 199px; left: 623px; position: absolute; height: 19px; width: 243px"  />
    </div>
    </form>
</body>
</html>
