<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="StaffViewSpecificFeedBack.aspx.cs" Inherits="eadLab5.StaffViewSpecificFeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .row {
            margin-top: 40px;
        }



        .header {
            padding: 10px 0;
            background: #f5f5f5;
            border-top: 3px solid #ffffff;
        }

        .list-group {
            list-style: disc inside;
        }

        .list-group-item {
            display: list-item;
        }

        .find-more {
            text-align: right;
        }


        .label-theme {
            font-size: 14px;
            padding: .3em .7em .3em;
            color: #fff;
            border-radius: .25em;
        }

        .label a {
            color: inherit;
        }

        .pricingTable{
    text-align: center;
    background: #e6e6e6;
}

.pricingTable > .pricingTable-header{
    color:#fff;
}
.pricingTable .pricingTable-header > .heading{
    display: block;
    padding: 20px 0;
    background: #ed687c;
}
.pricingTable .pricingTable-header > .heading > h3{
    margin: 0 0 12px 0;
    text-transform: uppercase;
    font-weight: bold;
}
.pricingTable .pricingTable-header > .heading > i{
    font-size: 70px;
    opacity: 0.5;
}
.pricingTable .pricingTable-header > .price-value{
    display: block;
    background: #ed687c;
    margin: 20px 0;
    padding: 10px 0;
    font-size: 47px;
    font-weight: bold;
}
.pricingTable .pricingTable-header > .price-value > .month{
    display: block;
    font-size: 14px;
}
.pricingTable > .pricingContent{
    text-transform: capitalize;
}
.pricingTable > .pricingContent > ul{
    list-style: none;
    padding: 0;
    margin-bottom: 0;
}
.pricingTable > .pricingContent > ul > li{
    border-top: 1px solid #cdcdcd;
    border-bottom: 1px solid #fff;
    padding: 10px 0;
    position: relative;
    z-index: 1;
    overflow: hidden;
}
.pricingTable > .pricingContent > ul > li:after{
    content: "";
    width: 100%;
    height:100%;
    position: absolute;
    top:0;
    left:-100%;
    background: #b6b6b6;
    z-index: -5;
    transition: all 0.4s ease 0s;
}

.pricingTable .pricingTable-sign-up{
    padding: 20px 0;
}
.pricingTable .pricingTable-sign-up > .btn-block{
    padding: 15px 0;
    text-transform: uppercase;
    font-size: 16px;
    font-weight: bold;
    border-radius: 0px;
    border: 1px solid #ed687c;
    color: #ed687c;
    background: #cdcdcd;
    position: relative;
    transition: all 0.6s ease 0s;
}
.pricingTable .pricingTable-sign-up > .btn-block:before{
    content: "";
    position: absolute;
    top:0;
    left:0;
    width: 100%;
    height:0;
    z-index: -1;
    transition: all 0.6s ease 0s;
}
.pricingTable .pricingTable-sign-up > .btn-block:after{
    content: "";
    position: absolute;
    bottom:0;
    right:0;
    width: 100%;
    height:0;
    z-index: -1;
    transition: all 0.6s ease 0s;
}

@media screen and (max-width: 990px){
    .pricingTable{
        margin-bottom: 20px;
    }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <body>
        <!-- ******HEADER****** -->
        <header class="header">
            <div class="container">

                <div class="col-md-12">
                    <!-- Rank & Qualifications -->
                    <h2 style="font-size: 38px"><strong>
                               <asp:Label ID="NameLabel" runat="server" Text="[Name]"></asp:Label></strong></h2>
                    <h5 style="color: #3AAA64">Admin Number:
                        <asp:Label ID="AdminLabel" runat="server" Text="[AdminNo]"></asp:Label></h5>
                    <p>Visited Country:
                        <asp:Label ID="CountryLabel" runat="server" Text="[Country]"></asp:Label></p>
                    <p>Feedback Created On:
                        <asp:Label ID="DateCreatedLabel" runat="server" Text="[Date]"></asp:Label></p>
                </div>
            </div>
        </header>
        <!--End of Header-->

        <!-- Main container -->
        <div class="container">

            <div class="row">
                <div class="col-md-4 col-sm-8">
                    <div class="pricingTable">
                        <div class="pricingTable-header">
                            <span class="heading">
                                <h3>Overall Experience:</h3>
                                <i class="fa fa-caret-square-o-right"></i>
                            </span>
                        </div>
                        <div class="pricingContent">
                            <asp:Label ID="EnjoymentLabel" runat="server" Text="[Enjoyment]"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-sm-8">
                    <div class="pricingTable">
                        <div class="pricingTable-header">
                            <span class="heading">
                                <h3>Satisfied With Affordability</h3>
                                <i class="fa fa-caret-square-o-right"></i>
                            </span>

                        </div>

                        <div class="pricingContent">
                            <asp:Label ID="AffordablitityLabel" runat="server" Text="[Affordability]"></asp:Label>
                        </div>
                        <!-- /  CONTENT BOX-->
                    </div>
                </div>

                <div class="col-md-4 col-sm-8">
                    <div class="pricingTable">
                        <div class="pricingTable-header">
                            <span class="heading">
                                <h3>Satisfied With Freedom Given</h3>
                                <i class="fa fa-caret-square-o-right"></i>
                            </span>
                        </div>

                        <div class="pricingContent">
                            <asp:Label ID="FreedomLabel" runat="server" Text="[Freedom]"></asp:Label>
                        </div>
                        <!-- /  CONTENT BOX-->
                    </div>
                </div>
            </div>
              <div class="row">
                    <div class="col-md-12">
                        <div class="card card-block text-xs-left" style="left: 0px; top: 0px">
                            <h4 class="card-title" style="color: #009688"><i class="fa fa-user fa-fw"></i>Trip Highlights:</h4>
                            <div style="height: 15px"></div>
                            <h6><asp:Label ID="HighlightsLabel" runat="server" Text="[Highlights]"></asp:Label></h6>
                        </div>
                    </div>
                    </div>
               
                 <div class="row">
                    <div class="col-md-12">
                        <div class="card card-block text-xs-left">
                            <h4 class="card-title" style="color: #009688"><i class="fa fa-user fa-fw"></i>Trip Downsides:</h4>
                            <div style="height: 15px"></div>
                            <h6><asp:Label ID="DownsidesLabel" runat="server" Text="[Downsides]"></asp:Label></h6>
                        </div>
                    </div>
                     </div>
             
               <div class="row">
                    <div class="col-md-12">
                        <div class="card card-block text-xs-left">
                            <h4 class="card-title" style="color: #009688"><i class="fa fa-user fa-fw"></i>Trip could be improved in:</h4>
                            <div style="height: 15px"></div>
                            <h6><asp:Label ID="ImprovementsLabel" runat="server" Text="[Improvements]"></asp:Label></h6>
                        </div>
                    </div>
               </div>
            <!--End of Container-->
        </div>
    </body>
</asp:Content>
