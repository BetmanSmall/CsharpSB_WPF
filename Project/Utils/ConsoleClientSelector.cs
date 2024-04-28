using System;
using System.Diagnostics;
using System.Text;
using CsharpSB_WPF.Project.Data;

namespace CsharpSB_WPF.Project.Utils {
    public static class ConsoleClientSelector {
        public static Client SelectClient() {
            if (ClientsManager.Clients.Count == 0) {
                return null;
            }
            int clientsCountInPage = 10;
            int pageIndex = 0;
            do {
                StringBuilder stringBuilder = new StringBuilder();
                int pagesCount = ClientsManager.Clients.Count / clientsCountInPage;
                int clientsPageIndexMin = pageIndex * clientsCountInPage;
                int clientsPageIndexMax = (pageIndex + 1) * clientsCountInPage;
                // clientsPageIndexMax = clientsPageIndexMax < ClientsManager.Clients.Count ? clientsPageIndexMax : ClientsManager.Clients.Count;
                if (clientsPageIndexMax > ClientsManager.Clients.Count) {
                    clientsPageIndexMax = ClientsManager.Clients.Count;
                }
                for (int i = clientsPageIndexMin; i < clientsPageIndexMax; i++) {
                    stringBuilder.Append($"  --- {i + 1} - " + ClientsManager.Clients[i].FullName + "\n");
                }
                Debug.WriteLine($"\n Pages:({pageIndex + 1}/{pagesCount + 1})");
                Debug.WriteLine(stringBuilder.ToString());
                Debug.WriteLine("Менять страницы: -1 = Назад, 0 = Вперед.");
                Debug.WriteLine("Выбери клиента:");
                string enterValueString = (Console.ReadLine() ?? "0");
                if (enterValueString == String.Empty) enterValueString = "0";
                int enterValue = int.Parse(enterValueString);
                if (enterValue <= 0) {
                    if (enterValue == 0) {
                        pageIndex++;
                        pageIndex = pageIndex > pagesCount ? pagesCount : pageIndex;
                    } else {
                        pageIndex--;
                        pageIndex = pageIndex < 0 ? 0 : pageIndex;
                    }
                } else {
                    if (enterValue > clientsPageIndexMin && enterValue <= clientsPageIndexMax) {
                        return ClientsManager.Clients[enterValue - 1];
                    }
                }
            } while (true);
        }
    }
}