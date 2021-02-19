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

				<script type="text/x-kendo-template" id="productsEditTemplate">			

					<label for="Sort">Sort</label><input data-bind="value: Sort" name="Sort"/><br/>

					<label for="Name">Name</label><input data-bind="value: Name" name="Name"/><br/>

					<label for="Address">Address</label><input data-bind="value: Address" name="Address"/><br/>

					<input type="hidden" id='uploadedFile' data-bind="value: fileName" />

					<input type="file" id="files" data-role="upload" data-async='{"saveUrl": "/Home/test","autoUpload": "true"}' data-success="onSuccess" name="files" />

				</script>

				<script>

					var dataSource = new kendo.data.DataSource({

						transport: {

							read:  {

								url: "/webservices/newsletterservice.asmx/GetNewsLettersList",

								dataType: "json"

							},

							update: {

								url: "/webservices/newsletterservice.asmx/UpdateNewsLetter",

								dataType: "json"

							},

							destroy: {

								url: "/webservices/newsletterservice.asmx/DeleteNewsletter",

								dataType: "json"

							},

							create: {

								url: "/webservices/newsletterservice.asmx/AddNewsletter",

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

							id: "nNum",

							fields: {

								nNum: { editable: false },

								addDate: { editable: false },

								uName: {

									

									validation: {

        								required: { message: "User Name cannot be Null!" }

									}

								},

								fullName: {

									

									validation: {

        								required: { message: "Full Name cannot be Null!" }

									}

								},

								passWord: {

									

									validation: {

        								required: { message: "Password cannot be Null!" },

										passwordvalidation: function (input) {

											//if (input.is("[name='passWord']") && input.val() != "") {

												//input.attr("data-productnamevalidation-msg", "Product Name should start with capital letter");

												//return /^[A-Z]/.test(input.val());

											//}

											//if (input.val() != "") {

												//input.attr("data-passwordvalidation-msg", "Password cannot be null");

												//return /^[A-Z]/.test(input.val());

											//}



											return true;

										}

									}

								},

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

						{ command: ["edit", "destroy",{ text: "DELETE FILE", click: showDetails}], title: "&nbsp;", width: "350px" },
						{ field: "nNum", title:"ID", width: "120px" },
						{ field: "nTitle", title:"Title", width: "120px" },
						{ field: "nDescription", title:"Description", width: "120px" },
						{ field: "nSort", title:"Sort Order", width: "120px" },
						{ field: "linkCategory", title:"Category", width: "120px", editor: categoryDropDownEditor  },

						
						{ field: "fileName", title:"Thumb", width: "120px", editor: uploadEditor, template: "<a href='/Documents/newsletter/Thumbs/#: fileName #' onerror='imgError(this);' >#: fileName #</a>" }

					],

					editable:  {

						mode: "popup",

						width: "600px"

					},

					save: function(e,c){

						e.model.set("fileName",$("#uploadedFile").val());

					}	

				});





					

				function imgError(image) {

					image.onerror = "";

					image.src = "/Graphics/fill.png";

					return true;

				}

				function passwordEditor(container, options)

				{

					$('<input type="password" required data-bind="value:' + options.field + '"/>').appendTo(container);

				};

					

					

					

				function onCreateSuccess(e)

				{	

					$('#grid').data('kendoGrid').dataSource.read();

				}





				function uploadEditor(container, options) {

					console.log(container);

					console.log(options);

					var dir = options.model.acctNum;

					$("<input type='hidden' id='uploadedFile' data-bind='value: fileName' />").appendTo(container);

					$("<input type='file' id='files' data-role='upload'  data-success='onSuccess' name='files' />")

						.appendTo(container)

						.kendoUpload({

							async: {

								saveUrl: "/webservices/uploadservice.asmx/saveUser?dir=" + dir,

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


					{ "CategoryID": "Travel Forms", "CategoryName": "Travel Forms" },

					{ "CategoryID": "Staff Email", "CategoryName": "Staff Email" }

				
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

					$.ajax({

						url: "/webservices/newsletterservice.asmx/DeleteFile?nNum=" + dataItem.nNum, 

						success: function(result){

							$("#div1").html(result);

						}

					});

					$('#grid').data('kendoGrid').dataSource.read();

					//window.location.href = "Your-Owner-ListingAdd.aspx?pID=" + dataItem.CustomerID;

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