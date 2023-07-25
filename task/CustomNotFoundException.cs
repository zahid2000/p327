using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class CustomNotFoundException : Exception
    {
        public CustomNotFoundException(string message) : base(message)
        {
        }

        public CustomNotFoundException(): base()
        {
        }
    }
}
