using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp.models;

namespace Csharp.Repository
{
    internal interface ICustomerRepository
    {
        /// <returns>All Customers</returns>
        IList<Customer> GetAllCustomerData();

        /// <param name="id"></param>
        /// <returns>Customer with the id provided</returns>
        Customer GetCustomerData(int id);

        /// <param name="name"></param>
        /// <returns>Customers with the name provided</returns>
        IList<Customer> GetCustomerData(string name);

        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>List of Customers from offset with limit</returns>
        IList<Customer> GetCustomerData(int offset, int limit);

        /// <summary>
        /// Adds customer to db
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>true if customer got added</returns>
        public bool AddCustomer(Customer newCustomer);

        /// <summary>
        /// Updates Customer in db
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns>true if customer got updated</returns>
        public bool UpdateCustomer(Customer updateCustomer);


        /// <summary>
        /// Get how many customers are in each country in descending order
        /// </summary>
        /// <returns>CustomerCountry Object</returns>
        public CustomerCountry GetCustomersFromCountry();

        /// <summary>
        /// Get which customers has spent the most in descending order
        /// </summary>
        /// <returns>CustomerSpender Object</returns>
        public CustomerSpender GetCustomersWhoSpendMost();

        /// <summary>
        /// Gets the favorite genre of the customer sent in
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>CustomerGenre object</returns>
        public CustomerGenre MostPopularGenre(Customer customer);



    }
}
