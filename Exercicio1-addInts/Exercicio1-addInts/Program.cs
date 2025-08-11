using System;

class exercicio1
{
    static void AddInts(out int soma, out bool sucesso)
    {
        soma = 0;
        sucesso = true;

        Console.WriteLine("Digite 5 numeros inteiros:");

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"numero {i} : ");
            string entrada = Console.ReadLine();


            if (int.TryParse(entrada, out int numero))
            {

                soma += numero;
            }
            else
            {

                sucesso = false;
                soma = 0;
                break;
            }
        }

    }
    static void Main(string[] args)
    {

        AddInts(out int resultado, out bool ok);


        if (ok)
        {
            Console.WriteLine(($"Somaa concluida com sucesso! Resultado: {resultado}"));




        }
        else
        {

            Console.WriteLine("erro: entrada invalida");

        }




    }






}