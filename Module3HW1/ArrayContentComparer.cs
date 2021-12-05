using System;
using System.Collections.Generic;

namespace Module2HW2
{
    public class ArrayContentComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            if (x.GetHashCode() > y.GetHashCode())
            {
                return 1;
            }
            else if (x.GetHashCode() < y.GetHashCode())
            {
                return -1;
            }

            return 0;
        }
    }
}