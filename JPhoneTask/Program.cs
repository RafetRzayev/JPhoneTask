namespace JPhoneTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jphone = new StandartJphone("Nokia");

            jphone.Call("41234555");
            jphone.Call("11234555");

            jphone.AddAccount("John");
            jphone.AddAccount("Kevin");
            jphone.AddAccount("Nick");
            jphone.AddAccount("Levin");

            jphone.DeleteAccount("Kevin");

            jphone.SetCurrentAccount("John");

            jphone.PrintInfo();

            Console.WriteLine();

            var jphonePlus = new AdvancedJphone("Nokia", "12345");

            jphonePlus.Call("412345521");
            jphonePlus.Call("4123455512223");

            jphonePlus.AddAccount("John");
            jphonePlus.AddAccount("Nick");
            jphonePlus.AddAccount("Levin");
            jphonePlus.AddAccount("Kevin");
            jphonePlus.AddAccount("Tven");
            jphonePlus.AddAccount("Hugo");

            jphonePlus.DeleteAccount("Hugo");
            jphonePlus.DeleteAccount("Levin");

            jphonePlus.SetCurrentAccount("Nick");

            jphonePlus.PrintInfo();
            jphonePlus.PrintServiceTag();
        }
    }
}