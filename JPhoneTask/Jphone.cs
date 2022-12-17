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
            var pattern = "^[46][0-9]{5,7}$";
            var regex = new Regex(pattern);

            if (!regex.IsMatch(number))
            {
                Console.WriteLine("Invalid phone number, please check the number!");

                return;
            }

            Console.WriteLine($"Calling to the number {number}");
            ValidCallsCount++;
        }

        internal void SetCurrentAccount(string accountName)
        {
            if (!UserAccounts.Contains(accountName))
            {
                Console.WriteLine($"{accountName} account name doesn't found in accounts");

                return;
            }

            CurrentAccount = accountName;
            Console.WriteLine($"{accountName} is current account");
        }

        internal void PrintAllAccounts()
        {
            if (UserAccounts.Count == 0)
            {
                Console.WriteLine("No user accounts to display");

                return;
            }

            foreach (var userAccount in UserAccounts)
            {
                Console.WriteLine(userAccount);
            }
        }

        internal void PrintInfo()
        {
            string currentAccountInfo;

            if (CurrentAccount == null)
                currentAccountInfo = "no one has been designated as a current user";
            else
                currentAccountInfo = $"{CurrentAccount} is current account";


            Console.WriteLine($"JPhone is called \'{DeviceName}\', it has {MemorySize}GB of memory and {UserAccounts.Count} user accounts and {ValidCallsCount} valid calls and {currentAccountInfo}");
        }

        internal abstract void AddAccount(string accountName);

        internal void DeleteAccount(string accountName)
        {
            if (!UserAccounts.Contains(accountName))
            {
                Console.WriteLine($"{accountName} account name doesn't found in accounts");

                return;
            }

            UserAccounts.Remove(accountName);
            Console.WriteLine($"{accountName} account name deleted from accounts");
        }

    }
}