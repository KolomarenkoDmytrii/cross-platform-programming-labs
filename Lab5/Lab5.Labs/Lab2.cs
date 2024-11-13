using System;
using System.IO;
using System.Collections.Generic;

namespace Lab5.Labs
{
    public class Lab2
    {
        public class BinarySumsNumberCalculator
        {
            private Dictionary<int, int> _cache;

            public BinarySumsNumberCalculator()
            {
                _cache = new Dictionary<int, int>();
            }

            public int Calculate(int number)
            {
                if (number < 1)
                    return 0;
                if (number == 1)
                    return 1;
                if (number == 2)
                    return 2;

                int result = 0;

                if (_cache.ContainsKey(number))
                    return _cache[number];
                else
                {
                    result = Calculate(number / 2) + Calculate(number - 2);
                    _cache[number] = result;
                }

                return result;
            }
        }

        public static int Run(int number)
        {
            return new BinarySumsNumberCalculator().Calculate(number);
        }
    }
}
