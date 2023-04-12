using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {  
        private readonly DepartmentRepository _repository;

        public DepartmentService()
        {
            _repository  = new DepartmentRepository();
        }

        public void AddDepartment(){
             Departments d = new Departments();
            Console.Write("Enter name of Department: ");
            d.DeptName = Console.ReadLine();
            Console.Write("Enter Location: ");
            d.Location = Console.ReadLine();

            if ( _repository.Insert(d) > 0) //Reflects the number of records impacted
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public void DeleteDepartment(){
            Console.Write("Enter Id number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
             _repository.DeleteById(id);
        }
        public void GetAllDepartments(){ 
            IEnumerable<Departments> departments = _repository.GetAll();
             Console.WriteLine("ID \t DeptName \t Location");
            Console.WriteLine("-----------------------------------");
            foreach (var dept in departments)
            {
                Console.Write($"{dept.Id} \t {dept.DeptName}");
                Console.SetCursorPosition(20, Console.CursorTop);
                Console.WriteLine($"{dept.Location}");
            }
        }
        public Departments GetDepartmentById(){
              Console.Write("Enter Id number to Delete: ");
              int id = Convert.ToInt32(Console.ReadLine());
              Departments dept =  _repository.GetById(id);
              Console.Write($"{dept.Id} \t {dept.DeptName}");
              Console.SetCursorPosition(20, Console.CursorTop);
              Console.WriteLine($"{dept.Location}");
              return dept;
        }
       public void UpdateDepartment(){
            var dC = GetDepartmentById();
            Console.Write("Enter New Dept Name: ");
            dC.DeptName = Console.ReadLine();
            Console.Write("Enter New Location: ");
            dC.Location = Console.ReadLine();
            _repository.Update(dC);

        }
    }
}