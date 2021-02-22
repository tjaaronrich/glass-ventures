<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="VB/ADMIN_Calendar2Add.aspx.vb" Inherits="ADMIN_Calendar2Add" validateRequest="false" %>
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
            <td><h3><a href="events.aspx"><img src="Graphics/icon_back.png" width="25" height="25" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="events.aspx" class="Blacku">Back to ADMIN Events</a></h3>
              <p>
                <asp:Label ID="lblCalNum" runat="server" Visible="False"></asp:Label><asp:Label ID="lblStartDate" runat="server" Visible="False"></asp:Label>&nbsp;<asp:Label ID="lblEndDate" runat="server" Visible="False"></asp:Label> 
</p>
              <p>&nbsp;</p></td>
          </tr>
          <tr>
            <td>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td colspan="2" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
              </tr>
            <tr>
                <td width="90" valign="middle"><h5>Category:                    </h5></td>
                <td width="100%" valign="top"><asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="XDS_CategoryStatus" DataTextField="StatusName" DataValueField="StatusCode"></asp:DropDownList></asp:Panel><asp:TextBox ID="txtCategory" runat="server" Visible="False" Width="27px"></asp:TextBox>&nbsp;                </span></td>
                </tr>
            <tr>
              <td colspan="2" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
              </tr>
            <tr>
                <td width="90" valign="middle"><h5>Title:                    </h5></td>
                <td width="100%" valign="top"><asp:TextBox ID="txtTitle" runat="server" Width="350"></asp:TextBox>
                  &nbsp;
                  <asp:requiredfieldvalidator ID="RFV_01" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator>
                  </span></td></tr>
            <tr>
              <td colspan="2" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
              </tr>
            <tr>
                <td valign="top"><h5>                  Start/End:</h5></td>
                <td><table width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="240">
                          <p align="left"><strong>Start Date:</strong></p>
                          <asp:Calendar ID="clndrStartDate" runat="server" BackColor="White" BorderColor="#999999"
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
                            </asp:Calendar>	                    </td>
                        <td><p align="left"><strong>End Date:</strong></p>
                          <asp:Calendar ID="clndrEndDate" runat="server" BackColor="White" BorderColor="#999999"
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
                          </asp:Calendar>					</td>
                    </tr>
                    <tr>
                      <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><p>
                            <asp:CheckBox ID="chkAllDay" runat="server" AutoPostBack="True" Text="Check for an all-day or time-independent event" />                          
                          </p></td>
                        <!--<td>
                            &nbsp;
                        </td>
                        <td style="width: 60px">&nbsp;
                        </td>-->
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlStartTime" runat="server" Height="80px" Width="207px">
                              <p><strong>Start Time:</strong></p>
                            <p> &nbsp;Hr &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mn<br />
                                <asp:ListBox ID="lbStartHr" runat="server" Font-Size="10px">
                                  <asp:ListItem Selected="True">01</asp:ListItem>
                                  <asp:ListItem>02</asp:ListItem>
                                  <asp:ListItem>03</asp:ListItem>
                                  <asp:ListItem>04</asp:ListItem>
                                  <asp:ListItem>05</asp:ListItem>
                                  <asp:ListItem>06</asp:ListItem>
                                  <asp:ListItem>07</asp:ListItem>
                                  <asp:ListItem>08</asp:ListItem>
                                  <asp:ListItem>09</asp:ListItem>
                                  <asp:ListItem>10</asp:ListItem>
                                  <asp:ListItem>11</asp:ListItem>
                                  <asp:ListItem>12</asp:ListItem>
                                  <asp:ListItem></asp:ListItem>
                                  </asp:ListBox>
  &nbsp;
                                <asp:ListBox ID="lbStartMin" runat="server" Font-Size="10px">
                                  <asp:ListItem Selected="True">00</asp:ListItem>
                                  <asp:ListItem>05</asp:ListItem>
                                  <asp:ListItem>10</asp:ListItem>
                                  <asp:ListItem>15</asp:ListItem>
                                  <asp:ListItem>20</asp:ListItem>
                                  <asp:ListItem>25</asp:ListItem>
                                  <asp:ListItem>30</asp:ListItem>
                                  <asp:ListItem>35</asp:ListItem>
                                  <asp:ListItem>40</asp:ListItem>
                                  <asp:ListItem>45</asp:ListItem>
                                  <asp:ListItem>50</asp:ListItem>
                                  <asp:ListItem>55</asp:ListItem>
                                  <asp:ListItem></asp:ListItem>
                                  </asp:ListBox>
  &nbsp;
                                <asp:ListBox ID="lbStartampm" runat="server" Height="39px" Font-Size="10px">
                                  <asp:ListItem Selected="True">am</asp:ListItem>
                                  <asp:ListItem>pm</asp:ListItem>
                                  </asp:ListBox>
                            </p>
                            </asp:Panel>                        </td>
                        <td>
                            <asp:Panel ID="pnlEndTime" runat="server" Height="80px" Width="212px">
                              <p><strong>End Time:</strong></p>
                              <p> &nbsp;Hr &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mn<br />
                                <asp:ListBox ID="lbEndHr" runat="server" Font-Size="10px">
                                  <asp:ListItem Selected="True">01</asp:ListItem>
                                  <asp:ListItem>02</asp:ListItem>
                                  <asp:ListItem>03</asp:ListItem>
                                  <asp:ListItem>04</asp:ListItem>
                                  <asp:ListItem>05</asp:ListItem>
                                  <asp:ListItem>06</asp:ListItem>
                                  <asp:ListItem>07</asp:ListItem>
                                  <asp:ListItem>08</asp:ListItem>
                                  <asp:ListItem>09</asp:ListItem>
                                  <asp:ListItem>10</asp:ListItem>
                                  <asp:ListItem>11</asp:ListItem>
                                  <asp:ListItem>12</asp:ListItem>
                                  <asp:ListItem></asp:ListItem>
                                </asp:ListBox>
  &nbsp;
                                <asp:ListBox ID="lbEndMin" runat="server" Font-Size="10px">
                                  <asp:ListItem Selected="True">00</asp:ListItem>
                                  <asp:ListItem>05</asp:ListItem>
                                  <asp:ListItem>10</asp:ListItem>
                                  <asp:ListItem>15</asp:ListItem>
                                  <asp:ListItem>20</asp:ListItem>
                                  <asp:ListItem>25</asp:ListItem>
                                  <asp:ListItem>30</asp:ListItem>
                                  <asp:ListItem>35</asp:ListItem>
                                  <asp:ListItem>40</asp:ListItem>
                                  <asp:ListItem>45</asp:ListItem>
                                  <asp:ListItem>50</asp:ListItem>
                                  <asp:ListItem>55</asp:ListItem>
                                  <asp:ListItem></asp:ListItem>
                                </asp:ListBox>
  &nbsp;
                                <asp:ListBox ID="lbEndampm" runat="server" Height="39px" Font-Size="10px">
                                  <asp:ListItem Selected="True">am</asp:ListItem>
                                  <asp:ListItem>pm</asp:ListItem>
                                </asp:ListBox>
                                </p>
                              </asp:Panel>                        </td>
                    </tr>
                </table>                
                <p>&nbsp;</p></td>
                </tr>
            <tr>
              <td colspan="2"><img src="Graphics/spacer.gif" width="5" height="5"></td>
              </tr>
            <tr>
                <td valign="middle"><h5>Contact #:
                </h5></td>
                <td valign="top"><asp:TextBox ID="txtContactNumber" runat="server" Width="350"></asp:TextBox>&nbsp;</td>
            </tr>
            <tr>
              <td colspan="2"><img src="Graphics/spacer.gif" width="5" height="5"></td>
              </tr>
            <tr>
                <td valign="middle"><h5>Location:
                </h5></td>
                <td valign="top"><asp:TextBox ID="txtLocation" runat="server" Width="350"></asp:TextBox>&nbsp;<asp:requiredfieldvalidator ID="RFV_02" runat="server" ControlToValidate="txtLocation" ErrorMessage="Location is required" Font-Name="Arial" Font-Size="9"> </asp:requiredfieldvalidator></td>
                </tr>
            <tr>
              <td height="5" colspan="2" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
              </tr>
            <tr>
                <td valign="top"><h5>                  Content:</h5></td>
                <td><RTE:Editor runat="server" ID="Editor1" ContentCss="../CSS/richtext.css" Width="100%" Height="500px"/></td>
                </tr>
                <tr>
                  <td height="5" colspan="3" valign="top"><img src="Graphics/spacer.gif" width="5" height="5"></td>
                  </tr>
                <tr>
                  <td valign="top"><h5><asp:Label ID="Label27" runat="server" Text="Choose File:  "></asp:Label>
<br>
<div><font style="font-family:Arial, Helvetica, sans-serif; font-size:10px; font-style:italic; color:#006699">Leave blank  if you are not replacing existing file</font></div>
                  </h5></td>
                  <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td valign="top"><asp:FileUpload ID="FileUpload2" runat="server" Width="350px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblfileName" runat="server" Text="" Visible="True" Font-Name="Arial" Font-Size="10px" ></asp:Label><asp:Label ID="lblfileName2" runat="server" Text="" Visible="False" Font-Name="Arial" Font-Size="10px" ></asp:Label></td>
                      </tr>
                    
                  </table>                    </td>
                  <td><p> </p></td>
                </tr>
            <tr>
              <td colspan="2"><img src="Graphics/spacer.gif" width="5" height="10"></td>
              </tr>
            <tr>
                <td><img src="Graphics/spacer.gif" width="90" height="5"></td>
                <td><asp:Panel ID="pnlStatus" runat="server" Height="50px" Visible="False" Width="125px">
                  <p><strong>Status:</strong>
                          <asp:TextBox ID="txtStatus" runat="server" Visible="False" Width="27px"></asp:TextBox>
                                <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="XDS_Status" DataTextField="StatusName" DataValueField="StatusCode" Font-Size="10px"></asp:DropDownList></p>
                        </asp:Panel>                </td>
                </tr>
            
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="SaveButton" runat="server" Text="Add Item" /></td>
                </tr>
        </table></td>
          </tr>
          
          <tr>
            <td>        <asp:ObjectDataSource ID="ODS_Calendar" runat="server" DataObjectTypeName="PC_Calendar"
            DeleteMethod="DelCalendarEvent" SelectMethod="GetAllCalendarItems" TypeName="DAL_Calendar2">        </asp:ObjectDataSource>
        <asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/NewsFTBStatus.xml">        </asp:XmlDataSource>
    <asp:XmlDataSource ID="XDS_CategoryStatus" runat="server" DataFile="~/App_Data/EventStatus.xml"></asp:XmlDataSource></td>
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
