using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;

namespace dapperpra.Menu
{
    public class MenuSelection
    {
        private readonly DepartmentService _departmentService;
        private readonly EmployeeService _employeesService;

        public MenuSelection()
        {
            _departmentService = new DepartmentService();
            _employeesService = new EmployeeService();
        }

        public void Run()
        {
            Console.WriteLine("Please select a service to use:");
            Console.WriteLine("1. Department Service");
            Console.WriteLine("2. Employees Service");

            int choice = InputChoice();

            switch (choice)
            {
                case 1:
                    DepartmentServiceMenu();
                    break;
                case 2:
                    EmployeesServiceMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        public int InputChoice()
        {
            int choice = 0;
            while (choice == 0)
            {
                Console.Write("Enter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }

        private void DepartmentServiceMenu()
        {
            while (true)
            {
                Console.WriteLine("Department Service Menu:");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Delete Department");
                Console.WriteLine("3. Get All Departments");
                Console.WriteLine("4. Get Department By Id");
                Console.WriteLine("5. Update Department");
                Console.WriteLine("0. Exit");

                int choice = InputChoice();

                switch (choice)
                {
                    case 1:
                        _departmentService.AddDepartment();
                        break;
                    case 2:
                        _departmentService.DeleteDepartment();
                        break;
                    case 3:
                        _departmentService.GetAllDepartments();
                        break;
                    case 4:
                        _departmentService.GetDepartmentById();
                        break;
                    case 5:
                        _departmentService.UpdateDepartment();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void EmployeesServiceMenu()
        {
            while (true)
            {
                Console.WriteLine("Employees Service Menu:");
                Console.WriteLine("1. Add Employees");
                Console.WriteLine("2. Delete Employees");
                Console.WriteLine("3. Get All Employees");
                Console.WriteLine("4. Get Employee By Id");
                Console.WriteLine("5. Update Employees");
                Console.WriteLine("0. Exit");

                int choice = InputChoice();

                switch (choice)
                {
                    case 1:
                        _employeesService.AddEmployees();
                        break;
                    case 2:
                        _employeesService.DeleteEmployees();
                        break;
                    case 3:
                        _employeesService.GetAllEmployees();
                        break;
                    case 4:
                        _employeesService.GetEmployeeById();
                        break;
                    case 5:
                        _employeesService.UpdateEmployees();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}