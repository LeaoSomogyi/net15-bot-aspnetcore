using SimpleBotCore.Context;
using SimpleBotCore.Contracts;
using SimpleBotCore.Logic;
using System;
using System.Data.SqlClient;

namespace SimpleBotCore.Repositories
{
    public class SimpleMessageRepository : ISimpleMessageRepository
    {
        private readonly SQLServerConnectionSettings _settings;

        public SimpleMessageRepository(SQLServerConnectionSettings settings)
        {
            _settings = settings;
        }

        public int CountMessages(string id)
        {
            SqlConnection connection = new SqlConnection(_settings.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select count(*) from TBMessage where id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                int count = (int)command.ExecuteScalar();
                return count;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }

        public void Insert<T>(T entity) where T : SimpleMessage
        {
            SimpleMessage message = entity as SimpleMessage;

            SqlConnection connection = new SqlConnection(_settings.ConnectionString);

            try
            {
                connection.Open();

                string command = "INSERT INTO TBMessage VALUES (@Id, @User, @Text)";

                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Id", message.Id);
                sqlCommand.Parameters.AddWithValue("@User", message.User);
                sqlCommand.Parameters.AddWithValue("@Text", message.Text);

                sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
