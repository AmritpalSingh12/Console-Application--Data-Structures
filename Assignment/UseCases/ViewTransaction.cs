using Assignment.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public class ViewTransaction : AbstractUseCase
    {
        public ViewTransaction(IDataGatewayFacade gatewayFacade) : base(gatewayFacade)
        { }

        public override DTO Execute()
        {
            return new 
        }
    }
}
