<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/ADMIN_NewsAdd.aspx.vb" Inherits="ADMIN_NewsAdd" validaterequest="false" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

















<asp:Content ID="headContentBefore" ContentPlaceHolderID="headContentBefore" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="msapplication-tap-highlight" content="no">

    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">

    <title>Aaron Rich Marketing CMS Dashboard</title>

</asp:Content>



<asp:Content ID="headContentAfter" ContentPlaceHolderID="headContentAfter" runat="server">

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

   
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />

	<script src="/plugins/kendo/js/jquery.min.js"></script>

	<script src="/plugins/kendo/js/kendo.all.min.js"></script>

	

</asp:Content>

 

 

 

 

 

 

 

 





<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <!-- START CONTENT -->

        <form runat="server">

        	

        <section id="content">

          <!--start container-->

          <div class="container">

            <!--card stats start-->

            <div id="card-stats">

              <div class="row">

                <div class="col s12">

					<div class="row">   

						<div class="col s12">

							<asp:Label ID="lblErrorMsg" runat="server"></asp:Label>

							<asp:Label ID="lblNewsNum" runat="server" Text="Label" Visible="False"></asp:Label>

						</div>

						<div class="col s9">




							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										<h5 align="left"><asp:Label ID="Label10" runat="server" Text="Slug:  "></asp:Label></h5>

										<asp:TextBox ID="txtPageName" runat="server" Width="100%" MaxLength="60"></asp:TextBox>

									</li>

								</ul>

							</div>


           			

							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										<h5 align="left"><asp:Label ID="Label3" runat="server" Text="Title:  "></asp:Label></h5>

										<asp:TextBox ID="txtTitle" runat="server" Width="100%" MaxLength="60"></asp:TextBox>

									</li>

								</ul>

							</div>

           			

           			

							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										<h5 align="left"><asp:Label ID="Label8" runat="server" Text="Summary:  "></asp:Label></h5>

										<asp:TextBox ID="txtSummary" runat="server" Height="100" Width="100%" TextMode="MultiLine" Wrap="true" ></asp:TextBox>

									</li>

								</ul>

							</div>

           			

							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										<h5 align="left">Content:</h5>

										<RTE:Editor runat="server" ID="Editor1" ContentCss="../CSS/richtext.css" Width="100%" Height="500px"/>

									</li>

								</ul>

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
							


	
	
                    		<script>
								
									console.log("test1");
								function saveClick()
									{
										//alert("test");
										var multiselect = $("#categories").data("kendoMultiSelect");
										var selectedData= [];
										var items = multiselect.value();
										$("#MainContent_lblMultiSelect").val(items);
										//alert(items);
									}
									
								var inpDisabled;
								$(document).ready(function() {
									var crudServiceBaseUrl = "";
									var dataSource = new kendo.data.DataSource({
										batch: true,
										transport: {
											read:  {
												url: "/webservices/newscategoriesservice.asmx/GetCategories",
												dataType: "json"
											},
											create: {
												url: "/webservices/newscategoriesservice.asmx/AddCategory",
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
									var array = [];
									if($('#MainContent_lblMultiSelect').val() === undefined){
										var catValue = '<%= catValue %>';
										array = catValue.split(",");
									} else 
									{
										array = $('#MainContent_lblMultiSelect').val().split(",");

									}
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

	
	
           			



						</div>

						<div class="col s3">

						

						

						

							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

					  					<h5>Main Image</h5>

										<asp:Image  ID="thumb0" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

										<%= HeaderImageValue %>

										<asp:Label ID="lblImageFile0" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

										<asp:FileUpload ID="FileUpload0" runat="server"  />

									</li>

								</ul>

							</div>

						

							

							<%--<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										

										<h5>Category: </h5>

										<asp:Panel ID="pnlStatus2" runat="server" Visible="True" >

											<asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="XDS_Category" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList>

										</asp:Panel>

										<asp:TextBox ID="txtCategory" runat="server" Visible="False" Width="27px"></asp:TextBox>

									</li>

								</ul>

							</div>--%>

							

							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										<h5>Headline Date: </h5>

									  	<input id="datePicker" runat="server" type="text" class="datepicker" placeholder="Click Here">

									</li>

								</ul>

							</div>

							

							<div class="demo-section k-content">

								<ul class="fieldlist">

									<li class="culture">

										<h5><asp:Label ID="Label15" runat="server" Text="Status:  "></asp:Label></h5>

										<asp:TextBox ID="txtStatus" runat="server" Visible="False" ></asp:TextBox>

										<asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList>

									</li>

								</ul>

							</div>

							

							

							

						</div> 

				  		<div class="col s12">  
							
							
							
							
							<asp:TextBox ID="lblMultiSelect" runat="server"  Visible="True" style="visibility:hidden;"></asp:TextBox>

							<asp:LinkButton ID="SaveButton" OnClientClick="javascript:return saveClick()"  runat="server" Text="Add News Item" CssClass="waves-effect waves-light btn btn-large  box-shadow btn-opt1" />  

							<p>&nbsp;</p>

							<asp:Label ID="guidLabel" runat="server" Text=""  style="position: absolute;visibility: hidden;width: 0;height: 0;overflow: hidden;"></asp:Label>

							<asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/NewsFTBStatus.xml"></asp:XmlDataSource>

							<asp:XmlDataSource ID="XDS_Featured" runat="server" DataFile="~/App_Data/FeaturedStatus.xml"></asp:XmlDataSource>

							<asp:XmlDataSource ID="XDS_Category" runat="server" DataFile="~/App_Data/NewsCategoryStatus2.xml"></asp:XmlDataSource>

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


      
	
	
	
        <script>

			$( document ).ready(function() {

				

				$("#FileUpload0").kendoUpload();

				var userID = '<%= Session("UserAcctNum").ToString() %>';

				var changeID = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>'

				$('.datepicker').pickadate({

					selectMonths: true, // Creates a dropdown to control month

					selectYears: 15, // Creates a dropdown of 15 years to control year,

					format: 'yyyy/mm/dd',

					today: 'Today',

					clear: 'Clear',

					close: 'Ok',

					closeOnSelect: false // Close upon selecting a date,

				}); 

				

				

				var guid = '<%= strGUID %>';

				var action = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>';

				if (action == '')

				{

					action = 'Add News Item'

				} else 

				{

					action = 'Update News Item'

				}

				console.log(guid);

				

				$("#SaveButton").click(function(){

					$.ajax({

							type: "POST",

							url: "/webservices/activityService.asmx/AddActivity",

							data: "{title:'News/Blog', user:'" + FullName + "', userID:'" + userID + "', guid:'" + guid + "', action: '" + action + "'}", 

							contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this

							dataType: "json", // the data type we want back.  The data will come back in JSON format

							success: function (data) {

								//$("#searchresultsB").html(data.d); // it's a quirk, but the JSON data comes back in a property called "d"; {"d":"Hello Aidy F"}

							}

					});

				});

				

			});

			

			

			function uuidv4() {

			  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {

				var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);

				return v.toString(16);

			  });

			}



			



	  	</script>

  

</asp:content>

        

        