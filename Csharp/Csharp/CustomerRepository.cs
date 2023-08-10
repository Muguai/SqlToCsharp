using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;

namespace Csharp
{
    internal class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetAllCustomerData()
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = "SELECT * FROM Customer";

            using SqlCommand command = new(sqlQuery, connection);

            IList<Customer> customers = new List<Customer>();

            using SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) { 
                Customer customer = createCustomerFromReader(reader);
                customers.Add(customer);
            }
            return customers;
        }

        public Customer GetCustomerData(int id)
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = $"SELECT * FROM Customer WHERE CustomerId={id}";

            using SqlCommand command = new(sqlQuery, connection);

            Customer customer = new();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customer = createCustomerFromReader(reader);
            }
            return customer;
        }

        public IList<Customer> GetCustomerData(string name)
        {
            
            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = $"SELECT * FROM Customer WHERE FirstName LIKE '%{name}%'";

            using SqlCommand command = new(sqlQuery, connection);

            IList<Customer> customers = new List<Customer>();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = createCustomerFromReader(reader);
                customers.Add(customer);
            }
            return customers;
        }

        public IList<Customer> GetCustomerData(int offset, int limit)
        {

            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = $"SELECT * FROM Customer ORDER BY CustomerId OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY";

            using SqlCommand command = new(sqlQuery, connection);

            IList<Customer> customers = new List<Customer>();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = createCustomerFromReader(reader);
                customers.Add(customer);
            }

            return customers;
        }

        private Customer createCustomerFromReader(SqlDataReader reader)
        {
            Customer tempCustomer = new();
            tempCustomer.Id = reader.GetInt32(0);
            tempCustomer.FirstName = reader.GetString(1);
            tempCustomer.LastName = reader.GetString(2);
            tempCustomer.Country = reader.GetString(7);
            if (!reader.IsDBNull(8))
            {
                tempCustomer.PostalCode = reader.GetString(8);
            }
            if (!reader.IsDBNull(9))
            {
                tempCustomer.PhoneNumber = reader.GetString(9);
            }
            tempCustomer.Email = reader.GetString(11);
            return tempCustomer;
        }
    }
}
