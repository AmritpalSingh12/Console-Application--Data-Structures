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
    public class ViewFinancialReportController : AbstractController
    {
        public ViewFinancialReportController(
            AbstractPresenter presenter) : base (new DataGatewayFacade(), presenter)
        {

        }
        public override DTO ExecuteUseCase()
        {
            return new ViewFinancialReport(gatewayFacade).Execute();
        }

    }
}
