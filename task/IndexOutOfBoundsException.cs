using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class IndexOutOfBoundsException : Exception
    {
        public IndexOutOfBoundsException(string message) : base(message)
        {
            
        }
        public IndexOutOfBoundsException() : base("Index out of bounds of the array.")
        {
            
        }
    }
}
