using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    public static class Extensions
    {
        public static string CustomReverse(this string word)
        {
            StringBuilder sb = new();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }
            return sb.ToString();
        }

        public static int CustomIntPow(this object num, int power)
        {
            if (num is decimal  || num is double  || num is int || num is float )
            {
                int result = 1;
                for (int i = 0; i < power; i++)
                {
                    result *= Convert.ToInt32(num);
                }
                return result;
            }
            throw new ArgumentException("Object type must be a number value.");
        }
    }
}
