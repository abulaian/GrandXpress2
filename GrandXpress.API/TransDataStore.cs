using GrandXpress.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.API
{
    public class TransDataStore
    {
        public static TransDataStore Current { get; } = new TransDataStore();
        public List<TransactionsDto> Transactions { get; set; } = new List<TransactionsDto>();

        //public List<TransactionsDto> Transactions { get; set; } = new List<TransactionsDto>
        //{
        //    new TransactionsDto{  Description = "first trans", Id = 1, Name = "Kobe Bryant", 
        //        Items = new List<ItemDto>()
        //        {
        //            new ItemDto(){ Amount = 10, Id = 1, ReceiverName = "Amanh Adam", ReceiverPhone="09125406532", RecevierCountry="Sudan" },
        //             new ItemDto(){ Amount = 20, Id = 2, ReceiverName = "Sarah Ali", ReceiverPhone="09125406532", RecevierCountry="Sudan" }
        //        }
        //   },
        //     new TransactionsDto{ Description = "second trans", Id = 2, Name = "Mohamed Ali",
        //        Items = new List<ItemDto>()
        //        {
        //            new ItemDto(){ Amount = 10, Id = 1, ReceiverName = "Amnah Adam", ReceiverPhone="09125406532", RecevierCountry="Sudan" },
        //             new ItemDto(){ Amount = 20, Id = 2, ReceiverName = "Sarah Ahmed", ReceiverPhone="09125406532", RecevierCountry="Sudan" },
        //                new ItemDto(){ Amount = 30, Id = 3, ReceiverName = "Mona Salah", ReceiverPhone="09125406532", RecevierCountry="Sudan" }
        //        }},
        //      new TransactionsDto{ Description = "third trans", Id = 3, Name = "Malcom X",
        //        Items = new List<ItemDto>()
        //        {
        //            new ItemDto(){ Amount = 100, Id = 1, ReceiverName = "Isam Isaac", ReceiverPhone="09125406532", RecevierCountry="Sudan" },
        //             new ItemDto(){ Amount = 200, Id = 2, ReceiverName = "Tariq Lee", ReceiverPhone="09125406532", RecevierCountry="Sudan" }
        //        }}
        //};


    }
}
