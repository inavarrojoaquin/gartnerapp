using Domain.ProviderItems;
using Infrastructure.Persistance;
using System.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Database database;
        public ProductRepository(Database database)
        {
            this.database = database;
        }
        public void Insert(IProduct item)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("List of users from database:");
                        while (reader.Read())
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string email = reader["email"].ToString();

                            Console.WriteLine("User: " + firstName + " " + lastName + "Email: " + email);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
