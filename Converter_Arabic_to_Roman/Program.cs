using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_Arabic_to_Roman
{
    class Program
    {
        static void Main(string[] args)
        {
            Array_Numerals array_Numerals = new Array_Numerals();
            int value = array_Numerals.InputValue();
            array_Numerals.DividedOnDigital(value);
            array_Numerals.Converter();
            Console.ReadKey();
        }
    }
}
