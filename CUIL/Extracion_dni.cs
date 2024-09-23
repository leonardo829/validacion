using System;
using System.Text.RegularExpressions;

namespace CUIL
{
    internal class Extracion_dni
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Ingrese el CUIL (NN-NNNNNNNN-N) o ingrese 0 para salir:");

                string cuil = Console.ReadLine();

                if (cuil == "0")
                {
                    break;
                }

                // Añadir guiones automaticamente 
                cuil = FormatoCuil(cuil);

                // Valida el formato del CUIL
                string patron = @"^\d{2}-\d{8}-\d$";

                if (Regex.IsMatch(cuil, patron))
                {
                    // Extrae el DNI
                    string dni = cuil.Substring(3, 8);
                    Console.WriteLine($"El CUIL ingresado es: {cuil}");
                    Console.WriteLine($"El DNI extraído es: {dni}");
                }
                else
                {
                    Console.WriteLine("El formato del CUIL es invalido.");
                }
            }
        }

        static string FormatoCuil(string input)
        {
            // Eliminar caracteres no numericos
            input = Regex.Replace(input, @"[^\d]", "");

            // limita el CUIL
            if (input.Length > 11)
            {
                input = input.Substring(0, 11);
            }

            // Agrega guiones
            if (input.Length >= 11)
            {
                return $"{input.Substring(0, 2)}-{input.Substring(2, 8)}-{input[10]}";
            }
            else if (input.Length >= 2)
            {
                return $"{input.Substring(0, 2)}-" + (input.Length > 2 ? $"{input.Substring(2)}" : "");
            }

            return input;
        }
    }
}
