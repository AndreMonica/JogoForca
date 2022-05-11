using JogoForca;

var sair = false;
while (!sair)
{
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
            sair = true;
            break;
        case 3:
            sair = true;
            break;
        case 0:
            Console.WriteLine("Applicacao Terminada com Sucesso");
            sair = true;
            break;
    }
}