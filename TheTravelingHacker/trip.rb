class Trip
	def initialize(routing_service)
		@routing_service = routing_service
	end
	
	def add_stop(stop_name)
		validate_location(stop_name)
	end
	
	private
	
	def validate_location(location)
		@routing_service.get("/validate", :location => location)
	end
end