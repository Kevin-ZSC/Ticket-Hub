using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

namespace Ticket_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertTicketController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        // Constructor
        public ConcertTicketController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the Concert Ticket Info API");
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ConcertTicketInfo ticketInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           

            //post contact to queue

            string queueName = "tickethub";
            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(ticketInfo);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok(ticketInfo);
        }
    }
}
