

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD_OP.aspx.cs" Inherits="CRUD_OP_WEBFROM.CRUD_OP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table>
                <tr><td> Student Name:<asp:TextBox ID="StdName" runat="server"></asp:TextBox></td></tr>
                <tr> <td> Student Class:<asp:TextBox ID="StdCls" runat="server"></asp:TextBox></td></tr>
                <tr><td>Student Mob<asp:TextBox ID="StdMno" runat="server"></asp:TextBox></td></tr>
                  <tr><td>Student Stream<asp:TextBox ID="StdStrm" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td><asp:Button ID="insert" runat="server" Text="insert" OnClick="add_Click" /></td>
                   <td><asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" /></td>
                   <td><asp:Button ID="Read" runat="server" Text="Read" OnClick="Read_Click" /></td>
                   <td><asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" /></td>
                    <asp:GridView ID="Display" runat="server"></asp:GridView>
                 </tr>
                <tr><td><asp:Label ID="message" runat="server" ></asp:Label></td></tr>
</table>
        </div>
    </form>
</body>
</html>
