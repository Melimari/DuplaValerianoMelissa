using System;

class Calculadora
{
    static void Main()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("===== CALCULADORA =====");
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicar");
            Console.WriteLine("4 - Dividir");
            Console.WriteLine("5 - Resto da Divisão");
            Console.WriteLine("6 - Potenciação");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 0)
            {
                Console.WriteLine("Saindo da calculadora...");
                break;
            }

            if (opcao < 0 || opcao > 6)
            {
                Console.WriteLine("Opção inválida!");
                Console.ReadLine();
                continue;
            }

            Console.Write("Digite o primeiro valor: ");
            double valor1 = double.Parse(Console.ReadLine());

            Console.Write("Digite o segundo valor: ");
            double valor2 = double.Parse(Console.ReadLine());

            double resultado = 0;
            bool valido = true;

            switch (opcao)
            {
                case 1:
                    resultado = valor1 + valor2;
                    break;
                case 2:
                    resultado = valor1 - valor2;
                    break;
                case 3:
                    resultado = valor1 * valor2;
                    break;
                case 4:
                    if (valor2 == 0)
                    {
                        Console.WriteLine("Não é possível dividir por zero.");
                        valido = false;
                    }
                    else
                        resultado = valor1 / valor2;
                    break;
                case 5:
                    if (valor2 == 0)
                    {
                        Console.WriteLine("Não é possível dividir por zero.");
                        valido = false;
                    }
                    else
                        resultado = valor1 % valor2;
                    break;
                case 6:
                    resultado = Math.Pow(valor1, valor2);
                    break;
            }

            if (valido)
            {
                Console.WriteLine($"Resultado: {resultado}");
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

        } while (opcao != 0);
    }
}
