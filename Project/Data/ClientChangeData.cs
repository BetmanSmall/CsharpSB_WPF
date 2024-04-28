using System;
using CsharpSB_WPF.Project.Employees;

namespace CsharpSB_WPF.Project.Data {
    public class ClientChangeData {
        public DateTime ChangeDateTime { get; set; }
        public enum WhichDataChange {
            FullName,
            PhoneNumber,
            SerialNumber
        }
        public string WhichDataChanged;
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string WhoChanged { get; set; }

        public ClientChangeData() {
        }

        public ClientChangeData(WhichDataChange whichDataChanged, string oldValue, string newValue, Employee whoChanged) {
            WhichDataChanged = whichDataChanged.ToString();
            ChangeDateTime = DateTime.Now;
            OldValue = oldValue;
            NewValue = newValue;
            WhoChanged = whoChanged.GetType().ToString();
        }
    }
}