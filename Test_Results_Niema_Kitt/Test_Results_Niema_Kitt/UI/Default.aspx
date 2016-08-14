<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test_Results_Niema_Kitt.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 480px">
    <form id="form1" runat="server">
    <div style="height: 476px">
    
     <asp:Label ID="Label2" runat="server" Font-Size="20pt" style="top: 37px; left: 341px; position: absolute; height: 26px; width: 199px; text-align: center; bottom: 391px" Text="Employees"></asp:Label>
     <asp:Label ID="Label3" runat="server" style="top: 99px; left: 338px; position: absolute; height: 19px; width: 34px" Text="Managers: "></asp:Label>
     <asp:DropDownList ID="drpManager" runat="server" style="top: 95px; left: 413px; position: absolute; height: 24px; width: 164px" 
      AutoPostBack="true"  onselectedindexchanged="drpManager_SelectedIndexChanged"  >
     </asp:DropDownList>
     <br />
     <asp:GridView ID="grdEmployees" AutoGenerateColumns="true" UseAccessibleHeader="true" Showheader="false" runat="server" style="top: 171px; left: 346px; position: absolute; height: 133px; width: 266px; bottom: 103px" OnRowCreated="grdEmployees_RowCreated">
     </asp:GridView>
    
    </div>
     <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="top: 377px; left: 380px; position: absolute; height: 26px" Text="Add Employee" />
    </form>
</body>
</html>
