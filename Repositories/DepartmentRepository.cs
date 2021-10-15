using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class DepartmentRepository
{
    private static EFCoreDemoDbContext _context;

    public DepartmentRepository(EFCoreDemoDbContext context)
    {
        _context = context;
    }

    static void GetDepartmentsWithEmployees()
    {
        var deps = _context.Departments.Include("Employees");
        foreach (var dep in deps)
        {
            Console.WriteLine(dep.Id);
            Console.WriteLine(dep.Name);
            Console.WriteLine(dep.Employees != null ? dep.Employees.Count : 0);
            if (dep.Employees != null)
            {
                foreach (var employee in dep.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }

    static void AddDepartmentsWithEmployees()
    {
        var dName = "HR";
        var nEmp = new Employee("Zigmas");
        var mDep = _context.Departments
            .Include("Employees")
            .Where(d => d.Name == dName).First();

        mDep.Employees.Add(nEmp);
        _context.SaveChanges();
    }

    static void GetDepartmentFromEmployee()
    {
        //var e = _context.Employees
        //    .Include("Department")
        //    .Where(e => e.Id == 65).First();
        //Console.WriteLine($"{{ {e.Department.Id} {e.Department.Name} }}");

        //var empl = _context.Employees.Find(65);
        //var dep = _context.Departments.Find(empl.DepartmentId);
        //Console.WriteLine($"{{ {dep.Id} {dep.Name} }}");
    }

}