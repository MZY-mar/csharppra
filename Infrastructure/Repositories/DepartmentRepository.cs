using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Dapper;


namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository<Departments>
    {

        private readonly DapperDbContext _dbContext;
        public DepartmentRepository()
        {
            _dbContext = new DapperDbContext();
        }

        public int DeleteById(int id ){
            using (IDbConnection connection = _dbContext.GetConnection()){
                return connection.Execute("Delete from Departments where id = @Id",new {Id = id});
            }
        }
        //DynamicParameters can be a useful tool for building dynamic SQL queries and stored procedures, and for parameterizing SQL queries to protect against SQL injection attack
         public int Insert(Departments obj){
            using (IDbConnection connection = _dbContext.GetConnection()){
               DynamicParameters dynamic = new DynamicParameters();
            //    dynamic.Add("Id", obj.Id);
            //    dynamic.Add("DeptName",obj.DeptName);
            //    dynamic.Add("Location",obj.Location);
            return connection.Execute("Insert Into Departments Values(@DeptName, @Location)", obj);
            }
         }
        public int Update(Departments obj){
             using (IDbConnection connection = _dbContext.GetConnection()){
                 return connection.Execute("Update Departments set DeptNAme = @DeptName, Location = @Location Where Id = @Id)", obj);
             }
        }
    
       public Departments GetById(int id){
        using (IDbConnection connection = _dbContext.GetConnection()){
            return connection.QuerySingleOrDefault<Departments>("Select * from Departments where Id = @id", new{Id = id});
        }
       }
      public  IEnumerable<Departments> GetAll(){
        using(IDbConnection connection = _dbContext.GetConnection()){
            return connection.Query<Departments>("Select Id, DeptName, Location From Departments");
        }
      }
    }
}