namespace AirFreight.Services
{

    using AirFreight.Models;
    using AirFreight.Utils;
    public class AirportService
    {
        private string folder{get;set;}
        private string fileName{get;set;}

        public AirportService(string folder, string fileName){
            this.folder = folder;
            this.fileName = fileName;            
        }

        public List<Airport> getAllAirports(){
            return Json.getObject<Airport>(Json.GetJsonStringFromFile(this.folder, this.fileName));
        }
    }
}