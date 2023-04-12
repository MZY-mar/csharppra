using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Infrastructure.Data
{
    public class DapperDbContext 
    {
          IDbConnection dbConnection;

            public DapperDbContext()
        {
            //dbConnection = new SqlConnection("Data Source=.;Initial Catalog=MarchDapper2023;Integrated Security=True");
        }

        public IDbConnection GetConnection()
        {
            dbConnection = new SqlConnection("Server=localhost;Database=dapper;User Id=sa;Password=root1234;Integrated Security=False");
            return dbConnection;
        }
        
    }

        
}