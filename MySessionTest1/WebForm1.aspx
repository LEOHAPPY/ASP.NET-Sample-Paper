<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Parking Rebate system"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Vehicle number:"></asp:Label>
        <asp:TextBox ID="tb_vn" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Parking Rebate system"></asp:Label>
        <br />
        <asp:Label runat="server" Text="Receipt s/n : "></asp:Label>
        <asp:TextBox ID="tb_receipt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Shop name : "></asp:Label>
        <asp:TextBox ID="tb_sn" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Amount :     "></asp:Label>
        <asp:TextBox ID="tb_amount" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_add" runat="server" OnClick="add_btn_Click" Text="Add Receipt" />
        <br />
        
        
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btn_apply" runat="server" Text="Apply Rebates" OnClick="btn_apply_Click" />
    
        <br />
        <asp:Label runat="server" Text="Rebate Tickets : " ID="Label7"></asp:Label>
        <asp:TextBox ID="tb_rt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="bt_find" runat="server" OnClick="bt_find_Click" Text="Find Exsiting  Rebates" />
        <br />
        <asp:Label runat="server" Text="Existing Rebates : " ID="Label8"></asp:Label>
        <asp:TextBox ID="tb_er" runat="server"></asp:TextBox>
    
        <br />
    
    </div>
    </form>
</body>
</html>
