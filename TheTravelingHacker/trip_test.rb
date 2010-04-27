require 'trip'
require	'test/unit'
require 'rubygems'
require	'contest'
require 'mocha'

class TripTest < Test::Unit::TestCase
	setup do
		@routing_service = mock("RoutingService")
		@trip = Trip.new(@routing_service)
	end
	
	context "adding a stop" do
		test "stop count is initially 0" do
			assert_equal(0, @trip.stops.length)
		end
		
		test "adding a valid stop increases stops.length by 1" do
			valid_stop("Hartford, CT")
			valid_stop("Quahog, RI")
			
			@trip.add_stop("Hartford, CT")
			assert_equal(1, @trip.stops.length)
			
			@trip.add_stop("Quahog, RI")
			assert_equal(2, @trip.stops.length)
		end
		
		test "raises an error when an invalid stop is added" do
			invalid_stop("Fakevilla, AR")
			
			assert_raises(Trip::InvalidStopError) do
				@trip.add_stop("Fakevilla, AR")
			end
			
			assert_equal(0, @trip.stops.length)
		end
	end
	
	context "computing distance" do
		test "should return 0 when stops < 2" do
			valid_stop("Hartford, CT")
			
			@trip.add_stop("Hartford, CT")
			
			assert_equal(0, @trip.total_distance)
		end
		
		test "should compute point to point disstance with two stops" do
			all_stops_valid
			distance_between "New Haven, CT", "Naugatuck, CT", 17.4
			
			@trip.add_stop("New Haven, CT")
			@trip.add_stop("Naugatuck, CT")
			
			assert_equal(17.4, @trip.total_distance)
		end
		
		test "should compute leg by leg distance for N stops" do
			all_stops_valid
			
			distance_between "Point A", "Point B", 6
			distance_between "Point B", "Point C", 9
			distance_between "Point C", "Point D", 4
			distance_between "Point D", "Point E", 13
			
			%w[A B C D E].each do |point|
				@trip.add_stop("Point #{point}")
			end
			
			assert_equal(32, @trip.total_distance)
		end
	end
	
	context "trip mileage report" do
		test "should have a meaningful string representation" do
			all_stops_valid
			
			distance_between "Point A", "Point B", 6
			distance_between "Point B", "Point C", 9
			
			%w[A B C].each do |point|
				@trip.add_stop("Point #{point}")
			end
			
			assert_equal("Point A -> Point B: 6\nPoint B -> Point C: 9\n\n"+ 
										"Total: 15", @trip.to_s)
		end
	end
	
	def valid_stop(location)
		@routing_service.expects(:get).
										 with("/validate", :location => location).
										 returns("valid" => true)
	end
	
	def invalid_stop(location)
		@routing_service.expects(:get).
										 with("/validate", :location => location).
										 returns("valid" => false)
	end
	
	def all_stops_valid
		@routing_service.stubs(:get).with() { |route, params| route == "/validate" }.
																 returns("valid" => true) 
	end
	
	def distance_between(origin, destination, miles)
		@routing_service.expects(:get).
										 with("/distance", :origin => origin,
										 									 :destination => destination).
										 returns("miles" => miles)
	end
end