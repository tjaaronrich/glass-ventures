<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB/Admin_Videosadd.aspx.vb" Inherits="Admin_Videos" validaterequest="false" %>
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
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td>
            <asp:Label ID="lblVideosNum" runat="server" Text="Label" Visible="False"></asp:Label>
<h3><a href="Videos.aspx"><img src="Graphics/icon_back.png" width="25" height="25" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="Videos.aspx" class="Blacku">Back to Videos</a></h3></td>
          </tr>
          <tr>
            <td>
<table style="width: 100%; border: 0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><h5 align="left">
                    <asp:Label ID="Label2" runat="server" Text="You Tube ID:  "></asp:Label>
                  </h5></td>
                  <td><asp:TextBox ID="txtYouTubeID" runat="server" Width="450" Font-Name="Arial" Font-Size="11px"></asp:TextBox></td>
                  <td><asp:requiredfieldvalidator ID="RFV_01" runat="server" ControlToValidate="txtYouTubeID" ErrorMessage="You Tube ID is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                  </tr>
                <tr>
                    <td width="90"><h5 align="left"><asp:Label ID="Label3" runat="server" Text="Title:  "></asp:Label></h5></td>
                    <td><asp:TextBox ID="txtvTitle" runat="server" Width="450" Font-Name="Arial" Font-Size="11px"></asp:TextBox></td>
                    <td><asp:requiredfieldvalidator ID="RFV_02" runat="server" ControlToValidate="txtvTitle" ErrorMessage="Title is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                  </tr>
                <tr>
                    <td valign="top"><h5 align="left"><asp:Label ID="Label8" runat="server" Text="Description:  "></asp:Label>
                    </h5></td>
                    <td width="460"><asp:TextBox ID="txtvDescription" runat="server" Width="450" Font-Name="Arial" Font-Size="11px"></asp:TextBox></td>
                    <td valign="top"><asp:requiredfieldvalidator ID="RFV_03" runat="server" ControlToValidate="txtvDescription" ErrorMessage="Description is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                  </tr>
                <tr>
                  <td valign="top"><h5 align="left">
                    <asp:Label ID="Label4" runat="server" Text="Credits:  "></asp:Label>
                  </h5></td>
                  <td><asp:TextBox ID="txtCredits" runat="server" Width="450" Font-Name="Arial" Font-Size="11px"></asp:TextBox></td>
                  <td valign="top"><asp:requiredfieldvalidator ID="RFV_04" runat="server" ControlToValidate="txtCredits" ErrorMessage="Credits is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator></td>
                </tr>
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                </tr>
                <tr>
                  <td valign="top"><h5 align="left"><asp:Label ID="Label1" runat="server" Text="Video Date:  "></asp:Label>
                    </h5></td>
                  <td><asp:Calendar ID="clndrVideoDate" runat="server" BackColor="White" BorderColor="#999999"
                                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                        ForeColor="Black" Height="150px" Width="225px" ShowGridLines="True" >
                            <SelectedDayStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#C4CECF" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#C4CECF" ForeColor="Black" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <NextPrevStyle VerticalAlign="Bottom" ForeColor="#FFFFFF" />
                            <DayHeaderStyle BackColor="#000000" Font-Bold="True" forecolor="white" Font-Size="7pt" />
                            <TitleStyle BackColor="#666666" Font-Bold="True" forecolor="white" />
                          </asp:Calendar></td>
                  <td valign="top">&nbsp;</td>
                </tr>
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                  </tr>
                <tr>
                  <td valign="top"><h5 align="left"><asp:Label ID="Label15" runat="server" Text="Status:  "></asp:Label>
                    </h5></td>
                  <td valign="top"><asp:Panel ID="pnlStatus" runat="server" Visible="False" Width="250px"><asp:TextBox ID="txtStatus" runat="server" Visible="False" Width="27px"></asp:TextBox><asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList></asp:Panel></td>
                  <td valign="top">&nbsp;</td>
                </tr>
                
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                  </tr>
                <tr>
                    <td><h5>&nbsp;</h5></td>
                    <td colspan="2"><h5><asp:Button ID="SaveButton" runat="server" Text="Add Videos" /><asp:Label ID="lblErrorMsg" runat="server" Width="350px"></asp:Label></h5></td>
                </tr>
            </table></td>
          </tr>
          
          <tr>
            <td>        <asp:ObjectDataSource ID="ODS_Videos" runat="server" DataObjectTypeName="PC_Videos"
            DeleteMethod="DelVideos" SelectMethod="GetAllVideos" TypeName="DAL_Videos">
            <SelectParameters>
                <asp:Parameter Name="VideosStatus" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/VideosStatus.xml"></asp:XmlDataSource><asp:XmlDataSource ID="XDS_Status2" runat="server" DataFile="~/App_Data/YearStatus.xml"></asp:XmlDataSource></td>
          </tr>
        </table>
						</div>
						<div class="col-md-12">
							
							
							
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
