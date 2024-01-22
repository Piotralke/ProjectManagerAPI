using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagerAPI.Controllers;
using ProjectManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerAPITests
{
	[TestFixture]
	public class GroupControllerTests
	{
		private Mock<IGroupService> _mockGroupService;
		private GroupController _groupController;

		[SetUp]
		public void Setup()
		{
			_mockGroupService = new Mock<IGroupService>();
			_groupController = new GroupController(_mockGroupService.Object);
		}
		[Test]
		public void GetAllGroups_ReturnsAllGroups()
		{
			var groups = new List<Group>
			{
				new Group { uuid = new Guid("7a4d4000-7102-4cc3-8b8b-aa1c14840629"), name= "3ID12A" },
				new Group { uuid = new Guid("995904f9-d380-4d0a-8f91-23be085d2008"), name = "5ed42" }
			};

			_mockGroupService.Setup(service => service.GetAllGroups()).Returns(groups);

			var result = _groupController.GetAllGroups();

			var okResult = result.Result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.IsInstanceOf<IEnumerable<Group>>(okResult.Value);
			Assert.AreEqual(groups, okResult.Value);
		}
		[Test]
		public void GetGroupsBySubject_ReturnsGroups()
		{
			var subjectId = new Guid("a82b8d66-190b-41ed-b661-d8b8dff1c13f");
			var groups = new List<Group>
			{
				new Group { uuid = new Guid("5858ee5f-43d4-4b55-8c87-bcfbc491a153") },
			};

			_mockGroupService.Setup(service => service.GetGroupsBySubject(subjectId)).Returns(groups);

			var result = _groupController.GetGroupsBySubject(subjectId);

			var okResult = result.Result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.IsInstanceOf<IEnumerable<Group>>(okResult.Value);
			Assert.AreEqual(groups, okResult.Value);
		}
	}
}
