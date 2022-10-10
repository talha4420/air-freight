using AirFreight.Models;
using AirFreight.Services;

internal class Program
{
    private static void Main(string[] args)
    {

        AirportService airportService = new AirportService("Data", "airport.json" );
        List<Airport> airports = airportService.getAllAirports();

        FlightService flightService = new FlightService("Data", "flight.json", airports);        
        List<Flight> AllFlights = flightService.getAllFlights();
        flightService.showAllFlights();
            

        OrderService orderService = new OrderService("Data", "orders.json", airports );
        List<Order> Allorders = orderService.getAllOrders();
        orderService.assignFlights(AllFlights);
        orderService.showAllOrders();



    }

}