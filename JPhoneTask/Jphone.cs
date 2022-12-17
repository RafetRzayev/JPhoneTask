using System.Text.RegularExpressions;

namespace JPhoneTask
{
    internal abstract class Jphone
    {
        protected string DeviceName;
        protected int MemorySize;
        protected int ValidCallsCount = 0;
        protected string CurrentAccount;

        protected List<string> UserAccounts = new();

        internal virtual void Call(string number)
        {
            //Phone numbers can have a length of 6-8 digits and have to start with numbers 4 or 6
            var pattern = "^[46][0-9]{5,7}$";
            var regex = new Regex(pattern);

            //If phone number invalid then we write output to console like below and exit the method with return keyword
            if (!regex.IsMatch(number))
            {
                Console.WriteLine("Invalid phone number, please check the number!");

                return;
            }

            //If phone number is valid then we write output to console like below and increase valid calls count
            Console.WriteLine($"Calling to the number {number}");
            ValidCallsCount++;
        }

        internal void SetCurrentAccount(string accountName)
        {
            //If that account name doesn't exist then we write output to console like below and exit the method with return keyword
            if (!UserAccounts.Contains(accountName))
            {
                Console.WriteLine($"{accountName} account name doesn't found in accounts");

                return;
            }

            //If account name found, then setted current account and print in the console
            CurrentAccount = accountName;
            Console.WriteLine($"{accountName} is current account");
        }

        internal void PrintAllAccounts()
        {
            //If accounts has not then we write output to console like below and exit the method with return keyword
            if (UserAccounts.Count == 0)
            {
                Console.WriteLine("No user accounts to display");

                return;
            }


            //If accounts has thew we print them in console
            foreach (var userAccount in UserAccounts)
            {
                Console.WriteLine(userAccount);
            }
        }

        internal void PrintInfo()
        {
            //we check current account has or not and depend on this we create info text for printing
            string currentAccountInfo;

            if (CurrentAccount == null)
                currentAccountInfo = "no one has been designated as a current user";
            else
                currentAccountInfo = $"{CurrentAccount} is current account";


            Console.WriteLine($"JPhone is called \'{DeviceName}\', it has {MemorySize}GB of memory and {UserAccounts.Count} user accounts and {ValidCallsCount} valid calls and {currentAccountInfo}");
        }

        //Add account logic(standart phone 3 account,advanced 5 account) is different for standart and advanced phone that reason we create abstract method and then overrite it in child classes
        internal abstract void AddAccount(string accountName);

        internal void DeleteAccount(string accountName)
        {
            //We check than account name isn't exit then print the output like below and exit method from return keyword
            if (!UserAccounts.Contains(accountName))
            {
                Console.WriteLine($"{accountName} account name doesn't found in accounts");

                return;
            }

            //we delete that account name and show info in console
            UserAccounts.Remove(accountName);
            Console.WriteLine($"{accountName} account name deleted from accounts");
        }

    }
}