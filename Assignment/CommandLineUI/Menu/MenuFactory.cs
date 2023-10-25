﻿using Assignment.CommandLineUI.Menu;
using Assignment.menu;
using Assignment.UI_commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Menu
{
    class MenuFactory
    {
        public static MenuFactory INSTANCE { get; } = new MenuFactory();

        private Menus menu;
        private MenuFactory()
        {
            menu = CreateMenu();
        }


        private Menus CreateMenu()
        {
            Menus menu = new Menus("Stationary Management");

            menu.Add(CreateItemMenu());
            menu.Add(CreateViewMenu());
            menu.Add(CreateAppMenu());

            return menu;
        }

        private Menus CreateAppMenu()
        {
            Menus menu = new Menus("App menu");
            menu.Add(new MenuItem(RequestUseCase.EXIT, "Exit"));
            return menu;
        }

        private Menus CreateItemMenu()
        {
            Menus menu = new Menus("Stationary menu");
            menu.Add(new MenuItem(RequestUseCase.ADD_ITEM_TO_STOCK, "Add item to stock"));
            menu.Add(new MenuItem(RequestUseCase.ADD_QUANTITY_TO_ITEM, "Add quantity to item"));
            menu.Add(new MenuItem(RequestUseCase.TAKE_QUANTITY_FROM_ITEM, "Take quantity from item"));
            return menu;
        }

        private Menus CreateViewMenu()
        {
            Menus menu = new Menus("View Stationary menu");
            menu.Add(new MenuItem(RequestUseCase.VIEW_INVENTORY_REPORT, "View inventory report"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_FINANCIAL_REPORT, "View financial report"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_TRANSACTION_LOG, "View transaction log"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_PERSONAL_USAGE_REPORT, "View personal usage report"));
            return menu;
        }

        public void Execute()
        {
            menu.Print("");
        }
    }

}


   