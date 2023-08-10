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

        public void Display()
        {
            foreach(KeyValuePair<Customer, decimal> keyValuePair in mostMoneyDict)
            {
                Console.WriteLine($"Name: {keyValuePair.Key.FirstName} {keyValuePair.Key.LastName} Total: {keyValuePair.Value}");
            }
        }
    }
}
