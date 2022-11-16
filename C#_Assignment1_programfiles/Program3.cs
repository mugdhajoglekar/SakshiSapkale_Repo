namespace ConsoleApp3_assgn1_Q3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        enum Country { INDIA=10, AUSTRALIA, USA, JAPAN, FRANCE, ENGLAND };
        static void Main(string[] args)
        {
            int x = (int)Country.INDIA;
            int y = (int)Country.USA;
            int z= (int)Country.ENGLAND;
            Console.WriteLine("INDIA ={0} ", x);
            Console.WriteLine("USA = {0}", y);
            Console.WriteLine("ENGLAND = {0}", z);

            //traversing all values
            foreach (Country c in Enum.GetValues(typeof(Country)))  
            {  
                Console.WriteLine(c);  
            }  
            Console.ReadLine();
        }
    }
}
