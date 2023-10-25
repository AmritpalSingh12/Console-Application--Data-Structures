using Assignment.DataGateway.MySql;
using Assignment.DTOs;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Controller
{
    public class InitailiseDatabaseController : AbstractController
    {
        public InitailiseDatabaseController(
            AbstractPresenter presenter) : base(new DataGatewayFacade(), presenter)
        {

        }

        public override DTO ExecuteUseCase()
        {
            return new Ini
        }

    }
}
