namespace JPhoneTask
{
    internal class StandartJphone : Jphone
    {
        public StandartJphone(string deviceName)
        {
            DeviceName = deviceName;
            MemorySize = 32;
        }

        //we overrite AddAccount method and implement for standart phone like below
        internal override void AddAccount(string accountName)
        {
            //If account count reached 3 then we show output like below and exit method with return keyword
            if (UserAccounts.Count == 3)
            {
                Console.WriteLine("You cannot add more accounts, limit is reached");

                return;
            }

            //If not reached 3 account then we can add new account to phone and show info in console
            UserAccounts.Add(accountName);
            Console.WriteLine($"Account \'{accountName}\' was added");
        }
    }
}