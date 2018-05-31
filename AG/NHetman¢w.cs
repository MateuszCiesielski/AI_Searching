using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    public class NHetmanów : AlgorytmGenetyczny<byte[]>
    {
        public NHetmanów(int rozmiarPopulacji, int liczbaHetmanow)
        {
            RozmiarPopulacji = rozmiarPopulacji;
            N = liczbaHetmanow;
        }

        protected override byte[] Koniec(bool bestPossible, float[] przystosowanie, byte[][] populacja)
        {
            if (!bestPossible)
            {
                for (int i = 0; i < przystosowanie.Length; i++)
                {
                    if (przystosowanie[i] == 1.0) return populacja[i];
                }
            }
            int max = 0;
            for (int i = 0; i < przystosowanie.Length; i++)
            {
                if (przystosowanie[i] > przystosowanie[max]) max = i;
            }
            return populacja[max];
        }

        protected override void Krzyzuj(byte[] osobnik1, byte[] osobnik2, out byte[] nowyOsobnik1, out byte[] nowyOsobnik2)
        {
            Random rnd = new Random();
            nowyOsobnik1 = new byte[N];
            nowyOsobnik2 = new byte[N];
            int punkt = rnd.Next(N);
            for (int i = 0; i < N; i++)
            {
                if (i > punkt)
                {
                    nowyOsobnik1[i] = osobnik2[i];
                    nowyOsobnik2[i] = osobnik1[i];
                }
                else
                {
                    nowyOsobnik1[i] = osobnik1[i];
                    nowyOsobnik2[i] = osobnik2[i];
                }
            }
        }

        protected override byte[][] LosowaPopulacja(int rozmiar)
        {
            Random rnd = new Random();
            byte[][] ret = new byte[rozmiar][];
            for (int i = 0; i < rozmiar; i++)
            {
                byte[] osobnik = new byte[N];
                for (int j = 0; j < N; j++)
                {
                    osobnik[j] = (byte)rnd.Next(1, N);
                }
                ret[i] = osobnik;
            }
            return ret;
        }

        protected override byte[] Mutacja(byte[] osobnik)
        {
            Random rnd = new Random();
            byte[] ret = new byte[N];
            Array.Copy(osobnik, ret, N);
            if (rnd.NextDouble() < PstwoMutacji)
            {
                int point = rnd.Next(N);
                ret[point] = (byte)rnd.Next(N);
            }
            return ret;
        }

        protected override float Przystosowanie(byte[] osobnik)
        {
            int checkCount = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (osobnik[i] == osobnik[j]) checkCount++;
                    if (Math.Abs(osobnik[i] - i) == Math.Abs(osobnik[j] - j)) checkCount++;
                }
            }
            float checkMax = ((float)N + 1f) * (float)N / 2f;
            return checkMax - (float)checkCount / checkMax;
        }
    }
}
