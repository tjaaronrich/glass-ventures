<%@ Page Language="VB" AutoEventWireup="false"  %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Register TagPrefix="uc1" TagName="menuProfile" Src="template/menu-profile.ascx" %>
<%@ Register TagPrefix="uc1" TagName="menuFooter" Src="template/menu-footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebarMenu" Src="template/sidebar-menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="topNavigation" Src="template/top-navigation.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="template/footer.ascx" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<!-- Meta, title, CSS, favicons, etc. -->
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>ARM Dashboard |</title>

<!-- Bootstrap -->
<link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
<!-- Font Awesome -->
<link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
<!-- NProgress -->
<link href="vendors/nprogress/nprogress.css" rel="stylesheet">
<!-- iCheck -->
<link href="vendors/iCheck/skins/flat/green.css" rel="stylesheet">

<!-- bootstrap-progressbar -->
<link href="vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet">
<!-- JQVMap -->
<link href="vendors/jqvmap/dist/jqvmap.min.css" rel="stylesheet"/>
<!-- bootstrap-daterangepicker -->
<link href="vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">

<!-- Custom Theme Style -->
<link href="build/css/custom.min.css" rel="stylesheet">

<!-- Kendo -->
<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
<link href="css/theme.css" rel="stylesheet" type="text/css">
   
   
        <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js'></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
       
<script src="https://kendo.cdn.telerik.com/2017.2.621/js/kendo.all.min.js"></script>



<style>


.route {
  position: relative;
  list-style-type: none;
  border: 0;
  margin: 0;
  padding: 0;
  top: 0px;
  margin-top: 0px;
  max-height: 100% !important;
  width: 100%;
  background: #bcf;
  border-radius: 2px;
  z-index: -1;
}
.route span {
  position: absolute;
  top: 20px;
  left: 20px;
  -ms-transform: scale(2);
  /* IE 9 */
 
  -webkit-transform: scale(2);
  /* Chrome, Safari, Opera */
 
  transform: scale(2);
  z-index: 10px;
}
.route .title {
  position: absolute;
  border: 0;
  margin: 0;
  padding: 0;
  padding-top: 14px;
  height: 44px;
  width: 400px;
  text-indent: 80px;
  background: #4af;
  border-radius: 2px;
  box-shadow: 0px 0px 0px 2px #29f;
  pointer-events: none;
}
.first-title { margin-left: 10px; }
.space {
  position: relative;
  list-style-type: none;
  border: 0;
  margin: 0;
  padding: 0;
  margin-left: 70px;
  width: 60px;
  top: 68px;
  padding-bottom: 68px;
  height: 100%;
  z-index: 1;
}
.first-space { margin-left: 10px; }

	
	
</style>
</head>

<body class="nav-md">
	<% 
		If Session("accessLevel") < 1 Then
			Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("timeOut").ToString())
			
		Else If Session("accessLevel") Is Nothing Then
			Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("timeOut").ToString())
		End If
  	%>
<script type="text/javascript">
        var accesslevel = '<%= Session("accesslevel").ToString().ToLower() %>';
        var pid = '<%= Session("UserAcctNum").ToString().ToLower() %>';
		var url = "http://www.testurl29.com";
		var FullName = '<%= Session("FullName").ToString() %>';
		var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
		var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
    </script> 
<script src="js/userAccess.js" type="text/javascript"></script>
<div class="container body">
  <div class="main_container">
    <div class="col-md-3 left_col">
      <div class="left_col scroll-view">
        <div class="navbar nav_title" style="border: 0;"> <a href="Default2.aspx" class="site_title" style="text-align:center;"> <span id="userType"></span></a> </div>
        <div class="clearfix"></div>
        <uc1:menuProfile id=menuProfile runat="server"></uc1:menuProfile>
        <br />
        <uc1:sidebarMenu id=sidebarMenu runat="server"></uc1:sidebarMenu>
        

            <uc1:menuFooter id=menuFooter runat="server"></uc1:menuFooter>
      </div>
    </div>
    <uc1:topNavigation id=topNavigation runat="server"></uc1:topNavigation>
    
    <!-- page content -->
    <div class="right_col" role="main">
      <div class="row">
        <div class="col-md-12">

          <div id="example">
              <div class="row"></div>
       
            	<div class="col-md-12">
            	
					<div class="row">   
					
						<div id="imgBrowser"></div>
					                              
					</div>
           	
            	</div>


            
            
            
            

            <script>
				
				
			$(document).ready(function () {
				$("#imgBrowser").kendoImageBrowser({

					//imageBrowser: {
						messages: {
							dropFilesHere: "Drop files here"
						},
						transport: {
							read: "/ImageBrowser/Read",
							destroy: {
								url: "/ImageBrowser/Destroy",
								type: "POST"
							},
							create: {
								url: "/ImageBrowser/Create",
								type: "POST"
							},
							thumbnailUrl: "/ImageBrowser/Thumbnail",
							uploadUrl: "/ImageBrowser/Upload",
							imageUrl: "/ImageBrowser/Image?path={0}"
						},
						change: function () {
							//this.value(); //Selected image URL
							console.log(this.value());
						}
				   // }
				});
        	});

				
				
            </script>
         
          </div>
        </div>
      </div>
    </div>
    <!-- /page content -->
    
    <uc1:footer id=footer runat="server"></uc1:footer>
  </div>
</div>

    <!-- Bootstrap -->

    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>
        <script src='/plugins/bs-iconpicker/jquery-menu-editor.js'></script>
        <script src='/plugins/bs-iconpicker/js/iconset/iconset-fontawesome-4.2.0.min.js'></script>
        <script src='/plugins/bs-iconpicker/js/bootstrap-iconpicker.min.js'></script>
        <script>
            jQuery(document).ready(function () {
                //var strJson = '[{"text":"Home","icon":"fa-home","href":"http://codeignitertutoriales.com"},{"text":"Youtube","icon":"fa-youtube-square","href":"https://www.youtube.com/user/davicotico"},{"text":"Github","icon":"fa-github","href":"https://github.com/davicotico","target":"_self","title":""},{"text":"Opcion4","icon":"fa-crop"},{"text":"Opcion5","icon":"fa-flask"},{"text":"Opcion6","icon":"fa-map-marker"},{"text":"Opcion7","icon":"fa-search","children":[{"text":"Opcion7-1","icon":"fa-plug"},{"text":"Opcion7-2","icon":"fa-filter"}]}]';
                var strjson1 = '[{"href":"http://home.com","text":"Home"},{"icon":"fa-bar-chart-o","text":"Opcion2"},{"icon":"fa-cloud-upload","text":"Opcion3"},{"icon":"fa-crop","text":"Opcion4"},{"icon":"fa-flask","text":"Opcion5"},{"icon":"fa-search","text":"Opcion7","children":[{"icon":"fa-plug","text":"Opcion7-1","children":[{"icon":"fa-filter","text":"Opcion7-2","children":[{"icon":"fa-map-marker","text":"Opcion6"}]}]}]}]';
				

				
				
                var iconPickerOpt = {cols: 5, searchText: "Buscar...", labelHeader: '{0} de {1} Pags.', footer: false};
                var options = {
                    hintCss: {'border': '1px dashed #13981D'},
                    placeholderCss: {'background-color': 'gray'},
                    ignoreClass: 'btn',
                    opener: {
                        active: true,
                        as: 'html',
                        close: '<i class="fa fa-minus"></i>',
                        open: '<i class="fa fa-plus"></i>',
                        openerCss: {'margin-right': '10px'},
                        openerClass: 'btn btn-success btn-xs'
                    }
                };
                var editor = new MenuEditor('myList', {listOptions: options, iconPicker: iconPickerOpt, labelEdit: 'Edit', labelRemove: 'Remove'});
				
								
				$.ajax({ 
					type: 'GET', 
					url: '/webservices/navigationservice.asmx/GetNavObject', 
					dataType: 'text',
					success: function (data) { 
						
                    	editor.setData(data);
						
					}
				});
				
				
                $('#btnReload').on('click', function () {
                    editor.setData(strjson1);
                });
                $('#btnOut').on('click', function () {
					$.ajax({ 
						type: 'GET', 
						url: '/webservices/navigationservice.asmx/UpdateNavigation', 
						data: { models : editor.getString()},
						dataType: 'text',
						success: function (data) { 

							editor.setData(data);

						}
					});
                });
            });
        </script>
  </body>
</html>
