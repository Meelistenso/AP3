using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LambdaMicrobenchmarking;
using System.Reflection;
using System.Threading;

namespace TreeApp
{
    class Program
    {

        static Random rand = new Random();
        static BinaryTree<int> myTree = new BinaryTree<int>();
        static BinaryTree<int> myTree2 = new BinaryTree<int>();

        static void Main(string[] args)
        {
            //muzON4ik marin = new muzON4ik();
            //Thread muzic = new Thread(marin.Startuem);

        Console.CursorVisible = false;
            Console.WriteLine("Без балансировки (5к)");
            Script.Of("Заполнение случайными", addRandom)
                  .Of("Заполнение последовательными", addCounter)
                  .Of("Выборка случайных", findRandom)
                  .Of("Выборка Последовательных", findCounter)
                  .Of("Удаление случайных", deleteRandom)
                  .WithHead()
                  .RunAll();
            Console.WriteLine();

            Console.WriteLine("Балансировка");
            Script.Of("Случайных", balanceRandom)
                  .Of("Последовательных", balanceCount)
                  .WithHead()
                  .RunAll();
            Console.WriteLine();

            Console.WriteLine("После балансировки (5к)");
            Script
                  .Of("Выборка случайных", findRandom)
                  .Of("Выборка последовательных", findCounter)
                  .Of("Удаление случайных", deleteRandom)
                  .WithHead()
                  .RunAll();
            Console.WriteLine();

            Console.CursorVisible = true;
            Console.WriteLine("Конец");
            Console.Read();
            MissionImpossible();
        }
        private static void MissionImpossible()
        {
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            Thread.Sleep(150);
            Console.Beep(932, 150);
            Console.Beep(784, 150);
            Console.Beep(587, 1200);
            Thread.Sleep(75);
            Console.Beep(932, 150);
            Console.Beep(784, 150);
            Console.Beep(554, 1200);
            Thread.Sleep(75);
            Console.Beep(932, 150);
            Console.Beep(784, 150);
            Console.Beep(523, 1200);
            Thread.Sleep(150);
            Console.Beep(466, 150);
            Console.Beep(523, 150);
        }

        private static bool addRandom()
        {
            for (int i = 0; i < 5000; i++)
            {
                myTree.Add(rand.Next());
            }
            return true;
        }

        private static bool findRandom()
        {
            for (int i = 0; i < 5000; i++)
            {
                myTree.Contains(rand.Next());
            }
            return true;
        }

        private static bool findCounter()
        {
            for (int i = 0; i < 5000; i++)
            {
                myTree2.Contains(rand.Next());
            }
            return true;
        }

        private static bool addCounter()
        {
            for (int i = 0; i < 5000; i++)
            {
                myTree2.Add(i*100);
            }
            return true;
        }

        private static bool balanceRandom()
        {
            myTree.constructBalancedTree(myTree);
            return true;
        }
        private static bool balanceCount()
        {
            myTree2.constructBalancedTree(myTree2);
            return true;
        }

        private static bool deleteRandom()
        {
            for (int i = 5000; i > 0; i--)
            {
                myTree.Add(rand.Next(i));
            }
            return true;
        }
    }
}
