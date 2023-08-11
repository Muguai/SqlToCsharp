using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using Csharp.models;

namespace Csharp.Repository
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

            while (reader.Read())
            {
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

        public bool AddCustomer(Customer newCustomer)
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());

            connection.Open();

            // NB! Insert variable elements into SQL command using SqlCommand.Parameters.AddWithValue()
            string sqlQuery = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            SqlCommand cmd = new(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@FirstName", newCustomer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", newCustomer.LastName);
            cmd.Parameters.AddWithValue("@Country", newCustomer.Country);
            cmd.Parameters.AddWithValue("@PostalCode", newCustomer.PostalCode);
            cmd.Parameters.AddWithValue("@Phone", newCustomer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", newCustomer.Email);



            return cmd.ExecuteNonQuery() == 1;
        }

        public bool UpdateCustomer(Customer updateCustomer)
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());

            connection.Open();

            // NB! Insert variable elements into SQL command using SqlCommand.Parameters.AddWithValue()
            string sql = "UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, Country=@Country, PostalCode=@PostalCode, Phone=@Phone, Email=@Email  WHERE CustomerId=@Id";

            SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", updateCustomer.Id);
            cmd.Parameters.AddWithValue("@FirstName", updateCustomer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", updateCustomer.LastName);
            cmd.Parameters.AddWithValue("@Country", updateCustomer.Country);
            cmd.Parameters.AddWithValue("@PostalCode", updateCustomer.PostalCode);
            cmd.Parameters.AddWithValue("@Phone", updateCustomer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", updateCustomer.Email);


            return cmd.ExecuteNonQuery() == 1;
        }

        public CustomerCountry GetCustomersFromCountry()
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = $"SELECT Country, count(customerId) FROM Customer group by Country ORDER BY count(Country) DESC";

            using SqlCommand command = new(sqlQuery, connection);

            Dictionary<string, int> countByCountry = new Dictionary<string, int>();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                countByCountry.Add(reader.GetString(0), reader.GetInt32(1));
            }

            return new CustomerCountry(countByCountry);
        }

        public CustomerSpender GetCustomersWhoSpendMost()
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = @"
                        SELECT
                            c.CustomerId,
                            c.FirstName,
                            c.LastName,
                            c.Country,
                            c.PostalCode,
                            c.Phone,
                            c.Email,
                            SUM(i.Total) AS TotalSpending
                        FROM Invoice i
                        INNER JOIN Customer c ON i.CustomerId = c.CustomerId
                        GROUP BY c.CustomerId, c.FirstName, c.LastName, c.Country, c.PostalCode, c.Phone, c.Email
                        ORDER BY TotalSpending DESC;";

            using SqlCommand command = new(sqlQuery, connection);

            Dictionary<Customer, decimal> whoSpentTheMost = new Dictionary<Customer, decimal>();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer tempCustomer = new();
                tempCustomer.Id = reader.GetInt32(0);
                tempCustomer.FirstName = reader.GetString(1);
                tempCustomer.LastName = reader.GetString(2);
                tempCustomer.Country = reader.GetString(3);
                if (!reader.IsDBNull(4))
                {
                    tempCustomer.PostalCode = reader.GetString(4);
                }
                if (!reader.IsDBNull(5))
                {
                    tempCustomer.PhoneNumber = reader.GetString(5);
                }
                tempCustomer.Email = reader.GetString(6);
                decimal total =  reader.GetDecimal(7);
                whoSpentTheMost.Add(tempCustomer, total);
            }

            return new CustomerSpender(whoSpentTheMost);
        }

        public CustomerGenre MostPopularGenre(Customer customer)
        {
            using SqlConnection connection = new(DbConfig.GetConnectionString());
            connection.Open();

            string sqlQuery = $@"
                                SELECT TOP 1 WITH TIES
                                    g.Name AS FavoriteGenre
                                FROM INVOICE i
                                JOIN INVOICELINE il ON i.InvoiceId = il.InvoiceId
                                JOIN TRACK t ON il.TrackId = t.TrackId
                                JOIN GENRE g ON t.GenreId = g.GenreId
                                WHERE i.CustomerId = @Id
                                GROUP BY g.Name
                                ORDER BY COUNT(*) DESC;";

            using SqlCommand command = new(sqlQuery, connection);

            command.Parameters.AddWithValue("@Id", customer.Id);

            string customersFavoriteGenre = "None";

            using SqlDataReader reader = command.ExecuteReader();

            bool FirstLine = true;

            while (reader.Read())
            {
                if (FirstLine)
                    customersFavoriteGenre = "";
                if (!FirstLine)
                    customersFavoriteGenre += " & ";
                customersFavoriteGenre += reader.GetString(0);
                FirstLine = false;
            }

            return new CustomerGenre(customersFavoriteGenre, customer);
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
