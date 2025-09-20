using Microsoft.AspNetCore.Mvc;

namespace Mini_Juego.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Juego1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Juego1(int? maxNumber, int? guess, int? randomNumber)
        {
            string message = null;
            if (maxNumber == null)
            {
                message = "Por favor, ingresa el número máximo.";
            }
            else if (maxNumber <= 0)
            {
                message = "El número máximo debe ser mayor que cero. No se puede jugar.";
            }
            else if (guess != null && randomNumber != null)
            {
                if (guess == randomNumber)
                {
                    message = $"¡Ganaste! El número era {randomNumber}.";
                }
                else
                {
                    message = $"Perdiste. El número era {randomNumber}.";
                }
            }
            ViewBag.MaxNumber = maxNumber;
            ViewBag.RandomNumber = randomNumber;
            ViewBag.Guess = guess;
            ViewBag.Message = message;
            return View();
        }
        public IActionResult Juego2()
        {
            return View();
        }
    }
}
