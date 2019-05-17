<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage1.master" CodeBehind="ProfilePage.aspx.cs" Inherits="eadLab5.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style type="text/css">
        .auto-style1 {
            width: 292px;
        }
   </style>
    <form runat="server" text-align="center" margin="0 auto">
 

        <h2>Profile</h2>
        <asp:Image height="193px" width="193px" ID="Image1" runat="server" />
        <table class="table">
            <tr>
                <td class="auto-style1">Name :</td>
                <td>
                    <asp:Label ID="Lbl_studentname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Gender :</td>
                <td>
                    <asp:Label ID="Lbl_Gender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Diploma:</td>
                <td>
                    <asp:Label ID="Lbl_Diploma" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">MedicalCondition:</td>
                <td>
                    <asp:Label ID="Lbl_MedicalCondition" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">MedicalHistory:</td>
                <td>
                    <asp:Label ID="Lbl_MedicalHistory" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Hp Number:</td>
                <td>
                    <asp:Label ID="Lbl_HpNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Email:</td>
                <td>
                    <asp:Label ID="Lbl_Email" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Summary:</td>
                <td>
                    <asp:Label ID="Lbl_Summary" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
                                <asp:Button class="btn btn-secondary" ID="SettingDetails" runat="server" Text="Setting" OnClick="BtnSettingDetails"  />
                </div>
    </form>

</asp:Content>