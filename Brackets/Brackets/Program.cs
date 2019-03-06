using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a string");

            string message = Console.ReadLine();

            bool ok = CheckBrackets(message);

            string strOk = ok ? "OK" : "KO";
            Console.WriteLine($"Text is { ok }");

            Console.ReadLine();
        }

        static List<char> OpenBrackets = new List<char>() { '(', '[', '{' };
        static List<char> ClosedBrackets = new List<char>() { ')', ']', '}' };

        /// <summary>
        /// Verify if passed text contains the correct parentheses pairs.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets(string text)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char i in text)
            {
                if (OpenBrackets.Contains(i))

                    stack.Push(i);

                if (ClosedBrackets.Contains(i))
                {

                    if (stack.Peek() == GetClosedBracket(i) && stack.Count != 0)
         
                        stack.Pop();
         
                    else

                        return false;
                }
            }

            return stack.Count == 0;
        }

        /// <summary>
        /// Function returns the opposite bracket
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        static char GetClosedBracket(char ch)
        {
            int ClosedBracketIndex = ClosedBrackets.IndexOf(ch);

            return ClosedBrackets[ClosedBracketIndex];
        }

        static int[] GetFailedBracketIndex()
        {
            int[] index = new int[2];

            return index;
        }
    }
}
