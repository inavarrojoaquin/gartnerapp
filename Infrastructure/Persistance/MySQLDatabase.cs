using Application.Database;
using System.Data;

namespace Infrastructure.Persistance
{
    public class MySQLDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnector.MySqlConnection(connectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new MySqlConnector.MySqlCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            MySqlConnector.MySqlConnection connection = (MySqlConnector.MySqlConnection)CreateConnection();
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            MySqlConnector.MySqlCommand command = (MySqlConnector.MySqlCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (MySqlConnector.MySqlConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            MySqlConnector.MySqlCommand command = (MySqlConnector.MySqlCommand)CreateCommand();

            command.CommandText = procName;
            command.Connection = (MySqlConnector.MySqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new MySqlConnector.MySqlParameter(parameterName, parameterValue);
        }
    }
}
