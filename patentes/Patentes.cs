using System;
using System.Text.RegularExpressions;

namespace Validacion_Patentes
{
    public class Patentes
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Ingrese la patente del auto (o ingrese 0 para salir):");
                string patente = Console.ReadLine();

                if (patente == "0")
                {
                    break;
                }

                // valida todos los formatos (con o sin espacios)
                string patron = @"^(?:(?:[a-z]{2}\d{3}[a-z]{2}|[a-z]{2}\s\d{3}\s[a-z]{2}|[a-z]{2}\d{3}|[a-z]{3}\s\d{3}|[a-z]{2}\d{3}[a-z]|[a-z]{3}\d{3}))$";

                // Valida la patente (ignore case: no key sensitive)
                if (Regex.IsMatch(patente, patron, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("La patente es valida.");
                }
                else
                {
                    Console.WriteLine("La patente es invalida.");
                }
            }
        }
    }

}
