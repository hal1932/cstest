using System;
using System.Reflection;

namespace lib
{
    public class LibTest
    {
        public void test(string src)
        {
            var domain = AppDomain.CreateDomain(new Random().Next(int.MaxValue).ToString());

            var writer = new StringWriterWithEvent();
            writer.Written += (str) => Console.WriteLine("=====" + str);

            var thisAssemblyName = Assembly.GetExecutingAssembly().FullName;
            var console = domain.CreateInstanceAndUnwrap(thisAssemblyName, "lib.ConsoleWriterControl") as ConsoleWriterControl;
            console.SetOut(writer);
            console.SetError(writer);

            var compiler = domain.CreateInstanceAndUnwrap("compiler", "compiler.Compiler") as ICompiler;
            if (compiler != null && compiler.Compile(src))
            {
                var instance = compiler.CreateInstance("Test");
                instance.InvokeMethod("Void", null);
            }

            Console.Error.WriteLine("hogehoge");

            console.Dispose();
            AppDomain.Unload(domain);

            // compiler.dll をちゃんと手放してるかどうかチェック
            //File.Delete("compiler.dll");
        }
    }
}
