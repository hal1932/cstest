using System;
using System.Collections.Generic;

public class Test : MarshalByRefObject
{
    public void Void()
    {
        Console.WriteLine("void");
    }

    public int Int(int i)
    {
        return i;
    }

    public string String(string s)
    {
        return s;
    }

    public List<int> ListInt(List<int> l)
    {
        return l;
    }
}