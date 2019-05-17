<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="WaitingList.aspx.cs" Inherits="eadLab5.WaitingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center">Waiting list for vietnam immersion trip</h3>
    <div class="container">
        <form runat="server">
            <asp:GridView ID="GvWaitingList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Precedence" HeaderText="Precedence" />
                    <asp:BoundField DataField="StudentName" HeaderText="Name" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</asp:Content>
