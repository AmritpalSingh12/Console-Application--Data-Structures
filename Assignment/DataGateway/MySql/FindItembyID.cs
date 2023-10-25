using Assignment.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class FindItembyID : DatabaseSelector<ItemDTO>
    { 
        private int id;

    
        public FindItembyID(int ID)
        {
            this.id = ID;
        }

        protected override string GetSQL()
        {
            return "select * from item where ID= @id";
        }

        protected override ItemDTO DoSelect(MySqlCommand command)
        {
            ItemDTO ItemId = null;

            try
            {
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    ItemId = new ItemDTO(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDateTime(3));

                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of item ID failed", e);
            }
            return ItemId;
        }

    }
}
