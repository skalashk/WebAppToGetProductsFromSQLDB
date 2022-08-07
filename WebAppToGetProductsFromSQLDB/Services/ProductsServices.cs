using System.Data.SqlClient;
using WebAppToGetProductsFromSQLDB.Model;

namespace WebAppToGetProductsFromSQLDB.Services
{
    public class ProductsServices
    {
        public class ProductServices
        {
            private static string db_source = "skalashk-db-server.database.windows.net";
            private static string db_user = "skalashk";
            private static string db_password = "Kalashkam@27";
            private static string db_database = "skalashkDB";
            public SqlConnection GetConnection()
            {
                var _builder = new SqlConnectionStringBuilder();
               
                _builder.DataSource = db_source;
                _builder.UserID = db_user;
                _builder.Password = db_password;
                _builder.InitialCatalog = db_database;

                return new SqlConnection(_builder.ConnectionString);
            }

            public List<Products> GetProducts()
            {
                List<Products> products = new List<Products>();

                SqlConnection conn = GetConnection();
                conn.Open();

                string sqlcmd = "Select ProductID, ProductName, Quantity from Products";

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Products _product = new Products()
                        {
                            ProductId = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Quantity = reader.GetInt32(2)
                        };
                        products.Add(_product);
                    }
                }

                conn.Close();

                return products;

            }
        }
    }
}
