<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ResetPassCfm.aspx.cs" Inherits="eadLab5.ResetPassCfm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">










    <form id="form1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Reset Password Confirmation"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Your Password has been reset "></asp:Label>
        <asp:HyperLink ID="HyperLinkLogIn" runat="server" NavigateUrl="~/loginStudent.aspx">Click here to log in.</asp:HyperLink>
    </p>
    <br />
</form>










</asp:Content>