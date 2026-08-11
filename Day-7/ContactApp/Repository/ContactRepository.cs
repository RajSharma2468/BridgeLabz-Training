using Microsoft.Data.SqlClient;
using ContactApp.Model;

namespace ContactApp.Repository
{
    // Implements contact data access using SQL Server
    public class ContactRepository : IContactRepository
    {
        // Connection string for database
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=ContactRepoDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Fetches all contact records
        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT ContactId, Name, Phone, Email FROM Contacts", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact c = new Contact();
                        c.ContactId = (int)reader["ContactId"];
                        c.Name = reader["Name"].ToString();
                        c.Phone = reader["Phone"].ToString();
                        c.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                        contacts.Add(c);
                    }
                }
            }
            return contacts;
        }

        // Fetches single contact by id
        public Contact GetById(int id)
        {
            Contact contact = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT ContactId, Name, Phone, Email FROM Contacts WHERE ContactId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contact = new Contact();
                        contact.ContactId = (int)reader["ContactId"];
                        contact.Name = reader["Name"].ToString();
                        contact.Phone = reader["Phone"].ToString();
                        contact.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                    }
                }
            }
            return contact;
        }

        // Inserts new contact record
        public void Add(Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Contacts (Name, Phone, Email) VALUES (@Name, @Phone, @Email)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Email", (object)contact.Email ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Updates existing contact record
        public void Update(int id, Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Contacts SET Name = @Name, Phone = @Phone, Email = @Email WHERE ContactId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Email", (object)contact.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a contact record
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Contacts WHERE ContactId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}