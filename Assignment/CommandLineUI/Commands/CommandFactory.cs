using Assignment.CommandLineUI.Menu;
using Assignment.UI_commands;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    public class CommandFactory
    {

        IDataGatewasyFacade dataGatewayFacade;

        public CommandFactory(IDataGatewasyFacade dataGatewasyFacade)

        {
            dataGatewayFacade = dataGatewasyFacade;
        }

        public RequestUseCase CreateCommand(int commandCode)
        {
            switch (commandCode)
            {
                case RequestUseCase.ADD_ITEM_TO_STOCK:
                    return new AddItemToStockCommand(dataGatewayFacade);

                case RequestUseCase.ADD_QUANTITY_TO_ITEM:
                    return new AddQuantityToItem(dataGatewayFacade);

                case RequestUseCase.TAKE_QUANTITY_FROM_ITEM:
                    return new TakeQuantityFromItemCommand(dataGatewayFacade);

                case RequestUseCase.VIEW_INVENTORY_REPORT:
                    return new ViewInventoryReportCommand(dataGatewayFacade);

                case RequestUseCase.VIEW_FINANCIAL_REPORT:
                    return new ViewFinancialReportCommand(dataGatewayFacade);

                case RequestUseCase.VIEW_TRANSACTION_LOG:
                    return new ViewTransactionLogCommand(dataGatewayFacade);
                case RequestUseCase.INITIALISE_DATABASE:
                    return new InitialiseDatabaseCommand(dataGatewayFacade);
                case RequestUseCase.DISPLAY_MENU:
                    return (RequestUseCase)MenuFactory.INSTANCE;

                case RequestUseCase.VIEW_PERSONAL_USAGE_REPORT:
                    return new ViewPersonalUsageReportCommand_cs(dataGatewayFacade);
                default:
                    return new NullCommand();
            }
        }

    }
}