using Assignment.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public abstract class AbstractController
    {
        protected readonly IDataGatewayFacade gatewayFacade;
        protected AbstractPresenter presenter;

        public AbstractController(IDataGatewayFacade database, AbstractPresenter presenter)
        {
            this.gatewayFacade = database;
            this.presenter = presenter;
        }

        public ViewData Execute()
        {
            presenter.DataToPresent = ExecuteUseCase();
            return presenter.ViewData;
        }

        public abstract DTO ExecuteUseCase();


    }
}
