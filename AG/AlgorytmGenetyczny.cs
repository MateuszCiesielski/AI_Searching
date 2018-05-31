﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    public abstract class AlgorytmGenetyczny<TypOsobnika>
    {
        protected abstract TypOsobnika[] LosowaPopulacja(int rozmiar);
        protected abstract TypOsobnika Koniec(bool bestPossible, float[] przystosowanie, TypOsobnika[] populacja);
        protected abstract float Przystosowanie(TypOsobnika osobnik);
        protected abstract void Krzyzuj(TypOsobnika osobnik1, TypOsobnika osobnik2, out TypOsobnika nowyOsobnik1, out TypOsobnika nowyOsobnik2);
        protected abstract TypOsobnika Mutacja(TypOsobnika osobnik);

        protected int N { get; set; }
        protected int RozmiarPopulacji { get; set; }
        protected float PstwoMutacji { get; set; }
        protected TypOsobnika Najlepszy { get; set; }

        public TypOsobnika Szukaj(int liczbaIteracji)
        {
            TypOsobnika[] populacja = LosowaPopulacja(RozmiarPopulacji);
            float[] przystosowanie = new float[RozmiarPopulacji];
            int[] rodzice = new int[RozmiarPopulacji];

            while (liczbaIteracji > 0)
            {
                for (int i = 0; i < RozmiarPopulacji; i++)
                    przystosowanie[i] = Przystosowanie(populacja[i]);

                TypOsobnika wynik = Koniec(false, przystosowanie, populacja);
                if (wynik != null)
                    return wynik;

                LosowanieDoKrzyzowania(przystosowanie, rodzice);
                TypOsobnika[] nowaPopulacja = new TypOsobnika[RozmiarPopulacji];
                for (int i = 0; i < rodzice.Length; i += 2)
                    Krzyzuj(populacja[rodzice[i]], populacja[rodzice[i + 1]],
                        out nowaPopulacja[i], out nowaPopulacja[i + 1]);

                for (int i = 0; i < nowaPopulacja.Length; i++)
                    nowaPopulacja[i] = Mutacja(nowaPopulacja[i]);

                populacja = nowaPopulacja;
                liczbaIteracji--;
            }
            return Koniec(true, przystosowanie, populacja);
        }

        void LosowanieDoKrzyzowania(float[] przystosowanie, int[] rodzice)
        {
            Random r = new Random();
            float[] progi = Progi(przystosowanie);
            var iloscElementow = przystosowanie.Length;
            for (int i = 0; i < iloscElementow - 1; i++)
            {
                rodzice[i] = Indeks((float)r.NextDouble(), progi);
                int liczbaIteracji = 100;
                do
                {
                    rodzice[i + 1] = Indeks((float)r.NextDouble(), progi);
                    liczbaIteracji--;
                }
                while (rodzice[i] == rodzice[i + 1] && liczbaIteracji > 0);
            }
        }

        private float[] Progi(float[] przystosowanie)
        {
            float[] progi = new float[przystosowanie.Length];
            float suma = 0;
            for (int i = 0; i < progi.Length; i++)
            {
                suma += przystosowanie[i];
                progi[i] = suma;
            }
            for (int i = 0; i < progi.Length; i++)
                progi[i] /= suma;
            return progi;
        }

        private int Indeks(float x, float[] progi)
        {
            int a = 0, b = progi.Length - 1;
            do
            {
                int c = (a + b) / 2;
                if (c == a)
                    return c;
                if (progi[c] >= x)
                    b = c;
                else
                    a = c;
            } while (a < b);
            return a;
        }
    }
}
