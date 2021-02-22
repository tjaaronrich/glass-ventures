<%@ Page Language="VB" MasterPageFile="~/Site.Master" debug="true" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar1" Src="Template/request.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %>
<%@ import namespace="System.Data" %> 
<%@ import namespace="System.Data.Odbc" %>
<%@ import namespace="System.Data.SqlClient" %>
<%@ import Namespace="System" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Net.Mail" %>
<%@ import Namespace="System.IO" %><asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">

<head>
	<title>Contact Us | CareerSource Gulf Coast</title>
	<META NAME="DESCRIPTION" content="Contact Us | CareerSource Gulf Coast"> 
	<META NAME="AUTHOR" CONTENT="Contact Us | CareerSource Gulf Coast">
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
    
    
    
    
	<%: Styles.Render("~/bundles/MaterialStyles") %>
    
    
    <!-- Bootstrap Core CSS -->
    <link href="/framework/bootstrap/css/animate.css" rel="stylesheet">
    <link href="/framework/bootstrap/vendor/bootstrap/css-4/bootstrap.min.css" rel="stylesheet">


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    
    
    
    
    <!-- Slideshow -->

	<!-- Linked Files -->
	<link rel="shortcut icon" href="/Graphics/favicon.png" type="image/x-icon">
	<link rel="icon" href="/Graphics/favicon.png" type="image/x-icon">

	<link rel="stylesheet" href="https://use.typekit.net/gbc2crx.css">
    
    
    
    
        
    
    
    
    


    <!-- Theme CSS -->
    
	<%: Styles.Render("~/bundles/CommonStyles") %>
    
    <!--<link href="/css/custom.css" rel="stylesheet">-->
    
    
    <link href="/css/creative.min.css" rel="stylesheet">
    
    
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="/plugins/kendo/js/kendo.all.min.js"></script>
	<script src="http://demos.telerik.com/kendo-ui/content/dataviz/map/js/chroma.min.js"></script>

   	<script src="/framework/bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>
    
    <script src="/plugins/materialize/js/materialize.js"></script>

	<script src="https://www.google.com/recaptcha/api.js" async defer></script>	
		
	<script runat="server" src="/plugins/mail/sendMail.vb" ></script>
		
		


</head>
</asp:Content>
		



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<section id="posRelNav" class="hide-on-med-and-down">
</section>
    
<div class=" subpage parallax-container">
  <div class="parallax">
	  <div class="container">
		<div class="row align-items-center" id="main-content-header">
			<div class="col-md-12">
				<h2>Schedule a Consultation</h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/home-header-img.png" id="main-content-header-image">
  </div>
</div>
    
	<section class="">
		<div class="container-fluid">
			<div class="row justify-content-center schedule-row">
				<div class="col-lg-12 schedule-back-1 mobile-dn"></div>
				<div class="col-lg-12 schedule-back-2 mobile-dn"></div>
				<div class="col-lg-12 schedule-back-3 mobile-dn"></div>
				
				<div class="col-lg-12 schedule-front">
					<div class="d-flex w-100 justify-content-between mb-5 mobile-flex-col">
						<div>
							<h1 style="font-weight: 800; font-size: 57px;">Schedule a Consultation</h1>
							<h5 class="mb-4">Complete the form below and someone from our team will reach out to you</h5>
						</div>
						<a href="tel:850-215-5060"><h6>Call us instead</h6></a>
					</div>
					
					
					<form runat="server">
        			<div class="row justify-content-between">
					  <div class="input-field col-md-4 pr-5 mobile-no-pd-right mb-4">
						<input type="text" id="fullname" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Name" runat="server" >
						
					  </div>

					  <div class="input-field col-md-4 pr-5 mobile-no-pd-right mb-4">
						<input type="text" id="email" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Email Address" runat="server" >
					  </div>
						
					  <div class="input-field col-md-4 mb-4">
						<input type="text" id="phone" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Phone" runat="server" >
					  </div>
					</div>
					<div class="row justify-content-start">
					  <div class="input-field col-md-4 mb-4">
						  <input type="text" id="requestType" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Request Type" runat="server" >
						  
					  </div>
					  <div class="input-field col-md-4 pr-5 mobile-no-pd-right mb-4">
						  <input type="text" id="locationType" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Location Type" runat="server" >
						  

					  </div>
					  <div class="input-field col-md-4 pr-5 mobile-no-pd-right mb-4">
						<div class="g-recaptcha" data-sitekey="6LdCLBkaAAAAAGy6cXGvMOwboML3bszYrgU0qDqx"></div>
						<span id="rAlert" role="alert" runat="server" style="display: none;">Please verify that you are not a robot.</span>
					  </div>
				 	 
					</div>
					<div class="row">
					  <div class="input-field col-md-12 mb-5">
						 
						  <asp:Button ID="Submit" runat="server" OnClick="submit_click" Text="Submit Request" style="background-color: #2E335A; color: #fff; font-weight: 800; font-size: 22px; min-width: 100% !important; height: 60px; border: 0;" />
					  </div>
					</div>
					</form>
				</div>
			</div>
		</div>
	</section>
</asp:Content>

 


<asp:Content ID="ScriptDynamicContent" ContentPlaceHolderID="ScriptDynamicContent" runat="server">
 


<!-- jQuery -->

<!-- Bootstrap Core JavaScript -->



<!-- Plugin JavaScript -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/latest/plugins/ScrollToPlugin.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/latest/TweenMax.min.js"></script>

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
				


/*$(function(){
	
	var $window = $(window);		//Window object
	
	var scrollTime = .25;			//Scroll time
	var scrollDistance = 350;		//Distance. Use smaller value for shorter scroll and greater value for longer scroll
		
	$window.on("mousewheel DOMMouseScroll", function(event){
		
		event.preventDefault();	
										
		var delta = event.originalEvent.wheelDelta/120 || -event.originalEvent.detail/3;
		var scrollTop = $window.scrollTop();
		var finalScroll = scrollTop - parseInt(delta*scrollDistance);
			
		TweenMax.to($window, scrollTime, {
			scrollTo : { y: finalScroll, autoKill:true },
				ease: Power1.easeOut,	//For more easing functions see https://api.greensock.com/js/com/greensock/easing/package-detail.html
				autoKill: true,
				overwrite: 5							
			});
					
	});
	
});*/
	function tap(e) {
    	e.preventDefault();
    
	}	
	$(document).ready(function() {
		/*$('.scrollspy').scrollSpy({
			getActiveElement: function(id) {
				console.log(id);
				if(id == "test")
				{
					console.log('change logo');
				}
		  	}
		});*/

		$('.parallax').parallax();


		$( ".click-to-toggle" ).click(function() {
			$('.tap-target').tapTarget('open');
		});

		$('.tap-target').tapTarget('close');

		$('.slider.slider1').slider({
			indicators: false,
		});
		$('.slider.slider2').slider({
			indicators: false,
		});
		$('.slider.slider3').slider({
			interval: 10000,
			indicators: true,
		});
		$('.slider1').slider('pause');
		$(".button-collapse").sideNav();
		$(".button-collapse2").sideNav();
				
		
	});
</script>
		</asp:Content>
