<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="eadLab5.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>

            <table style="margin:auto;border:5px solid white">
          
        
        <tr>
            <td>
                <asp:Label ID="Label" runat="server" Text="Admin No:"></asp:Label></td>
            <td>
                <asp:TextBox ID="tbAdminNo" CssClass="form-control" runat="server"></asp:TextBox><asp:Label ID="validateAdminNo" Visible="False" runat="server" Text="Admin Number is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>

        <tr> 
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password:" ></asp:Label></td>
            <td>
                <asp:Textbox ID="tbPw" runat="server" CssClass="form-control" TextMode="Password" ></asp:Textbox><asp:Label ID="validatePw" Visible="False"  runat="server" Text="Password is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
        <tr> 
            <td>
                <asp:Label ID="Label1" runat="server" Text="Comfirm Password:" ></asp:Label></td>
            <td>
                <asp:Textbox ID="tbCfmpw" runat="server" CssClass="form-control" TextMode="Password" ></asp:Textbox><asp:Label ID="validateCfmPw" Visible="False"  runat="server" Text="Password not the same!" ForeColor="Red"></asp:Label>
</td>
        </tr>
                        <tr> 
            <td>
                <asp:Label ID="Label4" runat="server" Text="Email Address:" ></asp:Label></td>
            <td>
                <asp:Textbox ID="tbEmailAdd" runat="server" CssClass="form-control" ></asp:Textbox><asp:Label ID="validateEmail" Visible="False"  runat="server" Text="Email Address is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
                        <tr> 
            <td>
                <asp:Label ID="Label6" runat="server" Text="Phone Number:" ></asp:Label></td>
            <td>
                <asp:Textbox ID="tbPhone" runat="server" CssClass="form-control" ></asp:Textbox><asp:Label ID="validatePhoneNo" Visible="False"  runat="server" Text="Phone Number is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
        <tr>
            <td class="auto-style1">
                </td>
            <td class="auto-style1">
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click"></asp:Button></td>
            <td class="auto-style1"></td>
        </tr>
                <tr>
            <td></td>
            <td>
                <asp:Label ID="LblResult" runat="server" ForeColor="Green"></asp:Label>

            </td>
            <td></td>
        </tr>
    </table>   
    </div>
    </form>

</asp:Content>