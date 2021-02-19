<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB/ADMIN_EditPhoto.aspx.vb" Inherits="ADMIN_EditPhoto" %>
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
						<div class="col-md-12">

							
							<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                            <tr>
                              <td height="131" valign="top">
                              <p>&nbsp;</p>
                              <p>
                                <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
                              </p>
                              <table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td>
			<div>
			  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td colspan="3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td>
                          <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="170" valign="top"><p>Image ID:</p></td>
                              <td width="250">
                                  <asp:Label ID="lblphotoID" runat="server" Text=""></asp:Label></td>
                              <td class="style1"><p></p></td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Image Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox></td>
                              <td class="style1"><p></p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Image File Name:</p></td>
                              <td>
                                  <asp:Label ID="lblFileName" runat="server" Text="Label"></asp:Label>
                                  <p>To select a different image, delete this record, and upload a new image.</p>
                              </td>
                              <td class="style1"></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td valign="top" style="height: 22px"><p>Place in Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery" runat="server" datasourceid="ODS_GalleryList" 
                                      DataTextField="pgName" DataValueField="pgID">
                                  </asp:DropDownList></td>
                              <td class="style2"><p> </p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Status:</p></td>
                              <td>
                                  <asp:DropDownList ID="ddlStatus" runat="server">
                                      <asp:ListItem Value="Active">Active</asp:ListItem>
                                      <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                  </asp:DropDownList></td>
                              <td class="style1"><p> </p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Update" /></td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td colspan="2"><p>
                    <asp:Label ID="lblErrorMsg" runat="server" Width="487px"></asp:Label>
                  </p></td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td colspan="2">&nbsp;</td>
                </tr>
              </table>


    <asp:ObjectDataSource ID="ODS_Gallery" runat="server" SelectMethod="GetApprovedImageList"
        TypeName="DAL_Gallery" DeleteMethod="DeletePhoto" UpdateMethod="ModifyPhoto">
        <DeleteParameters>
            <asp:Parameter Name="photoID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="photoID" Type="Int32" />
            <asp:Parameter Name="photoName" Type="String" />
            <asp:Parameter Name="pgName" Type="String" />
            <asp:Parameter Name="photoStatus" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>



    <asp:ObjectDataSource ID="ODS_GalleryList" runat="server" SelectMethod="GetActiveGalleryList"
        TypeName="DAL_Gallery"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_GalleryListAll" runat="server" SelectMethod="GetGalleryList"
        TypeName="DAL_Gallery"></asp:ObjectDataSource>
    
    <asp:XmlDataSource ID="XDS_photoStatus" runat="server" DataFile="~/App_Data/photoStatus.xml">
    </asp:XmlDataSource>			
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </div>        </td>
    </tr> 
</table>                              
<p>&nbsp;</p></td>
                              <td width="20"><img src="Graphics/spacer.gif" width="20" height="20"></td>
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
