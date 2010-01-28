Screw.Unit(function(){
	describe("String Set", function(){
		var stringSet;
		before(function(){
			stringSet = new StringSet();
		});
		
		describe("Add item", function() {
	  	it("should increase items' count", function(){	  		  		
	  		stringSet.add("one");
	  		stringSet.add("two");
	  		
	  		expect(stringSet.count()).to(equal, 2);
	  	});
	  	
	  	it("duplicated value should not increase items' count", function(){
	  		stringSet.add("one");
	  		stringSet.add("one");
	  		
	  		expect(stringSet.count()).to(equal, 1);	
	  	});
	  	
	  	it("should return the added value", function(){	  		
	  		var addedValue = stringSet.add("one");
	  		
	  		expect(addedValue).to(equal, "one");
	  	});        	
		});
		
		describe("Remove item", function(){
			it("should return true for succeed", function(){
				stringSet.add("one");
				
				var result = stringSet.remove("one");
				
				expect(result).to(equal, true);
			});
			
			it("should return false for value doesn't exist", function(){
				var result = stringSet.remove("not exist");
				
				expect(result).to(equal, false);
			});
			
			it("should reduce items' count", function(){
				stringSet.add("one");
				
				stringSet.remove("one");
				
				expect(stringSet.count()).to(equal, 0);
			});
		});
		
		describe("Clear items", function(){
			it("should items' count equal zero", function(){
				stringSet.add("one");
				
				stringSet.clear();
				
				expect(stringSet.count()).to(equal, 0);
			});
		});
		
		describe("Union two string sets", function(){
			it("should return the new string set without duplicated items", function(){				 
				stringSet.add("one");
				stringSet.add("two");
				var stringSet2 = new StringSet();
				stringSet2.add("one");
				stringSet2.add("three");
				
				var result = stringSet.union(stringSet2);

				expect(result.count()).to(equal, 3);
			});			
		});
		
		describe("Intersect two string sets", function(){
			it("should return the new intersected string set", function(){
				stringSet.add("one");
				stringSet.add("two");
				var stringSet2 = new StringSet();
				stringSet2.add("one");
				stringSet2.add("three");
				
				var result = stringSet.intersect(stringSet2);

				expect(result.count()).to(equal, 1);
			});
		});		
	});
});