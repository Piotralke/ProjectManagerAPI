using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using ProjectManagerAPI.Data.Enum;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerAPI.Controllers
{
    [Route("api/chat")]
    [Authorize]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMessageService _messageService;
       
        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("GetProjectMessages/{projectId}")]
        public ActionResult<IEnumerable<MessageDto>> GetProjectMessages([FromRoute] Guid projectId) 
        {
            var messages = _messageService.GetProjectMessages(projectId);
            if(messages== null)
            {
                return NotFound("Messages not found");
            }
            return Ok(messages);
        }
        [HttpPost("SendMessage")]
        public ActionResult SendMessage([FromBody] CreateMessageDto message)
        {
            _messageService.SendMessage(message);
            if(_messageService.SaveChanges())
            {
                return Ok("Message send");
            }
            return BadRequest("Failed to send message");
        
        }
    }
}
