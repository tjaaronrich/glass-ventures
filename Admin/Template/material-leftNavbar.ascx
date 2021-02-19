
   <script type="text/javascript">
		var ImageFile = '<%= DAL_Account.GetImageByNum(Session("UserAcctNum").ToString()) %>';
   		var srcImageFile = '/Documents/Accounts/Thumbs/' + <%= Session("UserAcctNum").ToString() %> + '/' + ImageFile;
	   	$( document ).ready(function() {
			if(!ImageFile == "")
			{
				$(".profile-img").attr("src",srcImageFile);
			}
		});
    </script>  

       
       
       <!-- START LEFT SIDEBAR NAV-->
        <aside id="left-sidebar-nav">
          <ul id="slide-out" class="side-nav fixed leftside-navigation ps-container ps-active-y" style="transform: translateX(0%);">
            <!--<li class="user-details cyan darken-2">
              <div class="row">
                <div class="col col s4 m4 l4">
                  <img src="../../images/avatar/avatar-7.png" alt="" class="profile-img circle responsive-img valign profile-image" style="background-color: #d5d971;">
                </div>
                <div class="col col s8 m8 l8">
                  
                  <p id="userNameMenu" style="line-height: 1;" class="btn-flat dropdown-button waves-effect waves-light white-text profile-btn" href="#" data-activates="profile-dropdown-nav">John Doe<i class="mdi-navigation-arrow-drop-down right"></i></p><ul id="profile-dropdown-nav" class="dropdown-content" style="white-space: nowrap; position: absolute; top: 60px; left: 101.234px; display: none; opacity: 1;">
                    <li>
                      <a href="profile" class="grey-text text-darken-1">
                        <i class="material-icons">face</i> Profile</a>
                    </li>
                    <li>
                      <a href="support" class="grey-text text-darken-1">
                        <i class="material-icons">live_help</i> Help</a>
                    </li>
                    <li class="divider"></li>
                    <li>
                      <a href="logout" class="grey-text text-darken-1">
                        <i class="material-icons">keyboard_tab</i> Logout</a>
                    </li>
                  </ul>
                  <p id="userType" class="user-roal">Administrator</p>
                </div>
              </div>
            </li>-->
            <li class="no-padding">
              <ul class="collapsible" data-collapsible="accordion">
               
                <li class="bold">
                  <a href="default.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">dashboard</i>
                    <span class="nav-text">Dashboard</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="pages.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">pages</i>
                    <span class="nav-text">Pages</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="slider.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">slideshow</i>
                    <span class="nav-text">Slider</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="/admin/news.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">book</i>
                    <span class="nav-text">News/Blog</span>
                  </a>
                </li>
				  <li class="bold item-announcements">
                  <a href="newscategories" class="waves-effect waves-cyan">
                    <i class="material-icons">build</i>
                    <span class="nav-text">News Category Editor</span>
                  </a>
                </li>
				  
<!--
                <li class="bold">
                  <a href="/admin/announcements.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">event</i>
                    <span class="nav-text">Events</span>
                  </a>
                </li>
				  
				<li class="bold item-announcements">
                  <a href="categories" class="waves-effect waves-cyan">
                    <i class="material-icons">build</i>
                    <span class="nav-text">Event Category Editor</span>
                  </a>
                </li>
-->
<!--
                <li class="bold">
                  <a href="/admin/newsLetters.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">collections_bookmark</i>
                    <span class="nav-text">Newsletter</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="/admin/BiosMembers.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">people</i>
                    <span class="nav-text">Members</span>
                  </a>
                </li>
-->
				<li class="bold">
                  <a href="/admin/gallery.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">perm_media</i>
                    <span class="nav-text">Gallery</span>
                  </a>
                </li>
                <!--
				    <li class="bold">
                  <a href="calendar" class="waves-effect waves-cyan">
                    <i class="material-icons">event</i>
                    <span class="nav-text">Calendar</span>
                  </a>
                </li><li class="bold">
                  <a href="staff" class="waves-effect waves-cyan">
                    <i class="material-icons">portrait</i>
                    <span class="nav-text">Staff & Featured Clients</span>
                  </a>
                </li>
                -->
<!--
               <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">perm_media</i>
                    <span class="nav-text">Portal</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="newsletters">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Documents</span>
                        </a>
                      </li>
                      <li>
                        <a href="media-hover-effects.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Video Page</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
-->
                <!-- <li class="bold">
                  <a href="calendar" class="waves-effect waves-cyan">
                    <i class="material-icons">event</i>
                    <span class="nav-text">Calendar</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="announcements" class="waves-effect waves-cyan">
                    <i class="material-icons">announcement</i>
                    <span class="nav-text">Announcements</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="programs" class="waves-effect waves-cyan">
                    <i class="material-icons">developer_mode</i>
                    <span class="nav-text">Programs & Initiatives</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="links.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">insert_link</i>
                    <span class="nav-text">Links</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="faqs.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">question_answer</i>
                    <span class="nav-text">FAQs</span>
                  </a>
                </li>-->
<!--
                <li class="bold">
                  <a href="testimonials.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">textsms</i>
                    <span class="nav-text">Testimonials</span>
                  </a>
                </li>
-->
                <!--<li class="bold">
                  <a href="gallery" class="waves-effect waves-cyan">
                    <i class="material-icons">image</i>
                    <span class="nav-text">Gallery</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="menu" class="waves-effect waves-cyan">
                    <i class="material-icons">featured_play_list</i>
                    <span class="nav-text">Menu</span>
                  </a>
                </li>-->
                <li class="bold">
                  <a href="navigationedit.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">navigation</i>
                    <span class="nav-text">Navigation</span>
                  </a>
                </li>
<!--
                <li class="bold">
                  <a href="widgets.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">widgets</i>
                    <span class="nav-text">Widgets</span>
                  </a>
                </li>
-->
                <li class="bold">
                  <a href="users.aspx" class="waves-effect waves-cyan">
                    <i class="material-icons">account_circle</i>
                    <span class="nav-text">Users</span>
                  </a>
                </li>
			 	<!--<li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">settings</i>
                    <span class="nav-text">Theme Options</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="custom-javascript">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Custom Javascript</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">dashboard</i>
                    <span class="nav-text">Dashboard</span>
                  </a>
                  <div class="collapsible-body" style="display: none;">
                    <ul>
                      <li class="active">
                        <a href="dashboard-ecommerce.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>eCommerce</span>
                        </a>
                      </li>
                      <li>
                        <a href="index.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Analytics</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">dvr</i>
                    <span class="nav-text">Templates</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="../collapsible-menu/">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span> Collapsible Menu</span>
                        </a>
                      </li>
                      <li>
                        <a href="../semi-dark-menu/">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span> Semi Dark Menu</span>
                        </a>
                      </li>
                      <li>
                        <a href="../fixed-menu/">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span> Fixed Menu</span>
                        </a>
                      </li>
                      <li>
                        <a href="../overlay-menu/">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span> Overlay Menu</span>
                        </a>
                      </li>
                      <li>
                        <a href="../horizontal-menu/">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Horizontal Menu</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">web</i>
                    <span class="nav-text">Layouts</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="layout-light.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Light Layout</span>
                        </a>
                      </li>
                      <li>
                        <a href="layout-dark.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Dark Layout</span>
                        </a>
                      </li>
                      <li>
                        <a href="layout-semi-dark.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Semi Dark Layout</span>
                        </a>
                      </li>
                      <li>
                        <a href="layout-fixed-footer.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Fixed Footer</span>
                        </a>
                      </li>
                      <li>
                        <a href="layout-menu-native-scroll.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Menu Native Scroll</span>
                        </a>
                      </li>
                      <li>
                        <a href="layout-menu-collapsed.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Menu Collapsed</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">cast</i>
                    <span class="nav-text">Cards</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="cards-basic.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span> Basic</span>
                        </a>
                      </li>
                      <li>
                        <a href="cards-advance.html" class="waves-effect waves-cyan">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span class="nav-text">Advance</span>
                        </a>
                      </li>
                      <li>
                        <a href="cards-extended.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Extended</span>
                        </a>

                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a href="app-email.html" class="waves-effect waves-cyan">
                    <i class="material-icons">mail_outline</i>
                    <span class="nav-text">Mailbox</span>
                  </a>
                </li>
                <li class="bold">
                  <a href="app-calendar.html" class="waves-effect waves-cyan">
                    <i class="material-icons">today</i>
                    <span class="nav-text">Calender</span>
                  </a>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">invert_colors</i>
                    <span class="nav-text">CSS</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="css-typography.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Typography</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-color.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span class="nav-text">Color</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-grid.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span class="nav-text">Grid</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-helpers.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span class="nav-text">Helpers</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-media.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Media</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-pulse.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Pulse</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-sass.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Sass</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-shadow.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Shadow</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-animations.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Animations</span>
                        </a>
                      </li>
                      <li>
                        <a href="css-transitions.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Transition</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">photo_filter</i>
                    <span class="nav-text">Basic UI</span>
                  </a>
                  <div class="collapsible-body" style="display: none;">
                    <ul class="collapsible" data-collapsible="accordion">
                      <li class="bold">
                        <a class="collapsible-header waves-effect waves-cyan">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span class="nav-text">Buttons</span>
                        </a>
                        <div class="collapsible-body">
                          <ul class="collapsible" data-collapsible="accordion">
                            <li>
                              <a href="ui-basic-buttons.html">
                                <i class="material-icons">keyboard_arrow_right</i>
                                <span>Basic</span>
                              </a>
                            </li>
                            <li>
                              <a href="ui-extended-buttons.html">
                                <i class="material-icons">keyboard_arrow_right</i>
                                <span>Extended</span>
                              </a>
                            </li>
                          </ul>
                        </div>
                      </li>
                      <li>
                        <a href="ui-icons.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Icons</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-alerts.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Alerts</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-badges.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Badges</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-breadcrumbs.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Breadcrumbs</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-chips.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Chips</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-collections.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Collections</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-navbar.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Navbar</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-pagination.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Pagination</span>
                        </a>
                      </li>
                      <li>
                        <a href="ui-preloader.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Preloader</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">library_add</i>
                    <span class="nav-text">Advanced UI</span>
                  </a>
                  <div class="collapsible-body" style="display: none;">
                    <ul>
                      <li>
                        <a href="advance-ui-carousel.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Carousel</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-collapsibles.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Collapsible</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-toasts.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Toasts</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-tooltip.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Tooltip</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-dropdown.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Dropdown</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-feature-discovery.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Feature Discovery</span>
                        </a>
                      </li>
                      <li>
                        <a href="advanced-ui-media.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Media</span>
                        </a>
                      </li>
                      <li>
                        <a href="advanced-ui-modals.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Modals</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-scrollfire.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>ScrollFire</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-scrollspy.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Scrollspy</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-tabs.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Tabs</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-transitions.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Transitions</span>
                        </a>
                      </li>
                      <li>
                        <a href="advance-ui-waves.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Waves</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">add_to_queue</i>
                    <span class="nav-text">Extra Components</span>
                  </a>
                  <div class="collapsible-body" style="display: none; padding-top: 0px; margin-top: 0px; padding-bottom: 0px; margin-bottom: 0px;">
                    <ul>
                      <li>
                        <a href="extra-components-range-slider.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Range Slider</span>
                        </a>
                      </li>
                      <li>
                        <a href="extra-components-sweetalert.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>SweetAlert</span>
                        </a>
                      </li>
                      <li>
                        <a href="extra-components-nestable.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Shortable &amp; Nestable</span>
                        </a>
                      </li>
                      <li>
                        <a href="extra-components-translation.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Language Translation</span>
                        </a>
                      </li>
                      <li>
                        <a href="extra-components-highlight.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Highlight</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">border_all</i>
                    <span class="nav-text">Tables</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="table-basic.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Basic Tables</span>
                        </a>
                      </li>
                      <li>
                        <a href="table-data.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Data Tables</span>
                        </a>
                      </li>
                      <li>
                        <a href="table-jsgrid.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>jsGrid</span>
                        </a>
                      </li>
                      <li>
                        <a href="table-editable.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Editable Table</span>
                        </a>
                      </li>
                      <li>
                        <a href="table-floatThead.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>FloatThead</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">chrome_reader_mode</i>
                    <span class="nav-text">Forms</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="form-elements.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Form Elements</span>
                        </a>
                      </li>
                      <li>
                        <a href="form-layouts.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Form Layouts</span>
                        </a>
                      </li>
                      <li>
                        <a href="form-validation.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Form Validations</span>
                        </a>
                      </li>
                      <li>
                        <a href="form-masks.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Form Masks</span>
                        </a>
                      </li>
                      <li>
                        <a href="form-file-uploads.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>File Uploads</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">pages</i>
                    <span class="nav-text">Pages</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="page-contact.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Contact Page</span>
                        </a>
                      </li>
                      <li>
                        <a href="page-todo.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>ToDos</span>
                        </a>
                      </li>
                      <li>
                        <a href="page-blog-1.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Blog Type 1</span>
                        </a>
                      </li>
                      <li>
                        <a href="page-blog-2.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Blog Type 2</span>
                        </a>
                      </li>
                      <li>
                        <a href="page-404.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>404</span>
                        </a>
                      </li>
                      <li>
                        <a href="page-500.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>500</span>
                        </a>
                      </li>
                      <li>
                        <a href="page-blank.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Blank</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">add_shopping_cart</i>
                    <span class="nav-text">eCommers</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="eCommerce-products-page.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Products Page</span>
                        </a>
                      </li>
                      <li>
                        <a href="eCommerce-pricing.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Pricing Table</span>
                        </a>
                      </li>
                      <li>
                        <a href="eCommerce-invoice.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Invoice</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>-->
                <!--<li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">perm_media</i>
                    <span class="nav-text">Medias</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="media-gallary-page.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Gallery Page</span>
                        </a>
                      </li>
                      <li>
                        <a href="media-hover-effects.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Image Hover Effects</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">account_circle</i>
                    <span class="nav-text">User</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="user-profile-page.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>User Profile</span>
                        </a>
                      </li>
                      <li>
                        <a href="user-login.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Login</span>
                        </a>
                      </li>
                      <li>
                        <a href="user-register.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Register</span>
                        </a>
                      </li>
                      <li>
                        <a href="user-forgot-password.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Forgot Password</span>
                        </a>
                      </li>
                      <li>
                        <a href="user-lock-screen.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Lock Screen</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">pie_chart_outlined</i>
                    <span class="nav-text">Charts</span>
                  </a>
                  <div class="collapsible-body">
                    <ul>
                      <li>
                        <a href="charts-chartjs.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Chart JS</span>
                        </a>
                      </li>
                      <li>
                        <a href="charts-chartist.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Chartist</span>
                        </a>
                      </li>
                      <li>
                        <a href="charts-morris.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Morris Charts</span>
                        </a>
                      </li>
                      <li>
                        <a href="charts-xcharts.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>xCharts</span>
                        </a>
                      </li>
                      <li>
                        <a href="charts-flotcharts.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Flot Charts</span>
                        </a>
                      </li>
                      <li>
                        <a href="charts-sparklines.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Sparkline Charts</span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </li>-->
              </ul>
            </li>
            <!--<li class="li-hover">
              <p class="ultra-small margin more-text">MORE</p>
            </li>
            <li>
              <a href="angular-ui.html">
                <i class="material-icons">verified_user</i>
                <span class="nav-text">Angular UI</span>
              </a>
            </li>
            <li class="no-padding">
              <ul class="collapsible" data-collapsible="accordion">
                <li class="bold">
                  <a class="collapsible-header waves-effect waves-cyan">
                    <i class="material-icons">photo_filter</i>
                    <span class="nav-text">Menu Levels</span>
                  </a>
                  <div class="collapsible-body">
                    <ul class="collapsible" data-collapsible="accordion">
                      <li>
                        <a href="ui-basic-buttons.html">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span>Second level</span>
                        </a>
                      </li>
                      <li class="bold">
                        <a class="collapsible-header waves-effect waves-cyan">
                          <i class="material-icons">keyboard_arrow_right</i>
                          <span class="nav-text">Second level child</span>
                        </a>
                        <div class="collapsible-body">
                          <ul class="collapsible" data-collapsible="accordion">
                            <li>
                              <a href="ui-basic-buttons.html">
                                <i class="material-icons">keyboard_arrow_right</i>
                                <span>Third level</span>
                              </a>
                            </li>
                            <li class="bold">
                              <a class="collapsible-header waves-effect waves-cyan">
                                <i class="material-icons">keyboard_arrow_right</i>
                                <span class="nav-text">Third level child</span>
                              </a>
                              <div class="collapsible-body">
                                <ul class="collapsible" data-collapsible="accordion">
                                  <li>
                                    <a href="ui-basic-buttons.html">
                                      <i class="material-icons">keyboard_arrow_right</i>
                                      <span>Forth level</span>
                                    </a>
                                  </li>
                                  <li>
                                    <a href="ui-extended-buttons.html">
                                      <i class="material-icons">keyboard_arrow_right</i>
                                      <span>Forth level</span>
                                    </a>
                                  </li>
                                </ul>
                              </div>
                            </li>
                          </ul>
                        </div>
                      </li>
                    </ul>
                  </div>
                </li>
              </ul>
            </li>
            <li>
              <a href="changelogs.html">
                <i class="material-icons">track_changes</i>
                <span class="nav-text">Changelogs</span>
              </a>
            </li>-->
            <!--<li>
              <a href="../documentation" target="_blank">
                <i class="material-icons">import_contacts</i>
                <span class="nav-text">Documentation</span>
              </a>
            </li>-->
            <li>
              <a href="support" >
                <i class="material-icons">help_outline</i>
                <span class="nav-text">Support</span>
              </a>
            </li>
          </ul>
          <a href="#" data-activates="slide-out" class="sidebar-collapse btn-floating btn-medium waves-effect waves-light hide-on-large-only">
            <i class="material-icons">menu</i>
          </a>
        </aside>
        <!-- END LEFT SIDEBAR NAV-->
		<!-- Floating Action Button -->
<!--
        <div class="fixed-action-btn" style="bottom: 50px; right: 19px;">
          <a class="btn-floating btn-large">
            <i class="material-icons">add</i>
          </a>
          <ul>
            <li>
              <a href="support" class="btn-floating blue" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">help_outline</i>
              </a>
            </li>
-->
            <!--<li>
              <a href="cards-extended.html" class="btn-floating green" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">widgets</i>
              </a>
            </li>
            <li>
              <a href="app-calendar.html" class="btn-floating amber" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">today</i>
              </a>
            </li>
            <li>
              <a href="app-email.html" class="btn-floating red" style="transform: scaleY(0.4) scaleX(0.4) translateY(40px) translateX(0px); opacity: 0;">
                <i class="material-icons">mail_outline</i>
              </a>
            </li>-->
<!--
          </ul>
        </div>
-->
        <!-- Floating Action Button -->