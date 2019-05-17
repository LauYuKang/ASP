<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ReportAndStatistics.aspx.cs" Inherits="eadLab5.ReportAndStatistics" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

    <div id="content-wrapper">

        <br />

      <!-- Sidebar -->
        <div class="container-fluid">

        

          <!-- Area Chart Example-->
            <div class="card mb-3">
                <div class="card-header">
                    <asp:Button ID="ExportAverageCostChart" runat="server" OnClick="btnChart2Excel_Click" Text="Export" class="btn btn-secondary" style="float:right"/>
                    <i class="far fa-chart-bar"></i>&nbsp;Bar Chart</div>
                <div class="card-body">
                    <div class="table-responsive">
                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style3">Country:</td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="CountryDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CountryDropDown_SelectedIndexChanged" class="dropdown-toggle btn btn-secondary">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>Beijing</asp:ListItem>
                                    <asp:ListItem>Dubai</asp:ListItem>
                                    <asp:ListItem>China</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style2">Type:</td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="TypeDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypeDropDown_SelectedIndexChanged" class="dropdown-toggle btn btn-secondary">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>Immersion</asp:ListItem>
                                    <asp:ListItem>Study</asp:ListItem>
                                    <asp:ListItem>Internship</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style2">
                                &nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Year Start:</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="DateStartRange" runat="server" type="date" AutoPostBack="True" class="form-control" OnTextChanged="DateStartRange_TextChanged"></asp:TextBox>
                            </td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style2">Year End:</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="DateEndRange" runat="server" type="date" AutoPostBack="True" OnTextChanged="DateEndRange_TextChanged" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <canvas id="myAreaChart" width="100%" height="30" ></canvas>
                    
                    <asp:Chart ID="Chart2" runat="server" Width="1028px" BackGradientStyle="VerticalCenter"  OnDataBound="Chart2_DataBound">
                        <Series>
                            <asp:Series Name="Series1" XValueMember="Location" YValueMembers="Cost">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Titles>
                            <asp:Title Font="Microsoft Sans Serif, 20.25pt, style=Bold" ForeColor="SteelBlue" Name="AverageCost" Text="Average Cost Per Country">
                            </asp:Title>
                            <asp:Title Docking="Left" Name="Average Cost" Text="Average Cost">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>
                        </div>

                    <div class="row">
                        <div class="col-lg-8">
                            <div class="card mb-3">
                                <div class="card-header">
                                    <asp:Button ID="ExportPaxNo" runat="server" OnClick="btnChart4Excel_Click" Text="Export" class="btn btn-secondary" style="float:right"/>
                                    <i class="far fa-chart-bar"></i>&nbsp;Bar Chart</div>
                                <div class="card-body table-responsive">
                                    <table class="auto-style11">
                                        <tr>
                                            <td>
                                                <table class="auto-style5">
                                                    <tr>
                                                        <td class="auto-style10">Year:</td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" class="dropdown-toggle btn btn-secondary">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Chart ID="Chart4" runat="server" Palette="Berry" Width="600px"  OnDataBound="Chart4_DataBound">
                                        <Series>
                                            <asp:Series Name="Series1" XValueMember="Location" YValueMembers="NoOfStudents">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Titles>
                                            <asp:Title Font="Microsoft Sans Serif, 20.25pt, style=Bold" ForeColor="SteelBlue" Name="Title" Text="Number of students per country">
                                            </asp:Title>
                                            <asp:Title Docking="Left" Name="Title1" Text="Number of students">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="card mb-3">
                                <div class="card-header">
                                    <asp:Button ID="ExportPieChart" runat="server" OnClick="btnChart1Excel_Click" Text="Export" class="btn btn-secondary" style="float:right"/>
                                    <i class="fas fa-chart-pie"></i>&nbsp;Pie Chart</div>

                                <div class="card-body">
                                    <table class="auto-style5">
                                        <tr>
                                            <td class="auto-style4">Country:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListCountryPieChart" runat="server" OnSelectedIndexChanged="DropDownListCountryPieChart_SelectedIndexChanged" AutoPostBack="True" class="dropdown-toggle btn btn-secondary">
                                                    <asp:ListItem>All</asp:ListItem>
                                                    <asp:ListItem>Dubai</asp:ListItem>
                                                    <asp:ListItem>China</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Chart ID="Chart1" runat="server" Width="270.656px" Height="264.484px" Palette="Fire"  OnDataBound="Chart1_DataBound">
                                        <Series>
                                            <asp:Series ChartType="Pie" Name="Series1" XValueMember="Diploma" YValueMembers="NoOfStudents">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Titles>
                                            <asp:Title Font="Microsoft Sans Serif, 8.25pt, style=Bold" ForeColor="SteelBlue" Name="Title1" Text="Number of student from a diplomas in a country">
                                            </asp:Title>
                                        </Titles>
                                    </asp:Chart>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12">
                            <div class="card mb-3">
                            <div class="card-header">
                                <asp:Button ID="ExportLineGraph" runat="server" OnClick="btnChart3Excel_Click" Text="Export" class="btn btn-secondary" style="float:right"/>
                                <i class="fas fa-chart-line"></i>&nbsp;Line Graph</div>
                            <div class="card-body table-responsive">

                                <table class="auto-style5">
                                    <tr>
                                        <td class="auto-style6">Diploma:</td>
                                        <td class="auto-style7">
                                            <asp:DropDownList ID="DropDownDiplomaLine" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" class="dropdown-toggle btn btn-secondary">
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem>DIT</asp:ListItem>
                                                <asp:ListItem>DSF</asp:ListItem>
                                                <asp:ListItem>DBI</asp:ListItem>
                                                <asp:ListItem>DBA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="auto-style1">Year:</td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="DropDownYearLine" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownYearLine_SelectedIndexChanged" class="dropdown-toggle btn btn-secondary">
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem Value="1">Year 1</asp:ListItem>
                                                <asp:ListItem Value="2">Year 2</asp:ListItem>
                                                <asp:ListItem Value="3">Year 3</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>


                                <br />
                                <asp:Chart ID="Chart3" runat="server" Width="1028px"  OnDataBound="Chart3_DataBound" BorderlineColor="Transparent">
                                    <Series>
                                        <asp:Series ChartType="Line" Name="Series1" XValueMember="Month" YValueMembers="NoOfStudents">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Titles>
                                        <asp:Title Font="Microsoft Sans Serif, 20pt, style=Bold" ForeColor="SteelBlue" Name="Title1" Text="Number of confirmed trips in a month">
                                        </asp:Title>
                                        <asp:Title Docking="Left" Font="Microsoft Sans Serif, 10pt" Name="Title2" Text="Number of trips">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                            </div>

                        </div>
                            </div>

                    </div>
            </div>
            <!-- /.container-fluid -->

            <!-- Sticky Footer -->

        </div>
          <!-- /.content-wrapper -->

      </div>

    </form>
</asp:Content>
