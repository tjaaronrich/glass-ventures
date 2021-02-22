<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB/ADMIN_ProductsAdd.aspx.vb" Inherits="ADMIN_ProductsAdd" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Register TagPrefix="uc1" TagName="menuProfile" Src="template/menu-profile.ascx" %>
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
<form runat="server">
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
        <uc1:menuProfile id=menuProfile runat="server"></uc1:menuProfile>
        <br />
        <!--Sidebar-->
        <uc1:sidebarMenu id=sidebarMenu runat="server"></uc1:sidebarMenu>
        
        <!-- /menu footer buttons -->
        <div class="sidebar-footer hidden-small"> <a data-toggle="tooltip" data-placement="top" title="Settings"> <span class="glyphicon glyphicon-cog" aria-hidden="true"></span> </a> <a data-toggle="tooltip" data-placement="top" title="FullScreen"> <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span> </a> <a data-toggle="tooltip" data-placement="top" title="Lock"> <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span> </a> <a data-toggle="tooltip" data-placement="top" title="Logout" href="login.html"> <span class="glyphicon glyphicon-off" aria-hidden="true"></span> </a> </div>
        <!-- /menu footer buttons --> 
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
						<div class="col-md-12">
			
						</div>
						<div class="col-md-12">
							
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
	  <td><h3><a href="Products.aspx"><img src="Graphics/icon_back.png" width="25" height="25" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="Products.aspx" class="Blacku">Back to ADMIN Products</a></h3></td>
	  </tr>
	<tr>
		<td>
			<div>
			  <table width="100%" border="0" cellspacing="0" cellpadding="0">
              	<tr>
                <td><h5>Category: </h5></td>
                  <td><asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="XDS_CategoryStatus" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList><asp:TextBox ID="txtCategory" runat="server" Visible="False" Width="27px"></asp:TextBox>                    </td>
                </tr>
              	<%--<tr>
                <td><h5>Category #2: </h5></td>
                  <td><asp:DropDownList ID="ddlCategory2" runat="server" DataSourceID="XDS_CategoryStatus2" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList><asp:TextBox ID="txtCategory2" runat="server" Visible="False" Width="27px"></asp:TextBox>                    </td>
                </tr>
              	<tr>
                <td><h5>Category #3: </h5></td>
                  <td><asp:DropDownList ID="ddlCategory3" runat="server" DataSourceID="XDS_CategoryStatus2" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList><asp:TextBox ID="txtCategory3" runat="server" Visible="False" Width="27px"></asp:TextBox>                    </td>
                </tr>--%>
                <tr>
                
                    <td width="100" style="height: 24px;"><h5 align="left"><asp:Label ID="Label1" runat="server" Text="Item Name:  "></asp:Label></h5></td>
                    <td valign="top" style="height: 24px"><asp:TextBox ID="txtItemName" runat="server" Width="450" MaxLength="64"></asp:TextBox></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>
                
                <%--<tr>
                    <td width="100" style="height: 24px;"><h5 align="left"><asp:Label ID="Label2" runat="server" Text="Phone Number:  "></asp:Label></h5></td>
                    <td valign="top" style="height: 24px"><asp:TextBox ID="txtPhoneNumber" runat="server" Width="450" MaxLength="255"></asp:TextBox></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>
                <tr>
                    <td width="100" style="height: 24px;"><h5 align="left">Email: </h5></td>
                    <td valign="top" style="height: 24px"><asp:TextBox ID="txtEmailAddress" runat="server" Width="450" MaxLength="255"></asp:TextBox></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>--%>
                <tr>
                    <td width="100" style="height: 24px;"><h5 align="left">Description: </h5></td>
                    <td valign="top" style="height: 24px"><RTE:Editor runat="server" ID="Editor1" ContentCss="CSS/Text_Styles.css" Width="100%" Height="500px"/></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>
                <tr>
                    <td width="100" style="height: 24px;"><h5 align="left">Item Number: </h5></td>
                    <td valign="top" style="height: 24px"><asp:TextBox ID="txtItemID" runat="server" Width="100" MaxLength="64"></asp:TextBox></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>
                <tr>
                    <td width="100" style="height: 24px;"><h5 align="left">Price: </h5></td>
                    <td valign="top" style="height: 24px"><asp:TextBox ID="txtItemPrice" runat="server" Width="100" MaxLength="64"></asp:TextBox></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>
                <tr>
                    <td width="100" style="height: 24px;"><h5 align="left">Shipping: </h5></td>
                    <td valign="top" style="height: 24px"><asp:TextBox ID="txtItemShipping" runat="server" Width="100" MaxLength="64"></asp:TextBox></td>
                    <td style="height: 24px">&nbsp;</td>
                </tr>
                
                <tr>
                  <td style="height: 24px;"><h5 align="left">
                    <asp:Label ID="Label4" runat="server" Text="Sort Order:  "></asp:Label>
                  </h5></td>
                  <td valign="top" style="height: 24px"><asp:TextBox ID="txtSort" runat="server" Width="25" MaxLength="10"></asp:TextBox></td>
                  <td style="height: 24px"><asp:requiredfieldvalidator ID="RFV_04" runat="server" ControlToValidate="txtSort" ErrorMessage="Sort order is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td valign="top"><h5><asp:Label ID="Label9" runat="server" Text="Choose Image:  "></asp:Label>
<br>
<div><font style="font-family:Arial, Helvetica, sans-serif; font-size:10px; font-style:italic; color:#006699">Leave blank  if you are not replacing existing image</font></div>
                  </h5></td>
                  <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td valign="top"><asp:FileUpload ID="FileUpload1" runat="server" Width="350px" /></td>
                      <td width="160" align="center"><asp:Image  ID="thumb" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>
                        <div align="center" style="width:160px"><asp:Label ID="lblImageFile" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label></div></td>
                      <td width="100%" align="center">&nbsp;</td>
                      </tr>
                    
                  </table>                    </td>
                  <td><p> </p></td>
                </tr>
                <tr>
                  <td valign="top"><h5 align="left"><asp:Label ID="Label15" runat="server" Text="Status:  "></asp:Label>
                    </h5></td>
                  <td valign="top"><asp:Panel ID="pnlStatus" runat="server" Visible="False" Width="250px"><asp:TextBox ID="txtStatus" runat="server" Visible="False" Width="27px"></asp:TextBox><asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList></asp:Panel></td>
                  <td valign="top">&nbsp;</td>
                </tr>
                <tr>
                  <td width="100"><img src="Graphics/spacer.gif" width="100" height="5"></td>
                  <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Add Item" /></td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td colspan="2"><p>
                    <asp:Label ID="lblErrorMsg" runat="server" Width="350px"></asp:Label>
                    <asp:Label ID="lblProductsNum" runat="server" Width="350px" Visible="false"></asp:Label>
                  </p></td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td colspan="2">&nbsp;</td>
                </tr>
              </table>
    <asp:ObjectDataSource ID="ODS_Products" runat="server" SelectMethod="GetApprovedProductsList"
        TypeName="DAL_Products" DeleteMethod="DelProducts" UpdateMethod="ModProducts">
        <DeleteParameters>
            <asp:Parameter Name="pID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="pID" Type="Int32" />
            <asp:Parameter Name="Item_Name" Type="String" />
            <asp:Parameter Name="Item_Description" Type="String" />
            <asp:Parameter Name="Item_ID" Type="String" />
            <asp:Parameter Name="Item_Price" Type="String" />
            <asp:Parameter Name="Item_Shipping" Type="String" />
            <asp:Parameter Name="nSort" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:XmlDataSource ID="XDS_CategoryStatus" runat="server" DataFile="~/App_Data/CategoryStatus.xml"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XDS_CategoryStatus2" runat="server" DataFile="~/App_Data/CategoryStatus2.xml"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/Status.xml"></asp:XmlDataSource>
    </div>
    </td>
    </tr>
</table>
							
							
						</div>
					                              
					</div>
           	
            	</div>


            
            
            
            

         
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
</form>
  </body>
</html>
