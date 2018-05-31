using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public static class Examples
    {
        public static byte[,] PrzesuwankaGoal
        {
            get
            {
                return new byte[,]
                {
                    { 0, 1, 2 },
                    { 3, 4, 5 },
                    { 6, 7, 8 }
                };
            }
        }

        public static byte[,] PrzesuwankaGoal4
        {
            get
            {
                return new byte[,]
                {
                    { 0, 1, 2, 3 },
                    { 4, 5, 6, 7 },
                    { 8, 9, 10, 11 },
                    { 12, 13, 14, 15 }
                };
            }
        }

        public static byte[,] PrzesuwankaInit
        {
            get
            {
                return new byte[,]
                {
                    { 2, 7, 3 },
                    { 0, 1, 4 },
                    { 8, 6, 5 }
                };
            }
        }

        public static byte[,] PrzesuwankaInit4
        {
            get
            {
                return new byte[,]
                {
                    { 9, 7, 0, 11 },
                    { 1, 6, 8, 10 },
                    { 13, 5, 3, 4 },
                    { 12, 14, 2, 15 }
                };
            }
        }

        public static byte[] NHetmanówInit
        {
            get
            {
                return new byte[] { 5, 3, 3, 2, 7, 8, 7, 6 };
            }
        }

        public static byte[] NHetmanówInit2
        {
            get
            {
                return new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            }
        }

        public static Dictionary<string, City> Rumunia
        {
            get
            {
                return new Dictionary<string, City>()
                {
                    { "Arad",
                    new City("Arad", new Dictionary<string, int>() { {"Zerind", 75}, {"Timisoara", 118}, {"Sibiu", 140} }, 62, 154)
                    },
                    { "Zerind",
                    new City("Zerind", new Dictionary<string, int>() { {"Oradea", 71 }, {"Arad", 75} }, 94, 84)
                    },
                    { "Oradea",
                    new City("Oradea", new Dictionary<string, int>() { {"Sibiu", 151 }, {"Zerind", 71} }, 135, 17)
                    },
                    { "Timisoara",
                    new City("Timisoara", new Dictionary<string, int>() { {"Arad", 118 }, {"Lugoj", 111} }, 70, 294)
                    },
                    { "Lugoj",
                    new City("Lugoj", new Dictionary<string, int>() { {"Timisoara", 111 }, {"Mehadia", 70} }, 189, 346)
                    },
                    { "Drobeta",
                    new City("Drobeta", new Dictionary<string, int>() { {"Mehadia", 70 }, { "Craiova", 120} }, 189, 487)
                    },
                    { "Sibiu",
                    new City("Sibiu", new Dictionary<string, int>() { {"Oradea", 151 }, { "Arad", 140}, { "Fagaras", 99 }, { "Rimmicu Vilcea", 80} }, 261, 212)
                    },
                    { "Fagaras",
                    new City("Fagaras", new Dictionary<string, int>() { {"Sibiu", 99 }, { "Bucharest", 211} }, 436, 225)
                    },
                    { "Rimmicu Vilcea",
                    new City("Rimmicu Vilcea", new Dictionary<string, int>() { {"Sibiu", 80 }, { "Craiova", 146}, { "Pitesti", 97 } }, 306, 296)
                    },
                    { "Craiova",
                    new City("Craiova", new Dictionary<string, int>() { {"Drobeta", 120 }, { "Pitesti", 138}, { "Rimmicu Vilcea", 97 } }, 341, 506)
                    },
                    { "Bucharest",
                    new City("Bucharest", new Dictionary<string, int>() { {"Pitesti", 97 }, { "Giurgiu", 90}, { "Urziceni", 85 }, { "Fagaras", 211 } }, 597, 437)
                    },
                    { "Urziceni",
                    new City("Urziceni", new Dictionary<string, int>() { { "Bucharest", 85 }, { "Hirsova", 98}, { "Vaslui", 142} }, 698, 395)
                    },
                    { "Giurgiu",
                    new City("Giurgiu", new Dictionary<string, int>() { { "Bucharest", 90} }, 552, 535)
                    },
                    { "Hirsova",
                    new City("Hirsova", new Dictionary<string, int>() { {"Urziceni", 98 }, { "Eforie", 86} }, 827, 399)
                    },
                    { "Vaslui",
                    new City("Vaslui", new Dictionary<string, int>() { {"Urziceni", 142 }, { "Iasi", 92} }, 785, 236)
                    },
                    { "Iasi",
                    new City("Iasi", new Dictionary<string, int>() { {"Vaslui", 92 }, { "Neamt", 87} }, 723, 126)
                    },
                    { "Neamt",
                    new City("Neamt", new Dictionary<string, int>() { {"Iasi", 87} }, 604, 72)
                    },
                    { "Eforie",
                    new City("Eforie", new Dictionary<string, int>() { {"Hirsova", 86} }, 878, 496)
                    },
                    { "Mehadia",
                    new City("Mehadia", new Dictionary<string, int>() { {"Lugoj", 70 }, { "Drobeta", 75} }, 193, 419)
                    },
                    { "Pitesti",
                    new City("Pitesti", new Dictionary<string, int>() { {"Rimmicu Vilcea", 97 }, { "Craiova", 138}, { "Bucharest", 101} }, 459, 367)
                    },
                };
            }
        }
    }
}