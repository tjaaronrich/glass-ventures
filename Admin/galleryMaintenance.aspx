<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/ADMIN_GalleryMaintenance.aspx.vb" Inherits="ADMIN_GalleryMaintenance" %>
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
	<form runat="server">
		<section id="content">
		<!--start container-->
			<div class="container">
            <!--card stats start-->
            <!--card stats end-->
				<div class="row">
					<div class="col s12 m12">
			  			<div class="card">
							<div class="card-content center">
							<h4 style="text-align: left;">Gallery Maintenance</h4>
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="100"><img src="Graphics/spacer.gif" alt="" width="100" height="5" /></td>
                  <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td style="height: 149px">
                          <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td valign="top" style="height: 22px"><p>Select Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery" runat="server" datasourceid="ODS_GalleryListAll" DataTextField="pgName" DataValueField="pgID" AutoPostBack="True">
                                  </asp:DropDownList></td>
                              <td style="height: 22px; width: 1px;"><p> </p></td>
                            </tr>
                            <tr>
                              <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Gallery ID:</p></td>
                              <td width="250">
                                  <asp:Label ID="lblpgID" runat="server" Text="" Font-Name="Arial" Font-Size="12px"></asp:Label></td>
                              <td style="width: 1px"><p></p></td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Gallery Name:<br />&nbsp;<br />New Name: </p></td>
                              <td width="250">
                                  <asp:Label ID="lblpgName" runat="server" Text="" Width="200px" Font-Name="Arial" Font-Size="12px"></asp:Label><br />
                                  <asp:TextBox ID="txtpgName" runat="server" Width="200px"></asp:TextBox></td>
                              <td style="width: 1px"><p></p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Status:</p></td>
                              <td>
                                  <asp:DropDownList ID="ddlStatus" runat="server">
                                      <asp:ListItem Value="Active">Active</asp:ListItem>
                                      <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                  </asp:DropDownList></td>
                              <td style="width: 1px"><p> </p></td>
                            </tr>
                            <tr>
                              <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2"><asp:Button ID="btnModify" runat="server" Text="Modify" /></td>
                            </tr>
                            <tr>
                              <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                              <td colspan="3"><p>&nbsp;<asp:Button ID="btnArchive" runat="server" Text="Archive" />&nbsp;&nbsp;Gallery and all photos in gallery are DEACTIVATED.</p></td>
                            </tr>
                            <tr>
                              <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                              <td colspan="3"><p>&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" Width="67px" ForeColor="Red" />&nbsp;&nbsp;WARNING!
                                  Gallery and all photos in gallery are DELETED.<p></td>
                            </tr>
                          </table>
                        </td>
                        <td style="height: 149px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="height: 149px">
                        </td>
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
                <tr>
                  <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td>
                          <asp:ObjectDataSource ID="ODS_GalleryListAll" runat="server" SelectMethod="GetGalleryList"
        TypeName="DAL_Gallery"></asp:ObjectDataSource>
    
    <asp:XmlDataSource ID="XDS_photoStatus" runat="server" DataFile="~/App_Data/photoStatus.xml">
    </asp:XmlDataSource></tr>
                  </table></td>
                </tr>
              </table>
                        </td>
                        <td style="height: 149px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="height: 149px">
                        </td>
                      </tr>
                    </table>
							

   	
   	
						</div>
				  	</div>
				</div>
			</div>
            <!--end container-->
        </div></section>
	</form>
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
