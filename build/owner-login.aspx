<%@ Page Language="VB" debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="VB/owner-login.aspx.vb" Inherits="Login" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %><asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">

<head>
	
	<title>The Summerhouse</title>
	<META NAME="TITLE" CONTENT="The Summerhouse"> 
	<META NAME="DESCRIPTION" content="The Summerhouse"> 
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


    
    
    
    
        
    
    
    
    


    <!-- Theme CSS -->
    <link href="/css/theme.css" rel="stylesheet">
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

<section id="posRelNav" class="hide-on-med-and-down" style="color:#333;">
</section>

<div class=" subpage parallax-container">
  <div class="parallax">
	  <div class="container">
		<div class="row align-items-center" style="top: 35%;position: absolute;padding-left: 15px;z-index:1;">
			<div class="col-md-12">
				<h2 style="color:#ffffff;margin:0;font-size:50px;">Owner Login</h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/background-02.jpg" style="width:100%;">
  </div>
</div>
    
    

    
    
    
    <!--Services-->
    <form runat="server" defaultbutton="" style="margin-bottom:0;" >
	<section id="services" style="background-color:#ffffff;">
    	<div class="container about-container">
            <div class="row">    
                <div class="col-md-7" style="padding-bottom:10px;color:#333;">
                  	<p>&nbsp;</p>
                    <div class="col-lg-12" style="padding-top:10px;">
							<div class="row" style="padding-right:30px;">
								<div class="input-field col-md-12">
								  <i style="color:#9e9e9e;" class="material-icons prefix">account_circle</i>
								  <input id="txtUserName" runat="server" style="color:#9e9e9e;border-bottom:1px solid #9e9e9e;box-shadow: none;"  type="text" class="validate">
								  <label style="color:#9e9e9e;margin-left:4rem;width:auto;" for="icon_prefix">Username</label>
								</div>
								<div class="input-field col-md-12">
								  <i style="color:#9e9e9e;" class="material-icons prefix">lock_open</i>
								  <input id="txtPassword" runat="server" type="password" style="color:#9e9e9ev;border-bottom:1px solid #9e9e9e;box-shadow: none;"  class="validate">
								  <label style="color:#9e9e9e;margin-left:4rem;width:auto;" for="icon_mail">Password</label>
								</div>
							</div>
                    </div>
                    <div class="col-lg-12">
                    	<p style="margin-top:15px; margin-bottom:10px;">
                        <asp:Button id="Button1" Text="Submit" OnClick="Button1_Click" runat="server" class="btn-large z-depth-5" style=""/></p>
                    	
                    	<asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Name="Arial" Font-Size="12px"></asp:Label><asp:Label ID="lblURL" runat="server" ForeColor="#FF0000" Visible="false"></asp:Label>
                    </div>
                    <div class="col-lg-12">
						<p>&nbsp;</p>
                    	<p>Forgot your account username/password or need to request an admin login? <strong><a href="mailto:aaron@aaronrich.com" style="">Contact the site administrator</a></strong></p>
                  		<p>&nbsp;</p>
                    </div>
                </div>
                <div class="col-md-2"><img src="Graphics/spacer.gif" width="100%" height="0px;"></div>
              	
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
