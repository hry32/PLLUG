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
            Console.WriteLine("If you want exit, press: 0");
            do
           {
                Array_Numerals array_Numerals = new Array_Numerals();         
                int value = array_Numerals.InputValue();
                array_Numerals.DividedOnDigital(value);
                array_Numerals.Converter();
            } while (true);
           
        }
    }
    class Array_Numerals
    {
       int[] arrayArabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
       string[] arrayRoman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
       List<int> digital = new List<int>();

        public int InputValue()
        {
            try
            {
                Console.Write("Input arabic numeral: ");
                int intValue = Convert.ToInt32(Console.ReadLine());
                if (intValue < 0)
                {
                    Console.Write("You input incorrect numeric, repeat!\n");
                    Console.WriteLine("********************");
                    return (InputValue());
                }
                else if (intValue == 0)
                {
                    Environment.Exit(1);
                }
                 return intValue;
            }
            catch
            {
                Console.Write("You input incorrect numeric, repeat!\n");
                Console.WriteLine("********************");
                return (InputValue());
            }
        }      
        public void DividedOnDigital(int inputValue)
        {
            foreach (int n in arrayArabic)
            {
                while (inputValue >= n)
                {
                    inputValue -= n;
                    digital.Add(n);
                }
            }
            Console.Write("Divided numeral:      ");
            foreach (int i in digital)
            {
                Console.Write(i + " ");
            }           
        }
            public void Converter()
        {
            int indexA;
            string elementR;
            Console.Write("\nRoman numeral:        ");
            for (int n = 0; n < digital.Count; n++)
            {
                indexA = Array.IndexOf(arrayArabic, digital[n]);
                elementR = arrayRoman[indexA];
                Console.Write(elementR);
            }
            Console.WriteLine("\n********************");
        }        

             
    }
}
