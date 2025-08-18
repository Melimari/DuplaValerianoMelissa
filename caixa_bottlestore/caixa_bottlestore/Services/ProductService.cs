using caixa_bottlestore.Data;
using caixa_bottlestore.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace caixa_bottlestore.Services
{
    public class ProductService
    {
        public IEnumerable<Product> GetAll()
        {
            using var conn = Db.GetConnection();
            return conn.Query<Product>("SELECT * FROM products WHERE active=1 ORDER BY name;");
        }

        public Product GetById(int id)
        {
            using var conn = Db.GetConnection();
            return conn.QueryFirstOrDefault<Product>("SELECT * FROM products WHERE id=@Id;", new { Id = id });
        }

        public void Add(Product p)
        {
            using var conn = Db.GetConnection();
            conn.Execute(@"INSERT INTO products (code,name,category,price,stock,low_stock_threshold,active)
                       VALUES (@Code,@Name,@Category,@Price,@Stock,@LowStockThreshold,@Active);", p);
        }

        public void Update(Product p)
        {
            using var conn = Db.GetConnection();
            conn.Execute(@"UPDATE products SET code=@Code,name=@Name,category=@Category,price=@Price,stock=@Stock,low_stock_threshold=@LowStockThreshold,active=@Active WHERE id=@Id;", p);
        }

        public void Delete(int id)
        {
            using var conn = Db.GetConnection();
            // Estratégia: soft delete para preservar histórico
            conn.Execute("UPDATE products SET active=0 WHERE id=@Id;", new { Id = id });
        }

        public void ChangeStock(int productId, int delta, int userId, string? reason = null)
        {
            using var conn = Db.GetConnection();
            using var tx = conn.BeginTransaction();
            try
            {
                conn.Execute("UPDATE products SET stock = stock + @Delta WHERE id=@Id;", new { Delta = delta, Id = productId }, tx);
                conn.Execute("INSERT INTO stock_movements (product_id, change_amount, reason, user_id) VALUES (@Pid, @Delta, @Reason, @UserId);",
                             new { Pid = productId, Delta = delta, Reason = reason, UserId = userId }, tx);
                tx.Commit();
            }
            catch
            {
                try { tx.Rollback(); } catch { }
                throw;
            }
        }
    }
}
