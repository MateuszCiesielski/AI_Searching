using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public class Przesuwanka : IProblem<byte[,]>
    {
        private byte[,] initial, goal;

        public Przesuwanka(byte[,] initial, byte[,] goal)
        {
            this.initial = initial;
            this.goal = goal;
        }

        public byte[,] InitialState { get { return initial; } }

        public bool StateCompare(byte[,] state1, byte[,] state2)
        {
            for (byte i = 0; i < state1.GetLength(0); i++)
            {
                for (byte j = 0; j < state1.GetLength(1); j++)
                {
                    if (state1[i, j] != state2[i, j]) return false;
                }
            }
            return true;
        }

        public bool IsGoal(byte[,] state)
        {
            return StateCompare(goal, state);
        }

        public void SetRandomInitialState()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                List<byte[,]> temp = (List<byte[,]>) Expand(initial);
                initial = temp[rnd.Next(0, temp.Count)];
            }
        }

        public IList<byte[,]> Expand(byte[,] state)
        {
            IList<byte[,]> ret = new List<byte[,]>();
            int x = -1, y = -1;
            int lenghtX = state.GetLength(0);
            int lenghtY = state.GetLength(1);

            for (int i = 0; i < lenghtX; i++)
            {
                for (int j = 0; j < lenghtY; j++)
                {
                    if (state[i,j] == 0)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            if (x == -1 || y == -1) throw new Exception();

            if (x + 1 < lenghtX)
            {
                byte[,] subRet = (byte[,])state.Clone();
                subRet[x, y] = subRet[x + 1, y];
                subRet[x + 1, y] = 0;
                ret.Add(subRet);
            }
            if (x - 1 >= 0)
            {
                byte[,] subRet = (byte[,])state.Clone();
                subRet[x, y] = subRet[x - 1, y];
                subRet[x - 1, y] = 0;
                ret.Add(subRet);
            }
            if (y + 1 < lenghtY)
            {
                byte[,] subRet = (byte[,])state.Clone();
                subRet[x, y] = subRet[x, y + 1];
                subRet[x, y + 1] = 0;
                ret.Add(subRet);
            }
            if (y - 1 >= 0)
            {
                byte[,] subRet = (byte[,])state.Clone();
                subRet[x, y] = subRet[x, y - 1];
                subRet[x, y - 1] = 0;
                ret.Add(subRet);
            }

            return ret;
        }

        public int EstimatedCostToGoal(byte[,] state)
        {
            int sum = 0;
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    int x = state[i, j] / state.GetLength(0);
                    int y = state[i, j] % state.GetLength(0);
                    sum += Math.Abs(x - i) + Math.Abs(y - j);
                }
            }
            return sum;
        }

        public int GetCurrentCost(byte[,] state, byte[,] prievousState, int prievousCost)
        {
            if (prievousState == null)
            {
                return 0;
            }
            return prievousCost + 1;
        }

        public void Print(byte[,] state)
        {
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    Console.Write(state[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}