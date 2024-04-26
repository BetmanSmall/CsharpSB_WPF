using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using CsharpSB_WPF.Project.Utils;

namespace CsharpSB_WPF.Project.Data {
    public class Client {
        public FullName FullName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string SerialNumber { get; set; }
        [JsonInclude] public List<ClientChangeData> ClientChangeDatas = new List<ClientChangeData>();

        public Client() {
            this.FullName = new FullName(ClientsManager.Clients.Count);
            this.PhoneNumber = new PhoneNumber();
            this.SerialNumber = RandomNumberGenerator.GenerateRandomNumber(10);
            ClientsManager.Clients.Add(this);
        }

        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }
}