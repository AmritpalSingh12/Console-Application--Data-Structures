using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public interface IDataGatewayFacade
    {
        public int AddItem(Item item);
        public ItemDTO FindItem(int id);




        public Dictionary<int, ItemDTO> GetItems();




        public int AddQuantity(ItemDTO itemDTO);




        public int RemoveQuantity(ItemDTO itemDTO);



        public int AddEmployee(Employee e);




        public Employee FindEmployee(string EmpName);




        public int AddTransactionLog(TransactionLogEntry entry);



        public List<TransactionLogEntry> GetTransactionLog();

        public void InitialiseMySqlDatabase();

    }
}
