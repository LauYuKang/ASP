<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="Disable2FA.aspx.cs" Inherits="eadLab5.Disable2FA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">




        
        <asp:TextBox ID="TextBoxOTP" runat="server"></asp:TextBox>
        <asp:Label ID="Labelerror" runat="server"></asp:Label>
        <br />
        <asp:Button ID="ButtonOTP" runat="server" OnClick="ButtonOTP_Click" Text="Submit" />










    </form>
</asp:Content>
