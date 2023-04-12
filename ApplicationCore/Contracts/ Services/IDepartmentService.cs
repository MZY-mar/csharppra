using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts. Services
{
    public interface IDepartmentService
    {
        void AddDepartment();
        void DeleteDepartment();
        void GetAllDepartments();
        Departments GetDepartmentById();
        void UpdateDepartment();
    }
}