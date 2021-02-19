var observer = new MutationObserver(function(mutations) {
    mutations.forEach(function(mutationRecord) {
		//var obj = $.parseJSON( JSON.stringify(mutationRecord) );
		var animName = $("#countSection").css("animation-name");
		if (animName == "fadeInLeft")
		{
			var options = {
				useEasing : true, 
				useGrouping : true, 
				separator : ',', 
				decimal : '.', 
				prefix : '', 
				suffix : '' 
			};
			var yearsInBusiness = new CountUp("yearsInBusiness", 0, 30, 0, 2.5, options);
			yearsInBusiness.start();
	
	 
			var customPoolsBuilt = new CountUp("customPoolsBuilt", 0, 23, 0, 2.5, options);
			customPoolsBuilt.start();
	
	
			var satisfiedClients = new CountUp("satisfiedClients", 0, 100, 0, 2.5, options);
			satisfiedClients.start();	
		}
    });    
});
if (document.getElementById('countSection')) {
  	var target = document.getElementById('countSection');
	observer.observe(target, { attributes : true, attributeFilter : ['style'] });
  // do stuff
}
