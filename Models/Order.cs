namespace AirFreight.Models
{
    public class Order
    {

        static int nrOfInstances = 0;
        public int orderId{get;set;}
        public string orderCode{get;set;}
        public Airport destination{get;set;}

        public Flight flight{get;set;}

        public Order(){
            this.orderId = nrOfInstances;
            nrOfInstances++;
        }

    }
}