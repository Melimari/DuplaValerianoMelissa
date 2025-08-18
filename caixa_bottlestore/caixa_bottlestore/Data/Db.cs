using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_bottlestore.Data
{
    using MySql.Data.MySqlClient;
    using System.Data;

    public static class Db
    {
        public static string ConnectionString
        {
            get
            {
                // Tenta ler de Settings; se não existir, cai no valor padrão existente
                try
                {
                    var cfg = caixa_bottlestore.Properties.Settings.Default.ConnectionString;
                    if (!string.IsNullOrWhiteSpace(cfg))
                    {
                        return cfg;
                    }
                }
                catch
                {
                    // Ignora e usa o default
                }

                return "server=localhost;port=3306;database=bottle_store;uid=root;pwd=;SslMode=none;";
            }
        }

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static bool TestConnection()
        {
            try
            {
                using var conn = GetConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetConnectionError()
        {
            try
            {
                using var conn = GetConnection();
                return null; // Sem erro
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
