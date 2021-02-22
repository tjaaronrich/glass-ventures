<%@ Page Language="VB" AutoEventWireup="false"  %>
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
    
    
	<link href="css/theme.css" rel="stylesheet" type="text/css">
    
    
    
    
    
    
    <!-- Kendo -->
    <link rel="stylesheet" href="/plugins/kendo/styles/kendo.common.min.css" />
    <link rel="stylesheet" href="/plugins/kendo/styles/kendo.default.min.css" />
    <link rel="stylesheet" href="/plugins/kendo/styles/kendo.default.mobile.min.css" />

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
            	<form runat="server">
                	<div id="example">
                	    <asp:GridView showheader="false" ID="GridView" GridLines="None" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Property" DataKeyNames="pID"
                                width=100%
                                CellPadding="0" 
                                CellSpacing="0"
                                Border="0"
                                Font-Names="Arial" 
                                Font-Size="11px">
                 				<%--<Headerstyle BackColor="#897b23" ForeColor="#ffffff" Font-Name="Arial" Font-Size="11 px" HorizontalAlign="left" Font-Bold="True" ></Headerstyle>
								<AlternatingRowStyle BackColor="#e5e5e5" ForeColor="#000000" Font-Name="Arial" Font-Size="11 px" HorizontalAlign="left"></AlternatingRowStyle>
								<PAGERSTYLE backcolor="#cccccc" forecolor="Black" Font-Size="10 px" Font-Names="arial" horizontalalign="Left"></PAGERSTYLE>--%>
                  			<columns>
                  				<asp:TemplateField HeaderText="Property">
                    				<itemtemplate>
                                    	<div class="row" style="padding-bottom: 10px;padding-top: 10px;border-bottom-style: solid;border-bottom-width: 1px;border-bottom-color: #E2E2E2;">
                                            <div class="col-md-2 detail-img">
                                                <a href="vendors-detail.aspx?pID=<%#Eval("pID")%>&pName=<%#Eval("pName")%>">
                                                    <img class="img-responsive" src="/Documents/Vendors/<%#Eval("ImageFile1")%>" alt="Panhandle Property Management" width="100%" height="auto">
                                                </a>
                                                <img src="/Graphics/spacer.gif" width="100%" height="10" style="visibility:hidden;">
                                            </div>
                                            
                                            <div class="col-md-10">
                                                <div class="col-md-12">
                                                    <h1 style="margin:0;font-family:'Titillium Web';"><a class="properties" href="vendors-detail.aspx?pID=<%#Eval("pID")%>&pName=<%#Eval("pName")%>" ><%#Eval("pName")%></a></h1>
                                                    <br />
                                                    <p class="properties" style="font-family:'Titillium Web';"><span style="font-weight:bold;">Panama City's Beautiful Beaches!! </span></p>
                                                    <p class="properties" style="font-family:'Titillium Web';"><span style="">This would be a brief summary/description </span></p>
                                                    
                                                <a href="vendors-detail.aspx?pID=<%#Eval("pID")%>&pName=<%#Eval("pName")%>" class="btn-property" style="" >More Info</a>
                                                </div>
                                            </div>
                                        
                                        </div>

                    				</itemtemplate>
                  				</asp:TemplateField>
                  			</columns>
              			</asp:GridView>
						<asp:ObjectDataSource ID="ODS_Property" runat="server" SelectMethod="GetVendorList" TypeName="DAL_Listing" DataObjectTypeName="PC_Listing" ></asp:ObjectDataSource>
                                
        
        			</div>
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
	    <script>
        $("#editor1").kendoEditor({
            tools: [
                "bold",
                "italic",
                "underline",
                "strikethrough",
                "justifyLeft",
                "justifyCenter",
                "justifyRight",
                "justifyFull",
                "insertUnorderedList",
                "insertOrderedList",
                "indent",
                "outdent",
                "createLink",
                "unlink",
                "insertImage",
                "insertFile",
                "subscript",
                "superscript",
                "createTable",
                "addRowAbove",
                "addRowBelow",
                "addColumnLeft",
                "addColumnRight",
                "deleteRow",
                "deleteColumn",
                "viewHtml",
                "formatting",
                "cleanFormatting",
                "fontName",
                "fontSize",
                "foreColor",
                "backColor",
                "print"
            ]
        });
		
		$("#editor2").kendoEditor({
  			encoded: false,
            tools: [
                "bold",
                "italic",
                "underline",
                "strikethrough",
                "justifyLeft",
                "justifyCenter",
                "justifyRight",
                "justifyFull",
                "insertUnorderedList",
                "insertOrderedList",
                "indent",
                "outdent",
                "createLink",
                "unlink",
                "insertImage",
                "insertFile",
                "subscript",
                "superscript",
                "createTable",
                "addRowAbove",
                "addRowBelow",
                "addColumnLeft",
                "addColumnRight",
                "deleteRow",
                "deleteColumn",
                "viewHtml",
                "formatting",
                "cleanFormatting",
                "fontName",
                "fontSize",
                "foreColor",
                "backColor",
                "print"
            ]
        });
    </script>
  </body>
</html>
