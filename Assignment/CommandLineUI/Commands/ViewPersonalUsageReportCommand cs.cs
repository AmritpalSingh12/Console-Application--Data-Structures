using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class ViewPersonalUsageReportCommand_cs : RequestUseCase
    {

        private readonly IDataGatewasyFacade gatewasyFacade;

        public ViewPersonalUsageReportCommand_cs(IDataGatewasyFacade dataGatewasyFacade)
        {
            gatewasyFacade = dataGatewasyFacade;
        }

        public void Execute()
        {
            string employeeName = ConsoleReader.ReadString("Employee name");

            Console.WriteLine("\nPersonal Usage Report for {0}", employeeName);
            Console.WriteLine(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed");

            foreach (TransactionLogEntry entry in gatewasyFacade.GetTransactionLog())
            {
                if (entry.TypeOfTransaction.Equals("Quantity Removed") && entry.EmployeeName == employeeName)
                {
                    Console.WriteLine(
                        "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                        entry.DateAdded,
                        entry.ItemID,
                        entry.ItemName,
                        entry.Quantity);
                }
            }
        }
    }
}
