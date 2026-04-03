using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBookSystem.Models;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Utilities;

namespace AddressBookSystem.Services
{
    public class DatabaseDataSource : IDataSource
    {
        private string connectionString =
    "Server=.\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public async Task AddContactAsync(Contact contact)
        {
            await Task.Run(async () =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query =
                        "INSERT INTO Contacts " +
                        "(FirstName, LastName, Address, City, State, Zip, Phone, Email) " +
                        "VALUES (@FirstName,@LastName,@Address,@City,@State,@Zip,@Phone,@Email)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@Zip", contact.Zip);
                    command.Parameters.AddWithValue("@Phone", contact.Phone);
                    command.Parameters.AddWithValue("@Email", contact.Email);

                    await command.ExecuteNonQueryAsync();
                }

                AudioNotifier.PlaySuccessSound();
            });
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Contacts";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Contact contact = new Contact();
                    contact.Id = (int)reader["Id"];
                    contact.FirstName = reader["FirstName"].ToString();
                    contact.LastName = reader["LastName"].ToString();
                    contact.City = reader["City"].ToString();

                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query =
                    "UPDATE Contacts SET FirstName=@FirstName, LastName=@LastName, " +
                    "Address=@Address, City=@City, State=@State, Zip=@Zip, " +
                    "Phone=@Phone, Email=@Email WHERE Id=@Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", contact.Id);
                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@State", contact.State);
                command.Parameters.AddWithValue("@Zip", contact.Zip);
                command.Parameters.AddWithValue("@Phone", contact.Phone);
                command.Parameters.AddWithValue("@Email", contact.Email);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteContactAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Contacts WHERE Id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
