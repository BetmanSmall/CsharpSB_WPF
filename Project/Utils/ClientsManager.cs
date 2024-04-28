using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CsharpSB_WPF.Project.Data;
using Newtonsoft.Json;

namespace CsharpSB_WPF.Project.Utils {
    public static class ClientsManager {
        private static string JsonFileName = "clients.json";

        public static List<Client> Clients = new List<Client>();

        static ClientsManager() {
            Load();
        }

        public static void Load() {
            DeserializeFromFile(JsonFileName);
        }

        public static void UnLoad() {
            SerializeToFile(JsonFileName);
        }

        private static void SerializeToFile(string fileName) {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                JsonConvert.SerializeObject(Clients);
                Debug.WriteLine("Data has been saved to file");
            }
        }

        private static void DeserializeFromFile(string fileName) {
            if (!File.Exists(fileName)) return;
            using (StreamReader file = File.OpenText(fileName)) {
                JsonSerializer serializer = new JsonSerializer();
                Clients = (List<Client>)serializer.Deserialize(file, typeof(List<Client>));
                Debug.WriteLine($"Clients loaded:" + Clients);
            }
        }
    }
}