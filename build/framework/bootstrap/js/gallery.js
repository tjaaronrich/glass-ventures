// JavaScript Document
$( document ).ready(function() {
							 
	var blogId = getUrlParameter('nNum');
	if(blogId !== undefined)
	{
		$.ajax({
    		url: '/webservices/blogService.asmx/GetBlogId?nNum=' + blogId,
    		dataType: 'json',
    		timeout: 5000,
    		success: function(data, status){
					$( "#gallery-title" ).text(data.blog.item.title);
					
					var items = $("#gallery-items").hide();
            		//alert(data.blog.item.id);
					$("#gallery-items").append("<div class='col-lg-12'><p>" + data.blog.item.content + " </p</div>");
					items.show('slow');
				
    		},
    		error: function(){
        		alert('There was an error loading the data.');
    		}
		});		
	} else 
	{
		$( "#gallery-title" ).text("Latest Gallery Posts");
		$.ajax({
    		url: '/webservices/galleryService.asmx/GetAllGallery',
    		dataType: 'json',
    		timeout: 5000,
    		success: function(data, status){
				for (var i = 0; i < data.gallery.item.length; i++) {
            		//alert(data.blog.item[i].id);
					
					var items = $("#gallery-items").hide();
					$("#gallery-items").append("" + 
						"<div class='col-sm-3 blog-item'>" + 
							"<h3>" + data.gallery.item[i].pgName + "</h3>" + 
							"<p>" + data.gallery.item[i].name + " " + 
							"</p>" + 
							"<img class='img-responsive' src='/Documents/Gallery/" + data.gallery.item[i].imageFile + "' />" +
							"<p></p>" + 
						"</div>");
					items.show('slow');
				}
    		},
    		error: function(){
        		alert('There was an error loading the data.');
    		}
		});	
	}
	

});






// Check for a url Parameter
function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};