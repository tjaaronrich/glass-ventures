	var $div = $("#navbar");
	var observer = new MutationObserver(function(mutations) {
		mutations.forEach(function(mutation) {
			var i = 0;
			if (mutation.attributeName === "class") {
				var attributeValue = $(mutation.target).prop(mutation.attributeName);
				if (attributeValue == "nav-center pinned")
				{
					testAnim("slideInDown");
					console.log('df');
				} 
						
				if (attributeValue == "nav-center slideInDown animated pin-top")
				{
					$('#navbar').removeClass('slideInDown');
					$('#navbar').removeClass('animated');
					//testAnim("slideInDown");
					//console.log('df');
				} 
						
			  	console.log("Class attribute changed to:", attributeValue);
			}
			i++;
		});
	});
	observer.observe($div[0], {
	  attributes: true
	});

				
	function testAnim(x) {
		$('#navbar').addClass(x + ' animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
			//$(this).removeClass();
			//$(this).addClass("nav-center");
		});
	};



				
	$(document).ready(function() {
					

		//$('#navbar').pushpin({
		//	top: $('#navbar').offset().top
		//});

		$('.parallax').parallax();


		$( ".click-to-toggle" ).click(function() {
			$('.tap-target').tapTarget('open');
		});

		$('.tap-target').tapTarget('close');
		$('.slider').slider({
			indicators: false,
		});
		$(".button-collapse").sideNav();
		$(".button-collapse2").sideNav();
				
		
	});