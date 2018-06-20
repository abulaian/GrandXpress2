using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrandXpress.API.Repositories;
using GrandXpress.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GrandXpress.API.Controllers
{
    [Route("api/transactions")]
    public class TransactionsController : Controller
    {
        private ITransactionRepo _repo;
        public TransactionsController(ITransactionRepo repo)
        {
            _repo = repo;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetTransactions()
        {
            return Ok(_repo.GetTransactions());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {

            var trans = _repo.GetTransactionWithReceiverAndSender(id);
            if (trans == null)
                return NotFound("Bad Request");
            return Ok(trans);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
