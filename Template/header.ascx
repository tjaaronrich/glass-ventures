


<div class="material-header menu-index z-depth-nav" id="main-navigation" class="z-depth-3">

   	<nav id="top-navigation" class="hide-on-med-and-down menu-index">
    	<div class="nav-wrapper container-fluid menu-index" id="top-navigation-items">
      		
      		<div class="row align-items-center">
				<div class="col-2 col-lg-2 col-xl-2 align-self-center">
					<a href="/default">
						<img class="img-fluid"  src="/Graphics/glass-logo.png" id="csgc-logo" />
					</a>
				</div>

				<div class="col-2 col-lg-10 col-xl-10">
					<div class="row align-items-center">
						<div class="col-md-12">
							<ul class="right hide-on-med-and-down menu-index d-flex align-items-center" style="">
								<%= DAL_Navigation.BuildNav() %>	
								<li style='list-style-type: none !important; margin: 0 10px;'>
									<a class="schedule-button hide-on-med-and-down" href="tel:850-740-3175">850.740.3175</a>
								</li>
								<li class="d-flex" style='list-style-type: none !important; margin: 0 10px 0 35px;'>
									<a href="#" style="padding: 0 7.5px !important;"><i class="fab fa-instagram" style="color: #112D5C;"></i></a>
									<a href="#" style="padding: 0 7.5px !important;"><i class="fab fa-twitter" style="color: #112D5C;"></i></a>
									<a href="#" style="padding: 0 7.5px !important;"><i class="fab fa-facebook-f" style="color: #112D5C;"></i></a>
								</li>
							</ul>
						</div>
					</div>
				</div>
			</div>
	
    	</div>
  	</nav>
<!--
  	<nav id="notifyNav" class="menu-index">
    	<div class="nav-wrapper container-fluid menu-index">
      		<div class="row align-items-center">
				<div class="col-12" >
						<a href="#"><p class="top-notify-alert">Read Important COVID-19 Updates & How We're Helping</p></a>
				</div>
			</div>
		</div>
	
	</nav>
-->
	
  	
	<div class="nav-wrapper container-fluid hide-on-large-only" id="top-nav-mobile">
		<div class="row align-items-center" id="mobile-nav-div">
			<div class="col-10 col-sm-10">
				<a href="/" class="brand-logo"><img class="img-fluid navbar-logo navbar-img-lg" id="csgc-logo-mobile" src="/Graphics/glass-logo.png"/></a>
			</div>
			<div class="col-2 col-sm-2 hide-on-large-only">
				<a href="#" data-activates="mobile-demo" class="button-collapse">
					<i class="fa fa-bars" id="hamburger"></i>
				</a>
			</div>
			<div class="col-2 col-sm-6 hide-on-med-and-down">
				<a href="tel:18507842992" class="btn-large z-depth-1" id="call-today">CALL TODAY 850.740.3175</a>
			</div>
		</div>
	  	
	  	
	  	
		<ul id="mobile-demo" class="side-nav" style="">

            <li class="no-padding">
              <ul class="collapsible" data-collapsible="accordion">
                <%= DAL_Navigation.BuildNavMobile() %>
              </ul>
            </li>
            
            
            </ul>
	  	
	  	
	</div>
  	
  	
  	
  	
  	
</div>




