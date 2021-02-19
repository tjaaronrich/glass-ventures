<%@ Page Language="VB" AutoEventWireup="false" Debug="true" CodeFile="VB/Search.aspx.vb" Inherits="ADMIN_Search" validaterequest="false" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="header1" Src="Template/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar1" Src="Template/request.ascx" %>
<%@ Register TagPrefix="uc1" TagName="prefooter1" Src="Template/prefooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer1" Src="Template/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebar" Src="Template/sidebar-contact.ascx" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<title>Ink Trax Screen Printing Panama City FL</title>
	<META NAME="TITLE" CONTENT="Ink Trax Screen Printing Panama City FL"> 
	<META NAME="DESCRIPTION" content="Ink Trax, Inc. Screen Printing 850-235-4849 Panama City, Florida - Ink Trax is the hottest screen printing, promotional item, embroidery, digitizing, and graphic design company in Florida. From corporate apparel to team uniforms, we can handle any size and type of custom or contract order."> 
	<META NAME="AUTHOR" CONTENT="Aaron Rich Marketing <www.aaronrichmarketing.com>">
	<META NAME="GOOGLEBOT" CONTENT="ALL">
	<META NAME="ROBOTS" CONTENT="ALL, INDEX, FOLLOW">
	<META NAME="REVISIT-AFTER" CONTENT="5 days">
	<META NAME="DISTRIBUTION" CONTENT="GLOBAL">
	<meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">



    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
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

<body id="page-top" class="index">



<uc1:header1 id=header1 runat="server"></uc1:header1>
<section id="posRelNav" class="hide-on-med-and-down" style="color:#333;">
</section>

<div class=" subpage parallax-container">
  <div class="parallax">
	  <div class="container">
		<div class="row align-items-center" style="top: 35%;position: absolute;padding-left: 15px;z-index:1;">
			<div class="col-md-12">
				<h2 style="color:#ffffff;margin:0;font-size:50px;">APPAREL</h2>
			</div>
		</div>
	  </div>
	<img src="/Graphics/subpage1.jpg" style="width:100%;">
  </div>
</div>
    
    
    
    
<form runat="server"  >
	<section id="about" style="color:#333;">
    	<div class="container about-container">
            <div class="row">    
                <div class="col-md-12"  style="padding-bottom:10px;margin-top:2%;">
                    <asp:GridView showheader="false" ID="GridView" GridLines="None" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Products" DataKeyNames="pID" width=100% CellPadding="0" CellSpacing="0" Border="0" ForeColor="#FFFFFF" Font-Names="Arial" Font-Size="11px">
					  <Columns>
                          <asp:TemplateField HeaderText="Products">
                            <ItemTemplate>
                         		<div class="row" style="margin-bottom:0;">   
								<div class="col-lg-6">
									<a href='Documents/Products/BigThumbs/<%#Eval("ImageFile")%>' target='_blank' title='<%#Eval("Item_Name")%>'>
										<img src='Documents/Products/BigThumbs/<%#Eval("ImageFile")%>' class="img-fluid" >
									</a>
								</div>
								<div class="col-lg-6">
                            		<strong><h2><%#Eval("Item_Name")%></h2></strong>
									<h4 style="color:#c23f33; margin-bottom:20px;">Item #<%#Eval("Item_ID")%> - $<%#Eval("Item_Price")%></h4>
									<p style="margin-top:0px;"><%#Eval("Item_Description")%></p>
									<p style="font-size:12px;"><em>Enjoy your favorite outdoor activities or work in the heat of the day! MONEY BACK GUARANTEE</em></p>
                            		<p>&nbsp;</p>
									<form action="">
									</form>
							<div class="row" style="margin-bottom: 0;">	
								<div class="col-md-12">
									<div class="row no-gutter" style="margin-bottom:0;">
										<div class="col-md-6">
										<form id="<%#Eval("Item_ID")%>" method="post" action="https://www.paypal.com/cgi-bin/webscr" target="_blank">
											<input type="hidden" name="cmd" value="_cart">
											<input type="hidden" name="add" value="1">
											<input type="hidden" name="business" value="info@icepal.com">
											<input type="hidden" name="item_name" value="<%#Eval("Item_Name")%>">
											<input type="hidden" name="item_number" value="<%#Eval("Item_ID")%>">
											<input type="hidden" name="amount" value="<%#Eval("Item_Price")%>">
											<input type="hidden" name="shipping" value="<%#Eval("Item_Shipping")%>">
											<%--<input type="hidden" name="tax_rate" value="8.08">--%>
											<input type="hidden" name="currency_code" value="USD">
											<input type="hidden" name="return" value="http://www.icepal.com/thankyou.aspx">
											<input type="hidden" name="cancel_return" value="http://www.icepal.com/cancel.aspx">
											<input type="hidden" name="undefined_quantity" value="1">
											<input type="image" src="/Graphics/InkTrax_AddToCart.jpg" border="0" name="submit"  alt="Make payments with PayPal - it's fast, free and secure!">
										<!--<input type="button" class="btn btn-lg btn-submit" border="0" name="submit" height="40" value="Add To Cart"  >-->
										</form>
										</div>
										<div class="col-md-6">
										<form target="paypal" action="https://www.paypal.com/cgi-bin/webscr" method="post" >
											<input type="hidden" name="cmd" value="_s-xclick">
											<input type="hidden" name="encrypted" value="-----BEGIN PKCS7-----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-----END PKCS7-----">

											<input type="image" src="/Graphics/InkTrax_ViewCart.jpg" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
											<!--<input type="button" class="btn btn-lg btn-submit"  border="0" name="submit" height="40" value="View Cart" >-->
										</form> 
										</div>
									</div>
								</div>
                            </div>
                            
                            
                            
                            
                            
                            
                          </div>
                          </div>
                          <p>&nbsp;</p>
                          <hr style="height:1px; border:none;border-top:1px #CCCCCC solid;">
                          <p>&nbsp;</p>
                            </ItemTemplate>
                          </asp:TemplateField>
                          </Columns>
                  </asp:GridView><asp:ObjectDataSource ID="ODS_Products" runat="server" SelectMethod="GetApprovedListProductsApparel"
        TypeName="DAL_Products" DataObjectTypeName="PC_Products" ></asp:ObjectDataSource>
        
        
        <p><em><strong>Call us for bulk pricing</strong></em></p>
        <p>&nbsp;</p>

      
                    
                    
                    

                </div>
            </div>
        </div>
    </section>
	</form> 

    <!-- Footer -->
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
				
	var $div = $("#navbar");
	var observer = new MutationObserver(function(mutations) {
		mutations.forEach(function(mutation) {
			var i = 0;
			if (mutation.attributeName === "class") {
				var attributeValue = $(mutation.target).prop(mutation.attributeName);
				if (attributeValue == "nav-center pinned")
				{
					testAnim("slideInDown");
					console.log('df');
				} 
						
				if (attributeValue == "nav-center slideInDown animated pin-top")
				{
					$('#navbar').removeClass('slideInDown');
					$('#navbar').removeClass('animated');
					//testAnim("slideInDown");
					//console.log('df');
				} 
						
			  	console.log("Class attribute changed to:", attributeValue);
			}
			i++;
		});
	});
	observer.observe($div[0], {
	  attributes: true
	});

				
	function testAnim(x) {
		$('#navbar').addClass(x + ' animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
			//$(this).removeClass();
			//$(this).addClass("nav-center");
		});
	};


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
</body>

</html>
