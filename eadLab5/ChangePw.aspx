<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ChangePw.aspx.cs" Inherits="eadLab5.ChangePw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <h2>Change Password</h2>
        <table class="table">
            <tr>
                <td class="auto-style1">Admin Number :</td>
                <td>
                    <asp:Label ID="LblAdminNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">New Password :</td>
                <td>
                    <asp:TextBox ID="TbNewPassword" TextMode="Password" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Confirm New Password:</td>
                <td>
                    <asp:TextBox ID="TbCfmNewPassword" TextMode="Password" runat="server"></asp:TextBox>
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