using Assignment.DTOs;
using Assignment.UseCases;
using Assignment.visi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Presenter
{
    class ViewInventoryReport : AbstractPresenter
    {

        public override ViewData ViewData
        {
            get
            {
                List<ItemDTO> items = ((ItemDTO_List)DataToPresent).List;
                ItemPrinter printer = new ItemPrinter();

                GetVisitableItems(items)
                    .ForEach(
                    items =>
                    {
                        items.AcceptVisitFrom(printer);
                    });
                List<string> lines = new List<string>();
                lines.Add("\nAll items");
                lines.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    "ID",
                    "Name",
                    "Quantity"));

                return new CommandLineViewData(lines);

            }
        }

        private List<VisitableItem> GetVisitableItems (List<ItemDTO> item)
        {
            List<VisitableItem> list = new List<VisitableItem>();

            item.ForEach(item => list.Add(new VisitableItem(item)));

            return list;
        }


    }
}
