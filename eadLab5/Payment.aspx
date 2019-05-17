<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="eadLab5.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <table style="margin:auto;border:5px solid white">
          
        
        <tr>
            <td>
                <asp:Label ID="lblCreditHolder" runat="server" Text="Credit Card Holder :"></asp:Label></td>
            <td>
                <asp:TextBox ID="CreditName" runat="server"></asp:TextBox><asp:Label ID="validateHolder" Visible="false" runat="server" Text="Credit Card Holder is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCreditNumber" runat="server" Text="Credit Card Number :"></asp:Label></td>
            <td>
                <asp:TextBox ID="CreditEntry" runat="server" ></asp:TextBox>  <asp:Label ID="validateNumber" Visible="false"  runat="server" Text="Credit Card Number is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
            <tr>
            <td>
                <asp:Label ID="lblCreditExpiry" runat="server" Text="Expiry Date :"></asp:Label></td>
            <td><asp:Calendar ID="CreditExpiry" runat="server" ></asp:Calendar>
&nbsp;<asp:Label ID="validateExpiry" Visible="false"  runat="server" Text="Expiry Date is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
            <tr>
            <td>
                <asp:Label ID="lblCVC" runat="server" Text="CVC :"></asp:Label></td>
            <td>
                 <asp:TextBox ID="CreditCVC" runat="server"  MaxLength="3" ></asp:TextBox>
                 <asp:Label ID="validateCVC" Visible="false"  runat="server" Text="CVC is required!" ForeColor="Red"></asp:Label>
</td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Proceed to Pay" OnClick="btnLogin_Click" ></asp:Button></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect Credit Card Credentials" ForeColor="Red"></asp:Label>

            </td>
            <td></td>
        </tr>
    </table>
        
        
        <br />
        
        
    </form>

</asp:Content>
