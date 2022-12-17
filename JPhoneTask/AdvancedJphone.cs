using System.Text.RegularExpressions;

namespace JPhoneTask
{
    internal class AdvancedJphone : Jphone
    {
        private string _serviceTag;

        public AdvancedJphone(string deviceName, string serviceTag)
        {
            DeviceName = deviceName;
            MemorySize = 64;
            ValidateServiceTag(serviceTag);
        }

        internal override void Call(string number)
        {
            var pattern = "^[46][0-9]{5,8}$";
            var regex = new Regex(pattern);

            if (!regex.IsMatch(number))
            {
                Console.WriteLine("Invalid phone number, please check the number!");

                return;
            }

            Console.WriteLine($"Calling to the number {number}");
            ValidCallsCount++;
        }

        internal override void AddAccount(string accountName)
        {
            if (UserAccounts.Count == 5)
            {
                Console.WriteLine("You cannot add more accounts, limit is reached");

                return;
            }

            UserAccounts.Add(accountName);
            Console.WriteLine($"Account \'{accountName}\' was added");
        }

        internal void PrintServiceTag()
        {
            Console.WriteLine($"Service tag is {_serviceTag}");
        }

        internal void ValidateServiceTag(string serviceTag)
        {
            // we check service tag must be at least 5 digit in a row
            var pattern = "[0-9]{5}";
            var regex = new Regex(pattern);

            // if doesn't we throw exception because in the task not include extra information about this
            if (!regex.IsMatch(serviceTag))
                throw new Exception("Invalid service tag, please check the service tag!");

            _serviceTag = serviceTag;
        }
    }
}