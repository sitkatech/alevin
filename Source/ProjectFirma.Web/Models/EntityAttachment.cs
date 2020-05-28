﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class EntityAttachment
    {
        private readonly string _deleteUrl;
        private readonly string _editUrl;
        private string _displayCssClass;

        public string GetDeleteUrl()
        {
            return _deleteUrl;
        }

        public string GetEditUrl()
        {
            return _editUrl;
        }

        public void SetDisplayCssClass(string value)
        {
            _displayCssClass = value;
        }

        public string GetDisplayCssClass()
        {
            return _displayCssClass;
        }

        public string DisplayName { get; set; }
        public string Description { get; set; }
        public FileResourceInfo FileResourceInfo { get; set; }
        public AttachmentType AttachmentType { get; set; }

        public EntityAttachment(string deleteUrl, string editUrl, FileResourceInfo fileResourceInfo, AttachmentType attachmentType, string displayCssClass,
            string displayName, string description)
        {
            _deleteUrl = deleteUrl;
            _editUrl = editUrl;
            FileResourceInfo = fileResourceInfo;
            SetDisplayCssClass(displayCssClass);
            DisplayName = displayName;
            Description = description;
            AttachmentType = attachmentType;
        }

        public static List<EntityAttachment> CreateFromProjectAttachment(IEnumerable<ProjectAttachment> projectAttachments)
        {
            return projectAttachments.Select(x => new EntityAttachment(x.GetDeleteUrl(), x.GetEditUrl(), x.Attachment, x.AttachmentType, null, x.DisplayName, x.Description)).ToList();
        }
        public static List<EntityAttachment> CreateFromProjectAttachment(IEnumerable<ProjectAttachmentUpdate> projectAttachments)
        {
            return projectAttachments.Select(x => new EntityAttachment(x.GetDeleteUrl(), x.GetEditUrl(), x.Attachment, x.AttachmentType, null, x.DisplayName, x.Description)).ToList();
        }

    }
}