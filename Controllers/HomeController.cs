using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_SalaDeEscape.Models;
using Newtonsoft.Json;

namespace TP05_SalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
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


    public IActionResult verResultado(string codigoRecibido)
    {

        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        ViewBag.numeroVidas = juego.numeroVidas;
        ViewBag.numeroSala = juego.numeroSala;

        string AQueView ="Sala"+ juego.numeroSala;


        if(codigoRecibido == null)
        {
            ViewBag.Mensaje g "No ingresó el codigo";
        }

        else if (juego.comparar(codigoRecibido) == false)
        {
            ViewBag.Mensaje = "Lo hiciste mal, perdiste una vida";
            if(juego.numeroVidas == 0)
            {
                AQueView ="VistaPerdedor";
            }
        }
        else
        {
            ViewBag.Mensaje = "Muy bien, pasaste a la siguiente sala";
            AQueView ="Sala"+ juego.numeroSala;
        }

            HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
            return View(AQueView);
    }

}