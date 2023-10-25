using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class ViewTransactionLogCommand : RequestUseCase

    {

        private readonly IDataGatewasyFacade gatewasyFacade;


        public ViewTransactionLogCommand(IDataGatewasyFacade dataGatewasyFacade)
        {
            gatewasyFacade = dataGatewasyFacade;
        }

        public void Execute()
        {
            List<TransactionLogEntry> transactionlogentries = gatewasyFacade.GetTransactionLog();

            Console.WriteLine("\nTransaction Log:");
            Console.WriteLine(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price");

            foreach (TransactionLogEntry entry in transactionlogentries)
            {
                Console.WriteLine(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    entry.DateAdded.ToString("dd/MM/yyyy"),
                    entry.TypeOfTransaction,
                    entry.ItemID,
                    entry.ItemName,
                    entry.Quantity,
                    entry.EmployeeName,
                    entry.TypeOfTransaction.Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}", entry.ItemPrice));
            }
        }
    }
}
