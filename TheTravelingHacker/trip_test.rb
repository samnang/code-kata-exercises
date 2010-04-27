require 'trip'
require	'test/unit'
require 'rubygems'
require	'contest'
require 'mocha'

class TripTest < Test::Unit::TestCase
	context "adding a stop" do
		test "can add a valid stop without errors" do
			routing_service = mock('RoutingService')
			routing_service.expects(:get).
											with("/validate", :location => "Hartford, CT").
											returns("valid" => true)
			
			trip = Trip.new(routing_service)
			trip.add_stop("Hartford, CT")
		end
		
		test "raises an error when an invalid stop is added" do
			routing_service = mock('RoutingService')
			routing_service.expects(:get).
											with("/validate", :location => "Fakevilla, AR").
											returns("valid" => false)
											
			trip = Trip.new(routing_service)
			
			assert_raises(Trip::InvalidStopError) do
				trip.add_stop("Fakevilla, AR")
			end
		end
	end
end