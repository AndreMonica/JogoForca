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
                    Jogador player = new Jogador();
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
        string spaceCategoria = "";
        string spaceAdivinha = "";

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
            Console.WriteLine("| Tentativas: {0}              |", Jogador.vida ); //  more spaces cuz {0}
            if (chave.categoria == Categoria.FILMES) { spaceCategoria = "             ";}
            if (chave.categoria == Categoria.JOGOS)  { spaceCategoria = "              ";}
            if (chave.categoria == Categoria.PAISES) { spaceCategoria = "             ";}
            Console.WriteLine("| Topico: {0}{1}|", chave.categoria, spaceCategoria ); //  more spaces cuz {0}
            Console.WriteLine("| Letras ja usadas:          |"); //  more spaces cuz {0}
            Console.WriteLine("|" + letrasUsadas +"|"); 
            Console.WriteLine("------------------------------");
            Console.WriteLine("|          ADIVINHA          |");
            Console.WriteLine("------------------------------");
            if (!(new String(resultado).Contains("_")))
            {
                Jogo.Vitoria();
                break;
            }
            
            if (Jogador.vida < 0)
            {
                Jogo.Derrota();
                break;
            }

            for (int i = 0; i < 11; i++)
            {
                if ((spaceAdivinha.Length + resultado.Length + spaceAdivinha.Length) < letrasUsadas.Length)
                {
                    spaceAdivinha += " ";
                }
            }
           

            
            Console.WriteLine("|{0}" + new String(resultado) +"{0}|", spaceAdivinha); 
            Console.WriteLine("------------------------------");
            
            // catch error imput
            object[] values = { 'r', "s", "word", (byte) 83, 77, 109324, 335812911,
                new DateTime(2009, 3, 10), (uint) 1934,
                (sbyte) -17, 169.34, 175.6m, null };
            char result = '\0';
            try {
                letraEscolhida = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("The {0} value {1} converts to {2}.",
                    letraEscolhida.GetType().Name, letraEscolhida, result);
            }
            catch (FormatException e) {
                Console.WriteLine(e.Message);
            }
            catch (InvalidCastException) {
                Console.WriteLine("Conversion of the {0} value {1} to a Char is not supported.",
                    letraEscolhida.GetType().Name, letraEscolhida);
            }
            catch (OverflowException) {
                Console.WriteLine("The {0} value {1} is outside the range of the Char data type.",
                    letraEscolhida.GetType().Name, letraEscolhida);
            }
            catch (NullReferenceException) {
                Console.WriteLine("Cannot convert a null reference to a Char.");
            }
            
            // make spacing on chose letters
            if (!letrasUsadas.Contains(letraEscolhida) && !chave.word.Contains(letraEscolhida))
            {
                letrasUsadas += Convert.ToString(letraEscolhida);
                Jogador.vida--;
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