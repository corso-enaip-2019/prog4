using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many sides?");

            decimal[] sides = new decimal[3];

            for (int i = 0; i < sides.Length; ++i)
            {
                sides[i] = AskCheckNumber(string.Concat("Insert side ", i + 1));
            }

            if (IsTriangle(sides[0], sides[1], sides[2]))

                Console.WriteLine("Ok it can be a triangle");

            else
            {
                decimal[] solution = FindPossibleTriangle(sides);

                Console.WriteLine(string.Concat("Sorry the numbers you entered cannot be a triangle, try ",
                    string.Join(",", solution)));
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Ask the user for an input and try to convert it to a decimal
        /// </summary>
        /// <param name="message">Message shown to the user</param>
        /// <returns>The converted decimal inserted by the user</returns>
        static decimal AskCheckNumber(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Concat("Message: ", message));

            Console.WriteLine(message);

            string input = Console.ReadLine();

            bool isConversionOk = decimal.TryParse(input, out decimal convertedValue);

            if (!isConversionOk)

                Console.WriteLine("Sorry, the value entered is not valid!");

            if (convertedValue <= 0)

                Console.WriteLine("Sorry the input must be positive!");

            System.Diagnostics.Debug.WriteLine($"{message}, {input}");

            return convertedValue;
        }

        /// <summary>
        /// Given three decimals checks if it can be a triangle
        /// </summary>
        /// <param name="a">First side of the triangle</param>
        /// <param name="b">Second side of the triangle</param>
        /// <param name="c">Third side of the triangle</param>
        /// <returns>true or false</returns>
        static bool IsTriangle(decimal a, decimal b, decimal c)
        {
            bool is_sum_of_sides_correct = a < (b + c) &&
                b < (a + c) &&
                c < (a + b);

            bool is_abs_difference_correct = a > Math.Abs(b - c) &&
                b > Math.Abs(c - a) &&
                c > Math.Abs(a - b);

            return is_sum_of_sides_correct && is_abs_difference_correct;
        }

        static decimal[] FindPossibleTriangle(decimal[] sides)
        {
            Array.Sort(sides);

            do
            {
                sides[2]--;

            } while (!IsTriangle(sides[0], sides[1], sides[2]));

            return sides;
        }
    }
}
