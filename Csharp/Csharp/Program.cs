

using System.Collections.Generic;
using Csharp.models;
using Csharp.Repository;

namespace Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Customer Info: \n");


            ICustomerRepository customerRepository = new CustomerRepository();

            Console.WriteLine("\n------------------ All Customers -----------------\n");

            IList<Customer> customers = customerRepository.GetAllCustomerData();
            PrintMultipleCustomers(customers);

            Console.WriteLine("\n------------------ Single Customer By Id -----------------\n");


            Customer singleCustomer = customerRepository.GetCustomerData(5);

            PrintSingleCustomer(singleCustomer);
            
            Console.WriteLine("\n------------------ Customers By Name -----------------\n");


            IList<Customer> customerByName = customerRepository.GetCustomerData("Diego");

            PrintMultipleCustomers(customerByName);

            Console.WriteLine("\n------------------ Customers By Offset/Limit -----------------\n");


            IList<Customer> customerOffsetLimit = customerRepository.GetCustomerData(3, 5);

            PrintMultipleCustomers(customerOffsetLimit);
            
            Console.WriteLine("\n------------------ Add Customer -----------------\n");

            Customer addCustomer = new Customer();
            addCustomer.FirstName = "Carl";
            addCustomer.LastName = "Carlignton";
            addCustomer.Country = "Sweden";
            addCustomer.PhoneNumber = "+4670875327";
            addCustomer.Email = "Carl.Carlington@hotmail.com";
            addCustomer.PostalCode = "12345";

            //Outcommented for now since it adds a new carl everytime we run the program
            //Console.WriteLine("True if customer got add -> " + customerRepository.AddCustomer(addCustomer));

            Console.WriteLine("\n------------------ Update Customer -----------------\n");

            Customer updateCustomer = customerRepository.GetCustomerData(60);

            updateCustomer.LastName = "Annaton";

            customerRepository.UpdateCustomer(updateCustomer);

            Customer updatedCustomer = customerRepository.GetCustomerData(60);

            PrintSingleCustomer(updatedCustomer);

            Console.WriteLine("\n------------------ Get Amount of Customer From Each Country -----------------\n");


            CustomerCountry customerCountry = customerRepository.GetCustomersFromCountry();

            customerCountry.DisplayAll();

            Console.WriteLine("\n------------------ Get Amount of Customer From Each Country -----------------\n");

            CustomerSpender customerSpender = customerRepository.GetCustomersWhoSpendMost();

            customerSpender.DisplayAll();

            Console.WriteLine("\n------------------ Get Most Popular Genre -----------------\n");


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