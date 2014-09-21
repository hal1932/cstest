
namespace lib
{
    public interface IClassInstance
    {
        object InvokeMethod(string name, params object[] args);
    }

    public interface ICompiler
    {
        bool Compile(string src);
        IClassInstance CreateInstance(string name);
    }
}
