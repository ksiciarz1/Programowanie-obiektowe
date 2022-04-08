using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class FileLogger : WriterLogger
    {
        bool disposed;
        protected FileStream stream;
        string path;

        ~FileLogger()
        {
            this.Dispose();
        }

        public override void Dispose(bool v)
        {
            stream.Dispose();
            path = null;
            disposed = true;
        }

        public FileLogger(string path)
        {
            this.path = path;
        }
    }
}
