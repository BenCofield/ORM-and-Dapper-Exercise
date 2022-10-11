using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute($"INSERT INTO products (name, price, categoryID) VALUES (@name, @price, @categoryID)", new {name, price, categoryID});
        }

    }
}
