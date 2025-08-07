using System;
using MySql.Data.MySqlClient;

namespace MiniCaixaBottleStore

{

    class Program
    {
        static string conexao = "server=localhost;port=3307;database=bottle_store;uid=root;pwd=12345;";



        static void Main(string[] args)
        {
            TestarConexao();

            while (true)
            {
                Console.WriteLine("\n==== MINI CAIXA BOTTLE STORE ====");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarProduto()
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            using (var conexaoDB = new MySqlConnection(conexao))
            {
                conexaoDB.Open();
                string sql = "INSERT INTO produtos (nome, preco, quantidade) VALUES (@nome, @preco, @quantidade)";
                using (var cmd = new MySqlCommand(sql, conexaoDB))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("✅ Produto adicionado com sucesso!");
                }
            }
        }

        static void ListarProdutos()
        {
            using (var conexaoDB = new MySqlConnection(conexao))
            {
                conexaoDB.Open();
                string sql = "SELECT * FROM produtos";
                using (var cmd = new MySqlCommand(sql, conexaoDB))
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n📦 Produtos no Estoque:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]} | Nome: {reader["nome"]} | Preço: {reader["preco"]} | Quantidade: {reader["quantidade"]}");
                    }
                }
            }
        }
        static void TestarConexao()
        {
            try
            {
                using (var conexaoDB = new MySqlConnection(conexao))
                {
                    conexaoDB.Open();
                    Console.WriteLine("✅ Conexão bem-sucedida ao banco de dados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Erro ao conectar: " + ex.Message);
            }
        }

    }
}


