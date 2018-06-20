using GrandXpress.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.API.Models
{
    public class TransactionsDto
    {
        public int Id { get; set; }
        public SenderDto Sender { get; set; } = new SenderDto();
        public int SenderId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CloseDate { get; set; }

        public decimal Amount { get; set; }
        public ReceiverDto Receiver { get; set; } = new ReceiverDto();
        public int ReceiverId { get; set; }

    }
}
