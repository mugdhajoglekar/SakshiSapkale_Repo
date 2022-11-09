using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void substring(string s1, int index)
        {
            string reversedString = String.Empty;

            for (int i = index; i < s1.Length; i++)
            {
                reversedString += s1[i];

            }
            Console.WriteLine(reversedString);  
        }
        static void compareString(string s1, string s2)
        {
            if (s1 == s2)
                Console.WriteLine("Strings are same");
            else
                Console.WriteLine("string are not same");
        }

        static void concatString(string s1, string s2)
        {
            Console.WriteLine(s1+s2);

        }
        static void reverse(string Input)
        {
            // Converting string to character array
            char[] charArray = Input.ToCharArray();
            // Declaring an empty string
            string reversedString = String.Empty;
            // Iterating each character from right to left
            for (int i = charArray.Length - 1; i > -1; i--)
            {
                // Append each character to the reversedstring.
                reversedString += charArray[i];
            }
            Console.WriteLine($"After Reverse: {reversedString}");
        }
        static void Main(string[] args)
        {
            /*
            1.Write a C# program that performs all string operations like COMPARE, CONCAT, SUBSTRING, REVERSE using – 
            a.Manual Array operations for character array ‘char[]’
            b.Built -in functions for ‘string’ variables
            */

            string data1 = "Hello";
            string data2 = "Hello";
            string data3 = "Are you rocking?";

            //If both strings are equal, it returns 0, else -1
            Console.WriteLine(string.Compare(data1, data2));
            Console.WriteLine(string.Compare(data2, data3));

            //concat two strings
            Console.WriteLine(string.Concat(data2,data3));

            //retrieves a substring from the current string
            Console.WriteLine(data3.Substring(4));

            //reverse string using inbuilt function
            var resultstring = new string(data1.ToCharArray().Reverse().ToArray());
            Console.WriteLine(resultstring);

            Console.WriteLine("Using Manual array:");
            compareString(data1, data2);
            concatString(data1, data3);
            reverse(data1);
            substring(data1, 2);

            Console.ReadLine();
        }
    }
}
