using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public class NHetmanów : IProblem<byte[]>
    {
        private byte[] initial;

        public NHetmanów(byte[] initial)
        {
            this.initial = initial;
        }

        public byte[] InitialState { get { return initial; } }

        public bool StateCompare(byte[] state1, byte[] state2)
        {
            for (byte i = 0; i < state1.Length; i++)
            {
                if (state1[i] != state2[i]) return false;
            }
            return true;
        }

        public bool IsGoal(byte[] state)
        {
            return EstimatedCostToGoal(state) == 0;
        }

        public void SetRandomInitialState()
        {
            Random rnd = new Random();
            for (int i = 0; i < initial.Length; i++)
            {
                initial[i] = (byte)(rnd.Next(initial.Length) + 1);
            }
        }

        public IList<byte[]> Expand(byte[] state)
        {
            IList<byte[]> ret = new List<byte[]>();
            int cost = EstimatedCostToGoal(state);
            for (int i = 0; i < state.Length; i++)
            {

                for (byte j = 1; j <= state.Length; j++)
                {
                    byte[] newState = new byte[state.Length];
                    Array.Copy(state, newState, state.Length);
                    newState[i] = j;
                    if (EstimatedCostToGoal(state) <= cost) ret.Add(newState);
                }
            }
            return ret;
        }

        public int GetCurrentCost(byte[] state, byte[] prievousState, int prievousCost)
        {
            if (prievousState == null)
            {
                return 0;
            }
            return prievousCost + 1;
        }

        public int EstimatedCostToGoal(byte[] state)
        {
            int checkCount = 0;
            for (int i = 0; i < state.Length; i++)
            {
                for (int j = i + 1; j < state.Length; j++)
                {
                    if (state[i] == state[j]) checkCount++;
                    if (Math.Abs(state[i] - i) == Math.Abs(state[j] - j)) checkCount++;
                }
            }
            return checkCount;
        }

        public void Print(byte[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                Console.Write(state[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
