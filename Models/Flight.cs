namespace AirFreight.Models
{
    public class Flight
    {
        public int flightID{get;set;}

        public int capacity{get;set;}
        public string flightCode{get;set;}
        public Airport destination{get;set;}
        public Airport from{get;set;}
        public int day{get;set;}

    }
}