<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false"  %>





<asp:Content ID="headContentBefore" ContentPlaceHolderID="headContentBefore" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">
	<title>Aaron Rich Marketing CMS Dashboard</title>
	<!-- Bootstrap -->
	<link href="vendors/bootstrap/dist/css/bootstrap-mod.css" rel="stylesheet">
	<!-- Font Awesome -->
	<link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="headContentAfter" ContentPlaceHolderID="headContentAfter" runat="server">

	
	
	
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />
	<style>
		.btn
		{
			background: #0097a7!important;
		}
		.btnEdit, .btnRemove 
		{
			font-size: .7rem;
			height: 15px;
			line-height: 15px;
			padding: 0 1rem;
			background: #0097a7!important;
			color: #fff;
			text-transform: none;
		}
		.sortableListsOpener
		{
			height: 15px;
			line-height: 25px;
			padding: 0 8px;
			background: #0097a7!important;
			color: #fff;
		}
		
		.sortableListsOpener i
		{
			height: 15px;
			line-height: 15px;
			font-size: .5rem;
			/* margin-top: 9px; */
			display: block;
		}
		.list-group-item > div
		{
			padding: .5rem;
		}
	</style>
	<script src="/plugins/kendo/js/jquery.min.js"></script>
	<script src="/plugins/kendo/js/kendo.all.min.js"></script>
	
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
               			
						
						<div class="row">                
					   <div class="col-md-6">
						<div class="panel panel-default">
							<div class="panel-heading clearfix">
								<h5 class="pull-left">Edit Item</h5>
							</div>
							<div class="panel-body">
								<form id="frmEdit" class="form-horizontal">
									<input type="hidden" name="mnu_icon" id="mnu_icon">
									<div class="form-group">
										<label for="mnu_text" class="col-sm-2 control-label">Text</label>
										<div class="col-sm-10">
												<input type="text" class="form-control" id="mnu_text" name="mnu_text" placeholder="Text">
										</div>
									</div>
									<div class="form-group">
										<label for="mnu_href" class="col-sm-2 control-label">URL</label>
										<div class="col-sm-10">
											<input type="text" class="form-control" id="mnu_href" name="mnu_href" placeholder="URL">
										</div>
									</div>
									<!--<div class="form-group">
										<label for="mnu_target" class="col-sm-2 control-label">Target</label>
										<div class="col-sm-10">
											<select id="mnu_target" name="mnu_target" class="form-control">
												<option value="_self">Self</option>
												<option value="_blank">Blank</option>
												<option value="_top">Top</option>
											</select>
										</div>
									</div>
									<div class="form-group">
										<label for="mnu_title" class="col-sm-2 control-label">Tooltip</label>
										<div class="col-sm-10">
											<input type="text" class="form-control" id="mnu_title" name="mnu_title" placeholder="Text">
										</div>
									</div>-->
								</form>
							</div>
							<div class="panel-footer">
								<button type="button" id="btnUpdate" class="btn btn-primary" disabled><i class="fa fa-refresh"></i> Update</button>
								<button type="button" id="btnAdd" class="btn btn-success"><i class="fa fa-plus"></i> Add</button>
							</div>
						</div>
					</div>
					<div class="col-md-6">
						<div class="panel panel-default">
							<div class="panel-heading clearfix"><h5 class="pull-left">Menu</h5>
								<div class="pull-right">
									<button id="btnOut" type="button" class="btn btn-success"> <i class="glyphicon glyphicon-ok"></i> Save</button>
								</div>
							</div>
							<div class="panel-body" id="cont">
								<ul id="myList" class="sortableLists list-group">
								</ul>
							</div>
						</div>
						
					</div>
				</div>
						
						
						
						
						
						
						
						
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
										type: 'POST', 
										url: '/webservices/navigationservice.asmx/UpdateNavigationBody', 
										data: { models : editor.getString()},
										dataType: 'json',
										success: function (data) { 

											editor.setData(data);

										}
									});
								});
							});
						</script>
         
                     
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