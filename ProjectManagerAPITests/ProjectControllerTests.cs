using NUnit.Framework;
using Moq;
using ProjectManagerAPI.Controllers;
using ProjectManagerAPI.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;

namespace ProjectManagerAPITests
{
	[TestFixture]
	public class ProjectControllerTests
	{
		private Mock<IProjectService> _mockProjectService;
		private Mock<IGanntTaskService> _mockGanntTaskService;
		private Mock<IProjectEventService> _mockProjectEventService;
		private Mock<IUserEventService> _mockUserEventService;
		private ProjectController _projectController;

		[SetUp]
		public void Setup()
		{
			_mockProjectService = new Mock<IProjectService>();
			_mockGanntTaskService = new Mock<IGanntTaskService>();
			_mockProjectEventService = new Mock<IProjectEventService>();
			_mockUserEventService = new Mock<IUserEventService>();

			_projectController = new ProjectController(
				_mockProjectService.Object,
				_mockGanntTaskService.Object,
				_mockProjectEventService.Object,
				_mockUserEventService.Object
			);
		}

		[Test]
		public void GetProject_ExistingId_ReturnsProject()
		{
			var projectUuid = new Guid("785fbeb7-74c7-4968-abba-5fcc16090419");
			Project project = new Project
			{
				uuid = projectUuid
			};
			var projectDto = new ProjectDto(project);
			_mockProjectService.Setup(service => service.GetProjectById(projectUuid)).Returns(projectDto);
			var controller = _projectController;

			var result = controller.GetProject(projectUuid);

			var okResult = result.Result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.IsInstanceOf<ProjectDto>(okResult.Value);
			Assert.AreEqual(projectUuid, ((ProjectDto)okResult.Value).uuid);
		}

		[Test]
		public void GetProject_NonExistingId_ReturnsNotFound()
		{
			var projectUuid = Guid.NewGuid();
			_mockProjectService.Setup(service => service.GetProjectById(projectUuid)).Returns((ProjectDto)null);
			var controller = _projectController;
			var result = controller.GetProject(projectUuid);

			Assert.IsInstanceOf<NotFoundResult>(result.Result);
		}
	}
}