using Assignment.DTO;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public interface IDataGatewasyFacade
    {
        public int AddItem(Item item);
        public ItemDTO FindItem(int id);




        public Dictionary<int, ItemDTO> GetItems();
        
            
        

        public int AddQuantity(ItemDTO itemDTO);




        public int RemoveQuantity(ItemDTO itemDTO);



        public int AddEmployee(Employee employee);




        public Employee FindEmployee(string EmpName);




        public int AddTransactionLog(TransactionLogEntry entry);




        public List<TransactionLogEntry> GetTransactionLog();

        public void InitialiseMySqlDatabase();
        
    }
}
