﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB/ADMIN_LinksAdd.aspx.vb" Inherits="Admin_Uploads" validaterequest="false" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Register TagPrefix="uc1" TagName="materialHeader" Src="template/material-header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materialFooter" Src="template/material-footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materialLeftNavbar" Src="template/material-leftNavbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materialRightNavbar" Src="template/material-rightNavbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebarMenu" Src="template/sidebar-menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="topNavigation" Src="template/top-navigation.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="template/footer.ascx" %>
<!DOCTYPE html>
<html lang="en">
	
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">
    <title>Aaron Rich Marketing CMS Dashboard</title>
    <!-- Favicons-->
    <link rel="icon" href="../../images/favicon/favicon-32x32.png" sizes="32x32">
    <!-- Favicons-->
    <link rel="apple-touch-icon-precomposed" href="../../images/favicon/apple-touch-icon-152x152.png">
    <!-- For iPhone -->
    <meta name="msapplication-TileColor" content="#00bcd4">
    <meta name="msapplication-TileImage" content="images/favicon/mstile-144x144.png">
    <!-- For Windows Phone -->
    <!-- CORE CSS-->
    <link href="vendors/css/themes/fixed-menu/materialize.css" type="text/css" rel="stylesheet">
    <link href="vendors/css/themes/fixed-menu/style.css" type="text/css" rel="stylesheet">
    <!-- Custome CSS-->
    <link href="vendors/css/custom/custom.css" type="text/css" rel="stylesheet">
    <!-- INCLUDED PLUGIN CSS ON THIS PAGE -->
    <link href="vendors/perfect-scrollbar/perfect-scrollbar.css" type="text/css" rel="stylesheet">
    <link href="vendors/jvectormap/jquery-jvectormap.css" type="text/css" rel="stylesheet">
    <link href="vendors/flag-icon/css/flag-icon.min.css" type="text/css" rel="stylesheet">
    
    
    
	<% 
		If Session("accessLevel") < 1 Then
			Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("timeOut").ToString())
			
		Else If Session("accessLevel") Is Nothing Then
			Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("timeOut").ToString())
		End If
  	%>
  	
    <script type="text/javascript">
        var accesslevel = '<%= Session("accesslevel").ToString().ToLower() %>';
		var FullName = '<%= Session("FullName").ToString() %>';
		var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
    </script>  
	<!-- jQuery Library -->
	<script type="text/javascript" src="vendors/jquery-3.2.1.min.js"></script>
	<script src="js/userAccess.js" type="text/javascript"></script> 
   
   
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />
	<script src="/plugins/kendo/js/kendo.all.min.js"></script>
    
    
  </head>
  <body class="loading" style="">
    <!-- Start Page Loading -->
    <div id="loader-wrapper">
      <div id="loader"></div>
      <div class="loader-section section-left"></div>
      <div class="loader-section section-right"></div>
    </div>
    <!-- End Page Loading -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
	<uc1:materialHeader id=materialHeader runat="server"></uc1:materialHeader>
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START MAIN -->
    <div id="main">
      <!-- START WRAPPER -->
      <div class="wrapper">
        
		<uc1:materialLeftNavbar id=materialLeftNavbar runat="server"></uc1:materialLeftNavbar>
        <!-- //////////////////////////////////////////////////////////////////////////// -->
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
							<asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
							<asp:Label ID="lbllinkNum" runat="server" Text="Label" Visible="False"></asp:Label>
						</div>
						<div class="col s9">



           			
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5 align="left">Link Name</h5>
										<asp:TextBox ID="txtlinkName" runat="server" Width="100%" MaxLength="60"></asp:TextBox>
									</li>
								</ul>
							</div>
							
							
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5 align="left">URL</asp:Label></h5>
										<asp:TextBox ID="txtURL" runat="server" Width="100%" MaxLength="60"></asp:TextBox>
									</li>
								</ul>
							</div>
           			
           			
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5 align="left">Link Description</asp:Label></h5>
										<asp:TextBox ID="txtlinkDescription" runat="server" Height="100" Width="100%" TextMode="MultiLine" Wrap="true" ></asp:TextBox>
									</li>
								</ul>
							</div>
           			
           			

						</div>
						<div class="col s3">
						
						
						
							
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5 align="left">Sort</asp:Label></h5>
										<asp:TextBox ID="txtlinkSort" runat="server" Width="100%" MaxLength="60"></asp:TextBox>
									</li>
								</ul>
							</div>
						
							
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										
										<h5>Category: </h5>
										<asp:Panel ID="pnlStatus2" runat="server" Visible="True" >
											<asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="XDS_Category" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList>
										</asp:Panel>
										<asp:TextBox ID="txtCategory" runat="server" Visible="False" Width="27px"></asp:TextBox>
									</li>
								</ul>
							</div>
							
							<!--<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5><asp:Label ID="Label15" runat="server" Text="Status:  "></asp:Label></h5>
										<asp:TextBox ID="txtStatus" runat="server" Visible="False" ></asp:TextBox>
										<asp:DropDownList ID="ddllinkCategory" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList>
									</li>
								</ul>
							</div>-->
							
							
							
						</div> 
				  		<div class="col s12">        
							<asp:LinkButton ID="SaveButton" runat="server" Text="Add News Item" CssClass="waves-effect waves-light btn btn-large  box-shadow btn-opt1" />  
							<p>&nbsp;</p>
							<asp:Label ID="guidLabel" runat="server" Text=""  style="position: absolute;visibility: hidden;width: 0;height: 0;overflow: hidden;"></asp:Label>
							<asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/NewsFTBStatus.xml"></asp:XmlDataSource>
							<asp:XmlDataSource ID="XDS_Featured" runat="server" DataFile="~/App_Data/FeaturedStatus.xml"></asp:XmlDataSource>
							<asp:XmlDataSource ID="XDS_Category" runat="server" DataFile="~/App_Data/CategoryLinks.xml"></asp:XmlDataSource>
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
				
				
				var guid = '<%= strGUID %>';
				var action = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>';
				if (action == '')
				{
					action = 'Add Link Item'
				} else 
				{
					action = 'Update Link Item'
				}
				console.log(guid);
				
				$("#SaveButton").click(function(){
					$.ajax({
							type: "POST",
							url: "/webservices/activityService.asmx/AddActivity",
							data: "{title:'Links', user:'" + FullName + "', userID:'" + userID + "', guid:'" + guid + "', action: '" + action + "'}", 
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
        <!-- Floating Action Button -->
        <div class="fixed-action-btn" style="bottom: 50px; right: 19px;">
          <a class="btn-floating btn-large">
            <i class="material-icons">add</i>
          </a>
          <ul>
            <li>
              <a href="css-helpers.html" class="btn-floating blue" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">help_outline</i>
              </a>
            </li>
            <!--<li>
              <a href="cards-extended.html" class="btn-floating green" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">widgets</i>
              </a>
            </li>
            <li>
              <a href="app-calendar.html" class="btn-floating amber" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">today</i>
              </a>
            </li>
            <li>
              <a href="app-email.html" class="btn-floating red" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">mail_outline</i>
              </a>
            </li>-->
          </ul>
        </div>
        <!-- Floating Action Button -->
        <!-- //////////////////////////////////////////////////////////////////////////// -->

		<uc1:materialRightNavbar id=materialRightNavbar runat="server"></uc1:materialRightNavbar>
        </div>
        <!-- END WRAPPER -->
      </div>
      <!-- END MAIN -->
  	<!-- //////////////////////////////////////////////////////////////////////////// -->

	<uc1:materialFooter id=materialFooter runat="server"></uc1:materialFooter>
	<!-- ================================================
    Scripts
    ================================================ -->
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
  

</body>
</html>