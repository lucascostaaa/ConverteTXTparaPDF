using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TXT_to_PDF
{
    public class JsonConfig
    {
        protected const string pathAppConfig = "appsettings.json";

        protected static void Save(JObject newAppConfig)
        {
            File.WriteAllText(pathAppConfig, JsonConvert.SerializeObject(newAppConfig));
        }
        public static JObject AppConfig => JObject.Parse(File.ReadAllText(pathAppConfig));
        public static string PastaWatcher => AppConfig["PathWatcher"].ToString();
        public static string PastaPatch => AppConfig["PathPasta"].ToString();
    }
}
