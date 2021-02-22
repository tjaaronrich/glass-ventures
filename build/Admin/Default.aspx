<%@ Page Language="VB" debug="true" MasterPageFile="Site.Master" AutoEventWireup="false" CodeFile="VB/index.aspx.vb" Inherits="Index" validaterequest="false"  %>



<asp:Content ID="headContentBefore" ContentPlaceHolderID="headContentBefore" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="msapplication-tap-highlight" content="no">

    <meta name="description" content="Aaron Rich Marketing CMS Dashboard">

    <title>Aaron Rich Marketing CMS Dashboard</title>

</asp:Content>



<asp:Content ID="headContentAfter" ContentPlaceHolderID="headContentAfter" runat="server">

</asp:Content>

 

 





  

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



	<!-- START CONTENT -->

	<section id="content">

		<!--start container-->

		<div class="container">

			<!--card stats start-->

			<div id="card-stats">

				<div class="row">

					<div class="col s12">

						<div class="card">

							<div class="card-content center">

								<h4 style="text-align: left;">Welcome to the CMS!</h4>

								<p style="text-align: left;">Here are some links to help you get started:</p>

								<p>&nbsp;</p>

								<div class="row">

									<div class="col s12 m4">

										<h5 style="text-align: left;">Get Started</h5>

										<p style="text-align: left;"><a href="pages">Edit pages</a></p>

									</div>

									<div class="col s12 m4">

										<h5 style="text-align: left;">Next Steps</h5>

										<p style="text-align: left; margin-bottom: 5px;"><a href="/admin/newsAdd.aspx">Write your first blog post</a></p>

										<p style="text-align: left;"><a href="/">View your site</a></p>

									</div>

									<div class="col s12 m4">

										<h5 style="text-align: left;">More Actions</h5>

										<p style="text-align: left; margin-bottom: 5px;"><a href="/admin/users.aspx">Manage Users</a></p>

										<p style="text-align: left;"><a href="/admin/navigationedit.aspx">Edit site navigation menu</a></p>

									</div>

								</div>

								<p>&nbsp;</p>

							</div>

						</div>

					</div>

				</div>

			</div>

			<!--card stats end-->





			<!-- ecommerce product start-->

			<div id="ecommerce-product">

			  <div class="row">

				<div class="col s12 m6 <%= DAL_Activity.GetStatusHome() %>">

				  <div class="card">

					<div class="card-content center">

					  <h6 class="card-title font-weight-400 mb-0" style="text-align: left;">Recent Activity</h6>

					</div>

					<div class="card-action border-non center">

					<table>

						<%= recentActivity %>

					</table>

					</div>



				  </div>

				</div>

				<div class="col s12 m6">

				  <div class="card">

					<div class="card-content center">

					  <h6 class="card-title font-weight-400 mb-0" style="text-align: left;">CMS Events & News</h6>



					</div>

					<%= CmsEvents %>

				  </div>

				</div>

			  </div>

			  <!-- ecommerce product end-->





			  <!-- //////////////////////////////////////////////////////////////////////////// -->

			</div>

			<!--end container-->

		</div>

	</section>

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

  

</asp:content>

