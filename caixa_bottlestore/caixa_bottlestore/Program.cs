using caixa_bottlestore.Forms;
using caixa_bottlestore.Data;
using System;
using System.Windows.Forms;

namespace caixa_bottlestore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // para .NET 6+







            // Verifica conexão com o banco de dados
            if (!Db.TestConnection())
            {
                var errorMsg = Db.GetConnectionError();
                MessageBox.Show($"Não foi possível conectar ao banco de dados:\n{errorMsg}\n\n" +
                    "Verifique se:\n" +
                    "1. O MySQL está rodando\n" +
                    "2. O banco 'bottle_store' existe\n" +
                    "3. As credenciais estão corretas\n\n" +
                    "Execute o script 'database_setup.sql' no MySQL para criar o banco.", 
                    "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Application.Run(new MainForm());
        }
    }
}
