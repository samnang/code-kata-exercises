class Trip
	attr_reader :stops
	
	def initialize(routing_service)
		@routing_service = routing_service
		@stops = []
	end
	
	def add_stop(stop_name)
		raise InvalidStopError unless valid_location?(stop_name)
		@stops << stop_name
	end
	
	def total_distance
		calculate_total_distance_by_point_to_point
	end
	
	def to_s
		report = ""
		
		total_miles = calculate_total_distance_by_point_to_point do |origin, destination, miles|
										report += "#{origin} -> #{destination}: #{miles}\n"
									end
										
		report += "\nTotal: #{total_miles}"
	end
	
	private
	
	def valid_location?(location)
		@routing_service.get("/validate", :location => location)["valid"]
	end
	
	def calculate_total_distance_by_point_to_point
		zero_mile = 0
		return zero_mile if @stops.length < 2
		
	  total_miles = 0
		@stops.each_with_index do |stop, index|
			origin = stop
			destination = @stops[index + 1]
			
			miles = calculate_between_distances(origin,  destination)
			total_miles += miles
			
			yield(origin, destination, miles) if block_given?
			
			break if index == @stops.length - 2
		end
		
		total_miles
	end
	
	def calculate_between_distances(origin, destination)
		@routing_service.get("/distance", :origin => origin, :destination => destination)["miles"]
	end
	
	InvalidStopError = Class.new(StandardError)
end