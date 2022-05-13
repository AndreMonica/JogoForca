using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace JogoForca;
using System.IO;

public class WordList
{
    // Nomes de Filmes
    // Nomes de Jogos
    // Nomes de Paises
    
    // Fields
    public  string word;
    public  Categoria categoria;

    // Constructor
    public WordList(string word, Categoria categoria)
    {
        this.word = word;
        this.categoria = categoria;
    }

    
    // fields
    public static List<WordList> palavras = new List<WordList>();
    
    
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
            
            
   
            
            switch (opcao)
            {
                case 1:
                    // Escrever num fichero CSV
                    Console.WriteLine("TESTE INSERIR FILME CALL ");
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
    

    public static void ReadFile()
    {
        using (StreamReader sr = new StreamReader("/Users/Andre/RiderProjects/JogoForca_21210/palavras.csv")) {
            string line;

            // Read and display lines from the file until 
            // the end of the file is reached. 
            while ((line = sr.ReadLine()) != null)
            {
                String[] splitted = line.Split(';');
                WordList p = new WordList(splitted[0], (Categoria) Int16.Parse(splitted[1]));
                palavras.Add(p);
            }
        }
    }

    public static WordList RandomWord()
    {
        //Escolher uma categoria aleatoria
        var rnd = new Random();

        //Gerar uma Categoria aleatoria com base no quantidade de valores que este Enumerado têm
        Categoria escolhida = (Categoria)rnd.Next(Enum.GetNames(typeof(Categoria)).Length);
        // Console.WriteLine(escolhida);

        //Lista para guardar apenas as palavras da categoria selecionada
        List<WordList> palavrasCategoria = new List<WordList>();

        //Percorrer todas as palavras que estavam no ficheiro e adicionalas à nova lista
        Debug.Assert(palavras != null, nameof(palavras) + " != null");
        foreach (var pav in palavras)
        {
            if (pav.categoria == escolhida)
            {
                palavrasCategoria.Add(pav);
            }
        }

        //Obter uma chave aleatoria (Palavra que o utilizador deve advinhar)
        return (palavrasCategoria[rnd.Next(palavrasCategoria.Count)]);
    }

}