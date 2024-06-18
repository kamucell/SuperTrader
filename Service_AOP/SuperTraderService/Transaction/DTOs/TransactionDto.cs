using Data.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraderService.Transaction.DTOs
{
    public class TransactionDto
    {
        public int ShareId { get; set; }
        public decimal Price { get; set; }
        public EnumTransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
