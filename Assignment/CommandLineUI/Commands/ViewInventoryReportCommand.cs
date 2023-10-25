using Assignment.DTOs;
using Assignment.Library;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class ViewInventoryReportCommand : RequestUseCase
    {

        private readonly IDataGatewasyFacade gatewasyFacade;

        public ViewInventoryReportCommand(IDataGatewasyFacade dataGatewasyFacade)
        {
            gatewasyFacade = dataGatewasyFacade;

        }


        public void Execute()
        {
            Dictionary<int, ItemDTO> items = gatewasyFacade.GetItems();
            Console.WriteLine("\nAll items");
            Console.WriteLine(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity");

            foreach (ItemDTO i in items.Values)
            {
                ViewInventoryReport(i);
            }
        }
        public void ViewInventoryReport(ItemDTO i)
        {
            Console.WriteLine(
                        "\t{0, -4} {1, -20} {2, -20}",
                        i.ID,
                        i.Name,
                        i.Quantity);
        }







    }
}

