using System;
using System.Collections.Generic;
using System.Text;
using Assignment.DTOs;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;

namespace Assignment.CommandLineUI.Commands
{

    public class InitialiseDatabaseCommand : RequestUseCase
    {
        private readonly IDataGatewasyFacade gatewasyFacade;
        public InitialiseDatabaseCommand(IDataGatewasyFacade dataGatewasyFacade)
        {
            gatewasyFacade = dataGatewasyFacade;


        }

        public void Execute()
        {
            gatewasyFacade.InitialiseMySqlDatabase();

            gatewasyFacade.AddEmployee(new Employee("Graham"));
            gatewasyFacade.AddEmployee(new Employee("Phil"));
            gatewasyFacade.AddEmployee(new Employee("Jan"));
            Item item1 = new Item(1, "Pencil", 10, DateTime.Now);
            int rows = gatewasyFacade.AddItem(item1);
            gatewasyFacade.AddTransactionLog(
                new TransactionLogEntry("Item Added", item1.ID, item1.Name, 0.25f, item1.Quantity, "Graham", DateTime.Now));
            Item item2 = new Item(2, "Eraser", 20, DateTime.Now);
            int rows2 = gatewasyFacade.AddItem(item2);
            gatewasyFacade.AddTransactionLog(
                new TransactionLogEntry("Item Added", item2.ID, item2.Name, 0.15f, item2.Quantity, "Phil", DateTime.Now));

            item2.RemoveQuantity(4);
            gatewasyFacade.AddTransactionLog(
                new TransactionLogEntry("Quantity Removed", item2.ID, item2.Name, -1, 4, "Graham", DateTime.Now));

            item2.AddQuantity(2);
            gatewasyFacade.AddTransactionLog(
                new TransactionLogEntry("Quantity Added", item2.ID, item2.Name, 0.33, 2, "Phil", DateTime.Now));
        }


    }



}

