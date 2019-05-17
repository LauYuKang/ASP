<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="AchievementAdd.aspx.cs" Inherits="eadLab5.AchievementAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 205px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <h2>Adding Achievement</h2>
        <table class="table">
            <tr>
                <td class="auto-style1">Admin Number:</td>
                <td>
                    <asp:Label ID="lbAdminNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Achievement Name:</td>
                <td>
                    <asp:TextBox ID="TbAchievementName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Year Received:</td>
                <td>
                    <asp:TextBox ID="TbAyearTaken" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button class="btn btn-secondary" ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />&nbsp;&nbsp;
                 <asp:Button class="btn btn-secondary" ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label class="btn btn-secondary" ID="LblResult" Text="" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </form>

</asp:Content>
