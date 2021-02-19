<%@ Page Language="VB" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/Pages.aspx.vb" Inherits="PagesAdd" validaterequest="false" %>

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

	<Style>
		.switch label .lever:before,.switch label .lever:after {
			background-color: #16a6b6!important;
		}
		.switch *{
			background: transparent;
		}
		#MainContent_editor {
			/** Setting height is also important, otherwise editor wont showup**/
			height: 300px;
		}
		.k-colorpalette .k-item {
			padding: 0;
		}
		.k-editor
		{
			min-height: 700px;
		}
	</Style>

</asp:Content>

 

 

 

 

 

 

 

 

 



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<!-- START CONTENT -->

	<form runat="server" style="overflow: hidden">

        <section id="">

	  		<!--start container-->

          	<div class="container">

				<!--card stats start-->

				<div id="card-stats">

              		<div class="row">

                		<div class="col s12">

               		

							<div id="example">

								<div class="col s12">

									<div>

										<asp:Label ID="lblftbNum" runat="server" Text="Label" Visible="False"></asp:Label>

									</div>							

<!--
									<div class="col s12">

										<div class="demo-section k-content">

											<ul class="fieldlist">

												<li class="culture">

													<h5>Page Name:</h5>

													<asp:TextBox ID="txtpageName" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>



												</li>

											</ul>

										</div>

									</div>
-->

							

							

							





									<!--<div class="col-xs-12">

										<div class="demo-section k-content">

											<ul class="fieldlist">

												<li class="culture">

													<label for="culture">Meta Keywords:</label>

													<asp:TextBox ID="txtpageKeywords" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>



												</li>

											</ul>

										</div>

									</div>-->

							





									<div class="col s12">

										<div class="demo-section k-content" style="padding: 0;">

											<ul class="fieldlist">

												<li class="culture" style="padding: 0;">
					
													<iframe id="myiframe" src="https://cmseditor.aaronrich.com/" style="width: 100%; height: 80vh; border: 0;">
													
													</iframe>
													
													<script language="javascript">
														var iframe = document.getElementById('myiframe');
															iframe.src = iframe.src + window.location.search + "=" + "glassventures" + "=" + "50.62.209.111";
													</script>

													
													
<!--													This is the old text editor.  -->
													
													
													
													<%-- Switch --%>
<!--
													  <div class="switch">
														<label>
														  RichText Editor
														  <input id="editSelect" type="checkbox">
														  <span class="lever"></span>
														  Code Editor
														</label>
													  </div>
-->
													
								
<!--
													<div class="rteEditor">
														<span style="display: none;">
														<%--<RTE:Editor runat="server" ID="Editor1RTE" ContentCss="../CSS/richtext.css" Width="100%" Height="800px"/>--%></span>
														<textarea style="display: none;" id="aceeditor" runat="server"></textarea>
														<textarea style="display: none;" id="keditorp" runat="server"></textarea>
														<div class="">
															<h5>Content:</h5>

															<textarea style="" id="keditor" runat="server"></textarea>
															
														</div>
													</div>
-->
													
<!--
													<div class="container codeEditor" style="">
														<div class="panel panel-default">
															<div class="panel-heading">
																 <h3 class="panel-title">Editor</h3>
															</div>
															<div class="panel-body">
																<div id="editor" runat="server">


																</div>
															</div>
														</div>
														<div class="text-center"></div>
													</div>
-->
													
													
													<!--<textarea id="editor1" runat="server" rows="10" cols="30" style="height:440px" aria-label="editor">



													</textarea>-->
													
													
													
<!--													End of the old editor. -->

												</li>

											</ul>

										</div>

									</div>

							

							

							

							

							

							

							

								</div>

						

						

<!--
								<div class="col s3">

						

						

						

						

									<div class="demo-section k-content">

										<ul class="fieldlist">

											<li class="culture">

												<h5>Main Image</h5>

												<asp:Image  ID="thumb0" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

												<%= HeaderImageValue %>

												<asp:Label ID="lblImageFile0" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

												<asp:FileUpload ID="FileUpload0" runat="server"  />

											</li>

										</ul>

									</div>

						

									<div class="demo-section k-content">

										<ul class="fieldlist">

											<li class="culture">

												<h5>Image Text:</h5>

												<asp:TextBox ID="txtpageHeaderImageText" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>

											</li>

										</ul>

									</div>



									<div class="demo-section k-content">

										<ul class="fieldlist">

											<li class="culture">

												<h5>Meta Title:</h5>

												<asp:TextBox ID="txtpageMetaTitle" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>

											</li>

										</ul>

									</div>



									<div class="demo-section k-content">

										<ul class="fieldlist">

											<li class="culture">

												<h5>Meta Description:</h5>

												<asp:TextBox ID="txtpageDescription" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>

											</li>

										</ul>

									</div>
-->

									

	

							  









									<!--<div class="x_panel tile overflow_hidden">

										<div class="x_title">

										  <h2>Thumbnail #1</h2>

										  <ul class="nav navbar-right panel_toolbox">

											<li style="float:right;"><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>

											</li>



										  </ul>

										  <div class="clearfix"></div>

										</div>

										<div class="x_content" style="display: block;">

											<asp:Image  ID="thumb1" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

											<asp:Label ID="lblImageFile1" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

											<asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />

										</div>

									  </div>

									<div class="x_panel tile overflow_hidden">

										<div class="x_title">

										  <h2>Thumbnail #2</h2>

										  <ul class="nav navbar-right panel_toolbox">

											<li style="float:right;"><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>

											</li>



										  </ul>

										  <div class="clearfix"></div>

										</div>

										<div class="x_content" style="display: block;">

											<asp:Image  ID="thumb2" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

											<asp:Label ID="lblImageFile2" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

											<asp:FileUpload ID="FileUpload2" runat="server" Width="350px" />

										</div>

									  </div>

									<div class="x_panel tile overflow_hidden">

										<div class="x_title">

										  <h2>Thumbnail #3</h2>

										  <ul class="nav navbar-right panel_toolbox">

											<li style="float:right;"><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>

											</li>



										  </ul>

										  <div class="clearfix"></div>

										</div>

										<div class="x_content" style="display: block;">

											<asp:Image  ID="thumb3" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

											<asp:Label ID="lblImageFile3" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

											<asp:FileUpload ID="FileUpload3" runat="server" Width="350px" />

										</div>

									  </div>

									<div class="x_panel tile overflow_hidden">

										<div class="x_title">

										  <h2>Thumbnail #4</h2>

										  <ul class="nav navbar-right panel_toolbox">

											<li style="float:right;"><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>

											</li>



										  </ul>

										  <div class="clearfix"></div>

										</div>

										<div class="x_content" style="display: block;">

											<asp:Image  ID="thumb4" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

											<asp:Label ID="lblImageFile4" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

											<asp:FileUpload ID="FileUpload4" runat="server" Width="350px" />

										</div>

									  </div>

									<div class="x_panel tile overflow_hidden">

										<div class="x_title">

										  <h2>Thumbnail #5</h2>

										  <ul class="nav navbar-right panel_toolbox">

											<li style="float:right;"><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>

											</li>



										  </ul>

										  <div class="clearfix"></div>

										</div>

										<div class="x_content" style="display: block;">

											<asp:Image  ID="thumb5" runat="server" Width="100" alt="current image" Visible="false"></asp:Image>

											<asp:Label ID="lblImageFile5" runat="server" Font-Name="Arial" Font-Size="10px" visible="false"></asp:Label>

											<asp:FileUpload ID="FileUpload5" runat="server" Width="350px" />

										</div>

									  </div>-->







<!--								</div>-->

						

						

								<div class="col s12">





									<!--<div class="col-xs-12">

										<div class="demo-section k-content">

											<ul class="fieldlist">

												<li class="culture">

													<label for="culture">Title:</label>

													<asp:TextBox ID="txtpageTitle" runat="server" CssClass="k-textbox" Width="100%" ></asp:TextBox>



												</li>

											</ul>

										</div>

									</div>-->







							







<!--
									<div class="col s12">

										<asp:LinkButton ID="SaveButton" runat="server" OnClientClick="updateContent();" CssClass="waves-effect waves-light btn btn-large  box-shadow btn-opt1" Text="Add Item" />
										
										
										
										
										<a onClick="updateContent()">Test</a>


										<br />

										<%= strError %>

										<asp:Label ID="guidLabel" runat="server" Text=""  style="position: absolute;visibility: hidden;width: 0;height: 0;overflow: hidden;"></asp:Label>

										<asp:Label ID="lblErrorMsg" runat="server" Width="350px"></asp:Label>

										<asp:ObjectDataSource ID="ODS_NewsFTB" runat="server" DataObjectTypeName="PC_NewsFTB" DeleteMethod="DelNews" SelectMethod="GetAllNews" TypeName="DAL_NewsFTB">

											<SelectParameters>

												<asp:Parameter Name="NewsStatus" Type="String" />

											</SelectParameters>

										</asp:ObjectDataSource>



										<asp:XmlDataSource ID="XDS_Status" runat="server" DataFile="~/App_Data/NewsFTBStatus.xml"></asp:XmlDataSource>

										<asp:XmlDataSource ID="XDS_Featured" runat="server" DataFile="~/App_Data/FeaturedStatus.xml"></asp:XmlDataSource>



									</div>
-->





                        

        						</div>

                			</div>

                		</div>

              		</div>

            	</div>

            	<!--card stats end-->

            	<!--end container-->

        	</div>

		</section>

	</form>

	<!-- END CONTENT -->

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
	  <script src="https://pagecdn.io/lib/ace/1.4.5/ace.js" integrity="sha256-5Xkhn3k/1rbXB+Q/DX/2RuAtaB4dRRyQvMs83prFjpM=" crossorigin="anonymous"></script>


	

  

</asp:content>