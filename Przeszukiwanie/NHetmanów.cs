using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public class NHetmanów : IProblem<byte[]>
    {
        private byte[] initial, goal;

        public NHetmanów(byte[] initial, byte[] goal)
        {
            this.initial = initial;
            this.goal = goal;
        }

        public byte[] InitialState { get { return initial; } }

        public bool StateCompare(byte[] state1, byte[] state2)
        {
            for (int i = 0; i < state1.Length; i++)
            {
                if (state1[i] != state2[i]) return false;
            }
            return true;
        }

        public bool IsGoal(byte[] state)
        {
            return StateCompare(goal, state);
        }

        public IList<byte[]> Expand(byte[] state)
        {
            throw new NotImplementedException();
        }
    }
}
