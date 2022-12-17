namespace JPhoneTask
{
    internal class StandartJphone : Jphone
    {
        public StandartJphone(string deviceName)
        {
            DeviceName = deviceName;
            MemorySize = 32;
        }

        internal override void AddAccount(string accountName)
        {
            if (UserAccounts.Count == 3)
            {
                Console.WriteLine("You cannot add more accounts, limit is reached");

                return;
            }

            UserAccounts.Add(accountName);
            Console.WriteLine($"Account \'{accountName}\' was added");
        }
    }
}