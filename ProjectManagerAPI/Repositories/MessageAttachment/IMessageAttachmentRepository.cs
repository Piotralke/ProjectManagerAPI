﻿using ProjectManagerAPI.Models;

public interface IMessageAttachmentRepository
{
	IEnumerable<MessageAttachment> GetMessageAttachments(Guid messageUuid);
	void AddAttachment(MessageAttachment attachment);
}