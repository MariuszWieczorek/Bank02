using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class AccountManager
    {
        private List<Account> _accounts;
        public AccountManager()
        {
            _accounts = new List<Account>();
        }


         
        /// <summary>
        ///     Metoda zwracająca wszystkie konta
        /// </summary>
        /// <returns> pełna lista kont </returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }
        // Jak widać skorzystaliśmy tutaj z interfejsu IEnumerable,
        // ponieważ i tak jakiekolwiek operacje na liście powinniśmy od teraz wykonywać poprzez nasz manager.
        // Dlatego jedyne do czego potrzebujemy listę kont to wyciągnięcie ich w celu np. wyświetlenia.


        /// <summary>
        /// Metoda generująca numer konta
        /// Gdy Lista jest pusta zwraca najniższy możliwy numer czyli 1
        /// </summary>
        /// <returns> zwraca najniższy wolny numer konta </returns>
        private int generateId()
        {
            int id = 1;

            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }

            return id;
        }
        // Metoda Any() i Max() należy do biblioetki LINQ
        // Metoda Max() jako parametr przyjmuje wyrażenie lambda, pozwala ono w prosty sposób przekazać jako parametr funkcję
        // Max() będzie wykonywała tą przekazaną funkcję dla każdego elementu na liście i dopiero na zwróconych wartościach będzie operować
        //  Wyrażenie przekazane w parametrze wyglądałoby tak jak poniżej jeżeli byśmy chcieli je zapisać jako osobną funkcję:
        //    int Func(Account x)
        //     {
        //        return x.Id;
        //     }


        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }



        public IEnumerable<Account> GetAllAccountsFor1(string firstName, string lastName, long pesel)
        {
            List<Account> customerAccounts = new List<Account>();

            foreach (Account account in _accounts)
            {
                if (account.FirstName == firstName && account.LastName == lastName && account.Pesel == pesel)
                {
                    customerAccounts.Add(account);
                }
            }
            return customerAccounts;
        }


        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Pesel == pesel);
        }


        public Account GetAccount2(string accountNo)
        {
            Account account;
            account = null;

            foreach (Account acc in _accounts)
            {
                if (acc.AccountNumber == accountNo)
                {
                    account = acc;
                    break;
                }
            }

            return account;
        }



        public Account GetAccount(string accountNo)
        {

            return _accounts.Single(x => x.AccountNumber == accountNo);
            
        }
        // . Tym razem możemy wykorzystać funkcję Single(), która zgodnie z nazwą zwróci dokładnie jeden element z listy. 


    }
}
