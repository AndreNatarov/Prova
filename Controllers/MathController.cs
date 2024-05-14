using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AS2223_4G_INF_NatarovMauriAndre_API.Controllers
{
    public class CompitoController : Controller
    {
        [HttpGet("GetNumeroPari")]
        public JsonResult GetNumeroPari(int numero_1)
        {
            string result;

            if (numero_1 % 2 == 0)
            {

                result = "Pari";

            }
            else
            {

                result = "Dispari";

            }

            return Json(new
            {
                result,
                status = "OK"
            });
        }

        [HttpGet("GetFattoriale")]
        public JsonResult GetFattoriale(int numero_1)
        {

            string status;
            int result = 0;

            if (numero_1 < 0)
            {

                status = "Errore, numero minore di 0";
                result = 0;

            }
            else
            {

                if (numero_1 != 0)
                {

                    result = 1;

                }

                for (int i = 1; i < numero_1 + 1; i++)
                {

                    result *= i;

                }
                status = "OK";

            }

            return Json(new
            {
                result,
                status
            });

        }

        [HttpGet("GetTasse")]
        public JsonResult GetTasse(int reddito)
        {
            string status = null;
            int result_1 = 0, result_2 = 0;

            if (reddito <= 0)
            {

                status = "Errore, valore non accettabile";

            }
            else if (reddito > 0 && reddito < 35000)
            {

                result_1 = reddito / 100 * 12;
                status = "OK";

            }
            else if (reddito > 35000)
            {

                result_1 = 35000 / 100 * 12;
                result_2 = (reddito - 35000) / 100 * 12;
                status = "OK";

            }

            return Json(new
            {
                result_1,
                result_2,
                status
            });

        }

        [HttpGet("GetDelta")]
        public JsonResult GetDelta(int coeficente_a, int coeficente_b, int coeficente_c)
        {

            int delta = (coeficente_b * coeficente_b) - 4 * coeficente_a * coeficente_c;
            string result = null;

            if (delta > 0)
            {

                result = "Delta maggiore di 0";

            }
            else if (delta == 0)
            {

                result = "Delta uguale a 0";

            }
            else if (delta < 0)
            {

                result = "Delta minore di 0";

            }

            return Json(new
            {
                delta,
                result,
                status = "OK"
            });

        }
        [HttpGet("GetNumeroMultiplo")]
        public JsonResult GetNumeroMultiplo(int numero, int fattore)
        {
            if(numero > 0 && fattore > 0) { 
                if(numero % fattore == 0) { 
                    return Json(new{
                        message = "Il numero è multiplo",
                        status = "OK"
                    });
                } else
                {
                    return Json(new
                    {
                        message = "Il numero non è multiplo",
                        status = "OK"
                    });
                } 
            }
            else
            {
                return Json(new
                {
                    message = "ERRORE",
                    status = "KO"
                });
            }
        }

        [HttpGet("GetPotenza")]
        public JsonResult GetPotenza(double numero, double esponente)
        {
            double risultato = 0;
            string message;
            if (numero >= 0 && esponente >= 0) { 
                risultato = Math.Pow(numero, esponente);
                return Json(new
                {
                    risultato,
                    message = "Potenza eseguita correttamente",
                    status = "OK"
                });

            } else {
                return Json(new
                {
                    message = "Errore",
                    status = "KO"
                });
            }
        }

        [HttpGet("GetAnnoBisestile")]
        public JsonResult GetAnnoBisestile(int anno)
        {
            if (anno > 0 && anno % 4 == 0) {
                return Json(new
                {
                    anno,
                    message = "L'anno inserito è bisestile",
                    status = "OK"
                });
            } else if (anno > 0 && anno % 4 != 0)
            {
                return Json(new
                {
                    anno,
                    message = "L'anno inserito NON è bisestile",
                    status = "OK"
                });
            }
            else
            {
                return Json(new
                {
                    message = "Errore",
                    status = "KO"
                });
            }
        }
        [HttpGet("GetIpotenusa")]
        public JsonResult GetIpotenusa (double cateto_1, double cateto_2)
        {
            double ipotenusa = 0;
            if(cateto_1 > 0 && cateto_2 > 0)
            {
                ipotenusa = Math.Sqrt(cateto_1*cateto_1+cateto_2*cateto_2);
                return Json(new
                {
                    ipotenusa,
                    message = "Calcolo eseguito corretamente!",
                    status = "OK"
                });
            }
            else
            {
                return Json(new
                {
                    message = "Errore!",
                    status = "KO" //ERRORE GRAVE!
                });
            }
        }
    }
}
