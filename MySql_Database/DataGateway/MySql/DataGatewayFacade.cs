using Assignment.DTO;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class DataGatewayFacade : IDataGatewasyFacade
    {
        public int AddItem(Item item)
        {
          

            return new DatabaseOperationFactoryItem()
                .CreateInserter()
                .Insert(item);
        }
        
           
        

        public ItemDTO FindItem(int id)
        {
            return new DatabaseOperationFactoryItem()
                .CreateSelector(DatabaseOperationFactoryItem.FIND_ITEM_BY_ID, id)
                .Select();
        }

        public Dictionary<int, ItemDTO> GetItems()
        {
            return new DatabaseOperationFactoryItem()
                .CreateSelector(DatabaseOperationFactoryItem.SELECT_ALL_ITEM)
                .Select();
        }

        public int AddQuantity(ItemDTO itemDTO)
        {
            return new DatabaseOperationFactoryItem()
                .CreateUpdater(DatabaseOperationFactoryItem.UPDATE_ADD_QUANTITY)
                .Update(itemDTO);
        }





        public int RemoveQuantity(ItemDTO itemDTO)
        {
            return new DatabaseOperationFactoryItem()
                .CreateUpdater(DatabaseOperationFactoryItem.UPDATE_REMOVE_QUANTITY)
                .Update(itemDTO);
        }
        
            
        

        public int AddEmployee(Employee employee)
        {
            return new DatabaseOperationFactoryEmployee()
                .CreateInserter()
                .Insert(employee);
        }

        public Employee FindEmployee(string EmpName)
        {
            return new DatabaseOperationFactoryEmployee()
                .CreateSelector(DatabaseOperationFactoryEmployee.SELECT_ALL, EmpName)
                .Select();
        }

        public int AddTransactionLog(TransactionLogEntry entry)
        {
            return new DatabaseOperationFactoryTransactionLog()
                .CreateInserter()
                .Insert(entry);
        }

        public List<TransactionLogEntry> GetTransactionLog()
        {
            return new DatabaseOperationFactoryTransactionLog()
                .CreateSelector(DatabaseOperationFactoryTransactionLog.SELECT_ALL)
                .Select();
        }

       public void InitialiseMySqlDatabase()
        {
            new InitialisationGateway().InitialiseMySqlDatabase();
        }
    }
}
