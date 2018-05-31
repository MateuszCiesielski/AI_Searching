using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public interface IProblem<State>
    {
        State InitialState { get; }
        bool IsGoal(State state);
        IList<State> Expand(State state);
        int GetCurrentCost(State state, State prievousState, int prievousCost);
        int EstimatedCostToGoal(State state);
        bool StateCompare(State state1, State state2);
        void Print(State state);
    }

    public interface IFringe<Element>
    {
        void Add(Element element);
        bool IsEmpty { get; }
        Func<Element, int> GetCost { get; set; }
        Element Pop();
    }
}