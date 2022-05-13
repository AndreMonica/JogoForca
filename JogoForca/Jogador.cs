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
    private  int facil = 7;
    private  int normal = 6;
    private  int dificil = 5;
    private int vida;

    // Constructor
    public Jogador()
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
                this.vida = 7;
                Jogo.Inicio();
                break;
            case 2:
                Console.WriteLine("Dificuldade Normal escolhida");
                this.vida = 6;
                Jogo.Inicio();
                break;
            case 3:
                Console.WriteLine("Dificuldade Dificl escolhida");
                this.vida = 5;
                Jogo.Inicio();
                break;
            case 0:
                Console.WriteLine("TESTE INICIO CALL METHOD");
                Jogo.Inicio();
                break;
            default:
                throw new Exception("Falhou a criação do Jogador parametro inválido");
        }
    }


    // Properties

    // Methods

}
