namespace JogoForca;
using System.IO;

public class WordList
{
    // Nomes de Filmes
    // Nomes de Jogos
    // Nomes de Paises
    
    // Fields
    public static string word;
    public static int tipo;
    

    // Constructor
  
    // Method
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
            
            
            // build  CSV and file stuff >> NET >>https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0
            string path = @"c:\AndreMJogo\WordList.csv";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
         
            
            switch (opcao)
            {
                case 1:
                    // Escrever num fichero CSV
                    Console.WriteLine("TESTE INSERIR FILME CALL ");
                    word = Console.ReadLine();
                    tipo = 0;
                    string csv = string.Format("{0},{1}\n", word, tipo);
                    StreamWriter wr = new StreamWriter( @"c:\AndreMJogo\WordList.csv", csv);
                    wr.WriteLine("Teste");
                    wr.Close();
                    sair = true;
                    break;
                case 2:
                    // Escrever num fichero CSV
                    Console.WriteLine("TESTE INSERIR Jogo CALL ");
                    sair = true;
                    break;
                case 3:
                    // Escrever num fichero CSV
                    Console.WriteLine("TESTE INSERIR Pais CALL ");
                    sair = true;
                    break;
                case 0:
                    // Escrever num fichero CSV
                    Console.WriteLine("TESTE INICIO CALL METHOD");
                    Jogo.Inicio();
                    sair = true;
                    break;
            }
        }
    }

    public static string ChoseWord()
    {
        //Return a random word from the list with the type, filme, jogo ou pais
        return ("casa");
    }

}