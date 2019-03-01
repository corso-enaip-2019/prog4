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
            decimal side_a = AskCheckNumber("Insert first side");
            decimal side_b = AskCheckNumber("Insert second side");
            decimal side_c = AskCheckNumber("Insert third side");
            
            bool is_sum_of_sides_correct = side_a < (side_b + side_c) && side_b < (side_a + side_c) && side_c < (side_a + side_b);

            bool is_abs_difference_correct = side_a > Math.Abs(side_b - side_c) && side_b > Math.Abs(side_c - side_a) && side_c > Math.Abs(side_a - side_b);

            if (is_sum_of_sides_correct && is_abs_difference_correct)

                Console.WriteLine("Ok it can be a triangle");

            else

                Console.WriteLine("Sorry the numbers you entered cannot be a triangle");

            Console.ReadLine();
        }

        /// <summary>
        /// Ask the user for an input and try to convert it to a decimal
        /// </summary>
        /// <param name="message">Message shown to the user</param>
        /// <returns>The converted decimal inserted by the user</returns>
        static decimal AskCheckNumber(string message)
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            bool isConversionOk = decimal.TryParse(input, out decimal convertedValue);

            if (!isConversionOk)

                Console.WriteLine("Sorry, the value entered is not valid!");

            if (convertedValue <= 0)

                Console.WriteLine("Sorry the input must be positive!");

            return convertedValue;
        }
    }
}
