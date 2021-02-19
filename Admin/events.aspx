<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/ADMIN_Calendar2.aspx.vb" Inherits="ADMIN_Calendar2" validaterequest="false" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>








<asp:Content ID="headContentBefore" ContentPlaceHolderID="headContentBefore" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">
    <title>Aaron Rich Marketing CMS Dashboard</title>
</asp:Content>

<asp:Content ID="headContentAfter" ContentPlaceHolderID="headContentAfter" runat="server">

	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />
	<script src="/plugins/kendo/js/jquery.min.js"></script>
	<script src="/plugins/kendo/js/kendo.all.min.js"></script>
	
</asp:Content>
 
 
 
 
 
 
 
 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <!-- START CONTENT -->
        <form runat="server">
        	
        <section id="content">
          <!--start container-->
          <div class="container">
            <!--card stats start-->
            <div id="card-stats">
              <div class="row">
                <div class="col s12">
					<div class="row">  
						
				  		<div class="col s12">        
							<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Calendar" DataKeyNames="cNum" Width="100%" Font-Names="Arial" Font-Size="12px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" >
					<ControlStyle ForeColor="Black" />
				</asp:CommandField>
                <asp:BoundField DataField="cNum" HeaderText="Event ID" SortExpression="cNum" visible="false"/>
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" />
                <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" />
                <asp:BoundField DataField="StartTime" HeaderText="Start Time" SortExpression="StartTime" visible="false" />
                <asp:BoundField DataField="EndTime" HeaderText="End Time" SortExpression="EndTime" visible="false" />
                <asp:BoundField DataField="AllDay" HeaderText="All Day" SortExpression="AllDay" visible="false" />
                <asp:BoundField DataField="Repeats" HeaderText="Repeats" SortExpression="Repeats" visible="false"/>
                <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" visible="false"/>
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"
                    Visible="False" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="StartDateDisplay" HeaderText="StartDateDisplay" SortExpression="StartDateDisplay"
                    Visible="False" />
                <asp:BoundField DataField="EndDateDisplay" HeaderText="EndDateDisplay" SortExpression="EndDateDisplay"
                    Visible="False" />
            </Columns>
                            <Headerstyle BackColor="#666666" ForeColor="White" Font-Size="11px" HorizontalAlign="Left" Font-Bold="True" Font-Names="Arial"></Headerstyle>
                            <AlternatingRowStyle BackColor="#E5E5E5" ForeColor="Black" HorizontalAlign="Left" Font-Names="Arial"></AlternatingRowStyle>
        </asp:GridView>
							<asp:ObjectDataSource ID="ODS_Calendar" runat="server" DataObjectTypeName="PC_Calendar"
            DeleteMethod="DelCalendarEvent" SelectMethod="GetAllCalendarItems" TypeName="DAL_Calendar2">        </asp:ObjectDataSource>
        <asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="../App_Data/NewsFTBStatus.xml">        </asp:XmlDataSource>
				  		</div>                  
					</div>
               
               
               
               
               
               
                </div>
              </div>
            </div>
            <!--card stats end-->



            <!--end container-->
        </div>
        
        
        </section>
        </form>
        <!-- END CONTENT -->
</asp:content>









<asp:Content ID="ScriptDynamicContent" ContentPlaceHolderID="ScriptDynamicContent" runat="server">
     
      <!--materialize js-->
      <script type="text/javascript" src="vendors/js/materialize.min.js"></script>
      <!--prism-->
      <script type="text/javascript" src="vendors/prism/prism.js"></script>
      <!--scrollbar-->
      <script type="text/javascript" src="vendors/perfect-scrollbar/perfect-scrollbar.min.js"></script>
      <!-- chartjs -->
      <script type="text/javascript" src="vendors/chartjs/chart.min.js"></script>
      <!--plugins.js - Some Specific JS codes for Plugin Settings-->
      <script type="text/javascript" src="vendors/js/plugins.js"></script>
      <!--custom-script.js - Add your own theme custom JS-->
      <script type="text/javascript" src="vendors/js/custom-script.js"></script>
      <script type="text/javascript" src="vendors/js/scripts/dashboard-ecommerce.js"></script>
      
        <script>
			$( document ).ready(function() {
				
				$("#FileUpload0").kendoUpload();
				var userID = '<%= Session("UserAcctNum").ToString() %>';
				var changeID = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>'
				$('.datepicker').pickadate({
					selectMonths: true, // Creates a dropdown to control month
					selectYears: 15, // Creates a dropdown of 15 years to control year,
					format: 'yyyy/mm/dd',
					today: 'Today',
					clear: 'Clear',
					close: 'Ok',
					closeOnSelect: false // Close upon selecting a date,
				}); 
				
				
				var guid = '';
				var action = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>';
				if (action == '')
				{
					action = 'Add News Item'
				} else 
				{
					action = 'Update News Item'
				}
				console.log(guid);
				
				$("#SaveButton").click(function(){
					$.ajax({
							type: "POST",
							url: "/webservices/activityService.asmx/AddActivity",
							data: "{title:'News/Blog', user:'" + FullName + "', userID:'" + userID + "', guid:'" + guid + "', action: '" + action + "'}", 
							contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
							dataType: "json", // the data type we want back.  The data will come back in JSON format
							success: function (data) {
								//$("#searchresultsB").html(data.d); // it's a quirk, but the JSON data comes back in a property called "d"; {"d":"Hello Aidy F"}
							}
					});
				});
				
			});
			
			
			function uuidv4() {
			  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
				var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
				return v.toString(16);
			  });
			}

			

	  	</script>
  
</asp:content>
        
        