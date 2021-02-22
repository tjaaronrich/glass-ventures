<%@ Page Language="VB" debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="VB/default.aspx.vb" Inherits="FTBox2" validaterequest="false"  %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar1" Src="Template/request.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>

<%@ import namespace="System.Data" %> 
<%@ import namespace="System.Data.Odbc" %>
<%@ import namespace="System.Data.SqlClient" %>
<%@ import Namespace="System" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Net.Mail" %>
<%@ import Namespace="System.IO" %><asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">

<head>
	<title>Home | Glass Ventures</title>
	<META NAME="DESCRIPTION" content="Homepage for CareerSource Gulf Coast"> 
	<META NAME="AUTHOR" CONTENT="Aaron Rich Marketing <www.aaronrichmarketing.com>">
	<META NAME="REVISIT-AFTER" CONTENT="5 days">
	<META NAME="DISTRIBUTION" CONTENT="GLOBAL">
	<meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
	<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="author" content="">
	<!-- Materialize -->
    
	<%: Styles.Render("~/bundles/MaterialStyles") %>
    
<!--		Google fonts-->
	<link rel="preconnect" href="https://fonts.gstatic.com">
	<link href="https://fonts.googleapis.com/css2?family=Roboto&family=Source+Sans+Pro:wght@400;700;900&display=swap" rel="stylesheet">
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
    <script src="/plugins/jQuery/jquery-3.2.1.min.js"></script>
   	<script src="/framework/bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="/plugins/materialize/js/materialize.js"></script>
	<script src="https://www.google.com/recaptcha/api.js" async defer></script>
	<script runat="server" src="/plugins/mail/sendMailHome.vb"></script>
</head>
</asp:Content>

<asp:Content ID="SliderContent" ContentPlaceHolderID="SliderContent" runat="server"> 
	<div class="slider slider1 header-slider" style="">
		<ul class="slides">
			<%= Slider1 %>
		</ul>
	</div>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	
	<section>
		<div class="container-fluid">
			<div class="row d-flex flex-wrap align-items-center justify-content-center" style="padding: 100px 0; overflow: hidden;">
				<a class="home-col-img" href="#" target=�_blank� style="background-image: url('Graphics/home-image-1.png'); background-size: cover;">
					<h4 class="home-h4">Dolore magna</h5>
					<p class="p-home">Lorem ipsum dolor sit amet, ipsum labitur lucilius mel id, ad has appareat.</p>
					<div class="home-backs"></div>
				</a>
				<a class="home-col-img" href="#" target=�_blank� style="background-image: url('Graphics/home-image-2.png'); background-size: cover;">
					<h4 class="home-h4">Dolore magna</h5>
					<p class="p-home">Lorem ipsum dolor sit amet, ipsum labitur lucilius mel id, ad has appareat.</p>
					<div class="home-backs left-20 left-50"></div>
				</a>
				<a class="home-col-img" href="#" target=�_blank� style="background-image: url('Graphics/home-image-3.png'); background-size: cover;">
					<h4 class="home-h4">Dolore magna</h5>
					<p class="p-home">Lorem ipsum dolor sit amet, ipsum labitur lucilius mel id, ad has appareat.</p>
					<div class="home-backs left-40 top-30vh"></div>
				</a>
				<a class="home-col-img" href="#" target=�_blank� style="background-image: url('Graphics/home-image-4.png'); background-size: cover;">
					<h4 class="home-h4">Dolore magna</h5>
					<p class="p-home">Lorem ipsum dolor sit amet, ipsum labitur lucilius mel id, ad has appareat.</p>
					<div class="home-backs left-60 left-50 top-30vh"></div>
				</a>
				<a class="home-col-img-2" href="#" target=�_blank� style="background-image: url('Graphics/home-image-5.png'); background-size: cover;">
					<h4 class="home-h4">Dolore magna</h5>
					<p class="p-home">Lorem ipsum dolor sit amet, ipsum labitur lucilius mel id, ad has appareat.</p>
					<div class="home-backs left-80 wid-100 top-60vh"></div>
				</a>
			</div>
		</div>
	</section>
	
	<section>
		<div class="container-fluid">
			<div class="row justify-content-center schedule-row" style="padding: 100px 120px; overflow: hidden; background-color: #112D5C;">
				
				<div class="col-lg-12">
					<div class="d-flex w-100 justify-content-between mb-1 mobile-flex-col">
						<div>
							<h2 class="mb-1 white-t">CONTACT</h2>
							<p class="p-home">Schedule an appointment to visit our showroom, or if it�s more convenient for you we can visit your home for a free estimate.</p>
						</div>
					</div>
					
					
					
        			  <div class="row justify-content-between">
					    <div class="col-md-7 pl-4 pr-2">
							<form runat="server">
						  <div class="row">
							  <div class="input-field col-md-6 pl-2 pr-2">
								<input type="text" id="fullname" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Name" runat="server" >					
							  </div>
							  <div class="input-field col-md-6 pl-2 pr-2">
								<input type="text" id="email" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Email Address" runat="server" >
							  </div>

							  <div class="input-field col-md-6 pl-2 pr-2">
								<input type="text" id="phone" style="border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px;padding-left: 10px;box-sizing: border-box;" placeholder="Phone" runat="server" >
							  </div>

							  <div class="col-md-6 pl-2 pr-2">
								  <select class="input-field" id="requestType" runat="server" style="border:1px solid #ddd;background-color: #fff;box-shadow: none; border-radius:4px; padding-left: 10px; box-sizing: border-box;">
									  <option value="" selected="selected">Service you are interested in:</option>
									  <option value="Windows">Windows</option>
									  <option value="Doors">Doors</option>
									  <option value="Showers">Showers</option>
									  <option value="Commercial">Commercial</option>
									  <option value="Mirrors">Mirrors</option>
									  <option value="Handrails">Handrails</option>
									  <option value="Screen Rooms">Screen Rooms</option>
									  <option value="Hurricane Shutters">Hurricane Shutters</option>
									  <option value="Custom Glass">Custom Glass</option>
								  </select>
							  </div>
							
							  <div class="input-field col-md-6 pl-2 pr-2">
								  <textarea type="text" id="contactMessage" style="height: 100%; border:1px solid #ddd;background-color: #fff;box-shadow: none;border-radius:4px; padding: 10px;box-sizing: border-box;" placeholder="Message" runat="server" ></textarea>
							  </div>
							  <div class="col-md-6 pl-2 pr-2">
								  <div class="row" style="height: 100%; align-items: flex-end;">
									  <div class="input-field col-md-12">
										<div class="g-recaptcha" data-sitekey="6LeiwigaAAAAAOwqnTFo8jRZHNT-maRnU1hl9azv"></div>
										<span id="rAlert" role="alert" runat="server" style="display: none;">Please verify that you are not a robot.</span>
									  </div> 
									  <div class="input-field col-md-12">
										   <asp:Button ID="Submit" runat="server" OnClick="submit_click" Text="SUBMIT" style="background-color: #E28F2B; color: #fff; font-weight: 800; font-size: 22px; min-width: 100% !important; height: 60px; border: 0;" />
									  </div> 
									  <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>
								  </div>
							  </div>
							  
						  </div>
							</form>	  
					  </div>
					
					  <div class="col-md-5 pt-3 pl-2 pr-0">
						<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d55176.146111689646!2d-85.69824242022233!3d30.19401301844561!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x889383f4e8e25943%3A0xfc3e1bb46cdbc48f!2sGlass%20Ventures%2C%20Inc.!5e0!3m2!1sen!2sus!4v1610386521797!5m2!1sen!2sus" frameborder="0" style="border:0; width: 95%; height: 100%; min-height: 250px; margin-left: 2.5%;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
					  </div>
					</div>
					
				</div>
			</div>
		</div>
	</section>
	
	
	
	



	
<!--
	<section id="featured">
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<h2>Upcoming Events</h2>
					<a href="/events"><p id="upcoming-events"><img src="/graphics/calendar-title.png" class="img-fluid" /></p></a>
					<div class="row announcement-articles">
						<%= Announcements %>
					</div>
				</div>
			</div>
		</div>
	</section>
-->
	
<!--
	<section id="blog-area">
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<h2>Latest News</h2>
					<a href="/news-announcements"><p id="view-all-news"><img src="/graphics/view-all-news.png" class="img-fluid" /></p></a>
					<div class="row">
						<%= Blog %>
					</div>
				</div>
			</div>
		</div>
	</section>
-->
	
<!--
	<section id="contact">
		<div class="container">
			<div class="row">
				<div class="col-lg-4">
				<h2>Connect With Us</h2>
				<p><span>Job Center</span><br>625 Highway 231<br>Panama City, FL 32405<br>Phone: (850) 872-4340<br>Fax: (850) 872-4346</p>
				<p><span>Board Office</span><br>5230 W. Highway 98<br>Panama City, FL 32401<br>Phone: (850) 913-3285<br>Fax: (850) 913-3269</p>
				<div>
								<a href="https://www.facebook.com/CareerSourceGulfCoast/" target="_blank">
									<i class="icon fab fa-facebook-f contact-fb"></i>
								</a>
								<a href="https://twitter.com/careersourcegc" target="_blank">
									<i class="icon fab fa-twitter contact-tw"></i>
								</a>
							</div>
				</div>
			<div class="col-lg-8 col-md-6">
				<div class="row">
					<div class="col-lg-6 col-md-12 embed-col">
						<div class="fb-embed">
							<div id="fb-root"></div>
<script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v9.0" nonce="TdKHdE6y"></script>

<div class="fb-page" data-href="https://www.facebook.com/CareerSourceGulfCoast/" data-tabs="timeline" data-width="" data-height="" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true"><blockquote cite="https://www.facebook.com/CareerSourceGulfCoast/" class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/CareerSourceGulfCoast/">CareerSource Gulf Coast</a></blockquote></div>
						</div>
					</div>
					<div class="col-lg-6 col-md-12">
						<div class="tw-embed">
							<a class="twitter-timeline" data-height="495" href="https://twitter.com/careersourcegc?ref_src=twsrc%5Etfw">Tweets by careersourcegc</a> <script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
						</div>
					</div>

				</div>
			</div>
			</div>
		</div>
	</section>
-->

            
<!--<asp:Label ID="lblOut" runat="server"></asp:Label>-->
</asp:Content>

 


<asp:Content ID="ScriptDynamicContent" ContentPlaceHolderID="ScriptDynamicContent" runat="server">
<!-- jQuery -->

<!-- Bootstrap Core JavaScript -->



<!-- Plugin JavaScript 
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/latest/plugins/ScrollToPlugin.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/latest/TweenMax.min.js"></script>-->

<!-- Google Maps API Key - Use your own API key to enable the map feature. More information on the Google Maps API can be found at https://developers.google.com/maps/ -->
<!--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCRngKslUGJTlibkQ3FkfTxj3Xss1UlZDA&sensor=false"></script>-->

<!-- Theme JavaScript -->
<%--<script src="/js/theme.js"></script>--%>

<!-- Plugin Animations -->
<script src="plugins/animations/js/wow.js"></script>
<script src="plugins/animations/js/wow.init.js"></script>
<!--<script src="plugins/CountUp/js/CountUp.js"></script>
<script src="plugins/CountUp/js/eventWatcher.js"></script>-->

<!-- Masonry 
<script src='/plugins/masonry/js/imagesLoaded.js'></script>
<script src='/plugins/masonry/js/masonry.js'></script>
<script src="/plugins/masonry/js/index.js"></script>-->
    
    
    
    
    
    
<script>

	function tap(e) {
    	e.preventDefault();
    
	}	
	function isScrolledIntoView(elem)
	{
		var docViewTop = $(window).scrollTop();
		var docViewBottom = docViewTop + $(window).height();
		var elemTop = $(elem).offset().top;
		var elemBottom = elemTop + $(elem).height();
		return ((elemBottom >= docViewTop) && (elemTop <= docViewBottom) && (elemBottom <= docViewBottom) && (elemTop >= docViewTop));
	}
	function parallax()
	{
	  var image= document.getElementById('pier-fishing');
		//if(isScrolledIntoView($('#pier-fishing')))
		//{
			image.style.backgroundPositionX =  -(window.pageYOffset/ 10) + 'px';
		//}   
	  
	  var image2= document.getElementById('inshore-gulf-fishing');
		var nOffset= +(window.pageYOffset/ 10)
		nOffset -= 275
	  image2.style.backgroundPositionX= +nOffset + 'px';

	} 
	window.addEventListener("scroll",parallax,false)
	$(document).ready(function() {
		
		$('.carousel.carousel-slider').carousel({fullWidth: true});
		$('.parallax').parallax();


		$( ".click-to-toggle" ).click(function() {
			$('.tap-target').tapTarget('open');
		});
    	$('.collapsible').collapsible();
		$('.collapsible').collapsible('open', 0);

		$('.tap-target').tapTarget('close');

		$('.slider.slider1').slider({
			indicators: true,
		});
		$('.slider.slider2').slider({
			indicators: false,
		});
		$('.slider.slider3').slider({
			interval: 10000,
			height:440,
			indicators: true,
		});
		$(".button-collapse").sideNav();
		$(".button-collapse2").sideNav();
				
		
	});
</script>
                
</asp:Content>
