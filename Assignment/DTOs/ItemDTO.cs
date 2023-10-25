using Assignment.DataGateway;
using Assignment.DataGateway.MySql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{

    [Serializable]
    public class ItemDTO : DTO
    {
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; private set; }
        public DateTime DateCreated { get; }



        public ItemDTO(int id, string name, int quantity, DateTime dateCreated)
        { 

            this.ID = id;
            this.Name = name;
            this.Quantity = quantity;
            this.DateCreated = dateCreated;
        }


        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being added is below 0");
            }

            Quantity += quantity;

            ItemDTO itemDTO = new ItemDTO(ID, Name, Quantity, DateCreated);
            UpdateAddQuantity updateAddQuantity = new UpdateAddQuantity();
            updateAddQuantity.Update(itemDTO);

        }

        public void RemoveQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being removed is below 0");
            }

            if (quantity > Quantity)
            {
                throw new Exception("ERROR: Quantity too many");
            }

            Quantity -= quantity;

            ItemDTO itemDTO = new ItemDTO(ID, Name, Quantity, DateCreated);
            UpdateRemoveQuantity updateremoveQuantity = new UpdateRemoveQuantity();
            updateremoveQuantity.Update(itemDTO);


        }


    }
}
