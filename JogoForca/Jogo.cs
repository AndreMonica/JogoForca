using System.Diagnostics;
using System.Globalization;

namespace JogoForca;

public class Jogo
{
    // Fields
    private Jogador _jogador;

    // Constructor
    public Jogo(Jogador jogador)
    {
        _jogador = jogador;
    }

    // Methods
    public static void Inicio()
    {
        var sair = false;
        while (!sair)
        {
            Console.Clear();
            int opcao = 0;
            Console.WriteLine("------------------------------");
            Console.WriteLine("|       Jogo da Forca        |");
            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1) Inserir Palavras        |");
            Console.WriteLine("| 2) Escolher Dificuldade    |");
            Console.WriteLine("| 3) Jogar                   |");
            Console.WriteLine("| 0) Sair                    |");
            Console.WriteLine("------------------------------");
            opcao = Int32.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    WordList.InsertWord();
                    sair = true;
                    break;
                case 2:
                    Jogador j = new Jogador();
                    sair = true;
                    break;
                case 3:
                    Jogo.Jogar();
                    sair = true;
                    break;
                case 0:
                    Console.WriteLine("Applicacao Terminada com Sucesso");
                    sair = true;
                    break;
            }
        }
    }

    public static void Vitoria()
    {
        Console.Clear();
        int opcao = 0;
        Console.WriteLine("------------------------------");
        Console.WriteLine("------------------------------");
        Console.WriteLine("|          Ganhou!!!!        |");
        Console.WriteLine("------------------------------");
        Console.WriteLine("- 1)  Comecar de novo        -");
        Console.WriteLine("- 0)  Terminar programa      -");
        Console.WriteLine("------------------------------");
        opcao = Int32.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Jogo.Inicio();
                break;
            case 0:
                Jogo.Sair();
                break;
        }
    }

    public static void Derrota()
    {
        Console.Clear();
        int opcao = 0;
        Console.WriteLine("------------------------------");
        Console.WriteLine("------------------------------");
        Console.WriteLine("|    Fim de jogo, perdeu!    |");
        Console.WriteLine("------------------------------");
        Console.WriteLine("- 1)  Comecar de novo        -");
        Console.WriteLine("- 0)  Terminar programa      -");
        Console.WriteLine("------------------------------");
        opcao = Int32.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Jogo.Inicio();
                break;
            case 0:
                Jogo.Sair();
                break;
        }
    }

    public static void Sair()
    {
        System.Environment.Exit(0);
    }
    public static void Jogar()
    {
        var sair = false;
        char letraEscolhida = ' ';
        string letrasUsadas = "                            ";

        var primeiraVez = true;

        WordList.ReadFile();
        WordList chave = WordList.RandomWord();
        char[] resultado = new char[chave.word.Length];
        while (primeiraVez)
        {
            for (int i = 0; i < chave.word.Length; i++)
            {
                resultado[i] = '_';
            }
            primeiraVez = false;
        }
        
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("|       Jogo da Forca        |");
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Tentativas: {0}            |"); //  more spaces cuz {0}
            Console.WriteLine("| Topico: {0}                |"); //  more spaces cuz {0}
            Console.WriteLine("| Letras ja usadas:          |"); //  more spaces cuz {0}
            Console.WriteLine("|" + letrasUsadas +"|"); 
            Console.WriteLine("------------------------------");
            Console.WriteLine("|          ADIVINHA          |");
            Console.WriteLine("------------------------------");
            if (!(new String(resultado).Contains("_")))
            {
                Jogo.Vitoria();
                sair = true;
                break;
            }

            if (/** vida <= 0 >>> REMOVE FALSE*/  false)
            {
                Jogo.Derrota();
                sair = true;
                break;
            }
         
            
            Console.WriteLine("|  " + new String(resultado) +" |"); 
            Console.WriteLine("------------------------------");
            letraEscolhida = Convert.ToChar(Console.ReadLine());
            

            if (!letrasUsadas.Contains(letraEscolhida) && !chave.word.Contains(letraEscolhida))
            {
                letrasUsadas += Convert.ToString(letraEscolhida);
                // Tentativas -1; 
                // Nao consigo aceder a Jogador.Vida 
                // Nem consigo usar gets e sets 
                
                if (letrasUsadas.Contains(' '))
                {
                    letrasUsadas = letrasUsadas.Remove(0, 1);
                }
            }
            else if (chave.word.Contains((letraEscolhida)))
            {
                for (int i = 0; i < chave.word.Length; i++)
                {
                    if (Convert.ToChar(chave.word.Substring(i, 1)) == letraEscolhida)
                    {
                        resultado[i] = letraEscolhida;
                    }
                }
            }
        }
    }
}