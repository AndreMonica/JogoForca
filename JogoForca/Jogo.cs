﻿using System.Diagnostics;
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

    public static void Vitoria()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("------------------------------");
        Console.WriteLine("|          Ganhou!!!!        |");
        Console.WriteLine("------------------------------");
        Console.WriteLine("------------------------------");
    }

    public static void Derrota()
    {
        int opcao = 0;
        Console.WriteLine("------------------------------");
        Console.WriteLine("------------------------------");
        Console.WriteLine("|          Ganhou!!!!        |");
        Console.WriteLine("------------------------------");
        Console.WriteLine("- 1)  Comecar de novo        -");
        Console.WriteLine("- 0)  Terminar programa      -");
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
     
        char[] resultado = new char[WordList.ChoseWord().Length];
        resultado[0] = '_';
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
            if (!(new String(resultado).Contains("_")))
            {
                Jogo.Vitoria();
                break;
            }
         
            while (primeiraVez)
            {
                for (int i = 0; i < WordList.ChoseWord().Length; i++)
                {
                    resultado[i] = '_';
                }
                primeiraVez = false;
            }
            Console.WriteLine("|  " + new String(resultado) +" |"); 
            Console.WriteLine("------------------------------");
            letraEscolhida = Convert.ToChar(Console.ReadLine());
            

            if (!letrasUsadas.Contains(letraEscolhida) && !WordList.ChoseWord().Contains(letraEscolhida))
            {
                letrasUsadas += Convert.ToString(letraEscolhida);
                // Tentativas -1; 
                // NAo consigo aceder a Jogador.Vida 
                // Nem consigo usar gets e sets 
                
                if (letrasUsadas.Contains(' '))
                {
                    letrasUsadas = letrasUsadas.Remove(0, 1);
                }
            }
            else if (WordList.ChoseWord().Contains((letraEscolhida)))
            {
                for (int i = 0; i < WordList.ChoseWord().Length; i++)
                {
                    if (Convert.ToChar(WordList.ChoseWord().Substring(i, 1)) == letraEscolhida)
                    {

                        resultado[i] = letraEscolhida;
                    }
                }
            }
        }
    }
}