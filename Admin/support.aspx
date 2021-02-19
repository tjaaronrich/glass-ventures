<%@ Page Language="VB" debug="true" AutoEventWireup="false" CodeFile="VB/index.aspx.vb" Inherits="Index" validaterequest="false"  %>
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
    <!--
  Method 1:
  Using the Google APIs Client Library for JavaScript
-->
<script>
var apiKey = 'AIzaSyBg6-PW291_UeQZI242Fe7O7RVEirL8uHI';

function handleClientLoad() {
  gapi.client.setApiKey(apiKey);
  gapi.client.load('analytics', 'v3', makeRequest);
}

function makeRequest() {
  // Start coding cool things.
}
</script>
<script src="//apis.google.com/js/client.js?onload=handleClientLoad"></script>


<!--
  Method 2:
  Using REST and callback parameter
-->
<script>
function render() {
  // Place your awesome code here.
}
</script>

<!-- Replace RESOURCE with the path to the Google Analytics resource you're querying. -->
<script src="https://www.googleapis.com/analytics/v3/RESOURCE/?key=AIzaSyBg6-PW291_UeQZI242Fe7O7RVEirL8uHI&callback=render"></script>
     
      
        
	<!-- jQuery Library -->
	<script type="text/javascript" src="vendors/jquery-3.2.1.min.js"></script>
	<script src="js/userAccess.js" type="text/javascript"></script> 
    
    
    
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
        <section id="content">
          <!--start container-->
          <div class="container">
            <!--card stats start-->
            <div id="card-stats">
              <div class="row">
                <div class="col s12">
                  <div class="card">
                    <div class="card-content center">
                    </div>
                  </div>
                </div>

              </div>
            </div>
            <!--card stats end-->


            <!-- ecommerce product start-->
            <div id="ecommerce-product">
              <div class="row">
                <div class="col s12 m6">
                  <div class="card">
                    <div class="card-content center">
                    </div>
                    
                  </div>
                </div>
                <div class="col s12 m6">
                  <div class="card">
                    <div class="card-content center">
                    </div>
                  </div>
                </div>
              </div>
              <!-- ecommerce product end-->


              <!-- //////////////////////////////////////////////////////////////////////////// -->
            </div>
            <!--end container-->
        </div></section>
        <!-- END CONTENT -->
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
      <script type="text/javascript" src="vendors/js/scripts/dashboard-ecommerce.js"></script>
  

</body>
</html>