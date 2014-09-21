using System.IO;

namespace lib
{
    public class StringWriterWithEvent : StringWriter
    {
        public event OnFlushed Flushed;
        public delegate void OnFlushed();

        public event OnWritten Written;
        public delegate void OnWritten(string str);

        public bool AutoFlush { get; set; }


        public override void Flush()
        {
            base.Flush();
            if (Flushed != null) Flushed();
        }


        public override void Write(bool value)
        {
            base.Write(value);
            if (Written != null) Written(value.ToString());
            if (AutoFlush) Flush();
        }

        public override void Write(char[] buffer)
        {
            base.Write(buffer);
            if (Written != null) Written(new string(buffer));
            if (AutoFlush) Flush();
        }

        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            if (Written != null) Written(new string(buffer, index, count));
            if (AutoFlush) Flush();
        }
    }
}
