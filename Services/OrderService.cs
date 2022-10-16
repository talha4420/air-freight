namespace AirFreight.Services
{

    using AirFreight.Models;
    using AirFreight.Utils;
    public class OrderService
    {
        private string folder{get;set;}
        private string fileName{get;set;}
        List<Order> Allorders = new List<Order>();
        List<Airport> airports;

        public OrderService(string folder, string fileName, List<Airport> airports){
            this.folder = folder;
            this.fileName = fileName;
            this.airports = airports;
            
        }

        public List<Order> getAllOrders(){
            dynamic orders = Json.getObject(Json.GetJsonStringFromFile(this.folder, this.fileName));
            
            foreach (var item in orders)
            {
                Order order =  new Order();
                order.orderCode = item.Name;
                if(airports !=null)
                {
                    order.destination = airports.Where(u=> u.code == item.Value["destination"].Value).SingleOrDefault();
                }

                order.service = item.Value["service"].Value;

                switch(order.service){
                    case "same-day":
                        order.priority = 1;
                        break;
                    case "next-day":
                        order.priority = 2;
                        break;
                    case "regular":
                        order.priority = 3;
                        break;
                    default:
                    break;
                }
                
                Allorders.Add(order);
            }     

            return Allorders;
        }

        public void assignFlights(List<Flight> AllFlights)
        {
            foreach(Order order in Allorders.OrderBy(u=> u.priority).ToList())
            {
                var availableFLights  = AllFlights.Where(u=> u.destination == order.destination && u.capacity > 0)
                    .OrderBy(u=> u.day).ToList();
                if(availableFLights != null && availableFLights.Count> 0){
                    order.flight = availableFLights.FirstOrDefault();
                }
                
                if(order.flight != null)
                {
                    order.flight.capacity--;
                }
            }
        }

        public void showAllOrders()
        {
            Console.WriteLine("All Orders will be shown below:");
            foreach(Order order in Allorders)
            {
                if(order.flight != null)
                {
                    Console.WriteLine("order: {0}, flightNumber: {1}, departure: {2}, arrival: {3}, day: {4}, service: {5}, priority: {6}", 
                        order.orderCode, order.flight.flightID, order.flight.from.code, order.flight.destination.code, 
                        order.flight.day, order.service, order.priority);       
                }
                else{
                    Console.WriteLine("order: {0}, flightNumber: not scheduled", order.orderCode);       
                }
                
            }
        }


    }
}