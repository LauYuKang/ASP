<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="loginStudent.aspx.cs" Inherits="eadLab5.loginStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <div>
        <script src='https://www.google.com/recaptcha/api.js'></script>
        <table style="margin:auto;border:5px solid white">
        
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Admin Number"></asp:Label></td>
            <td>
                <asp:TextBox ID="tbLogin" CssClass="form-control" runat="server"></asp:TextBox>
</td>
            <td><asp:Label ID="validateLogin" Visible="false" runat="server" Text="Login is required!" ForeColor="Red"></asp:Label></td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password" ></asp:Label>
            </td>

            <td>
                <asp:Textbox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" ></asp:Textbox>
            </td>

            <td>
                <asp:Label ID="validatePassword" Visible="false"  runat="server" Text="Password is required!" ForeColor="Red">
                </asp:Label>
            </td>
        </tr>
        
        <tr>
            <td>
                
            </td>

            <td>
                <div class="g-recaptcha" data-type="image" data-sitekey="6LcRgqUUAAAAAAbJUgL-FZwLdDEqJSCrsm36XD4p"></div>
            </td>

            <td>
               
                <asp:Label ID="validateCaptcha" runat="server" ForeColor="Red" Text="Please check the box before you can continue" Visible="False"></asp:Label>
               
            </td>
        </tr>



        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                <asp:Label ID="errorMsg" runat="server" Text="Userid or password is not valid. Please try again." Visible="False"></asp:Label>
                <asp:Button ID="ButtonForgotPass" runat="server" OnClick="ButtonForgotPass_Click" Text="Forgot Password" />
            </td>
            <td>
                <asp:CheckBox ID="chkbox_rmbrMe" runat="server" Text="Remember Me" />

            </td>
            <td>

                <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>

            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button>

            </td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>   
    </div>
    </form>
</asp:Content>
