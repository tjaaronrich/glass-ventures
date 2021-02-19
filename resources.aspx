<%@ Page Language="VB" MasterPageFile="~/Site.Master" debug="true" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>

	
	
<asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">
<head>
	<title>Resources | Monica Cothran, Attorney at Law | Panama City, Florida | Divorce and Family Law</title>
	<META NAME="TITLE" CONTENT="Resources | Monica Cothran, Attorney at Law | Panama City, Florida | Divorce and Family Law"> 
	<META NAME="DESCRIPTION" content="Panama City Attorney Monica Cothran, Panama City Lawyer and Panama City Attorneys serving in the area of divorce law.  Call us today if you need Panama City Lawyers or a Divorce Attorney."> 
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


</head>

</asp:Content>




<asp:Content ID="SliderContent" ContentPlaceHolderID="SliderContent" runat="server">
<section id="posRelNav" class="hide-on-med-and-down" style="color:#333;">
</section>
    
<div class=" subpage parallax-container">
  <div class="parallax">
	  <div class="container">
		<div class="row align-items-center" style="top: 35%;position: absolute;padding-left: 15px;z-index:1;">
			<div class="col-md-12">
				<h2 style="color:#ffffff;margin:0;font-size:50px;"><i>Resources</i></h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/subpage5.jpg" style="width:100%;">
  </div>
</div>
    
    
    <!--Services-->
    <form runat="server"  >
	<!--Services-->
                    
                    
         
		<section style="padding: 60px 0 80px;">
			<div class="container">
				<div class="row">
					<div class="col-md-1"></div>
					<div class="col-md-10">
						<p>These trusted online resources can be great sources of information:</p>
						<asp:GridView showheader="false" ID="GridView1" gridlines="none" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Links01" DataKeyNames="linkNum" width=100% CellPadding="0" CellSpacing="0" Border="0" ForeColor="#FFFFFF" Font-Names="Arial" Font-Size="11px">
							<Columns>
								<asp:TemplateField HeaderText="Links">  
									<ItemTemplate>
										<p><i style="color: #bbb;" class="fa fa-arrow-circle-right" aria-hidden="true"></i> &nbsp; <strong><a href=<%#Eval("URL")%> target=_blank ><%#Eval("linkName")%></a></strong> - <%#Eval("linkDescription")%></p>
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
							</asp:GridView>
							<p>
								<asp:ObjectDataSource ID="ODS_Links01" runat="server" SelectMethod="GetAllLinks01" TypeName="DAL_Links" DataObjectTypeName="PC_Links" ></asp:ObjectDataSource>
							</p>
							<p>&nbsp;</p>          
							<p>&nbsp;</p>
					</div>
					<div class="col-md-1"></div>
				</div>
			</div>
		</section>
		
	</form> 

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
				

	$(window).on('resize', function(){
		console.log($("#navbar").height());
		$("#posRelNav").css("height", $("#navbar").height());
	});

				
	$(document).ready(function() {
					
		$("#posRelNav").css("height", $("#navbar").height());
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

