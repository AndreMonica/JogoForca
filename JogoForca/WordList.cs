namespace JogoForca;

public class WordList
{
    // Nomes de Filmes
    // Nomes de Jogos
    // Nomes de Paises


    public static void InsertWord()
    {
        var sair = false;
        while (!sair)
        {
            Console.Clear();
            int opcao = 0;
            Console.WriteLine("------------------------------");
            Console.WriteLine("|      Inserir Palavras      |");
            Console.WriteLine("------------------------------");
            Console.WriteLine("| 1) Inserir Filme           |");
            Console.WriteLine("| 2) Inserir Jogo            |");
            Console.WriteLine("| 3) Inserir Pais            |");
            Console.WriteLine("| 0) Menu Inicial            |");
            Console.WriteLine("------------------------------");
            opcao = Int32.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("TESTE INSERIR FILME CALL ");
                    sair = true;
                    break;
                case 2:
                    Console.WriteLine("TESTE INSERIR Jogo CALL ");
                    sair = true;
                    break;
                case 3:
                    Console.WriteLine("TESTE INSERIR Pais CALL ");
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