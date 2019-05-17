<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="EventAdd.aspx.cs" Inherits="eadLab5.EventAdd" %>

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
                <td class="auto-style1">Event Name:</td>
                <td>
                    <asp:TextBox ID="TbEventName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Year Taken:</td>
                <td>
                    <asp:TextBox ID="TbEyearTaken" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">SEM Taken:</td>
                <td>
                    <asp:TextBox ID="TbSEMTaken" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button class="btn btn-secondary" ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Label ID="LblResult" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>

    </form>

</asp:Content>
