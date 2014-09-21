using lib;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace compiler
{
    public class Compiler : MarshalByRefObject, ICompiler
    {
        private CSharpCodeProvider _provider;
        private CompilerResults _results;


        public bool Compile(string src)
        {
            var param = new CompilerParameters(new string[]
            {
                "System.dll",
                "mscorlib.dll",
                "System.Data.dll",
                "System.Xml.dll",
                "System.Xml.Linq.dll",
                "compiler.dll",
            });
            param.GenerateInMemory = true;
            param.GenerateExecutable = false;
            param.IncludeDebugInformation = false;

            _provider = new CSharpCodeProvider(
                new Dictionary<string, string>()
                {
                    { "CompilerVersion", "v4.0" },
                });
            _results = _provider.CompileAssemblyFromSource(param, src);
            if (_results.Errors.Count > 0)
            {
                foreach (CompilerError err in _results.Errors)
                {
                    if (err.IsWarning) Console.WriteLine("[Warning] {0}: [{1}] {2}", err.Line, err.ErrorNumber, err.ErrorText);
                    else Console.WriteLine("[Error] {0}: [{1}] {2}", err.Line, err.ErrorNumber, err.ErrorText);
                }
                return false;
            }

            return true;
        }


        public IClassInstance CreateInstance(string name)
        {
            var type = _results.CompiledAssembly.GetType(name);
            return new ClassInstance(type);
        }
    }
}
