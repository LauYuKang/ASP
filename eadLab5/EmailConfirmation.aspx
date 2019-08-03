<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage1.master"CodeBehind="EmailConfirmation.aspx.cs" Inherits="eadLab5.EmailConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="form1" runat="server">
        <div style="margin-left: 80px">
            <asp:Label ID="LabelAdmin" runat="server" Text="Email   : "></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:Label ID="LabelCfmEmailSent" runat="server" Font-Size="18pt" Text="Confirmation Email Sent" Visible="False"></asp:Label>
            <br />
            <br />
&nbsp;<asp:Button ID="BtnResetPassword" runat="server" OnClick="BtnResetPassword_Click" Text="Reset Password" />
            <asp:Label ID="LabelNotFound" runat="server" Text="Username not found!" Visible="False"></asp:Label>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelResetPassLink" runat="server" EnableViewState="False" Text="Please check your email for reset password link." Visible="False"></asp:Label>
        </div>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>

        <asp:SqlDataSource ID="EADP" runat="server" ConnectionString="<%$ ConnectionStrings:EADPConnectionString %>" SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>

</asp:Content>
