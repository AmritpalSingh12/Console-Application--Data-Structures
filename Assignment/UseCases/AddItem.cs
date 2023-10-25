using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public class AddItem : AbstractUseCase
    {
       private readonly string employeeName;
        
        public AddItem(string employeeName, IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.employeeName = employeeName;
        }
        
        public override DTO Execute()
        {
            try
            {
                EmployeeConverter employeeConverter = new EmployeeConverter();
                Employee EmpName = employeeConverter.ConvertFromDTO(gatewayFacade.FindEmployee(employeeName));
                
                if (EmpName == null)
                {
                    return new MassageDTO("ERROR: Employee not found");
                }

                Item_Converter item_Converter = new Item_Converter();
                

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
