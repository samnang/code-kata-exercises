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
			assert_equal 0, @trip.stops.length
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
end