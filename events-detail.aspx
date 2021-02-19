<%@ Page Language="VB" validaterequest="false" MasterPageFile="~/Site.Master" debug="true" src="/vb/Events-Detail.aspx.vb" Inherits="EventsDetail" %> 
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
	<title>Events Detail | CareerSource Gulf Coast</title>
	<META NAME="DESCRIPTION" content="Events Detail | CareerSource Gulf Coast"> 
	<META NAME="AUTHOR" CONTENT="Events Detail | CareerSource Gulf Coast">
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
	<link rel="shortcut icon" href="/Graphics/favicon.ico" type="image/x-icon">
	<link rel="icon" href="/Graphics/favicon.ico" type="image/x-icon">

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
				<h2>Events Detail</h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/contact-us-bg.jpg" id="main-content-header-image">
  </div>
</div>
    
<section id="" style="padding: 80px 0;">
        <div class="container">
            <div class="row">
				
				
				
                <div class="col-md-12" style="padding-bottom:10px;margin-top:40px;">
			  		<form runat="server" style="margin-bottom:0;" >

								  <h1 style="color:#1fc3f0;"><asp:Label ID="lblTitle" runat="server" Text="" Visible="True"></asp:Label></h1>
								  <br />
								  <div class="sharethis-inline-share-buttons"></div>
									<p>&nbsp;</p>
						
									
							    <% If Not ImageCheck = "" Then %>
								<img src="<%= FeaturedImage %>" class="img-fluid" style="margin-left: auto;margin-right: auto;display: block;"/>
						        <% End If %>
								<p>&nbsp;</p>
						
								<% If Not lblItemDate.Text = "" Then %>
    								<p><strong style="font-weight:bold;">Event Date: <em><asp:Label ID="lblItemDate" runat="server" Text="" Visible="True"></asp:Label></em></strong></p>
								<% End If %>
									
								<% If Not StartEndTime = "/" Then %>
									<p><strong style="font-weight:bold;">Start/End Times: <em><%= StartEndTime %></em></strong></p>
								<% End If %>
									
								<% If Not Location = "" Then %>
									<p><strong style="font-weight:bold;">Location: <em><%= Location %></em></strong></p>
								<% End If %>
									
								<% If Not ContactNumber = "" Then %>
									<p><strong style="font-weight:bold;">Contact: <em><%= ContactNumber %></em></strong></p>
								<% End If %>
									
								<% If Not lblContent.Text = "" Then %>
									<p style="margin-top:5px;"><span style="margin-top:5px; margin-bottom:10px"><asp:Label ID="lblContent" runat="server" Text="" Visible="True"></asp:Label></span></p>
								<% End If %>

								<p></asp:Label><asp:Label ID="lblImageFile" runat="server" Text="" Visible="False"></asp:Label><asp:Label ID="lblSummary" runat="server" Text="" Visible="False"></asp:Label></p>
								<p>&nbsp;</p>
								<div class="sharethis-inline-share-buttons"></div>
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




