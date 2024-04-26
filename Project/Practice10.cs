using System;
using CsharpSB_WPF.Project.Employees;
using CsharpSB_WPF.Project.Utils;

namespace CsharpSB_WPF.Project {
    public static class Practice10 {
        public static void MainLoop() {
            ClientsManager.Load();
            do {
                Console.Out.WriteLine(string.Join(",", ClientsManager.Clients));
                Console.Out.Write("Кто ты войн?" +
                                  "\n  --- 1. Консультант!" +
                                  "\n  --- 2. Менеджер!" +
                                  "\n  --- 0. Ахиллес, сын Пелея! | Выход!" +
                                  "\nЯ:");
                string enterValueString = (Console.ReadLine() ?? "0");
                if (enterValueString == String.Empty) enterValueString = "0";
                int enterValue = int.Parse(enterValueString);
                if (enterValue == 0) break;
                Employee employee = null;
                if (enterValue == 1) {
                    employee = new Consultant();
                } else if (enterValue == 2) {
                    employee = new Manager();
                }
                if (employee != null) {
                    employee.WorkWithClients();
                }
            } while (true);
            Console.Out.WriteLine(string.Join(",", ClientsManager.Clients));
            ClientsManager.UnLoad();
        }
    }
}