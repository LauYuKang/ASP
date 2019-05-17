<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="UpdateFeedBackSubmitted.aspx.cs" Inherits="eadLab5.UpdateFeedBackSubmitted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
    
	.contact{
		padding: 4%;
		height: 400px;
	}
	.col-md-3{
		background: #ff9b00;
		padding: 4%;
		border-top-left-radius: 0.5rem;
		border-bottom-left-radius: 0.5rem;
	}
	.contact-info{
		margin-top:10%;
	}
	.contact-info img{
		margin-bottom: 15%;
	}
	.contact-info h2{
		margin-bottom: 10%;
	}
	.col-md-9{
		background: #fff;
		padding: 3%;
		border-top-right-radius: 0.5rem;
		border-bottom-right-radius: 0.5rem;
	}
	.contact-form label{
		font-weight:600;
	}
	.contact-form button{
		background: #25274d;
		color: #fff;
		font-weight: 600;
		width: 25%;
	}
	.contact-form button:focus{
		box-shadow:none;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
         <div class="container contact">
         <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" />
	<div class="row">
         
		<div class="col-md-3">
			<div class="contact-info">
				<img src="https://image.ibb.co/kUASdV/contact-image.png" alt="image"/>
				<h2>Leave our trip a feedback!</h2>
				<h4>We would love to hear from you !</h4>
			</div>
		</div>
		<div class="col-md-9">
			<div class="contact-form">
               
				<div class="form-group">
				  <label>Did you enjoy your trip in <asp:Label ID="CountryLabel" runat="server" Text="[Country]"></asp:Label>? :</label>
				  <div class="col-sm-10">          
					 <asp:DropDownList ID="EnjoymentDropDownUpdate" runat="server" class="dropdown-toggle btn btn-secondary">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Not at all</asp:ListItem>
                        <asp:ListItem>A little bit</asp:ListItem>
                        <asp:ListItem>Average</asp:ListItem>
                        <asp:ListItem>Enjoyed it</asp:ListItem>
                        <asp:ListItem>Definitely Enjoyed it</asp:ListItem>
                     </asp:DropDownList>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="EnjoymentDropDownUpdate" ErrorMessage="Enjoyment Required" Operator="NotEqual" ValueToCompare="-Select-">*</asp:CompareValidator>
				  </div>
				</div>
				<div class="form-group">
				  <label for="lname">Do you think the trip was affordable? :</label>
				  <div class="col-sm-10">          
					 <asp:DropDownList ID="AffordabilityDropDownUpdate" runat="server" class="dropdown-toggle btn btn-secondary">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="AffordabilityDropDownUpdate" ErrorMessage="Affordability Required" Operator="NotEqual" ValueToCompare="-Select-">*</asp:CompareValidator>
				  </div>
				</div>
				<div class="form-group">
				  <label>Are you satisfied with the freedom you were given? :</label>
				  <div class="col-sm-10">
					 <asp:DropDownList ID="FreedomDropBoxUpdate" runat="server" class="dropdown-toggle btn btn-secondary">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidatorFreedom" runat="server" ControlToValidate="FreedomDropBoxUpdate" ErrorMessage="Freedom Required" Operator="NotEqual" ValueToCompare="-Select-">*</asp:CompareValidator>
				  </div>
				</div>
				<div class="form-group">
				  <label> What is your highlight of the trip? :</label>
				  <div class="col-sm-10">
					<asp:TextBox ID="HighlightTbUpdate" runat="server" TextMode="multiline" Columns="50" Rows="1" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="HighlightTbUpdate" ErrorMessage="Highlights Required">*</asp:RequiredFieldValidator>
				  </div>
				</div>
                <div class="form-group">
				  <label for="comment"> What are the downsides of the trip? :</label>
				  <div class="col-sm-10">
					<asp:TextBox ID="DownsidesTbUpdate" runat="server" TextMode="multiline" Columns="50" class="form-control" oninput='this.style.height = "";this.style.height = this.scrollHeight + "px"'>></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DownsidesTbUpdate" ErrorMessage="Downsides Required">*</asp:RequiredFieldValidator>
				  </div>
				</div>
                <div class="form-group">
				  <label for="comment"> What can be improved? :</label>
				  <div class="col-sm-10">
					  <asp:TextBox ID="ImprovementTbUpdate" runat="server" TextMode="multiline" Columns="50" class="form-control" oninput='this.style.height = "";this.style.height = this.scrollHeight + "px"'>></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Improvements Required" ControlToValidate="ImprovementTbUpdate">*</asp:RequiredFieldValidator>
				  </div>
				</div>
				<div class="form-group">        
				  <div class="col-sm-offset-2 col-sm-10">
					 <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" class="btn btn-outline-dark" />
				      <br />
				     <asp:Label ID="LblResult" Text="" runat="server"></asp:Label>
				  </div>
				</div>
			</div>
		</div>
	</div>
</div>
    </form>
</asp:Content>
