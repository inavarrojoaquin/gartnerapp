using Infrastructure.Workers;
using System.Data;

namespace Infrastructure.Managers
{
    class UsersManager : DatabaseWorker
    {
        public static void GetUsers()
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand("SELECT * FROM users", connection))
                {
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
