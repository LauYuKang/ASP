<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ManageInterviews.aspx.cs" Inherits="eadLab5.ManageInterviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.js" integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-header">Scheduling interviews</div>
            <% if (interviewList == null) { %>
                Sorry, no interview ongoing
            <%} else{%>
            <% foreach (var interview in interviewList)
                { %>
            <div class="card-body">
                <div class="media">
                    <img class="align-self-center mr-3" src="<%=interview.studentPic%>" alt="studentPicture" style="height: 193px; width: 193px;" />
                    <div class="media-body">
                        <h5 class="mt-0"><%=interview.studentName %></h5>
                        <p>Signing up for <%=interview.tripName %></p>
                        <p>From <%=interview.tripStart.ToString("dd/MM/yyyy") %> to <%=interview.tripEnd.ToString("dd/MM/yyyy") %></p>
                        <p>Location: <%=interview.tripLocation %></p>
                        <% if (interview.interviewDate.ToString() != null && interview.interviewTime.ToString() != null)
    { %>
                        <p>Scheduled on(yyyy/mm/dd): <b><%=interview.interviewDate.ToString() %>,<%=interview.interviewTime.ToString() %></b></p>
                        <%} %>
                        <p></p>
                    </div>
                    <button type="button" data-toggle="modal" data-target="#emailModal<%=interview.interviewId %>" class="btn btn-primary">Schedule interview</button><p>&nbsp</p>
                    <button type="button" class="btn btn-secondary" onclick="createSession(<%=interview.interviewId %>)">Start interview</button>
                </div>
            </div>
            <div class="modal fade" id="emailModal<%=interview.interviewId %>" tabindex="-1" role="dialog" aria-labelledby="addModal" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            Email students about time of interview
                        </div>
                        <div class="modal-body">
                            <table class="table table-bordered">
                                <tr>
                                    <td>
                                        <label>Date: </label>
                                    </td>
                                    <td>
                                        <input type="date" id="dateTrip<%=interview.interviewId %>" class="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Time: </label>
                                    </td>
                                    <td>
                                        <input type="time" id="timeTrip<%=interview.interviewId %>" min="13:00" max="20:00" class="form-control" /></td>
                                </tr>

                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="align-middle btn btn-primary" onclick="sendMail(<%=interview.interviewId %>)">Send email</button>
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
            <%} %>
            <form runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-striped" OnRowCommand="GridView1_RowCommand" DataKeyNames="InterviewId">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="InterviewId" HeaderText="Id" />
                        <asp:BoundField DataField="StudentAdminNo" HeaderText="Admin number" />
                        <asp:BoundField DataField="studentName" HeaderText="Student name" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnApprove" runat="server" CommandArgument='<%# Eval("InterviewId") %>' CommandName="Approve" Text="Approve" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnReject" runat="server" CommandArgument='<%# Eval("InterviewId") %>' CommandName="Reject" Text="Reject" />
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
            </form>
            <script type="text/javascript">
                function sendMail(id) {
                    var dateId = "dateTrip" + id;
                    var timeId = "timeTrip" + id;
                    var emailDate = document.getElementById(dateId).value;
                    var emailTime = document.getElementById(timeId).value;
                    var data = { "emailDate": emailDate, "emailTime": emailTime, "intId": id }
                    $.ajax({
                        url: "http://localhost:3355/manageInterviews.aspx/emailStudent",
                        type: 'POST',
                        data: JSON.stringify(data),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (response) {
                            console.log(response)
                            window.location.reload()
                        },
                        error: function () {
                            console.log("error")
                        }
                    })
                }

                function createSession(id) {
                    var data = { "intId": id }
                    $.ajax({
                        url: "http://localhost:3355/manageInterviews.aspx/createSession",
                        type: 'POST',
                        data: JSON.stringify(data),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (response) {
                            console.log(response["d"])
                            var sessionToken = response["d"];
                            var split = sessionToken.split("__________");
                            var token = split[0];
                            var session = split[1];
                            window.location.href = "Interview.aspx?sessionId=" + session + "&token=" + token;
                        },
                        error: function () {
                            console.log("error")
                        }
                    })
                }
            </script>
        </div>
    </div>
</asp:Content>
