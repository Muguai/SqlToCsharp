namespace Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            ICustomerRepository customerRepository = new CustomerRepository();
            IList<Customer> customers = customerRepository.GetAllCustomerData();

            Console.WriteLine("------------------ All Customers -----------------");

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"First Name: {customer.FirstName} " +
                    $"Last Name: {customer.LastName} " +
                    $"Country: {customer.Country} " +
                    $"PostalCode: {customer.PostalCode} " +
                    $"Phone Number: {customer.PhoneNumber} " +
                    $"Email: {customer.Email}");
            }

            Console.WriteLine("------------------ Single Customer By Id -----------------");


            Customer singleCustomer = customerRepository.GetCustomerData(5);

            Console.WriteLine($"First Name: {singleCustomer.FirstName} " +
                   $"Last Name: {singleCustomer.LastName} " +
                   $"Country: {singleCustomer.Country} " +
                   $"PostalCode: {singleCustomer.PostalCode} " +
                   $"Phone Number: {singleCustomer.PhoneNumber} " +
                   $"Email: {singleCustomer.Email}");

            Console.WriteLine("------------------ Customers By Name -----------------");


            IList<Customer> customerByName = customerRepository.GetCustomerData("Diego");

            foreach (Customer customer in customerByName)
            {
                Console.WriteLine($"First Name: {customer.FirstName} " +
                    $"Last Name: {customer.LastName} " +
                    $"Country: {customer.Country} " +
                    $"PostalCode: {customer.PostalCode} " +
                    $"Phone Number: {customer.PhoneNumber} " +
                    $"Email: {customer.Email}");
            }


            Console.WriteLine("------------------ Customers By Offset/Limit -----------------");


            IList<Customer> customerOffsetLimit = customerRepository.GetCustomerData(3,5);


            foreach (Customer customer in customerOffsetLimit)
            {
                Console.WriteLine($"First Name: {customer.FirstName} " +
                    $"Last Name: {customer.LastName} " +
                    $"Country: {customer.Country} " +
                    $"PostalCode: {customer.PostalCode} " +
                    $"Phone Number: {customer.PhoneNumber} " +
                    $"Email: {customer.Email}");
            }
        }
    }
}