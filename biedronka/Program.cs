using System;
using System.Collections.Generic;

class Program
{
    static Queue<(string, DateTime)> queue = new Queue<(string, DateTime)>();

    static void Main()
    {
        queue.Enqueue(("Klient uno", DateTime.Now));
        queue.Enqueue(("Klient primo", DateTime.Now));
        queue.Enqueue(("Klient trio", DateTime.Now));

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"""
                        biedronka dzis tu elo czesc
                        od 10:40 do 10:55 bo akurat zisiaj mam wizyte u dentysty i tyle
                        liczba klientów w kolejce: {queue.Count}

                        opcje:
                        - 1.dodaj klienta do kolejki
                        - 2.obsłuż klienta
                        - 3.statystki

                        """);

            string komenda = Console.ReadLine();

            switch (komenda.ToLower())
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    ServeClient();
                    break;
                case "3":
                    ShowQueue();
                    break;
                default:
                    Console.WriteLine("Nieznana komenda");
                    break;
            }
        }
    }

    static void AddClient()
    {
        Console.Clear();
        Console.Write("Numer klienta: ");
        string numer = Console.ReadLine();

        queue.Enqueue((numer, DateTime.Now));
        Console.WriteLine("Dodano klienta do kolejki");
        Console.ReadKey();
    }

    static void ServeClient()
    {
        Console.Clear();
        if (queue.Count == 0)
        {
            Console.WriteLine("Kolejka jest pusta");
        }
        else
        {
            var (numer, czasDodania) = queue.Dequeue();
            var czasObslugi = DateTime.Now;
            var czasWKolejce = czasObslugi - czasDodania;
            Console.WriteLine($"Obsłużono klienta {numer}. Czas to: {czasWKolejce.TotalSeconds} sekund, czyli predkosc normalnie mikiego pedziwiatr ");
        }
        Console.ReadKey();
    }

    static void ShowQueue()
    {
        Console.Clear();
        if (queue.Count == 0)
        {
            Console.WriteLine("Kolejka jest pusta");
        }
        else
        {
            Console.WriteLine("Klienci w kolejce:");
            foreach (var (numer, czasDodania) in queue)
            {
                Console.WriteLine(numer);
            }
        }
        Console.ReadKey();
    }
}
