<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="GeneralSetting.aspx.cs" Inherits="eadLab5.GeneralSetting" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 292px;
        }
        /*.sidenav {
  height: 100%;
  width: 160px;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: #111;
  overflow-x: hidden;
  padding-top: 20px;
}*/

.sidenav a {
  padding: 6px 8px 6px 16px;
  text-decoration: none;
  font-size: 25px;
  color: #818181;
  display: block;
}

.sidenav a:hover {
  color: #f1f1f1;
}

.main {
  margin-left: 160px; /* Same as the width of the sidenav */
  font-size: 28px; /* Increased text to enable scrolling */
  padding: 0px 10px;
}

@media screen and (max-height: 450px) {
  .sidenav {padding-top: 15px;}
  .sidenav a {font-size: 18px;}
}
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
  <asp:Button class="btn btn-secondary" ID="Button8" runat="server" OnClick="BtnAchievement_Click" Text="Achievement" />
  <asp:Button class="btn btn-secondary" ID="Button9" runat="server" OnClick="BtnEvent_Click" Text="Event" />
  <asp:Button class="btn btn-secondary" ID="Button10" runat="server" OnClick="BtnPassword_Click" Text="Change Password" />
        <h2>Update Details</h2>
        <table class="table">
            <tr>
                <td class="auto-style1">Admin Number :</td>
                <td>
                    <asp:Label ID="LblAdminNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Student Name :</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text=" "></asp:Label>
                    <asp:Label ID="LblStudentName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Student Image:</td>
                <td>
                    <asp:FileUpload ID="StudentPicture" runat="server" />
                    <asp:Image height="200px" width="50%" ID="StudentCurrentPicture" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Medical Condition:</td>
                <td>
                    <asp:TextBox ID="LblMedicalCondition" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Medical History :</td>
                <td>
                    <asp:TextBox ID="LblMedicalHistory" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Summary:</td>
                <td>
                    <asp:TextBox ID="LblSummary" Text="" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Phone Number</td>
                <td>
                    <asp:TextBox ID="LblHpNumber" Text="" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Email</td>
                <td>
                    <asp:TextBox ID="LblEmail" Text="" runat="server"></asp:TextBox>
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