<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false"  %>





<asp:Content ID="headContentBefore" ContentPlaceHolderID="headContentBefore" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">
    <title>Aaron Rich Marketing CMS Dashboard</title>
</asp:Content>

<asp:Content ID="headContentAfter" ContentPlaceHolderID="headContentAfter" runat="server">

	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />
	<script src="/plugins/kendo/js/jquery.min.js"></script>
	<script src="/plugins/kendo/js/kendo.all.min.js"></script>
	<style>
		
		.k-button{
		    box-shadow: none;
			border: 1px solid #ddd;
		}


		.k-filebrowser .k-filebrowser-toolbar .k-button-icon {
			margin-top: -11px;
			border-left: 0px;
			border-bottom-left-radius: 0px;
			border-top-left-radius: 0px;
		}
	
		.select-wrapper {
			display: none;
		}


		.k-filebrowser .k-upload .k-upload-button {

			border-top-right-radius: 0px;
			border-bottom-right-radius: 0px;
		}
		.k-breadcrumbs-wrap {
			top: 9px;
		}
	</style>
</asp:Content>
   
    

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- START CONTENT -->
	<section id="content">
		<!--start container-->
		<div class="container">
			<!--card stats start-->
			<div id="card-stats">
		  		<div class="row">
					<div class="col s12">
               			<div id="example">

						<div id="imgBrowser"></div>
						<script>
							$("#imgBrowser").kendoImageBrowser({
								transport: {
									read: "/mvc/ImageBrowser/Read/",
									destroy: {
									  url: "/mvc/ImageBrowser/Destroy/",
									  type: "POST"
									},
									create: {
									  url: "/mvc/ImageBrowser/Create/",
									  type: "POST"
									},
									thumbnailUrl: "/mvc/ImageBrowser/Thumbnail",
									uploadUrl: "/mvc/ImageBrowser/Upload/",
									imageUrl: "/mvc/ImageBrowser/Image?path={0}"
								},
								change: function(e){
									console.log(e);
									var selectedImage = e.sender._selectedItem();
									console.log('selectedImage',selectedImage);
								}
							});
						</script>
						</div>
                     
                	</div>
              	</div>
            </div>
            <!--card stats end-->
            <!--end container-->
		</div>
	</section>
	<!-- END CONTENT -->
</asp:content>









<asp:Content ID="ScriptDynamicContent" ContentPlaceHolderID="ScriptDynamicContent" runat="server">
     
      <!--materialize js-->
      <script type="text/javascript" src="vendors/js/materialize.min.js"></script>
      <!--prism-->
      <script type="text/javascript" src="vendors/prism/prism.js"></script>
      <!--scrollbar-->
      <script type="text/javascript" src="vendors/perfect-scrollbar/perfect-scrollbar.min.js"></script>
      <!-- chartjs -->
      <script type="text/javascript" src="vendors/chartjs/chart.min.js"></script>
      <!--plugins.js - Some Specific JS codes for Plugin Settings-->
      <script type="text/javascript" src="vendors/js/plugins.js"></script>
      <!--custom-script.js - Add your own theme custom JS-->
      <script type="text/javascript" src="vendors/js/custom-script.js"></script>
      <script type="text/javascript" src="vendors/js/scripts/dashboard-ecommerce.js"></script>
  
</asp:content>