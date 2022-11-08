using UserAddressDbEf;

class Program
{

    public static void Main(string[] args)
    {
        var print = new PrintFunctions();
        switch (args[0])
        {
            case "help":
                Console.WriteLine("Arguments are:");
                Console.WriteLine("--AddNewCustomers {amount:int}".PadLeft(10));
                Console.WriteLine("--PrintCustomerName".PadLeft(10));
                Console.WriteLine("--PrintCustomerAndAddress".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameFilter {search:string}".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameAndAddressFilter {search:string}".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameById {id:int}".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameAndAddressById {id:int}".PadLeft(10));
                break;
            case "--AddNewCustomers":
                print.AddNewCustomers(int.Parse(args[1]));
                break;
            case "--PrintCustomerName":
                print.PrintCustomerName();
                break;
            case "--PrintCustomerAndAddress":
                print.PrintCustomerAndAddress();
                break;
            case "--PrintCustomerNameFilter":
                print.PrintCustomerNameFilter(args[1]);
                break;
            case "--PrintCustomerNameAndAddressFilter":
                print.PrintCustomerNameAndAddressFilter(args[1]);
                break;
            case "--PrintCustomerNameById":
                print.PrintCustomerNameById(int.Parse(args[1]));
                break;
            case "--PrintCustomerNameAndAddressById":
                print.PrintCustomerNameAndAddressById(int.Parse(args[1]));
                break;
            default:
                Console.WriteLine("Invalid arguments");
                Console.WriteLine("Arguments are:");
                Console.WriteLine("--AddNewCustomers {amount:int}".PadLeft(10));
                Console.WriteLine("--PrintCustomerName".PadLeft(10));
                Console.WriteLine("--PrintCustomerAndAddress".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameFilter {search:string}".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameAndAddressFilter {search:string}".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameById {id:int}".PadLeft(10));
                Console.WriteLine("--PrintCustomerNameAndAddressById {id:int}".PadLeft(10));
                break;
        }
    }
}