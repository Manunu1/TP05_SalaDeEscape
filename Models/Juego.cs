namespace TP05_SalaDeEscape;

public class Juego
{
    public int numeroSala = 1;
    public int numeroVidas = 3;
    public Dictionary <int, string> respuestas;
    public void inicializar()
    {
        respuestas = new Dictionary<int, string>();
        respuestas.Add(1, "6531");
        respuestas.Add(2, "arriba derecha izquierda abajo");
        respuestas.Add(3, "9135");
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
        }
        else{
            aux = true;
        }
        return aux;
    }   
}