using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie
{
    public class StackFringe<Element> : IFringe<Element>
    {
        private Stack<Element> stack = new Stack<Element>();

        public Func<Element, int> GetCost { get; set; }

        public bool IsEmpty
        {
            get
            {
                return stack.Count == 0;
            }
        }

        public void Add(Element element)
        {
            stack.Push(element);
        }

        public Element Pop()
        {
            return stack.Pop();
        }
    }
}
