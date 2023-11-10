using System.Globalization;
namespace LibraryManager
{
    public static class ConsoleHandler
    {
        public static int ReadIntValue(string message = "")
        {
            var intInp = -1;
            while (intInp == -1)
            {
                Console.Write(message.Any() ? $"> {message}" : "> ");
                var inp = Console.ReadLine() ?? "";
                if (!inp.Any())
                {
                    inp = "0";
                }
                try
                {
                    intInp = int.Parse(inp);
                }
                catch (Exception ex)
                {
                    intInp = -1;
                    Console.WriteLine("Error while trying to parse input. Error: " + ex.Message);
                }
            }
            return intInp;
        }
        
        public static int ReadNonNullIntValue(string message = "")
        {
            var intInp = -1;
            while (intInp == -1)
            {
                Console.Write(message.Any() ? $"> {message}" : "> ");
                var inp = Console.ReadLine() ?? "";
                if (!inp.Any())
                {
                    Console.WriteLine("Value cannot be empty. Try another value.");
                    continue;
                }
                try
                {
                    intInp = int.Parse(inp);
                }
                catch (Exception ex)
                {
                    intInp = -1;
                    Console.WriteLine("Error while trying to parse input. Error: " + ex.Message);
                }
            }
            return intInp;
        }


        public static string ReadStringValue(string message = "")
        {
            Console.Write(message.Any() ? $"> {message}" : "> ");
            var inp = Console.ReadLine() ?? "";
            return inp;
        }
        
        public static string ReadNonNullStringValue(string message = "")
        {
            string inp = "";
            do
            {
                Console.Write(message.Any() ? $"> {message}" : "> ");
                inp = Console.ReadLine() ?? "";
                if (!inp.Any())
                {
                    Console.WriteLine("Value cannot be empty. Try another value.");
                }
            } while (!inp.Any());
            return inp;
        }


        public static DateTime? ReadDateTime()
        {
            var again = true;
            while (again)
                try
                {
                    var inputStr = ReadStringValue();
                    var inputDatetime = DateTime.ParseExact(inputStr, "dd-MM-yyyy HH:mm", new CultureInfo("pt-BR"));
                    again = false;
                    return inputDatetime;
                }
                catch (Exception ex)
                {
                    again = true;
                    Console.WriteLine("Error while trying to parse the date (dd-MM-yyyy HH:mm). Error: " + ex.Message);
                }
            return null;
        }

        public static int AskInput()
        {
            int[] validInputs = { 1, 2, 3, 4, 5, 6, 99 };
            var result = -1;
            try
            {
                while (result == -1)
                {
                    result = ReadIntValue();
                    if (!validInputs.Contains<int>(result))
                    {
                        result = -1;
                        Console.WriteLine("Try a valid option. ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error. Error: " + ex.Message);
                return -1;
            }
            return result;
        }

        public static void ShowLibraryManagerMenu()
        {
            Console.WriteLine("~ Library Manager ~");
            Console.WriteLine("1 - Save a Book");
            Console.WriteLine("2 - Retrieve all books");
            Console.WriteLine("3 - Remove a book");
            Console.WriteLine("4 - Update a book");
            Console.WriteLine("5 - Retrieve by Author");
            Console.WriteLine("99 - Exit");
        }
    }
}