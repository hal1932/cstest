using System;
using System.IO;

namespace cstest
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = "";
            using (var reader = new StreamReader("../../test.cs"))
            {
                src = reader.ReadToEnd();
            }

            for (int i = 0; i < 1; ++i)
            {
                new lib.LibTest().test(src);
            }

            Console.WriteLine("over");
            Console.ReadLine();
        }
    }
}
