using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public class City
    {
        public IDictionary<string, int> Neighbors { get; private set; }
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public City(string name, IDictionary<string, int> neighbors, int x, int y)
        {
            this.Name = name;
            this.Neighbors = neighbors;
            this.X = x;
            this.Y = y;
        }
    }

    public class Mapa : IProblem<City>
    {
        private City initial, goal;
        private Dictionary<string, City> cities = null;

        public Mapa(City initial, City goal, Dictionary<string, City> cities)
        {
            this.initial = initial;
            this.goal = goal;
            this.cities = cities;
        }

        public City InitialState { get { return initial; } }

        public bool StateCompare(City state1, City state2)
        {
            return state1.Name == state2.Name;
        }

        public bool IsGoal(City state)
        {
            return StateCompare(state, goal);
        }

        public IList<City> Expand(City state)
        {
            IList<City> ret = new List<City>();
            foreach(string neighbor in state.Neighbors.Keys)
            {
                ret.Add(cities[neighbor]);
            }
            return ret;
        }

        public int GetCurrentCost(City state, City prievousState, int prievousCost = 0)
        {
            if (prievousState == null)
            {
                return 0;
            }
            return prievousState.Neighbors[state.Name] + prievousCost;             
        }

        public int EstimatedCostToGoal(City state)
        {
            return (int)Math.Sqrt(Math.Pow(state.X - goal.X, 2) + Math.Pow(state.Y - goal.Y, 2));
        }

        public void Print(City state)
        {
            Console.WriteLine(state.Name);
        }
    }
}
