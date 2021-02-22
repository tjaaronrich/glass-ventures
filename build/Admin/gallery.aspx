<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/ADMIN_Gallery.aspx.vb" Inherits="ADMIN_Gallery" %>
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
        <!-- START CONTENT -->
        <section id="content">
          <!--start container-->
          <div class="container">
            <!--card stats start-->
            <!--card stats end-->


			<div class="row">
				<div class="col s12 m12">
			  		<div class="card">
						<div class="card-content center">
						<h4 style="text-align: left;">Gallery</h4>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td>
                          <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="170" valign="top"><p>Image #1 Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtName1" runat="server" Width="200px"></asp:TextBox></td>
                              <td><p></p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Choose Image #1:</p></td>
                              <td><asp:FileUpload ID="FileUpload1" runat="server" Width="343px" /></td>
                              <td><p> </p></td>
                            </tr>
                            <tr>
                              <td valign="top" style="height: 22px"><p>Place #1 in Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery1" runat="server" 
                                      datasourceid="ODS_GalleryList" DataTextField="pgName" DataValueField="pgID">
                                  </asp:DropDownList></td>
                              <td style="height: 22px"><p> </p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Image #2 Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtName2" runat="server" Width="200px"></asp:TextBox></td>
                              <td><p></p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Choose Image #2:</p></td>
                              <td><asp:FileUpload ID="FileUpload2" runat="server" Width="343px" /></td>
                              <td><p> </p></td>
                            </tr>
                            <tr>
                              <td valign="top" style="height: 22px"><p>Place #2 in Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery2" runat="server" 
                                      datasourceid="ODS_GalleryList" DataTextField="pgName" DataValueField="pgID">
                                  </asp:DropDownList></td>
                              <td style="height: 22px"><p> </p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Image #3 Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtName3" runat="server" Width="200px"></asp:TextBox></td>
                              <td><p></p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Choose Image #3:</p></td>
                              <td><asp:FileUpload ID="FileUpload3" runat="server" Width="343px" /></td>
                              <td><p> </p></td>
                            </tr>
                            <tr>
                              <td valign="top" style="height: 22px"><p>Place #3 in Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery3" runat="server" 
                                      datasourceid="ODS_GalleryList" DataTextField="pgName" DataValueField="pgID">
                                  </asp:DropDownList></td>
                              <td style="height: 22px"><p> </p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Image #4 Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtName4" runat="server" Width="200px"></asp:TextBox></td>
                              <td><p></p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Choose Image #4:</p></td>
                              <td><asp:FileUpload ID="FileUpload4" runat="server" Width="343px" /></td>
                              <td><p> </p></td>
                            </tr>
                            <tr>
                              <td valign="top" style="height: 22px"><p>Place #4 in Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery4" runat="server" 
                                      datasourceid="ODS_GalleryList" DataTextField="pgName" DataValueField="pgID">
                                  </asp:DropDownList></td>
                              <td style="height: 22px"><p> </p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="170" valign="top"><p>Image #5 Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtName5" runat="server" Width="200px"></asp:TextBox></td>
                              <td><p></p></td>
                            </tr>
                            <tr>
                              <td valign="top"><p>Choose Image #5:</p></td>
                              <td><asp:FileUpload ID="FileUpload5" runat="server" Width="343px" /></td>
                              <td><p> </p></td>
                            </tr>
                            <tr>
                              <td valign="top" style="height: 22px"><p>Place #5 in Gallery:</p></td>
                              <td style="height: 22px">
                                  <asp:DropDownList ID="ddlGallery5" runat="server" 
                                      datasourceid="ODS_GalleryList" DataTextField="pgName" DataValueField="pgID">
                                  </asp:DropDownList></td>
                              <td style="height: 22px"><p> </p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Upload" /></td>
                            </tr>
                          </table>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                          <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="170" valign="top"><p>New Gallery Name:</p></td>
                              <td width="250"><asp:TextBox ID="txtNewGallery" runat="server" Width="200px"></asp:TextBox></td>
                              <td><p></p></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2"><asp:Button ID="btnAddGallery" runat="server" Text="Add Gallery" /></td>
                            </tr>
                            <tr>
                              <td>&nbsp;</td>
                              <td colspan="2">
                                  <br><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="GalleryMaintenance.aspx" Font-Name="Arial" Font-Size="11px">Gallery Maintenance</asp:HyperLink></td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                    </table>
							<asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
						</div>
					</div>
				</div>
				<div class="col s12 m12">
			  		<div class="card">
						<div class="card-content center">
						
													<asp:GridView ID="GridView1" PageSize="20" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Gallery" DataKeyNames="photoID" 
                                width="100%"
                                CellPadding="5" 
                                Font-Names="Arial" 
                                Font-Size="11px" 
                                PagerSettings-Mode="NumericFirstLast"
                                BorderStyle="Solid" 
                                Border="1"
                                BorderColor="#CCCCCC">
                            <Headerstyle BackColor="#666666" ForeColor="White" Font-Size="11px" HorizontalAlign="Left" Font-Bold="True" Font-Names="Arial"></Headerstyle>
                            <AlternatingRowStyle BackColor="#E5E5E5" ForeColor="Black" Font-Size="11px" HorizontalAlign="Left" Font-Names="Arial"></AlternatingRowStyle>
                            <PAGERSTYLE backcolor="#CCCCCC" forecolor="Black" Font-Size="10px" Font-Names="arial" horizontalalign="Left"></PAGERSTYLE>
                            <Columns>
                            <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True">
                              <ControlStyle ForeColor="Black" />
                            </asp:CommandField>
                            <asp:BoundField DataField="photoID" HeaderText="Photo ID" ReadOnly="True"
                                SortExpression="photoID" visible="false" />
                            <asp:BoundField DataField="photoName" HeaderText="Image Name" SortExpression="photoName" />
                            <asp:HyperLinkField DataNavigateUrlFields="ImageFile" DataNavigateUrlFormatString="../Documents/Gallery/BigGallery/{0}" HeaderText="Image Link"
                                Text="View" Target="_blank" />
                            <asp:BoundField DataField="pgName" HeaderText="Gallery Name" SortExpression="pgName" Visible="false" />
                            <asp:TemplateField HeaderText="Gallery" SortExpression="pgName">
                              <EditItemTemplate> &nbsp;
                                  <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ODS_GalleryListAll"
                                    DataTextField="pgName" DataValueField="pgName" SelectedValue='<%# Bind("pgName") %>'> </asp:DropDownList>
                              </EditItemTemplate>
                              <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("pgName") %>'></asp:Label>
                              </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ImageFile" HeaderText="Image File" ReadOnly="True"
                                SortExpression="ImageFile" />
                            <asp:TemplateField HeaderText="Status" SortExpression="photoStatus">
                              <EditItemTemplate> &nbsp;
                                  <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="XDS_photoStatus"
                                    DataTextField="statusName" DataValueField="statusLevel" SelectedValue='<%# Bind("photoStatus") %>'> </asp:DropDownList>
                              </EditItemTemplate>
                              <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("photoStatus") %>'></asp:Label>
                              </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                          </asp:GridView>
						
						
						
						</div>
				  	</div>
				</div>
			</div>
            <!--end container-->
        </div></section>
        <!-- END CONTENT -->
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
