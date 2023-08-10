using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal interface ICustomerRepository
    {
        IList<Customer> GetAllCustomerData();

        /// <param name="id"></param>
        /// <returns>Customer with the id provided</returns>
        Customer GetCustomerData(int id);

        /// <param name="name"></param>
        /// <returns>Customer with the name provided</returns>
        Customer GetCustomerData(string name);




    }
}
