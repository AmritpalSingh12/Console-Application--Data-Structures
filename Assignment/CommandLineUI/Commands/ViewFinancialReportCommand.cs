using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    internal class ViewFinancialReportCommand : RequestUseCase
    {

        private readonly IDataGatewasyFacade gatewasyFacade;


        public ViewFinancialReportCommand(IDataGatewasyFacade dataGatewasyFacade)
        {

            gatewasyFacade = dataGatewasyFacade;

        }
        public void Execute()
        {
            double total = 0;

            Console.WriteLine("\nFinancial Report:");

            foreach (TransactionLogEntry entry in gatewasyFacade.GetTransactionLog())
            {
                if (entry.TypeOfTransaction.Equals("Item Added")
                    || entry.TypeOfTransaction.Equals("Quantity Added"))
                {
                    double cost = entry.ItemPrice * entry.Quantity;
                    Console.WriteLine("{0}: Total price of item: {1:C}", entry.ItemName, cost);
                    total += cost;
                }
            }

            Console.WriteLine("{0}: {1:C}", "Total price of all items", total);
        }
    }
}

