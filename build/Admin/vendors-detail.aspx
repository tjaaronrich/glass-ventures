<%@ Page Language="VB" validaterequest="false" debug="true" src="vb/vendors-detail.aspx.vb" Inherits="AttractionsDetail" %> 
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Register TagPrefix="uc1" TagName="menuProfile" Src="template/menu-profile.ascx" %>
<%@ Register TagPrefix="uc1" TagName="menuFooter" Src="template/menu-footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sidebarMenu" Src="template/sidebar-menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="topNavigation" Src="template/top-navigation.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="template/footer.ascx" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.Odbc" %>
<%@ import namespace="System.Data.SqlClient" %> 
<%@ import Namespace="System" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Net.Mail" %>
<%@ import Namespace="System.IO" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>ARM Dashboard | </title>

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
    <link rel="stylesheet" href="/plugins/kendo/styles/kendo.common.min.css" />
    <link rel="stylesheet" href="/plugins/kendo/styles/kendo.default.min.css" />
    <link rel="stylesheet" href="/plugins/kendo/styles/kendo.default.mobile.min.css" />

    <script src="/plugins/kendo/js/jquery.min.js"></script>
    <script src="/plugins/kendo/js/kendo.all.min.js"></script>


	<script runat="server" src="/Mail/sendMail.vb" ></script>
    <style>
    	.preview, .js-descriptionCollapse
		{
			background-color:transparent!important;
		}
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
		var FullName = '<%= Session("FullName").ToString() %>';
		var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
    </script>  
	<script src="js/userAccess.js" type="text/javascript"></script>  
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 left_col">
          <div class="left_col scroll-view">
            <div class="navbar nav_title" style="border: 0;">
              <a href="Default2.aspx" class="site_title" style="text-align:center;"> <span id="userType"></span></a>
            </div>

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
                <form runat="server" style="margin-bottom:0;" defaultbutton="submit" >
                    <section style="padding-top:0px;">
                        <div class="container about-container">
                            <div class="row">
                                <div class="col-md-8">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="9">
                                                            <asp:Label ID="lblImageFile0" runat="server" Text="" Visible="True" class="detail-img"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr> 
                                                        <td width="19%">
                                                            <asp:Label ID="lblImageFile1" runat="server" Text="" Visible="True" class="detail-img"></asp:Label>
                                                        </td>
                                                        <td width="1%">&nbsp;</td>
                                                        <td width="19%">
                                                            <asp:Label ID="lblImageFile2" runat="server" Text="" Visible="True" class="detail-img"></asp:Label>
                                                        </td>
                                                        <td width="1%">&nbsp;</td>
                                                        <td width="19%">
                                                            <asp:Label ID="lblImageFile3" runat="server" Text="" Visible="True" class="detail-img"></asp:Label>
                                                        </td>
                                                        <td width="1%">&nbsp;</td>
                                                        <td width="19%">
                                                            <asp:Label ID="lblImageFile4" runat="server" Text="" Visible="True" class="detail-img"></asp:Label>
                                                        </td>
                                                        <td width="1%">&nbsp;</td>
                                                        <td width="19%">
                                                            <asp:Label ID="lblImageFile5" runat="server" Text="" Visible="True" class="detail-img"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <p>&nbsp;</p>
                                                <h1><%= HttpUtility.HtmlEncode(propName) %></h1>
                                                <p><%= HttpUtility.HtmlEncode(Address) %></p>
                                                <p>
                                                    <%= Beds %>
                                                    <%= Baths %>
                                                    <%= Sleeps %>
                                                </p>
                                                <p>
                                                    <%= Price %>
                                                    <%= Acres %>
                                                </p>
                                                <div class="infoSection">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                
                                                    <tr>
                                                        <td>
                                                            <p style=""><strong>Listing Status: </strong></p>
                                                        </td>
                                                        <td>
                                                            <p><%= HttpUtility.HtmlEncode(Status) %></p>
                                                        </td>
                                                    </tr>
                                                    <%= listType %>
                                                    <tr>
                                                        <td>
                                                            <p style=""><strong>Property Type: </strong></p>
                                                        </td>
                                                        <td>
                                                            <p style='width:100%;'><%= HttpUtility.HtmlEncode(propType) %></p>
                                                        </td>
                                                    </tr>
                                                    <%= mls_Id %>
                                                    <tr>
                                                        <td>
                                                            <p><strong>Irrigated: </strong></p>
                                                        </td>
                                                        <td>
                                                            <p><%= HttpUtility.HtmlEncode(irrigated) %></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <p><strong>Residence: </strong></p>
                                                        </td>
                                                        <td>
                                                            <p><%= HttpUtility.HtmlEncode(residence) %></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <p><strong>Property ID: </strong></p>
                                                            </td>
                                                            <td>
                                                            <p><%= HttpUtility.HtmlEncode(propId) %></p>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div>
                                                <p>&nbsp;</p>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td> 
                                                            <%= Features %>
                                                        </td>
                                                    </tr> 
                                                </table>
                                                <p>&nbsp;</p>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <h5 style="font-size:26px" class="Blue">
                                                                            <asp:Label ID="lblpName" runat="server" Text="" Visible="True"></asp:Label>
                                                                        </h5>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <p style="margin-top:5px; margin-bottom:0px; font-size:14px">
                                                                <strong>
                                                                    <asp:Label ID="lblpAddress" runat="server" Text="" Visible="True"></asp:Label>
                                                                </strong>
                                                            </p>
                                                            <hr style="color:#E2E2E2; height:1px; border:none; background-color:#E2E2E2">
                                                            <p style="margin-top:5px;">
                                                                <span style="margin-top:5px; margin-bottom:10px">
                                                                    <asp:Label ID="lblpDescription" runat="server" Text="" Visible="True"></asp:Label>
                                                                </span>
                                                            </p>
                                                            <p>&nbsp;</p> 
                                                            <p>
                                                                <i class="fa fa-print" aria-hidden="true"></i>
                                                                <a href="javascript:window.print();" class="Grayu" style="color:#333;">Print Story</a>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <i class="fa fa-envelope-o" aria-hidden="true"></i>
                                                                <asp:Label ID="lblMailTo" runat="server" Text="" Visible="True"></asp:Label>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <p>&nbsp;</p>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblpLat" runat="server" Text="" Visible="True"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                            
                                </div>
                                
                                <div class="col-md-4 col-sidebar-contact" >
                                    <h3 style="">Request More Info</h3>
                                    <p style="font-size:15px;">For additional information, please complete the form below. Our staff at Panhandle Property Management looks forward to hearing from you. </p>
                                    <hr style="color:#E2E2E2; height:1px; border:none; background-color:#E2E2E2">
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:TextBox ID="firstName" runat="server" Width="100%" CssClass="form-field" placeholder="First name" style="font-size:11pt; padding:8px; outline:none; " required></asp:TextBox>	
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:TextBox ID="lastName" runat="server" Width="100%" CssClass="form-field" placeholder="Last name" style="font-size:11pt; padding:8px;"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:TextBox ID="emailAddress" runat="server" Width="100%" CssClass="form-field" placeholder="Email address" style="font-size:11pt; padding:8px; outline:none; " required></asp:TextBox>
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:TextBox ID="phoneNumber" runat="server" Width="100%" CssClass="form-field" placeholder="Phone number" style="font-size:11pt; padding:8px;"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:RequiredFieldValidator ID="RFV11" runat="server" ControlToValidate="emailAddress" ErrorMessage="Email is required" CssClass="form-message"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invalid email" ControlToValidate="emailAddress" ValidationExpression="\S+@\S+\.\S{2,3}" CssClass="form-message"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:TextBox ID="message" runat="server" TextMode="multiline" CssClass="form-multifield" placeholder="Message" Height="75px" Width="100%" style=" font-size:11pt; outline:none;  padding:8px;" required></asp:TextBox>
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:Button ID="Submit" OnClick="submit_click" runat="server" Text="Send message" CssClass="btn btn-success btn-lg"  Font-Size="18px" />
                                    </div>
                                    <div class="col-lg-12 sidebar-contact-form">
                                        <asp:TextBox ID="txtURL" runat="server" Width="0" MaxLength="255" Visible="true" BorderWidth="0" ForeColor="#ffffff" style="width: 0px;visibility: hidden;position: absolute;"></asp:TextBox>
                                        <!--<asp:Label ID="lblpVRBO" runat="server" Text="" Visible="True"></asp:Label>-->
                                        <br>
                                        <asp:Label ID="lblpHomeaway" runat="server" Text="" Visible="True"></asp:Label>
                                    </div>	
                                </div>
                            </div>  
                        </div>
                    </section>
                    
                
                </form>





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
</body>
</html>
