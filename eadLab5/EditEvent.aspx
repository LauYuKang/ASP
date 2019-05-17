<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="eadLab5.EditEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <h2>Edit Event</h2>
        <table class="table">
            <tr>
                <td class="auto-style1">Event ID :</td>
                <td>
                    <asp:Label ID="LblEventID" runat="server"></asp:Label>
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
                <td class="auto-style1">Sem Taken:</td>
                <td>
                    <asp:TextBox ID="TbEsemTaken" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                   <asp:Button class="btn btn-secondary" ID="Update" runat="server" Text="Update" OnClick="BtnUpdate"  />&nbsp;&nbsp;
                   <asp:Button class="btn btn-secondary" ID="Button2" runat="server" OnClick="BtnBack_Click" Text="Back" />
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