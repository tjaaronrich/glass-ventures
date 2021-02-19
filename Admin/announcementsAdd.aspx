<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="VB/AnnouncementsAdd.aspx.vb" Inherits="AnnouncementsAdd" validateRequest="false" %>
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
    
    <style>
		.k-widget .select-dropdown, .k-widget span.caret
		{
			display: none!important;
		}
		.k-button
		{
			padding-bottom: 0em!important;
		}
	
	</style>
    
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
        <form runat="server">
        <section id="content">
          <!--start container-->
          <div class="container">
            <!--card stats start-->
            <div id="card-stats">
              <div class="row">
                <div class="col s12">
               		
					<div id="example">
						<div class="col s9">

							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Title:</h5>
                 						<asp:TextBox ID="txtTitle" runat="server" ></asp:TextBox>
									</li>
								</ul>
							</div>
							<div class="row">
								<div class="col s6" >
									<div class="demo-section k-content">
										<ul class="fieldlist">
											<li class="culture">
												<h5>Start Date: </h5>
												<input id="datePicker1" runat="server" type="text" class="datepicker datepicker1" placeholder="Select Start Date">
											</li>
										</ul>
									</div>
								</div>
								<div class="col s6" >
									<div class="demo-section k-content">
										<ul class="fieldlist">
											<li class="culture">
												<h5>End Date: </h5>
												<input id="datePicker2" runat="server" type="text" class="datepicker datepicker2" placeholder="Select End Date">
											</li>
										</ul>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col s12">
								
									<div class="demo-section k-content">
										<ul class="fieldlist">
											<li class="culture">

												<div class="row">
													
													<!--<div class="col s12">
														<p>
                            							<asp:CheckBox ID="chkAllDay" runat="server" AutoPostBack="False" Text="Check for an all-day or time-independent event" />         </p>
													</div>	 -->

													<div class="col s6" >
														<h5>Start Time: </h5>
														<input id="timepicker1" type="text" runat="server" class="timepicker1" placeholder="Select Start Time">
													</div>


													<div class="col s6" >
														<h5>End Time: </h5>
														<input id="timepicker2" type="text" runat="server" class="timepicker2" placeholder="Select End Time">
													</div>
													
												</div>


											</li>
										</ul>
									</div>
								
								
								</div>

							</div>

                    		<script>
								function saveClick()
									{
										//alert("test");
										var multiselect = $("#categories").data("kendoMultiSelect");
										var selectedData= [];
										var items = multiselect.value();
										$("#lblMultiSelect").val(items);
										//alert(items);
									}
									
								var inpDisabled;
								$(document).ready(function() {
									$("#FileUpload2").kendoUpload();

									var userID = '<%= Session("UserAcctNum").ToString() %>';
									var changeID = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>'
									$('.datepicker1').pickadate({
										selectMonths: true, // Creates a dropdown to control month
										selectYears: 15, // Creates a dropdown of 15 years to control year,
										format: 'yyyy/mm/dd',
										today: 'Today',
										clear: 'Clear',
										close: 'Ok',
										closeOnSelect: false // Close upon selecting a date,
									}); 

									$('.datepicker2').pickadate({
										selectMonths: true, // Creates a dropdown to control month
										selectYears: 15, // Creates a dropdown of 15 years to control year,
										format: 'yyyy/mm/dd',
										today: 'Today',
										clear: 'Clear',
										close: 'Ok',
										closeOnSelect: false // Close upon selecting a date,
									}); 

									$('.timepicker1').pickatime({
										default: 'now', // Set default time: 'now', '1:30AM', '16:30'
										fromnow: 0,       // set default time to * milliseconds from now (using with default = 'now')
										twelvehour: true, // Use AM/PM or 24-hour format
										donetext: 'OK', // text for done-button
										cleartext: 'Clear', // text for clear-button
										canceltext: 'Cancel', // Text for cancel-button
										autoclose: false, // automatic close timepicker
										ampmclickable: true, // make AM PM clickable
										beforeShow: function(e) {
											console.log('clicked');
											if(inpDisabled){
												e.stopPropagation();
											}
										},
										aftershow: function(){} //Function for after opening timepicker
									});

									$('.timepicker2').pickatime({
										default: 'now', // Set default time: 'now', '1:30AM', '16:30'
										fromnow: 0,       // set default time to * milliseconds from now (using with default = 'now')
										twelvehour: true, // Use AM/PM or 24-hour format
										donetext: 'OK', // text for done-button
										cleartext: 'Clear', // text for clear-button
										canceltext: 'Cancel', // Text for cancel-button
										autoclose: false, // automatic close timepicker
										ampmclickable: true, // make AM PM clickable
										beforeShow: function(e) {
											console.log('clicked');
											if(inpDisabled){
												e.stopPropagation();
											}
										},
										aftershow: function(){} //Function for after opening timepicker
									});

									if($('#chkAllDay').is(':checked'))
									{
										inpDisabled = true;
									} else 
									{
										inpDisabled = false;
									}

									$('#chkAllDay').on('click', function (e) {				
										if($('#chkAllDay').is(':checked'))
										{
											inpDisabled = true;
										} else 
										{
											inpDisabled = false;
										}
									});




									//inpDisabled = true;

									var guid = '<%= strGUID %>';
									var action = '<%= Server.HtmlDecode(Request.QueryString("cNum")) %>';
									if (action == '')
									{
										action = 'Add Announcement'
									} else 
									{
										action = 'Update Announcement'
									}
									console.log(guid);

									$("#SaveButton").click(function(){
										
										
										$.ajax({
												type: "POST",
												url: "/webservices/activityService.asmx/AddActivity",
												data: "{title:'Announcement', user:'" + FullName + "', userID:'" + userID + "', guid:'" + guid + "', action: '" + action + "'}", 
												contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
												dataType: "json", // the data type we want back.  The data will come back in JSON format
												success: function (data) {
													//$("#searchresultsB").html(data.d); // it's a quirk, but the JSON data comes back in a property called "d"; {"d":"Hello Aidy F"}
												}
										});
									});
									
									var crudServiceBaseUrl = "https://www.discover850.com/webservices/categoriesservice.asmx";
									var dataSource = new kendo.data.DataSource({
										batch: true,
										transport: {
											read:  {
												url: "/webservices/categoriesservice.asmx/GetCategories",
												dataType: "json"
											},
											create: {
												url: "/webservices/categoriesservice.asmx/AddCategory",
												dataType: "json"
											},
											parameterMap: function(options, operation) {
												if (operation !== "read" && options.models) {
													return {models: kendo.stringify(options.models)};
												}
											}
										},
										schema: {
											model: {
												id: "ProductID",
												fields: {
													ProductID: { type: "number" },
													ProductName: { type: "string" }
												}
											}
										}
									});

									//alert($("#lblMultiSelect").val());
									var objCategory = [];
									var array = $('#lblMultiSelect').val().split(",");
									$.each(array,function(i){
									   	var item = {};
										item["ProductName"] = array[i];
										objCategory.push(item);
									});
									//alert(objCategory);
									var items = [
											{  ProductID: 2 },
											{  ProductID: 7 }
										];
									var items = objCategory;
									

									$("#categories").kendoMultiSelect({
										filter: "startswith",
										dataTextField: "ProductName",
										dataValueField: "ProductName",
										dataSource: dataSource,
										noDataTemplate: $("#noDataTemplate").html(),
										value: items
									});



								});
							</script>
							<script id="noDataTemplate" type="text/x-kendo-tmpl">
								# var value = instance.input.val(); #
								# var id = instance.element[0].id; #
								<div>
									No data found. Do you want to add new item - '#: value #' ?
								</div>
								<br />
								<button class="k-button" onclick="addNew('#: id #', '#: value #')" ontouchend="addNew('#: id #', '#: value #')">Add new item</button>
							</script>
							
							
							<script>
								function addNew(widgetId, value) {
									var widget = $("#" + widgetId).getKendoMultiSelect();
									var dataSource = widget.dataSource;

									if (confirm("Are you sure?")) {
										dataSource.add({
											ProductID: 0,
											ProductName: value
										});

										dataSource.one("requestEnd", function(args) {
											if (args.type !== "create") {
												return;
											}

											var newValue = args.response[0].ProductID;

											dataSource.one("sync", function() {
												widget.value(widget.value().concat([newValue]));
											});
										});

										dataSource.sync();
									}
								}
							</script>

							
							<div class="row">
								<div class="col s12">
									<div class="demo-section k-content">
										<ul class="fieldlist">
											<li class="culture">
												<h5>Content:</h5>
												<RTE:Editor runat="server" ID="Editor1" ContentCss="../CSS/richtext.css" Width="100%" Height="500px"/>
											</li>
										</ul>
									</div>
								</div>
							</div>
							
							
							
							
					
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Category:</h5>
										<select id="categories" multiple="multiple" data-placeholder="Select Categories...">
										</select>									
									</li>
								</ul>
							</div>
							
						</div>
						
						
						<div class="col s3">
						
						
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Choose File:</h5>
										<asp:FileUpload ID="FileUpload2" runat="server" style="width:100%;" />
										<asp:Label ID="lblfileName" runat="server" Text="" Visible="True"></asp:Label>
										<asp:Label ID="lblfileName2" runat="server" Text="" Visible="False"></asp:Label>
									</li>
								</ul>
							</div>
						
							<!--<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Category:</h5>
					  					<asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="XDS_CategoryStatus" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList></asp:Panel><asp:TextBox ID="txtCategory" runat="server" Visible="False" Width="27px"></asp:TextBox>
									</li>
								</ul>
							</div>-->
							
													
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Contact #:</h5>
                               			<asp:TextBox ID="txtContactNumber" runat="server" ></asp:TextBox>
									</li>
								</ul>
							</div>
					
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5>Email:</h5>
										<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
									</li>
								</ul>
							</div>
					
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
										<h5>Website:</h5>
										<asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
									
									</li>
								</ul>
							</div>
					
							
													
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Location:</h5>
                               			<asp:TextBox ID="txtLocation" runat="server" ></asp:TextBox>
									</li>
								</ul>
							</div>
					

						
							<div class="demo-section k-content">
								<ul class="fieldlist">
									<li class="culture">
					  					<h5>Status:</h5>
                               			<asp:TextBox ID="txtStatus" runat="server" Visible="False" Width="27px"></asp:TextBox>
                                		<asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList>
									</li>
								</ul>
							</div>


						</div>
						
						
						<div class="col s12">

							<div class="col s12">
								<p>&nbsp;</p>
								<!--<a onclick="javascript:return saveClick()">Test</a>-->
								<asp:TextBox ID="lblMultiSelect" runat="server" Value="Event" Visible="True" style="visibility:hidden;"></asp:TextBox>
								<asp:LinkButton ID="SaveButton" runat="server" Text="Add Item" OnClientClick="javascript:return saveClick()" CssClass="waves-effect waves-light btn btn-large  box-shadow btn-opt1" />
								<p>&nbsp;</p>
								<asp:Label ID="guidLabel" runat="server" Text=""  style="position: absolute;visibility: hidden;width: 0;height: 0;overflow: hidden;"></asp:Label>
                				<asp:Label ID="lblCalNum" runat="server" Visible="False"></asp:Label><asp:Label ID="lblStartDate" runat="server" Visible="False"></asp:Label>&nbsp;<asp:Label ID="lblEndDate" runat="server" Visible="False"></asp:Label> 
								<asp:ObjectDataSource ID="ODS_Calendar" runat="server" DataObjectTypeName="PC_Calendar"
								DeleteMethod="DelCalendarEvent" SelectMethod="GetAllCalendarItems" TypeName="DAL_Announcements"></asp:ObjectDataSource>
								<asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/NewsFTBStatus.xml"></asp:XmlDataSource>
								<asp:XmlDataSource ID="XDS_CategoryStatus" runat="server" DataFile="~/App_Data/EventStatus.xml"></asp:XmlDataSource>
							</div>
                        
        				</div>
                
            		</div>
               
               
               
                </div>
              </div>
            </div>
            <!--card stats end-->



            <!--end container-->
        </div>
        
        
        </section>
			</form>
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
	  <script>
	  
		$(".datepicker").mousedown(function(e){
		  	e.preventDefault();
			e.stopPropagation();
		});
		  
		$(".timepicker1").mousedown(function(e){
		  	e.preventDefault();
			e.stopPropagation();
		});
		  
		$(".timepicker2").mousedown(function(e){
		  	e.preventDefault();
			e.stopPropagation();
		});
		  
	  </script>
  

</body>
</html>