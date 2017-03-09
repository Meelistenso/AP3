using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    class Node<T> : IComparable
    where T:IComparable
    {
        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }

        public int CompareTo(object other)
        {

            if (Value.Equals(other)) return 0;
            else if (Convert.ToInt32(other) > Convert.ToInt32(Value)) return 1;
            else if (Convert.ToInt32(other) < Convert.ToInt32(Value)) return -1;
            return 666;
        }
    }
}