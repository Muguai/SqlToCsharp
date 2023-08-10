using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
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


    }
}
