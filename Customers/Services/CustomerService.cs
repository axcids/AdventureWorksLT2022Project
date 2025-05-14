using Customers.ObjectModels;
using Microsoft.Data.SqlClient;
using System.Text;

namespace Customers.Services; 
public class CustomerService {

    private string _connectionString;

    public CustomerService(string ConnectionString) {
        _connectionString = ConnectionString;
    }
    public async Task<List<Output>> GetAllCustomers() {
        using (var connection = new SqlConnection(_connectionString)) {
            await connection.OpenAsync();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT CustomerID, FirstName, LastName FROM SalesLt.Customer");
            SqlCommand cmd = new SqlCommand(query.ToString(), connection);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            List<Output> customers = new List<Output>();

            while (reader.Read()) {
                customers.Add(new Output {
                    CustomerID = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2)
                });
            }

            return customers;

        }
    }

}
