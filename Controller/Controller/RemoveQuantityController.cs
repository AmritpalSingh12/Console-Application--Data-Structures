using Assignment.DataGateway.MySql;
using Assignment.DTOs;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCases;

namespace Controller.Controller
{
    public class RemoveQuantityController : AbstractController
    {
        private  string employeeName;
        private  int itemId;
        private  int quantityToRemove;
        private double itemPrice;

        public RemoveQuantityController(string employeeName, int itemId, int quantityToRemove, double itemPrice,
            AbstractPresenter presenter): base (new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.quantityToRemove = quantityToRemove;
            this.itemPrice = itemPrice;
        }
        public override DTO ExecuteUseCase()
        {
            return new TakeQuantityItem(employeeName,itemId,quantityToRemove,itemPrice,gatewayFacade).Execute();
        }

    }
}
