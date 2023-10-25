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
    public class ViewTransactionController : AbstractController
    {
        public ViewTransactionController(
            AbstractPresenter presenter): base(new DataGatewayFacade(), presenter)
                {

        }

        public override DTO ExecuteUseCase()
        {
            return new ViewTransaction(gatewayFacade).Execute();
        }


    }
}
