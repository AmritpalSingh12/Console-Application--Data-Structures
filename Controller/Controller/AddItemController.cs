using Assignment.DataGateway.MySql;
using Assignment.DTOs;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller
{
    public class AddItemController : AbstractController
    {
        private string employeeName;
        private int itemId;
        private string itemName;
        private int itemQuantity;
        private double itemPrice;
        private DateTime addeddate;

        public AddItemController(string employeeName, int itemId, string itemName, int itemQuantity, double itemPrice,
            AbstractPresenter presenter) : base(new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
           
            this.itemPrice = itemPrice;
            
        }

        public override DTO ExecuteUseCase()
        {
            return new AddItem(employeeName,itemPrice, itemId, itemName, itemQuantity, addeddate, gatewayFacade).Execute();
        }

    }
}
