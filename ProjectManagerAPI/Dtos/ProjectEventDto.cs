using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;
using System;
using System.Text.Json.Serialization;

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
        public string? projectTitle { get; set; }
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
        [JsonPropertyName("title")]
        public string title { get; set; }
		[JsonPropertyName("description")]
		public string description { get; set; }
		[JsonPropertyName("dueTo")]
		public DateTime dueTo { get; set; }
		[JsonPropertyName("startTime")]
		public DateTime? startTime { get; set; }
		[JsonPropertyName("type")]
		public EventType type { get; set; }
		[JsonPropertyName("projectUuid")]
		public Guid projectUuid { get; set; }
        [JsonPropertyName("members")]
        public List<Guid> members { get; set; }
        public CreateProjectEventDto() { }
        //public CreateProjectEventDto(
        //    string title,
        //    string description,
        //    DateTime dueTo,
        //    DateTime startTime,
        //    EventType type, 
        //    Guid projectUuid)
        //{
        //    title = title;
        //    description = description;
        //    dueTo = dueTo;
        //    startTime = startTime;
        //    type = type;
        //    projectUuid = projectUuid;
        //}
        public CreateProjectEventDto(ProjectEvents ev)
        {
            title = ev.title;
            description = ev.description;
            dueTo = ev.dueTo;
            startTime = ev.startTime;
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
