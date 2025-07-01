namespace TP05_SalaDeEscape;
using Newtonsoft.Json;

public class Juego
{
    [JsonProperty]
    public int numeroSala {get; private set;}  
    [JsonProperty]
    public int numeroVidas {get; private set;} 
    [JsonProperty]
    public Dictionary <int, string> respuestas {get; private set;}
    public void inicializar()
    {
        respuestas = new Dictionary<int, string>();
        respuestas.Add(1, "2499");
        respuestas.Add(2, "arriba, izquierda, abajo, derecha");
        respuestas.Add(3, "9135");
        respuestas.Add(4, "1234");
        respuestas.Add(5, "RÍO DE JANEIRO");
        numeroVidas = 3;
        numeroSala = 1;
    }
    public void agregarSala(){
        numeroSala++;
    }
    public void perderVida(){
        numeroVidas--;
    }
    public bool comparar(string comparacion){
        bool aux = false;
        if(comparacion != respuestas[numeroSala]){
            aux = false;
            perderVida();
        }
        else
        {
            aux = true;
            agregarSala();
        }
        return aux;
    }   
}