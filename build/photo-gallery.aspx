<%@ Page Language="VB" debug="true" AutoEventWireup="false" CodeFile="VB/gallery.aspx.vb" Inherits="Gallery" validaterequest="false"  %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.Odbc" %>
<%@ import namespace="System.Data.SqlClient" %> 
<%@ import Namespace="System" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Net.Mail" %>
<%@ import Namespace="System.IO" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Miller Marine</title>
	<META NAME="TITLE" CONTENT="Miller Marine"> 
	<META NAME="DESCRIPTION" content="Miller Marine"> 
	<META NAME="AUTHOR" CONTENT="Aaron Rich Marketing <www.aaronrichmarketing.com>">
	<META NAME="GOOGLEBOT" CONTENT="ALL">
	<META NAME="ROBOTS" CONTENT="ALL, INDEX, FOLLOW">
	<META NAME="REVISIT-AFTER" CONTENT="5 days">
	<META NAME="DISTRIBUTION" CONTENT="GLOBAL">
	<meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">





    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="author" content="">
   
	<!-- Materialize -->
    
    
    <link href="/plugins/materialize/css/materialize.css" rel="stylesheet">
    
    
    <!-- Bootstrap Core CSS -->
    <link href="/framework/bootstrap/css/animate.css" rel="stylesheet">
    <link href="/framework/bootstrap/vendor/bootstrap/css-4/bootstrap.min.css" rel="stylesheet">
    
    
    <link href="/css/creative.min.css" rel="stylesheet">


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    
    
    
    
    <!-- Slideshow -->

	<!-- Linked Files -->
	<link rel="shortcut icon" href="Graphics/favicon.ico" type="image/x-icon">
	<link rel="icon" href="Graphics/favicon.ico" type="image/x-icon">


    
    
    
    
        
    
    
    
    


    <!-- Theme CSS -->
    <link href="/css/theme.css" rel="stylesheet">
    <link href="/css/theme-sass.css" rel="stylesheet">
    <link href="/css/custom.css" rel="stylesheet">
    
    
    
    
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="/plugins/kendo/js/kendo.all.min.js"></script>
	<script src="http://demos.telerik.com/kendo-ui/content/dataviz/map/js/chroma.min.js"></script>

   	<script src="/framework/bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>
    
    <script src="/plugins/materialize/js/materialize.js"></script>

		
		
		
		
	<script src="https://use.typekit.net/dty8oga.js"></script>
	<script>try{Typekit.load({ async: true });}catch(e){}</script>


</head>

<body style="margin:0;">
<uc1:header1 id=header1 runat="server"></uc1:header1>

	
   
<div class=" subpage parallax-container">
  <div class="parallax">
	  <div class="container">
		<div class="row align-items-center" style="top: 35%;position: absolute;padding-left: 15px;z-index:1;">
			<div class="col-md-12">
				<h2 style="color:#ffffff;margin:0;font-size:50px;">Photo Gallery</h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/hero-1.jpg" style="width:100%;">
  </div>
</div>
   
    
    
    
    
	<section class="no-padding" id="portfolio">
        <div class="container-fluid">
            <div class="row no-gutter popup-gallery" style="margin-bottom:0;">
				<%= Gallery %>
          	</div>
        </div>
    </section>
    
    
    
    
   
    
    
    
    
    <!--<section id="" style="padding-top:50px;padding-bottom:50px;background-size:cover;background-position:center;background-repeat:no-repeat;background-color:#ffffff;">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    

						<asp:Label ID="lblOut" runat="server"></asp:Label>
                       
                </div>
            </div>
        </div>
    </section>-->
    

	<uc1:footer1 id=footer1 runat="server"></uc1:footer1>
 


<!-- jQuery -->

<!-- Bootstrap Core JavaScript -->



<!-- Plugin JavaScript -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>

<!-- Google Maps API Key - Use your own API key to enable the map feature. More information on the Google Maps API can be found at https://developers.google.com/maps/ -->
<!--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCRngKslUGJTlibkQ3FkfTxj3Xss1UlZDA&sensor=false"></script>-->

<!-- Theme JavaScript -->
<%--<script src="/js/theme.js"></script>--%>

<!-- Plugin Animations -->
<script src="plugins/animations/js/wow.js"></script>
<script src="plugins/animations/js/wow.init.js"></script>
<script src="plugins/CountUp/js/CountUp.js"></script>
<script src="plugins/CountUp/js/eventWatcher.js"></script>

<!-- Masonry -->
<script src='/plugins/masonry/js/imagesLoaded.js'></script>
<script src='/plugins/masonry/js/masonry.js'></script>
<script src="/plugins/masonry/js/index.js"></script>
    
    
    
    
    
    
<script>
				
	



				
	$(document).ready(function() {
					

		//$('#navbar').pushpin({
		//	top: $('#navbar').offset().top
		//});

		$('.parallax').parallax();


		$( ".click-to-toggle" ).click(function() {
			$('.tap-target').tapTarget('open');
		});

		$('.tap-target').tapTarget('close');
		$('.slider').slider({
			indicators: false,
		});
		$(".button-collapse").sideNav();
		$(".button-collapse2").sideNav();
				
		
	});
</script>
</body>
</html>
