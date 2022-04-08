﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public abstract class WriterLogger : ILogger
    {
        protected TextWriter writer;
        string path = @"../log.txt";

        public virtual void Log(params string[] messages)
        {
            using (FileStream stream = new FileStream(path, FileMode.Append))
            {
                using (writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write($"{DateTime.Now}: ");
                    for (int i = 0; i < messages.Length; i++)
                    {
                        writer.Write(messages[i]);
                    }
                    writer.Write("\n");
                    writer.Flush();
                }
            }
        }

        public abstract void Dispose(bool v);

        public void Dispose()
        {
            writer.Dispose();
        }
    }
}
