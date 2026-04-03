using System;
using HealthCareApp.Models;
using HealthCareApp.Utilities;
using HealthCareApp.Attributes;
using Microsoft.Data.SqlClient;

namespace HealthCareApp.Services
{
    public class BillingService
    {
        [Audit("Generate Bill")]
        public void GenerateBill(int visitId, double amount)
        {
            Bill bill = new Bill
            {
                VisitID = visitId,
                Amount = amount,
                PaymentStatus = "UNPAID"
            };

            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Bills (VisitID, Amount, PaymentStatus)
                                    VALUES (@vid, @amt, @status);
                                    SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@vid", bill.VisitID);
                cmd.Parameters.AddWithValue("@amt", bill.Amount);
                cmd.Parameters.AddWithValue("@status", bill.PaymentStatus);

                bill.ID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Logger.Log("Bill " + bill.ID + " generated for visit " + visitId);
        }

        [Audit("Record Payment")]
        public void RecordPayment(int billId, string mode)
        {
            using (var conn = Database.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Bills SET PaymentStatus='PAID', PaymentDate=@pdate, PaymentMode=@mode WHERE ID=@id";
                cmd.Parameters.AddWithValue("@pdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@mode", mode);
                cmd.Parameters.AddWithValue("@id", billId);

                cmd.ExecuteNonQuery();
            }

            Logger.Log("Payment recorded for bill " + billId);
        }
    }
}
