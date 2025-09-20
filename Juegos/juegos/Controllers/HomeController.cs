using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Juegos.Controllers
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
        [HttpGet]
        public IActionResult Juego2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Juego2(int? maxNumber, int? nivel, string guess, int? randomNumber, int? maxIntentos, List<string> intentos)
        {
            string message = null;
            bool terminado = false;
            int nivelIntentos = 10;
            if (nivel == 2) nivelIntentos = 5;
            else if (nivel == 3) nivelIntentos = 3;

            if (maxIntentos == null || maxIntentos <= 0)
                maxIntentos = nivelIntentos;

            if (intentos == null)
                intentos = new List<string>();

            if (maxNumber == null || maxNumber <= 0)
            {
                message = "Por favor, ingresa un número máximo válido.";
                terminado = true;
            }
            else if (string.IsNullOrEmpty(guess))
            {
                message = "Introduce tu intento.";
            }
            else if (guess.ToUpper() == "S")
            {
                message = "Has salido del juego.";
                terminado = true;
            }
            else
            {
                int num;
                if (!int.TryParse(guess, out num) || num <= 0)
                {
                    message = "Número inválido. El juego se ha parado.";
                    terminado = true;
                }
                else
                {
                    if (randomNumber == null)
                        randomNumber = new System.Random().Next(1, (int)maxNumber + 1);

                    intentos.Add(guess);

                    if (num == randomNumber)
                    {
                        message = $"¡Ganaste! El número era {randomNumber}. Intentos usados: {intentos.Count}";
                        terminado = true;
                    }
                    else
                    {
                        if (intentos.Count >= maxIntentos)
                        {
                            message = $"Perdiste. El número era {randomNumber}. Se acabaron los intentos.";
                            terminado = true;
                        }
                        else
                        {
                            message = $"Incorrecto. Te quedan {maxIntentos - intentos.Count} intentos.";
                        }
                    }
                }
            }

            ViewBag.MaxNumber = maxNumber;
            ViewBag.Nivel = nivel;
            ViewBag.RandomNumber = randomNumber;
            ViewBag.MaxIntentos = maxIntentos;
            ViewBag.Intentos = intentos;
            ViewBag.Message = message;
            ViewBag.Terminado = terminado;
            return View();
        }
    }
}