
$(document).ready(function() { 
	$( "#userName" ).html( FullName );
	$( "#userNameMenu" ).html( FullName );
	$( "#topNavigation_logout" ).attr( 'onserverclick','btnSubmit_ServerClick' );
	
	if (ImageFile != "")
	{
		$( ".profile_pic" ).append('<img id="profilePic"  alt="..." class="img-circle profile_img">');
		$( "#profilePic" ).attr( 'src', '/Documents/Accounts/Thumbs/' + ImageFile );
		$( "#profilePic2" ).attr( 'src', '/Documents/Accounts/Thumbs/' + ImageFile );
	}
	else{
		$( "#profilePic" ).attr( 'style', 'visibility:hidden;position:absolute;' )
		$( ".profile_info" ).attr( 'style', 'float:none;text-align:center;width:100%;' );
		$( "#profilePic2" ).attr( 'style', 'visibility:hidden;position:absolute;' );
	}
	
	if (accesslevel == '2')
	{
		$( "#userType" ).html( "Owner" );
		$( ".menu-accesslevel" ).append( "<li><a class='' href='your-owner-listing.aspx'>Your Listings</a></li>" );
		$( ".menu-accesslevel" ).append( "<li><a class='' href='Vendor.aspx'>Vendors List</a></li>" );
		
	} 
	else if (accesslevel == '3') 
	{
		$( "#userType" ).html( "Vendor" );
		$( ".menu-accesslevel" ).append( "<li><a class='' href='your-vendor-listing.aspx'>Your Listings</a></li>" );
	}
	else if (accesslevel == '4') 
	{
		$( "#userType" ).html( "Attraction Host" );
		$( ".menu-accesslevel" ).append( "<li><a class='' href='your-attraction-listing.aspx'>Your Listings</a></li>" );
	}
	else if (accesslevel == '1') 
	{
		$( "#userType" ).html( "Admin" );
	}
});


function clearSession()
{
	alert("sdf");
	var xmlVar = new XMLHttpRequest();  

  	xmlVar .open("GET", "/webservices/mapservice.asmx?GetAllActiveSites", false); 

  	xmlVar .send(null);
	
}