using System;
using System.Text;
using CsharpSB_WPF.Project.Data;
using CsharpSB_WPF.Project.Utils;

namespace CsharpSB_WPF.Project.Employees {
    public class Consultant : Employee {
        public override void WorkWithClient(Client client) {
            do {
                Console.Out.WriteLine("Client: " + ClientToString(client));
                Console.Out.WriteLine("Консультант что ты хочешь сделать с этим клиентом?" +
                                      "   --- 1. Просмотреть серию и номер паспорта" +
                                      "   --- 2. Просмотреть ФИО (JSON)" +
                                      "   --- 3. Изменить Номер телефона" +
                                      "   --- 0. Назад" +
                                      "");
                string enterValueString = (Console.ReadLine() ?? "0");
                if (enterValueString == String.Empty) enterValueString = "0";
                int enterValue = int.Parse(enterValueString);
                if (enterValue == 0) break;
                if (enterValue == 1) {
                    Console.Out.WriteLine(GetClientSerialNumber(client));
                } else if (enterValue == 2) {
                    Console.Out.WriteLine(GetClientFullName(client));
                } else if (enterValue == 3) {
                    ChangeClientPhoneNumber(client);
                }
            } while (true);
        }

        public override string GetClientSerialNumber(Client client) {
            if (client != null) {
                if (client.SerialNumber != null) {
                    if (client.SerialNumber.Length > 0) {
                        return RandomNumberGenerator.GetAsterisksMask(client.SerialNumber.Length);
                    }
                }
            }
            return String.Empty;
        }

        public string GetClientFullName(Client client) {
            return client.FullName.ToString();
        }

        public void ChangeClientPhoneNumber(Client client) {
            do {
                try {
                    Console.Out.Write("Введите номер телефона: ");
                    string phoneNumberStr = Console.ReadLine() ?? string.Empty;
                    PhoneNumber newPhoneNumber = new PhoneNumber(phoneNumberStr);
                    SetClientPhoneNumber(client, newPhoneNumber);
                    break;
                } catch (Exception e) {
                    Console.Error.WriteLine(e);
                    Console.Out.Write("Плохой номер ты ввел! Давай еще раз!");
                }
            } while (true);
        }

        public void SetClientPhoneNumber(Client client, PhoneNumber phoneNumber) {
            PhoneNumber oldValue = client.PhoneNumber;
            client.PhoneNumber = phoneNumber;
            Console.Out.WriteLine("Успешно! Новый номер:" + GetClientPhoneNumber(client));
            ChangeClientData(client, ClientChangeData.WhichDataChange.PhoneNumber, oldValue.ToString(), client.PhoneNumber.ToString());
        }

        public string GetClientPhoneNumber(Client client) {
            return client.PhoneNumber.number;
        }

        public string ClientToString(Client client) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"ФИО: {client.FullName.ToString(false)}");
            stringBuilder.Append("\t");
            stringBuilder.Append($"Номeр телефона: {GetClientPhoneNumber(client)}");
            stringBuilder.Append("\t");
            stringBuilder.Append($"Серия, номер паспорта: {GetClientSerialNumber(client)}");
            return stringBuilder.ToString();
        }
    }
}