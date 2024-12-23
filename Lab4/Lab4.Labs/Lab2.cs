﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Lab4.Labs
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

        public static void WriteAnswer(string inputFilePath, string outputFilePath)
        {
            string? readInput = "";

            using (StreamReader input = new StreamReader(inputFilePath))
            {
                readInput = input.ReadLine();

                if (readInput == null)
                    throw new Exception(
                        "Could not read the input number"
                    );
            }

            int number = Int32.Parse(readInput);

            if (number < 1 || number > 1000)
                throw new Exception("The input number is too big or too small");

            using (StreamWriter output = new StreamWriter(outputFilePath))
            {
                output.WriteLine(
                    new BinarySumsNumberCalculator().Calculate(number)
                );
            }
        }
    }
}
