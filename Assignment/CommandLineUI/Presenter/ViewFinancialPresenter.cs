using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
{
     class ViewFinancialPresenter : AbstractPresenter

    {

        public override ViewData ViewData
        {
            get
            {
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

    }
}
