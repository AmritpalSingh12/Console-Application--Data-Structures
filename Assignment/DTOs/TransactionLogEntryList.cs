using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class TransactionLogEntryList : DTO
    {
        public List<TransactionLogEntryDTO> List { get; }

        public TransactionLogEntryList(List<TransactionLogEntryDTO> list)
        {
            List = list;
        }
    }
}
