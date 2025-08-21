using System;

class Drone
{
   
    static double altura = 0;               
    static int direcao = 0;              
    static double velocidade = 0;          
    static bool proximoObjeto = false;    

   
    class Braco
    {
        public bool CotoveloContraido = false;
        public int Pulso = 0;               
        public string Estado = "Repouso";   
        public bool Ocupado = false;        
    }

    static Braco bracoEsq = new Braco();
    static Braco bracoDir = new Braco();

    static int cameraHorizontal = 0;  
    static int cameraVertical = 0;    
    static bool gravandoVideo = false;

    static void Main()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine(" CONTROLE DO DRONE ");
            Console.WriteLine($"Altura: {altura} m | Direcao: {direcao}° | Velocidade: {velocidade} m/s");
            Console.WriteLine($"Aproximacao de objeto: {(proximoObjeto ? "Sim" : "nao")}");
            Console.WriteLine();
            Console.WriteLine("1 - Controlar altura");
            Console.WriteLine("2 - Controlar direção");
            Console.WriteLine("3 - Controlar velocidade");
            Console.WriteLine("4 - Aproximacao de objeto");
            Console.WriteLine("5 - Controle dos bracos");
            Console.WriteLine("6 - Controle da camera");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

            switch (opcao)
            {
                case 1: MenuAltura(); break;
                case 2: MenuDirecao(); break;
                case 3: MenuVelocidade(); break;
                case 4: MenuAproximacao(); break;
                case 5: MenuBracos(); break;
                case 6: MenuCamera(); break;
                case 0: Console.WriteLine("Saindo..."); break;
                default: Console.WriteLine("Opção invalida!"); break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

  
    static void MenuAltura()
    {
        if (proximoObjeto) { Console.WriteLine("Nao pode alterar altura durante aproximacao."); return; }

        Console.WriteLine("\n1 - Definir altura especifica");
        Console.WriteLine("2 - Subir 0.5m");
        Console.WriteLine("3 - Descer 0.5m");
        Console.Write("Escolha: ");
        int op = int.Parse(Console.ReadLine());

        if (op == 1)
        {
            Console.Write("Digite altura (0.5 a 25): ");
            double nova = double.Parse(Console.ReadLine());
            if (nova >= 0.5 && nova <= 25) altura = nova;
            else Console.WriteLine("Altura fora dos limites.");
        }
        else if (op == 2 && altura + 0.5 <= 25) altura += 0.5;
        else if (op == 3 && altura - 0.5 >= 0.5) altura -= 0.5;
        else Console.WriteLine("Movimento invalido.");
    }

    static void MenuDirecao()
    {
        if (proximoObjeto) { Console.WriteLine("Nao pode alterar direcao durante aproximacao."); return; }

        Console.WriteLine("\n1 - Definir angulo especifico (0 a 360)");
        Console.WriteLine("2 - Virar esquerda 5°");
        Console.WriteLine("3 - Virar direita 5°");
        Console.Write("Escolha: ");
        int op = int.Parse(Console.ReadLine());

        if (op == 1)
        {
            Console.Write("Digite angulo (0 a 360): ");
            direcao = (int.Parse(Console.ReadLine()) + 360) % 360;
        }
        else if (op == 2) direcao = (direcao - 5 + 360) % 360;
        else if (op == 3) direcao = (direcao + 5) % 360;
    }

   
    static void MenuVelocidade()
    {
        if (proximoObjeto) { Console.WriteLine("Nao pode alterar velocidade durante aproximacao."); return; }

        Console.WriteLine("\n1 - Aumentar 0.5 m/s");
        Console.WriteLine("2 - Diminuir 0.5 m/s");
        Console.Write("Escolha: ");
        int op = int.Parse(Console.ReadLine());

        if (op == 1 && velocidade + 0.5 <= 15) velocidade += 0.5;
        else if (op == 2 && velocidade - 0.5 >= 0) velocidade -= 0.5;
        else Console.WriteLine("Velocidade invalida.");
    }

    static void MenuAproximacao()
    {
        if (!proximoObjeto)
        {
            if (velocidade == 0)
            {
                proximoObjeto = true;
                Console.WriteLine("Drone aproximado de objeto.");
            }
            else Console.WriteLine("Pare o drone antes de aproximar.");
        }
        else
        {
            proximoObjeto = false;
            Console.WriteLine("Drone se afastou do objeto.");
        }
    }

   
    static void MenuBracos()
    {
        if (!proximoObjeto) { Console.WriteLine("Aproxime de um objeto antes de usar os bracos."); return; }

        Console.WriteLine("\n1 - Cotovelo Esquerdo (Repouso/Contraido)");
        Console.WriteLine("2 - Cotovelo Direito (Repouso/Contraido)");
        Console.WriteLine("3 - Pegar objeto (Esquerdo/Direito)");
        Console.WriteLine("4 - Armazenar objeto (Esquerdo/Direito)");
        Console.Write("Escolha: ");
        int op = int.Parse(Console.ReadLine());

        if (op == 1) bracoEsq.CotoveloContraido = !bracoEsq.CotoveloContraido;
        else if (op == 2) bracoDir.CotoveloContraido = !bracoDir.CotoveloContraido;
        else if (op == 3) PegarObjeto();
        else if (op == 4) ArmazenarObjeto();
    }

    static void PegarObjeto()
    {
        if (bracoEsq.CotoveloContraido && !bracoEsq.Ocupado)
        {
            bracoEsq.Ocupado = true;
            Console.WriteLine("Braco esquerdo pegou objeto.");
        }
        else if (bracoDir.CotoveloContraido && !bracoDir.Ocupado)
        {
            bracoDir.Ocupado = true;
            Console.WriteLine("Braco direito pegou objeto.");
        }
        else Console.WriteLine("Não foi possível pegar objeto.");
    }

    static void ArmazenarObjeto()
    {
        if (bracoEsq.Ocupado && !bracoEsq.CotoveloContraido)
        {
            bracoEsq.Ocupado = false;
            Console.WriteLine("Braco esquerdo armazenou objeto.");
        }
        else if (bracoDir.Ocupado && !bracoDir.CotoveloContraido)
        {
            bracoDir.Ocupado = false;
            Console.WriteLine("Braco direito armazenou objeto.");
        }
        else Console.WriteLine("nao foi possível armazenar.");
    }

    static void MenuCamera()
    {
        Console.WriteLine("\n1 - Girar horizontal (°)");
        Console.WriteLine("2 - Girar vertical (°)");
        Console.WriteLine("3 - Tirar foto");
        Console.WriteLine("4 - Iniciar/Parar vídeo");
        Console.Write("Escolha: ");
        int op = int.Parse(Console.ReadLine());

        if (op == 1)
        {
            Console.Write("Novo angulo horizontal: ");
            cameraHorizontal = (int.Parse(Console.ReadLine()) + 360) % 360;
        }
        else if (op == 2)
        {
            Console.Write("Novo angulo vertical (-90 a 90): ");
            cameraVertical = Math.Max(-90, Math.Min(90, int.Parse(Console.ReadLine())));
        }
        else if (op == 3) Console.WriteLine("Foto capturada!");
        else if (op == 4)
        {
            gravandoVideo = !gravandoVideo;
            Console.WriteLine(gravandoVideo ? " Gravando vídeo..." : " Vídeo parado.");
        }
    }
}
