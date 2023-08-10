using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.models
{
    internal class CustomerCountry
    {
        public List<(string, int)> customerCountryList { get; set; }

        public CustomerCountry(List<(string, int)> list) {
            this.customerCountryList = list;
        }

        public void Display()
        {
            foreach ((string, int) country in customerCountryList)
            {
                Console.WriteLine($"{country.Item1}: {country.Item2}");
            }
        }
    }
}
