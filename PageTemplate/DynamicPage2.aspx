<%@ Page Language="VB" AutoEventWireup="false" CodeFile="/VB/DynamicPage.aspx.vb" Inherits="DynamicPage" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="/Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar1" Src="/Template/request.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="/Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="/Template/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="/Template/sidebar-contact.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head id="Head1" runat="server">
  	<meta charset="utf-8">
    <title>Website Design :: IT Support :: Digital Marketing</title>
    <meta name="TITLE" content="Website Design :: IT Support :: Digital Marketing"> 
    <meta name="DESCRIPTION" content="Supporting commercial and non-profit website and IT services clients since 2000, the staff at Aaron Rich Marketing specializes in website development, IT services, network administration, social networking, search engine optimization (SEO), and digital marketing.  Contact us today for a free consultation."> 
    <meta name="KEYWORDS" content="website design, it services, network administration, Custom Website Design, Website Hosting, website Maintenance, Graphic Illustration, print Media, Corporate Branding, Search Engine Optimization, SEO, Social Networking, Information Technology Support, IT Support"> 
    <meta name="revisit-after" content="5 days">
    <meta name="ROBOTS" content="all">
    <meta name="rating" content="GENERAL">
    <meta name="distribution" content="GLOBAL">
    <meta name="AUTHOR" content="Aaron Rich Digital Marketing &amp; IT Services <www.aaronrich.com>">


    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
   
	<!-- Masonry -->
    <!--<link rel="stylesheet" href="/plugins/masonry/css/style.css">-->
    <!-- Bootstrap Core CSS -->
    <link href="/framework/bootstrap/css/animate.css" rel="stylesheet">
    <link href="/framework/bootstrap/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Theme CSS -->
    <link href="/css/theme.css" rel="stylesheet">
    <link href="/css/custom.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="/framework/bootstrap/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,700" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lato:400,700,400italic,700italic" rel="stylesheet" type="text/css">

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

	<!-- Google Fonts -->
	<link href='https://fonts.googleapis.com/css?family=Titillium+Web:400,600,700,900' rel='stylesheet' type='text/css'>
	<link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,700' rel='stylesheet' type='text/css'>
	<link href="https://fonts.googleapis.com/css?family=Roboto:400,500,700" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Abel" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="/plugins/pushMenu/css/jPushMenu.css" />

    <style>
    .fill {
    		width: 100%;
    		height: 100%;
    		background-position: center;
    		-webkit-background-size: cover;
    		-moz-background-size: cover;
    		background-size: cover;
    		-o-background-size: cover;
			background-image:url('https://avada.theme-fusion.com/agency/wp-content/uploads/sites/11/2017/03/video_agency_home_preview.jpg');
			opacity:1;
	}
    .fill2 {
    		width: 100%;
    		height: 100%;
    		background-position: center;
    		-webkit-background-size: cover;
    		-moz-background-size: cover;
    		background-size: cover;
    		-o-background-size: cover;
			opacity:.4;
			visibility: visible;
	}
	.carousel-inner {
    	height: 100%;
	}
	.item.active {
    	height: 100%;
	}
		@media(min-width: 768px)
		{
			.fill
			{
				
				background-image:none;
				opacity: 0.4;
			}
			.fill2
			{
				
				background-image:none;
				opacity: 0.4;
				visibility: hidden;
			}
		}
    </style>
    
    
</head>
<body id="page-top" class="index" style="background-color:#ffffff;">

    <!-- Navigation -->
    <uc1:header1 id=header1 runat="server"></uc1:header1>
    <!-- Header -->
    
<!--<header id="myCarousel" class="carousel slide" style="height:550px;">-->


    
    
    <!--Services-->
    <form runat="server"  >
	<!--Services-->
    
	<section id="about" style="color:#333;">
    	<div class="container about-container">
            <div class="row">    
                <div class="col-md-7" style="padding-bottom:10px;margin-top:2%;">
                	<%= HttpUtility.HtmlDecode(Content) %>
                	<!--<asp:Label ID="lblContent" runat="server" style="color:#333;"></asp:Label>-->
                	<%--<h2 style="color:#315487;">About Us</h2>
                    
                    <hr style="width:35%;background-color:#cc2435;height:3px;bold;float:left;">
                    
                    <p>&nbsp;</p>
                    
                    <p style="padding-top:10px;">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas pulvinar faucibus felis interdum rutrum. Sed pellentesque egestas diam at auctor. Fusce quis turpis in purus eleifend suscipit. Vivamus eu orci et turpis lobortis posuere ut nec libero.</p>
                    
                	<button type="submit" class="btn btn-success btn-lg">Learn More</button>--%>
                </div>
                <div class="col-md-2"><img src="Graphics/spacer.gif" width="100%" height="0px"></div>
              	
    			<uc1:sidebar id=sidebar runat="server"></uc1:sidebar>
            </div>
        </div>
    </section>
	</form> 
    
    
    
    
    
    
    
    
    
    
        <!-- Footer -->
	<uc1:footer1 id=footer1 runat="server"></uc1:footer1>

    <!-- jQuery -->
    <script src="/framework/bootstrap/vendor/jquery/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="/framework/bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>

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
    <script src="/framework/bootstrap/js/bootstrap-carousel.js"></script>
    <script>
    	$('.carousel').carousel({
        	interval: 20000 //changes the speed
    	})
    </script>
    
    <script src="/plugins/pushMenu/js/jPushMenu.js"></script>

<!--call jPushMenu, required-->
<script>
jQuery(document).ready(function($) {
	$('.toggle-menu').jPushMenu();
});
</script>
<script>
$(document).ready(function(){
	
	$(".dropdown").on("click", function(){
    	if ($(this).hasClass("open")) {
 			$(this).removeClass("open");
    	} else {
 			$(this).addClass("open");
		}
 
	});
	
});
</script>
    
    
    
    
    
</body>
</html> 
