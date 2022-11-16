namespace generic
{
    using System;

    // We use < > to specify Parameter type
    public class GC<T>
    {
        // private data members
        private T data;

        // using properties
        public T value
        {
            // using accessors
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
    }

    // Driver class
    class Test
    {
        static void Main(string[] args)
        {

            // instance of string type
            GC<string> name = new GC<string>();
            name.value = "SakshiSapkale";

            // instance of float type
            GC<float> version = new GC<float>();
            version.value = 5.0F;

            Console.WriteLine(name.value);

            Console.WriteLine(version.value);
            Console.ReadLine();
        }
    }
}
