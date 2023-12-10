using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;
using System;

namespace ProjectManagerAPI.Dtos
{
    public class ProjectEventDto
    {
        
        public Guid uuid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dueTo { get; set; }
        public DateTime? startTime { get; set; }
        public EventStatus status { get; set; }
        public EventType type { get; set; }
        public Guid projectUuid { get; set; }

        public ProjectEventDto(ProjectEvents ev)
        {
            uuid= ev.uuid;
            title= ev.title;
            description= ev.description;
            dueTo= ev.dueTo;
            startTime= ev.startTime;
            status= ev.status;
            type= ev.type;
            projectUuid= ev.projectUuid;
        }
    }
    public class CreateProjectEventDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dueTo { get; set; }
        public DateTime? startTime { get; set; }
        public EventStatus status { get; set; }
        public EventType type { get; set; }
        public Guid projectUuid { get; set; }

        public CreateProjectEventDto(ProjectEvents ev)
        {
            title = ev.title;
            description = ev.description;
            dueTo = ev.dueTo;
            startTime = ev.startTime;
            status = ev.status;
            type = ev.type;
            projectUuid = ev.projectUuid;
        }
    }
    public class UpdateProjectEventDto
    {
        public Guid uuid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dueTo { get; set; }
        public DateTime? startTime { get; set; }
        public EventStatus status { get; set; }

    }
}
