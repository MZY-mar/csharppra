using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using ApplicationCore.Entities;
using System.Data;
using Dapper;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employees>
    {
        private readonly DapperDbContext _dbContext;
        public  EmployeeRepository()
        {
            _dbContext = new DapperDbContext();
        }

         public int Insert(Employees employee)
    {
        using (IDbConnection connection = _dbContext.GetConnection())
        {
            string sql = @"INSERT INTO Employees (FirstName, LastName, Salary, DeptId) VALUES (@FirstName, @LastName, @Salary, @DeptId); SELECT CAST(SCOPE_IDENTITY() as int)";
            return connection.Query<int>(sql, employee).Single();
        }
    }

    public int Update(Employees employee)
    {
        using (IDbConnection connection = _dbContext.GetConnection())
        {
            string sql = @"UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary, DeptId = @DeptId WHERE Id = @Id";
            return connection.Execute(sql, employee);
        }
    }

    public int DeleteById(int id)
    {
        using (IDbConnection connection = _dbContext.GetConnection())
        {
            string sql = @"DELETE FROM Employees WHERE Id = @Id";
            return connection.Execute(sql, new { Id = id });
        }
    }

    public Employees GetById(int id)
    {
        using (IDbConnection connection = _dbContext.GetConnection())
        {
            string sql = @"SELECT * FROM Employees WHERE Id = @Id";
            return connection.QueryFirstOrDefault<Employees>(sql, new { Id = id });
        }
    }

    public IEnumerable<Employees> GetAll()
    {
        using (IDbConnection connection = _dbContext.GetConnection())
        {
            string sql = @"SELECT * FROM Employees";
            return connection.Query<Employees>(sql);
        }
    }
    }
}