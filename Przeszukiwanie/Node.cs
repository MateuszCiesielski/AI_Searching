using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public class Node<State>
    {
        private void SetPathToRoot(Node<State> node, List<Node<State>> list)
        {
            if (node == null) return;
            list.Add(node);
            steps++;
            SetPathToRoot(node.node, list);
        }
        private int steps;

        public State state { get; private set; }
        public Node<State> node { get; private set; }
        public int CurrentCost { get; private set; }
        public int GetSteps
        {
            get
            {
                return steps;
            }
        }
        public IList<Node<State>> PathToRoot
        {
            get
            {
                List<Node<State>> ret = new List<Node<State>>();
                ret.Add(this);
                steps++;
                SetPathToRoot(node, ret);
                return ret;
            }
        }

        public Node(State state, Node<State> node, int currentCost = 0)
        {
            this.state = state;
            this.node = node;
            this.CurrentCost = currentCost;
            steps = 0;
        }

        public bool OnPathToRoot(State state, Func<State, State, bool> stateCompare)
        {
            if (stateCompare(this.state, state)) return true;
            if (node == null) return false;
            return node.OnPathToRoot(state, stateCompare);
        }
    }
}