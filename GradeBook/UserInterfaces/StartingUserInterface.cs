﻿using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            //if (parts.Length != 2)
            //{
            //    Console.WriteLine("Command not valid, Create requires a name.");
            //    return;
            //}
            //if (parts.Length != 3)
            //{
            //    Console.WriteLine("Command not valid, Create requires a name and type of gradebook.");
            //    return;
            //} najnowsze zmiany:
            if (parts.Length != 4)
            {
                Console.WriteLine("Command not valid, Create requires a name, type of gradebook, if it's weighted (true / false).");
                return;
            }
            //◾If the value of  parts[2] is "standard" return a newly instantiated  StandardGradeBook  using the name  variable.
            //◾If the value of  parts[2] is "ranked" return a newly instantiated  RankedGradeBook  using the name  variable.
            //◾If the value of  parts[2]  doesn't match the above write the value of  parts[2]  followed by " is not a supported type of gradebook, please try again" to the console, then escape the method.

            var name = parts[1];
            string typNasz = parts[2];
            //zmiana ostatnia 23błąd 
            bool IsWeighted;
            if (parts[3] == "true")
            { IsWeighted = true; }
            else IsWeighted = false;
                //= Convert.ToBoolean(parts[3]);
                switch (typNasz)
            {
                case "standard":
                    BaseGradeBook gradeBook = new StandardGradeBook(name, IsWeighted);
                    Console.WriteLine("Created gradebook {0}.", name);
                    GradeBookUserInterface.CommandLoop(gradeBook);
                    break;
                case "ranked":
                    BaseGradeBook gradeBook2 = new RankedGradeBook(name, IsWeighted); 
                    Console.WriteLine("Created gradebook {0}.", name);
                    GradeBookUserInterface.CommandLoop(gradeBook2);
                    break;
                default:
                    Console.WriteLine("{0}" + " is not a supported type of gradebook, please try again", typNasz);
                    //break;
                    return;
            }
                    //BaseGradeBook gradeBook = new BaseGradeBook(name);
                   
        }

        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
                //"Create 'Name' 'Type' - Creates a new gradebook where 'Name' is the name of the gradebook and 'Type' is what type of grading it should use.");
                //"Create 'Name' - Creates a new gradebook where 'Name' is the name of the gradebook.");
            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }
    }
}
