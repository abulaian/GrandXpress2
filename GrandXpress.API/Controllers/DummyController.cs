using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrandXpress.Data.Entities;
using GrandXpress.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandXpress.API.Controllers
{
    public class DummyController : Controller
    {
        private TransactionDbContext _ctx;

        public DummyController(TransactionDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("api/testDatabase")]
        public IActionResult Index()
        {
            //var sender = new Sender()
            //{
            //    Address1 = "100 temple st",
            //    Address2 = "apt 2",
            //    City = "Long Island",
            //    Country = "USA",
            //    FirstName = "Khalid",
            //    LastName = "Sayed",
            //    Phone = "2454785214",
            //    Receivers = new List<Receivers>()
            //    {
            //        new Receivers() { City="Khartoum", Country="Sudan", Phone="124954872154", FirstName="Mo",
            //         LastName = "Abd AlRazag"}
            //    }
            //};

            //Receivers receiver = new Receivers()
            //{
            //    City = "Medani",
            //    Country = "Sudan",
            //    Phone = "124954872154",
            //    FirstName = "Omar",
            //    LastName = "Mahasin"

            //};

            //Transaction transaction = new Transaction()
            //{
            //    CreatedDate = new DateTime(2018, 8, 1),
            //    Description = "test",
            //    Sender = sender,
            //    Items = new List<Item>() {
            //     new Item() {  Amount = 50, ReceiverId = 1} }
            //};

            //try
            //{

            //    _ctx.Senders.Add(sender);
            //    // _ctx.Senders.Find(5).Receivers.Add(receiver);
            //   // _ctx.Transactions.Add(transaction);
            //    _ctx.SaveChanges();
            //}
            //catch(DbUpdateException entEx)
            //{

            //}
            //catch(Exception ex)
            //{

            //}
            var trans = _ctx.Transactions.Include(s=> s.Sender).ToList();
            return Ok(trans);
        }
    }
}