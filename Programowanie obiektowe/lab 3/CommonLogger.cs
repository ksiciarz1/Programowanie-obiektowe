using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class CommonLogger : ILogger
    {
        public ILogger[] loggers;

        public CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public void Log(params string[] messages)
        {
            Console.Write($"{DateTime.Now.ToString()}: ");
            for (int i = 0; i < messages.Length; i++)
            {
                Console.Write(messages[i]);
            }
            Console.Write("\n");
        }
        public void Dispose(bool v)
        {
        }

        public void Dispose()
        {
        }
    }
}
