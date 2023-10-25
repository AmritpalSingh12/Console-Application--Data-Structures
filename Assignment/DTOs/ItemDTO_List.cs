using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class ItemDTO_List
    {
        public List<ItemDTO> List { get; }

        public ItemDTO_List(List<ItemDTO> list)
        {
            this.List = list;
        }


    }
}
