<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="Enquiry.aspx.cs" Inherits="eadLab5.Enquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div > 
    <h3 >Enquiry</h3>
    <p>Contact us at telephone 67189999 or email our customer officer at admin@itp261.com.<br/> 
        Alternatively leave us your information, our customer officer will contact you shortly!</p>
    <table class="table">
        <tr>
            <td>Name :</td>
            <td><asp:TextBox ID="tbName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email :</td>
            <td><asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Enquiry :</td>
            <td><asp:TextBox ID="tbEnquiry"  runat="server" Height="49px" TextMode="MultiLine" Width="285px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</asp:Content>
