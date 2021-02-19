<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB/Your-Owner-Listing.aspx.vb" Inherits="YourOwnerListing" validaterequest="false" %>
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
<script src="/plugins/kendo/js/jquery.min.js"></script>
<script src="/plugins/kendo/js/kendo.all.min.js"></script>
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
		var url = "http://www.testurl14.com/webservices/mapservice.asmx/GetOwnerListByUser?pID=" + pid
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
          <!--<form runat="server">
            <div id="example">
              <h3><a href="Your-Owner-ListingAdd.aspx"><img src="/Graphics/icon_add.png" width="25" height="25" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="Your-Owner-ListingAdd.aspx" class="Blacku">Add Listing</a></h3>
              <asp:GridView ID="GridView1" PageSize="20" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Property" DataKeyNames="pID" 
                                width="100%"
                                CellPadding="5" PagerSettings-Mode="NumericFirstLast" class="table table-hover table-striped">
                <Headerstyle BackColor="#2A3F54" ForeColor="White" Font-Size="11px" HorizontalAlign="Left" Font-Bold="True" ></Headerstyle>
                <AlternatingRowStyle BackColor="#E5E5E5"  HorizontalAlign="Left" ></AlternatingRowStyle>
                <PAGERSTYLE backcolor="#CCCCCC" forecolor="Black" Font-Size="10px" Font-Names="arial" horizontalalign="Left"></PAGERSTYLE>
                <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True">
                  <ControlStyle ForeColor="Black" />
                </asp:CommandField>
                <asp:BoundField DataField="pID" HeaderText="ID" ReadOnly="True" SortExpression="pID" visible="false" />
                <asp:BoundField DataField="pSort" HeaderText="Sort Order" SortExpression="pSort" />
                <asp:BoundField DataField="pName" HeaderText="Name" SortExpression="pName" />
                <asp:BoundField DataField="pType" HeaderText="Type" SortExpression="pType" />
                <asp:TemplateField HeaderText="Thumb" ItemStyle-Width="10px">
                  <ItemTemplate>
                    <div align="center" style="text-align:center"> <a href='../Documents/Owners/BigThumbs/<%#Eval("ImageFile1")%>' target="_blank" ><img width="150px" src='../Documents/Owners/Thumbs/<%#Eval("ImageFile1")%>' border=0></a> </div>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                </Columns>
              </asp:GridView>
              <asp:ObjectDataSource ID="ODS_Property" runat="server" SelectMethod="GetOwnerListByUser"
        TypeName="DAL_Listing" DeleteMethod="DeleteProperty" UpdateMethod="ModifyProperty" DataObjectTypeName="PC_Attractions">
                <DeleteParameters>
                  <asp:Parameter Name="pID" Type="Int32" />
                </DeleteParameters>
              </asp:ObjectDataSource>
            </div>
          </form>-->
          <div id="example">

            <div class="demo-section k-content wide">
              <div id="grid"></div>
            </div>
			<script type="text/x-kendo-template" id="productsEditTemplate">			
				<label for="Sort">Sort</label><input data-bind="value: Sort" name="Sort"/><br/>
				<label for="Name">Name</label><input data-bind="value: Name" name="Name"/><br/>
				<label for="Address">Address</label><input data-bind="value: Address" name="Address"/><br/>
				<input type="hidden" id='uploadedFile' data-bind="value: ImageFile" />
				<input type="file" id="files" data-role="upload" data-async='{"saveUrl": "/Home/test","autoUpload": "true"}' data-success="onSuccess" name="files" />
	        </script>
            <script>
		
		
        var dataSource = new kendo.data.DataSource({
            transport: {
                read:  {
                    url: url,
                    dataType: "json"
                },
                update: {
                    url: "http://www.testurl14.com/webservices/mapservice.asmx/updateGrid",
                    dataType: "json"
                },
                destroy: {
                    url: "http://www.testurl14.com/webservices/mapservice.asmx/DeleteOwnerListing",
                    dataType: "json"
                },
                create: {
                    url: "http://www.testurl14.com/webservices/mapservice.asmx/AddOwnerListing?pLinkId=" + pid,
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
                    id: "CustomerID",
                    fields: {
                        CustomerID: { editable: false },
                        Sort: { type: "number" }
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
                { command: [{ text: "View Details", click: showDetails},"edit", "destroy"], title: "&nbsp;", width: "350px" },
                "Sort",
                "Name",
                { field: "Address", title:"Address", width: "120px" },
                { field: "Type", title:"Type", width: "120px", editor: categoryDropDownEditor },
                { field: "ImageFile", title:"Thumb", width: "120px", editor: uploadEditor, template: "<img class='img-responsive' src='/Documents/Owners/Thumbs/#: ImageFile #' />" },
                { field: "Status", title:"Status", width: "120px", editor: statusDropDownEditor, defaultValue: { CategoryID: 1, CategoryName: "Active"} },
            ],
			editable:  {
				mode: "popup",
      			width: "600px"
			},
			save: function(e,c){
						e.model.set("ImageFile",$("#uploadedFile").val());
			}	
        });
				
				
		function onCreateSuccess(e)
		{	
			$('#grid').data('kendoGrid').dataSource.read();
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
    </div>
    <!-- /page content -->
    
    <uc1:footer id=footer runat="server"></uc1:footer>
  </div>
</div>

<!-- jQuery 
    <script src="vendors/jquery/dist/jquery.min.js"></script>--> 
<!-- Bootstrap --> 
<script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script> 
<!-- FastClick --> 
<script src="vendors/fastclick/lib/fastclick.js"></script> 
<!-- NProgress --> 
<script src="vendors/nprogress/nprogress.js"></script> 
<!-- Chart.js --> 
<script src="vendors/Chart.js/dist/Chart.min.js"></script> 
<!-- gauge.js --> 
<script src="vendors/gauge.js/dist/gauge.min.js"></script> 
<!-- bootstrap-progressbar --> 
<script src="vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"></script> 
<!-- iCheck --> 
<script src="vendors/iCheck/icheck.min.js"></script> 
<!-- Skycons --> 
<script src="vendors/skycons/skycons.js"></script> 
<!-- Flot --> 
<script src="vendors/Flot/jquery.flot.js"></script> 
<script src="vendors/Flot/jquery.flot.pie.js"></script> 
<script src="vendors/Flot/jquery.flot.time.js"></script> 
<script src="vendors/Flot/jquery.flot.stack.js"></script> 
<script src="vendors/Flot/jquery.flot.resize.js"></script> 
<!-- Flot plugins --> 
<script src="vendors/flot.orderbars/js/jquery.flot.orderBars.js"></script> 
<script src="vendors/flot-spline/js/jquery.flot.spline.min.js"></script> 
<script src="vendors/flot.curvedlines/curvedLines.js"></script> 
<!-- DateJS --> 
<script src="vendors/DateJS/build/date.js"></script> 
<!-- JQVMap --> 
<script src="vendors/jqvmap/dist/jquery.vmap.js"></script> 
<script src="vendors/jqvmap/dist/maps/jquery.vmap.world.js"></script> 
<script src="vendors/jqvmap/examples/js/jquery.vmap.sampledata.js"></script> 
<!-- bootstrap-daterangepicker --> 
<script src="vendors/moment/min/moment.min.js"></script> 
<script src="vendors/bootstrap-daterangepicker/daterangepicker.js"></script> 

<!-- Custom Theme Scripts --> 
<script src="build/js/custom.min.js"></script> 
<script>

  </body>
</html>
