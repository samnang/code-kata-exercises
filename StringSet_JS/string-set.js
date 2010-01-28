StringSet = function (){
	this._items = [];
};

StringSet.prototype = {
	add: function(value){
		if(this._items.indexOf(value) == -1)
			this._items.push(value);
		
		return value;
	},
	remove: function(value){
		var indexItem = this._items.indexOf(value);
		if(indexItem == -1)
			return false;
			
		this._items.splice(indexItem, 1);	
		return true;
	},
	count: function(){
		return this._items.length;
	},
	clear: function(){
		this._items = [];
	},
	union: function(second){
		var result = new StringSet();
		this._copyItems(this, result);
		this._copyItems(second, result);

		return result;
	},
	intersect: function(second){
		var result = new StringSet();
		
		var maxLength = this.count();
		for(var index = 0; index < maxLength; index++){
			if(second._items.indexOf(this._items[index]) == -1){
				result._items.push(this._items[index]);	
			}
		}
		
		return result;
	},
	_copyItems: function(source, destination){
		if(destination._items.length == 0){
			destination._items = Array.concat(source._items.slice(0));
		}
		else{
			var maxLength = source.count();
			for(var index = 0; index < maxLength; index++){
				if(destination._items.indexOf(source._items[index]) == -1){
					destination._items.push(source._items[index]);	
				}
			}
		}	
	}
};