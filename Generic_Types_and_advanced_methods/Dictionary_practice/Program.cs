using System.Diagnostics.Contracts;

// List of employees
var employess = new List<Employee>
{
    new Employee("Jake Smith", "Space Navigation", 25000),
    new Employee("Anna Blake", "Space Navigation", 25000),
    new Employee("Barbara Oak", "Xenobiology", 25000),
    new Employee("Damian Parker", "Xenobiology", 25000),
    new Employee("Nisha Patel", "Mechanics", 25000),
    new Employee("Gustavo Sanchez", "Mechanics", 25000),
};

// method to calculate average salary per department
var result = CalculateAverageSalaryPerDepartament(employess);

Console.ReadKey();

// signature of a method - it returns a dictionary and takes an IEnumerable interface
Dictionary<string, decimal> CalculateAverageSalaryPerDepartament(
    IEnumerable<Employee> employess)
{
    // a dictionary that will be used to seperate employees per each department
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();

    // a loop to iterate a List of employees
    foreach(var employee in employess)
    {
        // if sepcific key does not exists, create this key and empty list:
        // List<Emplyee> for that specific key
        if(!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department] = new List<Employee>();
        }
        
        // add for a key: Department an Employee to the List<Employee>
        employeesPerDepartments[employee.Department].Add(employee);
    }

    // a Dictionary that will be returned
    var result = new Dictionary<string, decimal>();

    // iterating employees in order to calculate averag salary for a specific Department
    foreach(var employeesPerDepartment in employeesPerDepartments)
    {
        decimal sumOfSalaries = 0;

        foreach(var employee in employeesPerDepartment.Value)
        {
            sumOfSalaries += employee.MonthlySalary;
        }

        var average = sumOfSalaries / employeesPerDepartment.Value.Count;

        result[employeesPerDepartment.Key] = average;
    }

    return result;
}

public class Employee
{
    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }

    public string Name { get; init; }
    public string Department{ get; init; }
    public decimal MonthlySalary { get; init; }
}