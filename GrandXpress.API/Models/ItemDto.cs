using GrandXpress.Data.Entities;
using GrandXpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.Data.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public Receiver ReceiverDto { get; set; }
        public decimal Amount { get; set; }
    }
}
