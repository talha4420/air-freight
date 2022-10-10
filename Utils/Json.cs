namespace AirFreight.Utils
{

    using Newtonsoft.Json;
    public static class Json
    {
        public static string GetJsonStringFromFile(string folderName, string FileName )
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, folderName, FileName);
            string jsonString = File.ReadAllText(filePath);
            return jsonString;
        }

        public static List<T> getObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        public static Object getObject(string jsonString)
        {
            return JsonConvert.DeserializeObject(jsonString);
        }
    }
}