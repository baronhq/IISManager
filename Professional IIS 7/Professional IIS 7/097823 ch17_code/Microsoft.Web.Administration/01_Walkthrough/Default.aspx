<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Web Site</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Create Web Site<br />
        <br />
        <asp:Label ID="StatusLabel" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td>
                    Site Name</td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Site IP</td>
                <td>
                    <asp:TextBox ID="IPTextBox" runat="server"></asp:TextBox>
&nbsp;Leave blank for (all unassigned)</td>
            </tr>
            <tr>
                <td>
                    Site Port</td>
                <td>
                    <asp:TextBox ID="PortTextBox" runat="server">80</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Site Host Header</td>
                <td>
                    <asp:TextBox ID="HostHeaderTextBox" runat="server"></asp:TextBox>
&nbsp;Leave blank for all host headers</td>
            </tr>
            <tr>
                <td>
                    Site Path</td>
                <td>
                    <asp:TextBox ID="PathTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="CreateSiteButton" runat="server" Text="Create Site" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
