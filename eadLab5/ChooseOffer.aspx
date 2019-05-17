<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage1.master" AutoEventWireup="true" CodeBehind="ChooseOffer.aspx.cs" Inherits="eadLab5.ChooseOffer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h2>You are selected for <%=tripName %></h2>
            <hr />
            <p>In order to confirm you for the trip, you have to accept the trip.</p>
            <p>The trip will be held from <%=tripStart %> to <%=tripEnd %></p>
            <div class="alert alert-danger" role="alert">
                <i class="fa fa-warning"></i> After you have made your choice, you are not given another opportunity to choose
            </div>
            <form runat="server">
                <asp:Button runat="server" Text="Accept Offer" OnClick="Unnamed1_Click" CssClass="btn btn-primary" />
                <asp:Button runat="server" Text="Reject Offer" OnClick="Unnamed2_Click" CssClass="btn btn-danger" />
            </form>
        </div>
    </div>
</asp:Content>
