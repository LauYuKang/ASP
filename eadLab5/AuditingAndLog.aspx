<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage1.master" CodeBehind="AuditingAndLog.aspx.cs" Inherits="eadLab5.AuditingAndLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        function ConfirmOnDelete()
        {
          if (confirm("Are you sure?")==true)
            return true;
          else
            return false;
        }
    </script>

    <form id="form1" runat="server">
    <div style="text-align:center;margin:0.8em;">
        <asp:Label ID="pageLabel" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="XX-Large" ForeColor="Maroon" Text="Audit Log"></asp:Label>
    </div>
    
    <div style="text-align:center;margin:auto;display:block;width:16%">
        <asp:TextBox ID="tb_date" runat="server" CssClass="form-control" TextMode="Date" OnTextChanged="tb_date_TextChanged"  ></asp:TextBox>
        <asp:Button ID="btn_retrieve" runat="server" Text="Retrieve" OnClick="btn_retrieve_Click" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh" />
    </div> <br />

    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AuditId" DataSourceID="EADP" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" Width="100%" OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound">

        <AlternatingRowStyle BackColor="#EEEFF9" />


        <Columns >
            <asp:BoundField DataField="AuditId" HeaderText="AuditId" InsertVisible="False" ReadOnly="True" SortExpression="AuditId" />
            <asp:BoundField DataField="ActionType" HeaderText="ActionType" SortExpression="ActionType" />
            <asp:BoundField DataField="ActionDate" HeaderText="ActionDate" SortExpression="ActionDate" />
            <asp:BoundField DataField="StaffID" HeaderText="StaffID" SortExpression="StaffID" />
            <asp:BoundField DataField="AdminNo" HeaderText="AdminNo" SortExpression="AdminNo" />
            <asp:BoundField DataField="IPAddress" HeaderText="IPAddress" SortExpression="IPAddress" />
            <asp:BoundField DataField="TableName" HeaderText="TableName" SortExpression="TableName" />
            <asp:BoundField DataField="RecNumber" HeaderText="RecNumber" SortExpression="RecNumber" />
            <asp:BoundField DataField="IsBanned" HeaderText="Banned" SortExpression="IsBanned" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True"  />
        </Columns>
        <SelectedRowStyle BackColor="DarkTurquoise" BorderStyle="Solid" />

        <RowStyle BackColor="White" Font-Bold="False" HorizontalAlign="Left" />
            <FooterStyle BackColor="White" HorizontalAlign="Left" BorderWidth="1px" BorderColor="Black" />
            <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#4b3cbc" Wrap="true"  HorizontalAlign="Left" />
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" />
            <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
    </asp:GridView>
    <div style="margin-bottom:100px"></div>



  
    <asp:SqlDataSource ID="EADP" runat="server" ConnectionString="<%$ ConnectionStrings:EADPConnectionString %>" 
        SelectCommand="SELECT * FROM [AuditLog]" FilterExpression="ActionDate LIKE '{0}%'">
        <FilterParameters>
            <asp:ControlParameter Name="date" ControlID="tb_date" PropertyName="Text" />
        </FilterParameters>
    </asp:SqlDataSource>
</form>

</asp:Content>



