namespace JogoForca;

public class Jogador
{
    // Vida   Fácil: 7 tentativas
    // Vida  Normal: 6 tentativas
    // Vida Dificil: 5 tentativas
    // Pontos (total de letras correctas)

    //Propreties
    private int facil = 7;
    private int normal = 6;
    private int dificil = 5;
    private int pontos = 0;

    //Constructor
    public Jogador(int facil, int normal, int dificil, int pontos)
    {
        this.facil = facil;
        this.normal = normal;
        this.dificil = dificil;
        this.pontos = pontos;
    }

    
    //GET's SET's
    public int Facil
    {
        get => facil;
        set => facil = value;
    }

    public int Normal
    {
        get => normal;
        set => normal = value;
    }

    public int Dificil
    {
        get => dificil;
        set => dificil = value;
    }

    public int Pontos
    {
        get => pontos;
        set => pontos = value;
    }
}