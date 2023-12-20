using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using ProjectManagerAPI.Data.Enum;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using ProjectManagerAPI.Services;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerAPI.Controllers
{
    [Route("api/chat")]
    [Authorize]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMessageAttachmentRepository _attachmentRepository;
       
        public ChatController(IMessageService messageService, IMessageAttachmentRepository messageAttachmentRepository)
        {
            _messageService = messageService;
            _attachmentRepository = messageAttachmentRepository;
        }

        [HttpGet("GetProjectMessages/{projectId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetProjectMessages([FromRoute] Guid projectId) 
        {
            var messages = await _messageService.GetProjectMessagesAsync(projectId);
            if(messages== null)
            {
                return NotFound("Messages not found");
            }
            return Ok(messages);
        }
        [HttpPost("SendMessage")]
        public ActionResult SendMessage([FromForm] CreateMessageDto message, [FromForm] List<IFormFile> messageAttachments)
        {
            var createdMessage =  _messageService.SendMessage(message);
            if(message.hasAttachment)
            {
                foreach(var attachment in messageAttachments)
                {
                    MessageAttachmentDto attachmentDto = new MessageAttachmentDto
                    {
                        uuid = new Guid(),
                        fileName = Path.GetFileNameWithoutExtension(attachment.FileName),
                        fileType = Path.GetExtension(attachment.FileName),
                        filePath = "ProjectAttachments/" + message.projectUuid + "/" + attachment.FileName + "." + attachment.ContentType

                    };
                    MessageAttachment newAttachment = new MessageAttachment(attachmentDto, createdMessage.uuid);
                    _attachmentRepository.AddAttachment(newAttachment);
					SaveFileAndGetPath(attachment, message.projectUuid);
				}
            }
            if(_messageService.SaveChanges())
            {
                return Ok("Message send");
            }
            return BadRequest("Failed to send message");
        
        }
		[HttpGet("GetAttachmentContext")]
		public async Task<IActionResult> GetPicInfo([FromBody] MessageAttachmentDto attachment)
		{

			var imageFileStream = System.IO.File.OpenRead(attachment.filePath);

			using (MemoryStream memoryStream = new MemoryStream())
			{
				// Skopiuj zawartość pliku do pamięci
				await imageFileStream.CopyToAsync(memoryStream);

				// Konwertuj obraz do formatu base64
				var base64Image = Convert.ToBase64String(memoryStream.ToArray());

				// Zwróć base64 jako JSON
				return Ok(base64Image);
			}
		}
		private void SaveFileAndGetPath(IFormFile file, Guid projectUuid)
		{
			var fileExtension = Path.GetExtension(file.FileName);
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "ProjectAttachments", projectUuid.ToString());

			// Sprawdź, czy folder istnieje, jeśli nie, utwórz go
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			var filePath = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(file.FileName) + fileExtension);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
		}
	}
}
