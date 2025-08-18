using caixa_bottlestore.Data;
using caixa_bottlestore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using caixa_bottlestore.Data;
using caixa_bottlestore.Models;
using System.Collections.Generic;

namespace caixa_bottlestore.Services
{
    public class SaleService
    {
        public int AddSale(Sale sale, List<SaleItem> items)
        {
            using var conn = Db.GetConnection();
            using var tx = conn.BeginTransaction();
            try
            {
                string insertSaleSql = @"INSERT INTO sales (sale_date, total, payment_method, user_id) 
                                         VALUES (@SaleDate, @Total, @PaymentMethod, @UserId);
                                         SELECT LAST_INSERT_ID();";

                int saleId = conn.ExecuteScalar<int>(insertSaleSql, sale, tx);

                string insertItemSql = @"INSERT INTO sale_items (sale_id, product_id, quantity, unit_price) 
                                         VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice);";

                foreach (var item in items)
                {
                    item.SaleId = saleId;
                    conn.Execute(insertItemSql, item, tx);

                    // Atualiza estoque
                    conn.Execute("UPDATE products SET stock = stock - @Quantity WHERE id = @ProductId;", new { Quantity = item.Quantity, ProductId = item.ProductId }, tx);
                }

                tx.Commit();
                return saleId;
            }
            catch
            {
                try { tx.Rollback(); } catch { }
                throw;
            }
        }
    }
}

