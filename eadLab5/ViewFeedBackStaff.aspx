<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ViewFeedBackStaff.aspx.cs" Inherits="eadLab5.ViewFeedBackStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 25px;
        }
        .auto-style24 {
            width: 101px;
        }
        .auto-style26 {
            width: 98%
        }
        .auto-style27 {
            width: 100%;
            padding-right: 15px;
            padding-left: 15px;
            margin-right: auto;
            margin-left: auto;
            margin-top: 0px;
        }
        .auto-style28 {
            width: 76px;
        }
        .auto-style30 {
            width: 2px;
        }
        .auto-style32 {
            width: 103px;
        }
        .auto-style35 {
            width: 170px;
        }
        .auto-style36 {
            width: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div id="content-wrapper">
            
            <div class="auto-style27">
               
                <br />
                <div class="card mb-3" style="left: -4px; top: 0px">
                    <div class="card-header">
                        <i class="fas fa-table"></i>
                        <asp:Label ID="Label4" runat="server" Style="text-align: center;" Text="Student Feedbacks"></asp:Label>
                    </div>
                    <div class="table-responsive">
                         <br />
                         <table class="auto-style26 text-nowrap" style="margin: auto;">
                    <tr>
                        <td class="auto-style32">
                                    <asp:Label ID="CountryFilter0" runat="server" Text="Country Filter"></asp:Label>
                                    :</td>
                        <td class="auto-style35">
                                    <asp:DropDownList ID="CountryFilterDropDown" runat="server" OnSelectedIndexChanged="CountryFilterDropDown_SelectedIndexChanged" AutoPostBack="True" class="dropdown-toggle btn btn-secondary">
                                        <asp:ListItem>All</asp:ListItem>
                                        <asp:ListItem>Australia</asp:ListItem>
                                        <asp:ListItem>Beijing</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style24">
                                    <asp:Label ID="AffordableFilter" runat="server" Text="Affordability"></asp:Label>
                                    :</td>
                        <td class="auto-style36">
                                    <asp:DropDownList ID="AffordabilityFilterDropDown" runat="server" OnSelectedIndexChanged="AffordabilityFilterDropDown_SelectedIndexChanged" AutoPostBack="True" class="dropdown-toggle btn btn-secondary" >
                                        <asp:ListItem>-Select-</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style28">
                                    <asp:Label ID="Label8" runat="server" Text="Freedom"></asp:Label>
                                    :</td>
                        <td class="auto-style30">
                                    <asp:DropDownList ID="FreedomFilterDropDown" runat="server" OnSelectedIndexChanged="FreedomFilterDropDown_SelectedIndexChanged" AutoPostBack="True" class="dropdown-toggle btn btn-secondary" >
                                        <asp:ListItem>-Select-</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                    </tr>
                    <tr>
                        <td class="auto-style32">&nbsp;</td>
                        <td class="auto-style35">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style24">&nbsp;</td>
                        <td class="auto-style36">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style30">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style32">
                                    <asp:Label ID="Label6" runat="server" Text="Date Start:"></asp:Label>
                                </td>
                        <td class="auto-style35">
                                    <asp:TextBox runat="server" ID="txtDateCheckStart" Format="dd/MMMM/yyyy" placeholder="DD-MMMM-YYYY" min="1753-01-01" max="9999-12-31" type="date" value="1-1-1753" AutoPostBack="True" class="form-control"/>

                                </td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style24">
                                    <asp:Label ID="Label7" runat="server" Text="Date End"></asp:Label>
                                    :</td>
                        <td class="auto-style36">
                                    <asp:TextBox runat="server" ID="txtDateCheckEnd" Format="dd/MMMM/yyyy" placeholder="DD-MMMM-YYYY" min="1753-01-01" max="9999-12-31" type="date" Width="190px" value="1-1-1753" OnTextChanged="txtDateCheckEnd_TextChanged" AutoPostBack="True" class="form-control" style="width:100%"/>

                                </td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style30">&nbsp;</td>
                    </tr>
                </table>
             
              <hr />
                        <asp:GridView ID="GridView_GetFB" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnSelectedIndexChanged="GridView_GetFB_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Style="margin: 0 auto; text-align: left;">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField AccessibleHeaderText="FeedBackId" DataField="FeedBackId" HeaderText="ID" />
                                <asp:BoundField AccessibleHeaderText="Student Name" DataField="StudentName" HeaderText="Student Name" />
                                <asp:BoundField AccessibleHeaderText="Country" DataField="Country" HeaderText="Country" />
                                <asp:BoundField AccessibleHeaderText="AdminNo" DataField="AdminNo" HeaderText="AdminNo" />
                                <asp:BoundField AccessibleHeaderText="Affordable" DataField="Affordability" HeaderText="Affordable" DataFormatString="{0:n2}" />
                                <asp:BoundField AccessibleHeaderText="Enjoyable" DataField="Enjoyment" HeaderText="Enjoyable" />
                                <asp:BoundField AccessibleHeaderText="Freedom" DataField="Freedom" HeaderText="Freedom" />
                                <asp:CommandField HeaderText="View Feedback" ShowSelectButton="True" />
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
                            <EmptyDataTemplate>
                                <center>No records found!</center>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
    </form>

</asp:Content>

