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
	public class SubjectControllerTests
	{
		private Mock<ISubjectService> _mockSubjectService;
		private SubjectController _subjectController;

		[SetUp]
		public void Setup()
		{
			_mockSubjectService = new Mock<ISubjectService>();
			_subjectController = new SubjectController(_mockSubjectService.Object);
		}
		[Test]
		public void GetStudentSubjects_ReturnsSubjects()
		{
			var studentId = new Guid("975aace1-c9b3-479c-a91e-5157902f5eff");
			var subjects = new List<Subject>
	{
		new Subject { uuid=new Guid("a82b8d66-190b-41ed-b661-d8b8dff1c13f") },
	};

			_mockSubjectService.Setup(service => service.GetStudentSubjects(studentId)).Returns(subjects);

			var result = _subjectController.GetStudentSubjects(studentId);

			var okResult = result.Result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.IsInstanceOf<List<Subject>>(okResult.Value);
			Assert.AreEqual(subjects, okResult.Value);
		}

		[Test]
		public void GetStudentSubjects_NoSubjects_ReturnsNotFound()
		{
			var studentId = Guid.NewGuid();
			_mockSubjectService.Setup(service => service.GetStudentSubjects(studentId)).Returns((List<Subject>)null);

			var result = _subjectController.GetStudentSubjects(studentId);

			Assert.IsInstanceOf<NotFoundResult>(result.Result);
		}
	}
}
