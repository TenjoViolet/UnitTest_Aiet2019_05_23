using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;
namespace UnitTestLab1.Repository
{
    public class ProductRepository : IProductRepository
    {
        public virtual List<Product> SelectFruits()
        {
            var dt = new DataTable();
            var connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            using (var sqlConn = new SqlConnection(connString))
            {
                var sql = "select * from Product where Type = N'水果'";
                using (var sqlCmd = new SqlCommand(sql, sqlConn))
                {
                    sqlConn.Open();

                    dt.Load(sqlCmd.ExecuteReader());
                }
            }
            var result=dt.AsEnumerable().Select(p=> new Product
            {
                Name=p["Name"].ToString(),
                Price=p.Field<decimal>("Price")

            }).ToList();
            return result;
        }
    }
}
