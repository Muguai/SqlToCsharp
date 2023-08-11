using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.models
{
    internal class CustomerCountry
    {
        public Dictionary<string, int> customerCountryDict { get; set; }

        public CustomerCountry(Dictionary<string, int> dict) {
            this.customerCountryDict = dict;
        }

        /// <summary>
        /// Displays All Countries and their customer amount
        /// </summary>
        public void DisplayAll()
        {
            foreach (KeyValuePair<string, int> country in customerCountryDict)
            {
                Console.WriteLine($"{country.Key}: {country.Value}");
            }
        }

        /// <summary>
        /// Displays one specific country and its customer amount
        /// </summary>
        /// <param name="country"></param>
        public void DisplaySpecific(string country)
        {
            if (customerCountryDict.TryGetValue(country, out int value))
                Console.WriteLine($"{country}: {value}");
            else
                Console.WriteLine($"{country}: 0");
        }


    }
}
