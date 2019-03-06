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
            bool ok = CheckBrackets(@"
                namespace Brackets
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            bool ok = CheckBrackets("")
                            Console.ReadLine();
                        }
                        static bool CheckBrackets(string text)
                        {
                        }
                    }
                }", out int[] MissingBracketPosition);

            int row = MissingBracketPosition[0];
            int column = MissingBracketPosition[1];

            if (!ok)
            {
                Console.WriteLine(string.Concat("Sorry, found unmatched parenthesis at row ", row, " and column ", column));
            }
            else
            {
                Console.WriteLine("Text is ok!");
            }

            Console.ReadLine();
        }

        static List<char> OpenBrackets = new List<char>() { '(', '[', '{' };
        static List<char> ClosedBrackets = new List<char>() { ')', ']', '}' };

        /// <summary>
        /// Verify if passed text contains the correct parentheses pairs.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets(string text, out int[] MissingBracketPosition)
        {
            Stack<char> stack = new Stack<char>();

            MissingBracketPosition = new int[] { 0, 0 };

            int CurrentRow = 0;
            int CurrentCol = 0;

            foreach (char i in text)
            {
                if (i == '\n')
                {
                    CurrentRow++;
                    CurrentCol = 0;
                } else
                {
                    CurrentCol++;
                }

                if (OpenBrackets.Contains(i))
                { 
                    stack.Push(i);
                }

                if (ClosedBrackets.Contains(i))
                {

                    if (stack.Peek() == GetClosedBracket(i) && stack.Count != 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        MissingBracketPosition[0] = CurrentRow;
                        MissingBracketPosition[1] = CurrentCol;

                        return false;
                    }
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
    }
}
