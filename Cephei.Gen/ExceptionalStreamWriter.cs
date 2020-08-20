using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen
{
    /// <summary>
    /// Stream writer that ignores exceptions
    /// </summary>
    class ExceptionalStreamWriter
    {
        StreamWriter _stream;

        public ExceptionalStreamWriter(string path)
        {
            try
            {
                _stream = new StreamWriter(path);
            }
            catch
            {
                Console.WriteLine("**** Could not open {0} ", path);
            }
        }

        public void WriteLine(string value)
        {
            if (_stream != null)
                _stream.WriteLine(value);
        }
        public void Close ()
        {
            if (_stream != null)
                _stream.Close();
        }
    }
}
