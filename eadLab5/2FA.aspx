<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage1.master"  CodeBehind="2FA.aspx.cs" Inherits="eadLab5._2FA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
            <asp:Button ID="ButtonEnable2FA" runat="server" Text="Enable" OnClick="ButtonEnable2FA_Click" />
&nbsp;<asp:Button ID="ButtonDisable2FA" runat="server" OnClick="ButtonDisable2FA_Click" Text="Disable" />
    </form>
</asp:Content>