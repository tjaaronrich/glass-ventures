// JavaScript Document
// JavaScript Document

$( document ).ready(function() {
							 
	$( "#blog-title" ).text("Latest Blog Posts");
	$.ajax({
    	url: '/webservices/blogService.asmx/GetTop3Blog',
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
	
	
	
	
	
	

});


