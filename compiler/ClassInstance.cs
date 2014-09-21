using lib;
using System;

namespace compiler
{
    public class ClassInstance : MarshalByRefObject, IClassInstance
    {
        private Type _type;
        private object _instance;

        public ClassInstance(Type type)
        {
            _type = type;
            _instance = type.GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public object InvokeMethod(string name, params object[] args)
        {
            var method = _type.GetMethod(name);
            return method.Invoke(_instance, args);
        }
    }
}
