using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start;
            DateTime stop;

            Console.WriteLine("Wybierz problem:\n\n1. Przesuwanka 3x3\n2. Przesuwanka 4x4\n3. N Hetmanów\n4. Mapa Rumunii\n\n");
            char problem = Convert.ToChar(Console.ReadKey().KeyChar);
            Console.Clear();
            switch(problem)
            {
                case '1':
                    Przesuwanka przesuwanka = new Przesuwanka(Examples.PrzesuwankaGoal, Examples.PrzesuwankaGoal);
                    przesuwanka.SetRandomInitialState();
                    Console.WriteLine("DFS:");
                    Console.WriteLine("Initial: ");
                    przesuwanka.Print(przesuwanka.InitialState);
                    start = DateTime.Now;
                    Node<byte[,]> goal = Searching.TreeSearchWithQueue(przesuwanka, new StackFringe<Node<Byte[,]>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka.Print(goal.state);
                    Console.WriteLine("Koszt ścieżki: " + goal.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    start = DateTime.Now;
                    goal = Searching.TreeSearchWithQueue(przesuwanka, new QueueFringe<Node<Byte[,]>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka.Print(goal.state);
                    Console.WriteLine("Koszt ścieżki: " + goal.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    start = DateTime.Now;
                    goal = Searching.TreeSearchWithQueue(przesuwanka, new PriorityQueueFringe<Node<Byte[,]>>(), false); //BestFS
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka.Print(goal.state);
                    Console.WriteLine("Koszt ścieżki: " + goal.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    start = DateTime.Now;
                    goal = Searching.TreeSearchWithQueue(przesuwanka, new PriorityQueueFringe<Node<Byte[,]>>(), true); //A*
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka.Print(goal.state);
                    Console.WriteLine("Koszt ścieżki: " + goal.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    break;
                case '2':
                    Przesuwanka przesuwanka4 = new Przesuwanka(Examples.PrzesuwankaInit4, Examples.PrzesuwankaGoal4);
                    //przesuwanka.SetRandomInitialState();
                    Console.WriteLine("DFS:");
                    Console.WriteLine("Initial: ");
                    przesuwanka4.Print(przesuwanka4.InitialState);
                    start = DateTime.Now;
                    Node<byte[,]> goal2 = Searching.TreeSearchWithQueue(przesuwanka4, new StackFringe<Node<Byte[,]>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka4.Print(goal2.state);
                    Console.WriteLine("Koszt ścieżki: " + goal2.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal2.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    Console.WriteLine("BFS:");
                    start = DateTime.Now;
                    goal2 = Searching.TreeSearchWithQueue(przesuwanka4, new QueueFringe<Node<Byte[,]>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka4.Print(goal2.state);
                    Console.WriteLine("Koszt ścieżki: " + goal2.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal2.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    Console.WriteLine("BestFS:");
                    start = DateTime.Now;
                    goal2 = Searching.TreeSearchWithQueue(przesuwanka4, new PriorityQueueFringe<Node<Byte[,]>>(), false); //BestFS
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka4.Print(goal2.state);
                    Console.WriteLine("Koszt ścieżki: " + goal2.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal2.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    Console.WriteLine("A*:");
                    start = DateTime.Now;
                    goal2 = Searching.TreeSearchWithQueue(przesuwanka4, new PriorityQueueFringe<Node<Byte[,]>>(), true); //A*
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    przesuwanka4.Print(goal2.state);
                    Console.WriteLine("Koszt ścieżki: " + goal2.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal2.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    break;
                case '3':
                    NHetmanów nHetmanów = new NHetmanów(Examples.NHetmanówInit);
                    nHetmanów.SetRandomInitialState();
                    nHetmanów.Print(nHetmanów.InitialState);
                    /*Console.WriteLine("DFS:");
                    start = DateTime.Now;
                    Node<byte[]> goal3 = Searching.TreeSearchWithQueue(nHetmanów, new StackFringe<Node<Byte[]>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Initial: ");
                    nHetmanów.Print(nHetmanów.InitialState);
                    Console.WriteLine("Goal: ");
                    nHetmanów.Print(goal3.state);
                    Console.WriteLine("Koszt ścieżki: " + goal3.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal3.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);*/
                    Console.WriteLine("BFS:");
                    start = DateTime.Now;
                    Node<byte[]> goal3 = Searching.TreeSearchWithQueue(nHetmanów, new StackFringe<Node<Byte[]>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    nHetmanów.Print(goal3.state);
                    Console.WriteLine("Koszt ścieżki: " + goal3.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal3.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    Console.WriteLine("BestFS:");
                    start = DateTime.Now;
                    goal3 = Searching.TreeSearchWithQueue(nHetmanów, new PriorityQueueFringe<Node<Byte[]>>(), false); //BestFS
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    nHetmanów.Print(goal3.state);
                    Console.WriteLine("Koszt ścieżki: " + goal3.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal3.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    Console.WriteLine("A*:");
                    start = DateTime.Now;
                    goal3 = Searching.TreeSearchWithQueue(nHetmanów, new PriorityQueueFringe<Node<Byte[]>>(), true); //A*
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    nHetmanów.Print(goal3.state);
                    Console.WriteLine("Koszt ścieżki: " + goal3.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal3.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    break;
                case '4':
                    // ----
                    Console.WriteLine("DFS:");
                    Mapa mapa = new Mapa(Examples.Rumunia["Arad"], Examples.Rumunia["Bucharest"], Examples.Rumunia);
                    Console.WriteLine("Initial: ");
                    mapa.Print(mapa.InitialState);
                    start = DateTime.Now;
                    Node<City> goal4 = Searching.TreeSearchWithQueue(mapa, new StackFringe<Node<City>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine("Goal: ");
                    mapa.Print(goal4.state);
                    Console.WriteLine();
                    foreach(var g in goal4.PathToRoot)
                    {
                        Console.WriteLine(g.state.Name);
                    }
                    Console.WriteLine("Koszt ścieżki: " + goal4.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal4.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    // ----
                    Console.WriteLine();
                    Console.WriteLine("BFS:");
                    start = DateTime.Now;
                    goal4 = Searching.TreeSearchWithQueue(mapa, new QueueFringe<Node<City>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine();
                    Console.WriteLine("Goal: ");
                    mapa.Print(goal4.state);
                    Console.WriteLine();
                    foreach (var g in goal4.PathToRoot)
                    {
                        Console.WriteLine(g.state.Name);
                    }
                    Console.WriteLine("Koszt ścieżki: " + goal4.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal4.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    // ----
                    Console.WriteLine();
                    Console.WriteLine("BestFS:");
                    start = DateTime.Now;
                    goal4 = Searching.TreeSearchWithQueue(mapa, new PriorityQueueFringe<Node<City>>(), false);
                    stop = DateTime.Now;
                    Console.WriteLine();
                    Console.WriteLine("Goal: ");
                    mapa.Print(goal4.state);
                    Console.WriteLine();
                    foreach (var g in goal4.PathToRoot)
                    {
                        Console.WriteLine(g.state.Name);
                    }
                    Console.WriteLine("Koszt ścieżki: " + goal4.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal4.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    // ----
                    Console.WriteLine();
                    Console.WriteLine("A*:");
                    start = DateTime.Now;
                    goal4 = Searching.TreeSearchWithQueue(mapa, new PriorityQueueFringe<Node<City>>(), true);
                    stop = DateTime.Now;
                    Console.WriteLine();
                    Console.WriteLine("Goal: ");
                    mapa.Print(goal4.state);
                    Console.WriteLine();
                    foreach (var g in goal4.PathToRoot)
                    {
                        Console.WriteLine(g.state.Name);
                    }
                    Console.WriteLine("Koszt ścieżki: " + goal4.CurrentCost);
                    Console.WriteLine("Liczba kroków: " + goal4.GetSteps);
                    Console.WriteLine("Czas wykonania: " + (stop - start).TotalMilliseconds);
                    break;
                default:
                    break;
            }
        }
    }
}
