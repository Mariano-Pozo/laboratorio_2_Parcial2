using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BackLogException : Exception
    {
        public BackLogException() { }

        

    }
    public class BomberoOcupadoException : Exception
    {
        public BomberoOcupadoException() : base()
        {
        }
        public BomberoOcupadoException(string message) : base(message) { }
        public BomberoOcupadoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
