
namespace ConsoleApp1_assign2_Q1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void excep(int value)
        {
            Console.WriteLine(value);
            excep(++value);
        }
        static void StackOverFlow()
        {
            try
            {
                excep(0);
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        static void divideByzero()
        {
            int a = 10;
            int b = 0;
            int c = 0;

            try
            {
                c = a / b;
                Console.WriteLine(c);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void nullreference()
        {
            try
            {
                string value = null;
                if (value.Length == 0)
                {
                    Console.WriteLine(value);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
             divideByzero();
             //nullreference();
            StackOverFlow();
            Console.ReadLine();
            
        }
    }
}
