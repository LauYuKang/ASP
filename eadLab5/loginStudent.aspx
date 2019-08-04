<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="loginStudent.aspx.cs" Inherits="eadLab5.loginStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 170px;
        }
        .auto-style8 {
            display: block;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        margin-right: 0;
    }
        .auto-style9 {
            width: 170px;
            height: 42px;
        }
        .auto-style10 {
            width: 318px;
            height: 42px;
        }
        .auto-style11 {
            height: 42px;
        }
        .auto-style12 {
            display: block;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
            margin-top: 7;
        }
        .auto-style13 {
            width: 170px;
            height: 47px;
        }
        .auto-style14 {
            width: 318px;
            height: 47px;
        }
        .auto-style15 {
            height: 47px;
        }
    .auto-style16 {
        width: 318px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <script src='https://www.google.com/recaptcha/api.js'></script>
        <table style="margin:auto;border:5px solid white">
        
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Admin Number"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="tbLogin" runat="server" Width="300px" Height="40px"></asp:TextBox>
            </td> <!-- CssClass="auto-style8"-->

            <td>
                <asp:Label ID="validateLogin" Visible="false" runat="server" Text="Login is required!" ForeColor="Red"></asp:Label>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password" ></asp:Label>
            </td>

            <td>
                <asp:Textbox ID="tbPassword" runat="server" TextMode="Password" Width="300px" Height="42px" ></asp:Textbox>
            </td> <!--CssClass="auto-style12"-->

            <td>
                <asp:Label ID="validatePassword" Visible="false"  runat="server" Text="Password is required!" ForeColor="Red">
                </asp:Label>
            </td>

        </tr>
        
        <tr>
            <td>
                
            </td>

            <td class="auto-style16">
                <div class="g-recaptcha" data-type="image" data-sitekey="6LcRgqUUAAAAAAbJUgL-FZwLdDEqJSCrsm36XD4p"></div>
            </td>

            <td>
               
                <asp:Label ID="validateCaptcha" runat="server" ForeColor="Red" Text="Please check the box before you can continue!" Visible="False"></asp:Label>
               
            </td>
        </tr>



        <tr>
            <td>
                
            </td>
            <td class="auto-style16">
                <asp:CheckBox ID="chkbox_rmbrMe" runat="server" Text="Remember Me" />

            </td>
            <td>

            </td>
        </tr>

        <tr>
            <td></td>

            <td class="auto-style16">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="75px"></asp:Button>
                
                
                <asp:Button ID="ButtonForgotPass" runat="server" OnClick="ButtonForgotPass_Click" Text="Forgot Password" Width="179px" />
                
                </td>
            <td>
                </td>
        </tr>

        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style16">

                <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>

                </td>
            <td>&nbsp;</td>
        </tr>
    </table>   
    </div>
    </form>
</asp:Content>
