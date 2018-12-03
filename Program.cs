using System;

namespace Module4
{
    class Program
    {
        static string errormessages = "yes";


        static void Main(string[] args)
        {
            string[] names;
            var peopleArrayIsValid = false;
            bool errorMessageIsValid = false;
            string separator = ",";

            while (peopleArrayIsValid == false)
            {
                separator = AskForSeparator();
                var newpeopleArrayIsValid = ControlSeparator(separator);
                peopleArrayIsValid = newpeopleArrayIsValid.Item1;
                separator = newpeopleArrayIsValid.Item2;
            }

            while (errorMessageIsValid == false)
            {
                errormessages = AskForErrormessages();
                errorMessageIsValid = ControlErrorMessage(errormessages);
            }

            do
            {
                string input = GetInput(separator);
                names = CreateStringArray(input, separator);
                CleanupArray(names);
                peopleArrayIsValid = PeopleArrayIsValid(names);
            } while (peopleArrayIsValid == false);
            PrintArray(names);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            //TODO: Skapa olika gits i din repository så du inte behöver ha gammal kod som kommentarer i ditt program =) 
            //-----------------------------------------------------------------------------------------------------------

            //string input;

            //Console.Write("Enter names separated by comma (e.g. Maria,Peter,Lisa): ");
            //input = Console.ReadLine();
            //input = input.ToUpper();
            //string[] names = input.Split(',');
            //Console.WriteLine();


            //Console.ForegroundColor = ConsoleColor.Green;
            //foreach (string name in names)
            //{
            // Console.WriteLine("***SUPER-" + name + "***");
            //}

            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.White;



        }

        private static bool ControlErrorMessage(string errormessages)
        {
            if (errormessages.ToLower() == "yes" || errormessages.ToLower() == "no")
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only 'yes' or 'no' is alowed.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        private static (bool, string) ControlSeparator(string separator)
        {

            if (separator.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Separator is only allowed to be 1 character.");
                Console.ForegroundColor = ConsoleColor.White;
                return (false, separator);

            }
            else if (string.IsNullOrEmpty(separator) || string.IsNullOrWhiteSpace(separator))
            {
                separator = ",";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Separator is set to default.");
                Console.ForegroundColor = ConsoleColor.White;
                return (true, separator);

            }
            else
            {
                return (true, separator);

            }
        }

        private static string AskForSeparator()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Which separator do you want to use (default is comma)? ");
            string separatorinput = Console.ReadLine();
            return separatorinput;
        }

        private static string AskForErrormessages()
        {
            Console.Write("Do you want to see error messages (deafult is yes) ? ");
            string answer = Console.ReadLine();
            return answer;
        }

        private static string GetInput(string separator)
        {
            Console.Write($"Enter names separated by '{separator}' (e.g. Maria{separator}Peter{separator}Lisa): ");
            string input = Console.ReadLine();
            input = input.ToUpper();
            return input;
        }

        private static string[] CreateStringArray(string input, string separator)
        {
            char[] convertseparator = separator.ToCharArray();
            string[] names = input.Split(convertseparator[0]);
            return names;
        }

        private static void CleanupArray(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Trim();

            }
        }


        private static void PrintArray(string[] names)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (string name in names)
            {
                Console.WriteLine("***SUPER-" + name + "***");
            }
        }

        private static bool PeopleArrayIsValid(string[] names)
        {
            bool peopleArrayIsValid = true;
            if (names.Length == 0)
            {
                if (errormessages.ToLower() == "yes")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The list don't contain any names.");
                }
                peopleArrayIsValid = false;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (string name in names)
                {
                    if (name.Length < 2 || name.Length > 9)
                    {
                        if (errormessages.ToLower() == "yes")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("A person can only have 2 to 9 letters.");
                        }
                        peopleArrayIsValid = false;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        foreach (char letter in name)
                        {
                            if (!char.IsLetter(letter))
                            {
                                if (errormessages.ToLower() == "yes")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Name must consist of letters only.");
                                }
                                peopleArrayIsValid = false;
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        }
                    }
                }
            }
            return peopleArrayIsValid;

        }
    }
}