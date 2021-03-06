<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false"  %>
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

	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.common-material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.min.css" />
	<link rel="stylesheet" href="/plugins/kendo/styles/kendo.material.mobile.min.css" />
	<link rel="stylesheet" href="/admin/css/theme.css" />
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
               		<div id="grid"></div>
            		<script>
						
						var userID = '<%= Session("UserAcctNum").ToString() %>';
						var changeID = '<%= Server.HtmlDecode(Request.QueryString("nNum")) %>'

						var dataSource = new kendo.data.DataSource({
							transport: {
								read:  {
									url: "/webservices/testimonialService.asmx/GetAllTestimonials",
									dataType: "json"
								},
								update: {
									url: "/webservices/testimonialService.asmx/UpdatePage",
									dataType: "json"
								},
								destroy: {
									url: "/webservices/testimonialService.asmx/DeleteTestimonial",
									dataType: "json"
								},
								create: {
									url: "/webservices/testimonialService.asmx/AddPage",
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
									console.log(kendo.format("Request start ({0})", e.type));
								} else 
								{
									console.log('read');
								}
							},
							requestEnd: function(e) {
								if (e.type != "read") {
									console.log(kendo.format("Request end ({0})", e.type));
									if (e.type == "create")
									{
										grid.dataSource.read();
									}
								}
							},
							batch: true,
							pageSize: 20,
							schema: {
								model: {
									id: "tNum",
									fields: {
										tNum: { editable: false },
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
								{ command: [{name: 'test', text: "<span class='k-icon k-i-edit'></span>edit", click: showDetails}, "destroy"], title: "&nbsp;", width: "350px" },
								{ field: "fullName", title:"Full Name", width: "200px" },
								{ field: "tDescription", title:"Description", width: "500px"},
								{ field: "city", title:"City" },
								{ field: "tSort", title:"Sort"},
								{ field: "Status", title:"Status"},
							],
							editable:  {
								mode: "popup",
								width: "600px"
							},
							toolbar: [{name: "add-custom", text: "<span class='k-icon k-i-plus'></span> Add Testimonial"}],
							save: function(e,c){
										e.model.set("ImageFile",$("#uploadedFile").val());
							},
							remove: function(e)
							{
								var nNum = e.model.id;
								console.log(nNum);
								$.ajax({
										type: "POST",
										url: "/webservices/activityService.asmx/AddActivity",
										data: "{title:'Testimonial', user:'" + FullName + "', userID:'" + userID + "', guid:'" + nNum + "', action: 'Deleted Page'}", 
										contentType: "application/json; charset=utf-8", // we are sending in JSON format so we need to specify this
										dataType: "json", // the data type we want back.  The data will come back in JSON format
										success: function (data) {
											//$("#searchresultsB").html(data.d); // it's a quirk, but the JSON data comes back in a property called "d"; {"d":"Hello Aidy F"}
										}
								});

							}
						});
				        $("#grid .k-grid-add-custom").click(function(e) {
							window.location.replace("/admin/testimonialsAdd.aspx");
						});
				
				
						var grid = $('#grid').data('kendoGrid');
				
				
						function onCreateSuccess(e)
						{	
							//$('#grid').data('kendoGrid').dataSource.read();
						}
				
				
						function uploadEditor(container, options) {

							$("<input type='hidden' id='uploadedFile' data-bind='value: ImageFile' />").appendTo(container);
							$("<input type='file' id='files' data-role='upload'  data-success='onSuccess' name='files' />")
								.appendTo(container)
								.kendoUpload({
										async: {
											saveUrl: "/webservices/mapservice.asmx/save",
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
										{ "CategoryID": 1, "CategoryName": "House" },
										{ "CategoryID": 2, "CategoryName": "Condo" }
									];
		
						function categoryDropDownEditor(container, options) {
							$('<input required name="' + options.field + '"/>')
								.appendTo(container)
								.kendoDropDownList({
									autoBind: false,
									dataTextField: "CategoryName",
									dataValueField: "CategoryName",
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
                    window.location.href = "testimonialsAdd.aspx?tNum=" + dataItem.tNum;
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