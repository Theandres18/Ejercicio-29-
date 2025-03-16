using System;
using System.Linq;
using System;

class BridgeValidator
{
    public static bool IsValidBridge(string puente)
    {
        int n = puente.Length;

        // Validar que empiece y termine con una base
        if (!(puente.Substring(0, 1).Equals("*") && puente.Substring(n - 1, 1).Equals("*")))
        {
            return false;
        }

        // Validar que el puente no tenga caracteres inválidos
        int conRef = 0;
        for (int i = 1; i < n - 1; i++)
        {
            string pieza = puente.Substring(i, 1);
            if (!(pieza.Equals("=") || pieza.Equals("+") || pieza.Equals("*")))
            {
                return false;
            }

            if (pieza.Equals("="))
            {
                conRef++;
            }
            else
            {
                conRef = 0;
            }

            if (conRef == 4)
            {
                return false;
            }
        }

        // Validar simetría y otras condiciones
        conRef = 0;
        for (int i = 1; i < n / 2; i++)
        {
            string pi = puente.Substring(i, 1);
            string pd = puente.Substring(n - i - 1, 1);

            if (!pi.Equals(pd))
            {
                return false;
            }

            if (pi.Equals("+"))
            {
                conRef++;
            }
            else
            {
                conRef = 0;
            }

            if (conRef == 3)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        Console.WriteLine("Ingrese la representación del puente:");
        string input = Console.ReadLine();

        if (IsValidBridge(input))
            Console.WriteLine("El puente es válido.");
        else
            Console.WriteLine("El puente no es válido.");
    }
}
