using System;
using System.IO;

namespace lib
{
    public class ConsoleWriterControl : MarshalByRefObject, IDisposable
    {
        private TextWriter _defaultOut = Console.Out;
        private TextWriter _defaultError = Console.Error;


        #region IDisposable
        private bool _disposed;

        ~ConsoleWriterControl()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed) return;
            Console.SetOut(_defaultOut);
            Console.SetError(_defaultError);
            _disposed = true;
        }
        #endregion


        public void SetOut(TextWriter outWriter)
        {
            Console.SetOut(outWriter);
        }

        public void SetError(TextWriter errorWriter)
        {
            Console.SetError(errorWriter);
        }
    }
}
