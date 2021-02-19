<%@ Page Language="VB" debug="true" AutoEventWireup="false"  %>
     <script src="/plugins/kendo/js/jquery.min.js"></script>
    <script src="/plugins/kendo/js/kendo.all.min.js"></script>
    <script type="text/javascript">
        var accesslevel = '<%= Session("accesslevel").ToString().ToLower() %>';
		var FullName = '<%= Session("FullName").ToString() %>';
			alert(FullName);
		$(document).ready(function() { 
			$( "#userName" ).html( FullName );
			$( "#userNameMenu" ).html( FullName );
			if (accesslevel == '2')
			{
				$( "#userType" ).html( "Owner" );
				$( ".menu-accesslevel" ).append( "<li><a class='' href='your-listing.aspx'>Your Owner Listing</a></li>" );
			} 
			else if (accesslevel == '3') 
			{
				$( "#userType" ).html( "Vendor" );
				$( ".menu-accesslevel" ).append( "<li><a class='' href='your-listing.aspx'>Your Vendor Listing</a></li>" );
			}
			else if (accesslevel == '4') 
			{
				$( "#userType" ).html( "Attraction Host" );
			}
		});
    </script>  