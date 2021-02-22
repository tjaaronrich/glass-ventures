<script language="javascript">
// Copyright 2006-2007 javascript-array.com

var timeout	= 500;
var closetimer	= 0;
var ddmenuitem	= 0;

// open hidden layer
function mopen(id)
{	
	// cancel close timer
	mcancelclosetime();

	// close old layer
	if(ddmenuitem) ddmenuitem.style.visibility = 'hidden';

	// get new layer and show it
	ddmenuitem = document.getElementById(id);
	ddmenuitem.style.visibility = 'visible';

}
// close showed layer
function mclose()
{
	if(ddmenuitem) ddmenuitem.style.visibility = 'hidden';
}

// go close timer
function mclosetime()
{
	closetimer = window.setTimeout(mclose, timeout);
}

// cancel close timer
function mcancelclosetime()
{
	if(closetimer)
	{
		window.clearTimeout(closetimer);
		closetimer = null;
	}
}

// close layer when click-out
document.onclick = mclose;
</script>
<table width="100%" border="0" align="Left" cellpadding="0" cellspacing="0">
            <tr>
              <td>

<ul id="sddm" style="margin-left:0px">
    <li><p style="margin-left:30px; margin-top:5px"><a href="Default.aspx" onMouseOver="mopen('m1')">Home</a></p>
        <div id="m1" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">
                <a href="ADMIN_Banner.aspx">Slideshow</a>
                <a href="ADMIN_HomeJobSeekers.aspx">Job Seekers</a>
                <a href="ADMIN_HomeEmployers.aspx">Employers</a>
                <a href="ADMIN_HomeWelcome.aspx">Welcome</a>
                <a href="ADMIN_ResourceLinks.aspx">Resource Room</a>
                <a href="Reserve1.aspx">Reserve 1</a>
                <a href="Reserve2.aspx">Reserve 2</a>
                    	</div>
    </li>

  <li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_JSEmployment" onMouseOver="mopen('m2')">Job Seekers</a></p>
        <div id="m2" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">            
             			                     <a href="ADMIN_JSEmployment.aspx">Employment Services</a>
                                            <a href="ADMIN_JSHotJobs.aspx">Hiring Events</a>
                                            <a href="ADMIN_JSHotJobs2.aspx">Hot Jobs</a>
                                            <%--<a href="ADMIN_Jobs.aspx">Hot Jobs List</a>--%>
                                            <a href="ADMIN_FileUpload.aspx">Hot Jobs Upload</a>
                                            <a href="ADMIN_JSjobseeker.aspx">Training Services</a>
                                            <a href="ADMIN_JSReemployment.aspx">Reemployment</a>
                                            <a href="ADMIN_JSSpecial.aspx">Special Programs</a>
                                            <a href="ADMIN_JSpublic.aspx">Public Assistance</a>
                                            <%--<a href="ADMIN_JSTargeted.aspx">Targeted Occupations</a>--%>
         
            </div>
    </li>
    
  <li><p style="margin-left:30px; margin-top:5px"><a href="Admin_EResources.aspx" onMouseOver="mopen('m3')">Employers</a></p>
        <div id="m3" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">            
             			                     <a href="Admin_EResources.aspx">Free Business Services/Resources Available</a>
                                            <a href="Admin_Etraining.aspx">Training Programs & Incentives</a>
                                            <a href="Admin_eHiring.aspx">Hiring Special Populations</a>
         
            </div>
    </li>
    
    <li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Projects.aspx" onMouseOver="mopen('m4')">Special Projects</a></p>
        <div id="m4" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">        	</div>
    </li>
    
    <li><p style="margin-left:30px; margin-top:5px"><a href="Admin_News.aspx" onMouseOver="mopen('m5')">Newsroom</a></p>
        <div id="m5" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">
			<a href="Admin_News.aspx">News & Announcements</a>
			<a href="Admin_Events.aspx">Events</a>
			<a href="Admin_Newsletters.aspx">RFPs & Notices</a>
        	</div>
    </li>
    
  <li><p style="margin-left:30px; margin-top:5px"><a href="Admin_AUServices.aspx" onMouseOver="mopen('m6')">About Us</a></p>
        <div id="m6" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">            
                                            <a href="Admin_AUServices.aspx">Services by County</a>
                                            <a href="Admin_AUBoard.aspx">Board</a>
                                            <a href="Admin_AUJob.aspx">Job Center</a>
                                            <a href="ADMIN_Links.aspx">Helpful Links</a> 
            </div>
    </li>
    
  <li><p style="margin-left:30px; margin-top:5px"><a href="Reserve1.aspx" onMouseOver="mopen('m7')">Portal</a></p>
        <div id="m7" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:15px; margin-top:18px">            
			<a href="Admin_PortalLinks.aspx">Portal Links</a>
			<a href="Admin_PortalDocuments.aspx">Portal Documents</a>
			<a href="Admin_PortalStatus.aspx">Service Status</a>
			<a href="Admin_Notice.aspx">Notice</a>
            </div> 
    </li>

    <li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Users.aspx" onMouseOver="mopen('m8')">Users</a></p>
        <div id="m8" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-5000px; margin-top:18px">        </div>
    </li>
</ul>
      

              </td>
            </tr>
          </table>