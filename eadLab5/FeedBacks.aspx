<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="FeedBacks.aspx.cs" Inherits="eadLab5.FeedBacks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form runat="server">
        <div id="wrapper">

            <!-- Sidebar -->
            <div id="content-wrapper">

                <div class="container-fluid">
                    <br />
                    <!-- DataTables Example -->
                    <div class="card mb-3">
                        <div class="card-header">
                            <i class="fas fa-table"></i>
                <asp:Label ID="Label1" runat="server" Style="text-align: center;">Feedbacks Allocated</asp:Label>
                        </div>
                        <div class="table-responsive">
                <asp:GridView ID="GridViewStudentFeedBack" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewStudentFeedBack_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Style="margin: 0 auto;" width="1052px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="Trip ID" DataField="TripId" HeaderText="Trip ID" />
                        <asp:BoundField AccessibleHeaderText="Title" DataField="triptitle" HeaderText="Title" />
                        <asp:BoundField AccessibleHeaderText="TimeRange" DataField="TimeRange" HeaderText="Time Range" />
                        <asp:BoundField AccessibleHeaderText="location" DataField="location" HeaderText="Location" />
                        <asp:CommandField ShowSelectButton="True" />
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
                        </div>
                    </div>
                </div>

            </div>
            <!-- /.content-wrapper -->

        </div>
    </form>


    </asp:Content>
