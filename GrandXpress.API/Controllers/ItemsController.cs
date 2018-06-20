using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrandXpress.API.Models;
using GrandXpress.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrandXpress.API.Controllers
{
    [Produces("application/json")]
    [Route("api/transactions")]
    public class ItemsController : Controller
    {
        private ILogger<ItemsController> _logger;

        public ItemsController(ILogger<ItemsController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{transactionId}/Items")]
        //1- trans id doesn't exist or null
        //2- there is no items, // there should be at least one item.
        public IActionResult GetItems(int transactionId)
        {
            //err msg should be carried from db.
            var transaction = TransDataStore.Current.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return NotFound();
            return Ok(transaction.Items);
        }
        [HttpGet("{transactionId}/Items/{id}", Name = "GetTransactionItem")]
        public IActionResult GetItem(int transactionId, int id)
        {
            try
            {
                var transaction = TransDataStore.Current.Transactions.FirstOrDefault(t => t.Id == transactionId);
                _logger.LogInformation($"transaction with id {transactionId} wasn't found!");
                if (transaction == null) return NotFound();
                var item = transaction.Items.FirstOrDefault(i => i.Id == id);
                if (item == null) return NotFound();
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Excepton from id {id} causing {ex.Message}");
                return StatusCode(500, "Error happened when retreiving resources");
            }
           
        }
        [HttpPost("{transactionId}/Itmes")]
        public IActionResult CreateItems(int transactionId, [FromBody] ItemForCreationDto item)
        {

            if (item == null) return BadRequest();
            var transaction = TransDataStore.Current.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            int maxItemsId = TransDataStore.Current.Transactions.SelectMany(t => t.Items).Max(i => i.Id);
            var newItem = new ItemForCreationDto
            {
                Id = ++maxItemsId,
                Amount = item.Amount, 
                Receiver = new ReceiverDto()
                {
                     Address1 = item.Receiver.Address1,
                     Address2 = item.Receiver.Address2,
                     City = item.Receiver.City,
                     Country = item.Receiver.Country,
                     FirstName = item.Receiver.FirstName,
                      LastName = item.Receiver.LastName,
                      Phone = item.Receiver.Phone
                }
            };
          //  transaction.Items.Add(newItem);
            return CreatedAtRoute("GetTransactionItem", new { transactionId, id = newItem.Id }, newItem);
        }
        [HttpPut("{transactionId}/Itmes/{id}")]
        public IActionResult UpdateItem(int transactionId, int id, [FromBody] ItemDto item)
        {
            if (item == null) return BadRequest();
            var transaction = TransDataStore.Current.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return NotFound();
            var updatedItem = transaction.Items.FirstOrDefault(i => i.Id == id);
            if (updatedItem == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            updatedItem.Amount = item.Amount;
            updatedItem.ReceiverDto.FirstName = item.ReceiverDto.FirstName;
            updatedItem.ReceiverDto.LastName = item.ReceiverDto.LastName;

            updatedItem.ReceiverDto.Phone = item.ReceiverDto.Phone;
            updatedItem.ReceiverDto.Country = item.ReceiverDto.Country;

            return NoContent();
        }
        [HttpPatch("{transactionId}/Itmes/{id}")]
        public IActionResult PartiallyUpdateItem(int transactionId, int id,
            [FromBody]JsonPatchDocument<ItemForUpdateDto> patchDoc)
        {
            if (patchDoc == null) return BadRequest();
            var transaction = TransDataStore.Current.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return NotFound();
            var itemFromTheStore = transaction.Items.FirstOrDefault(i => i.Id == id);
            if (itemFromTheStore == null) return NotFound();




            var itemToPatch = new ItemForUpdateDto()
            {
                Amount = itemFromTheStore.Amount,
                Receiver = new ReceiverDto()
                {
                     FirstName = itemFromTheStore.ReceiverDto.FirstName,
                     LastName = itemFromTheStore.ReceiverDto.LastName,
                     Phone = itemFromTheStore.ReceiverDto.Phone
                }
            };


            patchDoc.ApplyTo(itemToPatch, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (itemToPatch.Receiver.LastName == itemToPatch.Receiver.Country)
                ModelState.AddModelError("Reciever Name", "Receiver Name cannot be the same as country");

            TryValidateModel(itemToPatch);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            itemFromTheStore.Amount = itemToPatch.Amount;
            itemFromTheStore.ReceiverDto.FirstName = itemToPatch.Receiver.FirstName;
            itemFromTheStore.ReceiverDto.LastName = itemToPatch.Receiver.LastName;
            itemFromTheStore.ReceiverDto.Phone = itemToPatch.Receiver.Phone;
            return NoContent();
        }
        [HttpDelete("{transactionId}/itmes/{id}")]
        public IActionResult DeleteItem(int transactionId, int id)
        {
            var transaction = TransDataStore.Current.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return NotFound();
            var deletedItem = transaction.Items.FirstOrDefault(i => i.Id == id);
            if (deletedItem == null) return NotFound();

            transaction.Items.Remove(deletedItem);
            return NoContent();
        }
    }
}