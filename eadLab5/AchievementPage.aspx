<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="AchievementPage.aspx.cs" Inherits="eadLab5.AchievementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <asp:Label ID="LblAdminNo" runat="server" Text="Admin No:"></asp:Label>
     <asp:GridView ID="GridView_Achievement" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gv_Students_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" Border="None" >
         <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="AchievementId" HeaderText="ID" />
            <asp:BoundField AccessibleHeaderText="Achievement Name" DataField="AchievementName" HeaderText="Achievement Name" />
            <asp:BoundField AccessibleHeaderText="Year Taken" DataField="AyearTaken" HeaderText="Year Taken" />
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AchievementId") %>' CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("AchievementId") %>' CommandName="Edit" Text="Edit" />
                    </ItemTemplate>

                </asp:TemplateField>
        </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        <asp:Button class="btn btn-secondary" ID="Button1" runat="server" Text="Add" OnClick="BtnAdd"  />
        <asp:Button class="btn btn-secondary" ID="Button2" runat="server" OnClick="BtnBack_Click" Text="Back" />
        </form>
</asp:Content>
