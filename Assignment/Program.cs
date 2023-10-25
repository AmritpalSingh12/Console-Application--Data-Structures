using Assignment.CommandLineUI;
using Assignment.CommandLineUI.Commands;
using Assignment.DataGateway.MySql;
using Assignment.Library;
using Assignment.UI_commands;
using System;
using System.Collections.Generic;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandFactory factory = new CommandFactory(new DataGatewayFacade());

            factory
                .CreateCommand(RequestUseCase.INITIALISE_DATABASE)
                .Execute();

            RequestUseCase displayMenu
                = factory.CreateCommand(RequestUseCase.DISPLAY_MENU);

            displayMenu.Execute();
            int choice = GetUserChoice();

            while (choice != RequestUseCase.EXIT)
            {
                factory
                    .CreateCommand(choice)
                    .Execute();

                displayMenu.Execute();
                choice = GetUserChoice();
            }
        }

        private static int GetUserChoice()
        {
            int option = ConsoleReader.ReadInteger("\nOption");
            while (option < 1 || option > 10)
            {
                Console.WriteLine("\nChoice not recognised, Please enter again");
                option = ConsoleReader.ReadInteger("\nOption");
            }
            return option;
        }
    }
}
