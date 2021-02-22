
    

        
<script type="text/javascript">
	var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
	var srcImageFile = '/Documents/Accounts/Thumbs/' + ImageFile;
	var headerName = ('<%= Session("FullName") %>').substring(0,1);
		if(!ImageFile == "")
		{
			$(".profile-img-header").attr("src",srcImageFile);
			headerName = '';
		} else 
		{
			$(".profile-img-header").attr("src","/Graphics/fill.png");
			headerName = FullName.substring(0,1)
		}
	$( document ).ready(function() {
		
		if(!ImageFile == "")
		{
			$(".profile-img-header").attr("src",srcImageFile);
			headerName = '';
		} else 
		{
			$(".profile-img-header").attr("src","/Graphics/fill.png");
			headerName = FullName.substring(0,1)
		}
	});
</script>  
    
                            
<!-- START HEADER -->
    <header id="header" class="page-topbar">
      <!-- start header nav-->
      <div class="navbar-fixed">
        <nav class="navbar-color">
          <div class="nav-wrapper">
            <ul class="left">
              <li>
                <h1 class="logo-wrapper">
                  <a href="default" class="brand-logo darken-1">
                    <img src="/images/logo.png" alt="materialize logo" style="width: 50%;height: auto;/* margin-left: auto; */margin-right: auto;display: block;margin-top: -17px;">
                  </a>
                </h1>
              </li>
            </ul>
            
				<div class="header-search-wrapper hide-on-med-and-down">
					<form method="get" action="search">
				  		<i class="material-icons">search</i>
				  		<input type="text" name="Search" class="header-search-input z-depth-2" placeholder="Search">
            		</form>
				</div>
            <ul class="right hide-on-med-and-down">
              <li>
                <!--<a href="javascript:void(0);" class="waves-effect waves-block waves-light translation-button" data-activates="translation-dropdown">
                  <span class="flag-icon flag-icon-gb"></span>
                </a>
                <ul id="translation-dropdown" class="dropdown-content" style="white-space: nowrap; position: absolute; top: 64px; left: 1080.42px; display: none; opacity: 1;">
				  <li>
					<a href="#!" class="grey-text text-darken-1">
					  <i class="flag-icon flag-icon-gb"></i> English</a>
				  </li>
				  <li>
					<a href="#!" class="grey-text text-darken-1">
					  <i class="flag-icon flag-icon-fr"></i> French</a>
				  </li>
				  <li>
					<a href="#!" class="grey-text text-darken-1">
					  <i class="flag-icon flag-icon-cn"></i> Chinese</a>
				  </li>
				  <li>
					<a href="#!" class="grey-text text-darken-1">
					  <i class="flag-icon flag-icon-de"></i> German</a>
				  </li>
            	</ul>-->
              </li>
              <li>
                <a href="javascript:void(0);" class="waves-effect waves-block waves-light toggle-fullscreen">
                  <i class="material-icons">settings_overscan</i>
                </a>
              </li>
              <li>
                <!--<a href="javascript:void(0);" class="waves-effect waves-block waves-light notification-button" data-activates="notifications-dropdown">
                  <i class="material-icons">notifications_none
                    <small class="notification-badge pink accent-2">5</small>
                  </i>
                </a>
                <ul id="notifications-dropdown" class="dropdown-content">
              <li>
                <h6>NOTIFICATIONS
                  <span class="new badge">5</span>
                </h6>
              </li>
              <li class="divider"></li>
              <li>
                <a href="#!" class="grey-text text-darken-2">
                  <span class="material-icons icon-bg-circle cyan small">add_shopping_cart</span> A new order has been placed!</a>
                <time class="media-meta" datetime="2015-06-12T20:50:48+08:00">2 hours ago</time>
              </li>
              <li>
                <a href="#!" class="grey-text text-darken-2">
                  <span class="material-icons icon-bg-circle red small">stars</span> Completed the task</a>
                <time class="media-meta" datetime="2015-06-12T20:50:48+08:00">3 days ago</time>
              </li>
              <li>
                <a href="#!" class="grey-text text-darken-2">
                  <span class="material-icons icon-bg-circle teal small">settings</span> Settings updated</a>
                <time class="media-meta" datetime="2015-06-12T20:50:48+08:00">4 days ago</time>
              </li>
              <li>
                <a href="#!" class="grey-text text-darken-2">
                  <span class="material-icons icon-bg-circle deep-orange small">today</span> Director meeting started</a>
                <time class="media-meta" datetime="2015-06-12T20:50:48+08:00">6 days ago</time>
              </li>
              <li>
                <a href="#!" class="grey-text text-darken-2">
                  <span class="material-icons icon-bg-circle amber small">trending_up</span> Generate monthly report</a>
                <time class="media-meta" datetime="2015-06-12T20:50:48+08:00">1 week ago</time>
              </li>
            </ul>-->
              </li>
              <li>
                <a href="javascript:void(0);" class="waves-effect waves-block waves-light profile-button" data-activates="profile-dropdown">
                  <span class="avatar-status avatar-online">
                    <img class="profile-img-header" src="../../images/avatar/avatar-7.png" alt="avatar">
                    <div style="position: absolute;color: white;top: -8px;left: 28%;"><script>document.write(headerName);</script></div>
                    <i></i>
                  </span>
                </a><ul id="profile-dropdown" class="dropdown-content">
              <li>
                <a href="profile" class="grey-text text-darken-1">
                  <i class="material-icons">face</i> Profile</a>
              </li>
              <!--<li>
                <a href="#" class="grey-text text-darken-1">
                  <i class="material-icons">settings</i> Settings</a>
              </li>-->
              <li>
                <a href="support" class="grey-text text-darken-1">
                  <i class="material-icons">live_help</i> Help</a>
              </li>
              <li class="divider"></li>
              <!--<li>
                <a href="#" class="grey-text text-darken-1">
                  <i class="material-icons">lock_outline</i> Lock</a>
              </li>-->
              <li>
                <a href="logout" class="grey-text text-darken-1">
                  <i class="material-icons">keyboard_tab</i> Logout</a>
              </li>
            </ul>
              </li>
              <li>
                <a href="#" data-activates="chat-out" class="waves-effect waves-block waves-light chat-collapse">
                  <i class="material-icons">format_indent_increase</i>
                </a>
              </li>
            </ul>
            <!-- translation-button -->
            
            <!-- notifications-dropdown -->
            
            <!-- profile-dropdown -->
            
          </div>
        </nav>
      </div>
      <!-- end header nav-->
    </header>
    <!-- END HEADER -->