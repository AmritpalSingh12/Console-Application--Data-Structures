using Assignment.DTOs;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class TakeQuantityFromItemCommand : RequestUseCase

    {
        private readonly IDataGatewasyFacade gatewasyFacade;

        public TakeQuantityFromItemCommand(IDataGatewasyFacade gatewasyFacade)
        {
            this.gatewasyFacade = gatewasyFacade;
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

                int quantityToRemove = ConsoleReader.ReadInteger("How many items would you like to remove?");

                item.RemoveQuantity(quantityToRemove);
                Console.WriteLine(
                    "{0} has removed {1} of Item ID: {2} on {3}",
                    employeeName,
                    quantityToRemove,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                gatewasyFacade.AddTransactionLog(
                    new TransactionLogEntry("Quantity Removed", item.ID, item.Name, -1, quantityToRemove, employeeName, DateTime.Now));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
