<%@ Page Title="" Language="C#" MasterPageFile="MasterPage1.master" AutoEventWireup="true" CodeBehind="Interview.aspx.cs" Inherits="eadLab5.interview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/Interview.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://static.opentok.com/v2/js/opentok.min.js"></script>
    <div class="container">
        <div id="videos">
            <div id="subscriber">
                <p class="text-center">Interviewer</p>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div id="publisher">
                        <p class="text-center">You</p>
                    </div>
                </div>
                <div class="col-md-8">
                    <% if(Session["role"] != null) { %>
                        <% if (Session["role"].ToString() == "Incharge")
                            { %>
                    <p>Remarks for student: </p>
                    <form runat="server">
                        <asp:TextBox ID="remarksTb" runat="server" TextMode="MultiLine" CssClass="interviewRemarks"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Submit remarks" Onclick="Button1_Click" CssClass="btn btn-primary"/>
                    </form>
                        <% } %>
                    <% } %>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            var apiKey = "46243942";
            var sessionId = "<%=sessionId%>";
            var token = "<%=token%>"
            // (optional) add server code here
            initializeSession();

            function handleError(error) {
                if (error) {
                    alert(error.message);
                }
            }

            function initializeSession() {
                var session = OT.initSession(apiKey, sessionId);

                // Subscribe to a newly created stream
                session.on('streamCreated', function (event) {
                    session.subscribe(event.stream, 'subscriber', {
                        insertMode: 'append',
                        width: '100%',
                        height: '100%'
                    }, handleError);
                });
                // Create a publisher
                var publisher = OT.initPublisher('publisher', {
                    insertMode: 'append',
                    width: '100%',
                    height: '100%'
                }, handleError);

                // Connect to the session
                session.connect(token, function (error) {
                    // If the connection is successful, publish to the session
                    if (error) {
                        handleError(error);
                    } else {
                        session.publish(publisher, handleError);
                    }
                });
            }

        </script>
    </div>
</asp:Content>
