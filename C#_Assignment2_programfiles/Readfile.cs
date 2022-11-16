namespace readfile
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            // Store the path of the textfile in your system
            string file = @"C:\Users\sakshi.sapkale\Documents\textread.txt";

            // To write all of the text to the file
            string text1 = "This is some text.";
            File.WriteAllText(file, text1);

            // To append text to a file
            string text2 = "This is text to be appended";
            File.AppendAllText(file, text2);

            // To display current contents of the file
            Console.WriteLine(File.ReadAllText(file));
            Console.ReadKey();
        }
    }

}
