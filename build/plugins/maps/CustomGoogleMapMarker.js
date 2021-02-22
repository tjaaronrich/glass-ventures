function CustomMarker(latlng, map, args) {
	this.latlng = latlng;	
	this.args = args;	
	this.setMap(map);	
}

CustomMarker.prototype = new google.maps.OverlayView();

CustomMarker.prototype.draw = function() {
	
	var self = this;
	
	var div = this.div;
	
	if (!div) {
	
		div = this.div = document.createElement('i');
		div.id = self.args.marker_id;
		if(self.args.marker_id == 'dothan')
		{
			div.className = 'fas fa-map-marker active';
			//div.style.color = '#ee362d';
		} else 
		{
			div.className = 'fas fa-map-marker';
			//div.style.color = '#2068b3';
		}
		
		
		div.style.position = 'absolute';
		div.style.cursor = 'pointer';
		//div.style.width = '20px';
		//div.style.height = '20px';
		div.style.background = 'transparent';
		//div.style.fontSize = '2rem';
		
		if (typeof(self.args.marker_id) !== 'undefined') {
			div.dataset.marker_id = self.args.marker_id;
		}
		
		google.maps.event.addDomListener(div, "click", function(event) {
			//alert('You clicked on a custom marker!');	
			$(".fa-map-marker.active").each( function(i,item){
				$(item).removeClass('active');
			});
			div.className = 'fas fa-map-marker active';	
			if(self.args.marker_id == 'dothan')
			{
				$('.collapsible').collapsible('open', 0);
			} 
			else if(self.args.marker_id == 'westgate')
			{
				$('.collapsible').collapsible('open', 1);
			}
			else if(self.args.marker_id == 'enterprise')
			{
				$('.collapsible').collapsible('open', 2);
			}
			else if(self.args.marker_id == 'eufaula')
			{
				$('.collapsible').collapsible('open', 3);
			}
			else if(self.args.marker_id == 'ozark')
			{
				$('.collapsible').collapsible('open', 4);
			}
			google.maps.event.trigger(self, "click");
		});
		
		var panes = this.getPanes();
		panes.overlayImage.appendChild(div);
	}
	
	var point = this.getProjection().fromLatLngToDivPixel(this.latlng);
	
	if (point) {
		div.style.left = (point.x - 10) + 'px';
		div.style.top = (point.y - 20) + 'px';
	}
};

CustomMarker.prototype.remove = function() {
	if (this.div) {
		this.div.parentNode.removeChild(this.div);
		this.div = null;
	}	
};

CustomMarker.prototype.getPosition = function() {
	return this.latlng;	
};