<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="/VB/DynamicPage.aspx.vb" Inherits="DynamicPage" %>

<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>

<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>

<%@ Register TagPrefix="uc1" TagName="sidebar1" Src="Template/request.ascx" %>

<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>

<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>

<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %><asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">

<head runat="server">

	<title></title>

	<META NAME="TITLE" CONTENT=""> 

	<META NAME="DESCRIPTION" content=""> 

	<META NAME="KEYWORDS" content=""> 

	<META NAME="AUTHOR" CONTENT="Aaron Rich Marketing <www.aaronrichmarketing.com>">

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


	<style>
	.iframe-container {
	  overflow: hidden;
	  /* Calculated from the aspect ration of the content (in case of 16:9 it is 9/16= 0.5625) */
	  padding-top: 56.25%;
	  position: relative;
	}

	.iframe-container iframe {
	   border: 0;
	   height: 100%;
	   left: 0;
	   position: absolute;
	   top: 0;
	   width: 100%;
	}	
	</style>


</head>

</asp:Content>













<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<section id="posRelNav" class="hide-on-med-and-down" style="color:#333;">

</section>
	
<section id="sub-page-header-image-section">
	<%= HeaderImage %>	
</section>



   

    

    

    <!--Services-->

    <form runat="server"  >

	<!--Services-->

    

		
	<section id="about" style="color:#f8f8f8; padding: 0;">

    	<div class="container-fluid" style="padding: 0;">

<!--            <div class="row">-->

                	<%= HttpUtility.HtmlDecode(Content) %>

                	<!--<asp:Label ID="lblContent" runat="server" style="color:#333;"></asp:Label>-->

                	

<!--            </div>-->

        </div>

    </section>

	</form> 

    

    

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

		

		
		$('.carousel').carousel({
			dist:0,
			padding:10,
		});









		$( ".click-to-toggle" ).click(function() {

			$('.tap-target').tapTarget('open');

		});

		

		$('.collapsible').collapsible();



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

