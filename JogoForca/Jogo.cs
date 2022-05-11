namespace JogoForca;

public class Jogo
{
    // Desenhar o menu de Intro para o jogo;
            // Inserir palavras nas WordList; 
                // Escolher qual adicionar > Filmes = 0 /Jogos = 1 /Pais = 2
            // Escolher a dificuldade (Facil; Normal; Dificil;)
            // Escolher JOGAR
        // Interface de Jogo
            // Sortear aliatoriamente uma categoria de 0, 1 ou 2 
            // Mostrar as Tentativas
            // Mostrar as palavras como _ _ _ _ 
            // Mostrar as Letras correctas na palavra _ A _ A
            // Mostrar as letras ja usadas e incorrectas
            // Mostrar os Pontos
            // Mostrar condicao de derrota "Fim de jogo, perdeu!"
            // Mostrar condicao de victoria "Fim de jogo, ganhou!"
    private Jogador _jogador;

    public Jogo(Jogador jogador)
    {
        _jogador = jogador;
    }

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
                    Jogador.ChoseDificulty();
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
    public static void Jogar()
    {
        var sair = false;
        char letraEscolhida = ' ';
        string letrasUsadas = "                            ";
        string theWord = "";
        var primeiraVez = true;
        
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("|       Jogo da Forca        |");
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Tentativas: {0}            |"); //  more spaces cuz {0}
            Console.WriteLine("| Topico: {0}                |"); //  more spaces cuz {0}
            Console.WriteLine("| Letras ja usadas {0}       |"); //  more spaces cuz {0}
            Console.WriteLine("|" + letrasUsadas +"|"); 
            Console.WriteLine("------------------------------");
            Console.WriteLine("|          ADIVINHA          |");
            Console.WriteLine("------------------------------");
            do
            {
                for (int i = 0; i < WordList.ChoseWord().Length; i++)
                {
                    theWord += "_ ";
                }
                primeiraVez = false;
            } while (primeiraVez);
            
            Console.WriteLine("|  " + theWord +" |"); 
            Console.WriteLine("------------------------------");
            letraEscolhida = Convert.ToChar(Console.ReadLine());

            
            if (!letrasUsadas.Contains(letraEscolhida) && !WordList.ChoseWord().Contains(letraEscolhida))
            {
                letrasUsadas += Convert.ToString(letraEscolhida);
                // Tentativas -1;
                
                if (letrasUsadas.Contains(' '))
                {
                    letrasUsadas = letrasUsadas.Remove(0, 1);
                }
            }
            else if (WordList.ChoseWord().Contains((letraEscolhida)))
            {
                for (int i = 0; i < WordList.ChoseWord().Length; i++)
                {
                    theWord += "_ ";
                }
            }
            {
                Console.WriteLine("Letra ja foi usada insira outra");
            }

        }
    }
}