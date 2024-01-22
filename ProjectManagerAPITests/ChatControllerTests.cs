using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagerAPI.Controllers;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerAPITests
{
	[TestFixture]
	public class ChatControllerTests
	{
		private Mock<IMessageService> _mockMessageService;
		private Mock<IMessageAttachmentService> _mockAttachmentService;
		private ChatController _chatController;

		[SetUp]
		public void Setup()
		{
			_mockMessageService = new Mock<IMessageService>();
			_mockAttachmentService = new Mock<IMessageAttachmentService>();

			_chatController = new ChatController(
				_mockMessageService.Object,
				_mockAttachmentService.Object
			);
		}
		[Test]
		public void SendMessage_IsInstance_ReturnsOk()
		{
			var messageDto = new CreateMessageDto { };
			var message = new Message { };
			var formFiles = new List<IFormFile>(); 

			_mockMessageService.Setup(service => service.SendMessage(It.IsAny<CreateMessageDto>())).Returns(message);
			_mockMessageService.Setup(service => service.SaveChanges()).Returns(true);

			var result = _chatController.SendMessage(messageDto, formFiles);

			Assert.IsInstanceOf<OkObjectResult>(result);
		}
	}
}
