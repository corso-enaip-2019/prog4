using System;
using System.Collections.Generic;

namespace ClasseStudenti
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                SelectionMenu();

                Console.WriteLine("Do you want to perform other actions? (y/n)");
            } while (Console.ReadLine() == "y");

            Console.WriteLine("See you next time!");

           Console.ReadLine();
        }

        static Dictionary<int, List<string>> NameClassDictionary = new Dictionary<int, List<string>>();

        static void StoreStudentNameAndClass()
        {
            Console.WriteLine("Please insert student's class and press enter:");

            int.TryParse(Console.ReadLine(), out int _class);

            if (_class < 1 || _class > 5)
            {
                Console.WriteLine("Sorry only 1, 2, 3, 4, 5 class exist");

                return;
            }

            Console.WriteLine("Please insert student's name and press enter:");

            string name = Console.ReadLine();

            if (!NameClassDictionary.ContainsKey(_class))
            {
                NameClassDictionary[_class] = new List<string>();
            }

            NameClassDictionary[_class].Add(name);
        }

        static void DisplayStudentsInClass()
        {
            if (NameClassDictionary.Count == 0)
            {
                Console.WriteLine("There are no entries");

                return;
            }

            foreach (KeyValuePair<int, List<string>> item in NameClassDictionary)
            {
                Console.WriteLine($"Classe: {item.Key}, Nome: {string.Join(", " , item.Value)}");
            }
        }

        static void DisplayStudentsInClass(int _class)
        {
            if (NameClassDictionary.Count == 0)
            {
                Console.WriteLine("There are no entries");

                return;
            }

            try
            {
                Console.WriteLine(string.Concat("Students in Class ", _class, " ",
                string.Join(", ", NameClassDictionary[_class])));
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Console.WriteLine("Sorry the class is empty");

                return;
            }
        }

        static void SelectionMenu()
        {
            Console.WriteLine(@"Please select what you want to do:
                1 - Insert students
                2 - Display students
                3 - Find student's class");

            int.TryParse(Console.ReadLine(), out int selection);

            switch (selection)
            {
                case 1:

                    Console.WriteLine("How many students you want to enter?");

                    int.TryParse(Console.ReadLine(), out int nStudents);

                    for (int i = 0; i < nStudents; ++i)
                    {
                        StoreStudentNameAndClass();
                    }

                    DisplayStudentsInClass();

                    break;

                case 2:

                    Console.WriteLine("Insert a class, type \'9\' for all.");

                    int.TryParse(Console.ReadLine(), out int SelectedClass);

                    if (SelectedClass == 9)
                    {
                        DisplayStudentsInClass();
                    }
                    else
                    {
                        DisplayStudentsInClass(SelectedClass);
                    }

                    break;

                case 3:

                    Console.WriteLine("Insert student's name:");

                    string name = Console.ReadLine();

                    GiveStudentClass(name);

                    break;

                default:

                    DisplayStudentsInClass();

                    break;
            }

            return;
        }

        static void GiveStudentClass(string name)
        {
            if(NameClassDictionary.Count == 0)
            {
                Console.WriteLine("Sorry there are no entries");

                return;
            }

            for(int i = 0; i < NameClassDictionary.Count; ++i)
            {
                if(NameClassDictionary.TryGetValue(i, out List<string> names) && names.Contains(name))
                {
                    Console.WriteLine(string.Concat("Student", name, "found in class", i));
                }
                else
                {
                    Console.WriteLine("Sorry student not found!");
                }
            }

            return;
        }
    }
}
