using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class EmployeeService: IEmployeeService
{
    private readonly EmployeeRepository _repository;

    public EmployeeService ()
    {
        _repository = new EmployeeRepository();
    }

    public void AddEmployees()
    {
        Employees employee = new Employees();
        Console.Write("Enter First Name: ");
        employee.FirstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        employee.LastName = Console.ReadLine();
        Console.Write("Enter Salary: ");
        employee.Salary = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter DeptId: ");
        employee.DeptId = Convert.ToInt32(Console.ReadLine());

        if (_repository.Insert(employee) > 0)
        {
            Console.WriteLine("Successfully Inserted");
        }
        else
        {
            Console.WriteLine("Error");
        }
    }

    public void DeleteEmployees()
    {
        Console.Write("Enter Id number to Delete: ");
        int id = Convert.ToInt32(Console.ReadLine());
        _repository.DeleteById(id);
    }

    public void GetAllEmployees()
    {
        IEnumerable<Employees> employees = _repository.GetAll();
        Console.WriteLine("ID \t FirstName \t LastName \t Salary \t DeptId");
        Console.WriteLine("-------------------------------------------------");
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.Id} \t {employee.FirstName} \t {employee.LastName} \t {employee.Salary} \t {employee.DeptId}");
        }
    }

    public Employees GetEmployeeById()
    {
        Console.Write("Enter Id number to Get: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Employees employee = _repository.GetById(id);
        Console.WriteLine($"{employee.Id} \t {employee.FirstName} \t {employee.LastName} \t {employee.Salary} \t {employee.DeptId}");
        return employee;
    }

    public void UpdateEmployees()
    {
        var employee = GetEmployeeById();
        Console.Write("Enter New First Name: ");
        employee.FirstName = Console.ReadLine();
        Console.Write("Enter New Last Name: ");
        employee.LastName = Console.ReadLine();
        Console.Write("Enter New Salary: ");
        employee.Salary = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter New DeptId: ");
        employee.DeptId = Convert.ToInt32(Console.ReadLine());

        _repository.Update(employee);
    }

      
    }
    }