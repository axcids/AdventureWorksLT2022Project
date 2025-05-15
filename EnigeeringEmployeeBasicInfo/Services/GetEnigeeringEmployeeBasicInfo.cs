using EnigeeringEmployeeBasicInfo.Object_Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Abstractions;
using System.Text;

namespace EnigeeringEmployeeBasicInfo.Services; 
public class GetEnigeeringEmployeeBasicInfo {

    private string _connectionString;

    public GetEnigeeringEmployeeBasicInfo(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<EnigeeringEmployeeOutput>> GetAllEnigeeringEmployeeBasicInfo() {
        using (var connection = new SqlConnection(_connectionString)) {
            await connection.OpenAsync();
            StringBuilder query = new StringBuilder();

            query.AppendLine("USE AdventureWorks2022");
            query.AppendLine("SELECT person.BusinessEntityID,employee.NationalIDNumber,person.FirstName,person.LastName");
            query.AppendLine("From Person.Person AS person " +
                "INNER JOIN HumanResources.Employee AS employee " +
                "ON person.BusinessEntityID = employee.BusinessEntityID " +
                "INNER JOIN HumanResources.EmployeeDepartmentHistory AS EmployeeDepartmentHistory " +
                "ON employee.BusinessEntityID = EmployeeDepartmentHistory.BusinessEntityID");
            query.AppendLine("WHERE EmployeeDepartmentHistory.DepartmentID = 1");
            query.AppendLine("ORDER BY person.BusinessEntityID ASC;");
            Console.WriteLine(query.ToString());
            SqlCommand cmd = new SqlCommand(query.ToString(), connection);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            List<EnigeeringEmployeeOutput> employees = new List<EnigeeringEmployeeOutput>();

            while (reader.Read()) {
                employees.Add(new EnigeeringEmployeeOutput {
                    BusinessEntityID = reader.GetInt32(0),
                    NationalNumber = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3)
                });
            }
            return employees;
        }
    }

}
