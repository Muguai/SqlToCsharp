namespace Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            ICustomerRepository customerRepository = new CustomerRepository();
            IList<Customer> customers = customerRepository.GetAllCustomerData();

            Console.WriteLine("------------------ All Customer -----------------");

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

            Console.WriteLine("------------------ Single Customer By Name -----------------");


            Customer singleCustomerName = customerRepository.GetCustomerData("Diego");

            Console.WriteLine($"First Name: {singleCustomerName.FirstName} " +
                   $"Last Name: {singleCustomerName.LastName} " +
                   $"Country: {singleCustomerName.Country} " +
                   $"PostalCode: {singleCustomerName.PostalCode} " +
                   $"Phone Number: {singleCustomerName.PhoneNumber} " +
                   $"Email: {singleCustomerName.Email}");
        }
    }
}