using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            string connString = config.GetConnectionString("DefaultConnection");
            
            IDbConnection conn = new MySqlConnection(connString);

            //Department Repo Demo
            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("Misc");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }

            //Product Repo Demo
            var productRepo = new DapperProductRepository(conn);

            productRepo.CreateProduct("iPhone 13", 799.00, 3);

            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name} {product.Price} {product.CategoryID} {product.OnSale} {product.StockLevel}");
            }

        }
    }
}