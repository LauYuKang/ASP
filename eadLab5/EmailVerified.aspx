<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="EmailVerified.aspx.cs" Inherits="eadLab5.EmailVerified" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <h2>Please Verify Your Email !!</h2>

            <table style="margin:auto;border:5px solid white">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Verification Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="tbCode" runat="server"></asp:TextBox>
                        <asp:Label ID="validationCode" runat="server" Text="Code is Required!" ForeColor="Red" Visible="False"></asp:Label>
                        </td>

                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_sendCode" AutoPostBack="false" onclick="btn_sendCodeClick" runat="server" Text="Send Code" />
                    </td>
                    <td>
                            <asp:Button ID="btn_submit" AutoPostBack="false" OnClick="btn_submitClick" runat="server" Text="Submit" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblError" runat="server" ForeColor="Green" Visible="False" ></asp:Label>
                    </td>
                </tr>
             </table>
    
    </form>

</asp:Content>
