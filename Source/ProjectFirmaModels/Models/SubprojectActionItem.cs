﻿namespace ProjectFirmaModels.Models
{
    public partial class SubprojectActionItem : IAuditableEntity
    {
        

        public string GetAuditDescriptionString()
        {
            return $"Subproject Action Item: {SubprojectActionItemID}, SubprojectID: {SubprojectID}";
        }


    }
}