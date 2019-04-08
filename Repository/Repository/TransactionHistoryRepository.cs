using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Service
{
    public class TransactionHistoryRepository : Repository<TransactionHistory>
    {
        public TransactionHistoryRepository() { }
        public TransactionHistoryRepository(ContextEntities context) : base(context)
        {
        }
    }
}
