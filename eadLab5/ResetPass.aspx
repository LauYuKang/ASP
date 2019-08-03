<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ResetPass.aspx.cs" Inherits="eadLab5.ResetPass" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 449px;
        }
    </style>
    <script src="Script/jquery-1.7.1.js"></script>
    <script language="javascript" type="text/javascript">
        function checkPassStrength() {
            var value = $('#<%=txtNewPassword.ClientID %>').val();
            var score = 0;
            var status = "";
            var specialChars = "<>@!#$%^&*()_+[]{}?:;|'\"\\,./~`-="
            if (value.toString().length >= 8) {
                if (/[a-z]/.test(value)) {
                    score += 1;
                }
                if (/[A-Z]/.test(value)) {
                    score += 1;
                }
                if (/\d/.test(value)) {
                    score += 1;
                }
                for (i = 0; i < specialChars.length; i++) {
                    if (value.indexOf(specialChars[i]) > -1) {
                        score += 1;
                    }
                }
            }
            else {
                score = 1;

            }

            if (score == 2) {
                status = status = "<span style='color:#CCCC00'>Medium</span>";
            }
            else if (score == 3) {
                status = "<span style='color:#0DFF5B'>Strong</span>";
            }
            else if (score >= 4) {
                status = "<span style='color:#009933'>Very Strong</span>";
            }
            else {

                status = "<span style='color:red'>Weak</span>";
            }
            if (value.toString().length > 0) {
                $('#<%=lblPasswordStrength.ClientID %>').html("Status :<span> " + status + "</span>");
                }
                else {
                    $('#<%=lblPasswordStrength.ClientID %>').html("");
                }
            }

    </script>

    

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    

    <form id="form1" runat="server">
        <div style="font-family: Arial">
        <table style="border: 1px solid black">
    <tr>
        <td colspan="2">
            <b>Change Password</b>
        </td>
    </tr>
    <tr>
        <td>
            New Password
        </td>
        <td class="auto-style1">

            &nbsp;
            <asp:TextBox ID="txtNewPassword" TextMode="Password"  runat="server" onkeyup ="checkPassStrength()"></asp:TextBox>

            <asp:Label ID="lblPasswordStrength" runat="server" /> 
            
            
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword" runat="server" ErrorMessage="New Password required" Text="*" ControlToValidate="txtNewPassword" ForeColor="Red" onkeyup="checkPassStrength()">
            </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Confirm New Password
        </td>
        <td class="auto-style1">
            
            &nbsp;
            <asp:TextBox ID="TextCfmPass" TextMode="Password"  runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmNewPassword" 
                runat="server" ErrorMessage="Confirm New Password required" Text="*" 
                ControlToValidate="TextCfmPass"
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server" 
                ErrorMessage="New Password and Confirm New Password must match"
                ControlToValidate="TextCfmPass" ForeColor="Red" 
                ControlToCompare="txtNewPassword"
                Display="Dynamic" Type="String" Operator="Equal" Text="*">
            </asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
                    
            <asp:Label ID="LabelNoWork" runat="server" Text="Please have Caps, Special Char, Number in Password" Visible="False"></asp:Label>
        </td>
        <td class="auto-style1">
            <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMessage" runat="server">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" 
            ForeColor="Red" runat="server" />
        </td>
    </tr>
</table>
</div>
    </form>


</asp:Content>
