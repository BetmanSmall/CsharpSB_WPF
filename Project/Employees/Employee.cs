using System;
using System.Diagnostics;
using CsharpSB_WPF.Project.Data;
using CsharpSB_WPF.Project.Utils;

namespace CsharpSB_WPF.Project.Employees {
    public abstract class Employee {
        public string EmployeeName { get; set; }
        public void WorkWithClients() {
            Client selectedClient = ConsoleClientSelector.SelectClient();
            if (selectedClient == null) {
                if (this.GetType() == typeof(Manager)) {
                    Debug.WriteLine("Клиенты не найдены! Создаем нового:");
                    selectedClient = ((Manager)this).CreateNewClient();
                } else {
                    Debug.WriteLine("Нет доступных клиентов для редактирования!");
                    return;
                }
            }
            WorkWithClient(selectedClient);
        }

        public abstract void WorkWithClient(Client client);

        public abstract string GetClientSerialNumber(Client client);

        public void ChangeClientData(Client client, ClientChangeData.WhichDataChange whichDataChanged, string oldValue, string newValue) {
            client.ClientChangeDatas.Add(new ClientChangeData(whichDataChanged, oldValue, newValue, this));
        }
    }
}