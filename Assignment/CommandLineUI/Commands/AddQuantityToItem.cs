using Assignment.DTOs;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class AddQuantityToItem : RequestUseCase
    {
        private readonly IDataGatewasyFacade gatewasyFacade;

        public AddQuantityToItem(IDataGatewasyFacade dataGatewasyFacade)
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
                ItemDTO item = gatewasyFacade.FindItem(itemId);
                if (item == null)
                {
                    throw new Exception("ERROR: Item not found");
                }

                int quantityToAdd = ConsoleReader.ReadInteger("How many items would you like to add?");
                double itemPrice = ConsoleReader.ReadDouble("Item Price");

                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }

                item.AddQuantity(quantityToAdd);
                Console.WriteLine(
                    "{0} items have been added to Item ID: {1} on {2}",
                    quantityToAdd,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                gatewasyFacade.AddTransactionLog(
                    new TransactionLogEntry("Quantity Added", item.ID, item.Name, itemPrice, quantityToAdd, employeeName, DateTime.Now));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
