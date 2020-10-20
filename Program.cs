using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Nazwa: Bank";
            string author = "Autor: Mariusz Wieczorek";
            Console.WriteLine(name);
            Console.WriteLine(author);
            Console.WriteLine();

            AccountManager manager = new AccountManager();
            manager.CreateSavingsAccount("Jan", "Kowalski", 72080408887);
            manager.CreateSavingsAccount("Jan", "Szwagierczak", 72080408897);
            manager.CreateSavingsAccount("Małgorzata", "Nowakowska", 72080409999);
            manager.CreateSavingsAccount("Marek", "Nowak", 72080409998);
            manager.CreateBillingAccount("Małgorzata", "Nowakowska", 72080409999);
            manager.CreateBillingAccount("Joanna", "Karbowniczak", 72080409991);

            // Nie przejmując się, która klasa tak naprawdę tym drukowaniem się zajmie.
            // Możemy więc jako typ zmiennej podawać od teraz IPrinter:
            IPrinter printer = new SmallerPrinter();

            IList<Account> accounts = (IList<Account>)manager.GetAllAccounts();

            foreach (Account x in accounts)
            {
                printer.Print(x);
            }



            IEnumerable<string> users = manager.ListOfCustomers2();
            Console.WriteLine();
            foreach (var x in users)
            {
                Console.WriteLine(x);
            }


            // Tworzymy obiekt managera.Dodajemy do niego kilka kont.Następnie bierzemy wszystkie i wypisujemy dane dwóch z nich.
            // IList<Account> accounts = (IList<Account>)manager.GetAllAccounts();
            // printer.Print(accounts[0]);
            // printer.Print(accounts[2]);
            // Musieliśmy jednak zamienić typ zwracanej listy z IEnumerable na IList ponieważ IEnumerable nie posiada operatora[].
            // Jednak mogliśmy to tutaj spokojnie zrobić bo wiemy, że pod spodem tak naprawdę jest lista.


            Console.ReadKey();
        }
    }
}
