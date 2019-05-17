<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage1.master" CodeBehind="FAQPage.aspx.cs" Inherits="eadLab5.FAQPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form runat="server">
          <h2>FAQ</h2>
     
      
          <asp:GridView ID="GridView_FAQ" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_FAQ_SelectedIndexChanged">
              <Columns>
                  <asp:BoundField DataField="FaqId" HeaderText="ID" />
                  <asp:BoundField DataField="Question" HeaderText="Question" />
                  <asp:BoundField DataField="Ans" HeaderText="Answer" />
                  <asp:ButtonField Text="delete" />
              </Columns>
          </asp:GridView>
      </form>
</asp:Content>
