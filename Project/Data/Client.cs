using System.Collections.Generic;
using CsharpSB_WPF.Project.Utils;
using Newtonsoft.Json;

namespace CsharpSB_WPF.Project.Data {
    public class Client {
        public FullName FullName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string SerialNumber { get; set; }
        public List<ClientChangeData> ClientChangeDatas = new List<ClientChangeData>();

        public Client() {
            this.FullName = new FullName(ClientsManager.Clients.Count);
            this.PhoneNumber = new PhoneNumber();
            this.SerialNumber = RandomNumberGenerator.GenerateRandomNumber(10);
            ClientsManager.Clients.Add(this);
        }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}