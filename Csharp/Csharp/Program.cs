

using System.Collections.Generic;
using Csharp.models;
using Csharp.Repository;

namespace Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            ICustomerRepository customerRepository = new CustomerRepository();

            Console.WriteLine("------------------ All Customers -----------------");

            IList<Customer> customers = customerRepository.GetAllCustomerData();
            PrintMultipleCustomers(customers);

            Console.WriteLine("------------------ Single Customer By Id -----------------");


            Customer singleCustomer = customerRepository.GetCustomerData(5);

            PrintSingleCustomer(singleCustomer);

            Console.WriteLine("------------------ Customers By Name -----------------");


            IList<Customer> customerByName = customerRepository.GetCustomerData("Diego");

            PrintMultipleCustomers(customerByName);

            Console.WriteLine("------------------ Customers By Offset/Limit -----------------");


            IList<Customer> customerOffsetLimit = customerRepository.GetCustomerData(3, 5);

            PrintMultipleCustomers(customerOffsetLimit);

            Console.WriteLine("------------------ Add Customer -----------------");

            Customer addCustomer = new Customer();
            addCustomer.FirstName = "Carl";
            addCustomer.LastName = "Carlignton";
            addCustomer.Country = "Sweden";
            addCustomer.PhoneNumber = "+4670875327";
            addCustomer.Email = "Carl.Carlington@hotmail.com";
            addCustomer.PostalCode = "12345";

            //Outcommented for now since it adds a new carl everytime we run the program
            //Console.WriteLine("True if customer got add -> " + customerRepository.AddCustomer(addCustomer));
            Console.WriteLine(" ");
            Console.WriteLine("------------------ Update Customer -----------------");
            Console.WriteLine(" ");


            Customer updateCustomer = customerRepository.GetCustomerData(60);

            updateCustomer.LastName = "Annaton";

            customerRepository.UpdateCustomer(updateCustomer);

            Customer updatedCustomer = customerRepository.GetCustomerData(60);

            PrintSingleCustomer(updatedCustomer);

            Console.WriteLine(" ");
            Console.WriteLine("------------------ Get Amount of Customer From Each Country -----------------");
            Console.WriteLine(" ");


            CustomerCountry customerCountry = customerRepository.GetCustomersFromCountry();

            customerCountry.Display();

            Console.WriteLine(" ");
            Console.WriteLine("------------------ Get Amount of Customer From Each Country -----------------");
            Console.WriteLine(" ");


            CustomerSpender customerSpender = customerRepository.GetCustomersWhoSpendMost();

            customerSpender.Display();

            Console.WriteLine(" ");
            Console.WriteLine("------------------ Get Most Popular Genre -----------------");
            Console.WriteLine(" ");


            List<Customer> customersReal = (List<Customer>)customers;


            foreach (Customer customer in customersReal)
            {
                customerRepository.MostPopularGenre(customer).Display();
            }


        }


        private static void PrintSingleCustomer(Customer customer)
        {

            Console.WriteLine($"First Name: {customer.FirstName} " +
                   $"Last Name: {customer.LastName} " +
                   $"Country: {customer.Country} " +
                   $"PostalCode: {customer.PostalCode} " +
                   $"Phone Number: {customer.PhoneNumber} " +
                   $"Email: {customer.Email}");
        }

        private static void PrintMultipleCustomers(IList<Customer> customers)
        {

            foreach (Customer customer in customers)
            {
                PrintSingleCustomer(customer);
            }


        }
    }
}