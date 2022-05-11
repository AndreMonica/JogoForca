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
        Console.WriteLine("TESTE Jogo CALL METHOD");
    }
    
}