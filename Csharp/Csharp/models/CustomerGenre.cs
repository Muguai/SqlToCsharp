using Csharp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.models
{
    internal class CustomerGenre
    {
        public string FavoriteGenre { get; set; }
        public Customer Customer { get; set; }


        public CustomerGenre(string favoritGenre, Customer customer)
        {
            this.FavoriteGenre = favoritGenre; 
            this.Customer = customer;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Customer.FirstName} {Customer.LastName} Favorite Genre:" + FavoriteGenre);
        }

    }
}
