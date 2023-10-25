using Assignment.DTOs;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
{
     class ViewPersonalReport : AbstractPresenter
    {
        public override ViewData ViewData
        {
            get
            {


                string employeeName = ConsoleReader.ReadString("Employee name");

                List<TransactionLogEntryDTO> transactionlogentries = ((TransactionLogEntryList)DataToPresent).List;
                List<string> lines = new List<string>();

                lines.Add("\nPersonal Usage Report for {0}", employeeName);
                lines.Add(string.Format(
                    "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                    "Date Taken",
                    "ID",
                    "Name",
                    "Quantity Removed"));





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
}
