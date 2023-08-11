using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Csharp.models
{
    internal class CustomerSpender
    {

        public Dictionary<Customer, decimal> mostMoneyDict { get; set; }

        public CustomerSpender(Dictionary<Customer, decimal> dict) { 
            mostMoneyDict = dict;
        }    

        /// <summary>
        /// Display all customers and their total spending
        /// </summary>
        public void DisplayAll()
        {
            foreach(KeyValuePair<Customer, decimal> keyValuePair in mostMoneyDict)
            {
                Console.WriteLine($"Name: {keyValuePair.Key.FirstName} {keyValuePair.Key.LastName} - Total: {keyValuePair.Value}");
            }
        }

        public void DisplaySpecific(Customer customer)
        {
            if(mostMoneyDict.TryGetValue(customer, out decimal value)) {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} - Total: {value}");
            }
            else
            {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} - Total: {value}");
            }
        }
    }
}
