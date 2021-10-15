using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        EFCoreDemoDbContext context = new();
        EmployeeRepository employeeRepository = new (context);

        //_context.Database.EnsureCreated(); // normally used for testing
        employeeRepository.GetEmployees();

        //AddEmployee();
        //AddEmployeeWithIDInsert(500);
        //GetEmployees();

        //GetEmployees();
        //UpdateEmployee();
        //GetEmployees();

        //GetEmployees();
        //DeleteEmployee();
        //GetEmployees();

        //GetEmployeesByNonIdColumn();

        //GetDepartmentsWithEmployees();
        //AddDepartmentsWithEmployees();

        //GetDepartmentFromEmployee();

        //AddEmployee();
    }
}
