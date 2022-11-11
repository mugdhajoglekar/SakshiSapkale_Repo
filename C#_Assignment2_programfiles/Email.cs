
namespace ConsoleApp4_assign1_Q4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    internal class Program
    {
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any Email :");
            string email = Console.ReadLine();
            if (EmailIsValid(email))
            {
                Console.WriteLine("Email is valid");
            }
            else
            {
                Console.WriteLine("Email is not valid");
            }
            Console.ReadLine();
        }
    }
}
