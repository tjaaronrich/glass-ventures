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
					$( "#blog-title" ).text(data.blog.item.title);
					
					var items = $("#blog-items").hide();
            		//alert(data.blog.item.id);
					$("#blog-items").append("<div class='col-lg-12'><p>" + data.blog.item.content + " </p</div>");
					items.show('slow');
				
    		},
    		error: function(){
        		alert('There was an error loading the data.');
    		}
		});		
	} else 
	{
		$( "#blog-title" ).text("Latest Blog Posts");
		$.ajax({
    		url: '/webservices/blogService.asmx/GetAllBlog',
    		dataType: 'json',
    		timeout: 5000,
    		success: function(data, status){
				for (var i = 0; i < data.blog.item.length; i++) {
            		//alert(data.blog.item[i].id);
					
					var items = $("#blog-items").hide();
					$("#blog-items").append("" + 
						"<div class='col-sm-3 blog-item'>" + 
							"<h3>" + data.blog.item[i].title + "</h3>" + 
							"<p>" + data.blog.item[i].summary + " " + 
								"<a href='http://www.testurl27.com/blog?nNum=" + data.blog.item[i].id + "'>Read more</a>" + 
							"</p>" + 
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