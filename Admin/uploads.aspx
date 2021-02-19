<%@ Page Language="VB"  AutoEventWireup="false"  %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Register TagPrefix="uc1" TagName="materialHeader" Src="template/material-header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materialFooter" Src="template/material-footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materialLeftNavbar" Src="template/material-leftNavbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materialRightNavbar" Src="template/material-rightNavbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebarMenu" Src="template/sidebar-menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="topNavigation" Src="template/top-navigation.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="template/footer.ascx" %>
<!DOCTYPE html>
<html lang="en">
	
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">
    <title>Aaron Rich Marketing CMS Dashboard</title>
    <!-- Favicons-->
    <link rel="icon" href="../../images/favicon/favicon-32x32.png" sizes="32x32">
    <!-- Favicons-->
    <link rel="apple-touch-icon-precomposed" href="../../images/favicon/apple-touch-icon-152x152.png">
    <!-- For iPhone -->
    <meta name="msapplication-TileColor" content="#00bcd4">
    <meta name="msapplication-TileImage" content="images/favicon/mstile-144x144.png">
    <!-- For Windows Phone -->
    <!-- CORE CSS-->
    <link href="vendors/css/themes/fixed-menu/materialize.css" type="text/css" rel="stylesheet">
    <link href="vendors/css/themes/fixed-menu/style.css" type="text/css" rel="stylesheet">
    <!-- Custome CSS-->
    <link href="vendors/css/custom/custom.css" type="text/css" rel="stylesheet">
    <!-- INCLUDED PLUGIN CSS ON THIS PAGE -->
    <link href="vendors/perfect-scrollbar/perfect-scrollbar.css" type="text/css" rel="stylesheet">
    <link href="vendors/jvectormap/jquery-jvectormap.css" type="text/css" rel="stylesheet">
    <link href="vendors/flag-icon/css/flag-icon.min.css" type="text/css" rel="stylesheet">
    
    
    
	<% 
		If Session("accessLevel") < 1 Then
			Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("timeOut").ToString())
			
		Else If Session("accessLevel") Is Nothing Then
			Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("timeOut").ToString())
		End If
  	%>
  	
    <script type="text/javascript">
        var accesslevel = '<%= Session("accesslevel").ToString().ToLower() %>';
		var FullName = '<%= Session("FullName").ToString() %>';
		var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
    </script>  
	<!-- jQuery Library -->
	<script type="text/javascript" src="vendors/jquery-3.2.1.min.js"></script>
	<script src="js/userAccess.js" type="text/javascript"></script> 
   
   
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />
	<script src="/plugins/kendo/js/jquery.min.js"></script>
	<script src="/plugins/kendo/js/kendo.all.min.js"></script>
    
    
  </head>
  <body class="loading" style="">
    <!-- Start Page Loading -->
    <div id="loader-wrapper">
      <div id="loader"></div>
      <div class="loader-section section-left"></div>
      <div class="loader-section section-right"></div>
    </div>
    <!-- End Page Loading -->
    <!-- //////////////////////////////////////////////////////////////////////////// -->
	<uc1:materialHeader id=materialHeader runat="server"></uc1:materialHeader>
    <!-- //////////////////////////////////////////////////////////////////////////// -->
    <!-- START MAIN -->
    <div id="main">
      <!-- START WRAPPER -->
      <div class="wrapper">
        
		<uc1:materialLeftNavbar id=materialLeftNavbar runat="server"></uc1:materialLeftNavbar>
        <!-- //////////////////////////////////////////////////////////////////////////// -->
        <!-- START CONTENT -->
        <section id="content">
          <!--start container-->
          <div class="container">
            <!--card stats start-->
            <div id="card-stats">
              <div class="row">
                <div class="col s12">
              <div id="grid"></div>
				<script>
					var dataSource = new kendo.data.DataSource({
						transport: {
							read:  {
								url: "/webservices/uploadItemService.asmx/GetAllUsers",
								dataType: "json"
							},
							update: {
								url: "/webservices/uploadItemService.asmx/updateUser",
								dataType: "json"
							},
							destroy: {
								url: "/webservices/uploadItemService.asmx/DeleteUser",
								dataType: "json"
							},
							create: {
								url: "/webservices/uploadItemService.asmx/AddUser",
								dataType: "json"
							},
							parameterMap: function(options, operation) {
								if (operation !== "read" && options.models) {
									return {models: kendo.stringify(options.models)};
								}
							}
						},
						requestStart: function(e) {
						if (e.type != "read") {
							//kendoConsole.log(kendo.format("Request start ({0})", e.type));
						}
					},
					requestEnd: function(e) {
						if (e.type != "read") {
							console.log(kendo.format("Request end ({0})", e.type));
							if (e.type == "create")
							{
								$('#grid').data('kendoGrid').dataSource.read();
							}
						}
					},
					batch: true,
					pageSize: 20,
					schema: {
						model: {
							id: "linkNum",
							fields: {
								linkNum: { editable: false }
							}
						}
					}
				});


				$("#grid").kendoGrid({
					dataSource: dataSource,
					pageable: {
						refresh: true
					},
					reorderable: true,
					resizable: true,
					height: 700,
					toolbar: [ "create" ],
					columns: [
						{ command: ["edit", "destroy"], title: "&nbsp;", width: "350px" },
						{ field: "linkName", title:"Name", width: "120px" },
						{ field: "linkCategory", title:"Category", width: "120px", editor: categoryDropDownEditor  },
						{ field: "linkDescription", title:"Description", width: "120px" },
						{ field: "URL", title:"File", width: "120px", editor: uploadEditor, template: "<a href='/Documents/Files/#: URL #' >View Link</a>" }
					],
					editable:  {
						mode: "popup",
						width: "600px"
					},
					save: function(e,c){
						e.model.set("URL",$("#uploadedFile").val());
					}	
				});


			
					
					
				function onCreateSuccess(e)
				{	
					$('#grid').data('kendoGrid').dataSource.read();
				}


				function uploadEditor(container, options) {

					$("<input type='hidden' id='uploadedFile' data-bind='value: URL' />").appendTo(container);
					$("<input type='file' id='files' data-role='upload'  data-success='onSuccess' name='files' />")
						.appendTo(container)
						.kendoUpload({
							async: {
								saveUrl: "/webservices/uploadservice.asmx/saveUploadedFile",
								removeUrl: "remove",
								autoUpload: true
							},
						success: onSuccess
						});
				}

				//This is for Status Dropdown

				var d_status = [
					{ "CategoryID": 1, "CategoryName": "Active" },
					{ "CategoryID": 2, "CategoryName": "Inactive" }
				];

				function statusDropDownEditor(container, options) {
					$('<input required name="' + options.field + '"/>')
						.appendTo(container)
						.kendoDropDownList({
							autoBind: false,
							dataTextField: "CategoryName",
							dataValueField: "CategoryName",
							dataSource: {
								data:d_status
							}
						});
				}



				//This is for Property Type Dropdown

				var categories = [
					{ "CategoryID": "Meetings", "CategoryName": "Meetings" },
					{ "CategoryID": "Policies", "CategoryName": "Policies" }
				];

				function categoryDropDownEditor(container, options) {
					$('<input required name="' + options.field + '"/>')
						.appendTo(container)
						.kendoDropDownList({
							autoBind: false,
							dataTextField: "CategoryID",
							dataValueField: "CategoryID",
							dataSource: {
								data:categories
							}
						});
				}

				function onSuccess(e){	
					$("#uploadedFile").val(e.files[0].name);
				}

				function showDetails(e) {
					e.preventDefault();

					var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
					//alert(dataItem.CustomerID);
					window.location.href = "Your-Owner-ListingAdd.aspx?pID=" + dataItem.CustomerID;
				}

			</script> 

			<script type="text/x-kendo-template" id="template">
				<div id="details-container">
					<h2>#= FirstName # #= LastName #</h2>
					<em>#= Title #</em>
					<dl>
						<dt>City: #= City #</dt>
						<dt>Birth Date: #= kendo.toString(BirthDate, "MM/dd/yyyy") #</dt>
					</dl>
				</div>
			</script>
         
         
               
               
               
               
               
               
               
                </div>
              </div>
            </div>
            <!--card stats end-->



            <!--end container-->
        </div>
        
        
        </section>
        <!-- END CONTENT -->

        <!-- //////////////////////////////////////////////////////////////////////////// -->

		<uc1:materialRightNavbar id=materialRightNavbar runat="server"></uc1:materialRightNavbar>
        </div>
        <!-- END WRAPPER -->
      </div>
      <!-- END MAIN -->
  	<!-- //////////////////////////////////////////////////////////////////////////// -->

	<uc1:materialFooter id=materialFooter runat="server"></uc1:materialFooter>
	<!-- ================================================
    Scripts
    ================================================ -->
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
  

</body>
</html>