using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerAPITests
{
	[TestFixture]
	public class ProjectProposalControllerTests
	{
		private Mock<IProjectProposalService> _mockProjectProposalService;
		private ProjectProposalController _projectProposalController;

		[SetUp]
		public void Setup()
		{
			_mockProjectProposalService = new Mock<IProjectProposalService>();
			_projectProposalController = new ProjectProposalController(_mockProjectProposalService.Object);
		}
		[Test]
		public void GetProjectProposal_ExistingId_ReturnsProposal()
		{
			var proposalId = Guid.NewGuid();
			var projectProposal = new ProjectProposal { uuid = new Guid("3e62ac1a-5ddb-4cdd-924a-4f029da6f27d") };

			_mockProjectProposalService.Setup(service => service.GetProjectProposalById(proposalId)).Returns(projectProposal);

			var result = _projectProposalController.GetProjectProposal(proposalId);

			var okResult = result.Result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.IsInstanceOf<ProjectProposal>(okResult.Value);
			Assert.AreEqual(projectProposal, okResult.Value);
		}

		[Test]
		public void GetProjectProposal_NonExistingId_ReturnsNotFound()
		{
			var proposalId = Guid.NewGuid();
			_mockProjectProposalService.Setup(service => service.GetProjectProposalById(proposalId)).Returns((ProjectProposal)null);

			var result = _projectProposalController.GetProjectProposal(proposalId);

			Assert.IsInstanceOf<NotFoundResult>(result.Result);
		}
	}
}
