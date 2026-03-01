using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GreenLifeManagementSystem.Data
{
    public class DatabaseHelper
    {
        
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\Users\LENOVO\source\repos\GreenLifeManagementSystem\GreenLifeManagementSystem\GreenLifeDB.mdf;Integrated Security=True";

        public void ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDataTable(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
    }
}