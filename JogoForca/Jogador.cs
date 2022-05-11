using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace JogoForca;

public class Jogador
{
    // Vida   Fácil: 7 tentativas
    // Vida  Normal: 6 tentativas
    // Vida Dificil: 5 tentativas
    // Pontos (total de letras correctas)

    // Fields
    private static int facil = 7;
    private static int normal = 6;
    private static int dificil = 5;
    public int vida = 0;
    private int pontos = 0;

    // Constructor
    public Jogador(int vida)
    {
        this.vida = vida;
    }


    // Properties
    public int Pontos
    {
        get => pontos;
        set => pontos = value;
    }

    public int Vida
    {
        get => vida;
        set => vida = value;
    }

    // Methods
    public static void ChoseDificulty()
    {
        var sair = false;
            while (!sair)
            {
                Console.Clear();
                int opcao = 0;
                Console.WriteLine("------------------------------");
                Console.WriteLine("|    Escolher Dificuldade    |");
                Console.WriteLine("------------------------------");
                Console.WriteLine("| 1) Facil   = 7 Tentativas  |");
                Console.WriteLine("| 2) Normal  = 6 Tentativas  |");
                Console.WriteLine("| 3) Dificil = 5 Tentativas  |");
                Console.WriteLine("| 0) Menu Inicial            |");
                Console.WriteLine("------------------------------");
                opcao = Int32.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Dificuldade Facil escolhida");
                        // Verificar se consigo ter acesso ao jf fora desta classe
                        Jogador jf = new Jogador(facil);
                        sair = true;
                        break;
                    case 2:
                        Console.WriteLine("Dificuldade Normal escolhida");
                        Jogador jn = new Jogador(normal);
                        sair = true;
                        break;
                    case 3:
                        Console.WriteLine("Dificuldade Dificil escolhida");
                        Jogador jd = new Jogador(dificil);
                        sair = true;
                        break;
                    case 0:
                        Console.WriteLine("TESTE INICIO CALL METHOD");
                        Jogo.Inicio();
                        sair = true;
                        break; 
                }
            }
    }
}
