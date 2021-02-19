<%@ Page Language="VB" MasterPageFile="~/Site.Master" debug="true"  %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %>




<asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">
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
    <link href="/css/theme-sass.css" rel="stylesheet">
    <!--<link href="/css/custom.css" rel="stylesheet">-->
    
    
    <link href="/css/creative.min.css" rel="stylesheet">
    
    
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="/plugins/kendo/js/kendo.all.min.js"></script>
	<script src="http://demos.telerik.com/kendo-ui/content/dataviz/map/js/chroma.min.js"></script>

   	<script src="/framework/bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>
    
    <script src="/plugins/materialize/js/materialize.js"></script>


        <!--<script src="/plugins/blog/js/blog.js"></script>-->
        <!-- Facebook Code -->
<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=583289895031935";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
</head>

</asp:Content>
   
   
   
   
   

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<div class=" subpage parallax-container">
  <div class="parallax">
	  <div class="container">
		<div class="row align-items-center" style="top: 35%;position: absolute;padding-left: 15px;z-index:1;">
			<div class="col-md-12">
				<h2 style="color:#ffffff;margin:0;font-size:50px;">Specials</h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/background-02.jpg" style="width: 100%; display: block; transform: translate3d(-50%, 247px, 0px);">
  </div>
</div>
    

    
    <section id="" style="padding: 60px 0 80px;">
        <div class="container">
            <div class="row">
               	<div class="col-md-4 hide-on-med-and-down"> <div class="row hide-on-med-and-down" style="margin-right: 20px;">
				<div class="col-md-12" style="background: #f8f8f8; padding: 20px 30px 30px;">
				<h4 style="color:#1C5C85">Calendar/Events</h4>
				<h4>&nbsp;</h4>
				<p class="nav sidebar"><a href="/events">Events</a></p>
				<p class="nav sidebar"><a href="/specials">Specials</a></p>
				</div>
				</div>
				&nbsp;</div>
				<div class="col-md-8">
					<div class="row">
						<form runat="server" style="width:100%;">
										<asp:GridView showheader="false" ID="GridView1" AllowPaging="False" runat="server" AutoGenerateColumns="False" GridLines="None" DataSourceID="ODS_Calendar" DataKeyNames="cNum" border="0" width="100%">
							<Columns>
				<asp:TemplateField HeaderText="Calendar">
				<ItemTemplate>

						<div style="padding-bottom: 20px;">
							<div class="col-md-12" style="background-color: #f8f8f8;padding: 50px;">
								<a href="events-detail.aspx?cnum=<%#Eval("cNum")%>"><h3 style="color: #77BFE5"><%#Eval("Title")%></h3></a>
								<br />
								<p><%#Eval("StartDate")%> - <%#Eval("EndDate")%> </p>
								<p><%#Eval("StartTime")%> </p>
								<p>Location: <%#Eval("Location")%></p>
								<p><%#Eval("ContactNumber")%></p>
								<br />
								<p><%#Eval("Description")%></p>
								
							</div>
						</div>
				</ItemTemplate>
				</asp:TemplateField>
				</Columns>
				</asp:GridView>
				<asp:ObjectDataSource ID="ODS_Calendar" runat="server" SelectMethod="GetActiveCalendarEventsList3" TypeName="DAL_Calendar2" DataObjectTypeName="PC_Calendar" >
				<SelectParameters>
					<asp:ControlParameter ControlID="lblStartDate" DefaultValue="ALL" Name="fStartDate" PropertyName="Text" Type="String" />
					<asp:ControlParameter ControlID="lblEndDate" DefaultValue="ALL" Name="fEndDate" PropertyName="Text" Type="String" />
				</SelectParameters>
			</asp:ObjectDataSource>
			<asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
			<asp:Label ID="lblMo" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblYr" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblStartDate" runat="server" Text="ALL" Visible="false"></asp:Label>
			<asp:Label ID="lblEndDate" runat="server" Text="ALL" Visible="false"></asp:Label>
						</form>
					</div>
				</div>
				<div class="col-md-1"></div>
			</div>
		</div>
	</section>
    
    

</asp:Content>
   



<asp:Content ID="ScriptDynamicContent" ContentPlaceHolderID="ScriptDynamicContent" runat="server">
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
    
</asp:Content>
