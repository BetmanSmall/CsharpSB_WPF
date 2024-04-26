using System;
using System.Linq;
using CsharpSB_WPF.Project.Data;
using CsharpSB_WPF.Project.Utils;

namespace CsharpSB_WPF.Project.Employees {
    public class Manager : Consultant {
        public override void WorkWithClient(Client client) {
            do {
                Console.Out.WriteLine("Client: " + ClientToString(client));
                Console.Out.WriteLine("Менеджер что ты хочешь сделать с этим клиентом?" +
                                      "   --- 1. Повзаимодействовать с клиентом как консультант" +
                                      "   --- 2. Изменить ФИО" +
                                      "   --- 3. Изменить Номер телефона" +
                                      "   --- 4. Изменить Серию, номер паспорта" +
                                      "   --- 5. Создать нового клиента" +
                                      "   --- 0. Назад" +
                                      "");
                string enterValueString = (Console.ReadLine() ?? "0");
                if (enterValueString == String.Empty) enterValueString = "0";
                int enterValue = int.Parse(enterValueString);
                if (enterValue == 0) break;
                if (enterValue == 1) {
                    base.WorkWithClient(client);
                } else if (enterValue == 2) {
                    ChangeClientFullName(client);
                } else if (enterValue == 3) {
                    ChangeClientPhoneNumber(client);
                } else if (enterValue == 4) {
                    ChangeClientSerialNumber(client);
                } else if (enterValue == 5) {
                    client = CreateNewClient();
                }
            } while (true);
        }

        public override string GetClientSerialNumber(Client client) {
            if (client != null) {
                if (client.SerialNumber != null) {
                    return client.SerialNumber;
                }
            }
            return String.Empty;
        }

        public void ChangeClientFullName(Client client) {
            FullName oldValue = client.FullName;
            Console.Out.Write("Введите фамилию: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            if (lastName.Length > 0)
                client.FullName.LastName = lastName;
            Console.Out.Write("Введите имя: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            if (firstName.Length > 0)
                client.FullName.FirstName = firstName;
            Console.Out.Write("Введите отчество: ");
            string surName = Console.ReadLine() ?? string.Empty;
            if (surName.Length > 0)
                client.FullName.SurName = surName;
            ChangeClientData(client, ClientChangeData.WhichDataChange.FullName, oldValue.ToString(), client.FullName.ToString());
        }

        public void ChangeClientSerialNumber(Client client) {
            do {
                Console.Out.Write("Введите серию и номер паспорта: ");
                string serialNumber = Console.ReadLine() ?? string.Empty;
                if (serialNumber.Length == 0) serialNumber = RandomNumberGenerator.GenerateRandomNumber(10);
                Console.Out.WriteLine($"Ты ввел serialNumber: {serialNumber}");
                var isNumeric = serialNumber.All(char.IsDigit);
                if (isNumeric && serialNumber.Length == 10) {
                    string oldValue = client.SerialNumber;
                    client.SerialNumber = serialNumber;
                    ChangeClientData(client, ClientChangeData.WhichDataChange.SerialNumber, oldValue, client.SerialNumber);
                    break;
                } else {
                    Console.Out.WriteLine("Ввел что то не то!");
                }
            } while (true);
        }

        public Client CreateNewClient() {
            Client newClient = new Client();
            ChangeClientFullName(newClient);
            ChangeClientPhoneNumber(newClient);
            ChangeClientSerialNumber(newClient);
            return newClient;
        }
    }
}