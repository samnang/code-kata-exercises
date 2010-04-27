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
	end
end