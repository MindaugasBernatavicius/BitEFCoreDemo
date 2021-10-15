using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Department> Departments { get; set; }
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public Employee(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"{{ Id: {Id} : Name: { Name } }}";
    }
}


