using GrandXpress.Data.Entities;
using GrandXpress.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender()
            {
                 Address1 = "1 temple st", Address2="apt 2", City="Long Beach", Country="USA",
                  FirstName = "Adams",  LastName="Lee", Phone="2454785214",
                Receivers = new List<Receiver>()
                {
                    new Receiver() { City="Khartoum", Country="Sudan", Phone="124954872154", FirstName="Mo",
                     LastName = "Derdairy"}
                }
            };

            Receiver receiver = new Receiver()
            {
                City = "Medani",
                Country = "Sudan",
                Phone = "124954872154",
                FirstName = "Omar",
                LastName = "Mahasin"
              
            };

            Transaction transaction = new Transaction()
            {
                CreatedDate = new DateTime(2018, 8, 1),
                Description = "test",
                Sender = sender,
              Amount = 50, ReceiverId = 1 
            };
            //using(var context = new TransactionDbContext())
            //{
            //  //    context.Senders.Add(sender);
            //    context.Senders.Find(5).Receivers.Add(receiver);
            //    //   context.Transactions.Add(transaction);
            //    var completeTransaction = context.Transactions
            //           .Include(t => t.Sender).Include(t => t.Receiver);
                   
                    
            //    context.SaveChanges();
            //}
            Console.WriteLine("Hello World!");
        }
    }
}
