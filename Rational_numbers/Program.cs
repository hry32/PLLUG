using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string eXit;
            do
            {
                int numValue, numValue2;
                int denValue, denValue2;
                Console.WriteLine("Input Rational_1:");
                Rational.InputValue(out numValue, out denValue);
                Console.WriteLine("Input Rational_2:");
                Rational.InputValue(out numValue2, out denValue2);

                Rational.SimpliForm(ref numValue, ref denValue);
                Rational.SimpliForm(ref numValue2, ref denValue2);

                Rational rational_1 = new Rational(numValue, denValue);
                Rational rational_2 = new Rational(numValue2, denValue2);
                
                rational_1.PrintShow("Rational_1", numValue, denValue);
                rational_2.PrintShow("Rational_2", numValue2, denValue2);

                Console.WriteLine("\nAddition (+) = " + (rational_1 + rational_2));
                Console.WriteLine("Multipli (*) = " + (rational_1 * rational_2));
                Console.WriteLine("Subtract (-) = " + (rational_1 - rational_2));
                Console.WriteLine("Division (/) = " + (rational_1 / rational_2));

                Console.WriteLine("\n For continue presskey Enter or input 'Ex' for Exit: ");
                eXit = Console.ReadLine();
            } while (eXit != "ex");            
        }
    }
    public class Rational
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Rational(int n, int d)
        {
            this.Numerator = n;
            this.Denominator = d;
        }

        public static void InputValue(out int Num, out int Den)
        {
            bool repeat;
            do
            {
                try
                {
                    Console.Write(" Input numerator:   ");
                    Num = int.Parse(Console.ReadLine());
                    Console.Write(" Input denominator: ");
                    Den = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (Den == 0)
                    {
                        repeat = true;
                        throw new ArgumentNullException();
                    }
                    else { repeat = false; }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Vallue denominator can't be 0!\n");
                    Num = 0;
                    Den = 0;
                    repeat = true;
                }
                catch
                {
                    Console.Write("You input incorrect numeric, repeat!\n");
                    Num = 0;
                    Den = 0;
                    repeat = true;
                }
            } while (repeat);

        }
        public void PrintShow(string n, int x, int y)
        {
            if (x % y == 0)
            {
                Console.WriteLine("{0} is integer number: {1}", n, x/y);
            }
            else if (x != y)
            {
                Console.WriteLine("{0} is true rational: {1}r{2}", n, x, y);
            }
        }

        public static void SimpliForm(ref int a, ref int b)
        {
            int x = GCD(a,b);
            a = a / x;
            b = b / x;
        }

        static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        static int CommonDen(int a, int b)
        {
            if (a>=b)
            {
                int temp = a;
                while (a % b > 0)
                {
                    a += temp;
                }   return a;
            }
            else
            {
                int temp = b;
                while (b % a > 0)
                {
                    b += temp;
                }   return b;
            }                    
        }
        public static Rational operator +(Rational a, Rational b)
        {
            int s = CommonDen(a.Denominator, b.Denominator);
            Rational Rational_3 = new Rational((s / a.Denominator) * (a.Numerator) + (s / b.Denominator) * b.Numerator, s);
            return Rational_3;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            int s = CommonDen(a.Denominator, b.Denominator);
            return new Rational(s / a.Denominator * a.Numerator - s / b.Denominator * b.Numerator, s);
        }
        public static Rational operator *(Rational a, Rational b)
       => new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Rational operator /(Rational a, Rational b)
       => new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);

        public override string ToString()
        {
            return Numerator+"r"+Denominator;
        }
            
    }


}

