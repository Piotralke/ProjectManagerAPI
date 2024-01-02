using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using System;
using System.Collections.Generic;

[Route("api/subjects")]
[ApiController]
public class SubjectController : ControllerBase
{
	private readonly ISubjectService _subjectService;

	public SubjectController(ISubjectService subjectService)
	{
		_subjectService = subjectService;
	}

	[HttpGet]
	public ActionResult<IEnumerable<Subject>> GetAllSubjects()
	{
		var subjects = _subjectService.GetAllSubjects();
		return Ok(subjects);
	}

	[HttpGet("{uuid}")]
	public ActionResult<Subject> GetSubject(Guid uuid)
	{
		var subject = _subjectService.GetSubjectById(uuid);
		if (subject == null)
		{
			return NotFound();
		}
		return Ok(subject);
	}

	[HttpGet("get-teacher-subjects/{teacherId}")]
	public ActionResult<List<Subject>> GetTeacherSubjects([FromRoute] Guid teacherId)
	{
		var subjects = _subjectService.GetTeacherSubjects(teacherId);
		if (subjects == null)
		{
			return NotFound();
		}
		return Ok(subjects);
	}

	[HttpGet("get-group-subjects/{groupId}")]
	public ActionResult<List<Subject>> GetGroupSubjects([FromRoute] Guid groupId)
	{
		var subjects = _subjectService.GetGroupSubjects(groupId);
		if (subjects == null)
		{
			return NotFound();
		}
		return Ok(subjects);
	}

	[HttpPost]
	public ActionResult<Subject> AddSubject([FromBody] CreateSubjectDto subject)
	{
		var createdSubject = new Subject
		{
			uuid = Guid.NewGuid(),
			name = subject.Name,
			teacherUuid = subject.TeacherUuid,
			requirements = subject.Requirements,
		};

		_subjectService.AddSubject(createdSubject);
		foreach(Guid groupId in subject.GroupUuids)
		{
			var groupSubjectEntry = new GroupSubjects
			{
				uuid = Guid.NewGuid(),
				groupUuid = groupId,
				subjectUuid = createdSubject.uuid,
			};
			_subjectService.AddSubjectGroup(groupSubjectEntry);
		}

		if (_subjectService.SaveChanges())
		{
			return CreatedAtAction("GetSubject", new { uuid = createdSubject.uuid }, createdSubject);
		}
		return BadRequest("Failed to create subject.");
	}

	[HttpPut("{id}")]
	public void Put(int id, [FromBody] string value)
	{
		// Implementacja aktualizacji, jeśli potrzebna
	}

	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		// Implementacja usuwania, jeśli potrzebna
	}
}
