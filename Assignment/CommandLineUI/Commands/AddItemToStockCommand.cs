using Assignment.DTOs;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class AddItemToStockCommand : RequestUseCase
    {

        private readonly IDataGatewasyFacade gatewasyFacade;
        public AddItemToStockCommand(IDataGatewasyFacade dataGatewasyFacade)
        {

            gatewasyFacade = dataGatewasyFacade;
        }

        public void Execute()
        {
            try
            {
                string employeeName = ConsoleReader.ReadString("\nEmployee Name");
                if (gatewasyFacade.FindEmployee(employeeName) == null)
                {
                    throw new Exception("ERROR: Employee not found");
                }

                int itemId = ConsoleReader.ReadInteger("Item ID");
                string itemName = ConsoleReader.ReadString("Item Name");
                int itemQuantity = ConsoleReader.ReadInteger("Item Quantity");
                double itemPrice = ConsoleReader.ReadDouble("Item Price");

                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }
                DateTime Addeddate = DateTime.Now;
                Item item = new Item(itemId, itemName, itemQuantity, DateTime.Now);
                gatewasyFacade.AddItem(item);
                gatewasyFacade.AddTransactionLog(
                    new TransactionLogEntry("Item Added", itemId, itemName, itemPrice, itemQuantity, employeeName, DateTime.Now));

                Console.WriteLine("Item Added");

                ViewInventoryReportCommand viewInventoryReportCommand = new ViewInventoryReportCommand(gatewasyFacade);
                viewInventoryReportCommand.Execute();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



    }
}
