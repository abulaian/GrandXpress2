using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.API.Models
{
    public class TransactionForCreationDto
    {
        public string Name { get; set; }
        public decimal Amount { get { return Items.Sum(i => i.Amount); } }
        public string Description { get; set; }
        public ICollection<ItemForCreationDto> Items { get; set; } = new List<ItemForCreationDto>();
    }
}
