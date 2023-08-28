using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Point
{
    public class Pointe
    {
        int x;
        int y;
        public Pointe() { }

        public Pointe(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public override string ToString()
        {
            return $"Point (x={x}, y={y})";
        }
        public List<Pointe> FillPoints()
        {
            List<Pointe> mylist = new List<Pointe>();
            x = 0;y = 0;
            for (int i = 0; i < 10; i++)
            {
                Pointe p = new Pointe(x,y);
                mylist.Add(p);
                x++;y++;
             }
            return mylist;  
        }
    }
    internal class Program
    {
        static void ThreadParam(object obj)
        {
            List <Pointe> mylist = (List<Pointe>)obj;//преобразов.обьекта в лист
            Thread t = Thread.CurrentThread;
            foreach (var i in mylist)
            {
                Console.WriteLine("Работает " + t.Name + " поток!\t" + i.ToString());
                Thread.Sleep(1000);
            }

            Console.WriteLine("Завершает работу " + t.Name + " поток!");
        }
        static void ThreadParam2(object obj)
        {
            List<Pointe> mylist = (List<Pointe>)obj;//преобразов.обьекта в лист
            Thread t = Thread.CurrentThread;
            foreach (var i in mylist)
            {
                Console.WriteLine("Работает " + t.Name + " поток!\t" + i.ToString());
                Thread.Sleep(500);
            }

            Console.WriteLine("Завершает работу " + t.Name + " поток!");
        }
        static void Main(string[] args)
        {
            Pointe point = new Pointe();
           
            Thread th = new Thread(new ParameterizedThreadStart(ThreadParam));
            th.Name = "First";
            th.Start(point.FillPoints());

          
            Thread th2 = new Thread(new ParameterizedThreadStart(ThreadParam2));
            th2.Name = "Second";         
            th2.Start(point.FillPoints());
        }
    }
}
