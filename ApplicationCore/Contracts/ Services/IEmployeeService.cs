using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts. Services
{
    public interface IEmployeeService
    {
        void AddEmployees();
        void DeleteEmployees();
        void GetAllEmployees();
        Employees GetEmployeeById();
        void UpdateEmployees();
    }
}