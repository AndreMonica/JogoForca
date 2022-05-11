using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace JogoForca;

public class Jogador
{
    // Vida   Fácil: 7 tentativas
    // Vida  Normal: 6 tentativas
    // Vida Dificil: 5 tentativas
    // Pontos (total de letras correctas)

    //Propreties
    private static int facil = 7;
    private static int normal = 6;
    private static int dificil = 5;
    public int vida = 0;
    public int pontos = 0;

    //Constructor
    public Jogador(int vida, int pontos)
    {
        this.vida = vida;
        this.pontos = pontos;
    }


    //GET's SET's
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
                        sair = true;
                        break;
                    case 2:
                        Console.WriteLine("Dificuldade Normal escolhida");
                        sair = true;
                        break;
                    case 3:
                        Console.WriteLine("Dificuldade Dificil escolhida");
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
