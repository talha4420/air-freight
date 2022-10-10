namespace AirFreight.Services
{

    using AirFreight.Models;
    using AirFreight.Utils;
    public class FlightService
    {
        private string folder{get;set;}
        private string fileName{get;set;}

        List<Flight> AllFlights = new List<Flight>();

        List<Airport> airports;

        public FlightService(string folder, string fileName, List<Airport> airports){
            this.airports = airports;
            this.folder = folder;
            this.fileName = fileName;          
        }

        public List<Flight> getAllFlights(){

            dynamic flights = Json.getObject(Json.GetJsonStringFromFile(this.folder, this.fileName));
            foreach (var item in flights)
            {
                Flight flight =  new Flight();
                flight.flightID = (int) item.flightID.Value;
                if(airports != null && airports.Count > 0){
                    flight.destination = airports.Where(u=> u.code == item.destination.Value).SingleOrDefault();
                    flight.from = airports.Where(u=> u.code == item.from.Value).SingleOrDefault();
                }
                
                flight.flightCode = item.flightCode;
                flight.flightCode = item.flightCode;
                flight.day = (int)item.day.Value;
                flight.capacity = 20;
                AllFlights.Add(flight);
            }      

            return AllFlights;
        }

        public void showAllFlights()
        {
            Console.WriteLine("All Flights will be shown below:");
            foreach(Flight flight in AllFlights)
            {
                Console.WriteLine("Flight: {0}, departure: {1}, arrival: {2}, day: {3}",flight.flightID,flight.from.code,flight.destination.code, flight.day);
            }
        }
    }
}