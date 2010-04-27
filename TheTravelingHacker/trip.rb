class Trip
	
	def initialize(routing_service)
		@routing_service = routing_service
	end
	
	def add_stop(stop_name)
		raise InvalidStopError unless valid_location?(stop_name)
	end
	
	private
	
	def valid_location?(location)
		@routing_service.get("/validate", :location => location)["valid"]
	end
	
	InvalidStopError = Class.new(StandardError)
end