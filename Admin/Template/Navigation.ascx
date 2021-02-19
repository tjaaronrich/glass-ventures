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
        <%--<div id="m1" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:0px; margin-top:18px">
            <a href="ADMIN_Testimonials.aspx" onMouseOver="mopen('m1')">Testimonials</a>--%>
            
       	</div>
    </li>

    <li><p style="margin-left:30px; margin-top:5px"><a href="#" onMouseOver="mopen('m5')">About Us</a></p>
        <div id="m5" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()" 
            style="margin-left:15px; margin-top:18px">
            <a href="ADMIN_company-info.aspx">Company Info</a>
            <a href="ADMIN_testimonials.aspx">Testimonials</a>
            
        	</div>
    </li>
    <%--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_owner.aspx" onMouseOver="mopen('m2')">Owner Services</a></p>
        <div id="m2" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-2000px; margin-top:18px">
            
        	</div>
    </li>--%>
    <%--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_staff.aspx" onMouseOver="mopen('m3')">Owner Info</a></p>
        <div id="m3" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-2000px; margin-top:18px">
            
        	</div>
    </li>--%>

     <li><p style="margin-left:30px; margin-top:5px"><a href="#" onMouseOver="mopen('m6')">Services</a></p>
        <div id="m6" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()" 
            style="margin-left:15px; margin-top:18px">
            <a href="ADMIN_residential.aspx">Residential</a>
            <a href="ADMIN_commercial.aspx">Commercial</a>
            <a href="ADMIN_renovations.aspx">Renovations</a>
            <a href="ADMIN_tile-deck.aspx">Tile & Deck</a>
            <a href="ADMIN_water-features.aspx">Water Features</a>
            
        	</div>
    </li>
     <!--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Gallery.aspx" onMouseOver="mopen('m5')">Gallery</a></p>
        <div id="m5" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()" 
            style="margin-left:15px; margin-top:18px">
            <a href="ADMIN_events.aspx">Events</a>
            <a href="ADMIN_gallery.aspx">Gallery</a>
            <a href="ADMIN_links.aspx">Links</a>
            <a href="ADMIN_faqs.aspx">FAQs</a>
            <a href="ADMIN_newsletters.aspx">Newsletter</a>
            
        	</div>
    </li>-->
     <!--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_consignment.aspx" onMouseOver="mopen('m7')">Consignment</a></p>
        <div id="m7" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()" 
            style="margin-left:15px; margin-top:18px">
            <a href="ADMIN_events.aspx">Events</a>
            <a href="ADMIN_gallery.aspx">Gallery</a>
            <a href="ADMIN_links.aspx">Links</a>
            <a href="ADMIN_faqs.aspx">FAQs</a>
            <a href="ADMIN_newsletters.aspx">Newsletter</a>
            
        	</div>
    </li>-->
     <li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_news.aspx" onMouseOver="mopen('m8')">Blogs</a></p>
        <div id="m8" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()" 
            style="margin-left:15px; margin-top:18px">
            <!--<a href="ADMIN_events.aspx">Events</a>
            <a href="ADMIN_gallery.aspx">Gallery</a>
            <a href="ADMIN_links.aspx">Links</a>
            <a href="ADMIN_faqs.aspx">FAQs</a>
            <a href="ADMIN_newsletters.aspx">Newsletter</a>-->
            
        	</div>
    </li>
     <!--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Parks-Campground.aspx" onMouseOver="mopen('m9')">Parks & Campground</a></p>
        <div id="m9" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()" 
            style="margin-left:15px; margin-top:18px">
            <a href="ADMIN_events.aspx">Events</a>
            <a href="ADMIN_gallery.aspx">Gallery</a>
            <a href="ADMIN_links.aspx">Links</a>
            <a href="ADMIN_faqs.aspx">FAQs</a>
            <a href="ADMIN_newsletters.aspx">Newsletter</a>
            
        	</div>
    </li>-->
    <%--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_News.aspx" onMouseOver="mopen('m6')">Blog</a></p>
        <div id="m6" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-5000px; margin-top:18px">
            
        	</div>
    </li>--%>
    <%--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Subcontractors.aspx" onMouseOver="mopen('m7')">Subcontractors</a></p>
        <div id="m7" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-5000px; margin-top:18px">
        </div>
    </li>--%>
    <li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Users.aspx" onMouseOver="mopen('m10')">Users</a></p>
        <div id="m10" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-5000px; margin-top:18px">
        </div>
    </li>
    <%--<li><p style="margin-left:30px; margin-top:5px"><a href="ADMIN_Contacts.aspx" onMouseOver="mopen('m9')" target="_blank">Contacts</a></p>
        <div id="m9" 
            onmouseover="mcancelclosetime()" 
            onmouseout="mclosetime()"
            style="margin-left:-5000px; margin-top:18px">
        </div>
    </li>--%>
</ul>
      

              </td>
            </tr>
          </table>