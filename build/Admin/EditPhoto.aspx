<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/ADMIN_EditPhoto.aspx.vb" Inherits="ADMIN_EditPhoto" %>
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
