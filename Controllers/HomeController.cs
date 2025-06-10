using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_SalaDeEscape.Models;
using Newtonsoft.Json;

namespace TP05_SalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

        public static class Objeto{
        public static string ObjectToString<T>(T? obj){
            return JsonConvert.SerializeObject(obj);
        }
        public static T? StringToObject<T>(string txt){
            if(string.IsNullOrEmpty(txt)){
                return default;
            }
            else{
                return JsonConvert.DeserializeObject<T>(txt);
            }
        }
    }
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego juego = new Juego();
        juego.inicializar();
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Sala1");
    }
    //
    //yo menos 


    public IActionResult verResultado(string codigoRecibido){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        ViewBag.numeroVidas = juego.numeroVidas;
        ViewBag.numeroSala = juego.numeroSala;

        if(codigoRecibido == null)
        {
            ViewBag.Mensaje = "No ingreso el codigo";
            return View("Sala" + juego.numeroSala);
        }
        else if (juego.comparar(codigoRecibido) == false){
            ViewBag.Mensaje = "Lo hiciste mal, perdiste una vida";
            juego.perderVida();
            return View("Sala" + juego.numeroSala);
        }
        else{
            ViewBag.Mensaje = "Muy bien, pasaste a la siguiente sala";
            juego.agregarSala();
            HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
            return View("Sala" + juego.numeroSala);
        }

        
        
    }

}