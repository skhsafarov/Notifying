using Microsoft.AspNetCore.Mvc;
using Notifying.API.Models;
using Notifying.Infrastructure.Services;

namespace Notifying.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientsController : ControllerBase
    {
        private readonly IRecipientService _recipientService;

        public RecipientsController(IRecipientService recipientService)
        {
            _recipientService=recipientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipient>>> GetRecipients()
        {
            return Ok(_recipientService.GetRecipients().Result.Select(x => (Recipient)x));
        }

        [HttpPost]
        public async Task<ActionResult<Recipient>> PostRecipient(Recipient recipient)
        {
            var newRecipient = await _recipientService.CreateRecipient(recipient);
            return CreatedAtAction(nameof(GetRecipient), new { id = newRecipient.Id }, newRecipient);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipient>> GetRecipient(int id)
        {
            var recipient = await _recipientService.GetRecipient(id);
            if (recipient == null)
            {
                return NotFound();
            }
            return (Recipient)recipient;
        }

        [HttpPut]
        public async Task<IActionResult> PutRecipient(Recipient recipient)
        {
            await _recipientService.UpdateRecipient(recipient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipient(int id)
        {
            var recipient = await _recipientService.DeleteRecipient(id);
            if (recipient == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}