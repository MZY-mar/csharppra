using Infrastructure.Data;
using System.Data.SqlClient;
using System.Data;
using dapperpra.Menu;


DapperDbContext dapperDbContext = new DapperDbContext();
IDbConnection connection = dapperDbContext.GetConnection();

//test the connection is successful
//  connection.Open();
    
//     if (connection.State == ConnectionState.Open)
//     {
//         Console.WriteLine("Connection opened successfully.");
//     }
//     else
//     {
//         Console.WriteLine("Connection failed to open.");
//     }

 MenuSelection menuSelection = new MenuSelection();
 menuSelection.Run();