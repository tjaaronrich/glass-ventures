<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/ADMIN_TestimonialsAdd.aspx.vb" Inherits="ADMIN_TestimonialsAdd" %>
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
                <div class="col s9">
                
                
                
                
                
                
                
            		<asp:Label ID="lblTestimonialsNum" runat="server" Text="Label" Visible="False"></asp:Label>
            		<asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
            		
            		
            		
          			<!--<div class="col s12">
						<div class="demo-section k-content">
							<ul class="fieldlist">
								<li class="culture">
									<h5>Title:</h5>
									<asp:TextBox ID="txtTitle" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>
								</li>
							</ul>
						</div>
					</div>-->
            		
            		
          
          			<div class="col s12">
						<div class="demo-section k-content">
							<ul class="fieldlist">
								<li class="culture">
									<h5>Description:</h5>
									<asp:TextBox ID="txttDescription" TextMode="MultiLine" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>
								</li>
							</ul>
						</div>
					</div>
         
         
          
          
          
          
                    
                    
                    
                   <div class="col s12">
						<div class="demo-section k-content">
							<ul class="fieldlist">
								<li class="culture">
									<h5>Full Name:</h5>
									<asp:TextBox ID="txtfullName" runat="server" MaxLength="60" ></asp:TextBox>
								</li>
							</ul>
						</div>
					</div>
                    
                   
                   	
                   
                    
                    <div class="col s12">
						<div class="demo-section k-content">
							<ul class="fieldlist">
								<li class="culture">
									<h5>City:</h5>
									<asp:TextBox ID="txtCity" runat="server" MaxLength="60" ></asp:TextBox>
								</li>
							</ul>
						</div>
					</div>
                    
                    
                    
					
						
                  
                   
                   
                   
                  
                  
					  
                
                
                <!--<h5 align="left"><asp:Panel ID="pnlStatus2" runat="server" Visible="False"><asp:Label ID="Label15" runat="server" Text="Status:  "></asp:Label></asp:Panel>
				</h5>-->
					  
					  
					  
					  
                
                
						
					     
							
							

               
                </div>
                <div class="col s3">
                
                	 
                   <!--<div class="col s12">
						<div class="demo-section k-content">
							<ul class="fieldlist">
								<li class="culture">
									<h5>Website:</h5>
									<asp:TextBox ID="txtURL" runat="server" MaxLength="128" ></asp:TextBox>
								</li>
							</ul>
						</div>
					</div>-->
               
               
                
                
					<div class="col s12">
						<div class="demo-section k-content">
							<ul class="fieldlist">
								<li class="culture">
									<h5>Sort:</h5>

										<asp:TextBox ID="txttSort" runat="server" MaxLength="10"></asp:TextBox>

								</li>
							</ul>
						</div>
					</div>
                
                
                
                
                
                
                
                	
                	<asp:Panel ID="pnlStatus" runat="server" Visible="False" >
						<div class="col s12">
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5>Status:</h5>

											<asp:TextBox ID="txtStatus" runat="server" Visible="False" ></asp:TextBox>
											<asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList>

									</li>
								</ul>
							</div>
						</div>
                	</asp:Panel>
                	
                	
				</div>
				
				
				
				<div class="col s12">
						<div class="col s12">
							<asp:LinkButton ID="SaveButton" runat="server" CssClass="waves-effect waves-light btn btn-large  box-shadow btn-opt1" Text="Add Item" />
						</div>
					

					<asp:ObjectDataSource ID="ODS_Testimonials" runat="server" DataObjectTypeName="PC_Testimonials" DeleteMethod="DelTestimonials" SelectMethod="GetAllTestimonials" TypeName="DAL_Testimonials"><SelectParameters><asp:Parameter Name="TestimonialsStatus" Type="String" /></SelectParameters>
					</asp:ObjectDataSource>
					<asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/TestimonialsStatus.xml"></asp:XmlDataSource>

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
			$(document).ready(function() {
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
				
				
				var guid = '<%= strGUID %>';
				var action = '<%= Server.HtmlDecode(Request.QueryString("ftbNum")) %>';
				if (action == '')
				{
					action = 'Add Page'
				} else 
				{
					action = 'Update Page'
				}
				console.log(guid);
				
				$("#SaveButton").click(function(){
					$.ajax({
							type: "POST",
							url: "/webservices/activityService.asmx/AddActivity",
							data: "{title:'Pages', user:'" + FullName + "', userID:'" + userID + "', guid:'" + guid + "', action: '" + action + "'}", 
							contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
							dataType: "json", // the data type we want back.  The data will come back in JSON format
							success: function (data) {
								//$("#searchresultsB").html(data.d); // it's a quirk, but the JSON data comes back in a property called "d"; {"d":"Hello Aidy F"}
							}
					});
				});
				
				
				
				
			});
		</script>
  
</asp:content>
