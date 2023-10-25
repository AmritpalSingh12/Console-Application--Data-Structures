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
    public class PersonalController : AbstractController
    {
        private string employeeName;

        public PersonalController(string employeeName,
            AbstractPresenter presenter) :base(new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
        }

        public override DTO ExecuteUseCase()
        {
            return new PersonalReport( employeeName, gatewayFacade).Execute();
        }
    }
}
