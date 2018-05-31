using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start;
            DateTime stop;

            Console.WriteLine("Podaj liczbę hetmanów: ");
            int liczbaHetmanow = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj rozmiar populacji: ");
            int rozmiarPopulacji = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj liczbę iteracji: ");
            int liczbaIteracji = Convert.ToInt32(Console.ReadLine());

            

            NHetmanów nHetmanów = new NHetmanów(rozmiarPopulacji, liczbaHetmanow);

            start = DateTime.Now;
            var wynik = nHetmanów.Szukaj(liczbaIteracji);
            stop = DateTime.Now;

            foreach (var a in wynik)
            {
                Console.Write(a);
            }
            Console.WriteLine("\nCzas wykonania: " + (stop - start).TotalMilliseconds + "ms");
        }
    }
}
