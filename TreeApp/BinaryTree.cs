using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    public class BinaryTree<T> : IEnumerable
        where T : IComparable
    {
        private Node<T> _head;
        private int _count;

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        Node<T> constructBalancedTree(List<T> values, int min, int max)
        {
            int median =min+ (max - min) / 2;
            if (max-min<2)
                return null;
            
            return new Node<T>(values[median])
            {
                Left = constructBalancedTree(values, min, median),
                Right = constructBalancedTree(values, median + 1, max)
            };
        }

        public void constructBalancedTree(BinaryTree<T> values)
        {
            List<T> list = new List<T>();

            foreach (T value in values)
            {
                list.Add(value);
            }
            _head = constructBalancedTree(
                list, 0, list.Count());
        }
    

        
        private void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            Node<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            Node<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public int Count
        {
            get { return _count; }
        }

        public bool Remove(T value)
        {
            Node<T> current, parent;

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            _count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }

                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost; leftmost = leftmost.Left;
                }
                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null) { _head = leftmost; }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }
        public IEnumerator GetEnumerator()
        {
            return InOrderTraversal();
        }

        public IEnumerator InOrderTraversal()
        {
            if (_head != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();

                Node<T> current = _head;

                bool goLeftNext = true;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Value;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }

            }
        }
    }
}
