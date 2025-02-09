using System;
using System.Linq;
/*
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el número elegido (4 dígitos):");
        string numeroJugador = Console.ReadLine();

        Console.WriteLine("Ingrese el número ganador del sorteo (4 dígitos):");
        string numeroGanador = Console.ReadLine();

        Console.WriteLine("Ingrese la cantidad apostada en pesos:");
        if (!int.TryParse(Console.ReadLine(), out int apuesta) || apuesta <= 0)
        {
            Console.WriteLine("Cantidad de apuesta inválida. Intente nuevamente.");
            return;
        }

        int premio = CalcularPremio(numeroJugador, numeroGanador, apuesta);

        if (premio > 0)
        {
            Console.WriteLine($"¡Felicidades! Ganaste un premio de ${premio} pesos.");
        }
        else
        {
            Console.WriteLine("Lo sentimos, no ganaste esta vez. ¡Inténtalo de nuevo!");
        }
    }

    static int CalcularPremio(string numeroJugador, string numeroGanador, int apuesta)
    {
        if (numeroJugador.Length != 4 || numeroGanador.Length != 4 || !numeroJugador.All(char.IsDigit) || !numeroGanador.All(char.IsDigit))
        {
            Console.WriteLine("Los números deben tener exactamente 4 dígitos.");
            return 0;
        }

        // Caso 1: Número exacto (4 cifras en orden)
        if (numeroJugador == numeroGanador)
        {
            return 4500 * apuesta;
        }

        // Caso 2: Cuatro cifras en desorden
        if (numeroJugador.OrderBy(c => c).SequenceEqual(numeroGanador.OrderBy(c => c)))
        {
            return 200 * apuesta;
        }

        // Caso 3: Últimas 3 cifras en orden
        if (numeroJugador.Substring(1) == numeroGanador.Substring(1))
        {
            return 400 * apuesta;
        }

        // Caso 4: Últimas 2 cifras en orden
        if (numeroJugador.Substring(2) == numeroGanador.Substring(2))
        {
            return 50 * apuesta;
        }

        // Caso 5: Última cifra
        if (numeroJugador.Last() == numeroGanador.Last())
        {
            return 5 * apuesta;
        }

        // Si no cumple ningún caso, no hay premio
        return 0;
    }
}

 */


/*
class Program
{
    static void Main(string[] args)
    {
        // Función para imprimir números primos de la serie de Fibonacci
        Console.WriteLine("Ingrese el número de términos de Fibonacci para analizar los primos:");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            Console.WriteLine("Números primos en la serie de Fibonacci:");
            ImprimirPrimosFibonacci(n);
        }
        else
        {
            Console.WriteLine("Por favor, ingrese un número entero positivo válido.");
        }

        // Función para convertir segundos a formato HH:MM:SS
        Console.WriteLine("Ingrese una cantidad de segundos:");
        if (int.TryParse(Console.ReadLine(), out int segundos) && segundos >= 0)
        {
            string formatoTiempo = ConvertirSegundosAFormato(segundos);
            Console.WriteLine($"El tiempo en formato HH:MM:SS es: {formatoTiempo}");
        }
        else
        {
            Console.WriteLine("Por favor, ingrese una cantidad válida de segundos.");
        }
    }

    static void ImprimirPrimosFibonacci(int n)
    {
        int a = 0, b = 1;
        for (int i = 1; i <= n; i++)
        {
            if (EsPrimo(a))
            {
                Console.WriteLine(a);
            }
            int temp = a + b;
            a = b;
            b = temp;
        }
    }

    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0) return false;
        }
        return true;
    }

    //de segundos a HH:MM:SS

    static string ConvertirSegundosAFormato(int segundos)
    {
        int horas = segundos / 3600;
        int minutos = (segundos % 3600) / 60;
        int segRestantes = segundos % 60;

        return $"{horas:D2}:{minutos:D2}:{segRestantes:D2}";
    }
}*/
public abstract class AbstractSample
{
    private string message;

    protected string Message
    {
        get { return message; }
        set { message = value; }
    }

    public abstract void PrintMessage();

    public virtual void InvertMessage()
    {
        Message = new string(Message.Reverse().ToArray());
    }
}

public class SimpleMessagePrinter : AbstractSample
{
    public SimpleMessagePrinter(string text)
    {
        Message = text;
    }

    public override void PrintMessage()
    {
        Console.WriteLine(Message);
    }
}

public class CaseInvertedPrinter : AbstractSample
{
    public CaseInvertedPrinter(string text)
    {
        Message = text;
    }

    public override void PrintMessage()
    {
        string result = string.Concat(Message.Select(c =>
            char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)));
        Console.WriteLine(result);
    }

    public override void InvertMessage()
    {
        base.InvertMessage();
        Message = string.Concat(Message.Select(c =>
            char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)));
    }
}

public class MessageManager
{
    private AbstractSample sample1;
    private AbstractSample sample2;

    public MessageManager(string text)
    {
        sample1 = new SimpleMessagePrinter(text);
        sample2 = new CaseInvertedPrinter(text);
    }

    public void ProcessMessages()
    {
        Console.WriteLine("Simple Printer:");
        sample1.PrintMessage();

        Console.WriteLine("\nCase Inverted Printer:");
        sample2.PrintMessage();

        Console.WriteLine("\nInverted Messages:");
        sample1.InvertMessage();
        sample2.InvertMessage();

        Console.WriteLine("\nAfter Inversion:");
        sample1.PrintMessage();
        sample2.PrintMessage();
    }
}

// Example usage:
class Program
{
    static void Main(string[] args)
    {
        MessageManager manager = new MessageManager("Profe 5.0 Jeje");
        manager.ProcessMessages();
    }
}
