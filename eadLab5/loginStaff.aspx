<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="loginStaff.aspx.cs" Inherits="eadLab5.loginStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>

            <table style="margin:auto;border:5px solid white">
          
        
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label></td>
            <td>
                <asp:TextBox ID="tbLogin" CssClass="form-control" runat="server"></asp:TextBox><asp:Label ID="validateLogin" Visible="false" runat="server" Text="Login is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password" ></asp:Label></td>
            <td>
                <asp:Textbox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" ></asp:Textbox><asp:Label ID="validatePassword" Visible="false"  runat="server" Text="Password is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>

            </td>
            <td></td>
        </tr>
    </table>   
    </div>
    </form>

</asp:Content>
