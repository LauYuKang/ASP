<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="EditTripDetails.aspx.cs" Inherits="eadLab5.EditTripDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function updateTripValidation(sender, args) {
            var start = document.getElementById("ContentPlaceHolder1_tbUpdateStart").value;
            var end = document.getElementById("ContentPlaceHolder1_tbUpdateEnd").value;
            if (start != "" && end != "") {
                if (end > start) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
        }

        function updateOpenValidation(sender, args) {
            var start = document.getElementById("ContentPlaceHolder1_tbUpdateStart").value;
            var open = document.getElementById("ContentPlaceHolder1_tbUpdateOpeningday").value;
            if (start != "" && open != "")
                if (open > start) {
                    args.IsValid = false;
                } else {
                    args.IsValid = true;
                }
        }
        function updateTripCompareNowStart(sender, args) {
            var start = document.getElementById("ContentPlaceHolder1_tbUpdateStart").value;
            var current = new Date();
            var tripStart = new Date(start.toString());
            if (start != "") {
                if (current > tripStart) {
                    args.IsValid = false;
                } else {
                    args.IsValid = true;
                }
            }
        }
        function updateTripCompareNowOpen(sender, args) {
            var open = document.getElementById("ContentPlaceHolder1_tbUpdateOpeningday").value;
            var current = new Date();
            var tripOpen = new Date(open.toString());
            if (open != "") {
                if (current > tripOpen) {
                    args.IsValid = false;
                } else {
                    args.IsValid = true;
                }
            }
        }
    </script>
    <form runat="server">
        <div class="container">
            <h2 class="text-center">Edit trip details</h2>
            <table class="table table-bordered">
                <tr>
                    <td>Trip title:<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Trip title is required" ControlToValidate="tbUpdateTitle" Text="*" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="tbUpdateTitle" runat="server" ReadOnly="True" CssClass="form-control" ValidationGroup="1" AutoPostBack="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Trip location:<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Location is required" Text="*" ControlToValidate="ddlUpdateLocation" ValidationGroup="1" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:DropDownList ID="ddlUpdateLocation" runat="server" CssClass="form-control" Enabled="False" ValidationGroup="1"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Image:<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Image required" ControlToValidate="tripUploadImg" Text="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:FileUpload ID="tripUploadImg" runat="server" Enabled="False" CssClass="form-control-file" AllowMultiple="true"/>
                        <asp:Image ID="tripImage" runat="server" CssClass="img-thumbnail"/>
                    </td>
                </tr>
                <tr>
                    <td>From:<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Trip start date must be before trip end date" ClientValidationFunction="updateTripValidation" Text="*" ValidationGroup="1"></asp:CustomValidator><asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="Trip open date must be before trip start date" ClientValidationFunction="updateTripCompareNowStart" Text="*" ValidationGroup="1"></asp:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Start date required" ControlToValidate="tbUpdateStart" Text="*" ValidationGroup="2"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="tbUpdateStart" runat="server" ReadOnly="True" CssClass="form-control" TextMode="Date" ValidationGroup="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>To:<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Text="*" ErrorMessage="End date required" ControlToValidate="tbUpdateEnd" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="tbUpdateEnd" runat="server" ReadOnly="True" CssClass="form-control" TextMode="Date" ValidationGroup="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Open to sign up:<asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Trip open date cannot be in the past" ClientValidationFunction="updateTripCompareNowOpen" Text="*" ValidationGroup="1"></asp:CustomValidator><asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Trip open date must be before trip start date" ValidationGroup="1" Text="*" ClientValidationFunction="updateOpenValidation"></asp:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Trip open date required" ControlToValidate="tbUpdateOpeningDay" Text="*" ValidationGroup="2"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="tbUpdateOpeningday" runat="server" ReadOnly="True" CssClass="form-control" TextMode="Date" ValidationGroup="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Activities:<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Activities required" ControlToValidate="tbUpdateActivities" Text="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="tbUpdateActivities" runat="server" ReadOnly="True" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Estimated cost:<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Cost required" ControlToValidate="tbUpdateCost" Text="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:TextBox ID="tbUpdateCost" runat="server" ReadOnly="True" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Trip type:<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Type of trip required" ControlToValidate="DdlUpdateType" Text="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:DropDownList ID="DdlUpdateType" CssClass="form-control" runat="server" Enabled="False" ValidationGroup="1">
                            <asp:ListItem Selected="True" Value="-1">--Selected--</asp:ListItem>
                            <asp:ListItem Value="Study">Study</asp:ListItem>
                            <asp:ListItem Value="Immersion">Immersion</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" />
                <asp:Button ID="EnableBtn" runat="server" Text="Enable edit" OnClick="AllowEdit" CausesValidation="False" CssClass="btn btn-secondary" />
                <asp:Button ID="UpdateBtn" runat="server" Text="Update" Enabled="False" OnClick="UpdateTrip" CssClass="btn btn-success" ValidationGroup="1" AutoPostBack="True" />
                <%--<button type="button" class="btn btn-danger" data-toggle="modal" data-target="#deleteWarning">Delete</button>--%>
                <asp:Button ID="CancelBtn" runat="server" Text="Delete trip" CssClass="btn btn-danger" data-toggle="modal" data-target="#deleteWarning" CausesValidation="False" UseSubmitBehavior="False" OnClientClick="return false;" Enabled="False" />
        </div>
        <div class="modal fade" id="deleteWarning" tabindex="-1" role="dialog" aria-labelledby="deleteWarningLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="alert alert-danger">
                                Warning <i class="fas fa-exclamation-triangle"></i>
                                <p>Cancelling this trip will notify all students who have signed up for the trip</p>
                            </div>
                            <p>Reasons: <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Reason for cancellation required" ValidationGroup="2" Text="*" ControlToValidate="tbReason"></asp:RequiredFieldValidator></p><asp:TextBox ID="tbReason" runat="server" CssClass="form-control" ValidationGroup="2"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="2" />
                            <asp:Button ID="DelTrip" runat="server" Text="Cancel trip and notify" CausesValidation="True" OnClick="DelTrip_Click" CssClass="btn btn-danger" ValidationGroup="2" />
                        </div>
                    </div>
                </div>
            </div>
    </form>
</asp:Content>
